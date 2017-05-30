using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprFuncCall : ExprBase
	{
		private List<ExprBase> args;

		private string id;
		private string lpar;
		private string rpar;

		private int line;
		private int pos;

		public IReadOnlyList<ExprBase> Args { get { return args; } }

		public string Name { get { return id; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprFuncCall(List<ExprBase> args, string id, string lpar, string rpar, int line, int pos)
		{
			this.args = args;

			this.id = id;
			this.lpar = lpar;
			this.rpar = rpar;

			this.line = line;
			this.pos = pos;
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
			return string.Format("{0}{1}{2}", id, lpar, rpar)
				.Remove(0, id[0] == '_' ? 1 : 0)
				.Replace(".", "." + Environment.NewLine);
		}
	}
}
