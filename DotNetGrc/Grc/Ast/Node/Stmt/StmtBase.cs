using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	abstract class StmtBase : NodeBase
	{
		public StmtBase(string text) : base(text)
		{
		}
	}
}
