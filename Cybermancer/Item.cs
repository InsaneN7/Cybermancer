// Parent class for all items
namespace Cybermancer
{
    internal class Item
    {
        internal string name;
        internal string description;
        internal int cost;
        internal string type;

        public override string ToString()
        {
            return $"{name}:" +
                $"\nWorth: {cost} eddies" +
                $"\n{description}";
        }
    }
}
