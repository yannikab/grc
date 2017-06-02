/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AVarLocalDef extends PLocalDef
{
    private PVarDef _varDef_;

    public AVarLocalDef()
    {
        // Constructor
    }

    public AVarLocalDef(
        @SuppressWarnings("hiding") PVarDef _varDef_)
    {
        // Constructor
        setVarDef(_varDef_);

    }

    @Override
    public Object clone()
    {
        return new AVarLocalDef(
            cloneNode(this._varDef_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAVarLocalDef(this);
    }

    public PVarDef getVarDef()
    {
        return this._varDef_;
    }

    public void setVarDef(PVarDef node)
    {
        if(this._varDef_ != null)
        {
            this._varDef_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._varDef_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._varDef_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._varDef_ == child)
        {
            this._varDef_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._varDef_ == oldChild)
        {
            setVarDef((PVarDef) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
