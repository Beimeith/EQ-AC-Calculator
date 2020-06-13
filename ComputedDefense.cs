using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ_AC_Calculator
{
    public static class ComputedDefense
    {
        //Computed Defense Variables
        public static int CD1;
        public static int functionalAgility;
        public static int agilityBonus;
        public static int CD2;
        public static int CD3;
        public static int drunkennessValue;
        public static decimal drunkennessReduction;
        public static int CD4;

        public static void Calculate()
        {
            //Calculate Computed_Defense_1 by multiplying Defense_Skill by 400, then dividing by 225 and truncating the result.
            CD1 = (UserValues.defenseSkill * 400) / 225;

            //Calculate Functional_Agility by adding Heroic_Agility to Capped_Agility.
            functionalAgility = UserValues.cappedAgility + UserValues.heroicAgility;

            //Calculate Agility_Bonus.
            agilityBonus = ((functionalAgility - 40) * 8000 / 36000) + (UserValues.heroicAgility / 10);

            //Calculate Computed_Defense_2 by adding Agility_Bonus to CD1.
            CD2 = CD1 + agilityBonus;

            //Calculate Computed_Defense_3 by adding Item_Avoidence to CD2.
            CD3 = CD2 + UserValues.itemAvoidence;

            //Divide Drunkenness by 2 for some reason,
            drunkennessValue = UserValues.Drunkenness / 2;

            //Then subtract it from 110 and divide by 100 for some reason.
            drunkennessReduction = (110 - drunkennessValue) / 100;

            //Check if the Drunkenness Reduction is greater than 1 (100%).
            if (drunkennessReduction > 1)
            {
                //If it is, set it to 1 (100%).
                drunkennessReduction = 1;
            }

            //Calculate Computed_Defense_4 by multiplying CD3 by Drunkenness_Reduction and truncating the result.
            CD4 = Convert.ToInt32(CD3 * drunkennessReduction);

            //Check if Computed_Defense_4 is less than one.
            //If it is,
            if (CD4 < 1)
            {
                //set it to one.
                CD4 = 1;
            }
        }
    }
}
