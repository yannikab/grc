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

		private static void AcceptGTypeVisitor(string program, out ISymbolTable symbolTable)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			Root root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			root.Accept(new GTypeVisitor(out symbolTable));
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
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 1, symbolTable.MaxSymbols);
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
			Assert.Throws<InvalidArrayDimensionException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			Assert.Throws<InvalidArrayDimensionException>(() => AcceptGTypeVisitor(program, out symbolTable));
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
			Assert.Throws<IntegerLiteralOverflowException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}
	}
}
