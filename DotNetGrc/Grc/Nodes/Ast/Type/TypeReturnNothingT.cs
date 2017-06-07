using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Type
{
	public class TypeReturnNothingT : TypeReturnBase
	{
		public TypeReturnNothingT(string keyNothing, int line, int pos)
			: base(keyNothing, line, pos)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
