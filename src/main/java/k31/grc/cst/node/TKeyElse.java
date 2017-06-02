/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class TKeyElse extends Token
{
    public TKeyElse()
    {
        super.setText("else");
    }

    public TKeyElse(int line, int pos)
    {
        super.setText("else");
        setLine(line);
        setPos(pos);
    }

    @Override
    public Object clone()
    {
      return new TKeyElse(getLine(), getPos());
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTKeyElse(this);
    }

    @Override
    public void setText(@SuppressWarnings("unused") String text)
    {
        throw new RuntimeException("Cannot change TKeyElse text.");
    }
}
