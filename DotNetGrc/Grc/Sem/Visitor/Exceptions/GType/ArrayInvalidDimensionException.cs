﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Type;
using Grc.Ast.Node;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class ArrayInvalidDimensionException : GTypeException
	{
		public ArrayInvalidDimensionException(NodeBase n, SystemException e)
			: base(string.Format("{0} Invalid array dimension: {1}", n.Location, n.Text), e)
		{
		}

		public ArrayInvalidDimensionException(NodeBase n)
			: base(string.Format("{0} Invalid array dimension: {1}", n.Location, n.Text))
		{
		}

		public ArrayInvalidDimensionException(NodeBase n, ExprBase c, SystemException e)
			: base(string.Format("{0} Expression {{{1}}} has an array index that is out of bounds: {2}", c.Location, n.Text, c.Text), e)
		{
		}

		public ArrayInvalidDimensionException(NodeBase n, ExprBase c)
			: base(string.Format("{0} Expression {{{1}}} has an array index that is out of bounds: {2}", c.Location, n.Text, c.Text))
		{
		}
	}
}
