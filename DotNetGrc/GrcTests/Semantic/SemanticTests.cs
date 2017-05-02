using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using java.io;
using k31.grc.cst.parser;
using k31.grc.cst.lexer;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor;
using Grc.Semantic.Visitor;
using Grc.Semantic;
using Grc.Semantic.SymbolTable.Exception;

namespace GrcTests.Semantic
{
	[TestClass]
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


		[TestMethod]
		public void TestSimple()
		{
			string program = @"

fun program() : nothing
{
}

";
			AcceptSemanticVisitor(program);
		}


		[TestMethod]
		[ExpectedException(typeof(SymbolAlreadyInScopeException))]
		public void TestSameVarVar()
		{
			string program = @"

fun program() : nothing

var a : int;
var a : char;

{
}

";
			AcceptSemanticVisitor(program);
		}


		[TestMethod]
		[ExpectedException(typeof(SymbolAlreadyInScopeException))]
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
			AcceptSemanticVisitor(program);
		}


		[TestMethod]
		[ExpectedException(typeof(SymbolAlreadyInScopeException))]
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
			AcceptSemanticVisitor(program);
		}


		[TestMethod]
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


		[TestMethod]
		[ExpectedException(typeof(SymbolNotDefinedException))]
		public void TestNotDefinedVar()
		{
			string program = @"

fun program() : nothing
{
	foo <- 5;
}

";
			AcceptSemanticVisitor(program);
		}


		[TestMethod]
		[ExpectedException(typeof(SymbolNotDefinedException))]
		public void TestNotDefinedFun()
		{
			string program = @"

fun program() : nothing
{
	foo();
}

";
			AcceptSemanticVisitor(program);
		}


		[TestMethod]
		[ExpectedException(typeof(SymbolNotDefinedException))]
		public void TestNotDefinedVarFun()
		{
			string program = @"

fun program() : nothing
{
	foo <- bar();
}

";
			AcceptSemanticVisitor(program);
		}


		[TestMethod]
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


		[TestMethod]
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


		[TestMethod]
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
