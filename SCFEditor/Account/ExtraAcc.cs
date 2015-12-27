using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Account
{
    public partial class ExtraAcc : Form
    {
        public string name;

        public ExtraAcc()
        {
            InitializeComponent();
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            DBLite.dbMe.Exec("UPDATE MEMB_INFO SET SCFLuckyCoins = " + tbox_LuckyCoins.Text + ",SCFExtWarehouse = " + tbox_ExtWare.Text + ",WCoin = " + tbox_WCoins.Text + ",WCoinP = " + tbox_WCoinsP.Text + ",GoblinCoin = " + tbox_GoblinCoins.Text + " WHERE memb___id = '" + name + "'");
            DBLite.dbMe.Close();

            MessageBox.Show("Account Updated", "Titan Editor", MessageBoxButtons.OK);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Extra_Load(object sender, EventArgs e)
        {
            DBLite.dbMe.Read("SELECT SCFLuckyCoins,SCFExtWarehouse,WCoin,WCoinP,GoblinCoin FROM MEMB_INFO WHERE memb___id = '" + name + "'");
            DBLite.dbMe.Fetch();
            tbox_LuckyCoins.Text = DBLite.dbMe.GetAsString("SCFLuckyCoins");
            tbox_ExtWare.Text = DBLite.dbMe.GetAsString("SCFExtWarehouse");
            tbox_WCoins.Text = DBLite.dbMe.GetAsString("WCoin");
            tbox_WCoinsP.Text = DBLite.dbMe.GetAsString("WCoinP");
            tbox_GoblinCoins.Text = DBLite.dbMe.GetAsString("GoblinCoin");
            DBLite.dbMe.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbox_LuckyCoins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') || (e.KeyChar == 8))
                e.Handled = true;
        }

        private void tbox_ExtWare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') || (e.KeyChar == 8))
                e.Handled = true;
        }

        private void tbox_WCoins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') || (e.KeyChar == 8))
                e.Handled = true;
        }

        private void tbox_WCoinsP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') || (e.KeyChar == 8))
                e.Handled = true;
        }

        private void tbox_GoblinCoins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') || (e.KeyChar == 8))
                e.Handled = true;
        }
    }
}
