/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.parser;

import k31.grc.cst.node.*;

@SuppressWarnings("serial")
public class ParserException extends Exception
{
    Token token;

    public ParserException(@SuppressWarnings("hiding") Token token, String  message)
    {
        super(message);
        this.token = token;
    }

    public Token getToken()
    {
        return this.token;
    }
}
