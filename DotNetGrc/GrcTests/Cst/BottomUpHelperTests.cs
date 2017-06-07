using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;
using Grc.Nodes.Helper;
using Grc.Visitors.Cst;
using Grc.Types;
using Grc.Visitors.Sem;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using NUnit.Framework;
using Grc.Nodes.Cond;
using Grc.Nodes.Func;
using Grc.Nodes.Expr;

namespace GrcTests.Cst
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
