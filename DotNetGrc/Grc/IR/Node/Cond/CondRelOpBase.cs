using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Cond
{
	public abstract partial class CondRelOpBase : CondBase
	{
		public override IEnumerable<Quad> IR
		{
			get { return left.IR.Concat(right.IR).Concat(this.ir); }
		}
	}
}
