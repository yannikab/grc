/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.node;

import k31.grc.analysis.*;

@SuppressWarnings("nls")
public final class TConstInt extends Token
{
    public TConstInt(String text)
    {
        setText(text);
    }

    public TConstInt(String text, int line, int pos)
    {
        setText(text);
        setLine(line);
        setPos(pos);
    }

    @Override
    public Object clone()
    {
      return new TConstInt(getText(), getLine(), getPos());
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTConstInt(this);
    }
}