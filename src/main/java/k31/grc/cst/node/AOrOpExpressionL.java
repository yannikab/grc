/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AOrOpExpressionL extends PExpressionL
{
    private PExpressionL _expressionL_;
    private TOperOr _operOr_;
    private PTermL _termL_;

    public AOrOpExpressionL()
    {
        // Constructor
    }

    public AOrOpExpressionL(
        @SuppressWarnings("hiding") PExpressionL _expressionL_,
        @SuppressWarnings("hiding") TOperOr _operOr_,
        @SuppressWarnings("hiding") PTermL _termL_)
    {
        // Constructor
        setExpressionL(_expressionL_);

        setOperOr(_operOr_);

        setTermL(_termL_);

    }

    @Override
    public Object clone()
    {
        return new AOrOpExpressionL(
            cloneNode(this._expressionL_),
            cloneNode(this._operOr_),
            cloneNode(this._termL_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAOrOpExpressionL(this);
    }

    public PExpressionL getExpressionL()
    {
        return this._expressionL_;
    }

    public void setExpressionL(PExpressionL node)
    {
        if(this._expressionL_ != null)
        {
            this._expressionL_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._expressionL_ = node;
    }

    public TOperOr getOperOr()
    {
        return this._operOr_;
    }

    public void setOperOr(TOperOr node)
    {
        if(this._operOr_ != null)
        {
            this._operOr_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._operOr_ = node;
    }

    public PTermL getTermL()
    {
        return this._termL_;
    }

    public void setTermL(PTermL node)
    {
        if(this._termL_ != null)
        {
            this._termL_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._termL_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._expressionL_)
            + toString(this._operOr_)
            + toString(this._termL_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._expressionL_ == child)
        {
            this._expressionL_ = null;
            return;
        }

        if(this._operOr_ == child)
        {
            this._operOr_ = null;
            return;
        }

        if(this._termL_ == child)
        {
            this._termL_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._expressionL_ == oldChild)
        {
            setExpressionL((PExpressionL) newChild);
            return;
        }

        if(this._operOr_ == oldChild)
        {
            setOperOr((TOperOr) newChild);
            return;
        }

        if(this._termL_ == oldChild)
        {
            setTermL((PTermL) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
