using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Account
{
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        public string AccountName;

        struct warehouses
        {
            public int Num;
            public byte[] items;
            public int Money;
        }
        warehouses[] ware = new warehouses[1];

        protected void loadAllWare(string accountName)
        {
            try
            {
                DBLite.dbMu.Read("select Items,money from warehouse where AccountID = '" + accountName + "'");
                DBLite.dbMu.Fetch();
                ware[0].Num = 0;
                ware[0].items = DBLite.dbMu.GetAsBinary("Items");
                ware[0].Money = DBLite.dbMu.GetAsInteger("money");
                DBLite.dbMu.Close();
                comboVault.Items.Add("0");

                DBLite.dbMu.Read("SELECT items,SCFExtWare,money FROM ExtendedWarehouse WHERE AccountID = '" + accountName + "'");
                while (DBLite.dbMu.Fetch())
                {
                    int val = ware.Length;
                    Array.Resize(ref ware, val + 1);
                    ware[val].items = DBLite.dbMu.GetAsBinary("Items");
                    ware[val].Num = DBLite.dbMu.GetAsInteger("SCFExtWare");
                    ware[val].Money = DBLite.dbMu.GetAsInteger("money");
                    comboVault.Items.Add(ware[val].Num.ToString());
                }
                DBLite.dbMu.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int GetWareNum(int index)
        {
            for (int i = 0; i < ware.Length; i++)
            {
                if (ware[i].Num == index)
                    return i;
            }
            return -1;
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            Text = AccountName + " Warehouse";
            equipPanel1.setSize(8, 15);
            equipPanel1.Editor = equipEditor1;
            equipPanel2.setSize(8, 15);
            equipPanel2.Editor = equipEditor1;
            equipEditor1.LoadData();

            loadAllWare(AccountName);
            if (ware[0].items != null)
            {
                comboVault.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Vault its not created!", "Titan Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = GetWareNum(comboVault.SelectedIndex);
            if(index != -1)
            {
                string sql;
                if (comboVault.SelectedIndex == 0)
                    sql = string.Format("update warehouse set Items=0x{0}{1}, Money = {2} where AccountId = '{3}'", equipPanel1.getEquipCodes(), equipPanel2.getEquipCodes(), tbox_zen.Text, AccountName);
                else
                    sql = string.Format("update ExtendedWarehouse set Items=0x{0}{1}, Money = {2} where AccountId = '{3}' AND SCFExtWare = {4}", equipPanel1.getEquipCodes(), equipPanel2.getEquipCodes(), tbox_zen.Text, AccountName, index);

                DBLite.dbMu.Exec(sql);
                DBLite.dbMu.Close();
                MessageBox.Show("Warehouse Edited", "Titan Editor", MessageBoxButtons.OK);
                Close();
            }else
            {
                MessageBox.Show(string.Format("[{0}] Error: Saving Warehouse!", AccountName));
            }
        }

        private void comboVault_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GetWareNum(comboVault.SelectedIndex);
            if (index != -1)
            {
                equipPanel1.clearData();
                if (!equipPanel1.loadItemsByCodes(ware[index].items, 0, ware[index].items.Length/2))
                {
                    MessageBox.Show(string.Format("[{0}] Error: Loading Warehouse!", AccountName));
                }
                equipPanel2.clearData();
                //if (!equipPanel2.loadItemsByCodes(ware[index].items, CharPanel.EquipNum * EquipItem.ITEM_SIZE, ware[index].items.Length - CharPanel.EquipNum * EquipItem.ITEM_SIZE - equipPanel2.XNum * equipPanel2.YNum * EquipItem.ITEM_SIZE))
                if (!equipPanel2.loadItemsByCodes(ware[index].items, ware[index].items.Length / 2, ware[index].items.Length))
                {
                    MessageBox.Show(string.Format("[{0}] Error: Loading Warehouse ex!", AccountName));
                }
                tbox_zen.Text = ware[index].Money.ToString();
            }
            else
            {
                comboVault.SelectedIndex = 0;
            }
        }
    }
}
