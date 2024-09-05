using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeTest.Model;

namespace BinaryTreeTest.DataStructure
{
    internal interface ITree
    {
        void Insert(Defense defense);
        void InsertRange(List<Defense> defenses);
        Defense GetDefenseByThreat(Threat threat);
        List<Defense> GetAllDefensesInOrder();
        string ToStringInOrder();
        string ToStringPreOrder();
        int GetMinValue();
        int GetMaxValue();

    }
}
