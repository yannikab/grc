/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.node;

import k31.grc.analysis.*;

@SuppressWarnings("nls")
public final class TOperLe extends Token
{
    public TOperLe()
    {
        super.setText("<=");
    }

    public TOperLe(int line, int pos)
    {
        super.setText("<=");
        setLine(line);
        setPos(pos);
    }

    @Override
    public Object clone()
    {
      return new TOperLe(getLine(), getPos());
    }

    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTOperLe(this);
    }

    @Override
    public void setText(@SuppressWarnings("unused") String text)
    {
        throw new RuntimeException("Cannot change TOperLe text.");
    }
}