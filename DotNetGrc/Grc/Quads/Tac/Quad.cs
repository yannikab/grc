using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Tac;
using Grc.Quads.Addr;
using Grc.Quads.Op;

namespace Grc.Quads
{
	public partial class Quad
	{
		private static Quad nextQuad;

		private readonly int id;

		private AddrQuad addr;

		private OpBase op;

		public OpBase Op { get { return op; } }

		private readonly AddrBase[] addrs = new AddrBase[3];

		public int Id { get { return id; } }

		public AddrQuad Addr
		{
			get
			{
				if (addr == null)
					addr = new AddrQuad(this);

				return addr;
			}
		}

		public IEnumerable<AddrBase> Addrs { get { return addrs; } }

		public AddrBase Arg1
		{
			get { return addrs[0]; }
			set
			{
				if (addrs[0] != null && !(addrs[0] is AddrStar))
					throw new TacException();

				addrs[0] = value;
			}
		}

		public AddrBase Arg2
		{
			get { return addrs[1]; }
			set
			{
				if (addrs[1] != null && !(addrs[1] is AddrStar))
					throw new TacException();

				addrs[1] = value;
			}
		}

		public AddrBase Res
		{
			get { return addrs[2]; }
			set
			{
				if (addrs[2] != null && !(addrs[2] is AddrStar))
					throw new TacException();

				addrs[2] = value;
			}
		}

		static Quad()
		{
			nextQuad = new Quad(0, OpNoOp.Instance, AddrStar.Instance, AddrStar.Instance, AddrStar.Instance);
		}

		private Quad(int id, OpBase op, AddrBase arg1, AddrBase arg2, AddrBase res)
		{
			this.id = id;

			this.op = op;
			this.op.Quad = this;
			this.Arg1 = arg1;
			this.Arg2 = arg2;
			this.Res = res;
		}

		public static Quad NextQuad { get { return nextQuad; } }

		public static Quad GenQuad(OpBase op, AddrBase arg1, AddrBase arg2, AddrBase res)
		{
			Quad q = nextQuad;

			nextQuad = new Quad(q.id + 1, OpNoOp.Instance, AddrStar.Instance, AddrStar.Instance, AddrStar.Instance);

			q.op = op;
			q.op.Quad = q;
			q.Arg1 = arg1;
			q.Arg2 = arg2;
			q.Res = res;

			return q;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}, {3}, {4}", id, op, addrs[0], addrs[1], addrs[2]);
		}
	}
}
