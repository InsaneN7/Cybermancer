//From the moment I understood the weakness of my flesh, it disgusted me
namespace Cybermancer
{
    class Cyberware : Item
    {
        internal int humanityLoss;
        internal string location;
        internal bool foundational;
        internal int newSlots;
        internal int takesSlots;
        internal RangedWeapon rangedWeapon;
        internal MeleeWeapon meleeWeapon;
        internal Armor armor;

        public Cyberware(string name, string description, bool foundational, int slots, int value, int humanity, string loc)
        {
            base.name = name;
            base.description = description;
            base.cost = value;
            base.type = "cyberware";
            humanityLoss = humanity;
            location = loc;
            this.foundational = foundational;
            if(foundational == true)
            {
                newSlots = slots;
                takesSlots = 0;
            }
            else
            {
                newSlots = 0;
                takesSlots = slots;
            }
        }

        public Cyberware(string name, string description, bool foundational, int slots, 
            int value, int humanity, string loc, RangedWeapon weapon) : this(name, description, foundational, slots, value, humanity, loc)
        {
            rangedWeapon = weapon;
        }

        public Cyberware(string name, string description, bool foundational, int slots, 
            int value, int humanity, string loc, MeleeWeapon weapon) : this(name, description, foundational, slots, value, humanity, loc)
        {
            meleeWeapon = weapon;
        }

        public Cyberware(string name, string description, bool foundational, int slots,
            int value, int humanity, string loc, Armor armor) : this(name, description, foundational, slots, value, humanity, loc)
        {
            this.armor = armor;
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
            else if(armor != null)
            {
                output += $"\nArmor: {armor.name}";
            }
            return output;
        }
    }
}
