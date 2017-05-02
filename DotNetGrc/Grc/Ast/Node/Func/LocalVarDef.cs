using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;
using Grc.Ast.Node.Type;
using Grc.Ast.Node.Helper;

namespace Grc.Ast.Node.Func
{
	public class LocalVarDef : LocalBase
	{
		private List<Variable> vars;

		public virtual IReadOnlyList<Variable> Vars
		{
			get { return this.vars; }
		}

		public LocalVarDef(string text)
			: base(text)
		{
			this.vars = new List<Variable>();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public void getVars()
		{
			if (!(Parent is LocalFuncDef))
				return;

			IList<string> vars = new List<string>();

			for (int i = 0; i < Children.Count; i++)
			{
				NodeBase p = Children[i];

				if (p is VarIdentifierT)
				{
					vars.Add(((VarIdentifierT)p).Text);
				}
				else if (p is HType)
				{
					addVars(vars, (HType)p);
				}
				else
				{
					return;
				}
			}
		}

		private void addVars(IList<string> vars, HType t)
		{
			TypeDataBase type = null;

			IList<int> dims = new List<int>();

			for (int i = 0; i < t.Children.Count; i++)
			{
				NodeBase c = t.Children[i];

				if (c is TypeDataBase)
				{
					type = (TypeDataBase)c;
				}
				else if (c is DimIntegerT)
				{
					dims.Add(((DimIntegerT)c).Dim);
				}
				else
				{
					return;
				}
			}

			if (type == null)
				return;

			for (int i = 0; i < vars.Count; i++)
				this.vars.Add(new Variable(vars[i], type, dims));
		}
	}
}
