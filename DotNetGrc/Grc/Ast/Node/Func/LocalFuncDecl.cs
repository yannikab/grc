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
	public class LocalFuncDecl : LocalBase
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

		public IReadOnlyList<Parameter> Parameters
		{
			get
			{
				if (parameters != null)
					return parameters;

				parameters = new List<Parameter>();

				for (int i = 0; i < hPars.Count; i++)
					parameters.AddRange(hPars[i].Parameters);

				return parameters;
			}
		}

		public string Name { get { return id; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public LocalFuncDecl(string keyFun, string id, string lpar, string rpar, string colon, int line, int pos)
		{
			this.keyFun = keyFun;
			this.id = id;
			this.lpar = lpar;
			this.rpar = rpar;
			this.colon = colon;

			this.line = line;
			this.pos = pos;

			this.hPars = new List<HPar>();
		}

		public override void AddChild(NodeBase c)
		{
			if (hTypeReturn != null)
				throw new NodeException();

			if (c is HPar)
				hPars.Add((HPar)c);
			else if (c is HTypeReturn)
				hTypeReturn = (HTypeReturn)c;
			else
				throw new NodeException();

			base.AddChild(c);
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

			parameters = new List<Parameter>();

			for (int i = 0; i < hPars.Count; i++)
			{
				parameters.AddRange(hPars[i].Parameters);

				sb.Append(hPars[i].Text);

				if (i < hPars.Count - 1)
					sb.Append("; ");
			}

			sb.Append(this.rpar);

			sb.Append(string.Format(" {0} ", this.colon));

			sb.Append(this.hTypeReturn.Text);

			return sb.ToString();
		}

		public override string ToString()
		{
			return string.Format("{0}{1}{2}", id, lpar, rpar);
		}
	}
}
