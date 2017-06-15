using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace Grc.Visitors.Cil
{
	public class Methods
	{
		private Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();

		private Stack<ILGenerator> il = new Stack<ILGenerator>();

		public MethodInfo this[string name]
		{
			get { return methods[name]; }
			set { methods[name] = value; }
		}

		public ILGenerator IL { get { return il.Peek(); } }

		public MethodBuilder Enter(string name)
		{
			MethodBuilder methodBuilder = typeBuilder.DefineMethod(name, MethodAttributes.Private | MethodAttributes.Static);

			methods[name] = methodBuilder;

			il.Push(methodBuilder.GetILGenerator());

			return methodBuilder;
		}

		public void Exit()
		{
			il.Pop();
		}

		private TypeBuilder typeBuilder;

		public Methods(TypeBuilder typeBuilder)
		{
			this.typeBuilder = typeBuilder;

			EmitPuti();
			EmitPutc();
		}

		private void EmitPuti()
		{
			MethodBuilder methodBuilder = Enter("_puti");

			methodBuilder.SetParameters(new Type[] { typeof(int) });

			methodBuilder.SetReturnType(typeof(void));

			methods["_puti"] = methodBuilder;

			IL.Emit(OpCodes.Ldarg, 0);

			MethodInfo methodInfo = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) });

			IL.Emit(OpCodes.Call, methodInfo);

			IL.Emit(OpCodes.Ret);
		}

		private void EmitPutc()
		{
			MethodBuilder methodBuilder = Enter("_putc");

			methodBuilder.SetParameters(new Type[] { typeof(char) });

			methodBuilder.SetReturnType(typeof(void));

			methods["_putc"] = methodBuilder;

			IL.Emit(OpCodes.Ldarg, 0);

			MethodInfo methodInfo = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(char) });

			IL.Emit(OpCodes.Call, methodInfo);

			IL.Emit(OpCodes.Ret);
		}
	}
}
