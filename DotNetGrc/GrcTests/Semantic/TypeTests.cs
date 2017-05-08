using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Semantic.Types;
using NUnit.Framework;


namespace GrcTests.Semantic
{
	[TestFixture]
	public class TypeTests
	{
		[Test]
		public void TestGTypeIndexedEqual()
		{
			GTypeIndexed ti1 = new GTypeIndexed(GTypeInt.Instance);
			GTypeIndexed ti2 = new GTypeIndexed(GTypeInt.Instance);

			Assert.AreEqual(ti1, ti2);
		}


		[Test]
		public void TestGTypeIndexedNotEqual()
		{
			GTypeIndexed ti1 = new GTypeIndexed(GTypeInt.Instance);
			GTypeIndexed ti2 = new GTypeIndexed(GTypeChar.Instance);

			Assert.AreNotEqual(ti1, ti2);
		}


		[Test]
		public void TestGTypeProductEqual()
		{
			GTypeProduct tp1 = new GTypeProduct(GTypeInt.Instance, GTypeChar.Instance);
			GTypeProduct tp2 = new GTypeProduct(GTypeInt.Instance, GTypeChar.Instance);

			Assert.AreEqual(tp1, tp2);
		}


		[Test]
		public void TestGTypeProductNotEqual()
		{
			GTypeProduct tp1 = new GTypeProduct(GTypeInt.Instance, GTypeChar.Instance);
			GTypeProduct tp2 = new GTypeProduct(GTypeInt.Instance, GTypeInt.Instance);

			Assert.AreNotEqual(tp1, tp2);
		}


		[Test]
		public void TestGTypeFunctionEqual()
		{
			GTypeProduct from1 = new GTypeProduct(GTypeInt.Instance, GTypeChar.Instance);

			GTypeProduct from2 = new GTypeProduct(GTypeInt.Instance, GTypeChar.Instance);

			GTypeInt to1 = GTypeInt.Instance;
			GTypeInt to2 = GTypeInt.Instance;

			GTypeFunction tf1 = new GTypeFunction(from1, to1);
			GTypeFunction tf2 = new GTypeFunction(from2, to2);

			Assert.AreEqual(tf1, tf2);
		}

		[Test]
		public void TestGTypeFunctionNotEqualFrom()
		{
			GTypeProduct from1 = new GTypeProduct(GTypeInt.Instance, GTypeChar.Instance);

			GTypeProduct from2 = new GTypeProduct(GTypeInt.Instance, GTypeInt.Instance);

			GTypeInt to1 = GTypeInt.Instance;
			GTypeInt to2 = GTypeInt.Instance;

			GTypeFunction tf1 = new GTypeFunction(from1, to1);
			GTypeFunction tf2 = new GTypeFunction(from2, to2);

			Assert.AreNotEqual(tf1, tf2);
		}


		[Test]
		public void TestGTypeFunctionNotEqualTo()
		{
			GTypeProduct from1 = new GTypeProduct(GTypeInt.Instance, GTypeChar.Instance);

			GTypeProduct from2 = new GTypeProduct(GTypeInt.Instance, GTypeInt.Instance);

			GTypeInt to1 = GTypeInt.Instance;
			GTypeChar to2 = GTypeChar.Instance;

			GTypeFunction tf1 = new GTypeFunction(from1, to1);
			GTypeFunction tf2 = new GTypeFunction(from2, to2);

			Assert.AreNotEqual(tf1, tf2);
		}
	}
}
