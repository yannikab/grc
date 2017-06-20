using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using Grc.Nodes;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Quads;
using Grc.Quads.Addr;
using Grc.Quads.Op;
using Grc.Types;
using Grc.Visitors.Ast;

namespace Grc.Visitors.Cil
{
	public class CilVisitor : DepthFirstVisitorDefaults
	{
		private bool unicode = false;

		private bool outputEncodingSet;

		private void SetOutputEncoding()
		{
			if (outputEncodingSet)
				return;

			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetUnicode = MethodLibrary.Instance["Encoding.get_Unicode"];
			MethodInfo consoleSetOutputEncoding = MethodLibrary.Instance["Console.set_OutputEncoding"];

			Cil.Emit(OpCodes.Call, unicode ? encodingGetUnicode : encodingGetASCII);

			Cil.Emit(OpCodes.Call, consoleSetOutputEncoding);

			outputEncodingSet = true;
		}

		private MethodVault methodVault;

		private ILGenerator Cil { get { return methodVault.Cil; } }

		private void Enter(LocalFuncDecl n)
		{
			Type returnType = (n.Type as TypeFunction).To.DotNetType;

			List<Type> paramTypes = new List<Type>();
			List<string> paramNames = new List<string>();

			foreach (var p in n.Parameters.OrderBy(p => p.Name))
			{
				TypeIndexed typeIndexed = p.Type as TypeIndexed;

				if (typeIndexed != null)
					paramTypes.Add(typeIndexed.DotNetElementType.MakePointerType());
				else if (p.ByRef)
					paramTypes.Add(p.Type.DotNetType.MakeByRefType());
				else
					paramTypes.Add(p.Type.DotNetType);

				paramNames.Add(p.Name);
			}

			methodVault.Enter(n.Name, returnType, paramTypes.ToArray(), paramNames);
		}

		private void Exit()
		{
			methodVault.Exit();
		}

		public override void Pre(Root n)
		{
			string programName = n.Program.Locals.OfType<LocalFuncDef>().First().Header.Name.Remove(0, 2);

			n.AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName(programName), AssemblyBuilderAccess.RunAndSave);

			ModuleBuilder module = n.AssemblyBuilder.DefineDynamicModule(programName, string.Format("{0}.exe", programName), true);

			string contextName = string.Format("{0}.{1}", programName, n.Program.Header.Name);

			methodVault = new MethodVault(module.DefineType(contextName, TypeAttributes.NotPublic), unicode);
		}

