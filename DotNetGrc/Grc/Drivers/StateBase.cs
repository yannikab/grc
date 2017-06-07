using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.io;
using k31.grc.cst.lexer;

namespace Grc.Drivers
{
	abstract class StateBase
	{
		public abstract void HandleArgument(ArgumentContext context, string arg);

		public Lexer GetLexer(string filename)
		{
			try
			{
				if (filename != null)
					return new Lexer(new PushbackReader(new FileReader(filename), 4096));
			}
			catch (FileNotFoundException)
			{
			}

			System.Console.WriteLine("File not found: " + filename);

			return null;
		}
	}
}
