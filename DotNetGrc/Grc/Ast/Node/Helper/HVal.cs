using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Helper
{
	class HVal : NodeBase
	{
		public HVal() : base("val")
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
