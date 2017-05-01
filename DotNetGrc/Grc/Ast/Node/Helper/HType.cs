using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Helper
{
	public class HType : NodeBase
	{
		public HType() : base("type")
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
