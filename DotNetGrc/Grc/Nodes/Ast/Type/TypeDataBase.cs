using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Type
{
	public abstract class TypeDataBase : TypeReturnBase
	{
		protected TypeDataBase(string keyword, int line, int pos)
			: base(keyword, line, pos)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
