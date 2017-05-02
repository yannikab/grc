using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Cst.Visitor.ASTCreation.Exceptions
{
	class ASTCreationException : ApplicationException
	{
		public ASTCreationException()
			: base("Inconsistency encountered while building abstract syntax tree.")
		{
		}
	}
}
