using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Type;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Helper
{
	public class HPar : NodeBase
	{
		private List<ParIdentifierT> identifiers;
		private HTypePar hTypePar;

		private List<Parameter> parameters;

		private string keyRef;
		private string colon;

		private string text;

		private int line;
		private int pos;

		public IReadOnlyList<ParIdentifierT> Identifiers
		{
			get { ProcessChildren(); return identifiers; }
		}

		public HTypePar HTypePar
		{
			get { ProcessChildren(); return hTypePar; }
		}

		public IReadOnlyList<Parameter> Parameters
		{
			get { ProcessChildren(); return parameters; }
		}

		public override string Text
		{
			get { ProcessChildren(); return text; }
		}

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public HPar(string keyRef, string colon, int line, int pos)
		{
			this.keyRef = keyRef;
			this.colon = colon;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (identifiers != null || hTypePar != null || parameters != null)
				return;

			identifiers = new List<ParIdentifierT>();

			foreach (NodeBase c in Children)
			{
				if (c is ParIdentifierT)
				{
					identifiers.Add((ParIdentifierT)c);
				}
				else if (c is HTypePar)
				{
					if (hTypePar != null)
						throw new NodeException("Parameter type specified by two children.");

					hTypePar = (HTypePar)c;
				}
				else
				{
					throw new NodeException("Invalid child type.");
				}
			}

			parameters = new List<Parameter>();

			foreach (ParIdentifierT p in identifiers)
				parameters.Add(new Parameter(p.Text, keyRef != null, hTypePar.DataType, hTypePar.DimEmpty != null, hTypePar.Dims.Select(d => d.Dim).ToList()));

			StringBuilder sb = new StringBuilder();

			sb.Append(keyRef != null ? keyRef + " " : string.Empty);

			for (int i = 0; i < parameters.Count; i++)
			{
				sb.Append(parameters[i].Name);

				if (i < parameters.Count - 1)
					sb.Append(", ");
			}

			sb.Append(string.Format(" {0} ", colon));

			sb.Append(hTypePar.Text);

			this.text = sb.ToString();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return keyRef ?? "val";
		}
	}
}
