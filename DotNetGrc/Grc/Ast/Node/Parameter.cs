using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Node
{
	class Parameter
	{
		private bool @ref;
		private string id;
		private TypeDataBase type;
		private bool nodim;
		private IList<int?> dims;

		public Parameter(string id, bool @ref, TypeDataBase type, bool nodim, IList<int?> dims)
		{
			this.id = id;
			this.@ref = @ref;
			this.type = type;
			this.nodim = nodim;
			this.dims = dims;
		}

		public override string ToString()
		{
			string t = @ref ? "ref " : "";

			t += id + "\n" + type.Text;

			if (nodim)
				t += "[]";

			foreach (int i in dims)
				t += "[" + i + "]";

			return t;
		}
	}
}
