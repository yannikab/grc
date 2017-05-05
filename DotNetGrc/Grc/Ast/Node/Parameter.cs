using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Node
{
	public class Parameter
	{
		private string id;
		private bool byRef;
		private TypeDataBase type;
		private bool nodim;
		private IReadOnlyList<int> dims;

		public string Name { get { return id; } }

		public Parameter(string id, bool byRef, TypeDataBase type, bool nodim, IReadOnlyList<int> dims)
		{
			this.id = id;
			this.byRef = byRef;
			this.type = type;
			this.nodim = nodim;
			this.dims = dims;
		}
	}
}
