//Weapon, a child of Item
using System.Security.Cryptography.X509Certificates;

namespace Cybermancer
{
    internal class RangedWeapon : Item
    {
        internal int damageDice;
        internal string weaponType;
        internal string attackSkill;
        internal int hands;
        internal string ammoType;
        internal int maxAmmo;
        internal int currentAmmo;
        internal int totalAmmo;
        private Random RNGesus = new Random();

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
        public RangedWeapon(string name, string desc, int value, int damage, string type,
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
            currentAmmo = 0;
        }

        public int Damage()
        {
            int damage = 0;
            for (int i = 0; i < damageDice; i++)
            {
                damage += RNGesus.Next(1, 7);
            }
            return damage;
        }

        /// <summary>
        /// Returns how many bullets need to be loaded
        /// </summary>
        /// <returns></returns>
        public int Reload()
        {
            return maxAmmo - currentAmmo;
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\nDamage: {damageDice}d6" +
                $"\nWeapon Type: {weaponType}" +
                $"\nAttack Skill: {attackSkill}" +
                $"\nHands: {hands}" +
                $"\nCurrent Ammo Type: {ammoType}" +
                $"\nAmmo: {currentAmmo}/{maxAmmo}";
        }
    }
    
}
