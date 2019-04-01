using System;
using System.Collections.Generic;
using System.Windows;

namespace GURPS_Character_Creator.Models
{
    public class AdvantageModel
    {
        public string Name { get; private set; }
        public int PtCostPerLvl { get; private set; }
        public string CanLevel { get; private set; }
        public string Description { get; private set; }

        public AdvantageModel(string name, int point, string canLevel, string description)
        {
            Name = name;
            PtCostPerLvl = point;
            CanLevel = canLevel;
            Description = description;
        }
    }

    public class AdvantageList
    {
        public Dictionary<string, AdvantageModel> AdvantageDict { get; set; }
        private Dictionary<string, string> Description;

        public AdvantageList()
        {
            Description = new Dictionary<string, string>();
            LoadDescriptions();

            AdvantageDict = new Dictionary<string, AdvantageModel>();
            LoadAdvantages();
        }

        private void LoadAdvantages() {
            AdvantageDict.Add("Acute Senses (Hearing)", new AdvantageModel("Acute Senses (Hearing)", 2, "Has Rank", Description["Acute Senses (Hearing)"]));
            AdvantageDict.Add("Acute Senses (Taste and Smell)", new AdvantageModel("Acute Senses (Taste and Smell)", 2, "Has Rank", Description["Acute Senses (Taste and Smell)"]));
            AdvantageDict.Add("Acute Senses (Touch)", new AdvantageModel("Acute Senses (Touch)", 2, "Has Rank", Description["Acute Senses (Touch)"]));
            AdvantageDict.Add("Acute Senses (Vision)", new AdvantageModel("Acute Senses (Vision)", 2, "Has Rank", Description["Acute Senses (Vision)"]));
            AdvantageDict.Add("Ambidexterity", new AdvantageModel("Ambidexterity", 5, "", Description["Ambidexterity"]));
            AdvantageDict.Add("Animal Empathy", new AdvantageModel("Animal Empathy", 5, "", Description["Animal Empathy"]));
            AdvantageDict.Add("Catfall", new AdvantageModel("Catfall", 10, "", Description["Catfall"]));
            AdvantageDict.Add("Combat Reflexes", new AdvantageModel("Combat Reflexes", 15, "", Description["Combat Reflexes"]));
            AdvantageDict.Add("Danger Sense", new AdvantageModel("Danger Sense", 15, "", Description["Danger Sense"]));
            AdvantageDict.Add("Daredevil", new AdvantageModel("Daredevil", 15, "", Description["Daredevil"]));
            AdvantageDict.Add("Empathy", new AdvantageModel("Empathy", 15, "", Description["Empathy"]));
            AdvantageDict.Add("Enhanced Defenses (Block)", new AdvantageModel("Enhanced Defenses (Block)", 5, "", Description["Enhanced Defenses (Block)"]));
            AdvantageDict.Add("Ehhanced Defenses (Dodge)", new AdvantageModel("Enhanced Defenses (Dodge)", 15, "", Description["Ehhanced Defenses (Dodge)"]));
            AdvantageDict.Add("Enhanced Defenses (Parry) (All Weapons)", new AdvantageModel("Enhanced Defenses (Parry) (All)", 10, "", Description["Enhanced Defenses (Parry) (All Weapons)"]));
            AdvantageDict.Add("Enhanced Defenses (Parry) (Barehands)", new AdvantageModel("Enhanced Defenses (Parry) (Barehands)", 5, "", Description["Enhanced Defenses (Parry) (Barehands)"]));
            AdvantageDict.Add("Enhanced Defenses (Parry) (Single Weapon of Choice Only)", new AdvantageModel("Enhanced Defenses (Parry) (Single)", 5, "", Description["Enhanced Defenses (Parry) (Single Weapon of Choice Only)"]));
            AdvantageDict.Add("Fearlessness", new AdvantageModel("Fearlessness", 2, "Has Rank", Description["Fearlessness"]));
            AdvantageDict.Add("Flexibility (Basic)", new AdvantageModel("Flexibility (Basic)", 5, "", Description["Flexibility (Basic)"]));
            AdvantageDict.Add("Flexibility (Double-Jointed)", new AdvantageModel("Flexibility (Double-Jointed)", 15, "", Description["Flexibility (Double-Jointed)"]));
            AdvantageDict.Add("Hard to Kill", new AdvantageModel("Hard to Kill", 2, "Has Rank", Description["Hard to Kill"]));
            AdvantageDict.Add("High Pain Threshold", new AdvantageModel("High Pain Threshold", 10, "", Description["High Pain Threshold"]));
            AdvantageDict.Add("Jumper", new AdvantageModel("Jumper", 100, "", Description["Jumper"]));
            AdvantageDict.Add("Language Talent", new AdvantageModel("Language Talent", 10, "", Description["Language Talent"]));
            AdvantageDict.Add("Luck (Basic)", new AdvantageModel("Luck (Basic)", 15, "", Description["Luck (Basic)"]));
            AdvantageDict.Add("Luck (Extraordinary)", new AdvantageModel("Luck (Extraordinary)", 30, "", Description["Luck (Extraordinary)"]));
            AdvantageDict.Add("Luck (Ridiculous)", new AdvantageModel("Luck (Ridiculous)", 60, "", Description["Luck (Ridiculous)"]));
            AdvantageDict.Add("Night Vision", new AdvantageModel("Night Vision", 1, "Has Rank", Description["Night Vision"]));
            AdvantageDict.Add("Perfect Balance", new AdvantageModel("Perfect Balance", 15, "", Description["Perfect Balance"]));
            AdvantageDict.Add("Resistant (Poison)", new AdvantageModel("Resistant (Poison)", 5, "", Description["Resistant (Poison)"]));
            AdvantageDict.Add("Resistant (Disease)", new AdvantageModel("Resistant (Disease)", 5, "", Description["Resistant (Disease)"]));
            AdvantageDict.Add("Talent (Artificer)", new AdvantageModel("Talent (Artificer)", 10, "Has Rank", Description["Talent (Artificer)"]));
            AdvantageDict.Add("Talent (Outdoorsman)", new AdvantageModel("Talent (Outdoorsman)", 10, "Has Rank", Description["Talent (Outdoorsman)"]));
            AdvantageDict.Add("Talent (Smooth Operator)", new AdvantageModel("Talent (Smooth Operator)", 15, "Has Rank", Description["Talent (Smooth Operator)"]));
        }

