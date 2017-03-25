package k31.grc;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PushbackReader;

import k31.grc.graphviz.GVNode;
import k31.grc.graphviz.GraphVizTraversal;
import k31.grc.lexer.Lexer;
import k31.grc.lexer.LexerException;
import k31.grc.node.Start;
import k31.grc.parser.Parser;
import k31.grc.parser.ParserException;

/**
 * Hello world!
 *
 */
public class App {

	public static void main(String[] args) {

		// System.out.println("Hello World!");
		// System.out.print("hello\n");
		// System.out.println(args[0]);

		FileReader fr;

		try {

			fr = new FileReader(args[0]);

		} catch (FileNotFoundException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();

			return;
		}

		Lexer lexer = new Lexer(new PushbackReader(fr, 4096));

		// Token token;
		//
		// try {
		//
		// for (token = lexer.next(); !(token instanceof EOF); token =
		// lexer.next()) {
		//
		// System.out.print("\"" + token.getText() + "\": " +
		// token.getClass().toString() + System.lineSeparator());
		// }
		//
		// } catch (LexerException e) {
		// // TODO Auto-generated catch block
		// e.printStackTrace();
		//
		// } catch (IOException e) {
		// // TODO Auto-generated catch block
		// e.printStackTrace();
		// }

		try {

			fr = new FileReader(args[0]);

		} catch (FileNotFoundException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();

			return;
		}

		lexer = new Lexer(new PushbackReader(fr, 4096));

		Parser parser = new Parser(lexer);

		Start s;

		try {

			s = parser.parse();

			// SimpleTraversal traversal = new SimpleTraversal();
			// s.apply(traversal);

			GVNode root = new GVNode(-1);
			GraphVizTraversal traversal = new GraphVizTraversal(root);
			s.apply(traversal);

			// root.print();
			// root.printRelations();

			System.out.println("graph\n{");
			root.printGraphViz();
			System.out.println("}");

			// System.out.println("success");

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
