using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public class TypeProduct : TypeBase
	{
		private readonly TypeBase left;
		private readonly TypeBase right;

		public TypeBase Left { get { return left; } }

		public TypeBase Right { get { return right; } }

		public TypeProduct(TypeBase left, TypeBase right)
		{
			this.left = left;
			this.right = right;
		}

		public override bool Equals(object obj)
		{
			TypeProduct that = obj as TypeProduct;

			if (that == null)
				return false;

			return Equals(this.left, that.left) && Equals(this.right, that.right);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + (left != null ? left.GetHashCode() : 0) + (right != null ? right.GetHashCode() : 0);
		}

		public override bool MatchesRef(TypeBase obj)
		{
			TypeProduct that = obj as TypeProduct;

			if (that == null)
				return false;

			if (!Equals(this, that))
				return false;

			if (!this.left.MatchesRef(that.left))
				return false;

			if (!this.right.MatchesRef(that.right))
				return false;

			return true;
		}

		private void TypeString(out string typeLeft, out string typeRight)
		{
			if (left is TypeProduct)
			{
				string l;
				string r;
				((TypeProduct)left).TypeString(out l, out r);
				typeLeft = string.Format("{0}, {1}", l, r);
			}
			else
			{
				typeLeft = left.ToString();
			}

			if (right is TypeProduct)
			{
				string l;
				string r;
				((TypeProduct)right).TypeString(out l, out r);
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

		public override TypeBase Clone()
		{
			return new TypeProduct(left.Clone(), right.Clone());
		}
	}
}
