//BONK
namespace Cybermancer
{
    internal class MeleeWeapon : Item
    {
        internal int damageDice;
        internal string attackSkill;
        internal int hands;
        internal bool concealable;
        internal int rof;
        private Random RNGesus;

        public MeleeWeapon(string name, string desc, int value, int damage,
            string skill, int hands, bool conceal, int rof)
        {
            base.name = name;
            base.description = desc;
            base.cost = value;
            base.type = "melee weapon";
            damageDice = damage;
            attackSkill = skill;
            this.hands = hands;
            concealable = conceal;
            this.rof = rof;
            RNGesus = new Random();
        }

        public int Attack(int attackRoll, int dodge)
        {
            int output = 0;
            if(attackRoll > dodge)
            {
                for(int i = 0; i < damageDice; i++)
                {
                    output += RNGesus.Next(1, 7);
                }
            }
            return output;
        }

        public string QuickStats()
        {
            return $"{name}, {damageDice}d6";
        }
    }
}
