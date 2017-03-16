/* This file was generated by SableCC (http://www.sablecc.org/). */

package k31.grc.analysis;

import k31.grc.node.*;

public interface Analysis extends Switch
{
    Object getIn(Node node);
    void setIn(Node node, Object o);
    Object getOut(Node node);
    void setOut(Node node, Object o);

    void caseTCommentSwitch(TCommentSwitch node);
    void caseTCommentContent(TCommentContent node);
    void caseTKeyAnd(TKeyAnd node);
    void caseTKeyChar(TKeyChar node);
    void caseTKeyDiv(TKeyDiv node);
    void caseTKeyDo(TKeyDo node);
    void caseTKeyElse(TKeyElse node);
    void caseTKeyFun(TKeyFun node);
    void caseTKeyIf(TKeyIf node);
    void caseTKeyInt(TKeyInt node);
    void caseTKeyMod(TKeyMod node);
    void caseTKeyNot(TKeyNot node);
    void caseTKeyNothing(TKeyNothing node);
    void caseTKeyOr(TKeyOr node);
    void caseTKeyRef(TKeyRef node);
    void caseTKeyReturn(TKeyReturn node);
    void caseTKeyThen(TKeyThen node);
    void caseTKeyVar(TKeyVar node);
    void caseTKeyWhile(TKeyWhile node);
    void caseTIdentifier(TIdentifier node);
    void caseTConstInt(TConstInt node);
    void caseTConstChar(TConstChar node);
    void caseTConstString(TConstString node);
    void caseTWhiteSpan(TWhiteSpan node);
    void caseTCommentLine(TCommentLine node);
    void caseTCommentSpan(TCommentSpan node);
    void caseTOperPlus(TOperPlus node);
    void caseTOperMinus(TOperMinus node);
    void caseTOperMult(TOperMult node);
    void caseTOperDiv(TOperDiv node);
    void caseTOperHash(TOperHash node);
    void caseTOperEq(TOperEq node);
    void caseTOperNe(TOperNe node);
    void caseTOperLt(TOperLt node);
    void caseTOperGt(TOperGt node);
    void caseTOperLe(TOperLe node);
    void caseTOperGe(TOperGe node);
    void caseTSepLpar(TSepLpar node);
    void caseTSepRpar(TSepRpar node);
    void caseTSepLbrack(TSepLbrack node);
    void caseTSepRbrack(TSepRbrack node);
    void caseTSepLbrace(TSepLbrace node);
    void caseTSepRbrace(TSepRbrace node);
    void caseEOF(EOF node);
}
