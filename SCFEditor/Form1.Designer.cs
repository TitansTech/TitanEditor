namespace TitanEditor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.accountWare = new System.Windows.Forms.Button();
            this.account_Rld = new System.Windows.Forms.Button();
            this.accountFind = new System.Windows.Forms.Button();
            this.accountEdit = new System.Windows.Forms.Button();
            this.account_Del = new System.Windows.Forms.Button();
            this.accountAdd = new System.Windows.Forms.Button();
            this.comboAccount = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.charFind = new System.Windows.Forms.Button();
            this.charEdit = new System.Windows.Forms.Button();
            this.charDel = new System.Windows.Forms.Button();
            this.charAdd = new System.Windows.Forms.Button();
            this.comboChar = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.rewardsBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.vipBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.extraAccBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 20);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(53, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titan Editor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.extraAccBtn);
            this.groupBox1.Controls.Add(this.accountWare);
            this.groupBox1.Controls.Add(this.account_Rld);
            this.groupBox1.Controls.Add(this.accountFind);
            this.groupBox1.Controls.Add(this.accountEdit);
            this.groupBox1.Controls.Add(this.account_Del);
            this.groupBox1.Controls.Add(this.accountAdd);
            this.groupBox1.Controls.Add(this.comboAccount);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(5, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Panel";
            // 
            // accountWare
            // 
            this.accountWare.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountWare.ForeColor = System.Drawing.Color.Black;
            this.accountWare.Location = new System.Drawing.Point(90, 46);
            this.accountWare.Name = "accountWare";
            this.accountWare.Size = new System.Drawing.Size(20, 21);
            this.accountWare.TabIndex = 8;
            this.accountWare.Text = "W";
            this.toolTip1.SetToolTip(this.accountWare, "Warehouse");
            this.accountWare.UseVisualStyleBackColor = true;
            this.accountWare.Click += new System.EventHandler(this.accountWare_Click);
            // 
            // account_Rld
            // 
            this.account_Rld.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.account_Rld.ForeColor = System.Drawing.Color.Black;
            this.account_Rld.Location = new System.Drawing.Point(157, 19);
            this.account_Rld.Name = "account_Rld";
            this.account_Rld.Size = new System.Drawing.Size(20, 21);
            this.account_Rld.TabIndex = 7;
            this.account_Rld.Text = "R";
            this.toolTip1.SetToolTip(this.account_Rld, "Reload");
            this.account_Rld.UseVisualStyleBackColor = true;
            this.account_Rld.Click += new System.EventHandler(this.account_Rld_Click);
            // 
            // accountFind
            // 
            this.accountFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountFind.ForeColor = System.Drawing.Color.Black;
            this.accountFind.Location = new System.Drawing.Point(157, 46);
            this.accountFind.Name = "accountFind";
            this.accountFind.Size = new System.Drawing.Size(20, 21);
            this.accountFind.TabIndex = 6;
            this.accountFind.Text = "F";
            this.toolTip1.SetToolTip(this.accountFind, "Find");
            this.accountFind.UseVisualStyleBackColor = true;
            this.accountFind.Click += new System.EventHandler(this.accountFind_Click);
            // 
            // accountEdit
            // 
            this.accountEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountEdit.ForeColor = System.Drawing.Color.Black;
            this.accountEdit.Location = new System.Drawing.Point(64, 46);
            this.accountEdit.Name = "accountEdit";
            this.accountEdit.Size = new System.Drawing.Size(20, 21);
            this.accountEdit.TabIndex = 5;
            this.accountEdit.Text = "E";
            this.toolTip1.SetToolTip(this.accountEdit, "Edit");
            this.accountEdit.UseVisualStyleBackColor = true;
            this.accountEdit.Click += new System.EventHandler(this.accountEdit_Click);
            // 
            // account_Del
            // 
            this.account_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.account_Del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.account_Del.ForeColor = System.Drawing.Color.Black;
            this.account_Del.Location = new System.Drawing.Point(38, 46);
            this.account_Del.Name = "account_Del";
            this.account_Del.Size = new System.Drawing.Size(20, 21);
            this.account_Del.TabIndex = 4;
            this.account_Del.Text = "-";
            this.toolTip1.SetToolTip(this.account_Del, "Delete");
            this.account_Del.UseVisualStyleBackColor = true;
            this.account_Del.Click += new System.EventHandler(this.account_Del_Click);
            // 
            // accountAdd
            // 
            this.accountAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.accountAdd.ForeColor = System.Drawing.Color.Black;
            this.accountAdd.Location = new System.Drawing.Point(12, 46);
            this.accountAdd.Name = "accountAdd";
            this.accountAdd.Size = new System.Drawing.Size(20, 21);
            this.accountAdd.TabIndex = 3;
            this.accountAdd.Text = "+";
            this.toolTip1.SetToolTip(this.accountAdd, "Add");
            this.accountAdd.UseVisualStyleBackColor = true;
            this.accountAdd.Click += new System.EventHandler(this.accountAdd_Click);
            // 
            // comboAccount
            // 
            this.comboAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboAccount.FormattingEnabled = true;
            this.comboAccount.Location = new System.Drawing.Point(12, 19);
            this.comboAccount.Name = "comboAccount";
            this.comboAccount.Size = new System.Drawing.Size(139, 21);
            this.comboAccount.TabIndex = 0;
            this.comboAccount.SelectedIndexChanged += new System.EventHandler(this.comboAccount_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.charFind);
            this.groupBox2.Controls.Add(this.charEdit);
            this.groupBox2.Controls.Add(this.charDel);
            this.groupBox2.Controls.Add(this.charAdd);
            this.groupBox2.Controls.Add(this.comboChar);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(5, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Character Panel";
            // 
            // charFind
            // 
            this.charFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.charFind.ForeColor = System.Drawing.Color.Black;
            this.charFind.Location = new System.Drawing.Point(157, 46);
            this.charFind.Name = "charFind";
            this.charFind.Size = new System.Drawing.Size(20, 21);
            this.charFind.TabIndex = 12;
            this.charFind.Text = "F";
            this.toolTip1.SetToolTip(this.charFind, "Find");
            this.charFind.UseVisualStyleBackColor = true;
            this.charFind.Click += new System.EventHandler(this.charFind_Click);
            // 
            // charEdit
            // 
            this.charEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.charEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.charEdit.ForeColor = System.Drawing.Color.Black;
            this.charEdit.Location = new System.Drawing.Point(64, 46);
            this.charEdit.Name = "charEdit";
            this.charEdit.Size = new System.Drawing.Size(20, 21);
            this.charEdit.TabIndex = 11;
            this.charEdit.Text = "E";
            this.toolTip1.SetToolTip(this.charEdit, "Edit");
            this.charEdit.UseVisualStyleBackColor = true;
            this.charEdit.Click += new System.EventHandler(this.charEdit_Click);
            // 
            // charDel
            // 
            this.charDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.charDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.charDel.ForeColor = System.Drawing.Color.Black;
            this.charDel.Location = new System.Drawing.Point(38, 46);
            this.charDel.Name = "charDel";
            this.charDel.Size = new System.Drawing.Size(20, 21);
            this.charDel.TabIndex = 10;
            this.charDel.Text = "-";
            this.toolTip1.SetToolTip(this.charDel, "Delete");
            this.charDel.UseVisualStyleBackColor = true;
            this.charDel.Click += new System.EventHandler(this.charDel_Click);
            // 
            // charAdd
            // 
            this.charAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.charAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.charAdd.ForeColor = System.Drawing.Color.Black;
            this.charAdd.Location = new System.Drawing.Point(12, 46);
            this.charAdd.Name = "charAdd";
            this.charAdd.Size = new System.Drawing.Size(20, 21);
            this.charAdd.TabIndex = 9;
            this.charAdd.Text = "+";
            this.toolTip1.SetToolTip(this.charAdd, "Add");
            this.charAdd.UseVisualStyleBackColor = true;
            this.charAdd.Click += new System.EventHandler(this.charAdd_Click);
            // 
            // comboChar
            // 
            this.comboChar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboChar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboChar.FormattingEnabled = true;
            this.comboChar.Location = new System.Drawing.Point(12, 19);
            this.comboChar.Name = "comboChar";
            this.comboChar.Size = new System.Drawing.Size(165, 21);
            this.comboChar.TabIndex = 8;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Titan Editor";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // rewardsBtn
            // 
            this.rewardsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rewardsBtn.ForeColor = System.Drawing.Color.Black;
            this.rewardsBtn.Location = new System.Drawing.Point(12, 21);
            this.rewardsBtn.Name = "rewardsBtn";
            this.rewardsBtn.Size = new System.Drawing.Size(20, 21);
            this.rewardsBtn.TabIndex = 13;
            this.rewardsBtn.Text = "R";
            this.toolTip1.SetToolTip(this.rewardsBtn, "Reward System");
            this.rewardsBtn.UseVisualStyleBackColor = true;
            this.rewardsBtn.Click += new System.EventHandler(this.rewardsBtn_Click);
            // 
            // vipBtn
            // 
            this.vipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.vipBtn.ForeColor = System.Drawing.Color.Black;
            this.vipBtn.Location = new System.Drawing.Point(38, 21);
            this.vipBtn.Name = "vipBtn";
            this.vipBtn.Size = new System.Drawing.Size(20, 21);
            this.vipBtn.TabIndex = 14;
            this.vipBtn.Text = "V";
            this.toolTip1.SetToolTip(this.vipBtn, "VIP System");
            this.vipBtn.UseVisualStyleBackColor = true;
            this.vipBtn.Click += new System.EventHandler(this.vipBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.vipBtn);
            this.groupBox3.Controls.Add(this.rewardsBtn);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(5, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 52);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extra Panel";
            // 
            // extraAccBtn
            // 
            this.extraAccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.extraAccBtn.ForeColor = System.Drawing.Color.Black;
            this.extraAccBtn.Location = new System.Drawing.Point(116, 46);
            this.extraAccBtn.Name = "extraAccBtn";
            this.extraAccBtn.Size = new System.Drawing.Size(20, 21);
            this.extraAccBtn.TabIndex = 9;
            this.extraAccBtn.Text = "X";
            this.toolTip1.SetToolTip(this.extraAccBtn, "Extra");
            this.extraAccBtn.UseVisualStyleBackColor = true;
            this.extraAccBtn.Click += new System.EventHandler(this.extraAccBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 244);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titan Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboAccount;
        private System.Windows.Forms.Button accountFind;
        private System.Windows.Forms.Button accountEdit;
        private System.Windows.Forms.Button account_Del;
        private System.Windows.Forms.Button accountAdd;
        private System.Windows.Forms.Button account_Rld;
        private System.Windows.Forms.Button charFind;
        private System.Windows.Forms.Button charEdit;
        private System.Windows.Forms.Button charDel;
        private System.Windows.Forms.Button charAdd;
        private System.Windows.Forms.ComboBox comboChar;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button accountWare;
        private System.Windows.Forms.Button rewardsBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button vipBtn;
        private System.Windows.Forms.Button extraAccBtn;
    }
}

