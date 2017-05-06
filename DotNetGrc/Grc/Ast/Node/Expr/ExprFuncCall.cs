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

		private int line;
		private int pos;

		public IReadOnlyList<ExprBase> Args { get { return args; } }

		public string Name { get { return Text.Replace(lpar + rpar, string.Empty); } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprFuncCall(string id, string lpar, string rpar, int line, int pos)
		{
			this.id = id;
			this.lpar = lpar;
			this.rpar = rpar;

			this.line = line;
			this.pos = pos;

			this.args = new List<ExprBase>();
		}

		public override void AddChild(NodeBase c)
		{
			if (!(c is ExprBase))
				throw new NodeException();

			args.Add((ExprBase)c);

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			if (args == null)
				throw new NodeException("Children have not been properly set.");

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

			return sb.ToString();
		}

		public override string ToString()
		{
			return string.Format("{0}{1}{2}", id, lpar, rpar);
		}
	}
}
