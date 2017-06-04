using Grc.Sem.SymbolTable.Symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.SymbolTable
{
	public interface ISymbolTable
	{
		void Enter();

		void Insert(SymbolBase s);

		T Lookup<T>(string name) where T : SymbolBase;
		T LookupLast<T>(int level) where T : SymbolBase;
		IEnumerable<T> LookupAll<T>(int level) where T : SymbolBase;

		void Exit();

		int CurrentScopeId { get; }
		int SymbolsInScope { get; }
		int MaxSymbols { get; }
	}
}
