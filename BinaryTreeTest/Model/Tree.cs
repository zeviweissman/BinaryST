using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BinaryTreeTest.Utils.Utils;
namespace BinaryTreeTest.Model
{
    internal class Tree : TreeInterface
    {
        Node _root;

		public List<Defense> GetAllDefensesInOrder()
		{
            List<Node> allNodes = InOrderRecursiveTraversal(_root);
            return allNodes.Select(NodeToDefense).ToList();  
		}
        
        public List<Defense> GetAllDefensesPreOrder()
		{
            List<Node> allNodes = PreOrderRecursiveTraversal(_root);
            return allNodes.Select(NodeToDefense).ToList();  
		}
        
       

		public void Insert(Defense defense)
        {
            _root = InsertRecursively(_root, DefenseToNode(defense));
        }

      


        Node InsertRecursively(Node prevNode, Node newNode)
        {
            if (prevNode == null)
            {
                return newNode;
            }

            if (ValueExist(prevNode, newNode))
            {
                return prevNode;
            }

            if (prevNode > newNode)
            {
                prevNode.LeftChild = InsertRecursively(prevNode.LeftChild, newNode);
            }
            else
            {
                prevNode.RightChild = InsertRecursively(prevNode.RightChild, newNode);
            }

			return balanceTree(prevNode);
            return prevNode;
        }



		public string InOrderRecursiveTraversalForPrint(Node node)
		{
			var result = new StringBuilder();
			InOrderRecursiveTraversalForPrint(node, result, "", "", 0);
			return result.ToString();
		}

		private void InOrderRecursiveTraversalForPrint(Node node, StringBuilder result, string prefix, string childPrefix, int level)
		{
			if (node == null)
			{
				return;
			}

			if (node.LeftChild != null)
			{
				InOrderRecursiveTraversalForPrint(node.LeftChild, result, childPrefix + (level > 0 ? "    " : ""), "│   ", level + 1);
			}
			else if (level > 0)
			{
				result.AppendLine(childPrefix + "    " + "└── " + "null");
			}
			result.AppendLine(prefix + (level > 0 ? "└── " : "") + node.ToString());

			if (node.RightChild != null)
			{
				InOrderRecursiveTraversalForPrint(node.RightChild, result, childPrefix + (level > 0 ? "    " : ""), "│   ", level + 1);
			}
			else if (level > 0)
			{
				result.AppendLine(childPrefix + "    " + "└── " + "null");
			}

		}


		public string PreOrderRecursiveTraversalForPrint(Node node)
		{
			var result = new StringBuilder();
			PreOrderRecursiveTraversalForPrint(node, result, "", "", 0);
			return result.ToString();
		}

		private void PreOrderRecursiveTraversalForPrint(Node node, StringBuilder result, string prefix, string childPrefix, int level)
		{
			if (node == null)
			{
				return;
			}

			result.AppendLine(prefix + (level > 0 ? "└── " : "") + node.ToString());

			if (node.LeftChild != null)
			{
				PreOrderRecursiveTraversalForPrint(node.LeftChild, result, childPrefix + (level > 0 ? "    " : ""), "│   ", level + 1);
			}
			else if (level > 0)
			{
				result.AppendLine(childPrefix + "    " + "└── " + "null");
			}
			if (node.RightChild != null)
			{
				PreOrderRecursiveTraversalForPrint(node.RightChild, result, childPrefix + (level > 0 ? "    " : ""), "│   ", level + 1);
			}
			else if (level > 0)
			{
				result.AppendLine(childPrefix + "    " + "└── " + "null");
			}

		}



		List<Node> InOrderRecursiveTraversal(Node node)
        {
            if (node == null)
            {
                return [];
            }

            var leftChild = InOrderRecursiveTraversal(node.LeftChild);          
            var currentNode = new List<Node> {node};
            var rightChild = InOrderRecursiveTraversal(node.RightChild);
		
			

			return [..leftChild,..currentNode,..rightChild];

        }
        
      
        
        List<Node> PreOrderRecursiveTraversal(Node node)
        {
            if (node == null)
            {
                return [];
            }

            var currentNode = new List<Node> {node};
            var leftChild = InOrderRecursiveTraversal(node.LeftChild);
            var rightChild = InOrderRecursiveTraversal(node.RightChild);

            return [..currentNode,..leftChild,..rightChild];

        }

		public Defense GetDefenseByThreat(Threat threat)
		{
			int severity = GetThreatSeverity(threat);
            if (severity > GetMaxValue())
            {
                throw new Exception("No suitable defence was found. Brace for impact");
			}
			if (severity < GetMinValue())
            {
                throw new Exception("Attack severity is below the threshold.Attack is ignored");

			}
			Node defenseNode = SearchRecursive(_root, severity)
				?? throw new Exception("Could not find a defense for this sevrity level");
            return NodeToDefense(defenseNode);               
		}

		Node? SearchRecursive(Node node, int severity)
		{
			if (node == null)
			{
				return null;
			}

			if (severity == node)
			{
				return node;
			}

			if (severity < node)
			{
				return SearchRecursive(node.LeftChild, severity);
			}

			else
			{
				return SearchRecursive(node.RightChild, severity);
			}
		}

		public void InsertRange(List<Defense> defenses)
		{
            defenses.ForEach(Insert);
		}

        public string ToStringInOrder() =>
            InOrderRecursiveTraversalForPrint(_root);
		

		public string ToStringPreOrder() =>
			PreOrderRecursiveTraversalForPrint(_root);

	

		public int GetMaxValue() =>
            GetMaxValue(_root);
		int GetMaxValue(Node node) =>
            node.RightChild == null ? node.MaxSeverity : GetMaxValue(node.RightChild);
        public int GetMinValue() =>
            GetMinValue(_root);
		int GetMinValue(Node node) =>
            node.LeftChild == null ? node.MinSeverity : GetMinValue(node.LeftChild);



		int height(Node node)
		{
			if (node == null)
			{
				return 0;
			}
			else
			{
				return 1 + int.Max(height(node.LeftChild), height(node.RightChild));
			}
		}




		private Node balanceTree(Node node)
		{
			if (node != null) 
			{
				node.BalanceFactor = height(node.LeftChild) - height(node.RightChild);
				if (node.BalanceFactor <= -2)
				{
					return rotateLeft(node);
				}
				if (node.BalanceFactor >= 2)
				{
					return rotateRight(node);
				}
			}
			return node;

		}

		private Node rotateLeft(Node node)
		{
			if (node.RightChild.BalanceFactor > 0) 
			{
				rotateRight(node.RightChild);
			}

			Node oldRoot = node;
			Node newRoot = node.RightChild;

			oldRoot.RightChild = newRoot.LeftChild;
			newRoot.LeftChild = oldRoot;

			node = newRoot;
			return node;
		}

		private Node rotateRight(Node node)
		{
			if (node.LeftChild.BalanceFactor < 0) 
			{
				rotateLeft(node.LeftChild);
			}

			Node oldRoot = node;
			Node newRoot = node.LeftChild;

			oldRoot.LeftChild = newRoot.RightChild;
			newRoot.RightChild = oldRoot;

			node = newRoot;
			return node;
		}

	}
}
