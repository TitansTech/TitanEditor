using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor
{
    public partial class EquipProperty : Form
    {
        EquipItem item = null;

        public EquipProperty()
        {
            InitializeComponent();
        }

        public EquipProperty(EquipItem item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chkEquipZY1.Checked = true;
            chkEquipZY2.Checked = true;
            chkEquipZY3.Checked = true;
            chkEquipZY4.Checked = true;
            chkEquipZY5.Checked = true;
            chkEquipZY6.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chkEquipZY1.Checked = false;
            chkEquipZY2.Checked = false;
            chkEquipZY3.Checked = false;
            chkEquipZY4.Checked = false;
            chkEquipZY5.Checked = false;
            chkEquipZY6.Checked = false;
        }

        public void updateUI(EquipItem item)
        {
            txtName.Text  = item.Name;
            txtEquipCodes.Text  = item.ToString();
            cboEquipLevel.SelectedIndex = item.Level;
            cboEquipExt.SelectedIndex = item.Ext;
            chkEquipJN.Checked = item.JN;
            chkEquipXY.Checked = item.XY;
            chkEquipZY1.Checked = item.ZY1;
            chkEquipZY2.Checked = item.ZY2;
            chkEquipZY3.Checked = item.ZY3;
            chkEquipZY4.Checked = item.ZY4;
            chkEquipZY5.Checked = item.ZY5;
            chkEquipZY6.Checked = item.ZY6;
            txtSerial.Text = item.Serial.ToString();
            //chkEquipSet.Checked = item.Set;

            int set = item.Set;

            if (set == 0)
                chkEquipSet.Checked = false;
            else
            {
                chkEquipSet.Checked = true;
                txtSet.Text = set.ToString();
            }

            txtDurability.Text = Convert.ToString(item.Durability);
            GetSocketVal(item.Socket1, ref comboSock1, ref numericSock1);
            GetSocketVal(item.Socket2, ref comboSock2, ref numericSock2);
            GetSocketVal(item.Socket3, ref comboSock3, ref numericSock3);
            GetSocketVal(item.Socket4, ref comboSock4, ref numericSock4);
            GetSocketVal(item.Socket5, ref comboSock5, ref numericSock5);
            //comboHarmony.SelectedIndex = (item.Harmony & 0xF0) >> 4;
        }

        public void updateData(EquipItem item)
        {
            item.Level = (byte)(cboEquipLevel.SelectedIndex);
            item.Ext = cboEquipExt.SelectedIndex;
            item.JN = chkEquipJN.Checked;
            item.XY = chkEquipXY.Checked;
            item.ZY1 = chkEquipZY1.Checked;
            item.ZY2 = chkEquipZY2.Checked;
            item.ZY3 = chkEquipZY3.Checked;
            item.ZY4 = chkEquipZY4.Checked;
            item.ZY5 = chkEquipZY5.Checked;
            item.ZY6 = chkEquipZY6.Checked;
            item.Serial = Convert.ToInt64(txtSerial.Text);
            //item.Set = chkEquipSet.Checked;

            if (chkEquipSet.Checked == false)
                item.Set = 0;
            else
            {
                item.Set = Convert.ToByte(txtSet.Text);
            }

            item.Durability = Convert.ToByte(txtDurability.Text);
            item.Socket1 = GetSocketNum(comboSock1, numericSock1.Value);
            item.Socket2 = GetSocketNum(comboSock2, numericSock2.Value);
            item.Socket3 = GetSocketNum(comboSock3, numericSock3.Value);
            item.Socket4 = GetSocketNum(comboSock4, numericSock4.Value);
            item.Socket5 = GetSocketNum(comboSock5, numericSock5.Value);

            item.Harmony = 0;
            if (comboHarmony.SelectedItem != null)
            {
                if (comboHarmony.SelectedIndex > 0)
                {
                    item.Harmony |= Convert.ToByte((comboHarmony.SelectedIndex) << 4);
                    item.Harmony |= Convert.ToByte(item.Level & 0x0F);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (null != item)
                updateData(item);
            item = null;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            item = null;
        }

        public void GetSocketVal(byte Sock, ref ComboBox combo, ref NumericUpDown numeric)
        {
            byte Lvl = Convert.ToByte(Sock / 50);
            byte Val = Convert.ToByte(Sock - (Lvl * 50));

            if (Lvl == 0)
                Lvl++;
            else if (Lvl != 5)
                Lvl++;
            numeric.Value = Lvl;

            if (Sock == 0xFF)
            {
                combo.SelectedIndex = 28;
                numeric.Value = 1;
                return;
            }
            else if (Sock == 0)
            {
                combo.SelectedIndex = 0;
                numeric.Value = 1;
                return;
            }

            if (Val >= 1 && Val <= 6)
            {
                combo.SelectedIndex = Val;
            }
            else if (Val >= 11 && Val <= 15)
            {
                combo.SelectedIndex = Val - 4;
            }
            else if (Val >= 17 && Val <= 21)
            {
                combo.SelectedIndex = Val - 5;
            }
            else if (Val >= 22 && Val <= 27)
            {
                combo.SelectedIndex = Val - 5;
            }
            else if (Val >= 30 && Val <= 33)
            {
                combo.SelectedIndex = Val - 7;
            }
            else if (Val == 37)
            {
                combo.SelectedIndex = Val - 10;
            }
        }

        public byte GetSocketNum(ComboBox combo, decimal Level)
        {
            byte sock1 = 0;
            if (combo.SelectedItem == null)
            {
                sock1 = 0;
            }
            else
            {
                byte sockVal = Convert.ToByte(combo.SelectedIndex);
                byte mult = Convert.ToByte(Level - 1);
                if (sockVal >= 1 && sockVal <= 6)
                {
                    sock1 = Convert.ToByte(sockVal + (50 * mult));
                }
                else if (sockVal >= 7 && sockVal <= 11)
                {
                    sock1 = Convert.ToByte((sockVal + 4) + (50 * mult));
                }
                else if (sockVal >= 12 && sockVal <= 16)
                {
                    sock1 = Convert.ToByte((sockVal + 5) + (50 * mult));
                }
                else if (sockVal >= 17 && sockVal <= 22)
                {
                    sock1 = Convert.ToByte((sockVal + 5) + (50 * mult));
                }
                else if (sockVal >= 23 && sockVal <= 26)
                {
                    sock1 = Convert.ToByte((sockVal + 7) + (50 * mult));
                }
                else if (sockVal == 27)
                {
                    sock1 = Convert.ToByte((sockVal + 10) + (50 * mult));
                }
                else if (sockVal == 28)
                {
                    sock1 = 255;
                }
            }
            return sock1;
        }

        private void EquipProperty_Load(object sender, EventArgs e)
        {
            comboSock1.SelectedIndex = 0;
            comboSock2.SelectedIndex = 0;
            comboSock3.SelectedIndex = 0;
            comboSock4.SelectedIndex = 0;
            comboSock5.SelectedIndex = 0;

            comboHarmony.Items.Add("None");

            if (item.Type >= 0 && item.Type <= 4)
            {
                comboHarmony.Items.Add("Min Attack Power");
                comboHarmony.Items.Add("Max Attack Power");
                comboHarmony.Items.Add("Strength Requirement");
                comboHarmony.Items.Add("Agility Requirement");
                comboHarmony.Items.Add("Attack (Max,Min)");
                comboHarmony.Items.Add("Critical Damage");
                comboHarmony.Items.Add("Skill Power");
                comboHarmony.Items.Add("Attack % Rate");
                comboHarmony.Items.Add("SD - Rate");
                comboHarmony.Items.Add("SD Ignore Rate");
            }
            else if (item.Type >= 6 && item.Type <= 11)
            {
                comboHarmony.Items.Add("Defense Power");
                comboHarmony.Items.Add("Max AG");
                comboHarmony.Items.Add("Max HP");
                comboHarmony.Items.Add("HP Auto Rate");
                comboHarmony.Items.Add("MP Auto Rate");
                comboHarmony.Items.Add("Defense Success Rate");
                comboHarmony.Items.Add("Damage Reduction Rate");
                comboHarmony.Items.Add("SD Rate");
            }
            else if (item.Type == 5)
            {
                comboHarmony.Items.Add("Magic Power");
                comboHarmony.Items.Add("Strength Requirement");
                comboHarmony.Items.Add("Agility Requirement");
                comboHarmony.Items.Add("Skill Power");
                comboHarmony.Items.Add("Critical Damage");
                comboHarmony.Items.Add("SD - Rate");
                comboHarmony.Items.Add("Attack % Rate");
                comboHarmony.Items.Add("SD Ignore Rate");
            }
            updateUI(item);
            comboHarmony.SelectedIndex = (item.Harmony & 0xF0) >> 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSerial.Text = item.AutoSerialize().ToString();
        }
    }
}