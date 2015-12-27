namespace TitanEditor.Account
{
    partial class VIP
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.accountFind = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.vipdaysTxt = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.vipmoneyTxt = new System.Windows.Forms.TextBox();
            this.vipRBtn = new System.Windows.Forms.RadioButton();
            this.normalRBtn = new System.Windows.Forms.RadioButton();
            this.account_Rld = new System.Windows.Forms.Button();
            this.comboAccount = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wareTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wareTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.accountFind);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.vipdaysTxt);
            this.groupBox1.Controls.Add(this.Label8);
            this.groupBox1.Controls.Add(this.Label7);
            this.groupBox1.Controls.Add(this.vipmoneyTxt);
            this.groupBox1.Controls.Add(this.vipRBtn);
            this.groupBox1.Controls.Add(this.normalRBtn);
            this.groupBox1.Controls.Add(this.account_Rld);
            this.groupBox1.Controls.Add(this.comboAccount);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VIP Account Panel";
            // 
            // accountFind
            // 
            this.accountFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountFind.ForeColor = System.Drawing.Color.Black;
            this.accountFind.Location = new System.Drawing.Point(183, 19);
            this.accountFind.Name = "accountFind";
            this.accountFind.Size = new System.Drawing.Size(20, 21);
            this.accountFind.TabIndex = 19;
            this.accountFind.Text = "F";
            this.accountFind.UseVisualStyleBackColor = true;
            this.accountFind.Click += new System.EventHandler(this.accountFind_Click);
            // 
            // button_Save
            // 
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.ForeColor = System.Drawing.Color.Black;
            this.button_Save.Location = new System.Drawing.Point(67, 158);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 18;
            this.button_Save.Text = "&Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // vipdaysTxt
            // 
            this.vipdaysTxt.Location = new System.Drawing.Point(82, 104);
            this.vipdaysTxt.Name = "vipdaysTxt";
            this.vipdaysTxt.Size = new System.Drawing.Size(121, 20);
            this.vipdaysTxt.TabIndex = 17;
            this.vipdaysTxt.Text = "0";
            this.vipdaysTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vipdaysTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vipdaysBtn_KeyPress);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(6, 108);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(31, 13);
            this.Label8.TabIndex = 16;
            this.Label8.Text = "Days";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(6, 83);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(39, 13);
            this.Label7.TabIndex = 15;
            this.Label7.Text = "Money";
            // 
            // vipmoneyTxt
            // 
            this.vipmoneyTxt.Location = new System.Drawing.Point(82, 78);
            this.vipmoneyTxt.Name = "vipmoneyTxt";
            this.vipmoneyTxt.Size = new System.Drawing.Size(121, 20);
            this.vipmoneyTxt.TabIndex = 14;
            this.vipmoneyTxt.Text = "0";
            this.vipmoneyTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vipmoneyTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vipmoneyBtn_KeyPress);
            // 
            // vipRBtn
            // 
            this.vipRBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.vipRBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.vipRBtn.ForeColor = System.Drawing.Color.Black;
            this.vipRBtn.Location = new System.Drawing.Point(32, 46);
            this.vipRBtn.Name = "vipRBtn";
            this.vipRBtn.Size = new System.Drawing.Size(20, 21);
            this.vipRBtn.TabIndex = 13;
            this.vipRBtn.Text = "V";
            this.vipRBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.vipRBtn, "VIP Accounts");
            this.vipRBtn.UseVisualStyleBackColor = true;
            this.vipRBtn.CheckedChanged += new System.EventHandler(this.vipRBtn_CheckedChanged);
            // 
            // normalRBtn
            // 
            this.normalRBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.normalRBtn.Checked = true;
            this.normalRBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.normalRBtn.ForeColor = System.Drawing.Color.Black;
            this.normalRBtn.Location = new System.Drawing.Point(6, 46);
            this.normalRBtn.Name = "normalRBtn";
            this.normalRBtn.Size = new System.Drawing.Size(20, 21);
            this.normalRBtn.TabIndex = 12;
            this.normalRBtn.TabStop = true;
            this.normalRBtn.Text = "N";
            this.normalRBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.normalRBtn, "Normal Accounts");
            this.normalRBtn.UseVisualStyleBackColor = true;
            this.normalRBtn.CheckedChanged += new System.EventHandler(this.normalRBtn_CheckedChanged);
            // 
            // account_Rld
            // 
            this.account_Rld.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.account_Rld.ForeColor = System.Drawing.Color.Black;
            this.account_Rld.Location = new System.Drawing.Point(157, 19);
            this.account_Rld.Name = "account_Rld";
            this.account_Rld.Size = new System.Drawing.Size(20, 21);
            this.account_Rld.TabIndex = 9;
            this.account_Rld.Text = "R";
            this.toolTip1.SetToolTip(this.account_Rld, "Reload Accounts");
            this.account_Rld.UseVisualStyleBackColor = true;
            this.account_Rld.Click += new System.EventHandler(this.account_Rld_Click);
            // 
            // comboAccount
            // 
            this.comboAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboAccount.FormattingEnabled = true;
            this.comboAccount.Location = new System.Drawing.Point(6, 19);
            this.comboAccount.Name = "comboAccount";
            this.comboAccount.Size = new System.Drawing.Size(145, 21);
            this.comboAccount.TabIndex = 8;
            this.comboAccount.SelectedIndexChanged += new System.EventHandler(this.comboAccount_SelectedIndexChanged);
            // 
            // wareTxt
            // 
            this.wareTxt.Location = new System.Drawing.Point(82, 130);
            this.wareTxt.Name = "wareTxt";
            this.wareTxt.Size = new System.Drawing.Size(121, 20);
            this.wareTxt.TabIndex = 21;
            this.wareTxt.Text = "0";
            this.wareTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ware Count";
            // 
            // VIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 208);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VIP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button account_Rld;
        private System.Windows.Forms.ComboBox comboAccount;
        private System.Windows.Forms.RadioButton normalRBtn;
        private System.Windows.Forms.RadioButton vipRBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox vipdaysTxt;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox vipmoneyTxt;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button accountFind;
        internal System.Windows.Forms.TextBox wareTxt;
        internal System.Windows.Forms.Label label1;
    }
}