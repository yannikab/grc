using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Sem.SymbolTable;
using Grc.Sem.Types;
using Grc.Sem.Visitor.Exceptions.GType;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
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
			Assert.AreEqual(LibrarySymbols + 6, symbolTable.MaxSymbols);
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
	}
}
