using System;
using java.io;
using k31.grc.cst.parser;
using k31.grc.cst.lexer;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor;
using Grc.Semantic.Visitor;
using Grc.Semantic;
using Grc.Semantic.SymbolTable.Exception;
using NUnit.Framework;

namespace GrcTests.Semantic
{
	[TestFixture]
	public class SemanticTests
	{
		private static void AcceptSemanticVisitor(string program)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			NodeBase root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			root.Accept(new SemanticVisitor());
		}


		[Test]
		public void TestSimple()
		{
			string program = @"

fun program() : nothing
{
}

";
			AcceptSemanticVisitor(program);
		}


		[Test]
		public void TestSameVarVar()
		{
			string program = @"

fun program() : nothing

var a : int;
var a : char;

{
}

";
			Assert.Throws<SymbolAlreadyInScopeException>
				(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameVarPar()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int) : nothing
	
	var a : int;

	{
	}
{
}

";
			Assert.Throws<SymbolAlreadyInScopeException>
				(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameParPar()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int; a : int) : nothing
	{
	}
{
}

";
			Assert.Throws<SymbolAlreadyInScopeException>
				(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameVarFun()
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
			AcceptSemanticVisitor(program);
		}


		[Test]
		public void TestNotDefinedVar()
		{
			string program = @"

fun program() : nothing
{
	foo <- 5;
}

";
			Assert.Throws<SymbolNotDefinedException>
				(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestNotDefinedFun()
		{
			string program = @"

fun program() : nothing
{
	foo();
}

";
			Assert.Throws<SymbolNotDefinedException>
				(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestNotDefinedVarFun()
		{
			string program = @"

fun program() : nothing
{
	foo <- bar();
}

";
			Assert.Throws<SymbolNotDefinedException>
					(() => AcceptSemanticVisitor(program));
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
			AcceptSemanticVisitor(program);
		}


		[Test]
		public void TestDefinedPar()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : int) : nothing
	{
		a <- 5;
	}
{
}

";
			AcceptSemanticVisitor(program);
		}


		[Test]
		public void TestDefinedFun()
		{
			string program = @"

fun program() : nothing

var a : int;

	fun foo() : int
	{
	}
{
	foo();
	a <- foo();
}

";
			AcceptSemanticVisitor(program);
		}
	}
}
