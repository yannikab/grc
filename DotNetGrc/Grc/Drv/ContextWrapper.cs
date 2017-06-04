using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Type;

namespace Grc.Drv
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
			
			root.Program = context;
		}
	}
}
