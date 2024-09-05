using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTest.DataStructure
{
    internal class Node
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string>? Defenses { get; set; }
        public Node? LeftChild { get; set; }
        public Node? RightChild { get; set; }
        public int BalanceFactor = 0;

        public static bool operator >(Node node1, Node node2) =>
             node1.MaxSeverity > node2.MaxSeverity;
        public static bool operator <(Node node1, Node node2) =>
             node1.MaxSeverity < node2.MaxSeverity;
        public static bool operator >(Node node, int num) =>
             node.MaxSeverity > num;
        public static bool operator <(Node node, int num) =>
             node.MaxSeverity < num;
        public static bool operator >(int num, Node node) =>
            num > node;
        public static bool operator <(int num, Node node) =>
             num < node.MaxSeverity;
        public static bool operator ==(int num, Node node) =>
             num == node.MaxSeverity || num == node.MinSeverity;
        public static bool operator !=(int num, Node node) =>
             num != node.MaxSeverity;

        public override string ToString()
        {
            return $"Node(MinValue: {MinSeverity}, MaxValue: {MaxSeverity}, Defenses: {string.Join(',', Defenses)})";
        }

    }
}
