using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;

namespace Grc.Nodes.Func
{
	public partial class LocalFuncDef : LocalBase
	{
		public override IEnumerable<Quad> Tac
		{
			get
			{
				IEnumerable<Quad> ie = this.tac.GetRange(0, 1);

				foreach (LocalBase l in locals)
					ie = ie.Concat(l.Tac);

				ie = ie.Concat(stmtBlock.Tac);

				return ie.Concat(this.tac.GetRange(1, 1));
			}
		}
	}
}
