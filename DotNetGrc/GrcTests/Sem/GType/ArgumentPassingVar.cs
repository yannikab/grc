using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Visitor.Exceptions.GType;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		[Test]
		public void TestPassingVarFunctionCallExprWrongNumberArguments()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun boo(p : char) : int
	{
		return 0;
	}
{
	a <- boo(3, 'a');
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarFunctionCallExprWrongTypeArguments()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun boo(p : char; i : int) : int
	{
		return 0;
	}
{
	a <- boo('b', 'c');
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarLiteralIntByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : int) : nothing
	{
	}
{
	boo(5);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarLiteralCharByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char) : nothing
	{
	}
{
	boo('t');
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarExprIntByRef1()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref a : int) : nothing
	{
	}
{
	boo(i + 1);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarExprIntByRef2()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref a : int) : nothing
	{
	}
{
	boo(1 + i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarExprIntByRef3()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref a : int) : nothing
	{
	}
{
	boo(+ i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarExprIntByRef4()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref a : int) : nothing
	{
	}
{
	boo(- i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarArrayElement()
		{
			string program = @"

fun program() : nothing

	var c : char[10];

	fun boo(ref a : char) : nothing
	{
	}

	fun far(a : char) : nothing
	{
	}
{
	boo(c[0]);

	far(c[0]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestPassingVarStringElement()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char) : nothing
	{
	}

	fun far(a : char) : nothing
	{
	}
{
	boo(""hello""[2]);

	far(""hello""[2]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArrayArrayElement()
		{
			string program = @"

fun program() : nothing

	var c : char[10][5];

	fun boo(ref a : char) : nothing
	{
	}

	fun far(a : char) : nothing
	{
	}
{
	boo(c[0][2]);

	far(c[0][2]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArray()
		{
			string program = @"

fun program() : nothing

	var arr : char[5];

	fun boo(ref a : char []) : nothing
	{
	}
{
	boo(arr);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArrayElementArray()
		{
			string program = @"

fun program() : nothing

	var c : char[10][5];

	fun boo(ref a : char[]) : nothing
	{
	}
{
	boo(c[0]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArrayWithSize()
		{
			string program = @"

fun program() : nothing

	var arr : char[5];

	fun boo(ref a : char [10]) : nothing
	{
	}
{
	boo(arr);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArrayElementArrayWithSize()
		{
			string program = @"

fun program() : nothing

	var c : char[10][5];

	fun boo(ref a : char[10]) : nothing
	{
	}
{
	boo(c[0]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarFunctionCallByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char) : nothing
	{
	}

	fun far() : char
	{
		return 'c';
	}
{
	boo(far());
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}
	}
}
