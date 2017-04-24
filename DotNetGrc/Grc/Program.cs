using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.io;
using k31.grc.ast.node;
using k31.grc.ast.node.aux;
using k31.grc.ast.visitor;
using k31.grc.cst.lexer;
using k31.grc.cst.node;
using k31.grc.cst.parser;
using k31.grc.cst.visitor;

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

			// Console.WriteLine(module);
			// Console.WriteLine(action);
			// Console.WriteLine(filename);

			if (module.Equals("lex"))
			{
				lex(filename);
			}
			else if (module.Equals("parse"))
			{
				if (action.Equals("cst"))
				{
					parseCST(filename);
				}
				else if (action.Equals("ast"))
				{
					parseAST(filename);
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
					graphvizCST(filename, true);
				}
				else if (action.Equals("cst"))
				{
					graphvizCST(filename, false);
				}
				else if (action.Equals("cst2ast"))
				{
					graphvizCSTtoAST(filename);
				}
				else if (action.Equals("ast"))
				{
					graphvizAST(filename);
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
		}

		private static void lex(string filename)
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
				{
					System.Console.Write("\"" + token.getText() + "\": " + token.getClass().getSimpleName() + Environment.NewLine);
				}

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

			System.Console.WriteLine("failure");
		}

		private static void parseCST(string filename)
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
				System.Console.WriteLine("success");

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

			System.Console.WriteLine("failure");
		}

		private static void parseAST(string filename)
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
				System.Console.WriteLine("success");

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

			System.Console.WriteLine("failure");
		}

		private static void graphvizCST(string filename, bool simple)
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

		private static void graphvizCSTtoAST(string filename)
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
				parser.parse().apply(new GraphVizTraversalAST(root));

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

		private static void graphvizAST(string filename)
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
				root.accept(new GraphVizNodeDataVisitor());
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
