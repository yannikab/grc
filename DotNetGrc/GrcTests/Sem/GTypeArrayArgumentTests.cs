using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Visitor.Exceptions.GType;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class GTypeArrayArgumentTests : GTypeVisitorTests
	{
		[Test]
		public void TestPar()
		{
			string program = @"

fun program() : nothing	

	fun boo(ref a : char[]) : nothing
	{
	}

	fun far(ref p : char[]) : nothing
	{
		boo(p);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParWithSize()
		{
			string program = @"

fun program() : nothing	

	fun boo(ref a : char[5]) : nothing
	{
	}

	fun far(ref p : char[5]) : nothing
	{
		boo(p);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParWrongSize()
		{
			string program = @"

fun program() : nothing	

	fun boo(ref a : char[5]) : nothing
	{
	}

	fun far(ref p : char[10]) : nothing
	{
		boo(p);
	}
{
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestParElement()
		{
			string program = @"

fun program() : nothing

	fun boo(a : char) : nothing
	{
	}

	fun far(ref a : char) : nothing
	{
	}

	fun nap(ref p : char[]) : nothing
	{
		boo(p[0]);

		far(p[0]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestParArrayElement()
		{
			string program = @"

fun program() : nothing

	fun boo(a : char) : nothing
	{
	}

	fun far(ref a : char) : nothing
	{
	}

	fun nap(ref p : char[][5]) : nothing
	{
		boo(p[2][3]);

		far(p[3][4]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestParElementArray()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char[]) : nothing
	{
	}

	fun far(ref p : char[][10]) : nothing
	{
		boo(p[3]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParElementArrayWithSize()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char[10]) : nothing
	{
	}

	fun far(ref p : char[][10]) : nothing
	{
		boo(p[3]);
	}
{
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestParElementArrayWrongSize()
		{
			string program = @"

fun program() : nothing

	fun boo(ref a : char[5]) : nothing
	{
	}

	fun far(ref p : char[][10]) : nothing
	{
		boo(p[2]);
	}
{
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestVar()
		{
			string program = @"

fun program() : nothing

	var v : char[5];

	fun boo(ref a : char[]) : nothing
	{
	}
{
	boo(v);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestVarWithSize()
		{
			string program = @"

fun program() : nothing

	var v : char[5];

	fun boo(ref a : char[5]) : nothing
	{
	}
{
	boo(v);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestVarWrongSize()
		{
			string program = @"

fun program() : nothing	

	var v : char[10];

	fun boo(ref a : char[5]) : nothing
	{
	}

	fun far() : nothing
	{
		boo(v);
	}
{
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}


		[Test]
		public void TestVarElement()
		{
			string program = @"

fun program() : nothing

	var v : char[10];

	fun boo(ref a : char) : nothing
	{
	}

	fun far(a : char) : nothing
	{
	}
{
	boo(v[3]);

	far(v[5]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestVarArrayElement()
		{
			string program = @"

fun program() : nothing

	var v : char[10][5];

	fun boo(ref a : char) : nothing
	{
	}

	fun far(a : char) : nothing
	{
	}
{
	boo(v[1][2]);

	far(v[3][4]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 5, MaxSymbols);
		}


		[Test]
		public void TestVarElementArray()
		{
			string program = @"

fun program() : nothing

	var v : char[10][5];

	fun boo(ref a : char[]) : nothing
	{
	}
{
	boo(v[8]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestVarElementArrayWithSize()
		{
			string program = @"

fun program() : nothing

	var v : char[10][5];

	fun boo(ref a : char[5]) : nothing
	{
	}
{
	boo(v[4]);
}

";
			AcceptGTypeVisitor(program);
			Assert.AreEqual(LibrarySymbols + 4, MaxSymbols);
		}


		[Test]
		public void TestVarElementArrayWrongSize()
		{
			string program = @"

fun program() : nothing

	var v : char[2][10];

	fun boo(ref a : char[5]) : nothing
	{
	}

	fun far() : nothing
	{
		boo(v[1]);
	}
{
}

";
			Assert.Throws<FunctionCallArgsMismatchException>(() => AcceptGTypeVisitor(program));
		}
	}
}
