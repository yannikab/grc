using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class TypeTests
	{
		[Test]
		public void TestTypeIndexedEqual()
		{
			TypeIndexed ti1 = new TypeIndexed(0, new TypeInt());
			TypeIndexed ti2 = new TypeIndexed(5, new TypeInt());

			Assert.AreEqual(ti1, ti2);
		}


		[Test]
		public void TestTypeIndexedNotEqual()
		{
			TypeIndexed ti1 = new TypeIndexed(4, new TypeInt());
			TypeIndexed ti2 = new TypeIndexed(4, new TypeChar());

			Assert.AreNotEqual(ti1, ti2);
		}


		[Test]
		public void TestTypeIndexedDoubleEqual()
		{
			TypeIndexed ti1 = new TypeIndexed(5, new TypeIndexed(4, new TypeInt()));
			TypeIndexed ti2 = new TypeIndexed(5, new TypeIndexed(4, new TypeInt()));

			Assert.AreEqual(ti1, ti2);
		}


		[Test]
		public void TestTypeIndexedDoubleNotEqual()
		{
			TypeIndexed ti1 = new TypeIndexed(5, new TypeIndexed(4, new TypeInt()));
			TypeIndexed ti2 = new TypeIndexed(5, new TypeIndexed(4, new TypeChar()));

			Assert.AreNotEqual(ti1, ti2);
		}


		[Test]
		public void TestTypeProductEqual()
		{
			TypeProduct tp1 = new TypeProduct(new TypeInt(), new TypeChar());
			TypeProduct tp2 = new TypeProduct(new TypeInt(), new TypeChar());

			Assert.AreEqual(tp1, tp2);
		}


		[Test]
		public void TestTypeProductNotEqual()
		{
			TypeProduct tp1 = new TypeProduct(new TypeInt(), new TypeChar());
			TypeProduct tp2 = new TypeProduct(new TypeInt(), new TypeInt());

			Assert.AreNotEqual(tp1, tp2);
		}


		[Test]
		public void TestTypeFunctionEqual()
		{
			TypeProduct from1 = new TypeProduct(new TypeInt(), new TypeChar());

			TypeProduct from2 = new TypeProduct(new TypeInt(), new TypeChar());

			TypeInt to1 = new TypeInt();
			TypeInt to2 = new TypeInt();

			TypeFunction tf1 = new TypeFunction(from1, to1);
			TypeFunction tf2 = new TypeFunction(from2, to2);

			Assert.AreEqual(tf1, tf2);
		}


		[Test]
		public void TestTypeFunctionNotEqualFrom()
		{
			TypeProduct from1 = new TypeProduct(new TypeInt(), new TypeChar());

			TypeProduct from2 = new TypeProduct(new TypeInt(), new TypeInt());

			TypeInt to1 = new TypeInt();
			TypeInt to2 = new TypeInt();

			TypeFunction tf1 = new TypeFunction(from1, to1);
			TypeFunction tf2 = new TypeFunction(from2, to2);

			Assert.AreNotEqual(tf1, tf2);
		}


		[Test]
		public void TestTypeFunctionNotEqualTo()
		{
			TypeProduct from1 = new TypeProduct(new TypeInt(), new TypeChar());

			TypeProduct from2 = new TypeProduct(new TypeInt(), new TypeInt());

			TypeInt to1 = new TypeInt();
			TypeChar to2 = new TypeChar();

			TypeFunction tf1 = new TypeFunction(from1, to1);
			TypeFunction tf2 = new TypeFunction(from2, to2);

			Assert.AreNotEqual(tf1, tf2);
		}
	}
}
