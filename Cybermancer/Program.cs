using System.Linq.Expressions;

namespace Cybermancer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character test = new Character("test", "test");
            test.AddRole("solo");
            test.AddIP(300);
            test.AddRole("solo");
            Console.WriteLine(test);
            Console.WriteLine();
            test.PrintSkills();
        }
    }
}
