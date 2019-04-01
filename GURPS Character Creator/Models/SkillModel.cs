using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GURPS_Character_Creator.Models
{
    public enum Attribute { ST, DX, IQ, HT };
    public enum Difficulty { Easy, Average, Hard };

    public class SkillType
    {
        public Attribute Attribute { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public SkillType(Attribute attribute, Difficulty difficulty)
        {
            Attribute = attribute;
            Difficulty = difficulty;
        }
    }

    public class SkillModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public SkillType Type { get; private set; }
        public List<SkillModel> Prerequisite { get; private set; }
        public string Description { get; private set; }
        public int Modifier { get; private set; }

        public SkillModel(int id, string name, SkillType skillType, string description)
        {
            Id = id;
            Name = name;
            Type = skillType;
            Description = description;
        }
    }

    public class SkillList
    {
        public Dictionary<string, SkillModel> SkillsDict { get; set; }
        private Dictionary<string, string> Description;

        public SkillList()
        {
            Description = new Dictionary<string, string>();
            LoadDescription();
            SkillsDict = new Dictionary<string, SkillModel>();
            LoadSkills();

        }

        private void LoadSkills()
        {
            // GURPS LITE
            SkillsDict.Add("Acrobatics", new SkillModel(1, "Acrobatics", new SkillType(Attribute.DX, Difficulty.Hard), Description["Acrobatics"]));
            SkillsDict.Add("Acting", new SkillModel(2, "Acting", new SkillType(Attribute.IQ, Difficulty.Average), Description["Acting"]));
            SkillsDict.Add("Animal Handling", new SkillModel(3, "Animal Handling", new SkillType(Attribute.IQ, Difficulty.Average), Description["Animal Handling"]));
            SkillsDict.Add("Area Knowledge", new SkillModel(4, "Area Knowledge", new SkillType(Attribute.IQ, Difficulty.Easy), Description["Area Knowledge"]));
            SkillsDict.Add("Armoury", new SkillModel(5, "Armoury", new SkillType(Attribute.IQ, Difficulty.Average), Description["Armoury"]));
            SkillsDict.Add("Brawling", new SkillModel(6, "Brawling", new SkillType(Attribute.DX, Difficulty.Easy), Description["Brawling"]));
            SkillsDict.Add("Camouflage", new SkillModel(7, "Camouflage", new SkillType(Attribute.IQ, Difficulty.Easy), Description["Camouflage"]));
            SkillsDict.Add("Carousing", new SkillModel(8, "Carousing", new SkillType(Attribute.HT, Difficulty.Easy), Description["Carousing"]));
            SkillsDict.Add("Climbing", new SkillModel(9, "Climbing", new SkillType(Attribute.DX, Difficulty.Average), Description["Climbing"]));
            SkillsDict.Add("Computer Operation", new SkillModel(10, "Computer Operation", new SkillType(Attribute.IQ, Difficulty.Easy), Description["Computer Operation"]));
            SkillsDict.Add("Computer Programming", new SkillModel(11, "Computer Programming", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Computer Programming"]));
            SkillsDict.Add("Crewman", new SkillModel(12, "Crewman", new SkillType(Attribute.IQ, Difficulty.Easy), Description["Crewman"]));
            SkillsDict.Add("Criminology", new SkillModel(13, "Criminology", new SkillType(Attribute.IQ, Difficulty.Average), Description["Criminology"]));
            SkillsDict.Add("Diagnosis", new SkillModel(14, "Diagnosis", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Diagnosis"]));
            SkillsDict.Add("Disguise", new SkillModel(15, "Disguise", new SkillType(Attribute.IQ, Difficulty.Average), Description["Disguise"]));
            SkillsDict.Add("Electronics Operation", new SkillModel(16, "Electronics Operation", new SkillType(Attribute.IQ, Difficulty.Average), Description["Electronics Operation"]));
            SkillsDict.Add("Electronics Repair", new SkillModel(17, "Electronics Repair", new SkillType(Attribute.IQ, Difficulty.Average), Description["Electronics Repair"]));
            SkillsDict.Add("Engineer", new SkillModel(18, "Engineer", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Engineer"]));
            SkillsDict.Add("Environment Suit (Battlesuit)", new SkillModel(19, "Environment Suit (Battlesuit)", new SkillType(Attribute.DX, Difficulty.Average), Description["Environment Suit (Battlesuit)"]));
            SkillsDict.Add("Environment Suit (Driving Suit)", new SkillModel(19, "Environment Suit (Driving Suit)", new SkillType(Attribute.DX, Difficulty.Average), Description["Environment Suit (Driving Suit)"]));
            SkillsDict.Add("Environment Suit (NBC Suit)", new SkillModel(19, "Environment Suit (NBC Suit)", new SkillType(Attribute.DX, Difficulty.Average), Description["Environment Suit (NBC Suit)"]));
            SkillsDict.Add("Environment Suit (Vacc Suit)", new SkillModel(19, "Environment Suit (Vacc Suit)", new SkillType(Attribute.DX, Difficulty.Average), Description["Environment Suit (Vacc Suit)"]));
            SkillsDict.Add("Escape", new SkillModel(20, "Escape", new SkillType(Attribute.DX, Difficulty.Hard), Description["Escape"]));
            SkillsDict.Add("Explosives", new SkillModel(21, "Explosives", new SkillType(Attribute.IQ, Difficulty.Average), Description["Explosives"]));
            SkillsDict.Add("First Aid", new SkillModel(22, "First Aid", new SkillType(Attribute.IQ, Difficulty.Easy), Description["First Aid"]));
            SkillsDict.Add("Forgery", new SkillModel(23, "Forgery", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Forgery"]));
            SkillsDict.Add("Gambling", new SkillModel(24, "Gambling", new SkillType(Attribute.IQ, Difficulty.Average), Description["Gambling"]));
            SkillsDict.Add("Hiking", new SkillModel(25, "Hiking", new SkillType(Attribute.HT, Difficulty.Average), Description["Hiking"]));
            SkillsDict.Add("Holdout", new SkillModel(26, "Holdout", new SkillType(Attribute.IQ, Difficulty.Average), Description["Holdout"]));
            SkillsDict.Add("Humanities", new SkillModel(27, "Humanities", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Humanities"]));
            SkillsDict.Add("Influence Skills (Diplomacy)", new SkillModel(28, "Influence Skills (Diplomacy)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Influence Skills (Diplomacy)"]));
            SkillsDict.Add("Influence Skills (Fast-Talk)", new SkillModel(29, "Influence Skills (Fast-Talk)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Influence Skills (Fast-Talk)"]));
            SkillsDict.Add("Influence Skills (Intimidation)", new SkillModel(30, "Influence Skills (Intimidation)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Influence Skills (Intimidation)"]));
            SkillsDict.Add("Influence Skills (Savoir-Faire)", new SkillModel(31, "Influence Skills (Savoir-Faire)", new SkillType(Attribute.IQ, Difficulty.Easy), Description["Influence Skills (Savoir-Faire)"]));
            SkillsDict.Add("Influence Skills (Sex Appeal)", new SkillModel(32, "Influence Skills (Sex Appeal)", new SkillType(Attribute.HT, Difficulty.Average), Description["Influence Skills (Sex Appeal)"]));
            SkillsDict.Add("Influence Skills (Streetwise)", new SkillModel(33, "Influence Skills (Streetwise)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Influence Skills (Streetwise)"]));
            SkillsDict.Add("Interrogation", new SkillModel(34, "Interrogation", new SkillType(Attribute.IQ, Difficulty.Average), Description["Interrogation"]));
            SkillsDict.Add("Jumping", new SkillModel(35, "Jumping", new SkillType(Attribute.DX, Difficulty.Easy), Description["Jumping"]));
            SkillsDict.Add("Karate", new SkillModel(36, "Karate", new SkillType(Attribute.DX, Difficulty.Hard), Description["Karate"]));
            SkillsDict.Add("Law", new SkillModel(37, "Law", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Law"]));
            SkillsDict.Add("Leadership", new SkillModel(38, "Leadership", new SkillType(Attribute.IQ, Difficulty.Average), Description["Leadership"]));
            SkillsDict.Add("Lockpicking", new SkillModel(39, "Lockpicking", new SkillType(Attribute.IQ, Difficulty.Average), Description["Lockpicking"]));
            SkillsDict.Add("Mathematics", new SkillModel(40, "Mathematics", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Mathematics"]));
            SkillsDict.Add("Mechanic", new SkillModel(41, "Mechanic", new SkillType(Attribute.IQ, Difficulty.Average), Description["Mechanic"]));
            SkillsDict.Add("Melee Weapon (Rapier)", new SkillModel(42, "Melee Weapon (Rapier)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Rapier)"]));
            SkillsDict.Add("Melee Weapon (Smallsword)", new SkillModel(43, "Melee Weapon (Smallsword)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Smallsword)"]));
            SkillsDict.Add("Melee Weapon (Flail)", new SkillModel(44, "Melee Weapon (Flail)", new SkillType(Attribute.DX, Difficulty.Hard), Description["Melee Weapon (Flail)"]));
            SkillsDict.Add("Melee Weapon (Axe/Mace)", new SkillModel(45, "Melee Weapon (Axe/Mace)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Axe/Mace)"]));
            SkillsDict.Add("Melee Weapon (Polearm)", new SkillModel(46, "Melee Weapon (Polearm)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Polearm)"]));
            SkillsDict.Add("Melee Weapon (Spear)", new SkillModel(47, "Melee Weapon (Spear)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Spear)"]));
            SkillsDict.Add("Melee Weapon (Staff)", new SkillModel(48, "Melee Weapon (Staff)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Staff)"]));
            SkillsDict.Add("Melee Weapon (Broadsword)", new SkillModel(49, "Melee Weapon (Broadsword)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Broadsword)"]));
            SkillsDict.Add("Melee Weapon (Knife)", new SkillModel(50, "Melee Weapon (Knife)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Melee Weapon (Knife)"]));
            SkillsDict.Add("Melee Weapon (Shortsword)", new SkillModel(51, "Melee Weapon (Shortsword)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Shortsword)"]));
            SkillsDict.Add("Melee Weapon (Two-Handed Sword)", new SkillModel(52, "Melee Weapon (Two-Handed Sword)", new SkillType(Attribute.DX, Difficulty.Average), Description["Melee Weapon (Two-Handed Sword)"]));
            SkillsDict.Add("Merchant", new SkillModel(53, "Merchant", new SkillType(Attribute.IQ, Difficulty.Average), Description["Merchant"]));
            SkillsDict.Add("Missile Weapon (Beams)", new SkillModel(54, "Missile Weapon (Beams)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Beams)"]));
            SkillsDict.Add("Missile Weapon (Cannon)", new SkillModel(55, "Missile Weapon (Cannon)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Cannon)"]));
            SkillsDict.Add("Missile Weapon (Machine Gun)", new SkillModel(56, "Missile Weapon (Machine Gun)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Machine Gun)"]));
            SkillsDict.Add("Missile Weapon (Light Anti-Armor Weapon)", new SkillModel(57, "Missile Weapon (Light Anti-Armor Weapon)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Light Anti-Armor Weapon)"]));
            SkillsDict.Add("Missile Weapon (Pistol)", new SkillModel(58, "Missile Weapon (Pistol)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Pistol)"]));
            SkillsDict.Add("Missile Weapon (Rifle)", new SkillModel(59, "Missile Weapon (Rifle)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Rifle)"]));
            SkillsDict.Add("Missile Weapon (Shotgun)", new SkillModel(60, "Missile Weapon (Shotgun)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Shotgun)"]));
            SkillsDict.Add("Missile Weapon (Submachine Gun)", new SkillModel(61, "Missile Weapon (Submachine Gun)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Submachine Gun)"]));
            SkillsDict.Add("Missile Weapon (Flamethrower)", new SkillModel(62, "Missile Weapon (Flamethrower)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Flamethrower)"]));
            SkillsDict.Add("Missile Weapon (Blowpipe)", new SkillModel(63, "Missile Weapon (Blowpipe)", new SkillType(Attribute.DX, Difficulty.Hard), Description["Missile Weapon (Blowpipe)"]));
            SkillsDict.Add("Missile Weapon (Bow)", new SkillModel(64, "Missile Weapon (Bow)", new SkillType(Attribute.DX, Difficulty.Average), Description["Missile Weapon (Bow)"]));
            SkillsDict.Add("Missile Weapon (Crossbow)", new SkillModel(65, "Missile Weapon (Crossbow)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Missile Weapon (Crossbow)"]));
            SkillsDict.Add("Natural Sciences (Astronomy)", new SkillModel(66, "Natural Sciences (Astronomy)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Natural Sciences (Astronomy)"]));
            SkillsDict.Add("Natural Sciences (Biology)", new SkillModel(66, "Natural Sciences (Biology)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Natural Sciences (Biology)"]));
            SkillsDict.Add("Natural Sciences (Chemistry)", new SkillModel(66, "Natural Sciences (Chemistry)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Natural Sciences (Chemistry)"]));
            SkillsDict.Add("Natural Sciences (Physics)", new SkillModel(66, "Natural Sciences (Physics)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Natural Sciences (Physics)"]));
            SkillsDict.Add("Naturalist", new SkillModel(66, "Naturalist", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Naturalist"]));
            SkillsDict.Add("Navigation (Sea)", new SkillModel(67, "Navigation (Sea)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Navigation (Sea)"]));
            SkillsDict.Add("Navigation (Air)", new SkillModel(68, "Navigation (Air)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Navigation (Air)"]));
            SkillsDict.Add("Navigation (Land)", new SkillModel(69, "Navigation (Land)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Navigation (Land)"]));
            SkillsDict.Add("Navigation (Space)", new SkillModel(70, "Navigation (Space)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Navigation (Space)"]));
            SkillsDict.Add("Navigation (Hyperspace)", new SkillModel(71, "Navigation (Hyperspace)", new SkillType(Attribute.IQ, Difficulty.Average), Description["Navigation (Hyperspace)"]));
            SkillsDict.Add("Observation", new SkillModel(72, "Observation", new SkillType(Attribute.IQ, Difficulty.Average), Description["Observation"]));
            SkillsDict.Add("Occultism", new SkillModel(73, "Occultism", new SkillType(Attribute.IQ, Difficulty.Average), Description["Occultism"]));
            SkillsDict.Add("Photography", new SkillModel(74, "Photography", new SkillType(Attribute.IQ, Difficulty.Average), Description["Photography"]));
            SkillsDict.Add("Physician", new SkillModel(75, "Physician", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Physician"]));
            SkillsDict.Add("Pickpocket", new SkillModel(76, "Pickpocket", new SkillType(Attribute.DX, Difficulty.Hard), Description["Pickpocket"]));
            SkillsDict.Add("Public Speaking", new SkillModel(77, "Public Speaking", new SkillType(Attribute.IQ, Difficulty.Average), Description["Public Speaking"]));
            SkillsDict.Add("Research", new SkillModel(78, "Research", new SkillType(Attribute.IQ, Difficulty.Average), Description["Research"]));
            SkillsDict.Add("Riding", new SkillModel(79, "Riding", new SkillType(Attribute.DX, Difficulty.Average), Description["Riding"]));
            SkillsDict.Add("Scrounging", new SkillModel(80, "Scrounging", new SkillType(Attribute.IQ, Difficulty.Easy), Description["Scrounging"]));
            SkillsDict.Add("Search", new SkillModel(81, "Search", new SkillType(Attribute.IQ, Difficulty.Average), Description["Search"]));
            SkillsDict.Add("Shadowing", new SkillModel(82, "Shadowing", new SkillType(Attribute.IQ, Difficulty.Average), Description["Shadowing"]));
            SkillsDict.Add("Shield", new SkillModel(83, "Shield", new SkillType(Attribute.DX, Difficulty.Easy), Description["Shield"]));
            SkillsDict.Add("Social Sciences (Anthropology)", new SkillModel(84, "Social Sciences (Anthropology)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Social Sciences (Anthropology)"]));
            SkillsDict.Add("Social Sciences (Archaeology)", new SkillModel(84, "Social Sciences (Archaeology)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Social Sciences (Archaeology)"]));
            SkillsDict.Add("Social Sciences (Psychology)", new SkillModel(84, "Social Sciences (Psychology)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Social Sciences (Psychology)"]));
            SkillsDict.Add("Social Sciences (Sociology)", new SkillModel(84, "Social Sciences (Sociology)", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Social Sciences (Sociology)"]));
            SkillsDict.Add("Smuggling", new SkillModel(85, "Smuggling", new SkillType(Attribute.IQ, Difficulty.Average), Description["Smuggling"]));
            SkillsDict.Add("Stealth", new SkillModel(86, "Stealth", new SkillType(Attribute.DX, Difficulty.Average), Description["Stealth"]));
            SkillsDict.Add("Survival", new SkillModel(87, "Survival", new SkillType(Attribute.IQ, Difficulty.Average), Description["Survival"]));
            SkillsDict.Add("Swimming", new SkillModel(88, "Swimming", new SkillType(Attribute.HT, Difficulty.Easy), Description["Swimming"]));
            SkillsDict.Add("Tactics", new SkillModel(89, "Tactics", new SkillType(Attribute.IQ, Difficulty.Hard), Description["Tactics"]));
            SkillsDict.Add("Throwing", new SkillModel(90, "Throwing", new SkillType(Attribute.DX, Difficulty.Average), Description["Throwing"]));
            SkillsDict.Add("Thrown Weapon (Axe/Mace)", new SkillModel(91, "Thrown Weapon (Axe/Mace)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Thrown Weapon (Axe/Mace)"]));
            SkillsDict.Add("Thrown Weapon (Knife)", new SkillModel(92, "Thrown Weapon (Knife)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Thrown Weapon (Knife)"]));
            SkillsDict.Add("Thrown Weapon (Shuriken)", new SkillModel(93, "Thrown Weapon (Shuriken)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Thrown Weapon (Shuriken)"]));
            SkillsDict.Add("Thrown Weapon (Spear)", new SkillModel(94, "Thrown Weapon (Spear)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Thrown Weapon (Spear)"]));
            SkillsDict.Add("Tracking", new SkillModel(95, "Tracking", new SkillType(Attribute.IQ, Difficulty.Average), Description["Tracking"]));
            SkillsDict.Add("Traps", new SkillModel(96, "Traps", new SkillType(Attribute.IQ, Difficulty.Average), Description["Traps"]));
            SkillsDict.Add("Vehicle Skill (Bicycling)", new SkillModel(97, "Vehicle Skill (Bicycling)", new SkillType(Attribute.DX, Difficulty.Easy), Description["Vehicle Skill (Bicycling)"]));
            SkillsDict.Add("Vehicle Skill (Boating)", new SkillModel(98, "Vehicle Skill (Boating)", new SkillType(Attribute.DX, Difficulty.Average), Description["Vehicle Skill (Boating)"]));
            SkillsDict.Add("Vehicle Skill (Driving)", new SkillModel(99, "Vehicle Skill (Driving)", new SkillType(Attribute.DX, Difficulty.Average), Description["Vehicle Skill (Driving)"]));
            SkillsDict.Add("Vehicle Skill (Piloting)", new SkillModel(100, "Vehicle Skill (Piloting)", new SkillType(Attribute.DX, Difficulty.Average), Description["Vehicle Skill (Piloting)"]));
            SkillsDict.Add("Vehicle Skill (Submarine)", new SkillModel(101, "Vehicle Skill (Submarine)", new SkillType(Attribute.DX, Difficulty.Average), Description["Vehicle Skill (Submarine)"]));
            SkillsDict.Add("Writing", new SkillModel(102, "Writing", new SkillType(Attribute.IQ, Difficulty.Average), Description["Writing"]));
        }

        private void LoadDescription()
        {
            Description.Add("Acrobatics", "This is the ability to perform gymnastic stunts, roll, take falls, etc.");
            Description.Add("Acting", "This is the ability to counterfeit moods, emotions, and voices, and to lie convincingly over a period of time.");
            Description.Add("Animal Handling", "This is the ability to train and work with animals. When working with a trained animal, roll against skill for each task you give the animal.");
            Description.Add("Area Knowledge", "This skill represents familiarity with the people, places, and politics of a given region. You usually have Area Knowledge only for the area you consider your “home base.”");
            Description.Add("Armoury", "This is the ability to build, modify, and repair a specific class of weapons or armor. A successful roll lets you find a problem, if it isn’t obvious; a second roll lets you repair it. Time required is up to the GM.");
            Description.Add("Brawling", "This is the skill of “unscientific” unarmed combat. Roll against Brawling to hit with a punch, or Brawling-2 to hit with a kick.");
            Description.Add("Camouflage", "This is the ability to use natural materials, special fabrics and paints, etc. to hide yourself, your position, or your equipment.");
            Description.Add("Carousing", "This is the skill of socializing, partying, etc. A successful Carousing roll, under the right circumstances, gives you a +2 bonus on a request for aid or information, or just on a general reaction. A failed roll means you made a fool of yourself in some way; you get a -2 penalty on any reaction roll made by those you caroused with.");
            Description.Add("Climbing", "This is the ability to climb mountains, rock walls, trees, the sides of buildings, etc. See Climbing (p. 22) for details.");
            Description.Add("Computer Operation", "This is the ability to use a computer: call up data, run programs, play games, etc. It is the only computer skill needed by most end users.");
            Description.Add("Computer Programming", "The ability to write and debug computer software. Roll to write, debug, or figure out a program.");
            Description.Add("Crewman", "This is the ability to serve as crew aboard a large vehicle. It includes familiarity with “shipboard life,” knowledge of safety measures, and training in damage control.");
            Description.Add("Criminology", "This is the study of crime and the criminal mind. A successful skill roll allows you to find and interpret clues, guess how criminals might behave, etc.");
            Description.Add("Diagnosis", "This is the ability to tell what is wrong with a sick or injured person, or what killed a dead person. It might not determine the exact problem, but it always gives hints, rule out impossibilities, etc.");
            Description.Add("Disguise", "This is the art of altering your appearance using clothing, makeup, and prosthetics. A good disguise requires a Disguise roll and 30 minutes to an hour of preparation.");
            Description.Add("Electronics Operation", "This skill lets you use electronic equipment. Make a skill roll in an emergency situation or for “abnormal” use of equipment – not for ordinary, everyday use.");
            Description.Add("Electronics Repair", "This is the ability to diagnose and repair known types of electronic equipment.");
            Description.Add("Engineer", "This is the ability to design and build technological devices and systems. A successful roll lets you design a new system, diagnose a glitch, identify the purpose of a strange device, or improvise a gadget to solve a problem.");
            Description.Add("Environment Suit (Battlesuit)", "All kinds of powered battle armor and exoskeletons. This is training in the use of a specific class of protective suit. Suits designed against environmental or battlefield hazards are so complex that you do not merely wear such gear – you operate it.");
            Description.Add("Environment Suit (Driving Suit)", "All types of hard diving suits. This is training in the use of a specific class of protective suit. Suits designed against environmental or battlefield hazards are so complex that you do not merely wear such gear – you operate it.");
            Description.Add("Environment Suit (NBC Suit)", "All forms of hazardous materials(“HazMat”) gear. This is training in the use of a specific class of protective suit. Suits designed against environmental or battlefield hazards are so complex that you do not merely wear such gear – you operate it.");
            Description.Add("Environment Suit (Vacc Suit)", "Any kind of spacesuit. This is training in the use of a specific class of protective suit. Suits designed against environmental or battlefield hazards are so complex that you do not merely wear such gear – you operate it.");
            Description.Add("Escape", "This is the ability to slip out of ropes, handcuffs, and similar restraints. The first attempt to escape takes one minute; each subsequent attempt takes 10 minutes.");
            Description.Add("Explosives", "This is the skill of working with explosives and incendiaries, including the ability to set up, disarm, and dispose of bombs and other explosives.");
            Description.Add("First Aid", "This is the ability to patch up an injury in the field (see Recovery, p. 30). Make a skill roll to halt bleeding, suck out poison, give artificial respiration to a drowning victim, etc.");
            Description.Add("Forgery", "This is the ability to create falsified documents (identity cards, passports, etc.). When you use a forged document, make your Forgery roll each time it is inspected – unless you roll a critical success on your first attempt. Failure means someone spots the forgery.");
            Description.Add("Gambling", "This is skill at playing games of chance. A successful Gambling roll can (among other things) tell you if a game is rigged, identify a fellow gambler in a group of strangers, or “estimate the odds” in any tricky situation.");
            Description.Add("Hiking", "This skill represents training for endurance walking, hiking, and marching. Make a Hiking roll before each day’s march; on a success, increase the distance traveled by 20%.");
            Description.Add("Holdout", "This is the skill of concealing items on your person or on other people (usually with their cooperation). An item’s size and shape govern its concealability, from +4 for a BB-sized jewel or a postage stamp, to -6 for a crossbow or a heavy sniper rifle.");
            Description.Add("Humanities", "Each academic “humanity” or “arts” subject (such as History, Literature, Philosophy, or Theology) is a separate skill.");
            Description.Add("Influence Skills (Diplomacy)", "Negotiation and compromise." + Environment.NewLine + Environment.NewLine + "There are several ways to influence others; each is a separate influence skill. A successful roll will result in a good reaction from an NPC. Failure results in a bad reaction (except for Diplomacy, which is relatively safe). To actually coerce or manipulate an NPC, you must win a Quick Contest of your skill versus his Will.");
            Description.Add("Influence Skills (Fast-Talk)", "Lying and deceit." + Environment.NewLine + Environment.NewLine + "There are several ways to influence others; each is a separate influence skill. A successful roll will result in a good reaction from an NPC. Failure results in a bad reaction (except for Diplomacy, which is relatively safe). To actually coerce or manipulate an NPC, you must win a Quick Contest of your skill versus his Will.");
            Description.Add("Influence Skills (Intimidation)", "Threats and violence." + Environment.NewLine + Environment.NewLine + "There are several ways to influence others; each is a separate influence skill. A successful roll will result in a good reaction from an NPC. Failure results in a bad reaction (except for Diplomacy, which is relatively safe). To actually coerce or manipulate an NPC, you must win a Quick Contest of your skill versus his Will.");
            Description.Add("Influence Skills (Savoir-Faire)", "Manners and etiquette. Mainly useful in “high society” situations." + Environment.NewLine + Environment.NewLine + "There are several ways to influence others; each is a separate influence skill. A successful roll will result in a good reaction from an NPC. Failure results in a bad reaction (except for Diplomacy, which is relatively safe). To actually coerce or manipulate an NPC, you must win a Quick Contest of your skill versus his Will.");
            Description.Add("Influence Skills (Sex Appeal)", "Vamping and seduction, usually of the opposite sex." + Environment.NewLine + Environment.NewLine + "There are several ways to influence others; each is a separate influence skill. A successful roll will result in a good reaction from an NPC. Failure results in a bad reaction (except for Diplomacy, which is relatively safe). To actually coerce or manipulate an NPC, you must win a Quick Contest of your skill versus his Will.");
            Description.Add("Influence Skills (Streetwise)", "Contacts and (usually) subtle intimidation." + Environment.NewLine + Environment.NewLine + "There are several ways to influence others; each is a separate influence skill. A successful roll will result in a good reaction from an NPC. Failure results in a bad reaction (except for Diplomacy, which is relatively safe). To actually coerce or manipulate an NPC, you must win a Quick Contest of your skill versus his Will.");
            Description.Add("Interrogation", "This is the ability to question a prisoner. Roll a Quick Contest of Interrogation vs. the prisoner’s Will for each question. This requires 5 minutes per question. If you win, you get a truthful answer. If you tie or lose, the victim remains silent or lies. If you lose by more than five points, he tells you a good, believable lie!");
            Description.Add("Jumping", "This skill represents trained jumping ability. When you attempt a difficult jump, roll against the higher of Jumping or DX.In addition, you may use half your Jumping skill(round down) instead of Basic Move when calculating jumping distance.");
            Description.Add("Karate", "This skill represents any advanced training at unarmed striking, not just the Okinawan martial art of karate. Roll against Karate to hit with a punch (at no -4 for the “off” hand), or Karate-2 to hit with a kick." + Environment.NewLine + Environment.NewLine + "Karate improves damage: if you know Karate at DX level, add +1 per die to basic thrust damage when you calculate damage with Karate attacks: punches, kicks, elbow strikes, etc. Add +2 per die if you know Karate at DX+1 or better!");
            Description.Add("Law", "This skill represents knowledge of law codes and jurisprudence. A successful roll lets you remember, deduce, or figure out the answer to a question about the law.");
            Description.Add("Leadership", "This is the ability to coordinate a group. Make a Leadership roll to lead NPCs into a dangerous or stressful situation. (PCs can decide for themselves if they want to follow you!)");
            Description.Add("Lockpicking", "This is the ability to open locks without the key or combination. Each attempt requires one minute. If you make the roll and open the lock, each point by which you succeeded shaves five seconds off the required time.");
            Description.Add("Mathematics", "This is the scientific study of quantities and magnitudes, and their relationships and attributes, through the use of numbers and symbols.");
            Description.Add("Mechanic", "This is the ability to diagnose and fix ordinary mechanical problems. A successful skill roll will let you find or repair one problem.");
            Description.Add("Melee Weapon (Rapier)", "Fencing weapons are light, one-handed weapons, usually hilted blades, optimized for parrying.");
            Description.Add("Melee Weapon (Smallsword)", "Fencing weapons are light, one-handed weapons, usually hilted blades, optimized for parrying.");
            Description.Add("Melee Weapon (Flail)", "A flail is any flexible, unbalanced weapon with its mass concentrated in the head. Because flails tend to wrap around the target’s shield or weapon, attempts to block them are at -2 and attempts to parry them are at -4.");
            Description.Add("Melee Weapon (Axe/Mace)", "An impact weapon is any rigid, unbalanced weapon with most of its mass concentrated in the head, such as axes and maces. Such a weapon cannot parry if you have already attacked with it on your turn.");
            Description.Add("Melee Weapon (Polearm)", "Pole weapons are long (usually wooden) shafts, often adorned with striking heads. All require two hands.");
            Description.Add("Melee Weapon (Spear)", "Pole weapons are long (usually wooden) shafts, often adorned with striking heads. All require two hands.");
            Description.Add("Melee Weapon (Staff)", "Pole weapons are long (usually wooden) shafts, often adorned with striking heads. All require two hands. Also +2 Parry.");
            Description.Add("Melee Weapon (Broadsword)", "A sword is a rigid, hilted blade with a thrusting point, cutting edge, or both. All swords are balanced, and can attack and parry without becoming unready.");
            Description.Add("Melee Weapon (Knife)", "A sword is a rigid, hilted blade with a thrusting point, cutting edge, or both. All swords are balanced, and can attack and parry without becoming unready. -1 to Parry");
            Description.Add("Melee Weapon (Shortsword)", "A sword is a rigid, hilted blade with a thrusting point, cutting edge, or both. All swords are balanced, and can attack and parry without becoming unready.");
            Description.Add("Melee Weapon (Two-Handed Sword)", "A sword is a rigid, hilted blade with a thrusting point, cutting edge, or both. All swords are balanced, and can attack and parry without becoming unready.");
            Description.Add("Merchant", "This is the skill of buying, selling, and trading retail and wholesale goods. It involves bargaining, salesmanship, and an understanding of trade practices.");
            Description.Add("Missile Weapon (Beams)", "Any kind of heavy directed-energy weapon: laser, particle beam, etc.");
            Description.Add("Missile Weapon (Cannon)", "Any kind of heavy projectile weapon – e.g., the main gun of a tank or an ultra-tech railgun on a starship – that fires single shots.");
            Description.Add("Missile Weapon (Machine Gun)", "Any kind of heavy projectile weapon capable of firing bursts.");
            Description.Add("Missile Weapon (Light Anti-Armor Weapon)", "All forms of rocket launchers and recoilless rifles.");
            Description.Add("Missile Weapon (Pistol)", "All kinds of handguns, including derringers, pepperboxes, revolvers, and automatics, but not machine pistols.");
            Description.Add("Missile Weapon (Rifle)", "Any kind of rifled long arm – assault rifle, hunting rifle, sniper rifle, etc. – that fires a solid projectile.");
            Description.Add("Missile Weapon (Shotgun)", "Any kind of smoothbore long arm that fires multiple projectiles (flechettes, shot, etc.).");
            Description.Add("Missile Weapon (Submachine Gun)", "All short, fully automatic weapons that fire pistol-caliber ammunition, including machine pistols.");
            Description.Add("Missile Weapon (Flamethrower)", "This is the ability to use a weapon that projects a stream of liquid or gas.");
            Description.Add("Missile Weapon (Blowpipe)", "You can use this weapon to shoot small, usually poisoned, darts. You can also use it to blow powders at targets within one yard.");
            Description.Add("Missile Weapon (Bow)", "This is the ability to use all bows except crossbows.");
            Description.Add("Missile Weapon (Crossbow)", "This is the ability to use all types of crossbows.");
            Description.Add("Natural Sciences (Astronomy)", "There are a number of skill types under this heading, including Astronomy, Biology, Chemistry, Geology, and Physics, plus any others the GM approves.");
            Description.Add("Natural Sciences (Biology)", "There are a number of skill types under this heading, including Astronomy, Biology, Chemistry, Geology, and Physics, plus any others the GM approves.");
            Description.Add("Natural Sciences (Chemistry)", "There are a number of skill types under this heading, including Astronomy, Biology, Chemistry, Geology, and Physics, plus any others the GM approves.");
            Description.Add("Natural Sciences (Physics)", "There are a number of skill types under this heading, including Astronomy, Biology, Chemistry, Geology, and Physics, plus any others the GM approves.");
            Description.Add("Natural Sciences (Geology)", "There are a number of skill types under this heading, including Astronomy, Biology, Chemistry, Geology, and Physics, plus any others the GM approves.");
            Description.Add("Naturalist", "This skill represents practical knowledge of nature – notably, how to tell dangerous plants and animals from benign ones, how to locate a cave to shelter in; and how to “read” weather patterns to know when to take shelter.");
            Description.Add("Navigation (Sea)", "This is the ability to find your position through careful observation of your surroundings and the use of instrumentation. A successful roll tells you where you are or lets you plot a course.");
            Description.Add("Navigation (Air)", "This is the ability to find your position through careful observation of your surroundings and the use of instrumentation. A successful roll tells you where you are or lets you plot a course.");
            Description.Add("Navigation (Land)", "This is the ability to find your position through careful observation of your surroundings and the use of instrumentation. A successful roll tells you where you are or lets you plot a course.");
            Description.Add("Navigation (Space)", "This is the ability to find your position through careful observation of your surroundings and the use of instrumentation. A successful roll tells you where you are or lets you plot a course.");
            Description.Add("Navigation (Hyperspace)", "This is the ability to find your position through careful observation of your surroundings and the use of instrumentation. A successful roll tells you where you are or lets you plot a course.");
            Description.Add("Observation", "This is the talent of observing dangerous or “interesting” situations without letting others know that you are watching. Use this skill to monitor a location, a group of people, or your immediate surroundings for concealed or tactically significant details.");
            Description.Add("Occultism", "This is the study of the mysterious and the supernatural. An occultist is an expert on ancient rituals, hauntings, mysticism, primitive magical beliefs, psychic phenomena, etc.");
            Description.Add("Photography", "This is the ability to use a camera competently, use a darkroom (TL5+) or digital imaging software (TL8+), etc., and to produce recognizable and attractive photos. You may roll at default to use a camera, but not to develop film or prints in a darkroom.");
            Description.Add("Physician", "This is the ability to aid the sick and the injured, prescribe drugs and care, etc. Make a skill roll to hasten natural recovery from injury (see Recovery, p. 30), and whenever the GM requires a roll to test general medical competence or knowledge.");
            Description.Add("Pickpocket", "This is the ability to steal a purse, knife, etc., from someone’s person – or to “plant” something on him.");
            Description.Add("Public Speaking", "This is general talent with the spoken word. A successful skill roll lets you (for instance) give a good political speech, entertain a group around a campfire, incite or calm a riot, or put on a successful “court jester” act.");
            Description.Add("Research", "This is the ability to do library and file research. Roll against skill to find a useful piece of data in an appropriate place of research . . . ifthe information is there to be found.");
            Description.Add("Riding", "This is the ability to ride a particular kind of mount. Make a skill roll when you first try to mount a riding animal, and again each time something happens to frighten or challenge the creature (e.g., a jump).");
            Description.Add("Scrounging", "This is the ability to find, salvage, or improvise useful items that others can’t locate. Each attempt takes an hour. You do not necessarily steal your booty; you just locate it – somehow – and then acquire it by any means necessary.");
            Description.Add("Search", "This is the ability to search people, baggage, and vehicles for items that aren’t in plain sight. The GM rolls once – in secret – per item of interest. For deliberately concealed items, this is a Quick Contest of your Search skill vs. the Holdout or Smuggling skill used to hide the item. If you fail, the GM simply says, “You found nothing.”");
            Description.Add("Shadowing", "This is the ability to follow another person through a crowd without being noticed. Roll a Quick Contest every 10 minutes: your Shadowing vs. the subject’s Vision roll. If you lose, you lost the subject; if you lose by more than 5, you were seen.");
            Description.Add("Shield", "This is the ability to use a shield, both to block and to attack. Your Block score with any shield is (skill/2) + 3, rounded down.");
            Description.Add("Social Sciences (Anthropology)", "Each “social science” (e.g., Anthropology, Archaeology, Psychology or Sociology) is a separate skill.");
            Description.Add("Social Sciences (Archaeology)", "Each “social science” (e.g., Anthropology, Archaeology, Psychology or Sociology) is a separate skill.");
            Description.Add("Social Sciences (Psychology)", "Each “social science” (e.g., Anthropology, Archaeology, Psychology or Sociology) is a separate skill.");
            Description.Add("Social Sciences (Sociology)", "Each “social science” (e.g., Anthropology, Archaeology, Psychology or Sociology) is a separate skill.");
            Description.Add("Smuggling", "This is the ability to conceal items in baggage and vehicles. You can also use it to hide an object in a room or a building. Roll against skill to hide an item from casual inspection. In an active search, the searchers must win a Quick Contest of Search vs. your Smuggling skill to find the item.");
            Description.Add("Stealth", "This is the ability to hide and to move silently. A successful roll lets you conceal yourself practically anywhere, or move so quietly that nobody will hear you, or follow someone without being noticed." + Environment.NewLine + Environment.NewLine + "If someone is specifically on the alert for intruders, the GM will roll a Quick Contest between your Stealth and the sentinel’s Perception.");
            Description.Add("Survival", "This is the ability to “live off the land,” find safe food and water, avoid hazards, build shelter, etc. To live safely in a wilderness situation, you must make a successful Survival roll once per day. Failure inflicts 2d-4 injury on you and anyone in your care. There are many different types of Survival skill, which must be learned independently.");
            Description.Add("Swimming", "This is the skill of swimming (on purpose or to keep afloat in emergencies) and lifesaving. Roll against the higher of Swimming or HT to avoid fatigue or injury due to aquatic misfortunes.");
            Description.Add("Tactics", "This is the ability to outguess and outmaneuver the enemy in small-unit or personal combat." + Environment.NewLine + Environment.NewLine + "When commanding a small unit, roll against Tactics to place your troops correctly for an ambush, know where to post sentries, etc. In personal combat, you may make a Tactics roll before the fight begins if you had any time to prepare. On a success, you start the fight in an advantageous position – e.g., behind cover or on higher ground – as determined by the GM.");
            Description.Add("Throwing", "This is the ability to throw any small, relatively smooth object that fits in the palm of your hand. Examples include baseballs, hand grenades, and rocks.");
            Description.Add("Thrown Weapon (Axe/Mace)", "Any axe, hatchet, or mace balanced for throwing (but not an unbalanced battleaxe or maul!).");
            Description.Add("Thrown Weapon (Knife)", "Any sort of knife.");
            Description.Add("Thrown Weapon (Shuriken)", "Any sort of hiltless blade, notably shuriken(“ninja stars”).");
            Description.Add("Thrown Weapon (Spear)", "Any sort of spear, javelin, etc.");
            Description.Add("Tracking", "This is the ability to follow a man or an animal by its tracks. Make a Tracking roll to pick up the trail, then roll every 15 minutes to avoid losing it, at a modifier ranging from 0 for soft terrain to -6 for city streets.");
            Description.Add("Traps", "This is the skill of building and nullifying traps. For the purposes of Traps skill, detection devices are “traps.” Thus, this skill covers everything from covered pits to elaborate electronic security systems!");
            Description.Add("Vehicle Skill (Bicycling)", "Each class of vehicle requires a different skill to operate it. Roll once to get under way and again each time a hazard is encountered; failure indicates lost time or even an accident.");
            Description.Add("Vehicle Skill (Boating)","Each class of vehicle requires a different skill to operate it. Roll once to get under way and again each time a hazard is encountered; failure indicates lost time or even an accident.");
            Description.Add("Vehicle Skill (Driving)","Each class of vehicle requires a different skill to operate it. Roll once to get under way and again each time a hazard is encountered; failure indicates lost time or even an accident.");
            Description.Add("Vehicle Skill (Piloting)","Each class of vehicle requires a different skill to operate it. Roll once to get under way and again each time a hazard is encountered; failure indicates lost time or even an accident.");
            Description.Add("Vehicle Skill (Submarine)","Each class of vehicle requires a different skill to operate it. Roll once to get under way and again each time a hazard is encountered; failure indicates lost time or even an accident.");
            Description.Add("Writing", "This is the ability to write in a clear or entertaining manner. A successful roll means the work is readable and accurate.");
        }
    }
}
