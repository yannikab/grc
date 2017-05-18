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
		public void TestFunctionCallExprWrongNumberArguments()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo(p : char) : int
	{
	}
{
	a <- foo(3, 'a');
}

";
			ISymbolTable symbolTable;
			Assert.Throws<FunctionArgsMismatchException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestFunctionCallExprWrongTypeArguments()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo(p : char; i : int) : int
	{
	}
{
	a <- foo('b', 'c');
}

";
			ISymbolTable symbolTable;
			Assert.Throws<FunctionArgsMismatchException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestIntLiteralPassedByReference()
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
			ISymbolTable symbolTable;
			Assert.Throws<RValuePassedByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestCharLiteralPassedByReference()
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
			ISymbolTable symbolTable;
			Assert.Throws<RValuePassedByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestArrayCharElementPassedByReference()
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}

		[Test]
		public void TestStringCharElementPassedByReference()
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestArrayArrayCharElementPassedByReference()
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestArrayPassedByReference()
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestArrayElementPassedByReference()
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}
	}
}
