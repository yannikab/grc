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
		public void TestFunctionMainParameters()
		{
			string program = @"

fun program(a : int) : nothing
{
}

";
			Assert.Throws<MainFunctionWithParametersException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionMainReturnValue()
		{
			string program = @"

fun program() : int
{
}

";
			Assert.Throws<MainFunctionWithReturnValueException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionCallStmtNothing()
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
		public void TestFunctionCallStmtSomething()
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
		public void TestFunctionMismatchedDeclDef1()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing;
	
	fun boo() : int
	{
	}
{
}

";
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionMismatchedDeclDef2()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing;
	
	fun boo(ref a, b : char[][3][5]) : nothing
	{
	}
{
}

";
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionDeclDef()
		{
			string program = @"

fun program() : nothing

	fun boo(x : int ; ref y : char; ref z : int[][4]) : char;

	var a, b : char[5];
	
	fun boo(a : int; ref b : char; ref c : int[][4]) : char
	{
		return 'a';
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 8, MaxSymbols);
		}


		[Test]
		public void TestFunctionIndexedByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref array : int [][5]) : nothing
	{
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestFunctionIndexedNotByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(array : int [][5]) : nothing
	{
	}
{
}

";
			Assert.Throws<ArrayNotPassedByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionNothingReturnsValue()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing
	{
		return 5;
	}
{
}

";
			Assert.Throws<ReturnValueNotAllowedException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionReturnsDifferentType()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return 'a';
	}
{
}

";
			Assert.Throws<ReturnDifferentTypeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionReturnsNothing()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return;
	}
{
}

";
			Assert.Throws<ReturnWithoutExpressionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionNoReturnInFunctionBody()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		
	}
{
}

";
			Assert.Throws<ReturnMissingInFunctionBodyException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionArgumentByVal()
		{
			string program = @"

fun program() : nothing

	fun boo(a : char) : nothing
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
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}
	}
}