        private void LoadDescriptions()
        {
            Description.Add("Acute Senses (Hearing)", "You have superior senses. Each Acute Sense is a separate advantage that gives +1 per level to all Sense rolls (p. 24) you make – or the GM makes for you – using that one sense.");
            Description.Add("Acute Senses (Taste and Smell)", "You have superior senses. Each Acute Sense is a separate advantage that gives +1 per level to all Sense rolls (p. 24) you make – or the GM makes for you – using that one sense.");
            Description.Add("Acute Senses (Touch)", "You have superior senses. Each Acute Sense is a separate advantage that gives +1 per level to all Sense rolls (p. 24) you make – or the GM makes for you – using that one sense.");
            Description.Add("Acute Senses (Vision)", "You have superior senses. Each Acute Sense is a separate advantage that gives +1 per level to all Sense rolls (p. 24) you make – or the GM makes for you – using that one sense.");
            Description.Add("Ambidexterity", "You can fight or otherwise act equally well with either hand, and never suffer the -4 DX penalty for using the “off” hand (see p. 5). Should some accident befall one of your arms or hands, assume it is the left one.");
            Description.Add("Animal Empathy", "You are unusually talented at reading the motivations of animals. When you meet an animal, the GM rolls against your IQ and tells you what you “feel.” This reveals the beast’s emotional state – friendly, frightened, hostile, hungry, etc. – and whether it is under supernatural control. You may also use your Influence skills (see p. 15) on animals just as you would on sapient beings, which usually ensures a positive reaction.");
            Description.Add("Catfall", "You subtract five yards from a fall automatically (treat this as an automatic Acrobatics success – don’t check again for it). In addition, a successful DX roll halves damage from any fall (see p. 32). To enjoy these benefits, your limbs must be unbound and your body free to twist as you fall.");
            Description.Add("Combat Reflexes", "You have extraordinary reactions, and are rarely surprised for more than a moment. You get +1 to all active defense rolls (see Defending, p. 28) and +2 to Fright Checks (see Fright Checks, p. 24). You never “freeze” in a surprise situation, and get +6 on all IQ rolls to wake up, or to recover from surprise or mental “stun.”");
            Description.Add("Danger Sense", "You can’t depend on it, but sometimes you get this prickly feeling right at the back of your neck, and you know something’s wrong . . .The GM rolls once against your Perception, secretly, in any situation involving an ambush, impending disaster, or similar hazard. On a success, you get enough of a warning that you can take action. A roll of 3 or 4 means you get a little detail as to the nature of the danger.");
            Description.Add("Daredevil", "Fortune seems to smile on you when you take risks! Any time you take an unnecessary risk (in the GM’s opinion), you get a +1 to all skill rolls. Furthermore, you may reroll any critical failure that occurs during such high-risk behavior.");
            Description.Add("Empathy", "You have a “feeling” for people. When you first meet someone – or are reunited after an absence – you may ask the GM to roll against your IQ. He will tell you what you “feel” about that person. On a failed IQ roll, he will lie! This talent is excellent for spotting imposters, possession, etc., and for determining the true loyalties of NPCs.");
            Description.Add("Enhanced Defenses (Block)", "You have +1 to your Block score with Shield skill.");
            Description.Add("Ehhanced Defenses (Dodge)", "You have +1 to your Dodge score.");
            Description.Add("Enhanced Defenses (Parry) (All Weapons)", "You have +1 to your Parry score.");
            Description.Add("Enhanced Defenses (Parry) (Barehands)", "You have +1 to your Parry score.");
            Description.Add("Enhanced Defenses (Parry) (Single Weapon of Choice Only)", "You have +1 to your Parry score.");
            Description.Add("Fearlessness", "You are difficult to frighten or intimidate! Add your level of Fearlessness to your Will whenever you make a Fright Check or must resist the Intimidation skill (p. 15) or a supernatural power that induces fear. You also subtract your Fearlessness level from all Intimidation rolls made against you.");
            Description.Add("Flexibility (Basic)", "You get +3 on Climbing rolls; on Escape rolls to get free of ropes, handcuffs, and similar restraints. You may ignore up to -3 in penalties for working in close quarters (including many Explosives and Mechanic rolls).");
            Description.Add("Flexibility (Double-Jointed)", "(Including Basic) You cannot stretch or squeeze yourself abnormally, but any part of your body may bend any way. You get +5 on Climbing, Escape rolls, and on attempts to break free. You may ignore up to -5 in penalties for close quarters.");
            Description.Add("Hard to Kill", "You are incredibly difficult to kill. Each level of Hard to Kill gives +1 to HT rolls made for survival at -HP or below, and on any HT roll where failure means instant death (due to heart failure, poison, etc.). If this bonus makes the difference between success and failure, you collapse, apparently dead (or disabled), but come to in the usual amount of time – see Recovering from Unconsciousness (p. 30).");
            Description.Add("High Pain Threshold", "You are as susceptible to injury as anyone else, but you don’t feel it as much. You never suffer a shock penalty when you are injured. In addition, you get +3 on all HT rolls to avoid knockdown and stunning – and if you are tortured physically, you get +3 to resist. The GM may let you roll at Will+3 to ignore pain in other situations.");
            Description.Add("Jumper", "You can travel through time or to parallel worlds (sometimes known as “timelines”) merely by willing the “jump.” Decide whether you are a time-jumper or a worldjumper. To do both, you must buy Jumper (Time) and Jumper (World) separately, at full cost." + Environment.NewLine + Environment.NewLine + "To initiate a jump, you must visualize your destination, concentrate for 10 seconds, and make an IQ roll. You may hurry the jump, but your roll will be at -1 per second of concentration omitted. Regardless of IQ, a roll of 14 or more always fails. On a success, you appear at your target destination. On a failure, you go nowhere. On a critical failure, you arrive at the wrong destination, which can be any time or world the GM wishes!" + Environment.NewLine + Environment.NewLine + "You appear at your destination at exactly the same place you left your previous time or world – or as close as possible." + Environment.NewLine + Environment.NewLine + "If there is no corresponding “safe” location within 100 yards of your destination, the jump will fail and you will know why it failed." + Environment.NewLine + Environment.NewLine + "This ability always costs at least 1 Fatigue Point (see p. 31) to use, whether it succeeds or fails. Particularly “distant” times or worlds might cost more, perhaps up to 10 FP, at the GM’s discretion.");
            Description.Add("Language Talent", "You have a knack for languages. When you learn a language at a comprehension level above None, you automatically function at the next higher level.");
            Description.Add("Luck (Basic)", "Once per hour of play, you may reroll a single bad die roll twice and take the best of the three rolls! You must declare that you are using your Luck immediately after you roll the dice." + Environment.NewLine + Environment.NewLine + "Your Luck only applies to your own success, damage, or reaction rolls, or on outside events that affect you or your whole party, or when you are being attacked (in which case you may make the attacker roll three times and take the worst roll!).");
            Description.Add("Luck (Extraordinary)", "Once per 30 mins of play, you may reroll a single bad die roll twice and take the best of the three rolls! You must declare that you are using your Luck immediately after you roll the dice." + Environment.NewLine + Environment.NewLine + "Your Luck only applies to your own success, damage, or reaction rolls, or on outside events that affect you or your whole party, or when you are being attacked (in which case you may make the attacker roll three times and take the worst roll!).");
            Description.Add("Luck (Ridiculous)", "Once per mins of play, you may reroll a single bad die roll twice and take the best of the three rolls! You must declare that you are using your Luck immediately after you roll the dice." + Environment.NewLine + Environment.NewLine + "Your Luck only applies to your own success, damage, or reaction rolls, or on outside events that affect you or your whole party, or when you are being attacked (in which case you may make the attacker roll three times and take the worst roll!).");
            Description.Add("Night Vision", "Your eyes adapt rapidly to darkness. Each level of this ability (maximum nine levels) allows you to ignore -1 in combat or vision penalties due to darkness, provided there is at least some light.");
            Description.Add("Perfect Balance", "You can always keep your footing, no matter how narrow the walking surface (tightrope, ledge, tree limb, etc.), under normal conditions without having to make a die roll. If the surface is wet, slippery, or unstable, you get +6 on all rolls to keep your feet. In combat, you get +4 to DX and DXbased skill rolls to keep your feet or avoid being knocked down. Finally, you get +1 to Acrobatics and Climbing skill.");
            Description.Add("Resistant (Poison)", "You are naturally resistant (or even immune) to diseases or poisons. This gives you a bonus on all HT rolls to resist incapacitation or injury from such things." + Environment.NewLine + Environment.NewLine + "You take a +8 bonus to HT.");
            Description.Add("Resistant (Disease)", "You are naturally resistant (or even immune) to diseases or poisons. This gives you a bonus on all HT rolls to resist incapacitation or injury from such things." + Environment.NewLine + Environment.NewLine + "You have a +3 bonus to HT.");
            Description.Add("Talent (Artificer)", "You have a natural aptitude for a set of closely related skills. “Talents” come in levels, and give a bonus of +1 per level with all affected skills, even for default use. This effectively raises your attribute scores for the purpose of those skills only; thus, this is an inexpensive way to be adept at small class of skills." + Environment.NewLine + Environment.NewLine + "You may never have more than four levels of a particular Talent. However, overlapping Talents can give skill bonuses (only) in excess of +4." + Environment.NewLine + Environment.NewLine + "[Covers] Armoury, Electronics, Repair, Engineer, Mechanic, and Computers.");
            Description.Add("Talent (Outdoorsman)", "You have a natural aptitude for a set of closely related skills. “Talents” come in levels, and give a bonus of +1 per level with all affected skills, even for default use. This effectively raises your attribute scores for the purpose of those skills only; thus, this is an inexpensive way to be adept at small class of skills." + Environment.NewLine + Environment.NewLine + "You may never have more than four levels of a particular Talent. However, overlapping Talents can give skill bonuses (only) in excess of +4." + Environment.NewLine + Environment.NewLine + "[Covers] Camoflage, Naturalist, Navigation, Survival, and Tracking.");
            Description.Add("Talent (Smooth Operator)", "You have a natural aptitude for a set of closely related skills. “Talents” come in levels, and give a bonus of +1 per level with all affected skills, even for default use. This effectively raises your attribute scores for the purpose of those skills only; thus, this is an inexpensive way to be adept at small class of skills." + Environment.NewLine + Environment.NewLine + "You may never have more than four levels of a particular Talent. However, overlapping Talents can give skill bonuses (only) in excess of +4." + Environment.NewLine + Environment.NewLine + "[Covers] Influence skills, Acting, Carousing, Leadership, and Public Speaking.");
        }
    }
}