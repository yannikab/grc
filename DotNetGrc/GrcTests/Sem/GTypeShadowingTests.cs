using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Visitor.Exceptions.Sem;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class GTypeShadowingTests : GTypeVisitorTests
	{
		[Test]
		public void TestSameVarFun()
		{
			string program = @"

fun program() : nothing

	var boo : int;
	
	fun boo() : nothing
	{
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestSameFunDefFunDef()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return 0;
	}

	fun boo(i : int) : char
	{
		return 'a';
	}
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameFunDefFunDecl()
		{
			string program = @"

fun program() : nothing

	fun boo(c : char) : int
	{
		return 0;
	}

	fun boo() : char;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameFunDeclFunDecl()
		{
			string program = @"

fun program() : nothing

	fun boo() : int;

	fun boo(i : int) : char;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestOuterDeclInnerDef()
		{
			string program = @"

fun program() : nothing

	fun boo() : int;
	
	fun far() : nothing
	
		fun boo(c : char) : nothing
		{
		}
	{
		boo('c');		$ fun boo(c : char) : nothing;
	}
	
	var v : int;

	fun boo() : int
	{
		far();

		v <- boo();		$ fun boo() : int;

		return 0;
	}

{
	v <- boo();			$ fun boo() : int;
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestNested1()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return 0;
	}

	fun far() : nothing
	
		fun boo() : nothing
		{
		}
	{
		boo();
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestNested2()
		{
			string program = @"

fun program() : nothing

	var v : int;

	fun boo() : int
	{
		return 0;
	}

	fun far() : nothing
	
		fun boo() : int
		{
			return 0;
		}
	{
		v <- boo();
	}
{
    v <- boo();

    far();
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestChild()
		{
			string program = @"

fun program() : nothing

	var v : int;

	fun boo() : char

		fun boo() : int
		{
			return 1;
		}

	{
		v <- boo();

		return 'c';
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestSameVarVar()
		{
			string program = @"

fun program() : nothing

	var v : int;
	var v : char;

{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameVarPar()
		{
			string program = @"

fun program() : nothing

	fun boo(a : int) : nothing
	
	var a : char;

	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameParParDef()
		{
			string program = @"

fun program() : nothing

	fun boo(a : int; a : char) : char
	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameParParDecl()
		{
			string program = @"

fun program() : nothing

	fun boo(a : int; a : char) : int;
	
	fun boo(b : int; b : char) : int
	{
		return 0;
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestNestedVar()
		{
			string program = @"

fun program() : nothing

	fun outer(a : int; b: int; ref c: char[][5]) : int

		var d : char;
		var e : char;
		var f : int;

		fun inner(b : char; e : int) : char
	
		var c : int;
		var f : int[3][5];
	
		{
			a <- 5;
			b <- 'z';
			c <- 3;
			d <- 'x';
			e <- 6;
			f[0][2] <- 4;

			return d;
		}
	{
		return b + f;
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 13, MaxSymbols);
		}
	}
}
