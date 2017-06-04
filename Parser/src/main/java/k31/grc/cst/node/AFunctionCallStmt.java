/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AFunctionCallStmt extends PFunctionCallStmt
{
    private PFunctionCall _functionCall_;
    private TSepSemi _sepSemi_;

    public AFunctionCallStmt()
    {
        // Constructor
    }

    public AFunctionCallStmt(
        @SuppressWarnings("hiding") PFunctionCall _functionCall_,
        @SuppressWarnings("hiding") TSepSemi _sepSemi_)
    {
        // Constructor
        setFunctionCall(_functionCall_);

        setSepSemi(_sepSemi_);

    }

    @Override
    public Object clone()
    {
        return new AFunctionCallStmt(
            cloneNode(this._functionCall_),
            cloneNode(this._sepSemi_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAFunctionCallStmt(this);
    }

    public PFunctionCall getFunctionCall()
    {
        return this._functionCall_;
    }

    public void setFunctionCall(PFunctionCall node)
    {
        if(this._functionCall_ != null)
        {
            this._functionCall_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._functionCall_ = node;
    }

    public TSepSemi getSepSemi()
    {
        return this._sepSemi_;
    }

    public void setSepSemi(TSepSemi node)
    {
        if(this._sepSemi_ != null)
        {
            this._sepSemi_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._sepSemi_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._functionCall_)
            + toString(this._sepSemi_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._functionCall_ == child)
        {
            this._functionCall_ = null;
            return;
        }

        if(this._sepSemi_ == child)
        {
            this._sepSemi_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._functionCall_ == oldChild)
        {
            setFunctionCall((PFunctionCall) newChild);
            return;
        }

        if(this._sepSemi_ == oldChild)
        {
            setSepSemi((TSepSemi) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}