﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Op;

namespace Grc.Nodes.Cond
{
	public partial class CondGe : CondRelOpBase
	{
		public override OpBase GetOp()
		{
			return new OpGe();
		}
	}
}
