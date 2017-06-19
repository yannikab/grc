using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Expr
{
	public partial class ExprLValIdentifierT : ExprLValBase
	{
		public bool IsPar { get; set; }

		public bool IsParByRef { get; set; }
	}
}
