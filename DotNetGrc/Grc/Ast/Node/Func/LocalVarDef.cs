﻿using System;
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

		private int line;
		private int pos;

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

		protected override string GetText()
		{
			StringBuilder sb = new StringBuilder();

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

		public override string ToString()
		{
			return keyVar;
		}
	}
}
