using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Cst;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;

namespace Grc.Driver
{
	class StateGraphVizCst : StateBase
	{
		private bool simple;

		public StateGraphVizCst(bool simple)
		{
			this.simple = simple;
		}

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
				GVNode root = new GVNode(-1);

				parser.parse().apply(simple ? new GraphVizVisitor(root) : new GraphVizVisitorTokens(root));

				System.Console.WriteLine("graph\n{");

				root.printGraphViz();

				System.Console.WriteLine("}");

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
