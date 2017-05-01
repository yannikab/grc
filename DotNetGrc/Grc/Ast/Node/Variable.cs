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
		private IList<int> dims;

		public Variable(string id, TypeDataBase type, IList<int> dims)
		{
			this.id = id;
			this.type = type;
			this.dims = dims;
		}

		public override string ToString()
		{
			string t = id + "\n" + type.Text;

			foreach (int i in dims)
				t += "[" + i + "]";

			return t;
		}
	}
}
