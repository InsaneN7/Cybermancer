//Class for skills
namespace Cybermancer
{
    class Skill
    {
        internal string name;
        internal int score;
        internal bool timesTwo;
        internal int levels;

        public Skill(string name, int score, bool timesTwo)
        {
            this.name = name;
            this.score = score;
            this.timesTwo = timesTwo;
            levels = 0;
        }

        public override string ToString()
        {
            return $"{name} has a bonus of {score}";
        }
    }
}
