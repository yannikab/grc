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

		private int line;
		private int pos;

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

			List<int> dims = hTypePar.Dims.Select(d => d.Dim).ToList();

			if (hTypePar.DimEmpty != null)
				dims.Insert(0, 0);

			foreach (ParIdentifierT p in identifiers)
				this.parameters.Add(new Parameter(p, keyRef != null, hTypePar.DataType, dims, line, pos));
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
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

		public override string ToString()
		{
			return keyRef ?? "val";
		}
	}
}
