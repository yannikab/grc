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
		public void TestExprAddNothing()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : nothing
	{
	}
{
	a <- 5 + foo();
}

";
			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestExprFunctionCallExprAdd()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo(c : char; i : int; ref a : char[5]) : int
	{
		return 0;
	}
{
	a <- foo('f', 34, ""hello"") + 5;
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 6, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestExprAddChar()
		{
			string program = @"

fun program() : nothing

	var a, b : char;
{
	a <- a + b;
}

";
			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestExprAddIntChar()
		{
			string program = @"

fun program() : nothing

	var a : int;
	var b : char;
{
	a <- a + b;
}

";
			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestExprIndexNotInteger()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char;
	
{
	b <- a['c'];	
}

";

			ISymbolTable symbolTable;
			Assert.Throws<ArrayIndexNotIntegerException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestExprRelOpInvalidType()
		{
			string program = @"

fun program() : nothing

	var a : char[3][4];
{

	if (""hello"" < a) then
		;
}

";

			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInRelOpException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestExprRelOpDifferentType()
		{
			string program = @"

fun program() : nothing

	var a : char;
	var b : int;
{

	if (a < 5 + b) then
		;
}

";

			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInRelOpException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}
	}
}
