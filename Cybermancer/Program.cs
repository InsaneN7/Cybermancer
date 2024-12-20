using System.Linq.Expressions;

namespace Cybermancer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1;
            string input2;
            Console.Write("What's your name?");
            input1 = Console.ReadLine()!.Trim();
            Console.WriteLine("What's your handle?");
            input2 = Console.ReadLine()!.Trim();
            Character character = new Character(input1, input2);
            character.AddRole("rockerboy");
            character.AddIP(60);
            character.AddRole("solo");
            Console.WriteLine(character);
        }
    }
}
