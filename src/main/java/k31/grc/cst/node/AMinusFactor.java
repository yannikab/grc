/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AMinusFactor extends PFactor
{
    private TOperMinus _operMinus_;
    private PFactor _factor_;

    public AMinusFactor()
    {
        // Constructor
    }

    public AMinusFactor(
        @SuppressWarnings("hiding") TOperMinus _operMinus_,
        @SuppressWarnings("hiding") PFactor _factor_)
    {
        // Constructor
        setOperMinus(_operMinus_);

        setFactor(_factor_);

    }

    @Override
    public Object clone()
    {
        return new AMinusFactor(
            cloneNode(this._operMinus_),
            cloneNode(this._factor_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAMinusFactor(this);
    }

    public TOperMinus getOperMinus()
    {
        return this._operMinus_;
    }

    public void setOperMinus(TOperMinus node)
    {
        if(this._operMinus_ != null)
        {
            this._operMinus_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._operMinus_ = node;
    }

    public PFactor getFactor()
    {
        return this._factor_;
    }

    public void setFactor(PFactor node)
    {
        if(this._factor_ != null)
        {
            this._factor_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._factor_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._operMinus_)
            + toString(this._factor_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._operMinus_ == child)
        {
            this._operMinus_ = null;
            return;
        }

        if(this._factor_ == child)
        {
            this._factor_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._operMinus_ == oldChild)
        {
            setOperMinus((TOperMinus) newChild);
            return;
        }

        if(this._factor_ == oldChild)
        {
            setFactor((PFactor) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
