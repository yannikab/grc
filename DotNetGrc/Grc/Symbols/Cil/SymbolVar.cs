using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;
using Grc.Nodes.Func;

namespace Grc.Symbols
{
	public partial class SymbolVar : SymbolBase
	{
		private ISet<LocalFuncDef> users = new HashSet<LocalFuncDef>();

		public IEnumerable<LocalFuncDef> Users { get { return users; } }

		public void AddUser(LocalFuncDef d)
		{
			users.Add(d);
		}
	}
}
