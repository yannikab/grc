package k31.grc;

import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PushbackReader;

import k31.grc.lexer.Lexer;
import k31.grc.lexer.LexerException;
import k31.grc.node.EOF;
import k31.grc.node.Token;

/**
 * Hello world!
 *
 */
public class App {

	public static void main(String[] args) {

		// System.out.println("Hello World!");

		System.out.print("hello\n");

		Lexer lexer = new Lexer(new PushbackReader(new InputStreamReader(System.in), 4096));

		Token token;

		try {

			for (token = lexer.next(); !(token instanceof EOF); token = lexer.next()) {

				System.out.print("\"" + token.getText() + "\": " + token.getClass().toString() + System.lineSeparator());
			}

		} catch (LexerException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();

		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
