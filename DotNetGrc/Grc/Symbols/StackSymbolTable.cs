using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Symbols;

namespace Grc.Symbols
{
	public class StackSymbolTable : ISymbolTable
	{
		private List<int> scope;
		private List<SymbolBase> symbol;
		private Dictionary<string, SymbolBase> symbolForName;
		private int maxSymbols;

		public StackSymbolTable()
		{
			this.scope = new List<int>();
			this.symbol = new List<SymbolBase>();
			this.symbolForName = new Dictionary<string, SymbolBase>();
			this.maxSymbols = 0;
		}

		public void Enter()
		{
			if (scope.Count == 0)
			{
				scope.Add(0);
				return;
			}

			scope.Add(scope[scope.Count - 1]);
		}

		public void Insert(SymbolBase s)
		{
			if (scope.Count == 0)
				throw new NoCurrentScopeException();

			int last = scope[scope.Count - 1] - 1;
			int first = scope.Count > 1 ? scope[scope.Count - 2] : 0;

			for (int i = last; i >= first; i--)
				if (symbol[i].GetHashCode() == s.GetHashCode() && symbol[i].Equals(s))
					throw new SymbolAlreadyInScopeException(scope.Count - 1, s);

			symbol.Add(s);
			symbol[symbol.Count - 1].ScopeId = scope.Count - 1;

			scope[scope.Count - 1]++;

			if (!symbolForName.ContainsKey(s.Name))
			{
				symbolForName.Add(s.Name, symbol[symbol.Count - 1]);
			}
			else
			{
				symbol[symbol.Count - 1].Next = symbolForName[s.Name];
				symbolForName[s.Name] = symbol[symbol.Count - 1];
			}

			if (symbol.Count > maxSymbols)
				maxSymbols = symbol.Count;
		}

		public T Lookup<T>(string name) where T : SymbolBase
		{
			if (scope.Count == 0)
				throw new NoCurrentScopeException();

			if (!symbolForName.ContainsKey(name))
				return null;

			for (SymbolBase t = symbolForName[name]; t != null; t = t.Next)
				if (t is T)
					return (T)t;

			return null;
		}

		public T LookupLast<T>(int level) where T : SymbolBase
		{
			if (scope.Count == 0)
				throw new NoCurrentScopeException();

			if (level < 0 || !(scope.Count - level > 0))
				throw new NoOuterScopeException(level);

			int outerScope = scope.Count - level - 1;

			int firstSymbol = outerScope > 0 ? scope[outerScope - 1] : 0;
			int lastSymbol = scope[outerScope] - 1;

			for (int i = lastSymbol; i >= firstSymbol; i--)
				if (symbol[i] is T)
					return (T)symbol[i];

			return null;
		}

		public IEnumerable<T> LookupAll<T>(int level) where T : SymbolBase
		{
			if (scope.Count == 0)
				throw new NoCurrentScopeException();

			if (level < 0 || !(scope.Count - level > 0))
				throw new NoOuterScopeException(level);

			int outerScope = scope.Count - level - 1;

			int firstSymbol = outerScope > 0 ? scope[outerScope - 1] : 0;
			int lastSymbol = scope[outerScope] - 1;

			for (int i = firstSymbol; i <= lastSymbol; i++)
				if (symbol[i] is T)
					yield return (T)symbol[i];
		}

		public void Exit()
		{
			if (scope.Count == 0)
				throw new NoCurrentScopeException();

			int last = scope[scope.Count - 1] - 1;
			int first = scope.Count > 1 ? scope[scope.Count - 2] : 0;

			for (int i = last; i >= first; i--)
			{
				if (symbol[i].Next != null)
					symbolForName[symbol[i].Name] = symbol[i].Next;
				else
					symbolForName.Remove(symbol[i].Name);

				symbol.RemoveAt(symbol.Count - 1);
			}

			scope.RemoveAt(scope.Count - 1);
		}

		public override string ToString()
		{
			var q = from s in symbol
					group s by s.ScopeId into g
					select g;

			StringBuilder sb = new StringBuilder();

			foreach (var scp in q)
			{
				sb.Append("Scope: " + scp.Key + Environment.NewLine);

				foreach (var sym in scp)
					sb.Append(sym.Name + ", ");

				sb.Append(Environment.NewLine);
			}

			return sb.ToString();
		}


		public int CurrentScopeId
		{
			get
			{
				if (scope.Count == 0)
					throw new NoCurrentScopeException();

				return scope.Count - 1;
			}
		}

		public int SymbolsInScope
		{
			get
			{
				if (scope.Count == 0)
					throw new NoCurrentScopeException();

				return scope.Count > 1 ? scope[scope.Count - 1] - scope[scope.Count - 2] : scope[scope.Count - 1];
			}
		}

		public int MaxSymbols { get { return maxSymbols; } }
	}
}
