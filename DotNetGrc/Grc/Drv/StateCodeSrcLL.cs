﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Cil.Visitor;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Tac.Visitor;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;

namespace Grc.Drv
{
	class StateCodeSrcLL : StateBase
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

				new ContextWrapper().WrapIntoContext(root);

				root.Accept(new ScopeNameVisitor());

				LLTickVisitor tick = new LLTickVisitor();
				LLBoomVisitor boom = new LLBoomVisitor();

				do
				{
					do
					{
						root.Accept(tick);
					}
					while (tick.MadeChanges);

					root.Accept(boom);

				} while (boom.MadeChanges);

				root.Accept(new ScopeGTypeVisitor());

				System.Console.WriteLine(root.Text);

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

			System.Console.WriteLine("Source parsing failure");

			context.State = new StateExitFailure();
		}
	}
}
