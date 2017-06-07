using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Type;

namespace Grc.Visitors.Cil
{
	public class ContextWrapper
	{
		public void WrapIntoContext(Root root)
		{
			if (root.Program == null)
				return;

			ExprFuncCall exprFuncCall = new ExprFuncCall(new List<ExprBase>(), root.Program.Header.Name, "(", ")", 0, 0);
			StmtFuncCall stmtFuncCall = new StmtFuncCall(exprFuncCall, ";");

			StmtBlock stmtBlock = new StmtBlock(new List<StmtBase>() { stmtFuncCall }, "{", "}", 0, 0);
	
			LocalFuncDecl header = new LocalFuncDecl(new List<HPar>(), new HTypeReturn(new TypeReturnNothingT("nothing", 0, 0)), "fun", "", "(", ")", ":", 0, 0);
			LocalFuncDef context = new LocalFuncDef(header, new List<LocalBase>() { root.Program }, stmtBlock);

			context.Parent = root;

			root.Program = context;
		}
	}
}
