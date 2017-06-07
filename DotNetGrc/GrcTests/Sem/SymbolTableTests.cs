using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable;
using Grc.Sem.SymbolTable.Exceptions;
using Grc.Sem.SymbolTable.Symbol;
using NUnit.Framework;

namespace GrcTests.Sem
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
			Assert.Throws<NoCurrentScopeException>(() => ist.Insert(new SymbolVar("test", false)));
		}

		[Test]

		public void TestLookupWithoutEnter()
		{
			ISymbolTable ist = new StackSymbolTable();
			Assert.Throws<NoCurrentScopeException>(() => ist.Lookup<SymbolVar>("test"));
		}

		[Test]
		public void TestEnterLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();

			Assert.IsNull(ist.Lookup<SymbolVar>("test"));
		}

		[Test]
		public void EnterInsert()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
		}

		[Test]
		public void EnterInsertLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
		}

		[Test]
		public void EnterInsertExitLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
			ist.Exit();
			Assert.Throws<NoCurrentScopeException>(() => ist.Lookup<SymbolVar>("test"));
		}

		[Test]
		public void EnterInsertExitInsert()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
			ist.Exit();
			Assert.Throws<NoCurrentScopeException>(() => ist.Insert(new SymbolVar("test2", false)));
		}

		[Test]
		public void EnterInsertManyExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test1", false));
			ist.Insert(new SymbolVar("test2", false));
			ist.Insert(new SymbolVar("test3", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test2"), new SymbolVar("test2", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test3"), new SymbolVar("test3", false));
			ist.Exit();
		}

		[Test]
		public void EnterInsertEnterLookup()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
			ist.Enter();
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
		}

		[Test]
		public void EnterInsertEnterInsertSameExitExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
			ist.Exit();
			Assert.AreEqual(ist.Lookup<SymbolVar>("test"), new SymbolVar("test", false));
			ist.Exit();
		}

		[Test]
		public void EnterInsertEnterInsertDiffExit()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			ist.Insert(new SymbolVar("test1", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1", false));
			ist.Enter();
			ist.Insert(new SymbolVar("test2", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1", false));
			Assert.AreEqual(ist.Lookup<SymbolVar>("test2"), new SymbolVar("test2", false));
			ist.Exit();
			Assert.AreEqual(ist.Lookup<SymbolVar>("test1"), new SymbolVar("test1", false));
			Assert.IsNull(ist.Lookup<SymbolVar>("test2"));
		}

		[Test]
		public void TestCount()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(0, ist.SymbolsInScope);
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(1, ist.SymbolsInScope);
			ist.Insert(new SymbolVar("test2", false));
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(2, ist.SymbolsInScope);
			ist.Exit();
			ist.Enter();
			ist.Insert(new SymbolVar("test", false));
			Assert.AreEqual(0, ist.CurrentScopeId);
			Assert.AreEqual(1, ist.SymbolsInScope);
			ist.Exit();
		}

		[Test]
		public void TestOuter()
		{
			ISymbolTable ist = new StackSymbolTable();
			ist.Enter();

			Assert.IsNull(ist.LookupLast<SymbolFunc>(0));
			Assert.IsNull(ist.LookupLast<SymbolVar>(0));

			ist.Insert(new SymbolFunc("fun", true));

			Assert.AreEqual(ist.LookupLast<SymbolFunc>(0).Name, "fun");
			Assert.IsNull(ist.LookupLast<SymbolVar>(0));

			ist.Enter();

			Assert.IsNull(ist.LookupLast<SymbolFunc>(0));
			Assert.IsNull(ist.LookupLast<SymbolVar>(0));

			Assert.AreEqual(ist.LookupLast<SymbolFunc>(1).Name, "fun");
			Assert.IsNull(ist.LookupLast<SymbolVar>(1));

			ist.Insert(new SymbolVar("par1", false));
			ist.Insert(new SymbolVar("par2", false));

			Assert.IsNull(ist.LookupLast<SymbolFunc>(0));
			Assert.AreEqual(ist.LookupLast<SymbolVar>(0).Name, "par2");

			Assert.AreEqual(ist.LookupLast<SymbolFunc>(1).Name, "fun");
			Assert.IsNull(ist.LookupLast<SymbolVar>(1));

			ist.Insert(new SymbolFunc("fun2", true));

			Assert.AreEqual(ist.LookupLast<SymbolFunc>(0).Name, "fun2");
			Assert.AreEqual(ist.LookupLast<SymbolVar>(0).Name, "par2");

			ist.Enter();

			Assert.IsNull(ist.LookupLast<SymbolFunc>(0));
			Assert.IsNull(ist.LookupLast<SymbolVar>(0));

			Assert.AreEqual(ist.LookupLast<SymbolFunc>(1).Name, "fun2");
			Assert.AreEqual(ist.LookupLast<SymbolVar>(1).Name, "par2");

			Assert.AreEqual(ist.LookupLast<SymbolFunc>(2).Name, "fun");
			Assert.IsNull(ist.LookupLast<SymbolVar>(2));
		}
	}
}
