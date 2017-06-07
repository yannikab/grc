using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Types;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class TypeExpressionTests : TypeVisitorTests
	{
		[Test]
		public void TestAssignNothing()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo() : nothing
	{
	}
{
	i <- boo();
}

";
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestAddNothing()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo() : nothing
	{
	}
{
	i <- 5 + boo();
}

";
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestFuncCallAdd()
		{
			string program = @"

fun program() : nothing

	var i : int;

	fun boo() : int
	{
		return 4;
	}
{
	i <- boo() + 5;
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestFuncCallInt()
		{
			string program = @"

fun program() : nothing

	var i : int;
	
	fun boo() : int
	{
		return 0;
	}
{
	i <- boo();
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestFuncCallChar()
		{
			string program = @"

fun program() : nothing

	var c : char;
	
	fun boo() : char
	{
		return 'a';
	}
{
	c <- boo();
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestAddCharChar()
		{
			string program = @"

fun program() : nothing

	var a, b : char;
{
	a <- a + b;
}

";
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptTypeVisitor(program));
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
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestRelOpInvalidType()
		{
			string program = @"

fun program() : nothing

	var a : char[3][4];
{

	if (""hello"" < a) then
		;
}

";
			Assert.Throws<InvalidTypeInRelOpException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestRelOpDifferentType()
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
			Assert.Throws<InvalidTypeInRelOpException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIntLiteralOverflow()
		{
			string program = @"

fun program() : nothing

	var i : int;
{
	i <- 3534534803854490548903408949805390045093094340538045838048531;
}

";
			Assert.Throws<OverflowInIntegerExpressionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestOverflowByOneAdd()
		{
			string program = @"

fun program() : nothing

	var i : int;
{
	i <- 2147483647 + 1;
}

";
			Assert.Throws<OverflowInIntegerExpressionException>(() => AcceptTypeVisitor(program));
			//AcceptTypeVisitor(program);
		}


		[Test]
		public void TestOverflowByOneAddNeg()
		{
			string program = @"

fun program() : nothing

	var i : int;
{
	i <- - 2147483648 - 1;
}

";
			Assert.Throws<OverflowInIntegerExpressionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestOverflowMul()
		{
			string program = @"

fun program() : nothing

	var i : int;
{
	i <- 46341 * 46341;
}

";
			Assert.Throws<OverflowInIntegerExpressionException>(() => AcceptTypeVisitor(program));
			//AcceptTypeVisitor(program);
		}


		[Test]
		public void TestOverflowMulNeg()
		{
			string program = @"

fun program() : nothing

	var i : int;
{
	i <- - 46341 * 46341;
}

";
			Assert.Throws<OverflowInIntegerExpressionException>(() => AcceptTypeVisitor(program));
			//AcceptTypeVisitor(program);
		}


		[Test]
		public void TestDivByZero()
		{
			string program = @"

fun program() : nothing

	var i : int;
{
	i <- 1 div 0;
}

";
			Assert.Throws<OverflowInIntegerExpressionException>(() => AcceptTypeVisitor(program));
			//AcceptTypeVisitor(program);
		}


		[Test]
		public void TestAssignInvalidType1()
		{
			string program = @"

fun program() : nothing

	var a : int[5];
{
	a[3] <- 'c';
}

";
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestAssignInvalidType2()
		{
			string program = @"

fun program() : nothing

	var a : char;
{
	a <- 5;
}

";
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestAssignCorrectType()
		{
			string program = @"

fun program() : nothing

	var a : int[3];
	var b : int;
	var c : char;
{
	a[2] <- 3;
	b <- 5;
	c <- 'd';
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestAssignToIndexed()
		{
			string program = @"

fun program() : nothing

	var a : char[4][5];

{
	a[1][2] <- 'c';	
	
	""hello""[2] <- 'c';	
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 2, MaxSymbols);
		}


		[Test]
		public void TestAssignFromIndexed()
		{
			string program = @"

fun program() : nothing

	var a : char[4][5][6];
	var c : char;

{
	c <- a[1][2][3];	

	c <- ""hello""[2];
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}
	}
}
