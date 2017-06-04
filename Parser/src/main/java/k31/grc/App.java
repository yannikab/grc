package k31.grc;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PushbackReader;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.node.helper.Root;
import k31.grc.ast.visitor.GraphVizNodeDataVisitor;
import k31.grc.cst.lexer.Lexer;
import k31.grc.cst.lexer.LexerException;
import k31.grc.cst.node.EOF;
import k31.grc.cst.node.Token;
import k31.grc.cst.parser.Parser;
import k31.grc.cst.parser.ParserException;
import k31.grc.cst.visitor.ASTCreationVisitor;
import k31.grc.cst.visitor.GVNode;
import k31.grc.cst.visitor.GraphVizTraversal;
import k31.grc.cst.visitor.GraphVizTraversalAST;
import k31.grc.cst.visitor.GraphVizTraversalTokens;

/**
 * Hello world!
 *
 */
public class App {

	public static void main(String[] args) {

		String filename = null;
		String module = null;
		String action = null;

		if (args.length == 0 || args.length > 3) {

			System.out.println("Usage: grc [module] [action] file");
			return;

		} else if (args.length == 1) {

			module = "graphviz";
			action = "ast";
			filename = args[0];

		} else if (args.length == 2) {

			module = args[0];
			action = "ast";
			filename = args[1];

		} else if (args.length == 3) {

			module = args[0];
			action = args[1];
			filename = args[2];
		}

		// System.out.println(module);
		// System.out.println(action);
		// System.out.println(filename);

		if (module.equals("lex")) {

			lex(filename);

		} else if (module.equals("parse")) {

			if (action.equals("cst")) {

				parseCST(filename);

			} else if (action.equals("ast")) {

				parseAST(filename);

			} else {

				System.out.println(String.format("Invalid action name '%s'", action));
				System.out.println(String.format("(available actions for module 'parse': %s, %s)", "cst", "ast"));
				return;
			}

		} else if (module.equals("graphviz")) {

			if (action.equals("cstsimple")) {

				graphvizCST(filename, true);

			} else if (action.equals("cst")) {

				graphvizCST(filename, false);

			} else if (action.equals("cst2ast")) {

				graphvizCSTtoAST(filename);

			} else if (action.equals("ast")) {

				graphvizAST(filename);

			} else {

				System.out.println(String.format("Invalid action name '%s'", action));
				System.out.println(String.format("(available actions for module 'graphviz': %s, %s, %s, %s)", "cstsimple", "cst", "cst2ast", "ast"));
				return;
			}

		} else {

			System.out.println(String.format("Invalid module name '%s'", module));
			System.out.println(String.format("(available modules: %s, %s, %s)", "lex", "parse", "graphviz"));
			return;
		}
	}

	private static void lex(String filename) {

		FileReader fr;

		try {

			fr = new FileReader(filename);

		} catch (FileNotFoundException e) {
			// e.printStackTrace();
			System.out.println("File not found: " + filename);

			return;
		}

		Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

		Token token;

		try {

			for (token = lexer.next(); !(token instanceof EOF); token = lexer.next()) {

				System.out.print("\"" + token.getText() + "\": " + token.getClass().getSimpleName().toString() + System.lineSeparator());
			}

			System.out.println("success");

			return;

		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();

		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		System.out.println("failure");
	}

	private static void parseCST(String filename) {

		FileReader fr;

		try {

			fr = new FileReader(filename);

		} catch (FileNotFoundException e) {
			// e.printStackTrace();
			System.out.println("File not found: " + filename);

			return;
		}

		Parser parser = new Parser(new Lexer(new PushbackReader(fr, 4096)));

		try {

			parser.parse();
			System.out.println("success");

			return;

		} catch (ParserException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		System.out.println("failure");
	}

	private static void parseAST(String filename) {
		FileReader fr;

		try {

			fr = new FileReader(filename);

		} catch (FileNotFoundException e) {
			// e.printStackTrace();
			System.out.println("File not found: " + filename);

			return;
		}

		Parser parser = new Parser(new Lexer(new PushbackReader(fr, 4096)));

		try {

			parser.parse().apply(new ASTCreationVisitor(new Root()));
			System.out.println("success");

			return;

		} catch (ParserException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		System.out.println("failure");
	}

	private static void graphvizCST(String filename, boolean simple) {

		FileReader fr;

		try {

			fr = new FileReader(filename);

		} catch (FileNotFoundException e) {
			// e.printStackTrace();
			System.out.println("File not found: " + filename);

			return;
		}

		Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

		Parser parser = new Parser(lexer);

		try {

			GVNode root = new GVNode(-1);
			parser.parse().apply(simple ? new GraphVizTraversal(root) : new GraphVizTraversalTokens(root));

			// root.print();
			// root.printRelations();

			System.out.println("graph\n{");
			root.printGraphViz();
			System.out.println("}");

		} catch (ParserException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	private static void graphvizCSTtoAST(String filename) {

		FileReader fr;

		try {

			fr = new FileReader(filename);

		} catch (FileNotFoundException e) {
			// e.printStackTrace();
			System.out.println("File not found: " + filename);

			return;
		}

		Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

		Parser parser = new Parser(lexer);

		try {

			GVNode root = new GVNode(-1);
			parser.parse().apply(new GraphVizTraversalAST(root));

			// root.print();
			// root.printRelations();

			System.out.println("graph\n{");
			root.printGraphViz();
			System.out.println("}");

		} catch (ParserException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	private static void graphvizAST(String filename) {

		FileReader fr;

		try {

			fr = new FileReader(filename);

		} catch (FileNotFoundException e) {
			// e.printStackTrace();
			System.out.println("File not found: " + filename);

			return;
		}

		Parser parser = new Parser(new Lexer(new PushbackReader(fr, 4096)));

		try {

			NodeBase root = new Root();

			parser.parse().apply(new ASTCreationVisitor(root));

			// root.accept(new GraphVizChildrenVisitor());
			root.accept(new GraphVizNodeDataVisitor());

		} catch (ParserException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
