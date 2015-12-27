using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Character
{
    public partial class SkillsEdition : Form
    {
        const int skillCount = 1024;

        public SkillsEdition()
        {
            InitializeComponent();
        }
        public string CharacterName;
        public string AccountName;

        private byte[] mlist = new byte[180];

        private struct skillstruct
        {
            public string clase;
            public string name;
        }
        private skillstruct[] slist = new skillstruct[skillCount];
 
        private void Button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetMDBSkills()
        {
            DBLite.mdb.Read("SELECT DISTINCT CLASS FROM SKILLS");
            while (DBLite.mdb.Fetch())
            {
                ComboBox1.Items.Add(DBLite.mdb.GetAsString("CLASS"));
            }
            DBLite.mdb.Close();

            DBLite.mdb.Read("SELECT ID,Class,Name FROM SKILLS");
            while (DBLite.mdb.Fetch())
            {
                int id = DBLite.mdb.GetAsInteger("ID");

                slist[id].clase = DBLite.mdb.GetAsString("CLASS");
                slist[id].name = DBLite.mdb.GetAsString("Name");
            }
            DBLite.mdb.Close();
        }

        private void Skills_Load(object sender, EventArgs e)
        {
            GetMDBSkills();
            DBLite.dbMu.Read("SELECT magiclist FROM Character WHERE Name='" + CharacterName + "'");
            DBLite.dbMu.Fetch();
            mlist = DBLite.dbMu.GetAsBinary("magiclist");
            DBLite.dbMu.Close();
            for (int i = 0; i < 45; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0:X2}{1:X2}", mlist[i * 3 + 1], mlist[i * 3]);
                
                int skillNum = int.Parse(sb.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                if (skillNum != 65535)
                {
                    listView1.Items.Add(skillNum.ToString()).SubItems.Add(slist[skillNum].name);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            byte[] tmp = new byte[180];
            for (int i = 0; i < 45; i++)
            {
                if (i >= listView1.Items.Count)
                {
                    tmp[i * 3] = 255;
                    tmp[i * 3 + 1] = 255;
                }
                else
                {
                    byte[] bskill = BitConverter.GetBytes(Convert.ToInt32(listView1.Items[i].SubItems[0].Text));
                    tmp[i * 3] = bskill[0];
                    tmp[i * 3 + 1] = bskill[1];
                }
            }
            string magiclistStr = "0x" + System.BitConverter.ToString(tmp).Replace("-", "");
            DBLite.dbMu.Exec("UPDATE Character SET magiclist=" + magiclistStr + " WHERE Name='" + CharacterName + "'");
            DBLite.dbMu.Close();
            MessageBox.Show("Skill Saved", "Titan Editor", MessageBoxButtons.OK);
            Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox2.Items.Clear();
            for (int i = 0; i < skillCount; i++)
            {
                if (slist[i].clase == ComboBox1.Text)
                    ComboBox2.Items.Add(slist[i].name);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < skillCount; i++)
            {
                if (slist[i].clase == ComboBox1.Text && slist[i].name == ComboBox2.Text)
                    listView1.Items.Add(i.ToString()).SubItems.Add(slist[i].name);
            }
        }
    }
}
