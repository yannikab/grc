﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Type;
using Grc.Nodes.Func;

namespace Grc.Nodes
{
	public partial class Parameter
	{
		private readonly string name;
		private readonly bool byRef;
		private readonly TypeDataBase nodeType;
		private readonly DimEmptyT dimEmpty;

		private readonly IReadOnlyList<DimIntegerT> dims;

		private readonly int line;
		private readonly int pos;

		public string Name { get { return name; } }

		public bool ByRef { get { return byRef; } }

		public TypeDataBase NodeType { get { return nodeType; } }

		public DimEmptyT DimEmpty { get { return dimEmpty; } }

		public IReadOnlyList<DimIntegerT> Dims { get { return dims; } }

		public bool Indexed { get { return dimEmpty != null || dims.Count > 0; } }

		public string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if (byRef)
					sb.Append("ref ");

				sb.Append(Name);

				sb.Append(" : ");

				sb.Append(nodeType.Text);

				if (dimEmpty != null)
					sb.Append("[]");

				foreach (DimIntegerT d in Dims)
					sb.Append(string.Format("[{0}]", d.Integer));

				return sb.ToString();
			}
		}

		public int Line { get { return line; } }

		public int Pos { get { return pos; } }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", line, pos); }
		}

		public Parameter(string name, bool byRef, TypeDataBase nodeType, DimEmptyT dimEmpty, IReadOnlyList<DimIntegerT> dims, int line, int pos)
		{
			this.name = name;
			this.byRef = byRef;
			this.nodeType = nodeType;
			this.dimEmpty = dimEmpty;
			this.dims = dims;

			this.line = line;
			this.pos = pos;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
