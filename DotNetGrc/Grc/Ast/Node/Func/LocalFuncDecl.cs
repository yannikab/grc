using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Func
{
	class LocalFuncDecl : LocalBase
	{
		private string id;
		private TypeReturnBase returnType;
		private List<Parameter> @params;

		public virtual string Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual TypeReturnBase ReturnType
		{
			get { return this.returnType; }
			set { this.returnType = value; }
		}

		public virtual IReadOnlyList<Parameter> Params
		{
			get { return this.@params; }
		}

		public LocalFuncDecl(string @string) : base(@string)
		{
			this.id = @string;

			@params = new List<Parameter>();
		}

		public void AddParam(Parameter p)
		{
			this.@params.Add(p);
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
	}
}
