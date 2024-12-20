//The Solo role

namespace Cybermancer
{
    internal class Solo : Role
    {
        internal int deflection;
        internal bool fumble;
        internal int initive;
        internal int percision;
        internal int weakness;
        internal int detection;

        /// <summary>
        /// Constructor for the solo role
        /// </summary>
        /// <param name="rank"></param>
        public Solo(int rank)
        {
            base.name = "Solo";
            base.rank = rank;
            base.description = "Combat Awareness:" +
                "When combat begins (before Initiative is rolled), anytime outside of combat, or in combat with an Action, a Solo may divide the total number of points they have in their Combat Awareness Role Ability among the following abilities. If a Solo chooses to not change their point assignments, their previous ones persist. Activating some of these abilities will cost the Solo more points than others:" +
                "\r\n \r\n▶ Damage Deflection" +
                "\r\n \r\nYou have been trained to \"roll with the punches,\" reducing damage done to you. • For 2 points, decrease the first damage you take this Round by 1. • For 4 points, decrease the first damage you take this Round by 2. • For 6 points, decrease the first damage you take this Round by 3. • For 8 points, decrease the first damage you take this Round by 4. • For 10 points, decrease the first damage you take this Round by 5." +
                "\r\n \r\n▶ Fumble Recovery" +
                "\r\nYou have been trained to instantly recover from mishaps by taking your time with every shot. For 4 points, you ignore critical failures (1s) you roll while attacking. These rolls are still treated as 1, however." +
                "\r\n \r\n▶ Initiative Reaction" +
                "\r\nYour reflexes are trained to respond instantly, without thinking, at the start of a firefight. Each point adds a +1 to Initiative rolls made." +
                "\r\n▶ Precision Attack\r\nYou have been trained to precisely aim attacks, giving you greater accuracy. • For 3 points, you add a +1 to any Attacks made. • For 6 points, you add a +2 to any Attacks made. • For 9 points, you add a +3 to any Attacks made." +
                "\r\n \r\n▶ Spot Weakness" +
                "\r\nYou have been trained to look for weak spots to damage even heavily armored targets. Each point adds a +1 to the damage (before armor) of your first successful Attack in a Round." +
                "\r\n \r\n▶ Threat Detection" +
                "\r\nYou have enhanced situational awareness. Each point adds a +1 to any Perception Checks made.";
            deflection = 0;
            fumble = false;
            initive = 0;
            percision = 0;
            weakness = 0;
            detection = 0;
        }

        /// <summary>
        /// Sets combat awarness points
        /// </summary>
        /// <param name="def">The amount of points to give to deflection</param>
        /// <param name="fum">The amount of points to give to fumble</param>
        /// <param name="init">The amount of points to give to initive</param>
        /// <param name="per">The amount of points to give to percision</param>
        /// <param name="weak">The amount of points to give to spot weakness</param>
        /// <param name="detec">The amount of points to give to threat detection</param>
        /// <exception cref="Exception"></exception>
        public void SetCombatAwareness(int def, int fum, int init, int per, int weak, int detec)
        {
            if (def + fum + init + per + weak + detec > rank)
            {
                throw new Exception($"You do not have that many Combat Awareness points. " +
                    $"You have a total of {rank} to distribute");
            }
            else if (def < 0 || fum < 0 || init < 0 || per < 0 || weak < 0 || detec < 0)
            {
                throw new Exception("You cannot use negative numbers");
            }
            else
            {
                deflection = def / 2;
                if(fum >= 4)
                {
                    fumble = true;
                }
                else
                {
                    fumble = false;
                }
                initive = init;
                percision = per / 3;
                weakness = weak;
                detection = detec;
            }
        }
    }
}
