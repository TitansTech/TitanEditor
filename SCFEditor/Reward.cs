using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor
{
    public partial class Reward : Form
    {
        bool ReloadAccount = false;
        public Reward()
        {
            InitializeComponent();
        }

        private void Reward_Load(object sender, EventArgs e)
        {
            equipEditor1.LoadData();
        }

        private void addReward_Click(object sender, EventArgs e)
        {
            if (comboAccount.Text == "")
            {
                MessageBox.Show(string.Format("[Error] Write a Account Name First"));
                return;
            }

            if (comboChar.Text == "")
            {
                MessageBox.Show(string.Format("[Error] Write a Character Name First"));
                return;
            }
            
            if (equipEditor1.EditItem == null && itemcheckBox.Checked == true)
            {
                MessageBox.Show(string.Format("[Error] Add an Item First"));
                return;
            }

            int ItemID = -1;
            if (equipEditor1.EditItem != null && itemcheckBox.Checked == true)
            {
                ItemID = (equipEditor1.EditItem.Type * 512 + equipEditor1.EditItem.Code);
                equipEditor1.updateData(equipEditor1.EditItem);

                int ExcCnt = 0;
                if (equipEditor1.EditItem.ZY1 == true)
                    ExcCnt += 1;
                if (equipEditor1.EditItem.ZY2 == true)
                    ExcCnt += 0x02;
                if (equipEditor1.EditItem.ZY3 == true)
                    ExcCnt += 0x04;
                if (equipEditor1.EditItem.ZY4 == true)
                    ExcCnt += 0x08;
                if (equipEditor1.EditItem.ZY5 == true)
                    ExcCnt += 0x10;
                if (equipEditor1.EditItem.ZY6 == true)
                    ExcCnt += 0x20;
                bool result = DBLite.dbMu.Exec("INSERT INTO Titan_Rewards (AccountID,Name,Zen,VIPMoney,Num,Lvl,Opt,Luck,Skill,Dur,Excellent,Ancient,JOH,Sock1,Sock2,Sock3,Sock4,Sock5,Days) VALUES ('" +
                    comboAccount.Text +
                    "', '" + comboChar.Text +
                    "', " + Zen.Text +
                    ", " + VIPMoney.Text +
                    ", " + ItemID +
                    ", " + equipEditor1.EditItem.Level +
                    ", " + equipEditor1.EditItem.Ext +
                    ", " + Convert.ToInt32(equipEditor1.EditItem.XY) +
                    ", " + Convert.ToInt32(equipEditor1.EditItem.JN) +
                    ", " + equipEditor1.EditItem.Durability +
                    ", " + ExcCnt +
                    ", " + equipEditor1.EditItem.Set +
                    ", " + equipEditor1.EditItem.Harmony +
                    ", " + equipEditor1.EditItem.Socket1 +
                    ", " + equipEditor1.EditItem.Socket2 +
                    ", " + equipEditor1.EditItem.Socket3 +
                    ", " + equipEditor1.EditItem.Socket4 +
                    ", " + equipEditor1.EditItem.Socket5 +
                    ", " + Days.Text + ")");
                DBLite.dbMu.Close();

                if (result == true)
                    MessageBox.Show(string.Format("[Success] Reward Added"));
                else
                    MessageBox.Show(string.Format("[Error] Cant add reward!!"));
            }
            else
            {
                bool result = DBLite.dbMu.Exec("INSERT INTO Titan_Rewards (AccountID,Name,Zen,VIPMoney,Num,Lvl,Opt,Luck,Skill,Dur,Excellent,Ancient,JOH,Sock1,Sock2,Sock3,Sock4,Sock5,Days) VALUES ('" +
                    comboAccount.Text +
                    "', '" + comboChar.Text +
                    "', " + Zen.Text +
                    ", " + VIPMoney.Text +
                    ", " + ItemID +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 +
                    ", " + 0 + ")");
                DBLite.dbMu.Close();

                if (result == true)
                    MessageBox.Show(string.Format("[Success] Reward Added"));
                else
                    MessageBox.Show(string.Format("[Error] Cant add reward!!"));
            }

            string eMail = "";

            if (itemcheckBox.Checked == true)
                eMail += string.Format(ini.Mail1, equipEditor1.EditItem.Name);

            if(Convert.ToInt32(Zen.Text) > 0)
                eMail += string.Format(ini.Mail2, Zen.Text);

            if (Convert.ToInt32(VIPMoney.Text) > 0)
                eMail += string.Format(ini.Mail3, VIPMoney.Text);

            eMail += ini.Mail4;

            DBLite.dbMu.Exec("exec TT_WriteMemoMail '" + ini.MailSender + "','" + comboChar.Text + "','" + ini.MailSubject + "','     " + eMail + "',143,27");
            DBLite.dbMu.Close();
        }

        public void Account_Reload()
        {
            ReloadAccount = true;
            comboChar.Text = "";
            comboChar.Items.Clear();
            comboAccount.Text = "";
            comboAccount.Items.Clear();
            DBLite.dbMe.Read("SELECT memb___id FROM MEMB_INFO ORDER BY memb___id");
            while (DBLite.dbMe.Fetch())
            {
                comboAccount.Items.Add(DBLite.dbMe.GetAsString("memb___id"));
            }
            DBLite.dbMe.Close();
        }
        public void Character_Reload()
        {
            comboChar.Text = "";
            comboChar.Items.Clear();
            if (comboAccount.SelectedItem != null)
            {
                DBLite.dbMu.Read("SELECT Name FROM Character WHERE AccountID = '" + comboAccount.Text + "' ORDER BY Name");
                while (DBLite.dbMu.Fetch())
                {
                    comboChar.Items.Add(DBLite.dbMu.GetAsString("Name"));
                }
                DBLite.dbMu.Close();
            }
        }

        private void account_Rld_Click(object sender, EventArgs e)
        {
            Account_Reload();
        }

        private void comboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Character_Reload();
        }

        private void accountFind_Click(object sender, EventArgs e)
        {
            Find formFind = new Find();
            formFind.isAccount = true;
            if (formFind.ShowDialog() == DialogResult.OK)
            {
                comboChar.Text = "";
                comboChar.Items.Clear();

                if (ReloadAccount)
                    comboAccount.Text = Extra.FindResult.AccountID;
                else
                {
                    bool found = false;
                    for (int i = 0; i < comboAccount.Items.Count; i++)
                    {
                        if (comboAccount.Items[i].ToString() == Extra.FindResult.AccountID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        comboAccount.Items.Add(Extra.FindResult.AccountID);
                    comboAccount.Text = Extra.FindResult.AccountID;
                }
            }
        }

        private void itemcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = itemcheckBox.Checked;
        }

        private void charFind_Click(object sender, EventArgs e)
        {
            Find formFind = new Find();
            formFind.isAccount = false;
            if (formFind.ShowDialog() == DialogResult.OK)
            {
                comboAccount.Text = Extra.FindResult.AccountID;
                comboChar.Text = Extra.FindResult.Character;
            }
        }
    }
}
