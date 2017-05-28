using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		[Test]
		public void TestPassingParArrayCharElementByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}

	fun bar(ref c : char[]) : nothing
	{
		foo(c[0]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingParArrayArrayCharElementByReference()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char) : nothing
	{
	}

	fun bar(ref c : char[][5]) : nothing
	{
		foo(c[0][2]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingParArrayByReferencePar()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char[]) : nothing
	{
	}

	fun bar(ref c : char[]) : nothing
	{
		foo(c);
	}
{
}		

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingParArrayElementByReferencePar()
		{
			string program = @"

fun program() : nothing

	fun foo(ref a : char[]) : nothing
	{
	}

	fun bar(ref c : char[][10]) : nothing
	{
		foo(c[0]);
	}
{
}		

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}
	}
}
