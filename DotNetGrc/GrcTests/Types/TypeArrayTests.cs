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
	public class TypeArrayTests : TypeVisitorTests
	{
		[Test]
		public void TestDimensionOverflow()
		{
			string program = @"

fun program() : nothing

	var a : char[3534534803854490548903408949805390045093094340538045838048531];
{
	a[0] <- 'c';
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestDimensionZero()
		{
			string program = @"

fun program() : nothing

	var a : char[0];
{
	a[0] <- 'c';
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexOverBounds()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[10];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexNegative()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[-2];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexExpressionOverBounds()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[3 mod 2 + (4 div (3 - 1)) * 5];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexExpressionNegative()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[- 24 div 3 + 2 * 3];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestAssign1()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char[5];

{
	b <- a;	
}

";
			Assert.Throws<IndexedTypeInAssignmentException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestAssign2()
		{
			string program = @"

fun program() : nothing

	var a : char[2][5];
	var b : char[2][5];

{
	b <- a;	
}

";
			Assert.Throws<IndexedTypeInAssignmentException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestAssign3()
		{
			string program = @"

fun program() : nothing

	var a : char[5];

{
	""text"" <- a;	
}

";
			Assert.Throws<IndexedTypeInAssignmentException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestAssign4()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char[5][4];

{
	a <- b;	
}

";
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexingNotArray1()
		{
			string program = @"

fun program() : nothing

	var a : int;
{
	a[5] <- 4;
}

";
			Assert.Throws<LValueNotIndexedTypeException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexingNotArray2()
		{
			string program = @"

fun program() : nothing

	var a : int[5];
{
	a[0][3] <- 4;
}

";
			Assert.Throws<LValueNotIndexedTypeException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexNotInteger1()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char;
	
{
	b <- a['c'];	
}

";
			Assert.Throws<ArrayIndexNotIntegerException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexNotInteger2()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char;
	
{
	b <- a[""hello""];	
}

";
			Assert.Throws<ArrayIndexNotIntegerException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestIndexNotInteger3()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char;
	
{
	b <- a[a];	
}

";
			Assert.Throws<ArrayIndexNotIntegerException>(() => AcceptTypeVisitor(program));
		}
	}
}
