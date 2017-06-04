using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;
using Grc.Ast.Node.Func;

namespace Grc.Sem.SymbolTable.Symbol
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
