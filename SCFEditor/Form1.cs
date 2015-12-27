using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TitanEditor
{
    public partial class Form1 : Form
    {
        Splash splash = new Splash();

        private bool ReloadAccount = true;

        public Form1()
        {
            InitializeComponent();

        }

        public void ShowSplash()
        {
            splash.TopMost = true;
            splash.ShowDialog();
        }

        public void Account_Reload()
        {
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(ShowSplash);
            th.Start();
            Thread.Sleep(500);

            string Path=Application.StartupPath + @"\Config.ini";

            string ODBC = ini.ReadString("Connection", "ODBC", "MuOnline", Path);
            string ODBCME = ini.ReadString("Connection", "ODBC_Me", "MeMuOnline", Path);
            string User = ini.ReadString("Connection", "User", "sa", Path);
            string Pass = ini.ReadString("Connection", "Password", "654321", Path);
            ini.MD5 = Convert.ToBoolean(ini.ReadInt("Common", "UseMD5", "1", Path));
            ini.ResetField = ini.ReadString("Common", "ResetField", "resets", Path);
            ReloadAccount = Convert.ToBoolean(ini.ReadInt("Common","ReloadAccounts","1",Path));

            bool UseODBC = Convert.ToBoolean(ini.ReadInt("Connection", "UseODBC", "1", Path));
            string SqlServer = ini.ReadString("Connection", "SQLServer", @"ADMIN-PC\SQLEXPRESS", Path);

            ini.MailSender = ini.ReadString("MuMail", "Sender", "", Path);
            ini.MailSubject = ini.ReadString("MuMail", "Subject", "", Path);
            ini.Mail1 = ini.ReadString("MuMail", "Mail1", "", Path);
            ini.Mail2 = ini.ReadString("MuMail", "Mail2", "", Path);
            ini.Mail3 = ini.ReadString("MuMail", "Mail3", "", Path);
            ini.Mail4 = ini.ReadString("MuMail", "Mail4", "", Path);

            if(UseODBC)
            {
                DBLite.dbMe = new DBLite(1);
                DBLite.dbMu = new DBLite(1);
                if (DBLite.dbMe.Connect(ODBCME, User, Pass) == false)
                {
                    th.Abort();
                    MessageBox.Show("Error on connection(1)!");
                    Application.Exit();
                }
                if (DBLite.dbMu.Connect(ODBC, User, Pass) == false)
                {
                    th.Abort();
                    MessageBox.Show("Error on connection(2)!");
                    Application.Exit();
                }
            }else
            {
                DBLite.dbMe = new DBLite(3);
                DBLite.dbMu = new DBLite(3);
                if(DBLite.dbMe.Connect(SqlServer,ODBCME,User,Pass) == false)
                {
                    th.Abort();
                    MessageBox.Show("Error on connection(1)!");
                    Application.Exit();
                }
                if(DBLite.dbMu.Connect(SqlServer,ODBC,User,Pass) == false)
                {
                    th.Abort();
                    MessageBox.Show("Error on connection(2)!");
                    Application.Exit();
                }
            }

            DBLite.mdb = new DBLite(Application.StartupPath + @"\TitanEditor.mdb","");
            if (DBLite.mdb.Connect() == false)
            {
                th.Abort();
                MessageBox.Show("Error on connection(3)!");
                Application.Exit();
            }
            if(ReloadAccount)
                Account_Reload();
            th.Abort();
            this.Focus();
        }

        private void account_Rld_Click(object sender, EventArgs e)
        {
            Account_Reload();
        }

        private void account_Del_Click(object sender, EventArgs e)
        {
            if (comboAccount.Text != "")
            {
                if (comboAccount.SelectedItem != null)
                {
                    if (MessageBox.Show("Do you want to remove the account " + comboAccount.Text + "?", "Titan Editor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DBLite.dbMe.Exec("DELETE FROM MEMB_INFO WHERE memb___id = '" + comboAccount.Text + "'");
                        DBLite.dbMe.Close();
                        DBLite.dbMu.Exec("DELETE FROM Character WHERE AccountID = '" + comboAccount.Text + "'");
                        DBLite.dbMu.Close();
                        DBLite.dbMu.Exec("DELETE FROM AccountCharacter WHERE Id = '" + comboAccount.Text + "'");
                        DBLite.dbMu.Close();
                        DBLite.dbMu.Exec("DELETE FROM warehouse WHERE AccountID = '" + comboAccount.Text + "'");
                        DBLite.dbMu.Close();
                        DBLite.dbMu.Exec("DELETE FROM ExtendedWarehouse WHERE AccountID = '" + comboAccount.Text + "'");
                        DBLite.dbMu.Close();

                        comboAccount.Items.Remove(comboAccount.SelectedItem);
                        comboAccount.Text = "";
                    }
                }                
            }
        }

        private void comboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Character_Reload();
        }

        private void charDel_Click(object sender, EventArgs e)
        {
            if (comboChar.Text != "")
            {
                if (comboChar.SelectedItem != null)
                {
                    if (MessageBox.Show("Do you want to remove the character " + comboChar.Text + "?", "Titan Editor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DBLite.dbMu.Exec("DELETE FROM Character WHERE Name = '" + comboChar.Text + "'");
                        DBLite.dbMu.Close();
                        for (int i = 1; i <= 5; i++)
                        {
                            DBLite.dbMu.Exec("UPDATE AccountCharacter SET GameID" + i + "=NULL WHERE GameID" + i + " = '" + comboChar.Text + "'");
                            DBLite.dbMu.Close();
                        }
                        DBLite.dbMu.Exec("UPDATE AccountCharacter SET GameIDC=NULL WHERE GameIDC = '" + comboChar.Text + "'");
                        DBLite.dbMu.Close();

                        comboChar.Items.Remove(comboChar.SelectedItem);
                        comboChar.Text = "";
                    }
                }                
            }
        }

        private void accountAdd_Click(object sender, EventArgs e)
        {
            Account.Account formAcc = new Account.Account();
            formAcc.name = null;
            if (formAcc.ShowDialog() == DialogResult.OK)
                if (ReloadAccount)
                    Account_Reload();
        }

        private void accountEdit_Click(object sender, EventArgs e)
        {
            if (comboAccount.SelectedItem != null)
            {
                Account.Account formAcc = new Account.Account();
                formAcc.name = comboAccount.Text;
                if (formAcc.ShowDialog() == DialogResult.OK)
                    if (ReloadAccount)
                        Account_Reload();
            }
        }

        private void charAdd_Click(object sender, EventArgs e)
        {
            if (comboAccount.SelectedItem != null)
            {
                if (comboChar.Items.Count < 5)
                {
                    Character.Add formAddChr = new Character.Add();
                    formAddChr.name = comboAccount.Text;
                    if (formAddChr.ShowDialog() == DialogResult.OK)
                        Character_Reload();
                }
            }
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
                    if(!found)
                        comboAccount.Items.Add(Extra.FindResult.AccountID);
                    comboAccount.Text = Extra.FindResult.AccountID;
                }
            }
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
                ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
                Focus();
            }
            else if (e.Button == MouseButtons.Right)
            {
                notifyIcon1.Visible = false;
                Application.Exit();
            }
        }

        private void charEdit_Click(object sender, EventArgs e)
        {
            if (comboAccount.SelectedItem != null && comboChar.SelectedItem != null)
            {
                Character.Edit formEditChr = new Character.Edit();
                formEditChr.AccountName = comboAccount.Text;
                formEditChr.CharacterName = comboChar.Text;
                formEditChr.ShowDialog();
            }
        }

        private void accountWare_Click(object sender, EventArgs e)
        {
            if (comboAccount.SelectedItem != null)
            {
                Account.Warehouse formWare = new Account.Warehouse();
                formWare.AccountName = comboAccount.Text;
                formWare.ShowDialog();
            }
        }

        private void rewardsBtn_Click(object sender, EventArgs e)
        {
            Reward formFew = new Reward();
            if (formFew.ShowDialog() == DialogResult.OK)
            {
                comboAccount.Text = Extra.FindResult.AccountID;
                comboChar.Text = Extra.FindResult.Character;
            }
        }

        private void vipBtn_Click(object sender, EventArgs e)
        {
            Account.VIP formVIP = new Account.VIP();
            formVIP.ShowDialog();
        }

        private void extraAccBtn_Click(object sender, EventArgs e)
        {
            if (comboAccount.SelectedItem != null)
            {
                Account.ExtraAcc formExt = new Account.ExtraAcc();
                formExt.name = comboAccount.Text;
                formExt.ShowDialog();
            }
        }
    }
}
