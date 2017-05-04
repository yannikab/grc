using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Type;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Func
{
	public class LocalVarDef : LocalBase
	{
		private List<VarIdentifierT> identifiers;
		private HTypeVar hTypeVar;

		private List<Variable> variables;

		private string keyVar;
		private string colon;
		private string semicolon;

		private string text;

		private int line;
		private int pos;

		public IReadOnlyList<VarIdentifierT> Identifiers
		{
			get { ProcessChildren(); return identifiers; }
		}

		public HTypeVar HTypeVar
		{
			get { ProcessChildren(); return hTypeVar; }
		}

		public IReadOnlyList<Variable> Variables
		{
			get { ProcessChildren(); return variables; }
		}

		public override string Text
		{
			get { ProcessChildren(); return text; }
		}

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public LocalVarDef(string keyVar, string colon, string semicolon, int line, int pos)
		{
			this.keyVar = keyVar;
			this.colon = colon;
			this.semicolon = semicolon;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (identifiers != null || hTypeVar != null || variables != null)
				return;

			identifiers = new List<VarIdentifierT>();

			foreach (NodeBase c in Children)
			{
				if (c is VarIdentifierT)
				{
					identifiers.Add((VarIdentifierT)c);
				}
				else if (c is HTypeVar)
				{
					if (hTypeVar != null)
						throw new NodeException("Variable type specified by two children.");

					hTypeVar = (HTypeVar)c;
				}
				else
				{
					throw new NodeException("Invalid child type.");
				}
			}

			variables = new List<Variable>();

			foreach (VarIdentifierT v in identifiers)
				variables.Add(new Variable(v.Text, hTypeVar.DataType, hTypeVar.Dims.Select(d => d.Dim).ToList()));

			StringBuilder sb = new StringBuilder();

			sb.Append(keyVar + " ");

			for (int i = 0; i < variables.Count; i++)
			{
				sb.Append(variables[i].Name);

				if (i < variables.Count - 1)
					sb.Append(", ");
			}

			sb.Append(string.Format(" {0} ", colon));

			sb.Append(hTypeVar.Text);

			sb.Append(semicolon);

			this.text = sb.ToString();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return keyVar;
		}
	}
}
