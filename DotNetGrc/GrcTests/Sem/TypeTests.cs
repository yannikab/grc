using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;
using NUnit.Framework;

namespace GrcTests.Sem
{
	[TestFixture]
	public class TypeTests
	{
		[Test]
		public void TestGTypeIndexedEqual()
		{
			GTypeIndexed ti1 = new GTypeIndexed(0, new GTypeInt());
			GTypeIndexed ti2 = new GTypeIndexed(5, new GTypeInt());

			Assert.AreEqual(ti1, ti2);
		}


		[Test]
		public void TestGTypeIndexedNotEqual()
		{
			GTypeIndexed ti1 = new GTypeIndexed(4, new GTypeInt());
			GTypeIndexed ti2 = new GTypeIndexed(4, new GTypeChar());

			Assert.AreNotEqual(ti1, ti2);
		}


		[Test]
		public void TestGTypeIndexedDoubleEqual()
		{
			GTypeIndexed ti1 = new GTypeIndexed(5, new GTypeIndexed(4, new GTypeInt()));
			GTypeIndexed ti2 = new GTypeIndexed(5, new GTypeIndexed(4, new GTypeInt()));

			Assert.AreEqual(ti1, ti2);
		}


		[Test]
		public void TestGTypeIndexedDoubleNotEqual()
		{
			GTypeIndexed ti1 = new GTypeIndexed(5, new GTypeIndexed(4, new GTypeInt()));
			GTypeIndexed ti2 = new GTypeIndexed(5, new GTypeIndexed(4, new GTypeChar()));

			Assert.AreNotEqual(ti1, ti2);
		}


		[Test]
		public void TestGTypeProductEqual()
		{
			GTypeProduct tp1 = new GTypeProduct(new GTypeInt(), new GTypeChar());
			GTypeProduct tp2 = new GTypeProduct(new GTypeInt(), new GTypeChar());

			Assert.AreEqual(tp1, tp2);
		}


		[Test]
		public void TestGTypeProductNotEqual()
		{
			GTypeProduct tp1 = new GTypeProduct(new GTypeInt(), new GTypeChar());
			GTypeProduct tp2 = new GTypeProduct(new GTypeInt(), new GTypeInt());

			Assert.AreNotEqual(tp1, tp2);
		}


		[Test]
		public void TestGTypeFunctionEqual()
		{
			GTypeProduct from1 = new GTypeProduct(new GTypeInt(), new GTypeChar());

			GTypeProduct from2 = new GTypeProduct(new GTypeInt(), new GTypeChar());

			GTypeInt to1 = new GTypeInt();
			GTypeInt to2 = new GTypeInt();

			GTypeFunction tf1 = new GTypeFunction(from1, to1);
			GTypeFunction tf2 = new GTypeFunction(from2, to2);

			Assert.AreEqual(tf1, tf2);
		}


		[Test]
		public void TestGTypeFunctionNotEqualFrom()
		{
			GTypeProduct from1 = new GTypeProduct(new GTypeInt(), new GTypeChar());

			GTypeProduct from2 = new GTypeProduct(new GTypeInt(), new GTypeInt());

			GTypeInt to1 = new GTypeInt();
			GTypeInt to2 = new GTypeInt();

			GTypeFunction tf1 = new GTypeFunction(from1, to1);
			GTypeFunction tf2 = new GTypeFunction(from2, to2);

			Assert.AreNotEqual(tf1, tf2);
		}


		[Test]
		public void TestGTypeFunctionNotEqualTo()
		{
			GTypeProduct from1 = new GTypeProduct(new GTypeInt(), new GTypeChar());

			GTypeProduct from2 = new GTypeProduct(new GTypeInt(), new GTypeInt());

			GTypeInt to1 = new GTypeInt();
			GTypeChar to2 = new GTypeChar();

			GTypeFunction tf1 = new GTypeFunction(from1, to1);
			GTypeFunction tf2 = new GTypeFunction(from2, to2);

			Assert.AreNotEqual(tf1, tf2);
		}
	}
}
