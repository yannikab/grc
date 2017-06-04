using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;
using Grc.Ast.Node.Helper;
using Grc.Sem.Visitor;

namespace Grc.Ast.Node.Func
{
	public partial class LocalFuncDecl : LocalBase
	{
		public void AddParameters(GTypeBase type, IEnumerable<string> names)
		{
			List<ParIdentifierT> parameters = new List<ParIdentifierT>();

			foreach (string s in names)
				parameters.Add(new ParIdentifierT(s, 0, 0));

			HTypePar hTypePar = new NodeComposer().ComposeHTypePar(type);

			HPar hPar = new HPar(parameters, hTypePar, "ref", ":", 0, 0);

			this.hPars.Add(hPar);

			this.parameters.AddRange(hPar.Parameters);
		}
	}
}
