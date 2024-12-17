//Class for characters of any type. Shouldn't be a parent whatsoever
using System.ComponentModel;

namespace Cybermancer
{
    internal class Character
    {
        // ------ CLASSES ------
        private Dictionary<string, int> stats;
        private Dictionary<string, Skill> skills;
        private string name;
        private string handle;
        private int humanity;
        private Dictionary<string, Role> roles;
        private int maxHealth;

        // ------ CONSTRUCTORS ------

        /// <summary>
        /// Constructor for a character
        /// </summary>
        /// <param name="name">their name</param>
        /// <param name="handle">their handle</param>
        /// <param name="smart">their intellegence score</param>
        /// <param name="reflex">their reflex score</param>
        /// <param name="dex">their dexterity score</param>
        /// <param name="tech">their technique score</param>
        /// <param name="cool">their cool score</param>
        /// <param name="will">their willpower score</param>
        /// <param name="move">their movement score</param>
        /// <param name="body">their body score</param>
        /// <param name="emp">their empathy score</param>
        public Character(string name, string handle, int smart, int reflex,
            int dex, int tech, int cool, int will, int move, int body, int emp)
        {
            this.name = name;
            this.handle = handle;
            humanity = emp * 10;
            stats = new Dictionary<string, int>(9);
            roles = new Dictionary<string, Role>();
            skills = new Dictionary<string, Skill>(60);
            stats.Add("int", smart);
            stats.Add("ref", reflex);
            stats.Add("dex", dex);
            stats.Add("tech", tech);
            stats.Add("cool", cool);
            stats.Add("will", will);
            stats.Add("move", move);
            stats.Add("body", body);
            stats.Add("emp", emp);
            SkillsSetup();
            SetMaxHealth();
        }

        /// <summary>
        /// Quick constructor for a character, with all stats as 5
        /// </summary>
        /// <param name="name">their name</param>
        /// <param name="handle">their handle</param>
        public Character(string name, string handle) : this(name, handle, 5, 5, 5, 5, 5, 5, 5, 5, 5)
        {
            //NOTHING GOES HERE
        }

        // ------ METHODS ------

        public void PrintSkills()
        {
            foreach(Skill skill in skills.Values)
            {
                Console.WriteLine(skill);
            }
        }

        // ------ HELPERS ------

