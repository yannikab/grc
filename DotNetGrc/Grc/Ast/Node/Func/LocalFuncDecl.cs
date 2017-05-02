using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Type;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Func
{
	public class LocalFuncDecl : LocalBase
	{
		private string name;
		private TypeReturnBase returnType;
		private List<Parameter> parms;

		public virtual string Name
		{
			get { return this.name; }
		}

		public virtual TypeReturnBase ReturnType
		{
			get { return this.returnType; }
			set { this.returnType = value; }
		}

		public virtual IReadOnlyList<Parameter> Params
		{
			get { return this.parms; }
		}

		public LocalFuncDecl(string text)
			: base(text)
		{
			this.name = text.Replace("()", "");

			parms = new List<Parameter>();
		}

		public void AddParam(Parameter p)
		{
			this.parms.Add(p);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			string s = base.ToString();

			// s += "\n: " + returnType.toString();

			return s;
		}

		public void ProcessFuncDecl()
		{
			if (Children.Count < 1)
				return;

			for (int i = 0; i < Children.Count; i++)
			{
				NodeBase c = Children[i];

				if (c is HRef)
				{
					getParams(c, true);
				}
				else if (c is HVal)
				{
					getParams(c, false);
				}
				else if (c is HType)
				{
					getReturnType((HType)c);
				}
				else
				{
					return;
				}
			}
		}

		private void getParams(NodeBase n, bool @ref)
		{
			if (!(n.Parent is LocalFuncDecl))
				return;

			IList<string> @params = new List<string>();

			for (int i = 0; i < n.Children.Count; i++)
			{
				NodeBase p = n.Children[i];

				if (p is FParIdentifierT)
				{
					@params.Add(((FParIdentifierT)p).Text);
				}
				else if (p is HType)
				{
					addParams(@ref, @params, (HType)p);
				}
				else
				{
					return;
				}
			}
		}

		private void addParams(bool @ref, IList<string> @params, HType t)
		{
			TypeDataBase type = null;

			bool dimEmpty = false;

			IList<int> dims = new List<int>();

			for (int i = 0; i < t.Children.Count; i++)
			{
				NodeBase c = t.Children[i];

				if (c is TypeDataBase)
				{
					type = (TypeDataBase)c;
				}
				else if (c is DimEmptyT)
				{
					if (dimEmpty)
						return;

					dimEmpty = true;
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

			for (int i = 0; i < @params.Count; i++)
				AddParam(new Parameter(@params[i], @ref, type, dimEmpty, dims));
		}

		private void getReturnType(HType n)
		{
			if (!(n.Parent is LocalFuncDecl))
				return;

			LocalFuncDecl d = (LocalFuncDecl)n.Parent;

			if (n.Children.Count != 1)
				return;

			NodeBase t = n.Children[0];

			if (!(t is TypeReturnBase))
				return;

			d.ReturnType = (TypeReturnBase)t;
		}
	}
}
