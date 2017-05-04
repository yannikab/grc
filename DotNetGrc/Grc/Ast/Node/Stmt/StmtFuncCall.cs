using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtFuncCall : StmtBase
	{
		private ExprFuncCall funCall;

		private string semicolon;

		public IReadOnlyList<ExprBase> Args
		{
			get { ProcessChildren(); return funCall.Args; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("{0}{1}", funCall.Text, semicolon);
			}
		}

		public string Name
		{
			get { ProcessChildren(); return funCall.Name; }
		}

		public override int Line
		{
			get { ProcessChildren(); return funCall.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return funCall.Pos; }
		}

		public StmtFuncCall(string semicolon)
		{
			this.semicolon = semicolon;
		}

		protected override void ProcessChildren()
		{
			if (this.funCall != null)
				return;

			if (Children.Count > 1)
				throw new NodeException("Function call statement must have one child.");

			this.funCall = (ExprFuncCall)Children[0];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			ProcessChildren();

			return string.Format("{0}{1}", funCall.ToString(), semicolon);
		}
	}
}
