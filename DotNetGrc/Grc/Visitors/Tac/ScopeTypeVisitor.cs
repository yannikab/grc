using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Sem;
using Grc.Symbols;
using Grc.Types;

namespace Grc.Visitors.Tac
{
	public class ScopeTypeVisitor : TypeVisitor
	{
		protected override void InjectLibraryFunctions()
		{
			SymbolTable.Insert(new SymbolFunc("_puti", true) { Type = new TypeFunction(new TypeInt(), TypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_putc", true) { Type = new TypeFunction(new TypeChar(), TypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_puts", true) { Type = new TypeFunction(new TypeIndexed(0, new TypeChar()) { InHeader = true }, TypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("_geti", true) { Type = new TypeFunction(TypeNothing.Instance, new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_getc", true) { Type = new TypeFunction(TypeNothing.Instance, new TypeChar()) });
			SymbolTable.Insert(new SymbolFunc("_gets", true) { Type = new TypeFunction(new TypeProduct(new TypeInt(), new TypeIndexed(0, new TypeChar()) { InHeader = true }), TypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("_abs", true) { Type = new TypeFunction(new TypeInt(), new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_ord", true) { Type = new TypeFunction(new TypeChar(), new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_chr", true) { Type = new TypeFunction(new TypeInt(), new TypeChar()) });

			SymbolTable.Insert(new SymbolFunc("_strlen", true) { Type = new TypeFunction(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_strcmp", true) { Type = new TypeFunction(new TypeProduct(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeIndexed(0, new TypeChar()) { InHeader = true }), new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("_strcpy", true) { Type = new TypeFunction(new TypeProduct(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeIndexed(0, new TypeChar()) { InHeader = true }), TypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_strcat", true) { Type = new TypeFunction(new TypeProduct(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeIndexed(0, new TypeChar()) { InHeader = true }), TypeNothing.Instance) });
		}
	}
}
