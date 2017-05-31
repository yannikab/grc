using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Op;
using Grc.Tac.Exceptions;

namespace Grc.Tac.Quads
{
	public class Quad
	{
		private static Quad nextQuad;

		private readonly int id;

		private readonly Addr addr;

		private OpBase op;
		private Addr arg1;
		private Addr arg2;
		private Addr res;

		public Addr Addr { get { return addr; } }

		public OpBase Op { get { return op; } }

		public Addr Arg1
		{
			get { return arg1; }
			set
			{
				if (!object.Equals(arg1, Addr.Star))
					throw new TacException();

				arg1 = value;
			}
		}

		public Addr Arg2
		{
			get { return arg2; }
			set
			{
				if (!object.Equals(arg2, Addr.Star))
					throw new TacException();

				arg2 = value;
			}
		}

		public Addr Res
		{
			get { return res; }
			set
			{
				if (!object.Equals(res, Addr.Star))
					throw new TacException();

				res = value;
			}
		}

		static Quad()
		{
			nextQuad = new Quad(0, OpNoOp.Instance, Addr.Empty, Addr.Empty, Addr.Empty);
		}

		private Quad(int id, OpBase op, Addr arg1, Addr arg2, Addr res)
		{
			this.id = id;
			this.addr = new Addr(id);

			this.op = op;
			this.arg1 = arg1;
			this.arg2 = arg2;
			this.res = res;
		}

		public static Quad NextQuad { get { return nextQuad; } }

		public static Quad GenQuad(OpBase op, Addr arg1, Addr arg2, Addr res)
		{
			Quad q = nextQuad;

			nextQuad = new Quad(q.id + 1, OpNoOp.Instance, Addr.Empty, Addr.Empty, Addr.Empty);

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
