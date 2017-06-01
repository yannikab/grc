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
	public partial class GTypeVisitorTests
	{
		[Test]
		public void TestShadowFuncSameVarFun()
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
		public void TestShadowFuncSameFunDefFunDef()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return 0;
	}

	fun boo(a : int) : char
	{
		return 'a';
	}
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestShadowFuncSameFunDefFunDecl()
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
		public void TestShadowFuncSameFunDeclFunDecl()
		{
			string program = @"

fun program() : nothing

	fun boo() : int;

	fun boo(a : int) : char;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestShadowFuncOuterDeclInnerDef()
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
	
	var a : int;

	fun boo() : int
	{
		far();

		a <- boo();		$ fun boo() : int;

		return 0;
	}

{
	a <- boo();			$ fun boo() : int;
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestShadowFuncNested1()
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
		public void TestShadowFuncNested2()
		{
			string program = @"

fun program() : nothing

	var a : int;

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
		a <- boo();
	}
{
    a <- boo();

    far();
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestShadowFuncChild()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun boo() : char

		fun boo() : int
		{
			return 1;
		}

	{
		a <- boo();

		return 'c';
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}
	}
}
