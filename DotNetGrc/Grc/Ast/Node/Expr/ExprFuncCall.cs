using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;
using Grc.Ast.Node.Stmt;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprFuncCall : ExprBase
	{
		private readonly List<ExprBase> args;

		private string id;
		private readonly string lpar;
		private readonly string rpar;

		private readonly int line;
		private readonly int pos;

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

		public override string Text
		{
			get
			{
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
		}

		public override string ToString()
		{
			return string.Format("{0}{1}{2}{3}", id, lpar, rpar, Parent is StmtFuncCall ? ";" : string.Empty)
				.Remove(0, id[0] == '_' ? (id.Length > 1 && id[1] == '.' ? 2 : 1) : 0)
				.Replace(".", "." + Environment.NewLine);
		}
	}
}
