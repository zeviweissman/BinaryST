using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BinaryTreeTest.Utils.Utils;

namespace BinaryTreeTest.Model
{
	internal class Threat
	{

		public string ThreatType { get; set; }
		public int Volume {  get; set; }	
		public int Sophistication {  get; set; }	
		public string Target {  get; set; }

		public override string ToString() =>
			$"{GetThreatSeverity(this)}, {ThreatType}";

	}
}
