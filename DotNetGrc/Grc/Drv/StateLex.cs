using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k31.grc.cst.lexer;
using k31.grc.cst.node;
using java.io;

namespace Grc.Drv
{
	class StateLex : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			Lexer lexer = GetLexer(arg);

			if (lexer == null)
			{
				context.State = new StateExitFailure();

				return;
			}

			try
			{
				for (Token token = lexer.next(); !(token is EOF); token = lexer.next())
					System.Console.Write("\"" + token.getText() + "\": " + token.getClass().getSimpleName() + Environment.NewLine);

				System.Console.WriteLine();

				System.Console.WriteLine("Lexing success");

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

			System.Console.WriteLine("Lexing failure");

			context.State = new StateExitFailure();
		}
	}
}
