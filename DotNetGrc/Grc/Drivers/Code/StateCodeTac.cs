using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Helper;
using Grc.Visitors.Cst;
using Grc.Visitors.Tac;
using Grc.Visitors.Sem;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;

namespace Grc.Drivers
{
	class StateCodeTac : StateBase
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

				root.Accept(new ScopeNameVisitor());

				root.Accept(new TacVisitor());

				foreach (var q in root.Program.Tac)
					System.Console.WriteLine(q);

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
	}
}
