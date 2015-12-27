using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Account
{
    public partial class VIP : Form
    {
        public VIP()
        {
            InitializeComponent();
        }

        private bool ReloadAccount = false;
        private int VIPDays = 0;

        private void vipmoneyBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') || (e.KeyChar == 8))
                e.Handled = true;
        }

        private void vipdaysBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') || (e.KeyChar == 8))
                e.Handled = true;
        }

        private void account_Rld_Click(object sender, EventArgs e)
        {
            comboAccount.Items.Clear();
            string Values = "";

            if (normalRBtn.Checked == true)
                Values = "<=";
            else
                Values = ">";

            DBLite.dbMe.Read("SELECT memb___id FROM MEMB_INFO WHERE (SCFVIPDays-DateDiff(dd , out__days,getdate())) " + Values + " 0  ORDER BY memb___id");
            while (DBLite.dbMe.Fetch())
            {
                comboAccount.Items.Add(DBLite.dbMe.GetAsString("memb___id"));
            }
            DBLite.dbMe.Close();

            ReloadAccount = true;
        }

        private void comboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        private void normalRBtn_CheckedChanged(object sender, EventArgs e)
        {
            comboAccount.Items.Clear();
            vipmoneyTxt.Text = "0";
            vipdaysTxt.Text = "0";
            wareTxt.Text = "0";
            VIPDays = 0;
            ReloadAccount = false;
        }

        private void vipRBtn_CheckedChanged(object sender, EventArgs e)
        {
            comboAccount.Items.Clear();
            vipmoneyTxt.Text = "0";
            vipdaysTxt.Text = "0";
            wareTxt.Text = "0";
            VIPDays = 0;
            ReloadAccount = false;
        }

        private void SearchData()
        {
            VIPDays = 0;
            vipmoneyTxt.Text = "0";
            vipdaysTxt.Text = "0";
            wareTxt.Text = "0";
            if (comboAccount.Text != "")
            {
                DBLite.dbMe.Read("SELECT SCFVipDays,SCFVipMoney,SCFWareVipCount FROM MEMB_INFO WHERE memb___id = '" + comboAccount.Text + "'");
                if (DBLite.dbMe.Fetch())
                {
                    vipdaysTxt.Text = DBLite.dbMe.GetAsString("SCFVipDays");
                    VIPDays = Convert.ToInt32(vipdaysTxt.Text);
                    vipmoneyTxt.Text = DBLite.dbMe.GetAsString("SCFVipMoney");
                    wareTxt.Text = DBLite.dbMe.GetAsString("SCFWareVipCount");
                }
                DBLite.dbMe.Close();
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(vipmoneyTxt.Text == "")
            {
                MessageBox.Show("ERROR: Please add vip money");
                return;
            }
            if (vipdaysTxt.Text == "")
            {
                MessageBox.Show("ERROR: Please add vip days");
                return;
            }
            if (wareTxt.Text == "")
            {
                MessageBox.Show("ERROR: Please add Ware Count");
                return;
            }
            
            string Value = " ";
            if (VIPDays.ToString() != vipdaysTxt.Text && VIPDays == 0)
                Value = ",out__days=getdate() ";

            if (Convert.ToInt32(vipdaysTxt.Text) == 0)
            {
                Value += ",SCFIsVip = 0 ";
            }else
            {
                Value += ",SCFIsVip = 1 ";
            }

            DBLite.dbMe.Exec("UPDATE MEMB_INFO SET SCFWareVipCount = " + wareTxt.Text + ",SCFVipMoney = " + vipmoneyTxt.Text + ",SCFVipDays = " + vipdaysTxt.Text + Value + "WHERE memb___id = '" + comboAccount.Text + "'");
            DBLite.dbMe.Close();

            if (comboAccount.SelectedItem != null)
            {
                if (normalRBtn.Checked == true && Convert.ToInt32(vipdaysTxt.Text) != 0)
                {
                    comboAccount.Items.Remove(comboAccount.SelectedItem);
                    vipmoneyTxt.Text = "0";
                    vipdaysTxt.Text = "0";
                    wareTxt.Text = "0";
                    VIPDays = 0;
                }
                else if (vipRBtn.Checked == true && Convert.ToInt32(vipdaysTxt.Text) == 0)
                {
                    comboAccount.Items.Remove(comboAccount.SelectedItem);
                    vipmoneyTxt.Text = "0";
                    vipdaysTxt.Text = "0";
                    wareTxt.Text = "0";
                    VIPDays = 0;
                }
            }

            MessageBox.Show("Account Updated", "Titan Editor", MessageBoxButtons.OK);
        }

        private void accountFind_Click(object sender, EventArgs e)
        {
            Find formFind = new Find();
            formFind.isAccount = true;
            if (formFind.ShowDialog() == DialogResult.OK)
            {
                comboAccount.Text = Extra.FindResult.AccountID;
                SearchData();
            }
        }
    }
}
