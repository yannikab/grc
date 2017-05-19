﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;


namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class InvalidTypeInRelOpException : GTypeException
	{
		public InvalidTypeInRelOpException(CondRelOpBase n, ExprBase c)
			: base(string.Format("{0} Expression {{{1}}} of type {{{2}}} not allowed with relational operator {{{3}}}.", c.Location, c.Text, c.Type, n))
		{
		}

		public InvalidTypeInRelOpException(CondRelOpBase n)
			: base(string.Format("{0} Expression {{{1}}} of type {{{2}}} and expression {{{3}}} of type {{{4}}} are incompatible when used with relational operator {{{5}}}.", n.Location, n.Left.Text, n.Left.Type, n.Right.Text, n.Right.Type, n))
		{
		}
	}
}
