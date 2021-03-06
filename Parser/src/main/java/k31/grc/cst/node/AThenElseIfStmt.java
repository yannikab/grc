/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class AThenElseIfStmt extends PIfStmt
{
    private TKeyIf _keyIf_;
    private PExpressionL _expressionL_;
    private TKeyThen _keyThen_;
    private PStatementElse _statementElse_;
    private TKeyElse _keyElse_;
    private PStatement _statement_;

    public AThenElseIfStmt()
    {
        // Constructor
    }

    public AThenElseIfStmt(
        @SuppressWarnings("hiding") TKeyIf _keyIf_,
        @SuppressWarnings("hiding") PExpressionL _expressionL_,
        @SuppressWarnings("hiding") TKeyThen _keyThen_,
        @SuppressWarnings("hiding") PStatementElse _statementElse_,
        @SuppressWarnings("hiding") TKeyElse _keyElse_,
        @SuppressWarnings("hiding") PStatement _statement_)
    {
        // Constructor
        setKeyIf(_keyIf_);

        setExpressionL(_expressionL_);

        setKeyThen(_keyThen_);

        setStatementElse(_statementElse_);

        setKeyElse(_keyElse_);

        setStatement(_statement_);

    }

    @Override
    public Object clone()
    {
        return new AThenElseIfStmt(
            cloneNode(this._keyIf_),
            cloneNode(this._expressionL_),
            cloneNode(this._keyThen_),
            cloneNode(this._statementElse_),
            cloneNode(this._keyElse_),
            cloneNode(this._statement_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseAThenElseIfStmt(this);
    }

    public TKeyIf getKeyIf()
    {
        return this._keyIf_;
    }

    public void setKeyIf(TKeyIf node)
    {
        if(this._keyIf_ != null)
        {
            this._keyIf_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._keyIf_ = node;
    }

    public PExpressionL getExpressionL()
    {
        return this._expressionL_;
    }

    public void setExpressionL(PExpressionL node)
    {
        if(this._expressionL_ != null)
        {
            this._expressionL_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._expressionL_ = node;
    }

    public TKeyThen getKeyThen()
    {
        return this._keyThen_;
    }

    public void setKeyThen(TKeyThen node)
    {
        if(this._keyThen_ != null)
        {
            this._keyThen_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._keyThen_ = node;
    }

    public PStatementElse getStatementElse()
    {
        return this._statementElse_;
    }

    public void setStatementElse(PStatementElse node)
    {
        if(this._statementElse_ != null)
        {
            this._statementElse_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._statementElse_ = node;
    }

    public TKeyElse getKeyElse()
    {
        return this._keyElse_;
    }

    public void setKeyElse(TKeyElse node)
    {
        if(this._keyElse_ != null)
        {
            this._keyElse_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._keyElse_ = node;
    }

    public PStatement getStatement()
    {
        return this._statement_;
    }

    public void setStatement(PStatement node)
    {
        if(this._statement_ != null)
        {
            this._statement_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._statement_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._keyIf_)
            + toString(this._expressionL_)
            + toString(this._keyThen_)
            + toString(this._statementElse_)
            + toString(this._keyElse_)
            + toString(this._statement_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._keyIf_ == child)
        {
            this._keyIf_ = null;
            return;
        }

        if(this._expressionL_ == child)
        {
            this._expressionL_ = null;
            return;
        }

        if(this._keyThen_ == child)
        {
            this._keyThen_ = null;
            return;
        }

        if(this._statementElse_ == child)
        {
            this._statementElse_ = null;
            return;
        }

        if(this._keyElse_ == child)
        {
            this._keyElse_ = null;
            return;
        }

        if(this._statement_ == child)
        {
            this._statement_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._keyIf_ == oldChild)
        {
            setKeyIf((TKeyIf) newChild);
            return;
        }

        if(this._expressionL_ == oldChild)
        {
            setExpressionL((PExpressionL) newChild);
            return;
        }

        if(this._keyThen_ == oldChild)
        {
            setKeyThen((TKeyThen) newChild);
            return;
        }

        if(this._statementElse_ == oldChild)
        {
            setStatementElse((PStatementElse) newChild);
            return;
        }

        if(this._keyElse_ == oldChild)
        {
            setKeyElse((TKeyElse) newChild);
            return;
        }

        if(this._statement_ == oldChild)
        {
            setStatement((PStatement) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
