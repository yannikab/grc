/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.node;

import k31.grc.analysis.*;

@SuppressWarnings("nls")
public final class TConstChar extends Token
{
    public TConstChar(String text)
    {
        setText(text);
    }

    public TConstChar(String text, int line, int pos)
    {
        setText(text);
        setLine(line);
        setPos(pos);
    }

    @Override
    public Object clone()
    {
      return new TConstChar(getText(), getLine(), getPos());
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTConstChar(this);
    }
}