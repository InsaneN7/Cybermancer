//Pistol child of Ranged Weapon
namespace Cybermancer
{
    internal class Pistol : RangedWeapon
    {

        public Pistol(string name, string desc, int value, int damage,
            string skill, int hands, int max, bool conceal, int ROF) : base(name, desc, value, damage, "pistol", skill, hands, max, conceal, ROF)
        {

        }

        /// <summary>
        /// Makes an attack and returns the damage if it hits or 0 if it misses
        /// </summary>
        /// <param name="range">The distance to the target in meters</param>
        /// <param name="penalties">What penalties you might suffer</param>
        /// <param name="roll">What you rolled to hit</param>
        /// <returns>The damage dealt (0 if it's a miss)</returns>
        /// <exception cref="Exception"></exception>
        public int Attack(int range, int penalties, int roll)
        {
            if(range < 0)
            {
                throw new Exception("Great job breaking it asshole");
            }
            else if(range < 6)
            {
                if(roll - penalties > 13)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 12)
            {
                if (roll - penalties > 15)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 25)
            {
                if (roll - penalties > 20)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 50)
            {
                if (roll - penalties > 25)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 100)
            {
                if (roll - penalties > 30)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 200)
            {
                if (roll - penalties > 30)
                {
                    return base.Damage();
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
