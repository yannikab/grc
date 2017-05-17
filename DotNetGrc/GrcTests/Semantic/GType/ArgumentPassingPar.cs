using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.Types;
using NUnit.Framework;

namespace GrcTests.Semantic
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		[Test]
		public void TestArrayCharElementPassedByReferencePar()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}

	fun bar(ref c : char[]) : nothing
	{
		foo(c[0]);
	}
{
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestArrayArrayCharElementPassedByReferencePar()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}

	fun bar(ref c : char[][5]) : nothing
	{
		foo(c[0][2]);
	}
{
}

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestArrayPassedByReferencePar()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char[]) : nothing
	{
	}

	fun bar(ref c : char[]) : nothing
	{
		foo(c);
	}
{
}		

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestArrayElementPassedByReferencePar()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char[]) : nothing
	{
	}

	fun bar(ref c : char[][10]) : nothing
	{
		foo(c[0]);
	}
{
}		

";
			ISymbolTable symbolTable;
			Dictionary<NodeBase, GTypeBase> typeForNode;
			AcceptGTypeVisitor(program, out symbolTable, out typeForNode);
			Assert.AreEqual(4, symbolTable.MaxSymbols);
		}
	}
}
