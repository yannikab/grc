/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class TKeyRef extends Token
{
    public TKeyRef()
    {
        super.setText("ref");
    }

    public TKeyRef(int line, int pos)
    {
        super.setText("ref");
        setLine(line);
        setPos(pos);
    }

    @Override
    public Object clone()
    {
      return new TKeyRef(getLine(), getPos());
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseTKeyRef(this);
    }

    @Override
    public void setText(@SuppressWarnings("unused") String text)
    {
        throw new RuntimeException("Cannot change TKeyRef text.");
    }
}
