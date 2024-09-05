using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTest.Model
{
	internal class Defense
	{
		public int MinSeverity { get; set; }
		public int MaxSeverity { get; set; }
		public List<string> Defenses { get; set; }

		public override string ToString() =>
			$"{string.Join(',', Defenses)}";
		
			
		
	}
}
