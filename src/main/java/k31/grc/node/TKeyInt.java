/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.node;

import k31.grc.analysis.*;

@SuppressWarnings("nls")
public final class TKeyInt extends Token
{
    public TKeyInt()
    {
        super.setText("int");
    }

    public TKeyInt(int line, int pos)
    {
        super.setText("int");
        setLine(line);
        setPos(pos);
    }

    @Override
    public Object clone()
    {
      return new TKeyInt(getLine(), getPos());
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTKeyInt(this);
    }

    @Override
    public void setText(@SuppressWarnings("unused") String text)
    {
        throw new RuntimeException("Cannot change TKeyInt text.");
    }
}
