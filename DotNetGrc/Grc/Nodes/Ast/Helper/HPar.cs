using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;
using Grc.Nodes.Type;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Helper
{
	public class HPar : NodeBase
	{
		private readonly List<ParIdentifierT> identifiers;
		private readonly HTypePar hTypePar;

		private readonly List<Parameter> parameters;

		private readonly string keyRef;
		private readonly string colon;

		private readonly int line;
		private readonly int pos;

		public IReadOnlyList<ParIdentifierT> Identifiers { get { return identifiers; } }

		public HTypePar HTypePar { get { return hTypePar; } }

		public IReadOnlyList<Parameter> Parameters { get { return parameters; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public HPar(List<ParIdentifierT> identifiers, HTypePar hTypePar, string keyRef, string colon, int line, int pos)
		{
			this.identifiers = identifiers;
			this.hTypePar = hTypePar;

			this.keyRef = keyRef;
			this.colon = colon;

			this.line = line;
			this.pos = pos;

			this.parameters = new List<Parameter>();

			foreach (ParIdentifierT p in identifiers)
				this.parameters.Add(new Parameter(p.Text, keyRef != null, hTypePar.DataType, hTypePar.DimEmpty, hTypePar.Dims, p.Line, p.Pos));
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.Append(keyRef != null ? keyRef + " " : string.Empty);

				for (int i = 0; i < Parameters.Count; i++)
				{
					sb.Append(Parameters[i].Name);

					if (i < Parameters.Count - 1)
						sb.Append(", ");
				}

				sb.Append(string.Format(" {0} ", colon));

				sb.Append(hTypePar.Text);

				return sb.ToString();
			}
		}

		public override string ToString()
		{
			return keyRef ?? "val";
		}
	}
}
