using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTest.DataStructure
{
	internal partial class Tree : ITree
	{

		public int GetMaxValue() =>
			GetMaxValue(_root);
		int GetMaxValue(Node node) =>
			node.RightChild == null ? node.MaxSeverity : GetMaxValue(node.RightChild);
		public int GetMinValue() =>
			GetMinValue(_root);
		int GetMinValue(Node node) =>
			node.LeftChild == null ? node.MinSeverity : GetMinValue(node.LeftChild);

		public string ToStringInOrder() =>
		   InOrderRecursiveTraversalForPrint(_root);


		public string ToStringPreOrder() =>
			PreOrderRecursiveTraversalForPrint(_root);



	}
}
