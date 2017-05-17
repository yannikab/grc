using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.Types;
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
		private static void AcceptGTypeVisitor(string program, out ISymbolTable symbolTable, out Dictionary<NodeBase, GTypeBase> typeForNode)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			Root root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			root.Accept(new GTypeVisitor(out symbolTable, out typeForNode));
		}


		[Test]
		public void TestSimple()
		{
			string program = @"

fun program() : nothing
{
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(1, symbolTable.MaxSymbols);
			Assert.AreEqual(1, typeForNode.Count);
		}


		[Test]
		public void TestMainFunctionParameters()
		{
			string program = @"

fun program(a : int) : nothing
{
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<MainFunctionWithParametersException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestMainFunctionReturnValue()
		{
			string program = @"

fun program() : int
{
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<MainFunctionWithReturnValueException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(3, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<IndexedNotByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestIntLiteralPassedByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : int) : nothing
	{
	}
{
	foo(5);
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<RValuePassedByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestCharLiteralPassedByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}
{
	foo('t');
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<RValuePassedByReferenceException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestArrayPassedByReference()
		{
			string program = @"

fun program() : nothing

	var arr : char[5];

	fun foo(ref a : char []) : nothing
	{
	}
{
	foo(arr);
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<IndexingInvalidTypeException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<IndexingInvalidTypeException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidTypeAssignmentException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidTypeAssignmentException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestAddNothing()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : nothing
	{
	}
{
	a <- 5 + foo();
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestAssignNothing()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : nothing
	{
	}
{
	a <- foo();
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidTypeAssignmentException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(3, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(6, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<FunctionArgsMismatchException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<FunctionArgsMismatchException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestFunctionCallExprAdd()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo(c : char; i : int; ref a : char[5]) : int
	{
	}
{
	a <- foo('f', 34, ""hello"") + 5;
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(6, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(2, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<FunctionCallStatementWithoutNothingException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestIndexedExprChar()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char;
	
{
	b <- a[8];	
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(3, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<MismatchedFunctionDefinitionException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestMismatchedDeclDef2()
		{
			string program = @"

fun program() : nothing

	fun foo() : nothing;
	
	fun foo(ref a, b : char[][3][5]) : nothing
	{
	}
{
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<MismatchedFunctionDefinitionException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestFunDeclFunDef()
		{
			string program = @"

fun program() : nothing

	fun foo(a, b : char) : nothing;

	var a, b : char[5];
	
	fun foo(a, b : char) : nothing
	{
	}
{
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(6, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestAddChar()
		{
			string program = @"

fun program() : nothing

	var a, b : char;
{
	a <- a + b;
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestAddIntChar()
		{
			string program = @"

fun program() : nothing

	var a : int;
	var b : char;
{
	a <- a + b;
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidTypeInNumericExpression>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestArraySizeZero()
		{
			string program = @"

fun program() : nothing

	var a : char[0];
{
	a[0] <- 'c';
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidArrayDimensionException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestArraySizeOverflow()
		{
			string program = @"

fun program() : nothing

	var a : char[3534534803854490548903408949805390045093094340538045838048531];
{
	a[0] <- 'c';
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<InvalidArrayDimensionException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
		}


		[Test]
		public void TestIntOverflow()
		{
			string program = @"

fun program() : nothing

	var a : int;
{
	a <- 3534534803854490548903408949805390045093094340538045838048531;
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			Assert.Throws<IntegerLiteralOverflowException>(() => AcceptGTypeVisitor(program, out symbolTable, out typeForNode));
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
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
		}


		[Test]
		public void TestPrimes()
		{
			string program = @"

fun main () : nothing

	fun puts(ref s : char[]) : nothing { }
    fun puti(i : int) : nothing { }
	fun geti() : int { }
    
	fun prime (n : int) : int
      var i : int;
    {
      if n<0              then return prime(-1);
      else if n<2         then return 0;
      else if n=2         then return 1;
      else if n mod 2 = 0 then return 0;
      else {
        i <- 3;
        while i <= n div 2 do {
          if n mod i = 0 then
            return 0;
          i <- i + 2;
        }
        return 1;
      }
    }

    var limit, number, counter : int;

{
   puts(""Limit: "");
   limit <- geti();
   puts(""Primes:\n"");
   counter <- 0;
   if limit >= 2 then {
      counter <- counter + 1;
      puti(2);
      puts(""\n"");
   }
   if limit >= 3 then {
      counter <- counter + 1;
      puti(3);
      puts(""\n"");
   }
   number <- 6;
   while number <= limit do {
      if prime(number - 1) = 1 then {
         counter <- counter + 1;
         puti(number - 1);
         puts(""\n"");
      }
      if number # limit and prime(number + 1) = 1 then {
         counter <- counter + 1;
         puti(number + 1);
         puts(""\n"");
      }
      number <- number + 6;
   }
   puts(""\nTotal: "");
   puti(counter);
   puts(""\n"");
}
";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
		}


		[Test]
		public void TestBSort()
		{
			string program = @"

fun main () : nothing

   fun puts(ref s : char[]) : nothing { }
   fun writeString(ref s : char[]) : nothing { }
   fun puti(i : int) : nothing { }
   
   fun bsort (n : int; ref x : int[]) : nothing

      fun swap (ref x, y : int) : nothing
         var t : int;
      {
         t <- x;
         x <- y;
         y <- t;
      }

      var changed, i : int;
   {
      changed <- 1;
      while changed > 0 do {
        changed <- 0;
        i <- 0;
        while i < n-1 do {
          if x[i] > x[i+1] then {
            swap(x[i],x[i+1]);
            changed <- 1;
          }
          i <- i+1;
        }
      }
   }

   fun putArray (ref msg : char[]; n : int; ref x : int[]) : nothing
      var i : int;
   {
      puts(msg);
      i <- 0;
      while i < n do {
        if i > 0 then writeString("", "");
        puti(x[i]);
        i <- i+1;
      }
      puts(""\n"");
   }

   var seed, i : int;
   var x : int[16];
{
  seed <- 65;
  i <- 0;
  while i < 16 do {
    seed <- (seed * 137 + 220 + i) mod 101;
    x[i] <- seed;
    i <- i+1;
  }
  putArray(""Initial array: "", 16, x);
  bsort(16,x);
  putArray(""Sorted array: "", 16, x);
}
";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
		}
	}
}
