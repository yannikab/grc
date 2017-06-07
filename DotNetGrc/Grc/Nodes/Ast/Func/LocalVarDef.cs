using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Helper;
using Grc.Nodes.Type;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Func
{
	public class LocalVarDef : LocalBase
	{
		private readonly List<VarIdentifierT> identifiers;
		private readonly HTypeVar hTypeVar;

		private readonly List<Variable> variables;

		private readonly string keyVar;
		private readonly string colon;
		private readonly string semicolon;

		private readonly int line;
		private readonly int pos;

		public IReadOnlyList<VarIdentifierT> Identifiers { get { return identifiers; } }

		public HTypeVar HTypeVar { get { return hTypeVar; } }

		public IReadOnlyList<Variable> Variables { get { return variables; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public LocalVarDef(List<VarIdentifierT> identifiers, HTypeVar hTypeVar, string keyVar, string colon, string semicolon, int line, int pos)
		{
			this.identifiers = identifiers;
			this.hTypeVar = hTypeVar;

			this.keyVar = keyVar;
			this.colon = colon;
			this.semicolon = semicolon;

			this.line = line;
			this.pos = pos;

			this.variables = new List<Variable>();

			foreach (VarIdentifierT v in identifiers)
				this.variables.Add(new Variable(v.Text, hTypeVar.DataType, hTypeVar.Dims, v.Line, v.Pos));
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

				sb.Append(Tabs);

				sb.Append(keyVar + " ");

				for (int i = 0; i < Variables.Count; i++)
				{
					sb.Append(Variables[i].Name);

					if (i < Variables.Count - 1)
						sb.Append(", ");
				}

				sb.Append(string.Format(" {0} ", colon));

				sb.Append(hTypeVar.Text);

				sb.Append(semicolon);

				return sb.ToString();
			}
		}

		public override string ToString()
		{
			return keyVar;
		}
	}
}
