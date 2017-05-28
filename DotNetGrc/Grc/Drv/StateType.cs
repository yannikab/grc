using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Cst.Visitor.ASTCreation;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using Grc.Sem.Visitor;
using Grc.Sem.SymbolTable;

namespace Grc.Drv
{
	class StateType : StateBase
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

				root.Accept(new GTypeVisitor());

				System.Console.WriteLine("Type checking success");

				context.State = new StateExitSuccess();

				return;
			}
			catch (LexerException e)
			{
				e.printStackTrace();
			}
			catch (IOException e)
			{
				e.printStackTrace();
			}

			System.Console.WriteLine();

			System.Console.WriteLine("Type checking failure");

			context.State = new StateExitFailure();
		}
	}
}
