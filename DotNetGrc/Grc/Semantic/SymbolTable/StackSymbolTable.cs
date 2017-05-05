using Grc.Semantic.SymbolTable.Exception;
using Grc.Semantic.SymbolTable.Symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable
{
	public class StackSymbolTable : ISymbolTable
	{
		private List<int> scope;
		private List<SymbolBase> symbol;
		private Dictionary<string, SymbolBase> symbolForName;

		public StackSymbolTable()
		{
			this.scope = new List<int>();
			this.symbol = new List<SymbolBase>();
			this.symbolForName = new Dictionary<string, SymbolBase>();
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
					throw new SymbolAlreadyInScopeException(String.Format("SymbolBase already defined in current scope: {0}", symbol[i]));

			symbol.Add((SymbolBase)s.Clone());
			symbol[symbol.Count - 1].Scope = scope.Count - 1;

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
		}

		public SymbolBase Lookup(SymbolBase s)
		{
			if (scope.Count == 0)
				throw new NoCurrentScopeException();

			if (!symbolForName.ContainsKey(s.Name))
				throw new SymbolNotDefinedException();

			for (SymbolBase t = symbolForName[s.Name]; t != null; t = t.Next)
				if (object.Equals(t, s))
					return (SymbolBase)t.Clone();

			throw new SymbolNotDefinedException();
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
					group s by s.Scope into g
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


		public int Scopes
		{
			get { return scope.Count; }
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
	}
}
