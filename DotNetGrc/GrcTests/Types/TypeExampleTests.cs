using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class TypeExampleTests : TypeVisitorTests
	{
		[Test]
		public void TestHello()
		{
			string program = @"

fun hello () : nothing
{
  puts(""Hello world!\n"");
}

";
			AcceptTypeVisitor(program);
		}


		[Test]
		public void TestReverse()
		{
			string program = @"

fun main () : nothing
  var r : char[32];

  fun reverse (ref s : char[]) : nothing
    var i, l : int;
  {
    l <- strlen(s);
    i <- 0;
    while i < l do {
      r[i] <- s[l-i-1];
      i <- i+1;
    }
    r[i] <- '\0';
  }

{
  reverse(""\n!dlrow olleH"");
  puts(r);
}

";
			AcceptTypeVisitor(program);
		}


		[Test]
		public void TestHanoi()
		{
			string program = @"

fun solve () : nothing
      fun hanoi (rings : int; ref source, target, auxiliary : char[]) : nothing
         fun move (ref source, target : char[]) : nothing
         {
            puts(""Moving from "");
            puts(source);
            puts("" to "");
            puts(target);
            puts("".\n"");
         }
      {
         if rings >= 1 then {
            hanoi(rings-1, source, auxiliary, target);
            move(source, target);
            hanoi(rings-1, auxiliary, target, source);
         }
      }

      var NumberOfRings : int;
{
  puts(""Rings: "");
  NumberOfRings <- geti();
  hanoi(NumberOfRings, ""left"", ""right"", ""middle"");
}

";
			AcceptTypeVisitor(program);
		}


		[Test]
		public void TestPrimes()
		{
			string program = @"

fun main () : nothing
    fun prime (n : int) : int
      var i : int;
    {
      if n<0              then return prime(-1);
      else if n<2         then return 0;
      else if n=2         then return 1;
      else if n mod 2 = 0 then return 0;
      else {
        i <- 3;
        while i <= n div 2 do {
          if n mod i = 0 then
            return 0;
          i <- i + 2;
        }
        return 1;
      }
    }

    var limit, number, counter : int;

{
   puts(""Limit: "");
   limit <- geti();
   puts(""Primes:\n"");
   counter <- 0;
   if limit >= 2 then {
      counter <- counter + 1;
      puti(2);
      puts(""\n"");
   }
   if limit >= 3 then {
      counter <- counter + 1;
      puti(3);
      puts(""\n"");
   }
   number <- 6;
   while number <= limit do {
      if prime(number - 1) = 1 then {
         counter <- counter + 1;
         puti(number - 1);
         puts(""\n"");
      }
      if number # limit and prime(number + 1) = 1 then {
         counter <- counter + 1;
         puti(number + 1);
         puts(""\n"");
      }
      number <- number + 6;
   }
   puts(""\nTotal: "");
   puti(counter);
   puts(""\n"");
}

";
			AcceptTypeVisitor(program);
		}


		[Test]
		public void TestBSort()
		{
			string program = @"

fun main () : nothing

   fun bsort (n : int; ref x : int[]) : nothing

      fun swap (ref x, y : int) : nothing
         var t : int;
      {
         t <- x;
         x <- y;
         y <- t;
      }

      var changed, i : int;
   {
      changed <- 1;
      while changed > 0 do {
        changed <- 0;
        i <- 0;
        while i < n-1 do {
          if x[i] > x[i+1] then {
            swap(x[i],x[i+1]);
            changed <- 1;
          }
          i <- i+1;
        }
      }
   }

   fun putArray (ref msg : char[]; n : int; ref x : int[]) : nothing
      var i : int;
   {
      puts(msg);
      i <- 0;
      while i < n do {
        if i > 0 then puts("", "");
        puti(x[i]);
        i <- i+1;
      }
      puts(""\n"");
   }

   var seed, i : int;
   var x : int[16];
{
  seed <- 65;
  i <- 0;
  while i < 16 do {
    seed <- (seed * 137 + 220 + i) mod 101;
    x[i] <- seed;
    i <- i+1;
  }
  putArray(""Initial array: "", 16, x);
  bsort(16,x);
  putArray(""Sorted array: "", 16, x);
}
";
			AcceptTypeVisitor(program);
		}
	}
}
