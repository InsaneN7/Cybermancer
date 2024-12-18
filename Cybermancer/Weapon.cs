//Weapon, a child of Item
using System.Security.Cryptography.X509Certificates;

namespace Cybermancer
{
    internal class Weapon : Item
    {
        internal int damageDice;
        internal string weaponType;
        internal string attackSkill;
        internal int hands;
        internal string ammoType;
        internal int maxAmmo;
        internal int currentAmmo;
        internal int totalAmmo;
        private string[] allAmmoTypes = new string[17];
        private Random RNGesus = new Random();
        //set up allAmmoTypes

        /// <summary>
        /// Constructor for a weapon
        /// </summary>
        /// <param name="name">What's it called</param>
        /// <param name="desc">What is it</param>
        /// <param name="value">What's it worth</param>
        /// <param name="damage">How many d6's doe it throw</param>
        /// <param name="type">What type of weapon is it</param>
        /// <param name="skill">How do you use it</param>
        /// <param name="hands">How many hands to use it</param>
        /// <param name="max">How much you packing</param>
        public Weapon(string name, string desc, int value, int damage, string type, 
            string skill, int hands, int max)
        {
            base.name = name;
            base.description = desc;
            base.cost = value;
            base.type = "weapon";
            damageDice = damage;
            weaponType = type;
            attackSkill = skill;
            this.hands = hands;
            ammoType = "basic";
            maxAmmo = max;
            allAmmoTypes[0] = "basic";
            allAmmoTypes[1] = "acid paintball";
            allAmmoTypes[2] = "armor-piercing";
            allAmmoTypes[3] = "biotoxin arrow";
            allAmmoTypes[4] = "bullet to slug adapter casing";
            allAmmoTypes[5] = "doberman 500 marking scent";
            allAmmoTypes[6] = "expansive ammunition";
            allAmmoTypes[7] = "incendiary ammunition";
            allAmmoTypes[8] = "junk ammunition";
            allAmmoTypes[9] = "poison ammunition";
            allAmmoTypes[10] = "poison arrow";
            allAmmoTypes[11] = "rubber damage";
            allAmmoTypes[12] = "shotgun shell";
            allAmmoTypes[13] = "sleep arrow";
            allAmmoTypes[14] = "small game ammunition";
            allAmmoTypes[15] = "smart ammunition";
            allAmmoTypes[16] = "stickball sanctioned rubber ammunition";
        }

        /// <summary>
        /// Sets the type of ammo being used
        /// </summary>
        /// <param name="type">The type to use</param>
        /// <exception cref="Exception"></exception>
        public void SetAmmoType(string type)
        {
            bool found = false;
            for(int i = 0; i < allAmmoTypes.Length; i++)
            {
                if(type == allAmmoTypes[i])
                {
                    ammoType = type;
                    found = true;
                    break;
                }
            }
            if(found == false)
            {
                throw new Exception("Invalid ammo type");
            }
        }

        //TO BE FINISHED: ADD AUTOMATIC HIT DETECTION
        public int Attack()
        {
            int damage = 0;
            for(int i = 0; i < damageDice; i++)
            {
                damage += RNGesus.Next(1, 7);
            }
            return damage;
        }
    }
}
