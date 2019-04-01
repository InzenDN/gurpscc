using System;
using System.Collections.Generic;

namespace GURPS_Character_Creator.Models
{
    public class DisadvantageModel
    {
        public string Name { get; private set; }
        public int PtCost { get; private set; }
        public string Description { get; private set; }

        public DisadvantageModel(string name, int pt, string description)
        {
            Name = name;
            PtCost = pt;
            Description = description;
        }
    }

    public class DisadvantageList
    {
        public Dictionary<string, DisadvantageModel> DisadvantageDict { get; private set; }
        public Dictionary<string, string> Description { get; private set; }

        public DisadvantageList()
        {
            Description = new Dictionary<string, string>();
            LoadDescription();

            DisadvantageDict = new Dictionary<string, DisadvantageModel>();
            LoadDisadvantage();   
        }

        private void LoadDisadvantage()
        {
            DisadvantageDict.Add("Bad Sight (Correctable)", new DisadvantageModel("Bad Sight (Correctable)", -10, Description["Bad Sight (Correctable)"]));
            DisadvantageDict.Add("Bad Sight", new DisadvantageModel("Bad Sight", -25, Description["Bad Sight"]));
            DisadvantageDict.Add("Bad Temper", new DisadvantageModel("Bad Temper", -10, Description["Bad Temper"]));
            DisadvantageDict.Add("Bloodlust", new DisadvantageModel("Bloodlust", -10, Description["Bloodlust"]));
            DisadvantageDict.Add("Code of Honor (Common)", new DisadvantageModel("Code of Honor (Common)", -5, Description["Code of Honor (Common)"]));
            DisadvantageDict.Add("Code of Honor (Among Peers Only)", new DisadvantageModel("Code of Honor (Among Peers Only)", -10, Description["Code of Honor (Among Peers Only)"]));
            DisadvantageDict.Add("Code of Honor (Require Suicide if Broken)", new DisadvantageModel("Code of Honor (Require Suicide If Broken)", -15, Description["Code of Honor (Require Suicide if Broken)"]));
            DisadvantageDict.Add("Curious", new DisadvantageModel("Curious", -5, Description["Curious"]));
            DisadvantageDict.Add("Delusions (Minor)", new DisadvantageModel("Delusions (Minor)", -5, Description["Delusions (Minor)"]));
            DisadvantageDict.Add("Delusions (Major)", new DisadvantageModel("Delusions (Major)", -10, Description["Delusions (Major)"]));
            DisadvantageDict.Add("Delusions (Severe)", new DisadvantageModel("Delusions (Severe)", -15, Description["Delusions (Severe)"]));
            DisadvantageDict.Add("Gluttony", new DisadvantageModel("Gluttony", -5, Description["Gluttony"]));
            DisadvantageDict.Add("Greed", new DisadvantageModel("Greed", -15, Description["Greed"]));
            DisadvantageDict.Add("Hard of Hearing", new DisadvantageModel("Hard of Hearing", -10, Description["Hard of Hearing"]));
            DisadvantageDict.Add("Honesty", new DisadvantageModel("Honesty", -10, Description["Honesty"]));
            DisadvantageDict.Add("Impulsiveness", new DisadvantageModel("Impulsiveness", -10, Description["Impulsiveness"]));
            DisadvantageDict.Add("Intolerance (Large Groups)", new DisadvantageModel("Intolerance", -10, Description["Intolerance (Large Groups)"]));
            DisadvantageDict.Add("Intolerance (Individuals)", new DisadvantageModel("Intolerance", -5, Description["Intolerance (Individuals)"]));
            DisadvantageDict.Add("Jealousy", new DisadvantageModel("Jealousy", -10, Description["Jealousy"]));
            DisadvantageDict.Add("Lecherousness", new DisadvantageModel("Lecherousness", -15, Description["Lecherousness"]));
            DisadvantageDict.Add("Obsession", new DisadvantageModel("Obsession", -5, Description["Obsession"]));
            DisadvantageDict.Add("Overconfidence", new DisadvantageModel("Overconfidence", -5, Description["Overconfidence"]));
            DisadvantageDict.Add("Pacificism (Reluctant Killer)", new DisadvantageModel("Pacificism (Reluctant Killer)", -5, Description["Pacificism (Reluctant Killer)"]));
            DisadvantageDict.Add("Pacificism (Cannot Harm Innocent)", new DisadvantageModel("Pacificism (Cannot Harm Innocent)", -10, Description["Pacificism (Cannot Harm Innocent)"]));
            DisadvantageDict.Add("Phobia (Blood)", new DisadvantageModel("Phobia (Blood)", -10, Description["Phobia (Blood)"]));
            DisadvantageDict.Add("Phobia (Darkness)", new DisadvantageModel("Phobia (Darkness)", -15, Description["Phobia (Darkness)"]));
            DisadvantageDict.Add("Phobia (Heights)", new DisadvantageModel("Phobia (Heights)", -10, Description["Phobia (Heights)"]));
            DisadvantageDict.Add("Phobia (#13 or equivalent)", new DisadvantageModel("Phobia (#13 or equivalent)", -5, Description["Phobia (#13 or equivalent)"]));
            DisadvantageDict.Add("Phobia (Spiders)", new DisadvantageModel("Phobia (Spiders)", -5, Description["Phobia (Spiders)"]));
            DisadvantageDict.Add("Sense of Duty (Individual)", new DisadvantageModel("Sense of Duty (Individual)", -2, Description["Sense of Duty (Individual)"]));
            DisadvantageDict.Add("Sense of Duty (Small Group)", new DisadvantageModel("Sense of Duty (Small Group)", -5, Description["Sense of Duty (Small Group)"]));
            DisadvantageDict.Add("Sense of Duty (Large Group)", new DisadvantageModel("Sense of Duty (Large Group)", -10, Description["Sense of Duty (Large Group)"]));
            DisadvantageDict.Add("Sense of Duty (Entire Race)", new DisadvantageModel("Sense of Duty (Entire Race)", -15, Description["Sense of Duty (Entire Race)"]));
            DisadvantageDict.Add("Sense of Duty (Every Living Being)", new DisadvantageModel("Sense of Duty (Every Living Being)", -20, Description["Sense of Duty (Every Living Being)"]));
            DisadvantageDict.Add("Truthfulness", new DisadvantageModel("Truthfulness", -5, Description["Truthfulness"]));
            DisadvantageDict.Add("Unluckiness", new DisadvantageModel("Unluckiness", -10, Description["Unluckiness"]));
            DisadvantageDict.Add("Vow (Minor)", new DisadvantageModel("Vow (Minor)", -5, Description["Vow (Minor)"]));
            DisadvantageDict.Add("Vow (Major)", new DisadvantageModel("Vow (Major)", -10, Description["Vow (Major)"]));
            DisadvantageDict.Add("Vow (Great)", new DisadvantageModel("Vow (Great)", -15, Description["Vow (Great)"]));
        }

