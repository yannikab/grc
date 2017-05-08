using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Semantic.Visitor;
using Grc.Semantic.Visitor.Exceptions.GType;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;

namespace GrcTests.Semantic
{
	[TestFixture]
	public class GTypeVisitorTests
	{
		private static void AcceptGTypeVisitor(string program)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			NodeBase root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			root.Accept(new GTypeVisitor());
		}


		[Test]
		public void TestSimple()
		{
			string program = @"

fun program() : nothing
{
}

";
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestMainFunctionParameters()
		{
			string program = @"

fun program(a : int) : nothing
{
}

";
			Assert.Throws<MainFunctionWithParametersException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestMainFunctionReturnValue()
		{
			string program = @"

fun program() : int
{
}

";
			Assert.Throws<MainFunctionWithReturnValueException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestIndexedPassedByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref array : int [][5]) : nothing
	{
	}
{
}

";
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestIndexedNotPassedByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(array : int [][5]) : nothing
	{
	}
{
}

";
			Assert.Throws<IndexedNotByReferenceException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLValueNotIndexed1()
		{
			string program = @"

fun program() : nothing

	var a : int;
{
	a[5] <- 4;
}

";
			Assert.Throws<IndexingInvalidTypeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestLValueNotIndexed2()
		{
			string program = @"

fun program() : nothing

	var a : int [5];
{
	a[0][3] <- 4;
}

";
			Assert.Throws<IndexingInvalidTypeException>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<InvalidTypeAssignmentException>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<InvalidTypeAssignmentException>(() => AcceptGTypeVisitor(program));
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
	c[5] <- 5;
}

";
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestFunctionCallExprNoArgs()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo() : int
	{
	}
{
	a <- foo();
}

";
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestFunctionCallExprArgs()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo(c : char; i : int; ref a : char[5]) : int
	{
	}
{
	a <- foo('f', 34, ""hello"");
}

";
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestFunctionCallExprWrongNumberArguments()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo(p : char) : int
	{
	}
{
	a <- foo(3, 'a');
}

";
			Assert.Throws<FunctionArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionCallExprWrongTypeArguments()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo(p : char; i : int) : int
	{
	}
{
	a <- foo('b', 'c');
}

";
			Assert.Throws<FunctionArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunctionCallStmtNothing()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing
	{
	}
{
	foo();
}

";
			AcceptGTypeVisitor(program);
		}

		[Test]
		public void TestFunctionCallStmtSomething()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
	}
{
	foo();
}

";
			Assert.Throws<FunctionCallStatementWithoutNothingException>(() => AcceptGTypeVisitor(program));
		}

		[Test]
		public void TestIndexedExprInt()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char;
	
{
	b <- a[8];	
}

";
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestMismatchedDeclDef1()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;
	
	fun foo() : int
	{
	}
{
}

";
			Assert.Throws<MismatchedFunctionDefinitionException>
					(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestMismatchedDeclDef2()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;
	
	fun foo(ref a, b : char[][3]) : nothing
	{
	}
{
}

";
			Assert.Throws<MismatchedFunctionDefinitionException>
					(() => AcceptGTypeVisitor(program));
		}
	}
}
