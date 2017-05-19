using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using Grc.IR.Quads;
using Grc.IR.Visitor;
using Grc.Sem.SymbolTable;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;


namespace Grc.Drv
{
	class StateCodeIR : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			Lexer lexer = GetLexer(arg);

			if (lexer == null)
			{
				context.State = new StateExitFailure();

				return;
			}

			Parser parser = new Parser(lexer);

			try
			{
				Root root = new Root();

				parser.parse().apply(new ASTCreationVisitor(root));

				ISymbolTable symbolTable;
				Dictionary<Addr, Quad> ir;

				root.Accept(new IRVisitor(out symbolTable, out ir));

				foreach (var q in ir.OrderBy(e => e.Key))
					System.Console.WriteLine(q.Value);

				context.State = new StateExitSuccess();

				return;
			}
			catch (ParserException e)
			{
				e.printStackTrace();
			}
			catch (LexerException e)
			{
				e.printStackTrace();
			}
			catch (IOException e)
			{
				e.printStackTrace();
			}

			context.State = new StateExitFailure();
		}

		private void ShowActions()
		{
			System.Console.WriteLine("Usage: grc [module] [action] [filename]");
			System.Console.Write("Available actions for module code: ir, help");
		}
	}
}
