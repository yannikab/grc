using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable;
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
	
	fun foo(p : char) : int
	{
		return 0;
	}
{
	a <- foo(3, 'a');
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
	
	fun foo(p : char; i : int) : int
	{
		return 0;
	}
{
	a <- foo('b', 'c');
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarIntLiteralByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : int) : nothing
	{
	}
{
	foo(5);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarCharLiteralByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}
{
	foo('t');
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarIntExprByReference1()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun foo(ref a : int) : nothing
	{
	}
{
	foo(i + 1);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarIntExprByReference2()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun foo(ref a : int) : nothing
	{
	}
{
	foo(1 + i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarIntExprByReference3()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun foo(ref a : int) : nothing
	{
	}
{
	foo(+ i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarIntExprByReference4()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun foo(ref a : int) : nothing
	{
	}
{
	foo(- i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestPassingVarArrayCharElementByReference()
		{
			string program = @"

fun program() : nothing

	var c : char[10];

	fun foo(ref a : char) : nothing
	{
	}
{
	foo(c[0]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarStringCharElementByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}
{
	foo(""hello""[2]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArrayArrayCharElementByReference()
		{
			string program = @"

fun program() : nothing

	var c : char[10][5];

	fun foo(ref a : char) : nothing
	{
	}
{
	foo(c[0][2]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArrayByReference()
		{
			string program = @"

fun program() : nothing

	var arr : char[5];

	fun foo(ref a : char []) : nothing
	{
	}
{
	foo(arr);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingVarArrayElementByReference()
		{
			string program = @"

fun program() : nothing

	var c : char[10][5];

	fun foo(ref a : char[]) : nothing
	{
	}
{
	foo(c[0]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingFunctionCallByVal()
		{
			string program = @"

fun program() : nothing

	fun foo(a : char) : nothing
	{
	}

	fun bar() : char
	{
		return 'c';
	}
{
	foo(bar());
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestPassingFunctionCallByRef()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}

	fun bar() : char
	{
		return 'c';
	}
{
	foo(bar());
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}
	}
}
