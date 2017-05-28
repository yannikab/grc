using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Func
{
	public partial class LocalFuncDef : LocalBase
	{
		public override IEnumerable<Quad> IR
		{
			get
			{
				IEnumerable<Quad> ie = this.ir.GetRange(0, 1);

				foreach (LocalBase l in locals)
					ie = ie.Concat(l.IR);

				ie = ie.Concat(stmtBlock.IR);

				return ie.Concat(this.ir.GetRange(1, 1));
			}
		}
	}
}
