using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Node
{
	public class Variable
	{
		private string id;
		private TypeDataBase type;
		private IReadOnlyList<int> dims;

		public string Name { get { return id; } }

		public Variable(string id, TypeDataBase type, IReadOnlyList<int> dims)
		{
			this.id = id;
			this.type = type;
			this.dims = dims;
		}
	}
}
