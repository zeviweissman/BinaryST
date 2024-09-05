using BinaryTreeTest.DataStructure;
using BinaryTreeTest.Service;
using static BinaryTreeTest.Service.JsonService;
namespace BinaryTreeTest
{
    internal class Mytest
	{
		
		public static async Task Main()
		{
			Tree tree = new Tree();
			var defences = await GetAllDefences();
			tree.InsertRange(defences);
            Console.WriteLine("tree builded succefully");
            await Task.Delay(4000);
            Console.WriteLine(tree.ToStringPreOrder());           
            Console.WriteLine(tree.ToStringInOrder());
            await Task.Delay(4000);

			var threates = await GetAllThreats();
            Console.WriteLine("got all threats");
			await Task.Delay(4000);

			foreach (var threat in threates)
            {
                try
                {
                    List<string> defenses = tree.GetDefenseByThreat(threat).Defenses;
                    Console.WriteLine("Preapare To Defened");
                    foreach (var defense in defenses)
                    {
                        Console.WriteLine(defense);
                        await Task.Delay(2000);
                    }
                    Console.WriteLine("Finshed Defending");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

            }



        }

	}

}

