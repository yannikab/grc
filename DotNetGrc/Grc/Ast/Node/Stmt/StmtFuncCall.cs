using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtFuncCall : StmtBase
	{
		private readonly ExprFuncCall funCall;

		private string name;

		private readonly string semicolon;

		public ExprFuncCall FunCall { get { return funCall; } }

		public IReadOnlyList<ExprBase> Args { get { return funCall.Args; } }

		public string Name { get { return name; } }

		public override int Line { get { return funCall.Line; } }

		public override int Pos { get { return funCall.Pos; } }

		public StmtFuncCall(ExprFuncCall funCall, string semicolon)
		{
			this.funCall = funCall;
			this.name = funCall.Name;

			this.semicolon = semicolon;

			this.funCall.Parent = this;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return string.Format("{0}{1}{2}{3}", Tabs, funCall.Text, semicolon, Environment.NewLine); }
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", funCall.ToString(), semicolon);
		}
	}
}
