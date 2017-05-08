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
	}
}
