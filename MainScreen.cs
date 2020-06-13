using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQ_AC_Calculator
{
    public partial class MainScreen : Form
    {
        const int MaxLevel = 115;
        
        

        

        

        public MainScreen()
        {
            InitializeComponent();
            Books.Load_Books();
            Set_DropDowns();
        }

        private void Set_DropDowns()
        {
            //Populate level DropDown Box.
            for (int i = 1; i <= MaxLevel; ++i)
            {
                DD_Level.Items.Add(i);
            }

            //Set initial selections for each DropDown.

            DD_Level.SelectedIndex = 0;//Set Level to 1.
            DD_Class.SelectedIndex = 0;//Set Class to Bard.
            DD_Race.SelectedIndex = 0;//Set Race to Barbarian.
            DD_Character_Type.SelectedIndex = 0;//Set Character Type to Player.
        }

        

        private void B_Calculate_Click(object sender, EventArgs e)
        {
            ComputedDefense.Calculate();
            ACSum.Calculate();
            L_Display_AC_Result.Text = ACSum.displayAC.ToString();
            L_Real_AC_Result.Text = ACSum.realAC.ToString();

        }
      
        #region MenuBar Items Clicked

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reset everything to starting values
            DD_Level.SelectedIndex = 0;
            TB_Defense_Skill_Value.Text = "0";
            TB_Capped_Agility_Value.Text = "0";
            TB_Heroic_Agility_Value.Text = "0";
            TB_Heroic_Strength_Value.Text = "0";
            TB_Item_Avoidence_Value.Text = "0";
            TB_Worn_AC_Value.Text = "0";
            TB_Shield_AC_Value.Text = "0";
            TB_Food_Drink_AC_Value.Text = "0";
            TB_Tribute_AC_Value.Text = "0";
            TB_Heros_Fortitude_Value.Text = "0";
            TB_Soft_Cap.Text = "0";
            TB_Buff_AC_Value.Text = "0";
            TB_Armor_of_Wisdom_Value.Text = "0";
            TB_Drunkenness.Text = "0";
            DD_Race.SelectedIndex = 0;
            DD_Character_Type.SelectedIndex = 0;
            TB_Base_AC_Value.Text = "0";
            TB_NPC_Base_AC_Value.Text = "0";
            TB_Pet_AC_Value.Text = "0";
            DD_Class.SelectedIndex = 0;
            TB_Weight_Value.Text = "0";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Details Details = new Details(this);
            Details.Show();

            B_Calculate.PerformClick();
            
            //'Fill the Details Listview with values.
            Details.LV_Details.Items[0].SubItems[1].Text = UserValues.Level.ToString();
            Details.LV_Details.Items[1].SubItems[1].Text = UserValues.defenseSkill.ToString();
            Details.LV_Details.Items[2].SubItems[1].Text = UserValues.cappedAgility.ToString();
            Details.LV_Details.Items[3].SubItems[1].Text = UserValues.heroicAgility.ToString();
            Details.LV_Details.Items[4].SubItems[1].Text = UserValues.heroicStrength.ToString();
            Details.LV_Details.Items[5].SubItems[1].Text = UserValues.itemAvoidence.ToString();
            Details.LV_Details.Items[6].SubItems[1].Text = UserValues.wornAC.ToString();
            Details.LV_Details.Items[7].SubItems[1].Text = UserValues.shieldAC.ToString();
            Details.LV_Details.Items[8].SubItems[1].Text = UserValues.foodDrinkAC.ToString();
            Details.LV_Details.Items[9].SubItems[1].Text = UserValues.tributeAC.ToString();
            Details.LV_Details.Items[10].SubItems[1].Text = UserValues.herosFortitudeAC.ToString();
            Details.LV_Details.Items[11].SubItems[1].Text = UserValues.softCapMultiplier.ToString();
            Details.LV_Details.Items[12].SubItems[1].Text = UserValues.buffAC.ToString();
            Details.LV_Details.Items[13].SubItems[1].Text = UserValues.armorofWisdomAC.ToString();
            Details.LV_Details.Items[14].SubItems[1].Text = UserValues.Drunkenness.ToString();
            Details.LV_Details.Items[15].SubItems[1].Text = UserValues.characterRace.ToString();
            Details.LV_Details.Items[16].SubItems[1].Text = UserValues.characterType;
            Details.LV_Details.Items[17].SubItems[1].Text = UserValues.baseAC.ToString();
            Details.LV_Details.Items[18].SubItems[1].Text = UserValues.NPCbaseAC.ToString();
            Details.LV_Details.Items[19].SubItems[1].Text = UserValues.petAC.ToString();
            Details.LV_Details.Items[20].SubItems[1].Text = UserValues.characterClass;
            Details.LV_Details.Items[21].SubItems[1].Text = UserValues.Weight.ToString();
            Details.LV_Details.Items[22].SubItems[1].Text = ComputedDefense.CD1.ToString();
            Details.LV_Details.Items[23].SubItems[1].Text = ComputedDefense.functionalAgility.ToString();
            Details.LV_Details.Items[24].SubItems[1].Text = ComputedDefense.agilityBonus.ToString();
            Details.LV_Details.Items[25].SubItems[1].Text = ComputedDefense.CD2.ToString();
            Details.LV_Details.Items[26].SubItems[1].Text = ComputedDefense.CD3.ToString();
            Details.LV_Details.Items[27].SubItems[1].Text = ComputedDefense.drunkennessValue.ToString();
            Details.LV_Details.Items[28].SubItems[1].Text = ComputedDefense.drunkennessReduction.ToString();
            Details.LV_Details.Items[29].SubItems[1].Text = ComputedDefense.CD4.ToString();
            Details.LV_Details.Items[30].SubItems[1].Text = ACSum.Class_Soft_Cap.ToString();
            Details.LV_Details.Items[31].SubItems[1].Text = ACSum.Class_Post_Cap_Multiplier.ToString();
            Details.LV_Details.Items[32].SubItems[1].Text = ACSum.shieldACMod.ToString();


            Details.LV_Details.Items[0].SubItems[3].Text = ACSum.Sum1.ToString();
            Details.LV_Details.Items[1].SubItems[3].Text = ACSum.Sum2.ToString();
            Details.LV_Details.Items[2].SubItems[3].Text = ACSum.Sum3.ToString();
            Details.LV_Details.Items[3].SubItems[3].Text = ACSum.Sum4.ToString();
            Details.LV_Details.Items[4].SubItems[3].Text = ACSum.Sum5.ToString();
            Details.LV_Details.Items[5].SubItems[3].Text = ACSum.Sum6.ToString();
            Details.LV_Details.Items[6].SubItems[3].Text = ACSum.Sum7.ToString();
            Details.LV_Details.Items[7].SubItems[3].Text = ACSum.Sum8.ToString();
            Details.LV_Details.Items[8].SubItems[3].Text = ACSum.Sum8Display.ToString();
            Details.LV_Details.Items[9].SubItems[3].Text = ACSum.Sum9.ToString();
            Details.LV_Details.Items[10].SubItems[3].Text = ACSum.Sum9Display.ToString();
            Details.LV_Details.Items[11].SubItems[3].Text = ACSum.Sum10.ToString();
            Details.LV_Details.Items[12].SubItems[3].Text = ACSum.Sum10Display.ToString();
            Details.LV_Details.Items[13].SubItems[3].Text = ACSum.Sum11.ToString();
            Details.LV_Details.Items[14].SubItems[3].Text = ACSum.Sum11Display.ToString();
            Details.LV_Details.Items[15].SubItems[3].Text = ACSum.Sum12.ToString();
            Details.LV_Details.Items[16].SubItems[3].Text = ACSum.Sum12Display.ToString();
            Details.LV_Details.Items[17].SubItems[3].Text = ACSum.Sum13.ToString();
            Details.LV_Details.Items[18].SubItems[3].Text = ACSum.Sum13Display.ToString();
            Details.LV_Details.Items[19].SubItems[3].Text = ACSum.Sum14.ToString();
            Details.LV_Details.Items[20].SubItems[3].Text = ACSum.Sum14Display.ToString();
            Details.LV_Details.Items[21].SubItems[3].Text = ACSum.Sum15.ToString();
            Details.LV_Details.Items[22].SubItems[3].Text = ACSum.Sum15Display.ToString();
            Details.LV_Details.Items[23].SubItems[3].Text = ACSum.Sum16.ToString();
            Details.LV_Details.Items[24].SubItems[3].Text = ACSum.Sum16Display.ToString();
            Details.LV_Details.Items[25].SubItems[3].Text = ACSum.Sum17.ToString();
            Details.LV_Details.Items[26].SubItems[3].Text = ACSum.Sum17Display.ToString();
            Details.LV_Details.Items[27].SubItems[3].Text = ACSum.Sum18.ToString();
            Details.LV_Details.Items[28].SubItems[3].Text = ACSum.Sum18Display.ToString();
            Details.LV_Details.Items[29].SubItems[3].Text = ACSum.displayAC.ToString();
            Details.LV_Details.Items[30].SubItems[3].Text = ACSum.Sum19.ToString();
            Details.LV_Details.Items[31].SubItems[3].Text = ACSum.Sum20.ToString();
            Details.LV_Details.Items[32].SubItems[3].Text = ACSum.Sum21.ToString();
            Details.LV_Details.Items[33].SubItems[3].Text = ACSum.Sum22.ToString();
            Details.LV_Details.Items[34].SubItems[3].Text = ACSum.Sum23.ToString();
            Details.LV_Details.Items[35].SubItems[3].Text = ACSum.Sum24.ToString();
            Details.LV_Details.Items[36].SubItems[3].Text = ACSum.realAC.ToString();
        }

        private void InstructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExampleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetToolStripMenuItem.PerformClick();

            DD_Level.SelectedIndex = 104;
            TB_Defense_Skill_Value.Text = "400";
            TB_Capped_Agility_Value.Text = "790";
            TB_Heroic_Agility_Value.Text = "407";
            TB_Heroic_Strength_Value.Text = "324";
            TB_Item_Avoidence_Value.Text = "100";
            TB_Worn_AC_Value.Text = "5860";
            TB_Shield_AC_Value.Text = "340";
            TB_Food_Drink_AC_Value.Text = "153";
            TB_Tribute_AC_Value.Text = "0";
            TB_Heros_Fortitude_Value.Text = "100";
            TB_Soft_Cap.Text = "82";
            TB_Buff_AC_Value.Text = "4444";
            TB_Armor_of_Wisdom_Value.Text = "620";
            TB_Drunkenness.Text = "0";
            DD_Race.SelectedIndex = 10;
            DD_Character_Type.SelectedIndex = 0;
            TB_Base_AC_Value.Text = "0";
            TB_NPC_Base_AC_Value.Text = "0";
            TB_Pet_AC_Value.Text = "0";
            DD_Class.SelectedIndex = 9;
            TB_Weight_Value.Text =" 0";
            B_Calculate.PerformClick();
        }

        private void ExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetToolStripMenuItem.PerformClick();

            //Fill with Sample values
            DD_Level.SelectedIndex = 104;
            TB_Defense_Skill_Value.Text = "330";
            TB_Capped_Agility_Value.Text = "790";
            TB_Heroic_Agility_Value.Text = "329";
            TB_Heroic_Strength_Value.Text = "245";
            TB_Item_Avoidence_Value.Text = "100";
            TB_Worn_AC_Value.Text = "3631";
            TB_Shield_AC_Value.Text = "0";
            TB_Food_Drink_AC_Value.Text = "4";
            TB_Tribute_AC_Value.Text = "0";
            TB_Heros_Fortitude_Value.Text = "100";
            TB_Soft_Cap.Text = "80";
            TB_Buff_AC_Value.Text = "4444";
            TB_Armor_of_Wisdom_Value.Text = "840";
            TB_Drunkenness.Text = "0";
            DD_Race.SelectedIndex = 9;
            DD_Character_Type.SelectedIndex = 0;
            TB_Base_AC_Value.Text = "0";
            TB_NPC_Base_AC_Value.Text = "0";
            TB_Pet_AC_Value.Text = "0";
            DD_Class.SelectedIndex = 15;
            TB_Weight_Value.Text = "0";
            B_Calculate.PerformClick();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Beimeith of Cazic", "About EQ AC Calculator v2.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        #endregion

        #region Values Changed

        private void Input_Validation(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;

            if (control.Name.Contains("DD"))
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void DD_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserValues.Level = Convert.ToInt32(DD_Level.SelectedItem);
        }

        private void TB_Defense_Skill_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Defense_Skill_Value.Text))
                {
                    UserValues.defenseSkill = Convert.ToInt32(TB_Defense_Skill_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Defense Skill.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Defense_Skill_Value.Clear();
                TB_Defense_Skill_Value.Focus();
            }
        }

        private void TB_Capped_Agility_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Capped_Agility_Value.Text))
                {
                    UserValues.cappedAgility = Convert.ToInt32(TB_Capped_Agility_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Capped Agility.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Capped_Agility_Value.Clear();
                TB_Capped_Agility_Value.Focus();
            }
        }

        private void TB_Heroic_Agility_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Heroic_Agility_Value.Text))
                {
                    UserValues.heroicAgility = Convert.ToInt32(TB_Heroic_Agility_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Heroic Agility.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Heroic_Agility_Value.Clear();
                TB_Heroic_Agility_Value.Focus();
            }
        }

        private void TB_Heroic_Strength_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Heroic_Strength_Value.Text))
                {
                    UserValues.heroicStrength = Convert.ToInt32(TB_Heroic_Strength_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Heroic Strength.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Heroic_Strength_Value.Clear();
                TB_Heroic_Strength_Value.Focus();
            }
        }

        private void TB_Item_Avoidence_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Item_Avoidence_Value.Text))
                {
                    UserValues.itemAvoidence = Convert.ToInt32(TB_Item_Avoidence_Value.Text);
                    
                    //Item Avoidence is capped at 300. Ensure a value greater than this wasn't entered.
                    if (UserValues.itemAvoidence > 300)
                    {
                        MessageBox.Show("You cannot have more than 300 Item Avoidence. Please enter a value of 300 or less.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        TB_Item_Avoidence_Value.Clear();
                        TB_Item_Avoidence_Value.Focus();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Capped Agility.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Item_Avoidence_Value.Clear();
                TB_Item_Avoidence_Value.Focus();
            }
        }

        private void TB_Worn_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Worn_AC_Value.Text))
                {
                    UserValues.wornAC = Convert.ToInt32(TB_Worn_AC_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Worn AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Worn_AC_Value.Clear();
                TB_Worn_AC_Value.Focus();
            }
        }

        private void TB_Shield_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Shield_AC_Value.Text))
                {
                    UserValues.shieldAC = Convert.ToInt32(TB_Shield_AC_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Shield AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Shield_AC_Value.Clear();
                TB_Shield_AC_Value.Focus();
            }
        }

        private void TB_Food_Drink_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Food_Drink_AC_Value.Text))
                {
                    UserValues.foodDrinkAC = Convert.ToInt32(TB_Food_Drink_AC_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Food/Drink AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Food_Drink_AC_Value.Clear();
                TB_Food_Drink_AC_Value.Focus();
            }
        }

        private void TB_Tribute_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Tribute_AC_Value.Text))
                {
                    UserValues.tributeAC = Convert.ToInt32(TB_Tribute_AC_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Tribute AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Tribute_AC_Value.Clear();
                TB_Tribute_AC_Value.Focus();
            }
        }

        private void TB_Heros_Fortitude_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Heros_Fortitude_Value.Text))
                {
                    UserValues.herosFortitudeAC = Convert.ToInt32(TB_Heros_Fortitude_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Hero's Fortitude.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Heros_Fortitude_Value.Clear();
                TB_Heros_Fortitude_Value.Focus();
            }
        }

        private void TB_SoFt_Cap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Soft_Cap.Text))
                {
                    UserValues.softCapMultiplier = Convert.ToInt32(TB_Soft_Cap.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Soft Cap.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Soft_Cap.Clear();
                TB_Soft_Cap.Focus();
            }
        }

        private void TB_Buff_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Buff_AC_Value.Text))
                {
                    UserValues.buffAC = Convert.ToInt32(TB_Buff_AC_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Buff AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Buff_AC_Value.Clear();
                TB_Buff_AC_Value.Focus();
            }
        }

        private void TB_Armor_of_Wisdom_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Armor_of_Wisdom_Value.Text))
                {
                    UserValues.armorofWisdomAC = Convert.ToInt32(TB_Armor_of_Wisdom_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Armor of Wisdom.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Armor_of_Wisdom_Value.Clear();
                TB_Armor_of_Wisdom_Value.Focus();
            }
        }

        private void TB_Drunkenness_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Drunkenness.Text))
                {
                    UserValues.Drunkenness = Convert.ToInt32(TB_Drunkenness.Text);
                    
                    //Drunkenness is capped at 200. Ensure a value greater than this wasn't entered.
                    if (UserValues.Drunkenness > 200)
                    {
                        MessageBox.Show("Drunkenness cannot be greater than 200", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        TB_Drunkenness.Clear();
                        TB_Drunkenness.Focus();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Drunkenness.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Drunkenness.Clear();
                TB_Drunkenness.Focus();
            }
        }

        private void DD_Race_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserValues.characterRace = DD_Race.SelectedItem.ToString();
        }

        private void DD_Character_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserValues.characterType = DD_Character_Type.SelectedItem.ToString();

            switch (UserValues.characterType)
            {
                case "Player":
                    //Disable Base, NPC, and Pet AC boxes.
                    TB_Base_AC_Value.Enabled = false;
                    TB_NPC_Base_AC_Value.Enabled = false;
                    TB_Pet_AC_Value.Enabled = false;
                    break;
                case "Shroud":
                    //Enable Base but disable NPC and Pet AC boxes.
                    TB_Base_AC_Value.Enabled = true;
                    TB_NPC_Base_AC_Value.Enabled = false;
                    TB_Pet_AC_Value.Enabled = false;
                    break;
                case "NPC":
                    //Enable NPC but disable Base and Pet AC boxes.
                    TB_Base_AC_Value.Enabled = false;
                    TB_NPC_Base_AC_Value.Enabled = true;
                    TB_Pet_AC_Value.Enabled = false;
                    break;
                case "Pet":
                    //Enable NPC and Pet but disable Base AC boxes.
                    TB_Base_AC_Value.Enabled = false;
                    TB_NPC_Base_AC_Value.Enabled = true;
                    TB_Pet_AC_Value.Enabled = true;
                    break;
            }
        }

        private void TB_Base_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Base_AC_Value.Text))
                {
                    UserValues.baseAC = Convert.ToInt32(TB_Base_AC_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Base AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Base_AC_Value.Clear();
                TB_Base_AC_Value.Focus();
            }
        }

        private void TB_NPC_Base_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_NPC_Base_AC_Value.Text))
                {
                    UserValues.NPCbaseAC = Convert.ToInt32(TB_NPC_Base_AC_Value.Text);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Base AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_NPC_Base_AC_Value.Clear();
                TB_NPC_Base_AC_Value.Focus();
            }
        }

        private void TB_Pet_AC_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Pet_AC_Value.Text))
                {
                    UserValues.petAC = Convert.ToInt32(TB_Pet_AC_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Pet AC.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Pet_AC_Value.Clear();
                TB_Pet_AC_Value.Focus();
            }
        }

        private void DD_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserValues.characterClass = DD_Class.SelectedItem.ToString();
            UserValues.characterClassNumber = Books.Get_Class_Number(UserValues.characterClass);

            //Enable Weight TextBox for Monks.
            if (UserValues.characterClass == "Monk")
            {
                TB_Weight_Value.Enabled = true;
            }
            else
            {
                TB_Weight_Value.Enabled = false;
            }
        }

        private void TB_Weight_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_Weight_Value.Text))
                {
                    UserValues.Weight = Convert.ToInt32(TB_Weight_Value.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid entry for Weight.", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                TB_Weight_Value.Clear();
                TB_Weight_Value.Focus();
            }
        }

        #endregion

        
    }
}
