using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Character
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        byte[] quest = new byte[50];
        public string AccountName;
        public string CharacterName;

        private void Edit_Load(object sender, EventArgs e)
        {
            DBLite.dbMu.Read("SELECT Name FROM Character WHERE Name <> '" + CharacterName + "'");
            while(DBLite.dbMu.Fetch())
                comboMarry.Items.Add(DBLite.dbMu.GetAsString("Name"));
            DBLite.dbMu.Close();

            labelAccName.Text = AccountName;
            labelChrName.Text = CharacterName;

            DBLite.dbMu.Read("SELECT clevel,leveluppoint,class,experience,quest,strength,dexterity,vitality,energy,leadership,life,mana,money," + ini.ResetField + ",ctlcode,mapnumber,mapposx,mapposy,pklevel,pkcount,pktime,SCFMasterLevel,SCFMasterPoints,SCFGensFamily,SCFGensContribution,SCFMarried,SCFMarryHusbandWife,SCFPCPoints,SCFExtInventory FROM Character WHERE Name = '" + CharacterName + "'");
            DBLite.dbMu.Fetch();

            tbox_lvl.Text = DBLite.dbMu.GetAsString("clevel");
            tbox_lvluppts.Text = DBLite.dbMu.GetAsString("leveluppoint");
            tbox_exp.Text = DBLite.dbMu.GetAsString("experience");
            tbox_str.Text = DBLite.dbMu.GetAsString("strength");
            tbox_dex.Text = DBLite.dbMu.GetAsString("dexterity");
            tbox_vit.Text = DBLite.dbMu.GetAsString("vitality");
            tbox_ene.Text = DBLite.dbMu.GetAsString("energy");
            tbox_cmd.Text = DBLite.dbMu.GetAsString("leadership");
            tbox_life.Text = DBLite.dbMu.GetAsString("life");
            tbox_mana.Text = DBLite.dbMu.GetAsString("mana");
            tbox_zen.Text = DBLite.dbMu.GetAsString("money");
            tbox_reset.Text = DBLite.dbMu.GetAsString(ini.ResetField);
            tbox_map.Text = DBLite.dbMu.GetAsString("mapnumber");
            tbox_x.Text = DBLite.dbMu.GetAsString("mapposx");
            tbox_y.Text = DBLite.dbMu.GetAsString("mapposy");
            tbox_pk_lvl.Text = DBLite.dbMu.GetAsString("pklevel");
            tbox_pk_cnt.Text = DBLite.dbMu.GetAsString("pkcount");
            tbox_pk_time.Text = DBLite.dbMu.GetAsString("pktime");

            int ctlcode = DBLite.dbMu.GetAsInteger("ctlcode");
            int clase = DBLite.dbMu.GetAsInteger("class");
            quest = DBLite.dbMu.GetAsBinary("quest");

            tbox_pcpoints.Text = DBLite.dbMu.GetAsString("SCFPCPoints");

            tbox_MLevel.Text = DBLite.dbMu.GetAsString("SCFMasterLevel");
            tbox_MPoints.Text = DBLite.dbMu.GetAsString("SCFMasterPoints");

            comboGens.SelectedIndex = DBLite.dbMu.GetAsInteger("SCFGensFamily");
            tbox_GensCont.Text = DBLite.dbMu.GetAsString("SCFGensContribution");

            checkMarry.Checked = Convert.ToBoolean(DBLite.dbMu.GetAsInteger("SCFMarried"));
            comboMarry.Text = DBLite.dbMu.GetAsString("SCFMarryHusbandWife");

            textbox_ExtInv.Text = DBLite.dbMu.GetAsString("SCFExtInventory");

            DBLite.dbMu.Close();

            switch (ctlcode)
            {
                case 0:
                    radio_status_normal.Checked = true;
                    break;
                case 32:
                    radio_status_gm.Checked = true;
                    break;
                case 8:
                    radio_status_gm_inv.Checked = true;
                    break;
                case 1:
                    radio_status_ban_char.Checked = true;
                    break;
                case 17:
                    radio_status_ban_item.Checked = true;
                    break;
            }

            switch (clase)
            {
                case 0:
                    dw.Checked = true;
                    break;
                case 1:
                    sm.Checked = true;
                    break;
                case 2:
                    gm.Checked = true;
                    break;
                case 16:
                    dk.Checked = true;
                    break;
                case 17:
                    dk.Checked = true;
                    break;
                case 18:
                    bm.Checked = true;
                    break;
                case 32:
                    elf.Checked = true;
                    break;
                case 33:
                    me.Checked = true;
                    break;
                case 34:
                    he.Checked = true;
                    break;
                case 48:
                    mg.Checked = true;
                    break;
                case 50:
                    dm_mg.Checked = true;
                    break;
                case 64:
                    dl.Checked = true;
                    break;
                case 66:
                    le.Checked = true;
                    break;
                case 80:
                    su.Checked = true;
                    break;
                case 81:
                    bs.Checked = true;
                    break;
                case 82:
                    dm_su.Checked = true;
                    break;
                case 96:
                    rf.Checked = true;
                    break;
                case 97:
                    lf.Checked = true;
                    break;
            }
            
            switch (quest[0])
            {
                case 254:
                    combo_Quest.SelectedIndex = 1;
                    break;
                case 250:
                    combo_Quest.SelectedIndex = 2;
                    break;
                case 234:
                    combo_Quest.SelectedIndex = 3;
                    break;
                case 170:
                    combo_Quest.SelectedIndex = 4;
                    break;
                case 255:
                    combo_Quest.SelectedIndex = 0;
                    break;

                case 0xB0:
                case 0xB1:
                case 0xB2:
                    {
                        combo_Quest.SelectedIndex = 5;
                    } break;

                case 0xB3:
                case 0xB4:
                    {
                        combo_Quest.SelectedIndex = 6;
                    } break;

                case 0xB5:
                case 0xB6:
                    {
                        combo_Quest.SelectedIndex = 7;
                    } break;

                case 0xBA:
                    {
                        combo_Quest.SelectedIndex = 8;
                    } break;
            }            
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string ctlcode = "0";
            string clase = "0";
            byte qbyte = 255;

            if (radio_status_normal.Checked == true)
                ctlcode = "0";
            else if (radio_status_gm.Checked == true)
                ctlcode = "32";
            else if (radio_status_gm_inv.Checked == true)
                ctlcode = "8";
            else if (radio_status_ban_char.Checked == true)
                ctlcode = "1";
            else if (radio_status_ban_item.Checked == true)
                ctlcode = "17";

            if(dw.Checked == true)
                clase = "0";
            else if(sm.Checked == true)
                clase = "1";
            else if(gm.Checked == true)
                clase = "2";
            else if(dk.Checked == true)
                clase = "16";
            else if(bk.Checked == true)
                clase = "17";
            else if(bm.Checked == true)
                clase = "18";
            else if(elf.Checked == true)
                clase = "32";
            else if(me.Checked == true)
                clase = "33";
            else if(he.Checked == true)
                clase = "34";
            else if(su.Checked == true)
                clase = "80";
            else if(bs.Checked == true)
                clase = "81";
            else if(dm_su.Checked == true)
                clase = "82";
            else if(mg.Checked == true)
                clase = "48";
            else if(dm_mg.Checked == true)
                clase = "50";
            else if(dl.Checked == true)
                clase = "64";
            else if(le.Checked == true)
                clase = "66";
            else if(rf.Checked == true)
                clase = "96";
            else if(lf.Checked == true)
                clase = "97";


            switch (combo_Quest.SelectedIndex)
            {
                case 0:
                    qbyte = 255;
                    break;
                case 1:
                    qbyte = 254;
                    break;
                case 2:
                    qbyte = 250;
                    break;
                case 3:
                    qbyte = 234;
                    break;
                case 4:
                    qbyte = 170;
                    break;
                case 5:
                    qbyte = 0xB0;
                    break;
                case 6:
                    qbyte = 0xB3;
                    break;
                case 7:
                    qbyte = 0xB5;
                    break;
                case 8:
                    qbyte = 0xBA;
                    break;
            }
            quest[0] = qbyte;

            byte married = Convert.ToByte(checkMarry.Checked);
            string marryWith = "";
            if (checkMarry.Checked == true)
                marryWith = comboMarry.Text;

            string questStr = "0x" + System.BitConverter.ToString(quest).Replace("-", "");
            DBLite.dbMu.Exec("UPDATE Character SET clevel=" + tbox_lvl.Text + ",leveluppoint=" + tbox_lvluppts.Text + ",class=" + clase + ",experience=" + tbox_exp.Text + ",strength=" + tbox_str.Text + ",dexterity=" + tbox_dex.Text + ",vitality=" + tbox_vit.Text + ",energy=" + tbox_ene.Text + ",leadership=" + tbox_cmd.Text + ",life=" + tbox_life.Text + ",mana=" + tbox_mana.Text + ",money=" + tbox_zen.Text + "," + ini.ResetField + "=" + tbox_reset.Text + ",ctlcode=" + ctlcode + ",mapnumber=" + tbox_map.Text + ",mapposx=" + tbox_x.Text + ",mapposy=" + tbox_y.Text + ",pklevel=" + tbox_pk_lvl.Text + ",pkcount=" + tbox_pk_cnt.Text + ",pktime=" + tbox_pk_time.Text + ",quest=" + questStr + ",SCFMasterLevel=" + tbox_MLevel.Text + ",SCFMasterPoints=" + tbox_MPoints.Text + ",SCFGensFamily=" + comboGens.SelectedIndex + ",SCFGensContribution=" + tbox_GensCont.Text + ",SCFMarried=" + married + ",SCFMarryHusbandWife='" + marryWith + "',SCFPCPoints=" + tbox_pcpoints.Text + ",SCFExtInventory=" + textbox_ExtInv.Text + " WHERE Name = '" + CharacterName + "'");
            DBLite.dbMu.Close();

            MessageBox.Show("Character Edited", "Titan Editor", MessageBoxButtons.OK);
            Close();
        }

        private void button_Skills_Click(object sender, EventArgs e)
        {
            Character.SkillsEdition formSkillsChr = new Character.SkillsEdition();
            formSkillsChr.AccountName = AccountName;
            formSkillsChr.CharacterName = CharacterName;
            formSkillsChr.ShowDialog();
        }

        private void button_Inv_Click(object sender, EventArgs e)
        {
            Character.Item formInv = new Character.Item();
            formInv.CharName = CharacterName;
            formInv.ShowDialog();
        }

        private void checkMarry_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMarry.Checked == false)
            {
                comboMarry.Text = "";
                comboMarry.Enabled = false;
            }
            else
            {
                comboMarry.Enabled = true;
                if(comboMarry.Items.Count > 0)
                    comboMarry.SelectedIndex = 0;
            }
        }
    }
}
