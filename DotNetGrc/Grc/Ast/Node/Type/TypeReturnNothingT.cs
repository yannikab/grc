using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Type
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
