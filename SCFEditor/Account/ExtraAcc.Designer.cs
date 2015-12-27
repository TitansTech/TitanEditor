namespace TitanEditor.Account
{
    partial class ExtraAcc
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.tbox_GoblinCoins = new System.Windows.Forms.TextBox();
            this.tbox_WCoinsP = new System.Windows.Forms.TextBox();
            this.tbox_WCoins = new System.Windows.Forms.TextBox();
            this.tbox_ExtWare = new System.Windows.Forms.TextBox();
            this.tbox_LuckyCoins = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Cancel);
            this.groupBox1.Controls.Add(this.button_Ok);
            this.groupBox1.Controls.Add(this.tbox_GoblinCoins);
            this.groupBox1.Controls.Add(this.tbox_WCoinsP);
            this.groupBox1.Controls.Add(this.tbox_WCoins);
            this.groupBox1.Controls.Add(this.tbox_ExtWare);
            this.groupBox1.Controls.Add(this.tbox_LuckyCoins);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 189);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Extra Manager";
            // 
            // button_Cancel
            // 
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.ForeColor = System.Drawing.Color.Black;
            this.button_Cancel.Location = new System.Drawing.Point(112, 156);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 13;
            this.button_Cancel.Text = "&Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Ok
            // 
            this.button_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ok.ForeColor = System.Drawing.Color.Black;
            this.button_Ok.Location = new System.Drawing.Point(31, 156);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 12;
            this.button_Ok.Text = "&Ok";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // tbox_GoblinCoins
            // 
            this.tbox_GoblinCoins.Location = new System.Drawing.Point(101, 126);
            this.tbox_GoblinCoins.Name = "tbox_GoblinCoins";
            this.tbox_GoblinCoins.Size = new System.Drawing.Size(100, 20);
            this.tbox_GoblinCoins.TabIndex = 10;
            this.tbox_GoblinCoins.Text = "0";
            this.tbox_GoblinCoins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbox_GoblinCoins_KeyPress);
            // 
            // tbox_WCoinsP
            // 
            this.tbox_WCoinsP.Location = new System.Drawing.Point(101, 100);
            this.tbox_WCoinsP.Name = "tbox_WCoinsP";
            this.tbox_WCoinsP.Size = new System.Drawing.Size(100, 20);
            this.tbox_WCoinsP.TabIndex = 9;
            this.tbox_WCoinsP.Text = "0";
            this.tbox_WCoinsP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbox_WCoinsP_KeyPress);
            // 
            // tbox_WCoins
            // 
            this.tbox_WCoins.Location = new System.Drawing.Point(101, 74);
            this.tbox_WCoins.Name = "tbox_WCoins";
            this.tbox_WCoins.Size = new System.Drawing.Size(100, 20);
            this.tbox_WCoins.TabIndex = 8;
            this.tbox_WCoins.Text = "0";
            this.tbox_WCoins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbox_WCoins_KeyPress);
            // 
            // tbox_ExtWare
            // 
            this.tbox_ExtWare.Location = new System.Drawing.Point(101, 48);
            this.tbox_ExtWare.Name = "tbox_ExtWare";
            this.tbox_ExtWare.Size = new System.Drawing.Size(100, 20);
            this.tbox_ExtWare.TabIndex = 7;
            this.tbox_ExtWare.Text = "0";
            this.tbox_ExtWare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbox_ExtWare_KeyPress);
            // 
            // tbox_LuckyCoins
            // 
            this.tbox_LuckyCoins.Location = new System.Drawing.Point(101, 22);
            this.tbox_LuckyCoins.Name = "tbox_LuckyCoins";
            this.tbox_LuckyCoins.Size = new System.Drawing.Size(100, 20);
            this.tbox_LuckyCoins.TabIndex = 6;
            this.tbox_LuckyCoins.Text = "0";
            this.tbox_LuckyCoins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbox_LuckyCoins_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(17, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Goblin Coins";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "W Coins (P)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "W Coins";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Extended Ware";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lucky Coins";
            // 
            // ExtraAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 212);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtraAcc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Extra Data";
            this.Load += new System.EventHandler(this.Extra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.TextBox tbox_GoblinCoins;
        private System.Windows.Forms.TextBox tbox_WCoinsP;
        private System.Windows.Forms.TextBox tbox_WCoins;
        private System.Windows.Forms.TextBox tbox_ExtWare;
        private System.Windows.Forms.TextBox tbox_LuckyCoins;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}