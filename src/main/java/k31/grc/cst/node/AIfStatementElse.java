/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AIfStatementElse extends PStatementElse
{
    private PIfStmtElse _ifStmtElse_;

    public AIfStatementElse()
    {
        // Constructor
    }

    public AIfStatementElse(
        @SuppressWarnings("hiding") PIfStmtElse _ifStmtElse_)
    {
        // Constructor
        setIfStmtElse(_ifStmtElse_);

    }

    @Override
    public Object clone()
    {
        return new AIfStatementElse(
            cloneNode(this._ifStmtElse_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAIfStatementElse(this);
    }

    public PIfStmtElse getIfStmtElse()
    {
        return this._ifStmtElse_;
    }

    public void setIfStmtElse(PIfStmtElse node)
    {
        if(this._ifStmtElse_ != null)
        {
            this._ifStmtElse_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._ifStmtElse_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._ifStmtElse_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._ifStmtElse_ == child)
        {
            this._ifStmtElse_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._ifStmtElse_ == oldChild)
        {
            setIfStmtElse((PIfStmtElse) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
