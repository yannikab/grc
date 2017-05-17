using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeProduct : GTypeBase
	{
		private GTypeBase left;
		private GTypeBase right;

		public GTypeBase Left { get { return left; } }

		public GTypeBase Right { get { return right; } }

		public GTypeProduct(GTypeBase left, GTypeBase right)
			: base(false)
		{
			this.left = left;
			this.right = right;
		}

		public override bool Equals(object obj)
		{
			GTypeProduct that;

			if ((that = obj as GTypeProduct) == null)
				return false;

			return object.Equals(this.left, that.left) && object.Equals(this.right, that.right);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + (left != null ? left.GetHashCode() : 0) + (right != null ? right.GetHashCode() : 0);
		}

		public override bool MatchesRef(GTypeBase obj)
		{
			GTypeProduct that = obj as GTypeProduct;

			if (that == null)
				return false;

			if (!object.Equals(this, that))
				return false;

			if (!this.left.MatchesRef(that.left))
				return false;

			if (!this.right.MatchesRef(that.right))
				return false;

			return true;
		}

		private void TypeString(out string typeLeft, out string typeRight)
		{
			if (left is GTypeProduct)
			{
				string l;
				string r;
				(left as GTypeProduct).TypeString(out l, out r);
				typeLeft = string.Format("{0}, {1}", l, r);
			}
			else
			{
				typeLeft = left.ToString();
			}

			if (right is GTypeProduct)
			{
				string l;
				string r;
				(right as GTypeProduct).TypeString(out l, out r);
				typeRight = string.Format("{0}, {1}", l, r);
			}
			else
			{
				typeRight = right.ToString();
			}
		}

		public override string ToString()
		{
			string typeLeft;
			string typeRight;

			TypeString(out typeLeft, out typeRight);

			return string.Format("({0}, {1})", typeLeft, typeRight);
		}
	}
}
