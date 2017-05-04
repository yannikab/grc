using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Helper
{
	public class HTypeVar : NodeBase
	{
		private TypeDataBase dataType;
		private List<DimIntegerT> dims;

		private string text;

		public TypeDataBase DataType
		{
			get { ProcessChildren(); return dataType; }
		}

		public List<DimIntegerT> Dims
		{
			get { ProcessChildren(); return dims; }
		}

		public override string Text
		{
			get { ProcessChildren(); return text; }
		}

		public override int Line
		{
			get { ProcessChildren(); return dataType.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return dataType.Pos; }
		}

		public HTypeVar()
		{
		}

		protected override void ProcessChildren()
		{
			if (dataType != null || dims != null)
				return;

			dims = new List<DimIntegerT>();

			for (int i = 0; i < Children.Count; i++)
			{
				NodeBase c = Children[i];

				if (c is TypeDataBase)
				{
					if (dataType != null)
						throw new NodeException("Data type specified by two children.");

					dataType = (TypeDataBase)c;
				}
				else if (c is DimIntegerT)
				{
					dims.Add((DimIntegerT)c);
				}
				else
				{
					throw new NodeException("Invalid child type.");
				}

				StringBuilder sb = new StringBuilder();

				sb.Append(dataType.Text);

				foreach (var d in dims)
					sb.Append(d.Text);

				this.text = sb.ToString();
			}
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return "type";
		}
	}
}
