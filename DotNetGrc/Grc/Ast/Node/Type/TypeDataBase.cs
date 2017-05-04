using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Type
{
	public abstract class TypeDataBase : TypeReturnBase
	{
		public TypeDataBase(string keyword, int line, int pos)
			: base(keyword, line, pos)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
