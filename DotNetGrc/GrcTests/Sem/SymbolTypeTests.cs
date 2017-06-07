using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable;
using Grc.Sem.SymbolTable.Symbol;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class SymbolTypeTests
	{
		[Test]
		public void EnterInsertLookupSameType()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
		}

		[Test]
		public void EnterInsertLookupDiffType()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));

			Assert.IsNull(ist.Lookup<SymbolFunc>("test"));
		}

		[Test]
		public void EnterInsertDiffLookupBoth()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			ist.Insert(new SymbolFunc("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolFunc>("test"), new SymbolFunc("test", false));
		}
	}
}
