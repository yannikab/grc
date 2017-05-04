using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtIfThenElse : StmtBase
	{
		private CondBase cond;
		private StmtBase stmtThen;
		private StmtBase stmtElse;

		private string keyIf;
		private string keyThen;
		private string keyElse;

		private int line;
		private int pos;

		public CondBase Cond
		{
			get { ProcessChildren(); return cond; }
		}

		public StmtBase StmtThen
		{
			get { ProcessChildren(); return stmtThen; }
		}

		public StmtBase StmtElse
		{
			get { ProcessChildren(); return stmtElse; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("{0} {1} {2} {3} {4} {5}",
					keyIf, cond.Text, keyThen, stmtThen.Text, keyElse, stmtElse.Text);
			}
		}

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtIfThenElse(string keyIf, string keyThen, string keyElse, int line, int pos)
		{
			this.keyIf = keyIf;
			this.keyThen = keyThen;
			this.keyElse = keyElse;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (cond != null || stmtThen != null || stmtElse != null)
				return;

			if (Children.Count > 3)
				throw new NodeException("If-then-else statement must have three children.");

			cond = (CondBase)Children[0];
			stmtThen = (StmtBase)Children[1];
			stmtElse = (StmtBase)Children[2];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return string.Format("{0}-{1}-{2}", keyIf, keyThen, keyElse);
		}
	}
}
