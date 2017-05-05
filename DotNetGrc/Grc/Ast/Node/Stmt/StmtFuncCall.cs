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

		public IReadOnlyList<ExprBase> Args { get { return funCall.Args; } }

		public string Name { get { return funCall.Name; } }

		public override int Line { get { return funCall.Line; } }

		public override int Pos { get { return funCall.Pos; } }

		public StmtFuncCall(string semicolon)
		{
			this.semicolon = semicolon;
		}

		public override void AddChild(NodeBase c)
		{
			if (funCall != null || (funCall = c as ExprFuncCall) == null)
				throw new NodeException();

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("{0}{1}", funCall.Text, semicolon);
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", funCall.ToString(), semicolon);
		}
	}
}
