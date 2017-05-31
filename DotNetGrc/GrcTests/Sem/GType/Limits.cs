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
		public void TestLimitsIntLiteralOverflow()
		{
			string program = @"

fun program() : nothing

	var a : int;
{
	a <- 3534534803854490548903408949805390045093094340538045838048531;
}

";
			Assert.Throws<OverflowInIntegerLiteralException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLimitsArraySizeOverflow()
		{
			string program = @"

fun program() : nothing

	var a : char[3534534803854490548903408949805390045093094340538045838048531];
{
	a[0] <- 'c';
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLimitsArraySizeZero()
		{
			string program = @"

fun program() : nothing

	var a : char[0];
{
	a[0] <- 'c';
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLimitsArrayIndexOverBounds()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[10];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLimitsArrayIndexNegative()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[-2];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLimitsArrayExpressionLiteralOverBounds()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[3 mod 2 + (4 div (3 - 1)) * 5];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLimitsArrayExpressionLiteralNegative()
		{
			string program = @"

fun program() : nothing

	var a : char[09];
	var c : char;
{
	c <- a[- 24 div 3 + 2 * 3];
}

";
			Assert.Throws<ArrayInvalidDimensionException>(() => AcceptGTypeVisitor(program));
		}
	}
}
