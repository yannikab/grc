﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Sem;
using Grc.Exceptions.Types;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class TypeFuncDefinitionTests : TypeVisitorTests
	{
		[Test]
		public void TestMain()
		{
			string program = @"

fun program() : nothing
{
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 1, MaxSymbols);
		}


		[Test]
		public void TestMainParameters()
		{
			string program = @"

fun program(i : int) : nothing
{
}

";
			Assert.Throws<MainFunctionWithParametersException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestMainReturnValue()
		{
			string program = @"

fun program() : int
{
}

";
			Assert.Throws<MainFunctionWithReturnValueException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestMismatchedDeclDef1()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing;
	
	fun boo() : int
	{
	}
{
}

";
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestMismatchedDeclDef2()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing;
	
	fun boo(ref a, b : char[][3][5]) : nothing
	{
	}
{
}

";
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestMismatchedDeclDef3()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : int[][4]) : nothing;
	
	fun boo(ref a : int[3][4]) : nothing
	{
	}
{
}

";
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestMismatchedDeclDef4()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : int[3][4]) : nothing;
	
	fun boo(ref a : int[][4]) : nothing
	{
	}
{
}

";
			Assert.Throws<FunctionMismatchedDefinitionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestDefMissing()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing;
{
}

";
			Assert.Throws<FunctionDefinitionMissingException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestDeclDef1()
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
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestDeclDef2()
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
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 6, MaxSymbols);
		}


		[Test]
		public void TestDeclDef3()
		{
			string program = @"

fun program() : nothing

	fun boo(x : int ; ref y : char; ref z : int[][4]) : char;

	var a, b : char[5];
	
	fun boo(a : int; ref b : char; ref c : int[][4]) : char
	{
		return 'a';
	}
{
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 8, MaxSymbols);
		}


		[Test]
		public void TestArrayParByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : int[][5]) : nothing
	{
	}
{
}

";
			AcceptTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, MaxSymbols);
		}


		[Test]
		public void TestArrayParNotByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(a : int[][5]) : nothing
	{
	}
{
}

";
			Assert.Throws<ArrayNotPassedByReferenceException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestNothingReturnsValue()
		{
			string program = @"

fun program() : nothing

	fun boo() : nothing
	{
		return 5;
	}
{
}

";
			Assert.Throws<ReturnValueNotAllowedException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestReturnsDifferentType()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return 'a';
	}
{
}

";
			Assert.Throws<ReturnDifferentTypeException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestReturnValueMissing()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
		return;
	}
{
}

";
			Assert.Throws<ReturnWithoutExpressionException>(() => AcceptTypeVisitor(program));
		}


		[Test]
		public void TestNoReturnInFunctionBody()
		{
			string program = @"

fun program() : nothing

	fun boo() : int
	{
	}
{
}

";
			Assert.Throws<ReturnMissingInFunctionBodyException>(() => AcceptTypeVisitor(program));
		}
	}
}
