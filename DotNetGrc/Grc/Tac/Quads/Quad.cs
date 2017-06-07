using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Tac;
using Grc.Tac.Addr;
using Grc.Tac.Op;

namespace Grc.Tac.Quads
{
	public class Quad
	{
		private static Quad nextQuad;

		private readonly int id;

		private readonly AddrQuad addr;

		private OpBase op;
		private AddrBase arg1;
		private AddrBase arg2;
		private AddrBase res;

		public AddrQuad Addr { get { return addr; } }

		public OpBase Op { get { return op; } }

		public AddrBase Arg1
		{
			get { return arg1; }
			set
			{
				if (!(arg1 is AddrStar))
					throw new TacException();

				arg1 = value;
			}
		}

		public AddrBase Arg2
		{
			get { return arg2; }
			set
			{
				if (!(arg2 is AddrStar))
					throw new TacException();

				arg2 = value;
			}
		}

		public AddrBase Res
		{
			get { return res; }
			set
			{
				if (!(res is AddrStar))
					throw new TacException();

				res = value;
			}
		}

		static Quad()
		{
			nextQuad = new Quad(0, OpNoOp.Instance, AddrEmpty.Instance, AddrEmpty.Instance, AddrEmpty.Instance);
		}

		private Quad(int id, OpBase op, AddrBase arg1, AddrBase arg2, AddrBase res)
		{
			this.id = id;
			this.addr = new AddrQuad(id);

			this.op = op;
			this.arg1 = arg1;
			this.arg2 = arg2;
			this.res = res;
		}

		public static Quad NextQuad { get { return nextQuad; } }

		public static Quad GenQuad(OpBase op, AddrBase arg1, AddrBase arg2, AddrBase res)
		{
			Quad q = nextQuad;

			nextQuad = new Quad(q.id + 1, OpNoOp.Instance, AddrEmpty.Instance, AddrEmpty.Instance, AddrEmpty.Instance);

			q.op = op;
			q.arg1 = arg1;
			q.arg2 = arg2;
			q.res = res;

			return q;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}, {3}, {4}", id, op, arg1, arg2, res);
		}
	}
}
