using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grc.Semantic;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Semantic.SymbolTable.Exception;

namespace GrcTests.Semantic
{
	[TestClass]
	public class SymbolTableTests
	{
		[ClassInitialize]
		public static void Initialize(TestContext tc)
		{
		}

		[ClassCleanup]
		public static void Cleanup()
		{
		}

		[TestMethod]
		[ExpectedException(typeof(NoCurrentScopeException))]
		public void TestExitWithoutEnter()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Exit();
		}

		[TestMethod]
		[ExpectedException(typeof(NoCurrentScopeException))]
		public void TestInsertWithoutEnter()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Insert(new SymbolVar("test"));
		}

		[TestMethod]
		[ExpectedException(typeof(NoCurrentScopeException))]
		public void TestLookupWithoutEnter()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Lookup(new SymbolVar("test"));
		}

		[TestMethod]
		[ExpectedException(typeof(SymbolNotDefinedException))]
		public void TestEnterLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			Assert.IsNull(ist.Lookup(new SymbolVar("test")));
		}

		[TestMethod]
		public void EnterInsert()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
		}

		[TestMethod]
		public void EnterInsertLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
		}

		[TestMethod]
		[ExpectedException(typeof(NoCurrentScopeException))]
		public void EnterInsertExitLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
			ist.Exit();
			ist.Lookup(new SymbolVar("test"));
		}

		[TestMethod]
		[ExpectedException(typeof(NoCurrentScopeException))]
		public void EnterInsertExitInsert()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
			ist.Exit();
			ist.Insert(new SymbolVar("test2"));
		}

		[TestMethod]
		public void EnterInsertManyExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test1"));
			ist.Insert(new SymbolVar("test2"));
			ist.Insert(new SymbolVar("test3"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test1")), new SymbolVar("test1"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test2")), new SymbolVar("test2"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test3")), new SymbolVar(("test3")));
			String s = ist.ToString();
			ist.Exit();
		}

		[TestMethod]
		public void EnterInsertEnterLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
			ist.Enter();
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
		}

		[TestMethod]
		public void EnterInsertEnterInsertSameExitExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
			String s = ist.ToString();
			ist.Exit();
			Assert.AreEqual(ist.Lookup(new SymbolVar("test")), new SymbolVar("test"));
			ist.Exit();
		}

		[TestMethod]
		[ExpectedException(typeof(SymbolNotDefinedException))]
		public void EnterInsertEnterInsertDiffExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test1"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test1")), new SymbolVar("test1"));
			ist.Enter();
			ist.Insert(new SymbolVar("test2"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test1")), new SymbolVar("test1"));
			Assert.AreEqual(ist.Lookup(new SymbolVar("test2")), new SymbolVar("test2"));
			String s = ist.ToString();
			ist.Exit();
			Assert.AreEqual(ist.Lookup(new SymbolVar("test1")), new SymbolVar("test1"));
			ist.Lookup(new SymbolVar("test2"));
		}

		[TestMethod]
		public void TestCount()
		{
			ISymbolTable ist = new StackSymbolTable();
			Assert.AreEqual(0, ist.Scopes);
			ist.Enter();
			Assert.AreEqual(1, ist.Scopes);
			Assert.AreEqual(0, ist.SymbolsInScope);
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(1, ist.Scopes);
			Assert.AreEqual(1, ist.SymbolsInScope);
			ist.Insert(new SymbolVar("test2"));
			Assert.AreEqual(1, ist.Scopes);
			Assert.AreEqual(2, ist.SymbolsInScope);
			ist.Exit();
			Assert.AreEqual(0, ist.Scopes);
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(1, ist.Scopes);
			Assert.AreEqual(1, ist.SymbolsInScope);
			ist.Exit();
			Assert.AreEqual(0, ist.Scopes);
		}
	}
}
