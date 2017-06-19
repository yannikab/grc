using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public partial class TypeInt : TypeData
	{
		public override Type DotNetType { get { return typeof(int); } }

		public override int ByteSize { get { return 4; } }
	}
}
