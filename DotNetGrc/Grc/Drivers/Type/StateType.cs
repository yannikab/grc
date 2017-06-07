using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Helper;
using Grc.Visitors.Cst;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;
using Grc.Visitors.Sem;

namespace Grc.Drivers
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

				root.Accept(new TypeVisitor());

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
