//Class for characters of any type. Shouldn't be a parent whatsoever
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Cybermancer
{
    internal class Character
    {
        // ------ CLASSES ------
        private Dictionary<string, int> stats;
        private Dictionary<string, Skill> skills;
        private string name;
        private string handle;
        private int currentHumanity;
        private int maxHumanity;
        private Dictionary<string, Role> roles;
        private Dictionary<string, Item> gear;
        private int maxHealth;
        private int currentHealth;
        private int headSP;
        private int bodySP;
        private bool subdermal;
        private int subHeadSP;
        private int subBodySP;
        private int ip;
        private int eddies;
        private Random RNGesus;
        private Armor headArmor;
        private Armor bodyArmor;
        private Dictionary<string, Cyberware> chrome;
        private Dictionary<string, int> chromeSlots;

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
        /// <param name="luck">their luck score</param>
        /// <param name="move">their movement score</param>
        /// <param name="body">their body score</param>
        /// <param name="emp">their empathy score</param>
        public Character(string name, string handle, int smart, int reflex,
            int dex, int tech, int cool, int will, int luck, int move, int body, int emp)
        {
            this.name = name;
            this.handle = handle;
            headSP = 0;
            bodySP = 0;
            headArmor = null!;
            bodyArmor = null!;
            subdermal = false;
            subHeadSP = 0;
            subBodySP = 0;
            ip = 0;
            eddies = 0;
            currentHumanity = emp * 10;
            maxHumanity = currentHumanity;
            stats = new Dictionary<string, int>(9);
            roles = new Dictionary<string, Role>(10);
            skills = new Dictionary<string, Skill>(60);
            gear = new Dictionary<string, Item>();
            chrome = new Dictionary<string, Cyberware>();
            chromeSlots = new Dictionary<string, int>(8);
            RNGesus = new Random();
            stats.Add("int", smart);
            stats.Add("ref", reflex);
            stats.Add("dex", dex);
            stats.Add("tech", tech);
            stats.Add("cool", cool);
            stats.Add("will", will);
            stats.Add("luck", luck);
            stats.Add("move", move);
            stats.Add("body", body);
            stats.Add("emp", emp);
            SetupChromeSlots();
            SkillsSetup();
            SetMaxHealth();
            currentHealth = maxHealth;
        }

        /// <summary>
        /// Quick constructor for a character, with all stats as 5
        /// </summary>
        /// <param name="name">their name</param>
        /// <param name="handle">their handle</param>
        public Character(string name, string handle) : this(name, handle, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5)
        {
            //NOTHING GOES HERE
        }

        // ------ METHODS ------

        /// <summary>
        /// Prints all the skills for the character
        /// </summary>
        public void PrintSkills()
        {
            foreach(Skill skill in skills.Values)
            {
                Console.WriteLine(skill);
            }
        }

        /// <summary>
        /// Sets a skill to a new given value
        /// </summary>
        /// <param name="skill">The name of the skill to set</param>
        /// <param name="score">The score of the skill</param>
        public void SetSkill(string skill, int score)
        {
            skills[skill].score = score;
        }

        /// <summary>
        /// Searches for a skill in your skill list. Also sanitizes the given skilln to make compatible with dictionary
        /// </summary>
        /// <param name="toFind">The skill you want to find</param>
        /// <returns>The skill if it is found</returns>
        /// <exception cref="Exception">Occurs if the skill is not in the dictionary</exception>
        public Skill SearchSkill(string toFind)
        {
            toFind.Trim().ToLower();
            if (skills.ContainsKey(toFind))
            {
                return skills[toFind];
            }
            else
            {
                throw new Exception("That is not a skill. Please check your spelling.");
            }
        }

        /// <summary>
        /// Adds a role to the character
        /// </summary>
        /// <param name="role">The role to add</param>
        /// <exception cref="Exception">Throws exception if the player doesn't have enough IP</exception>
        public void AddRole(string role)
        {
            role.Trim().ToLower();
            if (roles.Count == 0)
            {
                if(role == "solo")
                {
                    roles.Add("solo", new Solo(4));
                }
                else if(role == "rockerboy")
                {
                    roles.Add("rockerboy", new Rockerboy(4));
                }
                else if(role == "tech")
                {
                    roles.Add("tech", new Tech(4));
                }
            }
            else if (roles.ContainsKey(role)) {
                if (ip < 60 * (roles[role].rank + 1))
                {
                    throw new Exception($"Not enough IP for purchase. You need " +
                        $"{60 * (roles[role].rank + 1)}IP and have {ip}IP");
                }
                else
                {
                    ip -= 60 * (roles[role].rank + 1);
                    roles[role].rank += 1;
                }
            }
            else
            {
                if (ip < 60)
                {
                    throw new Exception($"Not enough IP for purchase. You need 60IP and have {ip}IP");
                }
                else
                {
                    if(role == "solo")
                    {
                        roles.Add("solo", new Solo(1));
                        ip -= 60;
                    }
                    else if (role == "rockerboy")
                    {
                        roles.Add("rockerboy", new Rockerboy(1));
                        ip -= 60;
                    }
                    else if (role == "tech")
                    {
                        roles.Add("tech", new Tech(1));
                        ip -= 60;
                    }
                }
            }
        }

        /// <summary>
        /// Lets the player buy a skill increase
        /// </summary>
        /// <param name="skill">The skill to increase</param>
        /// <exception cref="Exception"></exception>
        public void BuySkill(string skill)
        {
            skill.Trim().ToLower();
            if(skills.ContainsKey(skill) == false)
            {
                throw new Exception("That is not a skill. Please check your spelling");
            }
            int difficult = 1;
            if (skills[skill].timesTwo == true)
            {
                difficult = 2;
            }
            else if (skills[skill].level == 10)
            {
                throw new Exception($"{skill} is already at level 10");
            }
            else if(ip < 20 * (skills[skill].level + 1) * difficult)
            {
                throw new Exception($"Not enough IP for purchase. You need " +
                    $"{20 * (skills[skill].level + 1) * difficult}IP and have {ip}IP");
            }
            else
            {
                ip -= 20 * (skills[skill].level + 1) * difficult;
                skills[skill].level += 1;
            }
        }

        /// <summary>
        /// Allows the player to take damage
        /// </summary>
        /// <param name="damage">The amount of damage taken</param>
        /// <param name="location">Where the damage hit</param>
        /// <param name="range">Melee or range</param>
        /// <exception cref="Exception"></exception>
        public void TakeDamage(int damage, string location, string range, string ammoType)
        {
            location.Trim().ToLower();
            range.Trim().ToLower();
            ammoType.Trim().ToLower();
            
            //layer 1: check whats being hit
            //layer 2: check whats taking the hit
            //layer 3: check range
            //layer 4: do damage and lower SP
            if(location == "head")
            {
                if(headSP > 0)
                {
                    if(range == "melee")
                    {
                        if(damage > headSP / 2)
                        {
                            if (roles.ContainsKey("solo"))
                            {
                                damage -= ((Solo)roles["solo"]).deflection;
                            }
                            currentHealth -= damage - (headSP / 2);
                            headSP -= 1;
                        }
                    }
                    else if(range == "range")
                    {
                        if (damage > headSP)
                        {
                            if (roles.ContainsKey("solo"))
                            {
                                damage -= ((Solo)roles["solo"]).deflection;
                            }
                            currentHealth -= damage - headSP;
                            if (ammoType == "armor-piercing")
                            {
                                headSP -= 2;
                            }
                            else{
                                headSP -= 1;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Range must be \"melee\" or \"range\"");
                    }
                }
                else if(subHeadSP > 0)
                {
                    if (range == "melee")
                    {
                        if (roles.ContainsKey("solo"))
                        {
                            damage -= ((Solo)roles["solo"]).deflection;
                        }
                        if (damage > subHeadSP / 2)
                        {
                            currentHealth -= damage - (subHeadSP / 2);
                            subHeadSP -= 1;
                        }
                    }
                    else if (range == "range")
                    {
                        if (damage > subHeadSP)
                        {
                            if (roles.ContainsKey("solo"))
                            {
                                damage -= ((Solo)roles["solo"]).deflection;
                            }
                            currentHealth -= damage - subHeadSP;
                            if (ammoType == "armor-piercing")
                            {
                                subHeadSP -= 2;
                            }
                            else
                            {
                                subHeadSP -= 1;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Range must be \"melee\" or \"range\"");
                    }
                }
                else
                {
                    if (roles.ContainsKey("solo"))
                    {
                        damage -= ((Solo)roles["solo"]).deflection;
                    }
                    currentHealth -= damage;
                }
            }
            else if(location == "body")
            {
                if (bodySP > 0)
                {
                    if (range == "melee")
                    {
                        if (damage > bodySP / 2)
                        {
                            currentHealth -= damage - (bodySP / 2);
                            bodySP -= 1;
                        }
                    }
                    else if (range == "range")
                    {
                        if (damage > bodySP)
                        {
                            currentHealth -= damage - bodySP;
                            if (ammoType == "armor-piercing")
                            {
                                bodySP -= 2;
                            }
                            else
                            {
                                bodySP -= 1;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Range must be \"melee\" or \"range\"");
                    }
                }
                else if (subBodySP > 0)
                {
                    if (range == "melee")
                    {
                        if (damage > subBodySP / 2)
                        {
                            currentHealth -= damage - (subBodySP / 2);
                            subBodySP -= 1;
                        }
                    }
                    else if (range == "range")
                    {
                        if (damage > subBodySP)
                        {
                            currentHealth -= damage - subBodySP;
                            if (ammoType == "armor-piercing")
                            {
                                subBodySP -= 2;
                            }
                            else
                            {
                                subBodySP -= 1;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Range must be \"melee\" or \"range\"");
                    }
                }
                else
                {
                    currentHealth -= damage;
                }
            }
            else
            {
                throw new Exception("Target location invalid");
            }

            Console.WriteLine($"Health: {currentHealth}/{maxHealth}" +
                $"\nHead SP: {headSP}" +
                $"\nBody SP: {bodySP}");
            if (subdermal)
            {
                Console.WriteLine($"Subdermal Head SP: {subHeadSP}" +
                    $"\nSubdermal Body SP: {subBodySP}");
            }
        }

        /// <summary>
        /// Adds IP to a character
        /// </summary>
        /// <param name="toAdd">The amount of IP to add</param>
        public void AddIP(int toAdd)
        {
            ip += toAdd;
        }

        /// <summary>
        /// Equips armor to the character
        /// </summary>
        /// <param name="name">The name of the armor to equip</param>
        public void EquipArmor(string name)
        {
            if (gear.ContainsKey(name) == false)
            {
                throw new Exception("That ain't in your inventory mate");
            }
            Armor armor = (Armor)gear[name];
            if(armor.location == "head")
            {
                headArmor = armor;
                headSP = headArmor.SP;
            }
            else if (armor.location == "body")
            {
                bodyArmor = armor;
                bodySP = bodyArmor.SP;
            }
            stats["move"] -= armor.penalty;
            stats["ref"] -= armor.penalty;
            stats["dex"] -= armor.penalty;
        }

        /// <summary>
        /// Unequips armor on the character
        /// </summary>
        /// <param name="name">The armor's name</param>
        public void UnequipArmor(string name)
        {
            if (gear.ContainsKey(name) == false)
            {
                throw new Exception("That ain't in your inventory mate");
            }
            Armor armor = (Armor)gear[name];
            stats["move"] += armor.penalty;
            stats["ref"] += armor.penalty;
            stats["dex"] += armor.penalty;
            if (armor.location == "head")
            {
                headArmor = null!;
                headSP = 0;
            }
            else if (armor.location == "body")
            {
                bodyArmor = null!;
                bodySP = 0;
            }
        }

        /// <summary>
        /// Adds an item to the inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            gear.Add(item.name, item);
        }

        /// <summary>
        /// Allows you to (attempt) to buy an item
        /// </summary>
        /// <param name="item">The item to buy</param>
        /// <exception cref="Exception">Yer broke choom, sorry</exception>
        public void BuyItem(Item item)
        {
            if(eddies < item.cost)
            {
                throw new Exception("Not enough eddies");
            }
            eddies -= item.cost;
            gear.Add(item.name, item);
        }

        /// <summary>
        /// Attacks with a ranged weapon
        /// </summary>
        /// <param name="weapon">What weapon to use</param>
        /// <param name="range">The distance in meters</param>
        /// <param name="additions">what additional is added to the roll</param>
        /// <param name="penalties">what additional is subtracted from the roll</param>
        /// <param name="auto">Are you auto fireing</param>
        public void UseRangedWeapon(RangedWeapon weapon, int range, int additions, int penalties, bool auto)
        {
            for(int i = 0; i < weapon.rof; i++)
            {
                int roll;
                if(auto == false)
                {
                    roll = skills[weapon.attackSkill].RollSkill(Roll(), additions, penalties);
                    weapon.currentAmmo -= 1;
                }
                else
                {
                    roll = skills["autofire"].RollSkill(Roll(), additions, penalties);
                    weapon.currentAmmo -= 4;
                }
                if (weapon.type == "pistol")
                {
                    ((Pistol)weapon).Attack(range, 0, roll);
                }
                else if (weapon.type == "assault rifle")
                {
                    if (auto == true)
                    {
                        ((AssaultRifle)weapon).AutoAttack(range, 0, roll);
                    }
                    else
                    {
                        ((AssaultRifle)weapon).Attack(range, 0, roll);
                    }
                }
                else if (weapon.type == "smg")
                {
                    if (auto == true)
                    {
                        ((SMG)weapon).AutoAttack(range, 0, roll);
                    }
                    else
                    {
                        ((SMG)weapon).Attack(range, 0, roll);
                    }
                }
                else if (weapon.type == "shotgun")
                {
                    ((Shotgun)weapon).Attack(range, 0, roll);
                }
                else if (weapon.type == "bow")
                {
                    ((Bow)weapon).Attack(range, 0, roll);
                }
                else if (weapon.type == "grenade launcher")
                {
                    ((GrenadeLauncher)weapon).Attack(range, 0, roll);
                }
                else if (weapon.type == "sniper rifle")
                {
                    ((SniperRifle)weapon).Attack(range, 0, roll);
                }
                else if (weapon.type == "rocket launcher")
                {
                    ((RocketLauncher)weapon).Attack(range, 0, roll);
                }
            }
        }

        /// <summary>
        /// Attacks with a melee weapon
        /// </summary>
        /// <param name="weapon">the weapon to use</param>
        /// <param name="additions">any external buffs</param>
        /// <param name="penalties">any external penalties</param>
        /// <param name="dodgeroll">the enemy's dodge roll</param>
        public void UseMeleeWeapon(MeleeWeapon weapon, int additions, int penalties, int dodgeroll)
        {
            int roll;
            for (int i = 0; i < weapon.rof; i++)
            {
                roll = skills[weapon.attackSkill].RollSkill(Roll(), additions, penalties);
                if(roll > dodgeroll)
                {
                    weapon.Attack(roll, dodgeroll);
                }
            }
        }

        /// <summary>
        /// Adds cyberware to character
        /// </summary>
        /// <param name="metal">The cyberware to install</param>
        /// <exception cref="Exception"></exception>
        public void EquipCyberware(Cyberware metal)
        {
            if (gear.ContainsValue(metal) == false)
            {
                throw new Exception("You don't own that choomba");
            }
            if (chromeSlots[metal.location] < metal.takesSlots)
            {
                throw new Exception("Not enough installation slots");
            }
            if(metal.location == "borgware" && metal.humanityLoss != 0)
            {
                maxHumanity -= 4;
            }
            else if(metal.humanityLoss != 0)
            {
                maxHumanity -= 2;
            }
            if (metal.meleeWeapon != null)
            {
                gear.Add(metal.meleeWeapon.name, metal.meleeWeapon);
            }
            else if (metal.rangedWeapon != null)
            {
                gear.Add(metal.rangedWeapon.name, metal.rangedWeapon);
            }
            else if (metal.armor != null)
            {
                subdermal = true;
                subBodySP = metal.armor.SP;
                subHeadSP = metal.armor.SP;
            }
            chrome.Add(metal.location, metal);
            currentHumanity -= metal.humanityLoss;
            stats["emp"] = currentHumanity / 10;
        }

        /// <summary>
        /// Unequips cyberware
        /// </summary>
        /// <param name="name">The name of the cyberware</param>
        /// <exception cref="Exception"></exception>
        public void UnequipCyberware(string name)
        {
            if (gear.ContainsKey(name) == false)
            {
                throw new Exception("That ain't in your inventory mate");
            }
            Cyberware metal = (Cyberware)gear[name];
            if (metal.rangedWeapon != null)
            {
                gear.Remove(metal.rangedWeapon.name);
            }
            else if (metal.meleeWeapon != null)
            {
                gear.Remove(metal.meleeWeapon.name);
            }
            else if (metal.armor != null)
            {
                subdermal = false;
                subBodySP = 0;
                subHeadSP = 0;
            }
            if (metal.location == "borgware" && metal.humanityLoss != 0)
            {
                maxHumanity += 4;
            }
            else if (metal.humanityLoss != 0)
            {
                maxHumanity += 2;
            }
            currentHumanity += metal.humanityLoss;
            stats["emp"] = currentHumanity / 10;
        }

        /// <summary>
        /// Creates a short list of combat related info
        /// </summary>
        /// <returns>The list</returns>
        public string QuickStats()
        {
            string output = $"{name}" +
                $"\nHealth: {currentHealth}/{maxHealth}" +
                $"\nHead SP: {headSP}" +
                $"\nBody SP: {bodySP}";
            if (subdermal)
            {
                output +=
                $"\nSubdermal Head SP: {subHeadSP}" +
                $"\nSubdermal Body SP: {subBodySP}";
            }
            foreach(Item item in gear.Values)
            {
                if(item.type == "ranged weapon")
                {
                    output += $"\n{((RangedWeapon)item).QuickStats()}";
                }
                else if (item.type == "melee weapon")
                {
                    output += $"\n{((MeleeWeapon)item).QuickStats()}";
                }
            }
            return output;
        }

        /// <summary>
        /// Converts the character to a describing string
        /// </summary>
        /// <returns>The string of the associated character</returns>
        public override string ToString()
        {
            string output = 
                $"Name: {name}" +
                $"\nHandle: {handle}" +
                $"\nHealth: {currentHealth}/{maxHealth}" +
                $"\nHumanity: {currentHumanity}/{maxHumanity}" +
                $"\nHead SP: {headSP}" +
                $"\nBody SP: {bodySP}";
            if (subdermal)
            {
                output +=
                $"\nSubdermal Head SP: {subHeadSP}" +
                $"\nSubdermal Body SP: {subBodySP}";
            }
                output += 
                $"\nInt:  {stats["int"]}" +
                $"\nRef:  {stats["ref"]}" +
                $"\nTech: {stats["tech"]}" +
                $"\nCool: {stats["cool"]}" +
                $"\nWill: {stats["will"]}" +
                $"\nLuck: {stats["luck"]}" +
                $"\nMove: {stats["move"]}" +
                $"\nBody: {stats["body"]}" +
                $"\nEmp:  {stats["emp"]}" +
                $"\nIP: {ip}" +
                $"\nRoles: ";
            foreach(Role role in roles.Values)
            {
                output = output + $"\n{role.name}: {role.rank}";
            }

            return output;
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

        /// <summary>
        /// Rolls dice including fumbles and great successes. Also keeps track of Solo fumble recovery
        /// </summary>
        /// <returns>The roll</returns>
        private int Roll()
        {
            int output = RNGesus.Next(1, 11);
            Solo solo;
            if (roles.ContainsKey("solo"))
            {
                solo = (Solo)roles["solo"];
            }
            else
            {
                solo = null!;
            }
            if(output == 1 && (solo == null! || (solo != null && solo.fumble == false)))
            {
                output -= RNGesus.Next(1, 11);
            }
            else if(output == 10)
            {
                output += RNGesus.Next(1, 11);
            }
            return output;
        }
    
        /// <summary>
        /// Sets up the chrome slots
        /// </summary>
        private void SetupChromeSlots()
        {
            chromeSlots.Add("neuralware", 0);
            chromeSlots.Add("cyberoptics", 0);
            chromeSlots.Add("cyberaudio", 0);
            chromeSlots.Add("cyberlimbs", 0);
            chromeSlots.Add("internal", 7);
            chromeSlots.Add("external", 7);
            chromeSlots.Add("fashionware", 7);
            chromeSlots.Add("borgware", int.MaxValue);
        }
    }
}
