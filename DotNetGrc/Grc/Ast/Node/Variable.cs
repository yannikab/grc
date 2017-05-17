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
		private IReadOnlyList<DimIntegerT> dims;

		private int line;
		private int pos;

		public VarIdentifierT VarIdentifier { get { return varIdentifier; } }

		public string Name { get { return varIdentifier.Text; } }

		public TypeDataBase Type { get { return type; } }

		public IReadOnlyList<DimIntegerT> Dims { get { return dims; } }

		public bool Indexed { get { return dims.Count > 0; } }

		public string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.Append(Name);

				sb.Append(" : ");

				sb.Append(type.Text);

				foreach (DimIntegerT d in Dims)
					sb.Append(string.Format("[{0}]", d.Integer));

				return sb.ToString();
			}
		}

		public int Line { get { return line; } }

		public int Pos { get { return pos; } }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", line, pos); }
		}

		public Variable(VarIdentifierT varIdentifier, TypeDataBase type, IReadOnlyList<DimIntegerT> dims, int line, int pos)
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
