using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.Types;
using Grc.Semantic.Visitor.Exceptions.GType;
using NUnit.Framework;

namespace GrcTests.Semantic
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
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
		public void TestArrayCharElementPassedByReference()
		{
			string program = @"

fun program() : nothing

	var c : char[10];

	fun foo(ref a : char) : nothing
	{
	}
{
	foo(c[0]);
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
		}

		[Test]
		public void TestStringCharElementPassedByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}
{
	foo(""hello""[2]);
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(3, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestArrayArrayCharElementPassedByReference()
		{
			string program = @"

fun program() : nothing

	var c : char[10][5];

	fun foo(ref a : char) : nothing
	{
	}
{
	foo(c[0][2]);
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
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
		public void TestArrayElementPassedByReference()
		{
			string program = @"

fun program() : nothing

	var c : char[10][5];

	fun foo(ref a : char[]) : nothing
	{
	}
{
	foo(c[0]);
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
		}
	}
}
