using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Sem.SymbolTable;
using Grc.Sem.Visitor;
using Grc.Sem.Visitor.Exceptions.GType;
using Grc.Sem.Visitor.Exceptions.Sem;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		private static ISymbolTable AcceptGTypeVisitor(string program)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			Root root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			ISymbolTable symbolTable = new StackSymbolTable();
			root.Accept(new GTypeVisitor(out symbolTable));
			return symbolTable;
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
			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameVarPar()
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
		public void TestSameParParDef()
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
		public void TestSameParParDecl()
		{
			string program = @"

fun program() : nothing

	fun foo(a : int; a : char) : int;
	
	fun foo(b: int; b: char ) : int
	{
		return 0;
	}
{
}

";

			Assert.Throws<VariableAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
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
			ISymbolTable symbolTable = AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
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
			Assert.Throws<VariableNotInOpenScopesException>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<FunctionNotInSymbolTableException>(() => AcceptGTypeVisitor(program));
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
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestDefinedFun()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : int
	{
		return 0;
	}
{
	a <- foo();
}

";
			ISymbolTable symbolTable = AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestDeclaredFun()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : int;
{
	a <- foo();
}

";
			Assert.Throws<FunctionDefinitionMissingException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameFunDefFunDef()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		return 0;
	}

	fun foo() : char
	{
		return 'c';
	}
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameFunDefFunDecl()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		return 0;
	}

	fun foo() : char;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestSameFunDeclFunDecl()
		{
			string program = @"

fun program() : nothing

	fun foo() : int;

	fun foo() : char;
{
}

";
			Assert.Throws<FunctionAlreadyInScopeException>(() => AcceptGTypeVisitor(program));
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
			Assert.Throws<FunctionDefinitionMissingException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestFunDeclFunDef1()
		{
			string program = @"

fun program() : nothing

	fun foo() : char;

	var a, b : char[5];
	
	fun foo() : char
	{
		return 'a';
	}
{
}

";
			ISymbolTable symbolTable = AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestFunDeclFunDef2()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : int;

	var a : int;
	var b : char;

	fun foo(ref c : char) : int
	{
		a <- foo(b);
		return a;
	}
{
}

";
			ISymbolTable symbolTable = AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 6, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestOuterDeclInnerDef()
		{
			string program = @"

fun program() : nothing

	fun foo() : int;
	
	fun bar() : nothing
	
		fun foo() : char
		{
			return 'c';
		}
	{
	}
	
	fun foo() : int
	{
		return 0;
	}
{
}

";
			ISymbolTable symbolTable = AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}

		[Test]
		public void TestHanoi()
		{
			string program = @"

fun solve () : nothing

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
  puts(""Rings: "");
  NumberOfRings <- geti();
  hanoi(NumberOfRings, ""left"", ""right"", ""middle"");
}


";
			AcceptGTypeVisitor(program);
		}


		[Test]
		public void TestFunny1()
		{
			string program = @"

fun program() : nothing

	fun foo() : int
	{
		return 0;
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
			ISymbolTable symbolTable = AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestFunny2()
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
			ISymbolTable symbolTable = AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, symbolTable.MaxSymbols);
		}
	}
}
