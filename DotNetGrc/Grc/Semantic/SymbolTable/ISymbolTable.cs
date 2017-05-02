using Grc.Semantic.SymbolTable.Symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable
{
	public interface ISymbolTable
	{
		void Enter();
		void Insert(SymbolBase s);
		SymbolBase Lookup(SymbolBase s);
		void Exit();

		int Scopes { get; }
		int SymbolsInScope { get; }
	}
}
