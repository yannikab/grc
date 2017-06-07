using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Nodes.Stmt
{
	public partial class StmtFuncCall : StmtBase
	{
		public void ChangeName(string name)
		{
			this.name = name;
		}
	}
}
