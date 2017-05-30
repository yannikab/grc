using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Type;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Func
{
	public partial class LocalFuncDecl : LocalBase
	{
		private List<HPar> hPars;
		private HTypeReturn hTypeReturn;

		private List<Parameter> parameters;

		private string keyFun;
		private string id;
		private string lpar;
		private string rpar;
		private string colon;

		private int line;
		private int pos;

		public IReadOnlyList<HPar> HPars { get { return hPars; } }

		public HTypeReturn HTypeReturn { get { return hTypeReturn; } }

		public IReadOnlyList<Parameter> Parameters { get { return parameters; } }

		public string Name { get { return id; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public LocalFuncDecl(List<HPar> hPars, HTypeReturn hTypeReturn, string keyFun, string id, string lpar, string rpar, string colon, int line, int pos)
		{
			this.hPars = hPars;
			this.hTypeReturn = hTypeReturn;

			this.keyFun = keyFun;
			this.id = id;
			this.lpar = lpar;
			this.rpar = rpar;
			this.colon = colon;

			this.line = line;
			this.pos = pos;

			this.parameters = new List<Parameter>();

			for (int i = 0; i < hPars.Count; i++)
				this.parameters.AddRange(hPars[i].Parameters);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(this.keyFun + " ");

			sb.Append(this.id);

			sb.Append(this.lpar);

			for (int i = 0; i < hPars.Count; i++)
			{
				sb.Append(hPars[i].Text);

				if (i < hPars.Count - 1)
					sb.Append("; ");
			}

			sb.Append(this.rpar);

			sb.Append(string.Format(" {0} ", this.colon));

			sb.Append(this.hTypeReturn.Text);

			sb.Append(";");

			return sb.ToString();
		}

		public override string ToString()
		{
			string s = id.Remove(0, id[0] == '_' ? 1 : 0).Replace(".", "." + Environment.NewLine);

			return string.Format("decl:{0} {1}{2}{3}", Environment.NewLine, s, lpar, rpar);
		}
	}
}
