using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Helper;
using Grc.Visitors.Cst;
using Grc.Visitors.Sem;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class TypeVisitorTests
	{
		protected const int LibrarySymbols = 13;
		protected static int MaxSymbols;

		protected static void AcceptTypeVisitor(string program)
		{
			StringReader sr = new StringReader(program);
			Parser parser = new Parser(new Lexer(new PushbackReader(sr, 4096)));
			Root root = new Root();
			parser.parse().apply(new ASTCreationVisitor(root));
			TypeVisitor v = new TypeVisitor();
			root.Accept(v);
			MaxSymbols = v.SymbolTable.MaxSymbols;
		}
	}
}
