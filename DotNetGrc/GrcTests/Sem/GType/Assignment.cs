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
		public void TestAssignFunctionCallNoArgs()
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
		public void TestFunctionCallArgs()
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
		public void TestAssignedIndexedChar()
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
	}
}
