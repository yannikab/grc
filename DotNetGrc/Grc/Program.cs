using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;
using Grc.Ast.Visitor.GraphViz;
using Grc.Cst.Visitor.ASTCreation;
using Grc.Cst.Visitor.GraphViz;
using java.io;
using k31.grc.cst.lexer;
using k31.grc.cst.node;
using k31.grc.cst.parser;

namespace Grc
{
	class Program
	{
		static void Main(string[] args)
		{
			string filename = null;
			string module = null;
			string action = null;

			if (args.Length == 0 || args.Length > 3)
			{
				System.Console.WriteLine("Usage: grc [module] [action] file");
				return;
			}
			else if (args.Length == 1)
			{
				module = "graphviz";
				action = "ast";
				filename = args[0];
			}
			else if (args.Length == 2)
			{
				module = args[0];
				action = "ast";
				filename = args[1];
			}
			else if (args.Length == 3)
			{
				module = args[0];
				action = args[1];
				filename = args[2];
			}

			if (module == null || action == null || filename == null)
				return;

			// Console.WriteLine(module);
			// Console.WriteLine(action);
			// Console.WriteLine(filename);

			if (module.Equals("lex"))
			{
				Lex(filename);
			}
			else if (module.Equals("parse"))
			{
				if (action.Equals("cst"))
				{
					ParseCst(filename);
				}
				else if (action.Equals("ast"))
				{
					ParseAst(filename);
				}
				else
				{
					System.Console.WriteLine(string.Format("Invalid action name '%s'", action));
					System.Console.WriteLine(string.Format("(available actions for module 'parse': %s, %s)", "cst", "ast"));
					return;
				}
			}
			else if (module.Equals("graphviz"))
			{
				if (action.Equals("cstsimple"))
				{
					GraphvizCst(filename, true);
				}
				else if (action.Equals("cst"))
				{
					GraphvizCst(filename, false);
				}
				else if (action.Equals("cst2ast"))
				{
					GraphvizCsTtoAst(filename);
				}
				else if (action.Equals("ast"))
				{
					GraphvizAst(filename);
				}
				else
				{
					System.Console.WriteLine(string.Format("Invalid action name '%s'", action));
					System.Console.WriteLine(string.Format("(available actions for module 'graphviz': %s, %s, %s, %s)", "cstsimple", "cst", "cst2ast", "ast"));
					return;
				}
			}
			else
			{
				System.Console.WriteLine(string.Format("Invalid module name '%s'", module));
				System.Console.WriteLine(string.Format("(available modules: %s, %s, %s)", "lex", "parse", "graphviz"));
				return;
			}

			//System.Console.ReadLine();
		}

		private static void Lex(string filename)
		{
			FileReader fr;

			try
			{
				fr = new FileReader(filename);
			}
			catch (FileNotFoundException)
			{
				// e.printStackTrace();
				System.Console.WriteLine("File not found: " + filename);

				return;
			}

			Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

			Token token;

			try
			{
				for (token = lexer.next(); !(token is EOF); token = lexer.next())
					System.Console.Write("\"" + token.getText() + "\": " + token.getClass().getSimpleName() + Environment.NewLine);

				System.Console.WriteLine("success");

				return;
			}
			catch (LexerException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			System.Console.WriteLine("lex failure");
		}

		private static void ParseCst(string filename)
		{
			FileReader fr;

			try
			{
				fr = new FileReader(filename);
			}
			catch (FileNotFoundException)
			{
				// e.printStackTrace();
				System.Console.WriteLine("File not found: " + filename);

				return;
			}

			Parser parser = new Parser(new Lexer(new PushbackReader(fr, 4096)));

			try
			{
				parser.parse();
				System.Console.WriteLine("parse cst success");

				return;
			}
			catch (ParserException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (LexerException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			System.Console.WriteLine("parse cst failure");
		}

		private static void ParseAst(string filename)
		{
			FileReader fr;

			try
			{
				fr = new FileReader(filename);
			}
			catch (FileNotFoundException)
			{
				// e.printStackTrace();
				System.Console.WriteLine("File not found: " + filename);

				return;
			}

			Parser parser = new Parser(new Lexer(new PushbackReader(fr, 4096)));

			try
			{
				parser.parse().apply(new ASTCreationVisitor(new Root()));
				System.Console.WriteLine("parse ast success");

				return;
			}
			catch (ParserException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (LexerException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			System.Console.WriteLine("parse ast failure");
		}

		private static void GraphvizCst(string filename, bool simple)
		{
			FileReader fr;

			try
			{
				fr = new FileReader(filename);
			}
			catch (FileNotFoundException)
			{
				// e.printStackTrace();
				System.Console.WriteLine("File not found: " + filename);

				return;
			}

			Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

			Parser parser = new Parser(lexer);

			try
			{
				GVNode root = new GVNode(-1);
				parser.parse().apply(simple ? new GraphVizTraversal(root) : new GraphVizTraversalTokens(root));

				// root.print();
				// root.printRelations();

				System.Console.WriteLine("graph\n{");
				root.printGraphViz();
				System.Console.WriteLine("}");
			}
			catch (ParserException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (LexerException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

		private static void GraphvizCsTtoAst(string filename)
		{
			FileReader fr;

			try
			{
				fr = new FileReader(filename);
			}
			catch (FileNotFoundException)
			{
				// e.printStackTrace();
				System.Console.WriteLine("File not found: " + filename);

				return;
			}

			Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

			Parser parser = new Parser(lexer);

			try
			{
				//GVNode root = new GVNode(-1);
				//parser.parse().apply(new GraphVizTraversalAST(root));
				parser.parse();

				//// root.print();
				//// root.printRelations();

				//System.Console.WriteLine("graph\n{");
				//root.printGraphViz();
				//System.Console.WriteLine("}");
			}
			catch (ParserException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (LexerException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

		private static void GraphvizAst(string filename)
		{
			FileReader fr;

			try
			{
				fr = new FileReader(filename);
			}
			catch (FileNotFoundException)
			{
				// e.printStackTrace();
				System.Console.WriteLine("File not found: " + filename);

				return;
			}

			Parser parser = new Parser(new Lexer(new PushbackReader(fr, 4096)));

			try
			{
				NodeBase root = new Root();

				parser.parse().apply(new ASTCreationVisitor(root));

				// root.accept(new GraphVizChildrenVisitor());
				root.Accept(new GraphVizNodeDataVisitor());
			}
			catch (ParserException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (LexerException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
}
