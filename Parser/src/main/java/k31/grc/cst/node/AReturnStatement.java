/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AReturnStatement extends PStatement
{
    private PReturnStmt _returnStmt_;

    public AReturnStatement()
    {
        // Constructor
    }

    public AReturnStatement(
        @SuppressWarnings("hiding") PReturnStmt _returnStmt_)
    {
        // Constructor
        setReturnStmt(_returnStmt_);

    }

    @Override
    public Object clone()
    {
        return new AReturnStatement(
            cloneNode(this._returnStmt_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAReturnStatement(this);
    }

    public PReturnStmt getReturnStmt()
    {
        return this._returnStmt_;
    }

    public void setReturnStmt(PReturnStmt node)
    {
        if(this._returnStmt_ != null)
        {
            this._returnStmt_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._returnStmt_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._returnStmt_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._returnStmt_ == child)
        {
            this._returnStmt_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._returnStmt_ == oldChild)
        {
            setReturnStmt((PReturnStmt) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}