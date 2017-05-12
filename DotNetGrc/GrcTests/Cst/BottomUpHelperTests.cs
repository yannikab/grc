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
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Expr;

namespace GrcTests.Semantic
{
	[TestFixture]
	public class BottomUpHelperTests : BottomUpHelper<NodeBase>
	{
		[Test]
		public void TestUsage()
		{
			Assert.AreEqual(0, Count);

			Enter();
			Enter();

			Assert.AreEqual(0, Count);

			AddItem(new ExprIntegerT("", 0, 0));

			Assert.AreEqual(1, Count);

			Assert.IsTrue(this[0] is ExprIntegerT);

			Exit();

			Assert.AreEqual(1, Count);

			Enter();

			Assert.AreEqual(0, Count);

			AddItem(new ExprCharacterT("", 0, 0));

			Assert.AreEqual(1, Count);

			Assert.IsTrue(this[0] is ExprCharacterT);

			Exit();

			Assert.AreEqual(2, Count);

			Assert.IsTrue(this[0] is ExprIntegerT);
			Assert.IsTrue(this[1] is ExprCharacterT);

			AddItem(new ExprLValStringT("", 0, 0));

			Assert.AreEqual(3, Count);

			Assert.IsTrue(this[0] is ExprIntegerT);
			Assert.IsTrue(this[1] is ExprCharacterT);
			Assert.IsTrue(this[2] is ExprLValStringT);

			Exit();

			Assert.AreEqual(0, Count);

			Clear();
		}
	}
}
