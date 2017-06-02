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
	public class GTypeFuncUsageTests : GTypeVisitorTests
	{
		[Test]
		public void TestFuncCallStmtNothing()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing
	{
	}
{
	boo();
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 2, MaxSymbols);
		}


		[Test]
		public void TestFuncCallStmtValue()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return 0;
	}
{
	boo();
}

";
			Assert.Throws<FunctionCallStatementWithoutNothingException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgFuncCallByVal()
		{
			string program = @"

fun program() : nothing

	fun boo(c : char) : nothing
	{
	}

	fun far() : char
	{
		return 'a';
	}
{
	boo(far());
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestArgFuncCallByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref c : char) : nothing
	{
	}

	fun far() : char
	{
		return 'a';
	}
{
	boo(far());
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestParByValArgByVal()
		{
			string program = @"

fun program() : nothing

	fun boo(i : int) : nothing
	{
	}

	fun far(p : int) : nothing
	{
		boo(p);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParByRefArgByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref i : int) : nothing
	{
	}

	fun far(ref p : int) : nothing
	{
		boo(p);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParByValArgByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(i : int) : nothing
	{
	}

	fun far(ref p : int) : nothing
	{
		boo(p);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParByRefArgByVal()
		{
			string program = @"

fun program() : nothing

	fun boo(ref i : int) : nothing
	{
	}

	fun far(p : int) : nothing
	{
		boo(p);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParByValArgVar()
		{
			string program = @"

fun program() : nothing

	var v : int;

	fun boo(i : int) : nothing
	{
	}
{
	boo(v);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParByRefArgVar()
		{
			string program = @"

fun program() : nothing

	var v : int;

	fun boo(ref i : int) : nothing
	{
	}
{
	boo(v);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestWrongNumberArguments()
		{
			string program = @"

fun program() : nothing

	var i : int;
	
	fun boo(p : char) : int
	{
		return 0;
	}
{
	i <- boo(3, 'a');
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestWrongTypeArguments()
		{
			string program = @"

fun program() : nothing

	var i : int;
	
	fun boo(c : char; n : int) : int
	{
		return 0;
	}
{
	i <- boo('b', 'c');
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgLiteralIntByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref i : int) : nothing
	{
	}
{
	boo(5);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgLiteralCharByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref c : char) : nothing
	{
	}
{
	boo('t');
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgExprIntByRef1()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref p : int) : nothing
	{
	}
{
	boo(i + 1);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgExprIntByRef2()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref p : int) : nothing
	{
	}
{
	boo(1 + i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgExprIntByRef3()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref p : int) : nothing
	{
	}
{
	boo(+ i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgExprIntByRef4()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo(ref p : int) : nothing
	{
	}
{
	boo(- i);
}

";
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestArgStringElement()
		{
			string program = @"

fun program() : nothing

	fun boo(ref c : char) : nothing
	{
	}

	fun far(c : char) : nothing
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
	}
}
