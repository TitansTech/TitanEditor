using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Items
{
    public partial class Serial : Form
    {
        public Serial()
        {
            InitializeComponent();
        }

        public Int64 ItemSerial = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (radio0.Checked == true)
                ItemSerial = 0;
            else
            {
                ItemSerial = 0xFFFFFFFF;
                if (radioE.Checked == true)
                    ItemSerial = ItemSerial - 1;
                else if (radioD.Checked == true)
                    ItemSerial = ItemSerial - 2;
                else if (radioC.Checked == true)
                    ItemSerial = ItemSerial - 3;
            }
            this.Close();
        }
    }
}
