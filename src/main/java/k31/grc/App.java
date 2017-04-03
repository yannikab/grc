package k31.grc;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PushbackReader;

import k31.grc.cst.graphviz.GVNode;
import k31.grc.cst.graphviz.GraphVizTraversal;
import k31.grc.cst.graphviz.GraphVizTraversalAST;
import k31.grc.cst.graphviz.GraphVizTraversalTokens;
import k31.grc.cst.lexer.Lexer;
import k31.grc.cst.lexer.LexerException;
import k31.grc.cst.node.EOF;
import k31.grc.cst.node.Token;
import k31.grc.cst.parser.Parser;
import k31.grc.cst.parser.ParserException;

/**
 * Hello world!
 *
 */
public class App {

	public static void main(String[] args) {

		String module = args[0];
		String action = args[1];
		String fileName = args[args.length - 1];

		// System.out.println(module);
		// System.out.println(action);
		// System.out.println(fileName);

		if (module.equals("lex")) {
			System.out.println("lex");
			lex(fileName);
		} else if (module.equals("parse")) {
			if (action.equals("cst"))
				parseCST(fileName);
			else if (action.equals("ast"))
				parseAST(fileName);
		} else if (module.equals("graphviz")) {
			if (action.equals("cstsimple"))
				graphvizCST(fileName, true);
			else if (action.equals("cst"))
				graphvizCST(fileName, false);
			else if (action.equals("ast"))
				graphvizAST(fileName);
		}
	}

	private static void lex(String fileName) {

		FileReader fr;

		try {

			fr = new FileReader(fileName);

		} catch (FileNotFoundException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();

			return;
		}

		Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

		Token token;

		try {

			for (token = lexer.next(); !(token instanceof EOF); token = lexer.next()) {

				System.out.print("\"" + token.getText() + "\": " + token.getClass().getSimpleName().toString() + System.lineSeparator());
			}

		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();

		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	private static void parseCST(String fileName) {

		FileReader fr;

		try {

			fr = new FileReader(fileName);

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();

			return;
		}

		Parser parser = new Parser(new Lexer(new PushbackReader(fr, 4096)));

		try {

			parser.parse();
			System.out.println("success");

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

	private static void parseAST(String fileName) {
		// TODO Auto-generated method stub

	}

	private static void graphvizCST(String fileName, boolean simple) {

		FileReader fr;

		try {

			fr = new FileReader(fileName);

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();

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

	private static void graphvizAST(String fileName) {
		// TODO Auto-generated method stub

		FileReader fr;

		try {

			fr = new FileReader(fileName);

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();

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
}
