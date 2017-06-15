using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Func
{
	public partial class LocalFuncDef : LocalBase
	{
		public override IEnumerable<Quad> Tac
		{
			get
			{
				IEnumerable<Quad> ie = this.tac.Count > 0 ? this.tac.GetRange(0, 1) : this.tac;

				foreach (LocalBase l in locals)
					ie = ie.Concat(l.Tac);

				ie = ie.Concat(stmtBlock.Tac);

				return ie.Concat(this.tac.Count > 1 ? this.tac.GetRange(1, 1) : new List<Quad>());
			}
		}
	}
}
