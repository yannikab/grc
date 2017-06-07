using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Sem;
using Grc.Nodes.Helper;
using Grc.Visitors.Cst;
using Grc.Visitors.Sem;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class SemanticVisitorTests
	{
		private static int MaxSymbols;

		private static void AcceptSemanticVisitor(string program)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			Root root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			SemanticVisitor v = new SemanticVisitor();
			root.Accept(v);
			MaxSymbols = v.SymbolTable.MaxSymbols;
		}


		[Test]
		public void TestSimple()
		{
			string program = @"

fun program(ref a : char) : int
{
}

";
			AcceptSemanticVisitor(program);
			Assert.AreEqual(2, MaxSymbols);
		}


		[Test]
		public void TestSameVarVar()
		{
			string program = @"

fun program() : char

	var a : int;
	var a : char;

{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameVarPar()
		{
			string program = @"

fun program() : int

	fun foo(a : int) : nothing
	
	var a : char;

	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameParParDef()
		{
			string program = @"

fun program() : int

	fun foo(a : int; a : char) : char
	{
	}
{
}

";
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameParParDecl()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int; a : char) : int;
	
	fun foo(ref b : char [][5][4]) : char
	{
	}
{
}

";
			AcceptSemanticVisitor(program);
			Assert.AreEqual(4, MaxSymbols);
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
			Assert.AreEqual(3, MaxSymbols);
		}


		[Test]
		public void TestNotDefinedVar()
		{
			string program = @"

fun program(a, b, c : int [4][5][2]) : int
{
	foo <- 5;
}

";
			Assert.Throws<VariableNotInOpenScopesException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestNotDefinedFun()
		{
			string program = @"

fun program() : char
{
	foo();
}

";
			Assert.Throws<FunctionNotInOpenScopesException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestNotDefinedVarFun()
		{
			string program = @"

fun program() : int
{
	foo <- bar();
}

";
			Assert.Throws<VariableNotInOpenScopesException>(() => AcceptSemanticVisitor(program));
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

fun program() : char

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
			Assert.AreEqual(3, MaxSymbols);
		}


		[Test]
		public void TestDeclaredFun()
		{
			string program = @"

fun program() : char

	var a : int;

	fun foo() : int;
{
	foo();
	a <- foo();
}

";
			Assert.Throws<FunctionDefinitionMissingException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameFunDefFunDef()
		{
			string program = @"

fun program() : char

	fun foo() : int
	{
	}

	fun foo() : char
	{
	}
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameFunDefFunDecl()
		{
			string program = @"

fun program() : char

	fun foo() : int
	{
	}

	fun foo() : char;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestSameFunDeclFunDecl()
		{
			string program = @"

fun program() : char

	fun foo() : int;

	fun foo() : char;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestFunDefMissing()
		{
			string program = @"

fun program() : char

	fun foo() : nothing;
{
}

";
			Assert.Throws<FunctionDefinitionMissingException>(() => AcceptSemanticVisitor(program));
		}


		[Test]
		public void TestFunDeclFunDef1()
		{
			string program = @"

fun program() : int

	fun foo() : char;

	var a, b : char[5];
	
	fun foo() : nothing
	{
	}
{
}

";
			AcceptSemanticVisitor(program);
			Assert.AreEqual(5, MaxSymbols);
		}


		[Test]
		public void TestFunDeclFunDef2()
		{
			string program = @"

fun program() : char

	fun foo(a : int []) : int;

	var a : int;
	
	fun foo(a : char) : nothing
	{
	}
{
}

";
			AcceptSemanticVisitor(program);
			Assert.AreEqual(5, MaxSymbols);
		}


		[Test]
		public void TestOuterDeclInnerDef()
		{
			string program = @"

fun program() : char

	fun foo() : int;
	
	fun bar() : nothing
	
		fun foo() : nothing
		{
		}
	{
	}
	
	fun foo() : char
	{
	}
{
}

";
			AcceptSemanticVisitor(program);
			Assert.AreEqual(4, MaxSymbols);
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
		public void TestFunny1()
		{
			string program = @"

fun program() : int

	fun foo() : nothing
	{
	}

	fun bar() : nothing
	
		fun foo() : nothing
		{
		}
	{
		foo();
	}
{
}

";
			AcceptSemanticVisitor(program);
			Assert.AreEqual(4, MaxSymbols);
		}


		[Test]
		public void TestFunny2()
		{
			string program = @"

fun program() : char

	var a : int;

	fun foo() : int
	{
	}

	fun bar() : nothing
	
		fun foo() : int
		{
		}
	{
		a <- foo();
	}
{
}

";
			AcceptSemanticVisitor(program);
			Assert.AreEqual(5, MaxSymbols);
		}
	}
}
