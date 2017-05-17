using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Sem.SymbolTable;
using Grc.Sem.Types;
using Grc.Sem.Visitor;
using Grc.Sem.Visitor.Exceptions.GType;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		private const int LibrarySymbols = 13;

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
			Assert.AreEqual(LibrarySymbols + 1, symbolTable.MaxSymbols);
			Assert.AreEqual(1, typeForNode.Count);
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
		public void TestIntLiteralOverflow()
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
	}
}
