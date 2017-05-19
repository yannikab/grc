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
			ISymbolTable symbolTable;
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			ISymbolTable symbolTable;
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			ISymbolTable symbolTable;
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			ISymbolTable symbolTable;
			Assert.Throws<FunctionCallRValueByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}
	}
}
