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
		public void TestAssignLValueNotIndexed1()
		{
			string program = @"

fun program() : nothing

	var a : int;
{
	a[5] <- 4;
}

";
			Assert.Throws<LValueNotIndexedTypeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestAssignLValueNotIndexed2()
		{
			string program = @"

fun program() : nothing

	var a : int [5];
{
	a[0][3] <- 4;
}

";
			Assert.Throws<LValueNotIndexedTypeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestAssignInvalidType1()
		{
			string program = @"

fun program() : nothing

	var a : int [5];
{
	a[3] <- 'c';
}

";
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestAssignNothing()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun boo() : nothing
	{
	}
{
	a <- boo();
}

";
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestAssignCorrectType()
		{
			string program = @"

fun program() : nothing

	var a : int;
	var b : char;
	var c : int[3];
{
	a <- 5;
	b <- 'd';
	c[2] <- 5;
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestAssignIndexed1()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char[5];

{
	b <- a;	
}

";
			Assert.Throws<IndexedTypeInAssignmentException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestAssignIndexed2()
		{
			string program = @"

fun program() : nothing

	var a : char[2][5];
	var b : char[2][5];

{
	b <- a;	
}

";
			Assert.Throws<IndexedTypeInAssignmentException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestAssignIndexed3()
		{
			string program = @"

fun program() : nothing

	var a : char[5];

{
	""text"" <- a;	
}

";
			Assert.Throws<IndexedTypeInAssignmentException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestAssignIndexed4()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char[5][4];

{
	a <- b;	
}

";
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptGTypeVisitor(program));
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
			AcceptGTypeVisitor(program);
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
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}
	}
}