		public override void Post(Root n)
		{
			n.AssemblyBuilder.SetEntryPoint(methodVault[n.Program.Header.Name]);

			methodVault.CreateType();

			n.AssemblyBuilder.Save(string.Format("{0}.exe", n.AssemblyBuilder.GetName().Name));
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			InHeaderLocals(n);

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			InLocalsBlock(n);

			n.Block.Accept(this);

			Post(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			Enter(n.Header);

			SetOutputEncoding();

			if (n.Parent is Root)
				return;

			n.OwnTac.First().Emit(Cil);

			var parameters = n.Header.Parameters.OrderBy(p => p.Name).ToList();

			IEnumerable<AddrSym> args = n.Tac.Select(q => q.Addrs).SelectMany(x => x).OfType<AddrArg>();

			var qArgs = from p in parameters
						join a in args
						on p.Name equals a.Name
						group a by p into g
						select new
						{
							Param = g.Key,
							Addrs = g,
							Index = parameters.IndexOf(g.Key)
						};

			foreach (var g in qArgs)
				foreach (var a in g.Addrs)
					a.Index = g.Index;

			IEnumerable<AddrSym> vars = n.Tac.Select(q => q.Addrs).SelectMany(x => x).OfType<AddrLoc>();
			IEnumerable<AddrSym> tmps = n.Tac.Select(q => q.Addrs).SelectMany(x => x).OfType<AddrTmp>();

			var qLocals = from a in vars.Concat(tmps.Distinct())
						  group a by new
						  {
							  Class = a.GetType(),
							  Type = a.Type,
							  Name = a.Name,
							  OrderName = a.Name.StartsWith("$") ? a.Name.Remove(0, 1).PadLeft(6, '0') : a.Name
						  } into g
						  orderby g.Key.Class.Name, g.Key.OrderName
						  select new
						  {
							  Class = g.Key.Class,
							  Type = g.Key.Type,
							  Name = g.Key.Name,
							  Addrs = g
						  };

			int index = 0;

			foreach (var g in qLocals)
			{
				foreach (var a in g.Addrs)
					a.Index = index;

				Type type = null;

				TypeIndexed typeAsIndexed = g.Type as TypeIndexed;

				if (g.Class.Equals(typeof(AddrLoc)))
				{
					type = typeAsIndexed != null ? typeAsIndexed.DotNetElementType.MakePointerType() : g.Type.DotNetType;
				}
				else if (g.Class.Equals(typeof(AddrTmp)))
				{
					type = g.Type.ByRef ? g.Type.DotNetType.MakePointerType() : g.Type.DotNetType;
				}

				LocalBuilder localBuilder = Cil.DeclareLocal(type);

				localBuilder.SetLocalSymInfo(g.Name);

				if (typeAsIndexed != null && g.Class.Equals(typeof(AddrLoc)))
				{
					Cil.Emit(OpCodes.Ldc_I4, typeAsIndexed.TotalElements);

					Cil.Emit(OpCodes.Newarr, typeAsIndexed.DotNetElementType);

					Cil.Emit(OpCodes.Stloc, index);
				}

				index++;
			}

			IEnumerable<AddrString> strings = n.Tac.Select(q => q.Addrs).SelectMany(x => x).OfType<AddrString>();

			foreach (var s in strings)
			{
				TypeIndexed typeIndexed = (TypeIndexed)s.Type;

				s.Index = index;

				LocalBuilder localBuilder = Cil.DeclareLocal(typeIndexed.DotNetElementType.MakePointerType());

				localBuilder.SetLocalSymInfo(string.Format("_{0}", index));


				Cil.Emit(OpCodes.Ldc_I4, typeIndexed.ByteSize);

				Cil.Emit(OpCodes.Newarr, typeIndexed.DotNetElementType);

				Cil.Emit(OpCodes.Stloc, index);

				for (int i = 0; i < s.Text.Length + 1; i++)
				{
					Cil.Emit(OpCodes.Ldloc, index);
					Cil.Emit(OpCodes.Ldc_I4, i * typeIndexed.IndexedType.ByteSize);
					Cil.Emit(OpCodes.Add);

					if (i < s.Text.Length)
						Cil.Emit(OpCodes.Ldc_I4, (int)s.Text[i]);
					else
						Cil.Emit(OpCodes.Ldc_I4, 0);

					Cil.Emit((typeIndexed.IndexedType as TypeData).StIndirectOp);
				}

				index++;
			}

			IEnumerable<Quad> jumpTargets = (from q in n.Tac
											 select q.Addrs.OfType<AddrQuad>()).
											 SelectMany(x => x).Select(a => a.Quad).Distinct();

			foreach (Quad q in jumpTargets)
				q.DefineLabel(Cil);
		}

		public override void Post(LocalFuncDef n)
		{
			n.OwnTac.Last().Emit(Cil);

			methodVault.Exit();
		}

		public override void Pre(LocalFuncDecl n)
		{
			Enter(n);

			Exit();
		}

		public override void Post(ExprFuncCall n)
		{
			Quad call = n.OwnTac.Single(q => q.Op is OpCall);

			AddrFunc addrFunc = call.Res as AddrFunc;

			addrFunc.MethodInfo = methodVault[addrFunc.Name];

			Quad retVal = n.OwnTac.SingleOrDefault(q => q.Op is OpParRet);

			IEnumerable<Quad> args = n.OwnTac.Where(q => q.Op is OpParArg);

			foreach (var q in args)
				q.Emit(Cil);

			call.Emit(Cil);

			if (retVal != null)
				retVal.Emit(Cil);
		}

		public override void DefaultPost(NodeBase n)
		{
			foreach (Quad q in n.OwnTac)
				q.Emit(Cil);
		}

		public override void InThenElse(StmtIfThenElse n)
		{
			n.OwnTac.Single().Emit(Cil);
		}

		public override void Post(StmtIfThenElse n)
		{
			return;
		}
	}
}