        /// <summary>
        /// Sets up the skills dictionary
        /// </summary>
        private void SkillsSetup()
        {
            //Cool
            skills.Add("acting", new Skill("Acting", stats["cool"], false));
            skills.Add("bribery", new Skill("Bribery", stats["cool"], false));
            skills.Add("interrogation", new Skill("Interrogation", stats["cool"], false));
            skills.Add("personal grooming", new Skill("Personal Grooming", stats["cool"], false));
            skills.Add("persuasion", new Skill("Persuasion", stats["cool"], false));
            skills.Add("streetwise", new Skill("Streetwise", stats["cool"], false));
            skills.Add("trading", new Skill("Trading", stats["cool"], false));
            skills.Add("wardrobe & style", new Skill("Wardrobe & Style", stats["cool"], false));
            //Dexterity
            skills.Add("athletics", new Skill("Athletics", stats["dex"], false));
            skills.Add("brawling", new Skill("Brawling", stats["dex"], false));
            skills.Add("contortionist", new Skill("Contortionist", stats["dex"], false));
            skills.Add("dance", new Skill("Dance", stats["dex"], false));
            skills.Add("evasion", new Skill("Evasion", stats["dex"], false));
            skills.Add("martial arts", new Skill("Martial Arts", stats["dex"], true));
            skills.Add("melee weapon", new Skill("Melee Weapon", stats["dex"], false));
            skills.Add("stealth", new Skill("Stealth", stats["dex"], false));
            //empathy
            skills.Add("conversation", new Skill("Conversation", stats["emp"], false));
            skills.Add("human perception", new Skill("Human Perception", stats["emp"], false));
            //intelligence
            skills.Add("accounting", new Skill("Accounting", stats["int"], false));
            skills.Add("animal handling", new Skill("Animal Handling", stats["int"], false));
            skills.Add("bureaucracy", new Skill("Bureaucracy", stats["int"], false));
            skills.Add("business", new Skill("Business", stats["int"], false));
            skills.Add("composition", new Skill("Compostion", stats["int"], false));
            skills.Add("conceal/reveal object", new Skill("Conceal/Reveal Object", stats["int"], false));
            skills.Add("criminology", new Skill("Criminology", stats["int"], false));
            skills.Add("cryptography", new Skill("Cryptography", stats["int"], false));
            skills.Add("deduction", new Skill("Deduction", stats["int"], false));
            skills.Add("education", new Skill("Education", stats["int"], false));
            skills.Add("gamble", new Skill("Gamble", stats["int"], false));
            skills.Add("language", new Skill("Language", stats["int"], false));
            skills.Add("library search", new Skill("Library Search", stats["int"], false));
            skills.Add("lip reading", new Skill("Lip Reading", stats["int"], false));
            skills.Add("local expert", new Skill("Local Expert", stats["int"], false));
            skills.Add("perception", new Skill("Perception", stats["int"], false));
            skills.Add("science", new Skill("Science", stats["int"], false));
            skills.Add("tactics", new Skill("Tactics", stats["int"], false));
            skills.Add("tracking", new Skill("Tracking", stats["int"], false));
            skills.Add("wilderness survival", new Skill("Wilderness Survival", stats["int"], false));
            //will
            skills.Add("concentration", new Skill("Concentration", stats["will"], false));
            skills.Add("endurence", new Skill("Endurence", stats["will"], false));
            skills.Add("resist torture/drugs", new Skill("Resist Torture/Drugs", stats["will"], false));
            //reflex
            skills.Add("archery", new Skill("Archery", stats["ref"], false));
            skills.Add("autofire", new Skill("Autofire", stats["ref"], true));
            skills.Add("drive land vehicle", new Skill("Drive Land Vehicle", stats["ref"], false));
            skills.Add("handgun", new Skill("Handgun", stats["ref"], false));
            skills.Add("heavy weapons", new Skill("Heavy Weapons", stats["ref"], true));
            skills.Add("pilot air vehicle", new Skill("Pilot Air Vehicle", stats["ref"], true));
            skills.Add("pilot sea vehicle", new Skill("Pilot Sea Vehicle", stats["ref"], false));
            skills.Add("riding", new Skill("Riding", stats["ref"], false));
            skills.Add("shoulder arms", new Skill("Shoulder Arms", stats["ref"], false));
            //technique
            skills.Add("air vehicle tech", new Skill("Air Vehicle Tech", stats["tech"], false));
            skills.Add("basic tech", new Skill("Basic Tech", stats["tech"], false));
            skills.Add("cybertech", new Skill("Cybertech", stats["tech"], false));
            skills.Add("demolitions", new Skill("Demolitions", stats["tech"], true));
            skills.Add("electronics/security tech", new Skill("Electronics/Security Tech", stats["tech"], true));
            skills.Add("first aid", new Skill("First Aid", stats["tech"], false));
            skills.Add("forgery", new Skill("Forgery", stats["tech"], false));
            skills.Add("land vehicle tech", new Skill("Land Vehicle Tech", stats["tech"], false));
            skills.Add("paint/draw/sculpt", new Skill("Paint/Draw/Sculpt", stats["tech"], false));
            skills.Add("paramedic", new Skill("Paramedic", stats["tech"], true));
            skills.Add("photography/film", new Skill("Photography/Film", stats["tech"], false));
            skills.Add("pick lock", new Skill("Pick Lock", stats["tech"], false));
            skills.Add("pick pocket", new Skill("Pick Pocket", stats["tech"], false));
            skills.Add("play instrument", new Skill("Play Instrument", stats["tech"], false));
            skills.Add("sea vehicle tech", new Skill("Sea Vehicle Tech", stats["tech"], false));
            skills.Add("weapons tech", new Skill("Weapons Tech", stats["tech"], false));
        }

        /// <summary>
        /// Sets the character's max health
        /// </summary>
        private void SetMaxHealth()
        {
            int will = stats["will"];
            int body = stats["body"];
            if (will + body == 4)
            {
                maxHealth = 20;
            }
            else if (will + body == 5 || will + body == 6)
            {
                maxHealth = 25;
            }
            else if (will + body == 7 || will + body == 8)
            {
                maxHealth = 30;
            }
            else if (will + body == 9 || will + body == 10)
            {
                maxHealth = 35;
            }
            else if (will + body == 11 || will + body == 12)
            {
                maxHealth = 40;
            }
            else if (will + body == 13 || will + body == 14)
            {
                maxHealth = 45;
            }
            else if (will + body == 15 || will + body == 16)
            {
                maxHealth = 50;
            }
            else if (will + body == 17 || will + body == 18)
            {
                maxHealth = 55;
            }
            else if (will + body == 19 || will + body == 20)
            {
                maxHealth = 60;
            }
            else if (will + body == 21 || will + body == 22)
            {
                maxHealth = 65;
            }
            else if (will + body == 23 || will + body == 24)
            {
                maxHealth = 70;
            }
            else if (will + body == 25)
            {
                maxHealth = 75;
            }
        }
    }
}
