using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Semantic;
using Grc.Semantic.SymbolTable.Exception;

namespace GrcTests.Semantic
{
	[TestClass]
	public class SymbolTypeTests
	{
		[TestMethod]
		public void EnterInsertLookupSameType()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
		}

		[TestMethod]
		[ExpectedException(typeof(SymbolNotDefinedException))]
		public void EnterInsertLookupDiffType()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			ist.Lookup(new SymbolFunc("test"));
		}

		[TestMethod]
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
