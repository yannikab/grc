/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class TKeyFun extends Token
{
    public TKeyFun()
    {
        super.setText("fun");
    }

    public TKeyFun(int line, int pos)
    {
        super.setText("fun");
        setLine(line);
        setPos(pos);
    }

    @Override
    public Object clone()
    {
      return new TKeyFun(getLine(), getPos());
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTKeyFun(this);
    }

    @Override
    public void setText(@SuppressWarnings("unused") String text)
    {
        throw new RuntimeException("Cannot change TKeyFun text.");
    }
}
