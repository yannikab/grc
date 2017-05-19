﻿using System;
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
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
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}
	}
}
