using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Semantic.Visitor;
using Grc.Semantic.Visitor.Exceptions.Semantic;
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
			Assert.Throws<VariableNotInOpenScopesException>
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
			Assert.Throws<FunctionNotInOpenScopesException>
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
			Assert.Throws<VariableNotInOpenScopesException>
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
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
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
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
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


		[Test]
		public void TestOuterDeclInnerDef()
		{
			string program = @"

fun program() : nothing

	fun foo() : int;
	
	fun bar() : nothing
	
		fun foo() : int
		{
		}
	{
	}
	
	fun foo() : int
	{
	}
{
}

";
			AcceptSemanticVisitor(program);
		}

		[Test]
		public void TestHanoi()
		{
			string program = @"

fun solve () : nothing

      fun puts(ref s : char[]) : nothing { }
      fun writeString(ref s : char[]) : nothing { }
      fun geti() : int { }

      fun hanoi (rings : int; ref source, target, auxiliary : char[]) : nothing
         fun move (ref source, target : char[]) : nothing
         {
            puts(""Moving from "");
            puts(source);
            puts("" to "");
            puts(target);
            puts("".\n"");
         }
      {
         if rings >= 1 then {
            hanoi(rings-1, source, auxiliary, target);
            move(source, target);
            hanoi(rings-1, auxiliary, target, source);
         }
      }

      var NumberOfRings : int;
{
  writeString(""Rings: "");
  NumberOfRings <- geti();
  hanoi(NumberOfRings, ""left"", ""right"", ""middle"");
}


";
			AcceptSemanticVisitor(program);
		}


		[Test]
		public void TestFunny()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		return 0;
	}

	fun bar() : nothing
	
		var a : int;

		fun foo() : int
		{
			return 5;
		}
	{
		a <- foo();
	}
{
}

";
			AcceptSemanticVisitor(program);
		}
	}
}
