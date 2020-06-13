using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQ_AC_Calculator
{
    public static class ACSum
    {
        public static int Sum1;
        public static int Sum2;
        public static int Sum3;
        public static int Sum4;
        public static int Sum5;
        public static int Sum6;
        public static int Sum7;
        public static int Sum8;
        public static int Sum8Display;
        public static int classACBonus = 0; //Is 0 unless Monk / Rogue / Beastlord
        public static int weightHardcap; //Monk only
        public static int weightSoftcap; //Monk only
        public static int weightACBonus; //Monk only
        public static int weightACBonusBase; //Monk only
        public static decimal weightACBonusReduction; //Monk only
        public static int weightACPenalty; //Monk only
        public static decimal weightACPenaltyMultiplier; //Monk only
        public static int levelScaler; //Rogue / Beastlord only
        public static int raceACBonus = 0; //Is 0 unless Iksar
        public static int Sum9;
        public static int Sum9Display;
        public static int Sum10;
        public static int Sum10Display;
        public static int Sum11;
        public static int Sum11Display;
        public static int Sum12;
        public static int Sum12Display;
        public static int Sum13;
        public static int Sum13Display;
        public static int Sum14;
        public static int Sum14Display;
        public static int Sum15;
        public static int Sum15Display;
        public static int Sum16;
        public static int Sum16Display;
        public static int Sum17;
        public static int Sum17Display;
        public static int Sum18;
        public static int Sum18Display;
        public static int displayAC;
        public static int Sum19;
        public static int Sum20;
        public static int Sum21;
        public static int Sum22;
        public static int Sum23;
        public static int Sum24;
        public static int realAC;

        //Soft Cap Variables
        public static int Class_Soft_Cap;
        public static decimal Class_Post_Cap_Multiplier;

        public static int shieldACMod;

        public static void Calculate()
        {
            //Place Base_AC Variable into Step 1 variable.
            Sum1 = UserValues.baseAC;

            //Place Worn_AC Variable into Step 2 variable.
            Sum2 = UserValues.wornAC;

            //Check if a shield is equipped. Technically you -could- have a shield with a base AC of 0, but there isn't any other good way to check this
            //Unless used a checkbox or something of Shield Equipped yes/no, but that's dumb and a waste of space.
            if (UserValues.shieldAC > 0)
            {
                //If shield is equipped, add Heroic_Strength divided by 10. Truncate.
                shieldACMod = UserValues.shieldAC + (UserValues.heroicStrength / 10);
            }
            else
            {
                shieldACMod = 0;
            }

            //Place Shield_AC into Step 3 variable.
            Sum3 = shieldACMod;

            //Place Food / Drink AC into Step 4 variable.
            Sum4 = UserValues.foodDrinkAC;

            //Place Tribute_AC into Step 5 Varriable
            Sum5 = UserValues.tributeAC;

            //Total up the previous steps EXCEPT Shield AC and add to Step 6 Variable
            Sum6 = Sum1 + Sum2 + Sum4 + Sum5;

            //Multiply total by 4, then divide by 3 for some reason.
            Sum7 = ((Sum6 * 4) / 3);

            if (UserValues.Level < 50)
            {
                //Check if over the level cap
                if (Sum7 > 25 + (UserValues.Level * 6))
                {
                    //Cap it at the level cap
                    Sum8 = 25 + (UserValues.Level * 6);
                }
            }
            else
                //Give the full amount.
                Sum8 = Sum7;

            //Display AC always shows the full amount, even if level capped.
            Sum8Display = Sum7;

            //Calculate Race Bonus if Iksar
            if (UserValues.characterRace == "Iksar")
            {
                Race_Bonus();
            }

            //Calculate Class Bonus if Monk, Rogue, or Iksar
            if (UserValues.characterRace == "Monk" || UserValues.characterRace == "Rogue" || UserValues.characterRace == "Beastlord")
            {
                Class_Bonus();
            }

            //Add Class and Race bonuses to real and display AC
            Sum9 = Sum8 + classACBonus + raceACBonus;
            Sum9Display = Sum8Display + classACBonus + raceACBonus;

            //Check if AC is less than 0.
            if (Sum9 < 0)
            {
                Sum9 = 0;
            }

            //Calculate NPC / Pet AC
            NPC_AC();

            Class_Defense_Skill_AC();
            Class_Buff_AC();
            Class_AoW_AA_AC();
            Class_HF_AA_AC();

            Sum16 = Sum11 + Sum12 + Sum13 + Sum14 + Sum15;
            Sum16Display = Sum11Display + Sum12Display + Sum13Display + Sum14Display + Sum15Display;

            if (ComputedDefense.functionalAgility > 70)
            {
                Sum17 = (ComputedDefense.functionalAgility / 20);
                Sum17Display = (ComputedDefense.functionalAgility / 20);
            }
            else
            {
                Sum17 = 0;
                Sum17Display = 0;
            }
            Sum18 = Sum16 + Sum17;
            Sum18Display = Sum16Display + Sum17Display;

            if (Sum18 < 0)
                Sum18 = 0;

            displayAC = (Sum18Display + ComputedDefense.CD4) * 1000 / (350 + 497);
            

            Soft_Cap();
        }

        public static void Race_Bonus()
        {
            //Doublecheck if Race is Iksar and if so
            if (UserValues.characterRace == "Iksar")
            {
                //Give them the default bonus.
                raceACBonus = UserValues.Level;

                //Check if the bonus is too low or too high
                if (raceACBonus < 10)
                    //If too lowm, set to minimum value
                    raceACBonus = 10;
                else if (raceACBonus > 35)
                    //If too high, set to maximum value
                    raceACBonus = 35;
            }
            else//If class is not Iksar,
                //Fuck you no bonus
                raceACBonus = 0;
        }

        public static void Class_Bonus()
        {
            //Doublecheck if the Class should be getting a bonus
            switch (UserValues.characterClass)
            {

                case "Monk":
                    //If so, send it to the Monk Class Bonus sub to calculate bonuses and penalties
                    Monk_Class_Bonus();
                    break;
                case "Rogue":
                    //If so, send it to the Rogue Class Bonus sub to calculate bonus
                    Rogue_Class_Bonus();
                    break;
                case "Beastlord":
                    //If so, send it to the Beastlord Class Bonus sub to calculate bonus
                    Beastlord_Class_Bonus();
                    break;
                default:
                    //Fuck you, no bonus
                    classACBonus = 0;
                    break;
            }

        }

        public static void Monk_Class_Bonus()
        {
            if (UserValues.Level >= 1 && UserValues.Level <= 14)
            {
                weightHardcap = 30;
                weightSoftcap = 14;
            }
            else if (UserValues.Level >= 15 && UserValues.Level <= 29)
            {
                weightHardcap = 32;
                weightSoftcap = 15;
            }
            else if (UserValues.Level >= 30 && UserValues.Level <= 44)
            {
                weightHardcap = 34;
                weightSoftcap = 16;
            }
            else if (UserValues.Level >= 45 && UserValues.Level <= 50)
            {
                weightHardcap = 36;
                weightSoftcap = 17;
            }
            else if (UserValues.Level >= 51 && UserValues.Level <= 54)
            {
                weightHardcap = 38;
                weightSoftcap = 18;
            }
            else if (UserValues.Level >= 55 && UserValues.Level <= 59)
            {
                weightHardcap = 40;
                weightSoftcap = 20;
            }
            else if (UserValues.Level >= 60 && UserValues.Level <= 61)
            {
                weightHardcap = 45;
                weightSoftcap = 24;
            }
            else if (UserValues.Level >= 62 && UserValues.Level <= 63)
            {
                weightHardcap = 47;
                weightSoftcap = 24;
            }
            else if (UserValues.Level == 64)
            {
                weightHardcap = 50;
                weightSoftcap = 24;
            }
            else if (UserValues.Level >= 65 && UserValues.Level <= 69)
            {
                weightHardcap = 53;
                weightSoftcap = 26;
            }
            else if (UserValues.Level >= 70 && UserValues.Level <= 74)
            {
                weightHardcap = 53;
                weightSoftcap = 28;
            }
            else if (UserValues.Level >= 75 && UserValues.Level <= 79)
            {
                weightHardcap = 53;
                weightSoftcap = 30;
            }
            else if (UserValues.Level >= 80 && UserValues.Level <= 84)
            {
                weightHardcap = 54;
                weightSoftcap = 31;
            }
            else if (UserValues.Level >= 85 && UserValues.Level <= 89)
            {
                weightHardcap = 55;
                weightSoftcap = 32;
            }
            else if (UserValues.Level >= 90 && UserValues.Level <= 94)
            {
                weightHardcap = 56;
                weightSoftcap = 33;
            }
            else if (UserValues.Level >= 95 && UserValues.Level <= 99)
            {
                weightHardcap = 57;
                weightSoftcap = 34;
            }
            else if (UserValues.Level >= 100 && UserValues.Level <= 104)
            {
                weightHardcap = 58;
                weightSoftcap = 35;
            }
            else if (UserValues.Level >= 105 && UserValues.Level <= 109)
            {
                weightHardcap = 59;
                weightSoftcap = 36;
            }
            else if (UserValues.Level >= 105 && UserValues.Level <= 109)
            {
                weightHardcap = 60;
                weightSoftcap = 37;
            }
            else if (UserValues.Level >= 110 && UserValues.Level <= 114)
            {
                weightHardcap = 61;
                weightSoftcap = 38;
            }
            else if (UserValues.Level >= 115 && UserValues.Level <= 119)
            {
                weightHardcap = 62;
                weightSoftcap = 39;
            }
            else
            {
                MessageBox.Show("Unsupported Level value. The program needs to be updated.");
            }

            //Check if weight is under the hardcap.
            if (UserValues.Weight < weightHardcap)
            {
                //Calculate the base bonus.
                weightACBonusBase = UserValues.Level + 5;
                //Set the bonus to Base Bonus
                weightACBonus = weightACBonusBase;

                //Check if weight is over the softcap to see if the bonus is reduced.
                if (UserValues.Weight > weightSoftcap)
                {
                    //Calculate the reduction
                    weightACBonusReduction = Convert.ToDecimal((UserValues.Weight - weightSoftcap) * 6.66667);
                    //Check if the reduction is higher than the cap on the reduction.
                    if (weightACBonusReduction > 100)
                    {
                        //Cap the reduction
                        weightACBonusReduction = 100;
                    }

                    //Subtract the reduction out of 100 then divide by 100 for some reason.
                    weightACBonusReduction = (100 - weightACBonusReduction) / 100;

                    //Multiply the Bonus by the reduction to find the final AC Bonus.
                    weightACBonus = Convert.ToInt32(weightACBonusBase * weightACBonusReduction);
                }

                //If the AC Bonus is somehow negative
                if (weightACBonus < 0)
                {
                    //Set it to 0
                    weightACBonus = 0;
                }

                //Now multiply it by 4 and then divide by 3 for some reason to find the final AC Bonus value.
                weightACBonus = ((weightACBonus * 4) / 3);
            }
            //Check if weight is over the hardcap to see if a pentaly is applied.
            else if (UserValues.Weight > weightHardcap)
            {
                //Calculate Penalty
                weightACPenalty = UserValues.Level + 5;

                //Calculate Penalty Multiplier
                weightACPenaltyMultiplier = (UserValues.Weight - (weightHardcap - 10)) / 100;

                //Check if Multiplier is > 1 and if so
                if (weightACPenaltyMultiplier > 1)
                {
                    //set it to 1.
                    weightACPenaltyMultiplier = 1;
                }

                //Multiply the penalty by 4 and then divide by 3 for some reason.
                weightACPenalty = ((weightACPenalty * 4) / 3);

                //Multiply the penalty by the multipler to find the final Penalty.
                weightACPenalty = Convert.ToInt32((weightACPenalty * weightACPenaltyMultiplier));
            }
            else//If weight = Hardcap then no bonus or penalty.
            {
                weightACBonus = 0;
            }

            //Check if the Bonus is higher than the penalty to decide which to apply.
            //If Bonus is higher
            if (weightACBonus > weightACPenalty)
            {
                //Add bonus
                classACBonus = weightACBonus;
            }
            //If bonus is lower
            else if (weightACBonus < weightACPenalty)
            {
                //Add penalty
                classACBonus = weightACPenalty;
            }
            else
            {
                //If bonus is the same (aka they are at the hardcap), no bonus or penalty
                classACBonus = 0;
            }
        }

        public static void Rogue_Class_Bonus()
        {
            //Check if level over 30 and if so
            if (UserValues.Level > 30)
            {
                //Set Level_Scaler
                levelScaler = UserValues.Level - 26;
                //Find the value of Capped_Agility
                if (UserValues.cappedAgility < 80)
                    classACBonus = ((levelScaler * 1) / 4);
                else if (UserValues.cappedAgility >= 80 && UserValues.cappedAgility <= 84)
                    classACBonus = ((levelScaler * 2) / 4);
                else if (UserValues.cappedAgility >= 85 && UserValues.cappedAgility <= 89)
                    classACBonus = ((levelScaler * 3) / 4);
                else if (UserValues.cappedAgility >= 90 && UserValues.cappedAgility <= 99)
                    classACBonus = ((levelScaler * 4) / 4);
                else if (UserValues.cappedAgility >= 100)
                    classACBonus = ((levelScaler * 5) / 4);

                //Check if Class_AC_Bonus is over the cap and if so
                if (classACBonus > 12)
                {
                    //Set it to the cap
                    classACBonus = 12;
                }
            }
            else
            {
                //If under level 30 no bonus for you.
                classACBonus = 0;
            }
        }

        public static void Beastlord_Class_Bonus()
        {
            //Check if level over 10 and if so
            if (UserValues.Level > 10)
            {
                //Set Level_Scaler
                levelScaler = UserValues.Level - 6;

                //Find the value of Capped_Agility
                if (UserValues.cappedAgility < 80)
                    classACBonus = ((levelScaler * 1) / 5);
                else if (UserValues.cappedAgility >= 80 && UserValues.cappedAgility <= 84)
                    classACBonus = ((levelScaler * 2) / 5);
                else if (UserValues.cappedAgility >= 85 && UserValues.cappedAgility <= 89)
                    classACBonus = ((levelScaler * 3) / 5);
                else if (UserValues.cappedAgility >= 90 && UserValues.cappedAgility <= 99)
                    classACBonus = ((levelScaler * 4) / 5);
                else if (UserValues.cappedAgility >= 100)
                    classACBonus = ((levelScaler * 5) / 5);

                //Check if Class_AC_Bonus is over the cap and if so
                if (classACBonus > 16)
                    //Set it to the cap
                    classACBonus = 16;
            }
            else//If under level 10 no bonus for you.
                classACBonus = 0;
        }

        public static void NPC_AC()
        {
            switch (UserValues.characterType)
            {
                //Check if the Type is Player
                case "Player": //If no, add nothing

                    Sum10 = Sum9;
                    Sum10Display = Sum9Display;

                    Sum11 = Sum10;
                    Sum11Display = Sum10Display;
                    break;

                case "NPC": //Check if the Type is NPC If so, add the NPC Base AC to REAL AC only
                    Sum10 = Sum9 + UserValues.NPCbaseAC;
                    Sum10Display = Sum9Display;

                    //Do NOT add SPA 397 (Pet AC) to Non-pet NPCs
                    Sum11 = Sum10;
                    Sum11Display = Sum10Display;
                    break;


                case "Pet": //Check if the Type is Pet. If so, add the NPC BASE AC to REAL AC only
                    Sum10 = Sum9 + UserValues.NPCbaseAC;
                    Sum10Display = Sum9Display;

                    //DO add SPA 397 (Pet AC) to Pet NPCs
                    Sum11 = Sum10 + UserValues.petAC;
                    Sum11Display = Sum10Display;
                    break;
            }
        }

        public static void Class_Defense_Skill_AC()
        {
            switch (UserValues.characterClass)
            {
                case "Enchanter":
                    Sum12 = (UserValues.defenseSkill / 2);
                    Sum12Display = (UserValues.defenseSkill / 2);
                    break;
                case "Magician":
                    Sum12 = (UserValues.defenseSkill / 2);
                    Sum12Display = (UserValues.defenseSkill / 2);
                    break;
                case "Necromancer":
                    Sum12 = (UserValues.defenseSkill / 2);
                    Sum12Display = (UserValues.defenseSkill / 2);
                    break;
                case "Wizard":
                    Sum12 = (UserValues.defenseSkill / 2);
                    Sum12Display = (UserValues.defenseSkill / 2);
                    break;
                default:
                    Sum12 = (UserValues.defenseSkill / 3);
                    Sum12Display = (UserValues.defenseSkill / 3);
                    break;
            }
        }

        public static void Class_Buff_AC()
        {
            switch (UserValues.characterClass)
            {
                case "Enchanter":
                    Sum13 = UserValues.buffAC / 3;
                    Sum13Display = UserValues.buffAC / 3;
                    break;
                case "Magician":
                    Sum13 = UserValues.buffAC / 3;
                    Sum13Display = UserValues.buffAC / 3;
                    break;
                case "Necromancer":
                    Sum13 = UserValues.buffAC / 3;
                    Sum13Display = UserValues.buffAC / 3;
                    break;
                case "Wizard":
                    Sum13 = UserValues.buffAC / 3;
                    Sum13Display = UserValues.buffAC / 3;
                    break;
                default:
                    Sum13 = UserValues.buffAC / 4;
                    Sum13Display = UserValues.buffAC / 4;
                    break;
            }
        }

        public static void Class_AoW_AA_AC()
        {
            switch (UserValues.characterClass)
            {
                case "Druid":
                    Sum14 = UserValues.armorofWisdomAC / 3;
                    Sum14Display = UserValues.armorofWisdomAC / 3;
                    break;
                case "Enchanter":
                    Sum14 = UserValues.armorofWisdomAC / 3;
                    Sum14Display = UserValues.armorofWisdomAC / 3;
                    break;
                case "Magician":
                    Sum14 = UserValues.armorofWisdomAC / 3;
                    Sum14Display = UserValues.armorofWisdomAC / 3;
                    break;
                case "Necromancer":
                    Sum14 = UserValues.armorofWisdomAC / 3;
                    Sum14Display = UserValues.armorofWisdomAC / 3;
                    break;
                case "Wizard":
                    Sum14 = UserValues.armorofWisdomAC / 3;
                    Sum14Display = UserValues.armorofWisdomAC / 3;
                    break;
                default:
                    Sum14 = UserValues.armorofWisdomAC / 4;
                    Sum14Display = UserValues.armorofWisdomAC / 4;
                    break;
            }
        }

        public static void Class_HF_AA_AC()
        {

            switch (UserValues.characterClass)
            {
                case "Enchanter":
                    Sum15 = UserValues.herosFortitudeAC / 3;
                    Sum15Display = UserValues.herosFortitudeAC / 3;
                    break;
                case "Magician":
                    Sum15 = UserValues.herosFortitudeAC / 3;
                    Sum15Display = UserValues.herosFortitudeAC / 3;
                    break;
                case "Necromancer":
                    Sum15 = UserValues.herosFortitudeAC / 3;
                    Sum15Display = UserValues.herosFortitudeAC / 3;
                    break;
                case "Wizard":
                    Sum15 = UserValues.herosFortitudeAC / 3;
                    Sum15Display = UserValues.herosFortitudeAC / 3;
                    break;
                default:
                    Sum15 = UserValues.herosFortitudeAC / 4;
                    Sum15Display = UserValues.herosFortitudeAC / 4;
                    break;
            }
        }

        public static void Soft_Cap()
        {
            //Find the correct SoftCap info by checking every entry in ACSoftCaps
            foreach (SoftCap sc in Books.ACSoftCaps)
            {
                //And if the class numbers match and the Levels match,
                if (sc.ClassNumber == UserValues.characterClassNumber && sc.Level == UserValues.Level)
                {
                    //Set the softcaps and multiplier
                    Class_Soft_Cap = sc.Cap;
                    Class_Post_Cap_Multiplier = sc.Multiplier;
                }
            }

            //Multiply the Class Soft Cap by SPA 259 then divide by 100. Add this to the Class Soft Cap to find the new Soft Cap.
            Sum19 = (Class_Soft_Cap * UserValues.softCapMultiplier / 100);
            Sum20 = Class_Soft_Cap + Sum19;

            //Add Shield_AC to Class_Soft_Cap to find the final Soft Cap.
            Sum21 = Sum20 + shieldACMod;
            Class_Soft_Cap = Sum21;


            if (Sum18 > Sum21)
            {
                Sum22 = Sum18 - Class_Soft_Cap;
                Sum23 = Sum21 + Convert.ToInt32(Sum22 * Class_Post_Cap_Multiplier);
                Sum24 = Sum23;
                realAC = Sum24;
            }
            else
            {
                realAC = Sum18;
            }


        }
    }
}
