/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import java.util.*;
import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AFuncParams extends PFuncParams
{
    private PFparDef _fparDef_;
    private final LinkedList<PFparDefMore> _fparDefMore_ = new LinkedList<PFparDefMore>();

    public AFuncParams()
    {
        // Constructor
    }

    public AFuncParams(
        @SuppressWarnings("hiding") PFparDef _fparDef_,
        @SuppressWarnings("hiding") List<?> _fparDefMore_)
    {
        // Constructor
        setFparDef(_fparDef_);

        setFparDefMore(_fparDefMore_);

    }

    @Override
    public Object clone()
    {
        return new AFuncParams(
            cloneNode(this._fparDef_),
            cloneList(this._fparDefMore_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAFuncParams(this);
    }

    public PFparDef getFparDef()
    {
        return this._fparDef_;
    }

    public void setFparDef(PFparDef node)
    {
        if(this._fparDef_ != null)
        {
            this._fparDef_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._fparDef_ = node;
    }

    public LinkedList<PFparDefMore> getFparDefMore()
    {
        return this._fparDefMore_;
    }

    public void setFparDefMore(List<?> list)
    {
        for(PFparDefMore e : this._fparDefMore_)
        {
            e.parent(null);
        }
        this._fparDefMore_.clear();

        for(Object obj_e : list)
        {
            PFparDefMore e = (PFparDefMore) obj_e;
            if(e.parent() != null)
            {
                e.parent().removeChild(e);
            }

            e.parent(this);
            this._fparDefMore_.add(e);
        }
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._fparDef_)
            + toString(this._fparDefMore_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._fparDef_ == child)
        {
            this._fparDef_ = null;
            return;
        }

        if(this._fparDefMore_.remove(child))
        {
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._fparDef_ == oldChild)
        {
            setFparDef((PFparDef) newChild);
            return;
        }

        for(ListIterator<PFparDefMore> i = this._fparDefMore_.listIterator(); i.hasNext();)
        {
            if(i.next() == oldChild)
            {
                if(newChild != null)
                {
                    i.set((PFparDefMore) newChild);
                    newChild.parent(this);
                    oldChild.parent(null);
                    return;
                }

                i.remove();
                oldChild.parent(null);
                return;
            }
        }

        throw new RuntimeException("Not a child.");
    }
}
