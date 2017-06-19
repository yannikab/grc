using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public abstract partial class TypeBase
	{
		public virtual Type DotNetType { get { return typeof(void); } }

		public virtual int ByteSize { get { return 0; } }
	}
}
