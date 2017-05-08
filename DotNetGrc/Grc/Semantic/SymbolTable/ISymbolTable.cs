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
		T Lookup<T>(string name) where T : SymbolBase;
		void Exit();

		int CurrentScopeId { get; }
		int SymbolsInScope { get; }
	}
}
