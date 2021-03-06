/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import java.util.*;
import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AFparDef extends PFparDef
{
    private TKeyRef _keyRef_;
    private TIdentifier _identifier_;
    private final LinkedList<PParMore> _parMore_ = new LinkedList<PParMore>();
    private TSepColon _sepColon_;
    private PFparType _fparType_;

    public AFparDef()
    {
        // Constructor
    }

    public AFparDef(
        @SuppressWarnings("hiding") TKeyRef _keyRef_,
        @SuppressWarnings("hiding") TIdentifier _identifier_,
        @SuppressWarnings("hiding") List<?> _parMore_,
        @SuppressWarnings("hiding") TSepColon _sepColon_,
        @SuppressWarnings("hiding") PFparType _fparType_)
    {
        // Constructor
        setKeyRef(_keyRef_);

        setIdentifier(_identifier_);

        setParMore(_parMore_);

        setSepColon(_sepColon_);

        setFparType(_fparType_);

    }

    @Override
    public Object clone()
    {
        return new AFparDef(
            cloneNode(this._keyRef_),
            cloneNode(this._identifier_),
            cloneList(this._parMore_),
            cloneNode(this._sepColon_),
            cloneNode(this._fparType_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAFparDef(this);
    }

    public TKeyRef getKeyRef()
    {
        return this._keyRef_;
    }

    public void setKeyRef(TKeyRef node)
    {
        if(this._keyRef_ != null)
        {
            this._keyRef_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._keyRef_ = node;
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

    public LinkedList<PParMore> getParMore()
    {
        return this._parMore_;
    }

    public void setParMore(List<?> list)
    {
        for(PParMore e : this._parMore_)
        {
            e.parent(null);
        }
        this._parMore_.clear();

        for(Object obj_e : list)
        {
            PParMore e = (PParMore) obj_e;
            if(e.parent() != null)
            {
                e.parent().removeChild(e);
            }

            e.parent(this);
            this._parMore_.add(e);
        }
    }

    public TSepColon getSepColon()
    {
        return this._sepColon_;
    }

    public void setSepColon(TSepColon node)
    {
        if(this._sepColon_ != null)
        {
            this._sepColon_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._sepColon_ = node;
    }

    public PFparType getFparType()
    {
        return this._fparType_;
    }

    public void setFparType(PFparType node)
    {
        if(this._fparType_ != null)
        {
            this._fparType_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._fparType_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._keyRef_)
            + toString(this._identifier_)
            + toString(this._parMore_)
            + toString(this._sepColon_)
            + toString(this._fparType_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._keyRef_ == child)
        {
            this._keyRef_ = null;
            return;
        }

        if(this._identifier_ == child)
        {
            this._identifier_ = null;
            return;
        }

        if(this._parMore_.remove(child))
        {
            return;
        }

        if(this._sepColon_ == child)
        {
            this._sepColon_ = null;
            return;
        }

        if(this._fparType_ == child)
        {
            this._fparType_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._keyRef_ == oldChild)
        {
            setKeyRef((TKeyRef) newChild);
            return;
        }

        if(this._identifier_ == oldChild)
        {
            setIdentifier((TIdentifier) newChild);
            return;
        }

        for(ListIterator<PParMore> i = this._parMore_.listIterator(); i.hasNext();)
        {
            if(i.next() == oldChild)
            {
                if(newChild != null)
                {
                    i.set((PParMore) newChild);
                    newChild.parent(this);
                    oldChild.parent(null);
                    return;
                }

                i.remove();
                oldChild.parent(null);
                return;
            }
        }

        if(this._sepColon_ == oldChild)
        {
            setSepColon((TSepColon) newChild);
            return;
        }

        if(this._fparType_ == oldChild)
        {
            setFparType((PFparType) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
