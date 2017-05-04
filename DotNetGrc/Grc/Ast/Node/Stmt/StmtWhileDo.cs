using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtWhileDo : StmtBase
	{
		private CondBase cond;
		private StmtBase stmt;

		private string keyWhile;
		private string keyDo;

		private int line;
		private int pos;

		public CondBase Cond
		{
			get { ProcessChildren(); return cond; }
		}

		public StmtBase Stmt
		{
			get { ProcessChildren(); return stmt; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("{0} {1} {2} {3}", keyWhile, cond.Text, keyDo, stmt.Text);
			}
		}

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtWhileDo(string keyWhile, string keyDo, int line, int pos)
		{
			this.keyWhile = keyWhile;
			this.keyDo = keyDo;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (cond != null || stmt != null)
				return;

			if (Children.Count > 2)
				throw new NodeException("While-do statement must have two children.");

			cond = (CondBase)Children[0];
			stmt = (StmtBase)Children[1];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
