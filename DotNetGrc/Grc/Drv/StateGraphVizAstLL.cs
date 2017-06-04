﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Ast.Visitor.GraphViz;
using Grc.Cil.Visitor;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Sem.Visitor;
using Grc.Tac.Visitor;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.parser;

namespace Grc.Drv
{
	class StateGraphVizAstLL : StateBase
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

				root.Accept(new GraphVizNodeDataVisitor());

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