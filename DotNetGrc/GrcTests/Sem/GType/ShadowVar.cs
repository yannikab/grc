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
		public void TestShadowVarSameVarVar()
		{
			string program = @"

fun program() : nothing

	var a : int;
	var a : char;

{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestShadowVarSameVarPar()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int) : nothing
	
	var a : char;

	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestShadowVarSameParParDef()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int; a : char) : char
	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestShadowVarSameParParDecl()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int; a : char) : int;
	
	fun foo(a : int; a : char) : int
	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestShadowVarNestedVar()
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
