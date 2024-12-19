using System.Linq.Expressions;

namespace Cybermancer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool lcv = true;
            string input;
            string input2;
            Character character;
            while (lcv)
            {
                Console.Write("What would you like to do? ");
                input = Console.ReadLine()!.Trim().ToLower();
                Console.WriteLine();
                if(input == "create")
                {
                    Console.Write("Would you like a character with BASE stats of 5 or CUSTOM built? ");
                    input = Console.ReadLine()!.Trim().ToLower();
                    Console.WriteLine();
                    if(input == "base")
                    {
                        Console.WriteLine("What's their name and handle?");
                        Console.Write("Name: ");
                        input = Console.ReadLine()!.Trim();
                        Console.Write("Handle: ");
                        input2 = Console.ReadLine()!.Trim();
                        character = new Character(input, input2);
                        character.AddRole("solo");
                        Console.WriteLine(character);
                    }
                }
            }
        }
    }
}
