using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;

namespace Grc.Drivers
{
	class StateParseCst : StateBase
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
				parser.parse();

				System.Console.WriteLine("CST parsing success");

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

			System.Console.WriteLine("CST parsing failure");

			context.State = new StateExitFailure();
		}
	}
}
