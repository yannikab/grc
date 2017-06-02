/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class ADataReturnType extends PReturnType
{
    private PDataType _dataType_;

    public ADataReturnType()
    {
        // Constructor
    }

    public ADataReturnType(
        @SuppressWarnings("hiding") PDataType _dataType_)
    {
        // Constructor
        setDataType(_dataType_);

    }

    @Override
    public Object clone()
    {
        return new ADataReturnType(
            cloneNode(this._dataType_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseADataReturnType(this);
    }

    public PDataType getDataType()
    {
        return this._dataType_;
    }

    public void setDataType(PDataType node)
    {
        if(this._dataType_ != null)
        {
            this._dataType_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._dataType_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._dataType_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._dataType_ == child)
        {
            this._dataType_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._dataType_ == oldChild)
        {
            setDataType((PDataType) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
