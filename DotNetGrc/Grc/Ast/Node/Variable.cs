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
		private string name;
		private TypeDataBase type;
		private IList<int> dims;

		public string Name
		{
			get { return name; }
		}

		public Variable(string name, TypeDataBase type, IList<int> dims)
		{
			this.name = name;
			this.type = type;
			this.dims = dims;
		}

		public override string ToString()
		{
			string t = name + "\n" + type.Text;

			foreach (int i in dims)
				t += "[" + i + "]";

			return t;
		}
	}
}
