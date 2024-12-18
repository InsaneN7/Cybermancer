//Armor child of the item class
namespace Cybermancer
{
    class Armor : Item
    {
        internal string location;
        internal int SP;

        /// <summary>
        /// Constructor for armor
        /// </summary>
        /// <param name="name">What's it called</param>
        /// <param name="desc">What is it</param>
        /// <param name="value">What's it worth</param>
        /// <param name="loc">Where's it protect</param>
        /// <param name="sp">How good's it</param>
        public Armor(string name, string desc, int value, string loc, int sp)
        {
            base.name = name;
            base.description = desc;
            base.cost = value;
            base.type = "armor";
            location = loc;
            SP = sp;
        }

        public override string ToString()
        {
            return base.ToString() + 
                $"\nProtects: {location}" +
                $"\nSP: {SP}";
        }
    }
}
