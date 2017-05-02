using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Type
{
	public class DimIntegerT : NodeBase
	{
		private int dim;

		public virtual int Dim
		{
			get { return this.dim; }
		}

		public DimIntegerT(string text) : base(text)
		{
			this.dim = int.Parse(text.Replace("[", "").Replace("]", ""));
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
