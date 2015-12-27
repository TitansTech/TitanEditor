namespace TitanEditor.Account
{
    partial class Warehouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehouse));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboVault = new System.Windows.Forms.ComboBox();
            this.equipPanel1 = new TitanEditor.EquipPanel();
            this.equipEditor1 = new TitanEditor.EquipEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_zen = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.equipPanel2 = new TitanEditor.EquipPanel();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(529, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(448, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboVault
            // 
            this.comboVault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVault.FormattingEnabled = true;
            this.comboVault.Location = new System.Drawing.Point(121, 12);
            this.comboVault.Name = "comboVault";
            this.comboVault.Size = new System.Drawing.Size(88, 21);
            this.comboVault.TabIndex = 7;
            this.comboVault.SelectedIndexChanged += new System.EventHandler(this.comboVault_SelectedIndexChanged);
            // 
            // equipPanel1
            // 
            this.equipPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipPanel1.BackgroundImage")));
            this.equipPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.equipPanel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.equipPanel1.Location = new System.Drawing.Point(9, 66);
            this.equipPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.equipPanel1.Name = "equipPanel1";
            this.equipPanel1.Size = new System.Drawing.Size(200, 406);
            this.equipPanel1.TabIndex = 1;
            // 
            // equipEditor1
            // 
            this.equipEditor1.DefaultDurability = ((byte)(255));
            this.equipEditor1.Location = new System.Drawing.Point(422, 36);
            this.equipEditor1.Margin = new System.Windows.Forms.Padding(0);
            this.equipEditor1.Name = "equipEditor1";
            this.equipEditor1.Size = new System.Drawing.Size(231, 395);
            this.equipEditor1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Warehouse Number:";
            // 
            // tbox_zen
            // 
            this.tbox_zen.Location = new System.Drawing.Point(47, 39);
            this.tbox_zen.MaxLength = 10;
            this.tbox_zen.Name = "tbox_zen";
            this.tbox_zen.Size = new System.Drawing.Size(162, 20);
            this.tbox_zen.TabIndex = 24;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(12, 42);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(29, 13);
            this.Label22.TabIndex = 23;
            this.Label22.Text = "Zen:";
            // 
            // equipPanel2
            // 
            this.equipPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipPanel2.BackgroundImage")));
            this.equipPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.equipPanel2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.equipPanel2.Location = new System.Drawing.Point(214, 66);
            this.equipPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.equipPanel2.Name = "equipPanel2";
            this.equipPanel2.Size = new System.Drawing.Size(200, 406);
            this.equipPanel2.TabIndex = 25;
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 469);
            this.Controls.Add(this.equipPanel2);
            this.Controls.Add(this.tbox_zen);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboVault);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.equipPanel1);
            this.Controls.Add(this.equipEditor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Warehouse";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse";
            this.Load += new System.EventHandler(this.Warehouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EquipEditor equipEditor1;
        private EquipPanel equipPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboVault;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox tbox_zen;
        internal System.Windows.Forms.Label Label22;
        private EquipPanel equipPanel2;
    }
}