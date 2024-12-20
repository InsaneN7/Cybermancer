//We work, to earn the right to work
namespace Cybermancer
{
    class Tech : Role
    {
        internal int fieldTech;
        internal int fabricate;
        internal int upgrade;
        internal int invent;

        public Tech(int rank)
        {
            base.name = "Tech";
            base.description = "Maker:" +
                "\nA Tech can fix, improve, modify, make, and invent new items using Maker, their Role Ability. Whenever a Tech increases their Maker Rank by 1, they gain 1 Rank in two different Maker Specialties (Field Expertise, Upgrade Expertise, Fabrication Expertise, or Invention Expertise) of their choice." +
                "\r\n \r\n▶ Field Expertise" +
                "\r\n \r\nYour familiarity with technology in the field makes you a valuable asset on any job, especially when something breaks down at just the wrong moment. Add your Rank in this Specialty to any Basic Tech, Cybertech, Electronics/Security Tech, Weaponstech, Land, Sea, or Air Vehicle Tech Skill Check you make for any Non-Maker Specialty purpose." +
                "\r\n \r\nAdditionally, as long as you have at least 1 Rank in this specialty, instead of attempting a lengthy full repair you can elect to instead temporarily repair your target (at the same DV of a typical repair for the item) to perfect condition as an Action (with full SP and HP, if applicable). You add your Rank in Field Expertise to this Check. This jury-rigging holds for 10 minutes for each Rank you have in this specialty, after which the item returns to the state it was in before you jury-rigged it, except that it cannot be jury-rigged again until it has been fully repaired." +
                "\r\n \r\n▶ Upgrade Expertise" +
                "\r\n \r\nImproves an item in one of the following ways. An item can only benefit from 1 upgrade granted by this specialty. • Lower the Humanity Loss of non-borgware cyberware by 1d6 if its typical humanity loss would be 2d6 or greater. • Increase the number slots of a type an item already has for options, attachments, Programs/Hardware, etc. by one." +
                "\r\n \r\n • Simplify the item, halving the time it takes to make any future full repair to the item. • Grant a typically non-concealable onehanded weapon the ability to be concealed. • Increase an Average Quality Weapon to an Excellent Quality Weapon. • Grant a weapon Attachment Slot to an Exotic Weapon." +
                "\r\n • Allow an Exotic Weapon to fire one variety of Non-Basic Ammunition of its ammunition type." +
                "\r\n • Increase an item's SP by 1, but only if it had any to begin with. • Upgrade a vehicle with an upgrade that only requires a Nomad Role Ability Rank of 1. • Install an upgrade invented by the Tech using Invention Expertise. Requires additional materials equal to the Price Category assigned to the item by the GM when it was invented." +
                "\r\n \r\nTo upgrade an item, you roll TECH + the TECH Skill that the item is typically repaired with + your Rank in this specialty + 1d10. The Tech must purchase materials of the same price category of the item being upgraded, which installing the upgrade consumes. The DV you roll against and the time it takes to install the upgrade is based on the price category of the item you are upgrading." +
                "\r\n \r\nOn a failed Check, halfway through the upgrade, you realize that you'll have to start again from scratch. The materials purchased to make the upgrade and the item to be upgraded are both uninjured." +
                "\r\n \r\n▶ Fabrication Expertise" +
                "\r\n \r\nFabricate an existing item or one invented by the Tech using Invention Expertise from materials. To make an item, you roll TECH + the TECH Skill that the item is typically repaired with + your Rank in this specialty + 1d10. The Tech must purchase materials of one price category lower than the price category of the item being fabricated. (Except for Super Luxury items, which require materials equal to half their Price to fabricate.)" +
                "\r\n \r\nThe DV you roll against and the time it takes to make the item is based on the price category of the item you are making. On a failed Check, halfway through the fabrication process, you realize that you'll have to start again from scratch. The materials purchased to make the item are uninjured." +
                "\r\n \r\n▶ Invention Expertise" +
                "\r\n \r\nInvent an upgrade to an existing item or invent an entirely new item. To invent an item/upgrade, you'll need to describe to your GM the desired function of your item/upgrade, as precisely as you can in the language of already existing technologies in the setting, making sure to include the mechanism by which your invention might accomplish its function. It is suggested that you draw up a simple schematic for illustrative purposes. Your GM and fellow Players will certainly appreciate it." +
                "\r\n \r\nIf your GM is satisfied with your explanation and is okay with it in their game, they will write how the proposed invention would operate rules-wise, being careful not to create an imbalanced item. The upgrades presented earlier in Upgrade Expertise are a good guideline for balanced Tech upgrades. Based on the item or upgrade's value if it were to be sold on the open market, the GM will set the Price Category of the item as close to other items/upgrades of a similar \"power level\" as possible, although the lowest category they can select is Expensive." +
                "\r\n \r\nThe time it will take to invent the item/upgrade and the DV your Character has to beat with their TECH + the TECH Skill associated with repairing the invention or the item the invention is meant to upgrade + your Rank in this specialty + 1d10." +
                "\r\n \r\nThe DV you roll against and the time it takes to make the item is based on the price category of the item you are making. On a failed Check, you realize halfway through your process that you need to go back to the drawing board." +
                "\r\n \r\nOnce invented, you (or another Tech who you show the blueprints to) can make your invented item/ upgrade real using Fabrication or Upgrade Expertise! It's worth mentioning that nobody will give your invention a second thought before you have a working prototype. Of course, that's when they'll try to steal it. Don't bother with the courts." +
                "\r\n \r\nMore than any ability in the game, this ability can result in game imbalance. Your GM might need to retroactively change the way your invention operates rules-wise (or, in extreme circumstances, even replace it with another invention of an equal price category that you collaborate on together) several times before you find a version that works well at your table and doesn't negatively impact game balance.";
            base.rank = rank;
            fieldTech = 0;
            fabricate = 0;
            upgrade = 0;
            invent = 0;
        }

        /// <summary>
        /// Sets all the specialty scores
        /// </summary>
        /// <param name="field">Fieldtech score</param>
        /// <param name="fab">Fabrication score</param>
        /// <param name="up">Upgrade score</param>
        /// <param name="inv">Invent score</param>
        /// <exception cref="Exception"></exception>
        public void SetSpecialties(int field, int fab, int up, int inv)
        {
            if(field + fab + up + inv > 2 * rank)
            {
                throw new Exception("Not enough ranks");
            }
            fieldTech = field;
            fabricate = fab;
            upgrade = up;
            invent = inv;
        }

        /// <summary>
        /// Gets the time and cost of making something with a given price
        /// </summary>
        /// <param name="price">The price it's worth</param>
        /// <returns>The time and cost it'll take</returns>
        public string GetTimeCost(int price)
        {
            if(price < 50)
            {
                return "Materials: 1eb, DV: 9, Hours: 1";
            }
            else if (price < 100)
            {
                return "Materials: 10eb, DV: 13, Hours: 6";
            }
            else if (price < 500)
            {
                return "Materials: 50eb, DV: 17, Hours: 16";
            }
            else if (price < 1000)
            {
                return "Materials: 100eb, DV: 21, Hours: 112";
            }
            else if (price < 5000)
            {
                return "Materials: 500eb, DV: 24, Hours: 224";
            }
            else if (price < 10000)
            {
                return "Materials: 1000eb, DV: 29, Hours: 480";
            }
            else
            {
                return $"Materials: {price / 2}, DV: 29, Hours: {480 * (price/10000)}";
            }

        }
    }
}
