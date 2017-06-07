using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable.Symbol;
using Grc.Sem.Types;
using Grc.Sem.Visitor;

namespace Grc.Tac.Visitor
{
	public class GTypeVisitorScope : GTypeVisitor
	{
		protected override void InjectLibraryFunctions()
		{
			SymbolTable.Insert(new SymbolFunc("_puti", true) { Type = new GTypeFunction(new GTypeInt(), GTypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_putc", true) { Type = new GTypeFunction(new GTypeChar(), GTypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_puts", true) { Type = new GTypeFunction(new GTypeIndexed(0, new GTypeChar()) { InHeader = true }, GTypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("_geti", true) { Type = new GTypeFunction(GTypeNothing.Instance, new GTypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_getc", true) { Type = new GTypeFunction(GTypeNothing.Instance, new GTypeChar()) });
			SymbolTable.Insert(new SymbolFunc("_gets", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeInt(), new GTypeIndexed(0, new GTypeChar()) { InHeader = true }), GTypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("_abs", true) { Type = new GTypeFunction(new GTypeInt(), new GTypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_ord", true) { Type = new GTypeFunction(new GTypeChar(), new GTypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_chr", true) { Type = new GTypeFunction(new GTypeInt(), new GTypeChar()) });

			SymbolTable.Insert(new SymbolFunc("_strlen", true) { Type = new GTypeFunction(new GTypeIndexed(0, new GTypeChar()) { InHeader = true }, new GTypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_strcmp", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar()) { InHeader = true }, new GTypeIndexed(0, new GTypeChar()) { InHeader = true }), new GTypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_strcpy", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar()) { InHeader = true }, new GTypeIndexed(0, new GTypeChar()) { InHeader = true }), GTypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_strcat", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar()) { InHeader = true }, new GTypeIndexed(0, new GTypeChar()) { InHeader = true }), GTypeNothing.Instance) });
		}
	}
}
