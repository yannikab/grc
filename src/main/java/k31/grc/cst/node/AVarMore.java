/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AVarMore extends PVarMore
{
    private TSepComma _sepComma_;
    private TIdentifier _identifier_;

    public AVarMore()
    {
        // Constructor
    }

    public AVarMore(
        @SuppressWarnings("hiding") TSepComma _sepComma_,
        @SuppressWarnings("hiding") TIdentifier _identifier_)
    {
        // Constructor
        setSepComma(_sepComma_);

        setIdentifier(_identifier_);

    }

    @Override
    public Object clone()
    {
        return new AVarMore(
            cloneNode(this._sepComma_),
            cloneNode(this._identifier_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAVarMore(this);
    }

    public TSepComma getSepComma()
    {
        return this._sepComma_;
    }

    public void setSepComma(TSepComma node)
    {
        if(this._sepComma_ != null)
        {
            this._sepComma_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._sepComma_ = node;
    }

    public TIdentifier getIdentifier()
    {
        return this._identifier_;
    }

    public void setIdentifier(TIdentifier node)
    {
        if(this._identifier_ != null)
        {
            this._identifier_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._identifier_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._sepComma_)
            + toString(this._identifier_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._sepComma_ == child)
        {
            this._sepComma_ = null;
            return;
        }

        if(this._identifier_ == child)
        {
            this._identifier_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._sepComma_ == oldChild)
        {
            setSepComma((TSepComma) newChild);
            return;
        }

        if(this._identifier_ == oldChild)
        {
            setIdentifier((TIdentifier) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
