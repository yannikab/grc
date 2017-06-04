/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AAndOpTermL extends PTermL
{
    private PTermL _termL_;
    private TOperAnd _operAnd_;
    private PFactorL _factorL_;

    public AAndOpTermL()
    {
        // Constructor
    }

    public AAndOpTermL(
        @SuppressWarnings("hiding") PTermL _termL_,
        @SuppressWarnings("hiding") TOperAnd _operAnd_,
        @SuppressWarnings("hiding") PFactorL _factorL_)
    {
        // Constructor
        setTermL(_termL_);

        setOperAnd(_operAnd_);

        setFactorL(_factorL_);

    }

    @Override
    public Object clone()
    {
        return new AAndOpTermL(
            cloneNode(this._termL_),
            cloneNode(this._operAnd_),
            cloneNode(this._factorL_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAAndOpTermL(this);
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

    public TOperAnd getOperAnd()
    {
        return this._operAnd_;
    }

    public void setOperAnd(TOperAnd node)
    {
        if(this._operAnd_ != null)
        {
            this._operAnd_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._operAnd_ = node;
    }

    public PFactorL getFactorL()
    {
        return this._factorL_;
    }

    public void setFactorL(PFactorL node)
    {
        if(this._factorL_ != null)
        {
            this._factorL_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._factorL_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._termL_)
            + toString(this._operAnd_)
            + toString(this._factorL_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._termL_ == child)
        {
            this._termL_ = null;
            return;
        }

        if(this._operAnd_ == child)
        {
            this._operAnd_ = null;
            return;
        }

        if(this._factorL_ == child)
        {
            this._factorL_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._termL_ == oldChild)
        {
            setTermL((PTermL) newChild);
            return;
        }

        if(this._operAnd_ == oldChild)
        {
            setOperAnd((TOperAnd) newChild);
            return;
        }

        if(this._factorL_ == oldChild)
        {
            setFactorL((PFactorL) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}