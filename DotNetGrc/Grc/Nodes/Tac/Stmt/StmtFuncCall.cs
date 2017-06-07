﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Stmt
{
	public partial class StmtFuncCall : StmtBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return funCall.Tac; }
		}

		public void ChangeName(string name)
		{
			this.name = name;
		}
	}
}
