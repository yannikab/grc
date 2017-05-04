using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprFuncCall : ExprBase
	{
		private List<ExprBase> args;

		private string id;
		private string lpar;
		private string rpar;

		private string text;

		private int line;
		private int pos;

		public IReadOnlyList<ExprBase> Args { get { ProcessChildren(); return args; } }

		public string Name { get { return Text.Replace(lpar + rpar, string.Empty); } }

		public override string Text
		{
			get { ProcessChildren(); return text; }
		}

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprFuncCall(string id, string lpar, string rpar, int line, int pos)
		{
			this.id = id;
			this.lpar = lpar;
			this.rpar = rpar;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (this.args != null)
				return;

			this.args = new List<ExprBase>(Children.Cast<ExprBase>());

			StringBuilder sb = new StringBuilder();

			sb.Append(id);

			sb.Append(lpar);

			for (int i = 0; i < args.Count; i++)
			{
				sb.Append(args[i].Text);
				if (i < args.Count - 1)
					sb.Append(", ");
			}

			sb.Append(rpar);

			this.text = sb.ToString();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return string.Format("{0}{1}{2}", id, lpar, rpar);
		}
	}
}
