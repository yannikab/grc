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

		public MethodVault(TypeBuilder typeBuilder, bool unicode)
		{
			this.typeBuilder = typeBuilder;

			EmitPuti();
			EmitPutc();
			EmitPuts(unicode);

			EmitStrLen(unicode);
		}

		private void EmitPuti()
		{
			Enter("_puti", typeof(void), new Type[] { typeof(int) }, new string[] { "i" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, MethodLibrary.Instance["Console.WriteInt"]);

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitPutc()
		{
			Enter("_putc", typeof(void), new Type[] { typeof(char) }, new string[] { "c" });

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Call, MethodLibrary.Instance["Console.WriteChar"]);

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitPuts(bool unicode)
		{
			Enter("_puts", typeof(void), new Type[] { typeof(byte[]) }, new string[] { "s" });

			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetUnicode = MethodLibrary.Instance["Encoding.get_Unicode"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];
			MethodInfo stringReplace = MethodLibrary.Instance["String.Replace"];
			MethodInfo consoleWriteString = MethodLibrary.Instance["Console.WriteString"];

			Cil.Emit(OpCodes.Call, unicode ? encodingGetUnicode : encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);

			EmitEscapedTab(unicode);

			EmitTab(unicode);

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			EmitEscapedNewLine(unicode);

			EmitNewLine(unicode);

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			EmitEscapedQuote(unicode);

			EmitQuote(unicode);

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			EmitEscapedBackSlash(unicode);

			EmitBackSlash(unicode);

			Cil.Emit(OpCodes.Callvirt, stringReplace);


			Cil.Emit(OpCodes.Call, consoleWriteString);

			Cil.Emit(OpCodes.Ret);

			Exit();
		}

		private void EmitEscapedBackSlash(bool unicode)
		{
			EmitEscaped(92, unicode); // \\
		}

		private void EmitBackSlash(bool unicode)
		{
			Emit(92, unicode); // \
		}

		private void EmitEscapedQuote(bool unicode)
		{
			EmitEscaped(34, unicode); // \"
		}

		private void EmitQuote(bool unicode)
		{
			Emit(34, unicode); // "
		}

		private void EmitEscapedNewLine(bool unicode)
		{
			EmitEscaped(110, unicode); // \n
		}

		private void EmitNewLine(bool unicode)
		{
			Emit(10, unicode); // <10>
		}

		private void EmitEscapedTab(bool unicode)
		{
			EmitEscaped(116, unicode);  // \t
		}

		private void EmitTab(bool unicode)
		{
			Emit(9, unicode); // <9>
		}

		private void EmitEscaped(int c, bool unicode)
		{
			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetUnicode = MethodLibrary.Instance["Encoding.get_Unicode"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];

			Cil.Emit(OpCodes.Ldc_I4, unicode ? 4 : 2);

			Cil.Emit(OpCodes.Newarr, typeof(byte));

			Cil.Emit(OpCodes.Starg, 0);

			int i = 0;

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldc_I4, i++);

			Cil.Emit(OpCodes.Ldc_I4, 92);

			Cil.Emit(OpCodes.Stelem_I1);

			if (unicode)
			{
				Cil.Emit(OpCodes.Ldarg, 0);

				Cil.Emit(OpCodes.Ldc_I4, i++);

				Cil.Emit(OpCodes.Ldc_I4, 0);

				Cil.Emit(OpCodes.Stelem_I1);
			}

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldc_I4, i++);

			Cil.Emit(OpCodes.Ldc_I4, c);

			Cil.Emit(OpCodes.Stelem_I1);

			if (unicode)
			{
				Cil.Emit(OpCodes.Ldarg, 0);

				Cil.Emit(OpCodes.Ldc_I4, i++);

				Cil.Emit(OpCodes.Ldc_I4, 0);

				Cil.Emit(OpCodes.Stelem_I1);
			}

			Cil.Emit(OpCodes.Call, unicode ? encodingGetUnicode : encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);
		}

		private void Emit(int c, bool unicode)
		{
			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetUnicode = MethodLibrary.Instance["Encoding.get_Unicode"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];

			Cil.Emit(OpCodes.Ldc_I4, unicode ? 2 : 1);

			Cil.Emit(OpCodes.Newarr, typeof(byte));

			Cil.Emit(OpCodes.Starg, 0);

			int i = 0;

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Ldc_I4, i++);

			Cil.Emit(OpCodes.Ldc_I4, c);

			Cil.Emit(OpCodes.Stelem_I1);

			if (unicode)
			{
				Cil.Emit(OpCodes.Ldarg, 0);

				Cil.Emit(OpCodes.Ldc_I4, i++);

				Cil.Emit(OpCodes.Ldc_I4, 0);

				Cil.Emit(OpCodes.Stelem_I1);
			}

			Cil.Emit(OpCodes.Call, unicode ? encodingGetUnicode : encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);
		}

		private void EmitStrLen(bool unicode)
		{
			Enter("_strlen", typeof(int), new Type[] { typeof(byte[]) }, new string[] { "s" });

			MethodInfo encodingGetASCII = MethodLibrary.Instance["Encoding.get_ASCII"];
			MethodInfo encodingGetUnicode = MethodLibrary.Instance["Encoding.get_Unicode"];
			MethodInfo encodingGetString = MethodLibrary.Instance["Encoding.GetString"];
			MethodInfo stringGetLength = MethodLibrary.Instance["String.get_Length"];

			Cil.Emit(OpCodes.Call, unicode ? encodingGetUnicode : encodingGetASCII);

			Cil.Emit(OpCodes.Ldarg, 0);

			Cil.Emit(OpCodes.Callvirt, encodingGetString);

			Cil.Emit(OpCodes.Callvirt, stringGetLength);

			Cil.Emit(OpCodes.Ret);
		}
	}
}
