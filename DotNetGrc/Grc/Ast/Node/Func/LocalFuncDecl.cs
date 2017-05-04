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

		private string text;

		private int line;
		private int pos;

		public IReadOnlyList<HPar> HPars
		{
			get { ProcessChildren(); return hPars; }
		}

		public HTypeReturn HTypeReturn
		{
			get { ProcessChildren(); return hTypeReturn; }
		}

		public IReadOnlyList<Parameter> Params
		{
			get { ProcessChildren(); return parameters; }
		}

		public string Name { get { return id; } }

		public override string Text
		{
			get { ProcessChildren(); return text; }
		}

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
		}

		protected override void ProcessChildren()
		{
			if (hPars != null || hTypeReturn != null || parameters != null)
				return;

			hPars = new List<HPar>();

			for (int i = 0; i < Children.Count; i++)
			{
				NodeBase c = Children[i];

				if (c is HPar)
				{
					hPars.Add((HPar)c);
				}
				else if (c is HTypeReturn)
				{
					if (hTypeReturn != null)
						throw new NodeException("Return type specified by two children.");

					hTypeReturn = (HTypeReturn)c;
				}
				else
				{
					throw new NodeException("Invalid child type.");
				}
			}

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
