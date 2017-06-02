/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AFuncDeclLocalDef extends PLocalDef
{
    private PFuncDecl _funcDecl_;

    public AFuncDeclLocalDef()
    {
        // Constructor
    }

    public AFuncDeclLocalDef(
        @SuppressWarnings("hiding") PFuncDecl _funcDecl_)
    {
        // Constructor
        setFuncDecl(_funcDecl_);

    }

    @Override
    public Object clone()
    {
        return new AFuncDeclLocalDef(
            cloneNode(this._funcDecl_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAFuncDeclLocalDef(this);
    }

    public PFuncDecl getFuncDecl()
    {
        return this._funcDecl_;
    }

    public void setFuncDecl(PFuncDecl node)
    {
        if(this._funcDecl_ != null)
        {
            this._funcDecl_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._funcDecl_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._funcDecl_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._funcDecl_ == child)
        {
            this._funcDecl_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._funcDecl_ == oldChild)
        {
            setFuncDecl((PFuncDecl) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
