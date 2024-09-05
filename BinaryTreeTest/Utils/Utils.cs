using BinaryTreeTest.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTest.Utils
{
    internal class Utils
    {
        static Dictionary<string, int> targetValue = new ()
        {
            { "Web Server", 10},
            {"Database" , 15},
            {"User Credentials" , 20}

        };

        public static Func<Defense, Node> DefenseToNode =
            (defense) => new()
            {
                MinSeverity = defense.MinSeverity,
                MaxSeverity = defense.MaxSeverity,
                Defenses = defense.Defenses
            };

        public static Func<Node, Defense> NodeToDefense =
            (node) => new()
            {
                MinSeverity = node.MinSeverity,
                MaxSeverity = node.MaxSeverity,
                Defenses = node.Defenses
            };


        static Func<Node, Node, bool> DoesMinExist =
            (node1, node2) => node1.MinSeverity == node2.MinSeverity;

        static Func<Node, Node, bool> DoesMaxExist =
            (node1, node2) => node1.MaxSeverity == node2.MaxSeverity;

        public static Func<Node, Node, bool> ValueExist =
            (node1, node2) => DoesMaxExist(node1, node2) || DoesMinExist(node1, node2);

        public static Func<Threat, int> GetThreatSeverity =
            (threat) => (threat.Volume * threat.Sophistication) + targetValue.GetValueOrDefault(threat.Target, 5);




    }
}
