using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Node
{
	public class Variable
	{
		private VarIdentifierT varIdentifier;
		private TypeDataBase type;
		private IReadOnlyList<int> dims;

		private int line;
		private int pos;

		public VarIdentifierT VarIdentifier { get { return varIdentifier; } }

		public string Name { get { return varIdentifier.Text; } }

		public TypeDataBase Type { get { return type; } }

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
					sb.Append(string.Format("[{0}]", d.ToString()));

				return sb.ToString();
			}
		}

		public int Line { get { return line; } }

		public int Pos { get { return pos; } }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", line, pos); }
		}

		public Variable(VarIdentifierT varIdentifier, TypeDataBase type, List<int> dims, int line, int pos)
		{
			this.varIdentifier = varIdentifier;
			this.type = type;
			this.dims = dims;

			this.line = line;
			this.pos = pos;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
