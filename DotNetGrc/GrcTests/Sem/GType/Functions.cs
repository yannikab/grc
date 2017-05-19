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
		public void TestFunctionMainParameters()
		{
			string program = @"

fun program(a : int) : nothing
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<MainFunctionWithParametersException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionMainReturnValue()
		{
			string program = @"

fun program() : int
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<MainFunctionWithReturnValueException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionCallStmtNothing()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing
	{
	}
{
	foo();
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 2, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestFunctionCallStmtSomething()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		return 0;
	}
{
	foo();
}

";
			ISymbolTable symbolTable;
			Assert.Throws<FunctionCallStatementWithoutNothingException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionMismatchedDeclDef1()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;
	
	fun foo() : int
	{
	}
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionMismatchedDeclDef2()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;
	
	fun foo(ref a, b : char[][3][5]) : nothing
	{
	}
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionDeclDef()
		{
			string program = @"

fun program() : nothing

	fun foo(x : int ; ref y : char; ref z : int[][4]) : char;

	var a, b : char[5];
	
	fun foo(a : int; ref b : char; ref c : int[][4]) : char
	{
		return 'a';
	}
{
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 7, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestFunctionIndexedPassedByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref array : int [][5]) : nothing
	{
	}
{
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestFunctionIndexedNotPassedByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(array : int [][5]) : nothing
	{
	}
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<ArrayNotPassedByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionNothingReturnsValue()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing
	{
		return 5;
	}
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<ReturnValueNotAllowedException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionReturnsDifferentType()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		return 'a';
	}
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<ReturnDifferentTypeException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionReturnsNothing()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		return;
	}
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<ReturnWithoutExpressionException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionNoReturnInFunctionBody()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		
	}
{
}

";
			ISymbolTable symbolTable;
			Assert.Throws<ReturnMissingInFunctionBodyException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}
	}
}
