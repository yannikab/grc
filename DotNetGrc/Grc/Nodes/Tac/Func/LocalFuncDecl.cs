using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Nodes.Func
{
	public partial class LocalFuncDecl : LocalBase
	{
		public void ChangeName(string name)
		{
			this.id = name;
		}
	}
}
