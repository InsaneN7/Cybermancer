//Stupes would be proud
namespace Cybermancer
{
    internal class Rockerboy : Role
    {
        public Rockerboy(int rank)
        {
            base.name = "Rockerboy";
            string desc = "The Rockerboy has the Role ability Charismatic Impact. They can influence others by sheer presence of personality. They need not be a musical performer; they can influence others through poetry, art, dance, or simply their physical presence. They could be a rocker—or a cult leader." +
                "\r\n \r\nA Rockerboy can only use their Charismatic Impact Role Ability on Fans." +
                "\r\nAssuming you aren't in combat, you can make people who aren't currently fans into fans (unless they actively dislike you) by rolling Charismatic Impact + 1d10 vs. a DV8 for a Single Person, DV10 for a Small Group of up to 6, or DV12 for a Huge Group." +
                "\r\n \r\nThe GM determines whenever someone you meet is already a Fan." +
                "\r\nWhen a Rockerboy wants to make use of their Charismatic Impact on a fan or group of fans, the GM uses the table below to determine if the favor is something within the powers of their Charismatic Impact given their current Role Ability Rank. If it isn't, the Rockerboy automatically fails. If it is, the group size determines the DV against which the Rockerboy must roll Charismatic Impact + 1d10. If they succeed, the fan or group of fans puts their best effort toward the favor the Rockerboy asked for. If they fail, the Rockerboy can't ask for the same favor again from those fans for a week." +
                "\r\n \r\n▶ Charismatic Impact ◀" +
                "\r\n \r\nVenues You Can Play: The best type of venue your Rockerboy can hope to play under most circumstances." +
                "\r\n \r\nImpact on a Single Fan (DV8): The impact your Rockerboy can have on a single fan by beating a DV8 on their Charismatic Impact Check." +
                "\r\n \r\nImpact on a Small Group of Fans (DV10): The impact your Rockerboy can have on a group of up to six fans by beating a DV10 on their Charismatic Impact Check." +
                "\r\n \r\nImpact on a Huge Group of Fans (DV12): The impact your Rockerboy can have on a large group of fans gathered to see them by beating a DV12 on their Charismatic Impact Check." +
                "\n------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            if(rank <= 2)
            {
                desc += "\nVenues You Can Play: Small local clubs" +
                    "\r\n \r\nImpact on a Single Fan (DV8): Rockerboy can convince fan to do a small favor for the Rockerboy; buy the Rockerboy a drink or meal, give them a lift somewhere." +
                    "\r\n \r\nImpact on a Small Group of Fans (DV10): Rockerboy has a group of up to 6 fans to ask for autographs and other personal totems; fans will stop Rockerboy in streets to befriend them." +
                    "\r\n \r\nImpact on a Huge Group of Fans (DV12): You're kidding, right? You don't have huge groups of fans yet.";
            }
            else if(rank <= 4)
            {
                desc += "\nVenues You Can Play: Well known clubs" +
                    "\r\n \r\nImpact on a Single Fan (DV8): Rockerboy can convince fan to do a major favor for the Rockerboy; go to bed with the Rockerboy, put a good word in for them, etc." +
                    "\r\n \r\nImpact on a Small Group of Fans (DV10): Convince a group of up to 6 fans to regularly hang out with Rockerboy; provide booze, drugs, or other party favors to the Rockerboy." +
                    "\r\n \r\nImpact on a Huge Group of Fans (DV12): Rockerboy has a strong local following; fans buy their recordings and merch.";
            }
            else if(rank <= 6)
            {
                desc += "\nVenues You Can Play: Large, important clubs" +
                    "\r\n \r\nImpact on a Single Fan (DV8): Rockerboy can convince fan to commit a minor crime for Rockerboy; shoplift, help out in a fight." +
                    "\r\n \r\nImpact on a Small Group of Fans (DV10): Convince a group of up to 6 fans to act as the Rockerboy's personal \"posse\"; constantly hang out with them, do Rockerboy favors, and provide things for their personal needs." +
                    "\r\n \r\nImpact on a Huge Group of Fans (DV12): Rockerboy's fans are all over the City, often in nearby cities. They are strongly loyal and will often do major favors for the Rockerboy in exchange for attention.";
            }
            else if(rank <= 8)
            {
                desc += "\nVenues You Can Play: Small concert halls, local video feed" +
                    "\r\n \r\nImpact on a Single Fan (DV8): Fan is willing to risk their life for Rockerboy without question." +
                    "\r\n \r\nImpact on a Small Group of Fans (DV10): Convince a group of up to 6 fans to commit a minor crime for Rockerboy; shoplift, help in a fight." +
                    "\r\n \r\nImpact on a Huge Group of Fans (DV12): The Rockerboy's fans are rabidly loyal. They fight with rival fan groups, support strong fan information networks, will band together to help Rockerboy.";
            }
            else if(rank == 9)
            {
                desc += "\nVenues You Can Play: Large concert halls, national video feed" +
                    "\r\n \r\nImpact on a Single Fan (DV8): Rockerboy can convince fan to commit major crime for Rockerboy; steal expensive item, beat someone up for Rockerboy." +
                    "\r\n \r\nImpact on a Small Group of Fans (DV10): Convince a group of up to 6 fans to commit a major crime for Rockerboy; steal expensive item, beat someone up." +
                    "\r\n \r\nImpact on a Huge Group of Fans (DV12): The Rockerboy's fans are basically a brainwashed, cult-like following; they will riot, destroy property, and even kill for the Rockerboy.";
            }
            else
            {
                desc += "\nVenues You Can Play: Huge stadiums or international video" +
                    "\r\n \r\nImpact on a Single Fan (DV8): Fan is willing to sacrifice self for Rockerboy without question." +
                    "\r\n \r\nImpact on a Small Group of Fans (DV10):Convince a group of up to 6 fans to risk their lives for the Rockerboy; to act as personal protection." +
                    "\r\n \r\nImpact on a Huge Group of Fans (DV12): The Rockerboy's fans are now a worldwide following with strong, cult-like attributes. They will do almost anything for the Rockerboy if asked; they are a private army based on the Rockerboy's charisma.";
            }
            base.description = desc;
            base.rank = rank;
        }
    }
}
