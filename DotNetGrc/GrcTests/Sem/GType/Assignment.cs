﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable;
using Grc.Sem.Visitor.Exceptions.GType;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public partial class GTypeVisitorTests
	{
		[Test]
		public void TestAssignLValueNotIndexed1()
		{
			string program = @"

fun program() : nothing

	var a : int;
{
	a[5] <- 4;
}

";
			ISymbolTable symbolTable;
			Assert.Throws<LValueNotIndexedTypeException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestAssignLValueNotIndexed2()
		{
			string program = @"

fun program() : nothing

	var a : int [5];
{
	a[0][3] <- 4;
}

";
			ISymbolTable symbolTable;
			Assert.Throws<LValueNotIndexedTypeException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestAssignInvalidType1()
		{
			string program = @"

fun program() : nothing

	var a : int [5];
{
	a[3] <- 'c';
}

";
			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestAssignInvalidType2()
		{
			string program = @"

fun program() : nothing

	var a : char;
{
	a <- 5;
}

";
			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestAssignNothing()
		{
			string program = @"

fun program() : nothing

	var a : int;

	fun foo() : nothing
	{
	}
{
	a <- foo();
}

";
			ISymbolTable symbolTable;
			Assert.Throws<InvalidTypeInAssignmentException>(() => AcceptGTypeVisitor(program, out symbolTable));
		}


		[Test]
		public void TestAssignCorrectType()
		{
			string program = @"

fun program() : nothing

	var a : int;
	var b : char;
	var c : int[3];
{
	a <- 5;
	b <- 'd';
	c[5] <- 5;
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 4, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestAssignFunctionCallNoArgs()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo() : int
	{
		return 0;
	}
{
	a <- foo();
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestAssignFunctionCallArgs()
		{
			string program = @"

fun program() : nothing

	var a : int;
	
	fun foo(c : char; i : int; ref a : char[5]) : int
	{
		return 0;
	}
{
	a <- foo('f', 34, ""hello"");
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 6, symbolTable.MaxSymbols);
		}


		[Test]
		public void TestAssignIndexedChar()
		{
			string program = @"

fun program() : nothing

	var a : char[5];
	var b : char;
	
{
	b <- a[8];	
}

";
			ISymbolTable symbolTable;
			AcceptGTypeVisitor(program, out symbolTable);
			Assert.AreEqual(LibrarySymbols + 3, symbolTable.MaxSymbols);
		}
	}
}