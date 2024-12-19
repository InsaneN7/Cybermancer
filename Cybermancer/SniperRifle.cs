//Sniper rifle child of the ranged weapon
namespace Cybermancer
{
    internal class SniperRifle : RangedWeapon
    {
        /// <summary>
        /// Constructor for a sniper rifle
        /// </summary>
        /// <param name="name">What's it called</param>
        /// <param name="desc">What is it</param>
        /// <param name="value">What's it worth</param>
        /// <param name="damage">How many d6's doe it throw</param>
        /// <param name="skill">How do you use it</param>
        /// <param name="hands">How many hands to use it</param>
        /// <param name="max">How much you packing</param>
        public SniperRifle(string name, string desc, int value, int damage, 
            string skill, int hands, int max) : base(name, desc, value, damage, "sniper rifle", skill, hands, max)
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
            if (range < 0)
            {
                throw new Exception("Great job breaking it asshole");
            }
            else if (range < 6)
            {
                if (roll - penalties > 30)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 12)
            {
                if (roll - penalties > 25)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 25)
            {
                if (roll - penalties > 25)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 50)
            {
                if (roll - penalties > 20)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 100)
            {
                if (roll - penalties > 15)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 200)
            {
                if (roll - penalties > 16)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 400)
            {
                if (roll - penalties > 17)
                {
                    return base.Damage();
                }
                return 0;
            }
            else if (range < 800)
            {
                if (roll - penalties > 20)
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
