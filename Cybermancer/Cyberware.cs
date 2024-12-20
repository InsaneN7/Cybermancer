//From the moment I understood the weakness of my flesh, it disgusted me
namespace Cybermancer
{
    class Cyberware : Item
    {
        internal int humanityLoss;
        internal string location;
        internal RangedWeapon rangedWeapon;
        internal MeleeWeapon meleeWeapon;

        public Cyberware(string name, string description, int value, int humanity, string loc)
        {
            base.name = name;
            base.description = description;
            base.cost = value;
            base.type = "cyberware";
            humanityLoss = humanity;
            location = loc;
        }

        public Cyberware(string name, string description, int value, int humanity, string loc, RangedWeapon weapon) : this(name, description, value, humanity, loc)
        {
            rangedWeapon = weapon;
        }

        public Cyberware(string name, string description, int value, int humanity, string loc, MeleeWeapon weapon) : this(name, description, value, humanity, loc)
        {
            meleeWeapon = weapon;
        }

        public override string ToString()
        {
            string output = base.ToString() + 
                $"\nLocation: {location}" +
                $"\nHumanity cost: {humanityLoss}";
            if(rangedWeapon != null)
            {
                output += $"\nInternal weapon: {rangedWeapon.name}";
            }
            else if (meleeWeapon != null)
            {
                output += $"\nInternal weapon: {meleeWeapon.name}";
            }
            return output;
        }
    }
}
