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
		private IReadOnlyList<int> dims;

		private int line;
		private int pos;

		public string Name { get { return id; } }

		public bool ByRef { get { return byRef; } }

		public TypeDataBase Type { get { return type; } }

		public bool Nodim { get { return dims.Count > 0 && dims[0] == 0; } }

		public IReadOnlyList<int> Dims { get { return dims; } }

		public string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.Append(Name);
				
				sb.Append(" : ");

				sb.Append(type.Text);

				foreach (int d in Dims)
					sb.Append(string.Format("[{0}]", d != 0 ? d.ToString() : string.Empty));

				return sb.ToString();
			}
		}

		public int Line { get { return line; } }

		public int Pos { get { return pos; } }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", line, pos); }
		}

		public Parameter(string id, bool byRef, TypeDataBase type, IReadOnlyList<int> dims, int line, int pos)
		{
			this.id = id;
			this.byRef = byRef;
			this.type = type;
			this.dims = dims;

			this.line = line;
			this.pos = pos;
		}
	}
}
