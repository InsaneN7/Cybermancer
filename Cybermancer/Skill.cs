//Class for skills
namespace Cybermancer
{
    internal class Skill
    {
        internal string name;
        internal int score;
        internal bool timesTwo;
        internal int level;

        public Skill(string name, int score, bool timesTwo)
        {
            this.name = name;
            this.score = score;
            this.timesTwo = timesTwo;
            level = 0;
        }

        public int RollSkill(int roll, int additions, int penalties)
        {
            return roll + score + level + additions - penalties;
        }

        public override string ToString()
        {
            return $"{name} has a bonus of {score}";
        }
    }
}
