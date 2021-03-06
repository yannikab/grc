﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Cond
{
	public partial class CondOr : CondBase
	{
		private readonly CondBase left;
		private readonly CondBase right;

		private readonly string operOr;

		public CondBase Left { get { return left; } }

		public CondBase Right { get { return right; } }

		public override int Line { get { return left.Line; } }

		public override int Pos { get { return left.Pos; } }

		public CondOr(CondBase left, CondBase right, string operOr)
		{
			this.left = left;
			this.right = right;

			this.operOr = operOr;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return string.Format("({0} {1} {2})", left.Text, operOr, right.Text); }
		}

		public override string ToString()
		{
			return operOr;
		}
	}
}
