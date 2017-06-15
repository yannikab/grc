using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public partial class TypeIndexed : TypeBase
	{
		public override Type DotNetType
		{
			get
			{
				return InnerDotNetType.MakeArrayType();
			}
		}

		public Type InnerDotNetType
		{
			get
			{
				TypeBase type = indexedType;

				while (type is TypeIndexed)
					type = (type as TypeIndexed).indexedType;

				return type.DotNetType;
			}
		}
	}
}
