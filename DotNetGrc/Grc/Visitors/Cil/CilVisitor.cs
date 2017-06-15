using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Quads;
using Grc.Quads.Addr;
using Grc.Types;
using Grc.Visitors.Ast;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Grc.Visitors.Cil
{
	public class CilVisitor : DepthFirstVisitorDefaults
	{
		public TypeBuilder contextBuilder;

		private ILGenerator ilg;

		private Methods methods;

		private MethodBuilder CreateMethod(string name)
		{
			MethodBuilder methodBuilder = contextBuilder.DefineMethod(name, MethodAttributes.Private | MethodAttributes.Static);

			methods[name] = methodBuilder;

			ilg = methodBuilder.GetILGenerator();

			return methodBuilder;
		}

		public override void Pre(Root n)
		{
			string programName = n.Program.Locals.OfType<LocalFuncDef>().First().Header.Name.Remove(0, 2);

			n.AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName(programName), AssemblyBuilderAccess.RunAndSave);

			ModuleBuilder module = n.AssemblyBuilder.DefineDynamicModule(programName, string.Format("{0}.exe", programName), true);

			string contextName = string.Format("{0}.{1}", programName, n.Program.Header.Name);

			contextBuilder = module.DefineType(contextName, TypeAttributes.NotPublic);

			methods = new Methods(contextBuilder);
		}

		public override void Post(Root n)
		{
			MethodBuilder mainBuilder = CreateMethod("main");

			mainBuilder.SetReturnType(typeof(void));

			mainBuilder.SetParameters();

			ilg.EmitCall(OpCodes.Call, methods[n.Program.Locals.OfType<LocalFuncDef>().First().Header.Name], null);

			ilg.Emit(OpCodes.Ret);

			n.AssemblyBuilder.SetEntryPoint(mainBuilder);

			contextBuilder.CreateType();

			n.AssemblyBuilder.Save(string.Format("{0}.exe", n.AssemblyBuilder.GetName().Name));
		}

		public override void Visit(LocalFuncDef n)
		{
			if (n.Parent is LocalFuncDef)
				Pre(n);

			n.Header.Accept(this);

			InHeaderLocals(n);

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			InLocalsBlock(n);

			if (n.Parent is LocalFuncDef)
				n.Block.Accept(this);

			if (n.Parent is LocalFuncDef)
				Post(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			base.Pre(n);

			IEnumerable<AddrSym> args = n.Tac.Select(q => q.Addrs).SelectMany(x => x).OfType<AddrArg>();

			var parameters = n.Header.Parameters.ToList();

			var qArgs = from p in parameters
					 	join a in args
						on p.Name equals a.Name
						group a by new { Param = p, Type = a.Type } into g
						orderby parameters.IndexOf(g.Key.Param)
						select new
						{
							Name = g.Key.Param.Name,
							Type = g.Key.Type,
							Index = parameters.IndexOf(g.Key.Param),
							Addrs = g.ToList()
						};

			MethodBuilder methodBuilder = CreateMethod(n.Header.Name);

			methodBuilder.SetParameters(qArgs.Select(a => a.Type.DotNetType).ToArray());

			foreach (var g in qArgs)
			{
				methodBuilder.DefineParameter(g.Index + 1, ParameterAttributes.None, g.Name);

				foreach (var a in g.Addrs)
					a.Index = g.Index;
			}

			methodBuilder.SetReturnType(((TypeFunction)n.Type).To.DotNetType);

			IEnumerable<AddrSym> vars = n.Tac.Select(q => q.Addrs).SelectMany(x => x).OfType<AddrLoc>();
			IEnumerable<AddrTmp> temps = n.Tac.Select(q => q.Addrs).SelectMany(x => x).OfType<AddrTmp>();

			var qLocals = from a in vars.Concat(temps.Distinct())
						  group a by new { Class = a.GetType().Name, Type = a.Type, Name = a.Name } into g
						  orderby g.Key.Class, g.Key.Name
						  select new
						  {
							  Name = g.Key.Name,
							  Type = g.Key.Type,
							  Addrs = g
						  };

			int index = 0;

			foreach (var g in qLocals)
			{
				foreach (var a in g.Addrs)
					a.Index = index;

				LocalBuilder localBuilder = ilg.DeclareLocal(g.Type.DotNetType);

				localBuilder.SetLocalSymInfo(g.Name);

				TypeIndexed typeAsIndexed = g.Type as TypeIndexed;

				if (typeAsIndexed != null)
				{
					int length = 1;

					TypeBase indexedType;

					do
					{
						length *= typeAsIndexed.Dim;

						indexedType = typeAsIndexed.IndexedType;

						typeAsIndexed = indexedType as TypeIndexed;

					} while (typeAsIndexed != null);

					ilg.Emit(OpCodes.Ldc_I4, length);

					ilg.Emit(OpCodes.Newarr, indexedType.DotNetType);

					ilg.Emit(OpCodes.Stloc, index);
				}

				index++;
			}

			IEnumerable<Quad> jumpTargets = (from q in n.Tac
											 select q.Addrs.OfType<AddrQuad>()).
											 SelectMany(x => x).Select(a => a.Quad).Distinct();

			foreach (Quad q in jumpTargets)
				q.DefineLabel(ilg);
		}

		public override void Post(ExprFuncCall n)
		{
			foreach (var q in n.Tac)
			{
				AddrFunc addrFunc = q.Res as AddrFunc;

				if (addrFunc != null)
					addrFunc.MethodInfo = methods[addrFunc.Name];

				q.Emit(ilg);
			}
		}

		public override void DefaultPost(NodeBase n)
		{
			foreach (Quad q in n.OwnTac)
				q.Emit(ilg);
		}
	}
}
