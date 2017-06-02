/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.cst.node;

import k31.grc.cst.analysis.*;

@SuppressWarnings("nls")
public final class ACharacterFactor extends PFactor
{
    private TCharacter _character_;

    public ACharacterFactor()
    {
        // Constructor
    }

    public ACharacterFactor(
        @SuppressWarnings("hiding") TCharacter _character_)
    {
        // Constructor
        setCharacter(_character_);

    }

    @Override
    public Object clone()
    {
        return new ACharacterFactor(
            cloneNode(this._character_));
    }

    @Override
    public void apply(Switch sw)
    {
        ((Analysis) sw).caseACharacterFactor(this);
    }

    public TCharacter getCharacter()
    {
        return this._character_;
    }

    public void setCharacter(TCharacter node)
    {
        if(this._character_ != null)
        {
            this._character_.parent(null);
        }

        if(node != null)
        {
            if(node.parent() != null)
            {
                node.parent().removeChild(node);
            }

            node.parent(this);
        }

        this._character_ = node;
    }

    @Override
    public String toString()
    {
        return ""
            + toString(this._character_);
    }

    @Override
    void removeChild(@SuppressWarnings("unused") Node child)
    {
        // Remove child
        if(this._character_ == child)
        {
            this._character_ = null;
            return;
        }

        throw new RuntimeException("Not a child.");
    }

    @Override
    void replaceChild(@SuppressWarnings("unused") Node oldChild, @SuppressWarnings("unused") Node newChild)
    {
        // Replace child
        if(this._character_ == oldChild)
        {
            setCharacter((TCharacter) newChild);
            return;
        }

        throw new RuntimeException("Not a child.");
    }
}
