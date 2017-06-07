using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;

namespace Grc.Quads
{
	public static class QuadList
	{
		public static List<Quad> Empty()
		{
			return new List<Quad>();
		}

		public static List<Quad> Make(Quad q)
		{
			List<Quad> l = new List<Quad>();

			l.Add(q);

			return l;
		}

		public static List<Quad> Merge(this List<Quad> a, List<Quad> b)
		{
			return a.Concat(b).ToList();
		}

		public static void BackPatch(this List<Quad> l, AddrQuad a)
		{
			foreach (Quad q in l)
			{
				if (q.Arg1 is AddrStar)
					q.Arg1 = a;

				if (q.Arg2 is AddrStar)
					q.Arg2 = a;

				if (q.Res is AddrStar)
					q.Res = a;
			}
		}
	}
}
