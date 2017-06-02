/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class APlusFactor extends PFactor
{
    private TOperPlus _operPlus_;
    private PFactor _factor_;

    public APlusFactor()
    {
        // Constructor
    }

    public APlusFactor(
        @SuppressWarnings("hiding") TOperPlus _operPlus_,
        @SuppressWarnings("hiding") PFactor _factor_)
    {
        // Constructor
        setOperPlus(_operPlus_);

        setFactor(_factor_);

    }

    @Override
    public Object clone()
    {
        return new APlusFactor(
            cloneNode(this._operPlus_),
            cloneNode(this._factor_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAPlusFactor(this);
    }

    public TOperPlus getOperPlus()
    {
        return this._operPlus_;
    }

    public void setOperPlus(TOperPlus node)
    {
        if(this._operPlus_ != null)
        {
            this._operPlus_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._operPlus_ = node;
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
            + toString(this._operPlus_)
            + toString(this._factor_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._operPlus_ == child)
        {
            this._operPlus_ = null;
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
        if(this._operPlus_ == oldChild)
        {
            setOperPlus((TOperPlus) newChild);
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
