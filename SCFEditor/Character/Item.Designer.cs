namespace TitanEditor.Character
{
    partial class Item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Item));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.equipPanel4 = new TitanEditor.EquipPanel();
            this.equipPanel3 = new TitanEditor.EquipPanel();
            this.equipPanel2 = new TitanEditor.EquipPanel();
            this.equipPanel1 = new TitanEditor.EquipPanel();
            this.equipEditor1 = new TitanEditor.EquipEditor();
            this.charPanel1 = new TitanEditor.CharPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(239, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(320, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // equipPanel4
            // 
            this.equipPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipPanel4.BackgroundImage")));
            this.equipPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.equipPanel4.Cursor = System.Windows.Forms.Cursors.Cross;
            this.equipPanel4.Location = new System.Drawing.Point(209, 438);
            this.equipPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.equipPanel4.Name = "equipPanel4";
            this.equipPanel4.Size = new System.Drawing.Size(200, 100);
            this.equipPanel4.TabIndex = 7;
            // 
            // equipPanel3
            // 
            this.equipPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipPanel3.BackgroundImage")));
            this.equipPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.equipPanel3.Cursor = System.Windows.Forms.Cursors.Cross;
            this.equipPanel3.Location = new System.Drawing.Point(0, 541);
            this.equipPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.equipPanel3.Name = "equipPanel3";
            this.equipPanel3.Size = new System.Drawing.Size(200, 100);
            this.equipPanel3.TabIndex = 6;
            // 
            // equipPanel2
            // 
            this.equipPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipPanel2.BackgroundImage")));
            this.equipPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.equipPanel2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.equipPanel2.Location = new System.Drawing.Point(0, 438);
            this.equipPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.equipPanel2.Name = "equipPanel2";
            this.equipPanel2.Size = new System.Drawing.Size(200, 100);
            this.equipPanel2.TabIndex = 5;
            // 
            // equipPanel1
            // 
            this.equipPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipPanel1.BackgroundImage")));
            this.equipPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.equipPanel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.equipPanel1.Location = new System.Drawing.Point(0, 202);
            this.equipPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.equipPanel1.Name = "equipPanel1";
            this.equipPanel1.Size = new System.Drawing.Size(200, 227);
            this.equipPanel1.TabIndex = 2;
            // 
            // equipEditor1
            // 
            this.equipEditor1.DefaultDurability = ((byte)(255));
            this.equipEditor1.Location = new System.Drawing.Point(209, 9);
            this.equipEditor1.Margin = new System.Windows.Forms.Padding(0);
            this.equipEditor1.Name = "equipEditor1";
            this.equipEditor1.Size = new System.Drawing.Size(232, 399);
            this.equipEditor1.TabIndex = 1;
            // 
            // charPanel1
            // 
            this.charPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("charPanel1.BackgroundImage")));
            this.charPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.charPanel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.charPanel1.Location = new System.Drawing.Point(0, 0);
            this.charPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.charPanel1.Name = "charPanel1";
            this.charPanel1.Prof = -1;
            this.charPanel1.Size = new System.Drawing.Size(200, 202);
            this.charPanel1.TabIndex = 0;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 653);
            this.Controls.Add(this.equipPanel4);
            this.Controls.Add(this.equipPanel3);
            this.Controls.Add(this.equipPanel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.equipPanel1);
            this.Controls.Add(this.equipEditor1);
            this.Controls.Add(this.charPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Item";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.Load += new System.EventHandler(this.Item_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CharPanel charPanel1;
        private EquipEditor equipEditor1;
        private EquipPanel equipPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private EquipPanel equipPanel2;
        private EquipPanel equipPanel3;
        private EquipPanel equipPanel4;



    }
}