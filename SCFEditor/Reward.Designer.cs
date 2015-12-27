namespace TitanEditor
{
    partial class Reward
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.addReward = new System.Windows.Forms.Button();
            this.account_Rld = new System.Windows.Forms.Button();
            this.comboAccount = new System.Windows.Forms.ComboBox();
            this.comboChar = new System.Windows.Forms.ComboBox();
            this.accountFind = new System.Windows.Forms.Button();
            this.Zen = new System.Windows.Forms.TextBox();
            this.VIPMoney = new System.Windows.Forms.TextBox();
            this.Days = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.itemcheckBox = new System.Windows.Forms.CheckBox();
            this.equipEditor1 = new TitanEditor.EquipEditor();
            this.charFind = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addReward
            // 
            this.addReward.Location = new System.Drawing.Point(92, 572);
            this.addReward.Name = "addReward";
            this.addReward.Size = new System.Drawing.Size(75, 23);
            this.addReward.TabIndex = 11;
            this.addReward.Text = "Add Reward";
            this.addReward.UseVisualStyleBackColor = true;
            this.addReward.Click += new System.EventHandler(this.addReward_Click);
            // 
            // account_Rld
            // 
            this.account_Rld.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.account_Rld.ForeColor = System.Drawing.Color.Black;
            this.account_Rld.Location = new System.Drawing.Point(206, 12);
            this.account_Rld.Name = "account_Rld";
            this.account_Rld.Size = new System.Drawing.Size(20, 21);
            this.account_Rld.TabIndex = 2;
            this.account_Rld.Text = "R";
            this.account_Rld.UseVisualStyleBackColor = true;
            this.account_Rld.Click += new System.EventHandler(this.account_Rld_Click);
            // 
            // comboAccount
            // 
            this.comboAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboAccount.FormattingEnabled = true;
            this.comboAccount.Location = new System.Drawing.Point(83, 12);
            this.comboAccount.MaxLength = 10;
            this.comboAccount.Name = "comboAccount";
            this.comboAccount.Size = new System.Drawing.Size(117, 21);
            this.comboAccount.TabIndex = 1;
            this.comboAccount.SelectedIndexChanged += new System.EventHandler(this.comboAccount_SelectedIndexChanged);
            // 
            // comboChar
            // 
            this.comboChar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboChar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboChar.FormattingEnabled = true;
            this.comboChar.Location = new System.Drawing.Point(83, 38);
            this.comboChar.MaxLength = 10;
            this.comboChar.Name = "comboChar";
            this.comboChar.Size = new System.Drawing.Size(143, 21);
            this.comboChar.TabIndex = 4;
            // 
            // accountFind
            // 
            this.accountFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountFind.ForeColor = System.Drawing.Color.Black;
            this.accountFind.Location = new System.Drawing.Point(232, 12);
            this.accountFind.Name = "accountFind";
            this.accountFind.Size = new System.Drawing.Size(20, 21);
            this.accountFind.TabIndex = 3;
            this.accountFind.Text = "F";
            this.accountFind.UseVisualStyleBackColor = true;
            this.accountFind.Click += new System.EventHandler(this.accountFind_Click);
            // 
            // Zen
            // 
            this.Zen.Location = new System.Drawing.Point(83, 65);
            this.Zen.MaxLength = 8;
            this.Zen.Name = "Zen";
            this.Zen.Size = new System.Drawing.Size(169, 20);
            this.Zen.TabIndex = 6;
            this.Zen.Text = "0";
            this.Zen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VIPMoney
            // 
            this.VIPMoney.Location = new System.Drawing.Point(83, 91);
            this.VIPMoney.MaxLength = 8;
            this.VIPMoney.Name = "VIPMoney";
            this.VIPMoney.Size = new System.Drawing.Size(169, 20);
            this.VIPMoney.TabIndex = 7;
            this.VIPMoney.Text = "0";
            this.VIPMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Days
            // 
            this.Days.Location = new System.Drawing.Point(130, 400);
            this.Days.MaxLength = 3;
            this.Days.Name = "Days";
            this.Days.Size = new System.Drawing.Size(100, 20);
            this.Days.TabIndex = 10;
            this.Days.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Character:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Zen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "VIP Money:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Days (0 = forever):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.equipEditor1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Days);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 426);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item:";
            // 
            // itemcheckBox
            // 
            this.itemcheckBox.AutoSize = true;
            this.itemcheckBox.Checked = true;
            this.itemcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemcheckBox.Location = new System.Drawing.Point(99, 117);
            this.itemcheckBox.Name = "itemcheckBox";
            this.itemcheckBox.Size = new System.Drawing.Size(68, 17);
            this.itemcheckBox.TabIndex = 8;
            this.itemcheckBox.Text = "Add Item";
            this.itemcheckBox.UseVisualStyleBackColor = true;
            this.itemcheckBox.CheckedChanged += new System.EventHandler(this.itemcheckBox_CheckedChanged);
            // 
            // equipEditor1
            // 
            this.equipEditor1.DefaultDurability = ((byte)(255));
            this.equipEditor1.Location = new System.Drawing.Point(3, 17);
            this.equipEditor1.Margin = new System.Windows.Forms.Padding(0);
            this.equipEditor1.Name = "equipEditor1";
            this.equipEditor1.Size = new System.Drawing.Size(230, 380);
            this.equipEditor1.TabIndex = 0;
            // 
            // charFind
            // 
            this.charFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.charFind.ForeColor = System.Drawing.Color.Black;
            this.charFind.Location = new System.Drawing.Point(232, 37);
            this.charFind.Name = "charFind";
            this.charFind.Size = new System.Drawing.Size(20, 21);
            this.charFind.TabIndex = 5;
            this.charFind.Text = "F";
            this.charFind.UseVisualStyleBackColor = true;
            this.charFind.Click += new System.EventHandler(this.charFind_Click);
            // 
            // Reward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 602);
            this.Controls.Add(this.charFind);
            this.Controls.Add(this.itemcheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VIPMoney);
            this.Controls.Add(this.Zen);
            this.Controls.Add(this.accountFind);
            this.Controls.Add(this.comboChar);
            this.Controls.Add(this.account_Rld);
            this.Controls.Add(this.comboAccount);
            this.Controls.Add(this.addReward);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Reward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reward";
            this.Load += new System.EventHandler(this.Reward_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EquipEditor equipEditor1;
        private System.Windows.Forms.Button addReward;
        private System.Windows.Forms.Button account_Rld;
        private System.Windows.Forms.ComboBox comboAccount;
        private System.Windows.Forms.ComboBox comboChar;
        private System.Windows.Forms.Button accountFind;
        private System.Windows.Forms.TextBox Zen;
        private System.Windows.Forms.TextBox VIPMoney;
        private System.Windows.Forms.TextBox Days;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox itemcheckBox;
        private System.Windows.Forms.Button charFind;
    }
}