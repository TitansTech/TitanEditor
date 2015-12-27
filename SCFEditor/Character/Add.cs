using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Character
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        public string name;

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clase = 0;

            if (radioButton1.Checked == true)
                clase = 0;
            else if (radioButton2.Checked == true)
                clase = 16;
            else if (radioButton3.Checked == true)
                clase = 32;
            else if (radioButton4.Checked == true)
                clase = 80;
            else if (radioButton5.Checked == true)
                clase = 48;
            else if (radioButton6.Checked == true)
                clase = 64;
            else if (radioButton7.Checked == true)
                clase = 96;

            DBLite.dbMu.Exec("EXEC WZ_CreateCharacter '" + name + "','" + textBox1.Text + "'," + clase);
            DBLite.dbMu.Close();

            MessageBox.Show("Character Added", "Titan Editor", MessageBoxButtons.OK);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
