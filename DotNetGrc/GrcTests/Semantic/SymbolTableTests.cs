using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;
using NUnit.Framework;

namespace GrcTests.Semantic
{
	[TestFixture]
	public class SymbolTableTests
	{
		[Test]
		public void TestExitWithoutEnter()
		{
			ISymbolTable ist = new StackSymbolTable();
			Assert.Throws<NoCurrentScopeException>(() => ist.Exit());
		}

		[Test]
		public void TestInsertWithoutEnter()
		{
			ISymbolTable ist = new StackSymbolTable();
			Assert.Throws<NoCurrentScopeException>
				(() => ist.Insert(new SymbolVar("test")));
		}

		[Test]

		public void TestLookupWithoutEnter()
		{
			ISymbolTable ist = new StackSymbolTable();
			Assert.Throws<NoCurrentScopeException>
				(() => ist.Lookup<SymbolVar>("test"));
		}

		[Test]
		public void TestEnterLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();

			Assert.Throws<SymbolNotInOpenScopesException>
				(() => ist.Lookup<SymbolVar>("test"));
		}

		[Test]
		public void EnterInsert()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
		}

		[Test]
		public void EnterInsertLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
		}

		[Test]
		public void EnterInsertExitLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
			ist.Exit();
			Assert.Throws<NoCurrentScopeException>
				(() => ist.Lookup<SymbolVar>("test"));
		}

		[Test]
		public void EnterInsertExitInsert()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
			ist.Exit();
			Assert.Throws<NoCurrentScopeException>
				(() => ist.Insert(new SymbolVar("test2")));
		}

		[Test]
		public void EnterInsertManyExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test1"));
			ist.Insert(new SymbolVar("test2"));
			ist.Insert(new SymbolVar("test3"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test2"), new SymbolVar("test2"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test3"), new SymbolVar(("test3")));
			ist.Exit();
		}

		[Test]
		public void EnterInsertEnterLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
			ist.Enter();
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
		}

		[Test]
		public void EnterInsertEnterInsertSameExitExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
			ist.Exit();
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test"));
			ist.Exit();
		}

		[Test]
		public void EnterInsertEnterInsertDiffExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test1"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1"));
			ist.Enter();
			ist.Insert(new SymbolVar("test2"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1"));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test2"), new SymbolVar("test2"));
			ist.Exit();
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1"));
			Assert.Throws<SymbolNotInOpenScopesException>
				(() => ist.Lookup<SymbolVar>("test2"));
		}

		[Test]
		public void TestCount()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(0, ist.SymbolsInScope);
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(1, ist.SymbolsInScope);
			ist.Insert(new SymbolVar("test2"));
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(2, ist.SymbolsInScope);
			ist.Exit();
			ist.Enter();
			ist.Insert(new SymbolVar("test"));
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(1, ist.SymbolsInScope);
			ist.Exit();
		}
	}
}
