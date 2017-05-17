﻿using System;
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
			Assert.AreEqual(LibrarySymbols + 2, symbolTable.MaxSymbols);
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
			Assert.AreEqual(LibrarySymbols + 6, symbolTable.MaxSymbols);
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
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
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
	}
}
