using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		[Test]
		public void TestPassingParArrayElement()
		{
			string program = @"

fun program() : nothing

	fun boo(a : char) : nothing
	{
	}

	fun far(ref a : char) : nothing
	{
	}

	fun nap(ref c : char[]) : nothing
	{
		boo(c[0]);

		far(c[0]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestPassingParArrayElementArray()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char[]) : nothing
	{
	}

	fun far(ref c : char[][10]) : nothing
	{
		boo(c[0]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingParArrayArrayElement()
		{
			string program = @"

fun program() : nothing

	fun boo(a : char) : nothing
	{
	}

	fun far(ref a : char) : nothing
	{
	}

	fun nap(ref c : char[][5]) : nothing
	{
		boo(c[1][2]);

		far(c[1][2]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestPassingParArray()
		{
			string program = @"

fun program() : nothing	

	fun boo(ref a : char[]) : nothing
	{
	}

	fun far(ref c : char[]) : nothing
	{
		boo(c);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingParByRefToByVal()
		{
			string program = @"

fun program() : nothing

	fun boo(i : int) : nothing
	{
	}

	fun far(ref a : int) : nothing
	{
		boo(a);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestPassingParByValToByRef()
		{
			string program = @"

fun program() : nothing

	fun boo(ref i : int) : nothing
	{
	}

	fun far(a : int) : nothing
	{
		boo(a);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}
	}
}
