/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class ALValueFactor extends PFactor
{
    private PLValue _lValue_;

    public ALValueFactor()
    {
        // Constructor
    }

    public ALValueFactor(
        @SuppressWarnings("hiding") PLValue _lValue_)
    {
        // Constructor
        setLValue(_lValue_);

    }

    @Override
    public Object clone()
    {
        return new ALValueFactor(
            cloneNode(this._lValue_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseALValueFactor(this);
    }

    public PLValue getLValue()
    {
        return this._lValue_;
    }

    public void setLValue(PLValue node)
    {
        if(this._lValue_ != null)
        {
            this._lValue_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._lValue_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._lValue_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._lValue_ == child)
        {
            this._lValue_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._lValue_ == oldChild)
        {
            setLValue((PLValue) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
