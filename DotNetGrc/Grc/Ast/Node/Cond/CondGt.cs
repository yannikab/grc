using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	class CondGt : CondRelOpBase
	{
		public CondGt(string text) : base(text)
		{
		}
	}
}
