using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable;
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

	var foo : int;
	
	fun foo() : nothing
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

	fun foo() : int
	{
		return 0;
	}

	fun foo(a : int) : char
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

	fun foo(c : char) : int
	{
		return 0;
	}

	fun foo() : char;
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

	fun foo() : int;

	fun foo(a : int) : char;
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

	fun foo() : int;
	
	fun bar() : nothing
	
		fun foo(c : char) : nothing
		{
		}
	{
		foo('c');		$ fun foo(c : char) : nothing;
	}
	
	var a : int;

	fun foo() : int
	{
		bar();

		a <- foo();		$ fun foo() : int;

		return 0;
	}

{
	a <- foo();			$ fun foo() : int;
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestShadowFuncFunny()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : int
	{
		return 0;
	}

	fun bar() : nothing
	
		fun foo() : int
		{
			return 0;
		}
	{
		a <- foo();
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestShadowChild()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : int

		fun foo() : char
		{
			return 'c';
		}

	{
		return 0;
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}
	}
}
