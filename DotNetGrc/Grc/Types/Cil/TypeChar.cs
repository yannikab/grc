using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public partial class TypeChar : TypeData
	{
		public override Type DotNetType
		{
			get { return typeof(char); }
		}
	}
}
