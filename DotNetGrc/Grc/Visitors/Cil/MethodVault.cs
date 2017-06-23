using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace Grc.Visitors.Cil
{
	public class MethodVault : Dictionary<string, MethodBuilder>
	{
		private TypeBuilder typeBuilder;

		private Stack<ILGenerator> stackCil = new Stack<ILGenerator>();

		public ILGenerator Cil { get { return stackCil.Peek(); } }

		public void Enter(string method, Type returnType, Type[] paramTypes, IEnumerable<string> paramNames)
		{
			if (this.Keys.Contains(method))
			{
				stackCil.Push(this[method].GetILGenerator());

				return;
			}

			MethodAttributes attributes = MethodAttributes.Private | MethodAttributes.Static;

			MethodBuilder methodBuilder = typeBuilder.DefineMethod(method, attributes, returnType, paramTypes);

			int i = 1;

			foreach (string name in paramNames)
				methodBuilder.DefineParameter(i++, ParameterAttributes.None, name);

			this[method] = methodBuilder;

			stackCil.Push(methodBuilder.GetILGenerator());
		}

		public void Exit()
		{
			stackCil.Pop();
		}

		public void CreateType()
		{
			typeBuilder.CreateType();
		}

		public MethodVault(TypeBuilder typeBuilder)
		{
			this.typeBuilder = typeBuilder;

			EmitPuti();
			EmitPutc();
			EmitPuts();

			EmitGeti();
			EmitGetc();
			EmitGets();

			EmitAbs();
			EmitOrd();
			EmitChr();

			EmitStrLen();
			EmitStrCmp();
		}

		private void EmitPuti()
		{
			Enter("_puti", typeof(void), new Type[] { typeof(int) }, new string[] { "i" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("PutInt", new Type[] { typeof(int) }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitPutc()
		{
			Enter("_putc", typeof(void), new Type[] { typeof(byte) }, new string[] { "c" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("PutChar", new Type[] { typeof(byte) }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitPuts()
		{
			Enter("_puts", typeof(void), new Type[] { typeof(byte).MakePointerType() }, new string[] { "p" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("PutStr", new Type[] { typeof(byte).MakePointerType() }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitGeti()
		{
			Enter("_geti", typeof(int), new Type[] { }, new string[] { });

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("GetInt", new Type[] { }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitGetc()
		{
			Enter("_getc", typeof(byte), new Type[] { }, new string[] { });

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("GetChar", new Type[] { }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitGets()
		{
			Enter("_gets", typeof(void), new Type[] { typeof(int), typeof(byte).MakePointerType() }, new string[] { "n", "p" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldarg, 1);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("GetStr", new Type[] { typeof(int), typeof(byte).MakePointerType() }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitAbs()
		{
			Enter("_abs", typeof(int), new Type[] { typeof(int) }, new string[] { "i" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("IntGetAbs", new Type[] { typeof(int) }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitOrd()
		{
			Enter("_ord", typeof(int), new Type[] { typeof(byte) }, new string[] { "c" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("CharGetOrd", new Type[] { typeof(byte) }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitChr()
		{
			Enter("_chr", typeof(byte), new Type[] { typeof(int) }, new string[] { "i" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("IntGetChar", new Type[] { typeof(int) }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitStrLen()
		{
			Enter("_strlen", typeof(int), new Type[] { typeof(byte).MakePointerType() }, new string[] { "p" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("StrLen", new Type[] { typeof(byte).MakePointerType() }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitStrCmp()
		{
			Enter("_strcmp", typeof(int), new Type[] { typeof(byte).MakePointerType(), typeof(byte).MakePointerType() }, new string[] { "p1", "p2" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldarg, 1);

			Cil.Emit(OpCodes.Call, typeof(IO).GetMethod("StrCmp", new Type[] { typeof(byte).MakePointerType(), typeof(byte).MakePointerType() }));

			Cil.Emit(OpCodes.Ret);

			Exit();
		}
	}
}
