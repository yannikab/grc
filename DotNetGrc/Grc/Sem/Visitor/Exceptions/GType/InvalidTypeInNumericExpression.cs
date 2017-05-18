﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class InvalidTypeInNumericExpression : GTypeException
	{
		public InvalidTypeInNumericExpression(NodeBase n)
			: base(string.Format("{0} Numeric expression can not involve type {1}: {2}", n.Location, n.Type, n.Text))
		{
		}
	}
}
