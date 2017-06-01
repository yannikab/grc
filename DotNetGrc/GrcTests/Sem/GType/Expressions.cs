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
		public void TestExprAddNothing()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun boo() : nothing
	{
	}
{
	a <- 5 + boo();
}

";
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestExprFuncCallAdd()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun boo(c : char; i : int; ref a : char[6]) : int
	{
		return 0;
	}
{
	a <- boo('f', 34, ""hello"") + 5;
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 6, MaxSymbols);
		}


		[Test]
		public void TestExprFuncCallNoArgs()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun boo() : int
	{
		return 0;
	}
{
	a <- boo();
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestExprFuncCallArgs()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun boo(c : char; i : int; ref a : char[6]) : int
	{
		return 0;
	}
{
	a <- boo('f', 34, ""hello"");
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 6, MaxSymbols);
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
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<ArrayIndexNotIntegerException>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<InvalidTypeInRelOpException>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<InvalidTypeInRelOpException>(() => AcceptGTypeVisitor(program));
		}
	}
}
