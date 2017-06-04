/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import java.util.*;
import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class ABlockStmt extends PBlockStmt
{
    private TSepLbrace _sepLbrace_;
    private final LinkedList<PStatement> _statement_ = new LinkedList<PStatement>();
    private TSepRbrace _sepRbrace_;

    public ABlockStmt()
    {
        // Constructor
    }

    public ABlockStmt(
        @SuppressWarnings("hiding") TSepLbrace _sepLbrace_,
        @SuppressWarnings("hiding") List<?> _statement_,
        @SuppressWarnings("hiding") TSepRbrace _sepRbrace_)
    {
        // Constructor
        setSepLbrace(_sepLbrace_);

        setStatement(_statement_);

        setSepRbrace(_sepRbrace_);

    }

    @Override
    public Object clone()
    {
        return new ABlockStmt(
            cloneNode(this._sepLbrace_),
            cloneList(this._statement_),
            cloneNode(this._sepRbrace_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseABlockStmt(this);
    }

    public TSepLbrace getSepLbrace()
    {
        return this._sepLbrace_;
    }

    public void setSepLbrace(TSepLbrace node)
    {
        if(this._sepLbrace_ != null)
        {
            this._sepLbrace_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._sepLbrace_ = node;
    }

    public LinkedList<PStatement> getStatement()
    {
        return this._statement_;
    }

    public void setStatement(List<?> list)
    {
        for(PStatement e : this._statement_)
        {
            e.parent(null);
        }
        this._statement_.clear();

        for(Object obj_e : list)
        {
            PStatement e = (PStatement) obj_e;
            if(e.parent() != null)
            {
                e.parent().removeChild(e);
            }

            e.parent(this);
            this._statement_.add(e);
        }
    }

    public TSepRbrace getSepRbrace()
    {
        return this._sepRbrace_;
    }

    public void setSepRbrace(TSepRbrace node)
    {
        if(this._sepRbrace_ != null)
        {
            this._sepRbrace_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._sepRbrace_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._sepLbrace_)
            + toString(this._statement_)
            + toString(this._sepRbrace_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._sepLbrace_ == child)
        {
            this._sepLbrace_ = null;
            return;
        }

        if(this._statement_.remove(child))
        {
            return;
        }

        if(this._sepRbrace_ == child)
        {
            this._sepRbrace_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._sepLbrace_ == oldChild)
        {
            setSepLbrace((TSepLbrace) newChild);
            return;
        }

        for(ListIterator<PStatement> i = this._statement_.listIterator(); i.hasNext();)
        {
            if(i.next() == oldChild)
            {
                if(newChild != null)
                {
                    i.set((PStatement) newChild);
                    newChild.parent(this);
                    oldChild.parent(null);
                    return;
                }

                i.remove();
                oldChild.parent(null);
                return;
            }
        }

        if(this._sepRbrace_ == oldChild)
        {
            setSepRbrace((TSepRbrace) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}