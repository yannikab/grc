/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class ALessEqualFactorL extends PFactorL
{
    private PExpression _l_;
    private TOperLe _operLe_;
    private PExpression _r_;

    public ALessEqualFactorL()
    {
        // Constructor
    }

    public ALessEqualFactorL(
        @SuppressWarnings("hiding") PExpression _l_,
        @SuppressWarnings("hiding") TOperLe _operLe_,
        @SuppressWarnings("hiding") PExpression _r_)
    {
        // Constructor
        setL(_l_);

        setOperLe(_operLe_);

        setR(_r_);

    }

    @Override
    public Object clone()
    {
        return new ALessEqualFactorL(
            cloneNode(this._l_),
            cloneNode(this._operLe_),
            cloneNode(this._r_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseALessEqualFactorL(this);
    }

    public PExpression getL()
    {
        return this._l_;
    }

    public void setL(PExpression node)
    {
        if(this._l_ != null)
        {
            this._l_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._l_ = node;
    }

    public TOperLe getOperLe()
    {
        return this._operLe_;
    }

    public void setOperLe(TOperLe node)
    {
        if(this._operLe_ != null)
        {
            this._operLe_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._operLe_ = node;
    }

    public PExpression getR()
    {
        return this._r_;
    }

    public void setR(PExpression node)
    {
        if(this._r_ != null)
        {
            this._r_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._r_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._l_)
            + toString(this._operLe_)
            + toString(this._r_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._l_ == child)
        {
            this._l_ = null;
            return;
        }

        if(this._operLe_ == child)
        {
            this._operLe_ = null;
            return;
        }

        if(this._r_ == child)
        {
            this._r_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._l_ == oldChild)
        {
            setL((PExpression) newChild);
            return;
        }

        if(this._operLe_ == oldChild)
        {
            setOperLe((TOperLe) newChild);
            return;
        }

        if(this._r_ == oldChild)
        {
            setR((PExpression) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
