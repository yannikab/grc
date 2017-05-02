using System;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Semantic;
using Grc.Semantic.SymbolTable.Exception;
using NUnit.Framework;

namespace GrcTests.Semantic
{
	[TestFixture]
	public class SymbolTypeTests
	{
		[Test]
		public void EnterInsertLookupSameType()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
		}

		[Test]
		public void EnterInsertLookupDiffType()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));

			Assert.Throws<SymbolNotDefinedException>(() => ist.Lookup(new SymbolFunc("test")));
		}

		[Test]
		public void EnterInsertDiffLookupBoth()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			ist.Insert(new SymbolFunc("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolFunc("test")), new SymbolFunc("test"));
		}
	}
}
