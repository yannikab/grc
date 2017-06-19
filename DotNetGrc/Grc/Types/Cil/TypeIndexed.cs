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
				return DotNetElementType.MakeArrayType();
			}
		}

		public Type DotNetElementType
		{
			get
			{
				return ElementType.DotNetType;
			}
		}

		public override int ByteSize
		{
			get
			{
				return TotalElements * ElementType.ByteSize;
			}
		}
	}
}
