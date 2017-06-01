using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Visitor.Exceptions.GType;
using Grc.Sem.Visitor.Exceptions.Sem;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		[Test]
		public void TestNotDefinedVar()
		{
			string program = @"

fun program() : nothing
{
	boo <- 5;
}

";
			Assert.Throws<VariableNotInOpenScopesException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestNotDefinedFun()
		{
			string program = @"

fun program() : nothing
{
	boo();
}

";
			Assert.Throws<FunctionNotInOpenScopesException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestNotDefinedVarFun()
		{
			string program = @"

fun program() : nothing
{
	boo <- far();
}

";
			Assert.Throws<VariableNotInOpenScopesException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestDefinedVar()
		{
			string program = @"

fun program() : nothing

	var a : int;

{
	a <- 5;
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 2, MaxSymbols);
		}


		[Test]
		public void TestDefinedPar()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : int) : nothing
	{
		a <- 5;
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestDefinedFun()
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
		public void TestDeclaredFun()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun boo() : int;
{
	a <- boo();
}

";
			Assert.Throws<FunctionDefinitionMissingException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunDefMissing()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing;
{
}

";
			Assert.Throws<FunctionDefinitionMissingException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunDeclFunDef1()
		{
			string program = @"

fun program() : nothing

	fun boo() : char;

	var a, b : char[5];
	
	fun boo() : char
	{
		return 'a';
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestFunDeclFunDef2()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char) : int;

	var a : int;
	var b : char;

	fun boo(ref c : char) : int
	{
		a <- boo(b);
		return a;
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 6, MaxSymbols);
		}
	}
}