        private void LoadDescription()
        {
            Description.Add("Bad Sight (Correctable)", "You have poor vision, giving -6 to Vision rolls and -2 to hit in combat. This disadvantage costs -10 points at TLs where it is correctable (with glasses or contact lenses), -25 points when it is not.");
            Description.Add("Bad Sight", "You have poor vision, giving -6 to Vision rolls and -2 to hit in combat. This disadvantage costs -10 points at TLs where it is correctable (with glasses or contact lenses), -25 points when it is not.");
            Description.Add("Bad Temper", "You are not in full control of your emotions. Make a self-control roll in any stressful situation. If you fail, you lose your temper and must insult, attack, or otherwise act against the cause of the stress.");
            Description.Add("Bloodlust", "You want to see your foes dead.In battle, you must go for killing blows, and put in an extra shot to make sure of a downed foe. You must make a self-control roll whenever you need to accept a surrender, evade a sentry, take a prisoner, etc.If you fail, you attempt to kill your foe instead – even if that means breaking the law, compromising stealth, wasting ammo, or violating orders. Out of combat, you never forget that a foe is a foe.");
            Description.Add("Code of Honor (Common)", "You take pride in a set of principles that you follow at all times. The specifics can vary, but they always involve “honorable” behavior. You will do nearly anything – perhaps even risk death – to avoid the label “dishonorable” (whatever that means to you). The point value of a particular Code of Honor depends on how much trouble it is liable to get you into and how arbitrary and irrational its requirements are.");
            Description.Add("Code of Honor (Among Peers Only)", "You take pride in a set of principles that you follow at all times. The specifics can vary, but they always involve “honorable” behavior. You will do nearly anything – perhaps even risk death – to avoid the label “dishonorable” (whatever that means to you). The point value of a particular Code of Honor depends on how much trouble it is liable to get you into and how arbitrary and irrational its requirements are.");
            Description.Add("Code of Honor (Require Suicide if Broken)", "You take pride in a set of principles that you follow at all times. The specifics can vary, but they always involve “honorable” behavior. You will do nearly anything – perhaps even risk death – to avoid the label “dishonorable” (whatever that means to you). The point value of a particular Code of Honor depends on how much trouble it is liable to get you into and how arbitrary and irrational its requirements are.");
            Description.Add("Curious", "You are naturally very inquisitive. This is not the curiosity that affects all PCs (“What’s in that cave? Where did the flying saucer come from?”), but the real thing (“What happens if I push this button?”)." + Environment.NewLine + Environment.NewLine + "Make a self-control roll when presented with an interesting item or situation. If you fail, you examine it even if you know it could be dangerous. Good roleplayers won’t try to make this roll very often . . .");
            Description.Add("Delusions (Minor)", "You believe something that simply is not true. This may cause others to consider you insane. And they may be right! If you suffer from a Delusion, you must roleplay your belief at all times. The point value of the Delusion depends on its nature." + Environment.NewLine + Environment.NewLine + "A Minor Delusion affects your behavior, and anyone around you will soon notice it (and react at -1), but it does not keep you from functioning more-or-less normally");
            Description.Add("Delusions (Major)", "You believe something that simply is not true. This may cause others to consider you insane. And they may be right! If you suffer from a Delusion, you must roleplay your belief at all times. The point value of the Delusion depends on its nature." + Environment.NewLine + Environment.NewLine + "A Major Delusion strongly affects your behavior, but does not keep you from living a fairly normal life.Others will react to you at - 2.");
            Description.Add("Delusions (Severe)", "You believe something that simply is not true. This may cause others to consider you insane. And they may be right! If you suffer from a Delusion, you must roleplay your belief at all times. The point value of the Delusion depends on its nature." + Environment.NewLine + Environment.NewLine + "A Severe Delusion affects your behavior so much that it may keep you from functioning in the everyday world. Others react to you at -3, but they are more likely to fear or pity you than to attack.");
            Description.Add("Gluttony", "You are overly fond of good food and drink. Given the chance, you must always burden yourself with extra provisions. You should never willingly miss a meal. Make a self-control roll when presented with a tempting morsel or good wine that, for some reason, you should resist. If you fail, you partake – regardless of the consequences.");
            Description.Add("Greed", "You lust for wealth. Make a self-control roll any time riches are offered – as payment for fair work, gains from adventure, spoils of crime, or just bait. If you fail, you do whatever it takes to get the payoff. Small sums do not tempt you much if you are rich, but if you are poor, you get -5 or more on your self-control roll if a rich prize is in the offing.");
            Description.Add("Hard of Hearing", "You are not deaf, but you have some hearing loss. You are at -4 on any Hearing roll and on any skill roll where it is important that you understand someone (if you are the one talking, this disadvantage doesn’t affect you).");
            Description.Add("Honesty", "You must obey the law, and do your best to get others to do so as well. In an area with little or no law, you do not “go wild” – you act as though the laws of your own home were in force. You also assume that others are honest unless you know otherwise." + Environment.NewLine + Environment.NewLine + "This is a disadvantage, because it often limits your options! Make a self-control roll when faced with the “need” to break unreasonable laws; if you fail, you must obey the law, whatever the consequences. If you manage to resist your urges and break the law, make a second self-control roll afterward. If you fail, you must turn yourself in to the authorities!");
            Description.Add("Impulsiveness", "You hate talk and debate. You prefer action! When you are alone, you act first and think later. In a group, when your friends want to stop and discuss something, you should put in your two cents’ worth quickly – if at all – and then do something. Roleplay it! Make a self-control roll whenever it would be wise to wait and ponder. If you fail, you must act.");
            Description.Add("Intolerance (Large Groups)", "You dislike and distrust some (or all) people who are different from you. You may be prejudiced on the basis of class, ethnicity, nationality, religion, sex, or species. Victims of your Intolerance will react to you at -1 to -5 (GM’s decision).");
            Description.Add("Intolerance (Individuals)", "You dislike and distrust some (or all) people who are different from you. You may be prejudiced on the basis of class, ethnicity, nationality, religion, sex, or species. Victims of your Intolerance will react to you at -1 to -5 (GM’s decision).");
            Description.Add("Jealousy", "You react poorly toward those who seem smarter, more attractive, or better off than you!You resist any plan proposed by a “rival,” and hate it if someone else is in the limelight. If an NPC is jealous, the GM will apply a - 2 to - 4 reaction penalty toward the victim(s) of his jealousy.");
            Description.Add("Lecherousness", "You have an unusually strong desire for romance. Make a self-control roll whenever in more than the briefest contact with an appealing member of the sex you find attractive – at -5 if this person is Handsome/Beautiful, or at -10 if Very Handsome/Very Beautiful. If you fail, you must make a “pass,” using whatever wiles and skills you can bring to bear.");
            Description.Add("Obsession", "Your entire life revolves around a single goal, an overpowering fixation that motivates all of your actions." + Environment.NewLine + Environment.NewLine + "Make a self-control roll whenever it would be wise to deviate from your goal. If you fail, you continue to pursue your Obsession, regardless of the consequences.");
            Description.Add("Overconfidence", "You believe that you are far more powerful, intelligent, or competent than you really are. You may be proud and boastful or just quietly determined, but you must roleplay this trait." + Environment.NewLine + Environment.NewLine + "You must make a self-control roll any time the GM feels you show an unreasonable degree of caution. If you fail, you must go ahead as though you were able to handle the situation! Caution is not an option.");
            Description.Add("Pacificism (Reluctant Killer)", "You get -4 to hit a person (not a monster, machine, etc.) with a deadly attack, or -2 if you can’t see his face. If you kill someone, roll 3d – you’re morose and useless for that many days.");
            Description.Add("Pacificism (Cannot Harm Innocent)", "You may fight – you may even start fights – but you may only use deadly force on a foe that is attempting to do you serious harm.");
            Description.Add("Phobia (Blood)", "A “phobia” is a fear of a specific item, creature, or circumstance. The more common an object or situation, the greater the point value of a fear of it. If you have a phobia, you may temporarily master it by making a successful self-control roll . . . but the fear persists. Even if you master a phobia, you will be at -2 to all IQ, DX, and skill rolls while the cause of your fear is present, and you must roll again every 10 minutes to see if the fear overcomes you. If you fail the self-control roll, you will cringe, flee, panic, or otherwise react in a manner that precludes sensible action.");
            Description.Add("Phobia (Darkness)", "A “phobia” is a fear of a specific item, creature, or circumstance. The more common an object or situation, the greater the point value of a fear of it. If you have a phobia, you may temporarily master it by making a successful self-control roll . . . but the fear persists. Even if you master a phobia, you will be at -2 to all IQ, DX, and skill rolls while the cause of your fear is present, and you must roll again every 10 minutes to see if the fear overcomes you. If you fail the self-control roll, you will cringe, flee, panic, or otherwise react in a manner that precludes sensible action.");
            Description.Add("Phobia (Heights)", "A “phobia” is a fear of a specific item, creature, or circumstance. The more common an object or situation, the greater the point value of a fear of it. If you have a phobia, you may temporarily master it by making a successful self-control roll . . . but the fear persists. Even if you master a phobia, you will be at -2 to all IQ, DX, and skill rolls while the cause of your fear is present, and you must roll again every 10 minutes to see if the fear overcomes you. If you fail the self-control roll, you will cringe, flee, panic, or otherwise react in a manner that precludes sensible action.");
            Description.Add("Phobia (#13 or equivalent)", "A “phobia” is a fear of a specific item, creature, or circumstance. The more common an object or situation, the greater the point value of a fear of it. If you have a phobia, you may temporarily master it by making a successful self-control roll . . . but the fear persists. Even if you master a phobia, you will be at -2 to all IQ, DX, and skill rolls while the cause of your fear is present, and you must roll again every 10 minutes to see if the fear overcomes you. If you fail the self-control roll, you will cringe, flee, panic, or otherwise react in a manner that precludes sensible action.");
            Description.Add("Phobia (Spiders)", "A “phobia” is a fear of a specific item, creature, or circumstance. The more common an object or situation, the greater the point value of a fear of it. If you have a phobia, you may temporarily master it by making a successful self-control roll . . . but the fear persists. Even if you master a phobia, you will be at -2 to all IQ, DX, and skill rolls while the cause of your fear is present, and you must roll again every 10 minutes to see if the fear overcomes you. If you fail the self-control roll, you will cringe, flee, panic, or otherwise react in a manner that precludes sensible action.");
            Description.Add("Sense of Duty (Individual)", "You feel a strong sense of commitment toward a particular class of people. You will never betray them, abandon them when they’re in trouble, or let them suffer or go hungry if you can help.");
            Description.Add("Sense of Duty (Small Group)", "(e.g., Close Friends, companions, or squad) You feel a strong sense of commitment toward a particular class of people. You will never betray them, abandon them when they’re in trouble, or let them suffer or go hungry if you can help.");
            Description.Add("Sense of Duty (Large Group)", "(e.g., Nation, religious group, etc) You feel a strong sense of commitment toward a particular class of people. You will never betray them, abandon them when they’re in trouble, or let them suffer or go hungry if you can help.");
            Description.Add("Sense of Duty (Entire Race)", "You feel a strong sense of commitment toward a particular class of people. You will never betray them, abandon them when they’re in trouble, or let them suffer or go hungry if you can help.");
            Description.Add("Sense of Duty (Every Living Being)", "You feel a strong sense of commitment toward a particular class of people. You will never betray them, abandon them when they’re in trouble, or let them suffer or go hungry if you can help.");
            Description.Add("Truthfulness", "You hate to tell a lie – or you are just very bad at it. Make a self-control roll whenever you must keep silent about an uncomfortable truth (lying by omission). Roll at -5 if you actually have to tell a falsehood! If you fail, you blurt out the truth, or stumble so much that your lie is obvious. You have a permanent -5 to Fast-Talk skill, and your Acting skill is at -5 when your purpose is to deceive.");
            Description.Add("Unluckiness", "You have rotten luck. Things go wrong for you – and usually at the worst possible time. Once per play session, the GM will arbitrarily and maliciously make something go wrong for you. You miss a vital die roll, or the enemy (against all odds) shows up at the worst possible time. If the plot of the adventure calls for something bad to happen to someone, it’s you. The GM may not kill you outright with “bad luck,” but anything less than that is fine.");
            Description.Add("Vow (Minor)", "(e.g., Silence during daylight hours; vegetarianism; chastity) You have sworn an oath to do (or not to do) something. Whatever the oath, you take it seriously; if you didn’t, it would not be a disadvantage. This trait is especially appropriate for knights, holy men, and fanatics.");
            Description.Add("Vow (Major)", "(e.g., Use no edged weapons; keep silence at all times; never sleep indoors; own no more than your horse can carry) You have sworn an oath to do (or not to do) something. Whatever the oath, you take it seriously; if you didn’t, it would not be a disadvantage. This trait is especially appropriate for knights, holy men, and fanatics.");
            Description.Add("Vow (Great)", "(e.g., Never refuse any request for aid; always fight with the wrong hand; hunt a given foe until you destroy him; challenge every knight you meet to combat.) You have sworn an oath to do (or not to do) something. Whatever the oath, you take it seriously; if you didn’t, it would not be a disadvantage. This trait is especially appropriate for knights, holy men, and fanatics.");
        }
    }
}
