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

			EmitStrLen();
		}

		private void EmitPuti()
		{
			Enter("_puti", typeof(void), new Type[] { typeof(int) }, new string[] { "i" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, MethodLibrary.Instance["Console.Write"]);

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitPutc()
		{
			Enter("_putc", typeof(void), new Type[] { typeof(char) }, new string[] { "c" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, MethodLibrary.Instance["Console.Write"]);

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitPuts()
		{
			Enter("_puts", typeof(void), new Type[] { typeof(byte[]) }, new string[] { "s" });

			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];
			MethodInfo stringReplace = MethodLibrary.Instance["String.Replace"];
			MethodInfo consoleWrite = MethodLibrary.Instance["Console.Write"];

			Cil.Emit(OpCodes.Call, encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);


			EmitEscapedTab();

			EmitTab();

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			EmitEscapedNewLine();

			EmitNewLine();

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			EmitEscapedQuote();

			EmitQuote();

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			EmitEscapedBackSlash();

			EmitBackSlash();

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			Cil.Emit(OpCodes.Call, consoleWrite);

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitEscapedBackSlash()
		{
			EmitEscaped(92); // \\
		}

		private void EmitBackSlash()
		{
			Emit(92); // \
		}

		private void EmitEscapedQuote()
		{
			EmitEscaped(34); // \"
		}

		private void EmitQuote()
		{
			Emit(34); // "
		}

		private void EmitEscapedNewLine()
		{
			EmitEscaped(110); // \n
		}

		private void EmitNewLine()
		{
			Emit(10); // <10>
		}

		private void EmitEscapedTab()
		{
			EmitEscaped(116);  // \t
		}

		private void EmitTab()
		{
			Emit(9); // <9>
		}

		private void EmitEscaped(int c)
		{
			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];

			Cil.Emit(OpCodes.Ldc_I4, 2);

			Cil.Emit(OpCodes.Newarr, typeof(byte));

			Cil.Emit(OpCodes.Starg, 0);


			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldc_I4, 0);

			Cil.Emit(OpCodes.Ldc_I4, 92);

			Cil.Emit(OpCodes.Stelem_I1);


			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldc_I4, 1);

			Cil.Emit(OpCodes.Ldc_I4, c);

			Cil.Emit(OpCodes.Stelem_I1);


			Cil.Emit(OpCodes.Call, encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);
		}

		private void Emit(int c)
		{
			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];

			Cil.Emit(OpCodes.Ldc_I4, 1);

			Cil.Emit(OpCodes.Newarr, typeof(byte));

			Cil.Emit(OpCodes.Starg, 0);


			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldc_I4, 0);

			Cil.Emit(OpCodes.Ldc_I4, c);

			Cil.Emit(OpCodes.Stelem_I1);


			Cil.Emit(OpCodes.Call, encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);
		}

		private void EmitStrLen()
		{
			Enter("_strlen", typeof(int), new Type[] { typeof(byte[]) }, new string[] { "s" });

			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];

			MethodInfo stringGetLength = MethodLibrary.Instance["String.get_Length"];

			Cil.Emit(OpCodes.Call, encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);

			Cil.Emit(OpCodes.Callvirt, stringGetLength);

			Cil.Emit(OpCodes.Ret);
		}
	}
}
