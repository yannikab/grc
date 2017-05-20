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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			ISymbolTable symbolTable;
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			ISymbolTable symbolTable;
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 5, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 5, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}

	}
}
