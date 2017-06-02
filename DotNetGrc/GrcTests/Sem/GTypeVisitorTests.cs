using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Sem.Visitor;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class GTypeVisitorTests
	{
		protected const int LibrarySymbols = 13;
		protected static int MaxSymbols;

		protected static void AcceptGTypeVisitor(string program)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			Root root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			GTypeVisitor v = new GTypeVisitor();
			root.Accept(v);
			MaxSymbols = v.SymbolTable.MaxSymbols;
		}
	}
}
