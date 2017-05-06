using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Semantic.Visitor;
using Grc.Semantic.Visitor.Exceptions;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;

namespace GrcTests.Semantic
{
	[TestFixture]
	public class SemanticVisitorTests
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
			Assert.Throws<VariableAlreadyInScopeException>
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
			Assert.Throws<VariableAlreadyInScopeException>
				(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameParParDef()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int; a : int) : nothing
	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>
				(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameParParDecl()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int; a : int) : nothing;
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>
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
			Assert.Throws<VariableNotInScopeException>
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
			Assert.Throws<FunctionNotInScopeException>
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
			Assert.Throws<VariableNotInScopeException>
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


		[Test]
		public void TestDeclaredFun()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : int;
{
	foo();
	a <- foo();
}

";
			Assert.Throws<FunctionDefinitionMissingException>
					(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameFunDefFunDef()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing
	{
	}

	fun foo() : nothing
	{
	}
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>
					(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameFunDefFunDecl()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing
	{
	}

	fun foo() : nothing;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>
					(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameFunDeclFunDecl()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;

	fun foo() : nothing;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>
					(() => AcceptSemanticVisitor(program));
		}

		[Test]
		public void TestFunDefMissing()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;
{
}

";
			Assert.Throws<FunctionDefinitionMissingException>
					(() => AcceptSemanticVisitor(program));
		}

		[Test]
		public void TestFunDeclFunDef()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;

	var a, b : char[5];
	
	fun foo() : nothing
	{
	}
{
}

";
			AcceptSemanticVisitor(program);
		}
	}
}
