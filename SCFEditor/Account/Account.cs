using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TitanEditor.Account
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        public string name;
        bool edit = false;

        private void Account_Load(object sender, EventArgs e)
        {
            if (name != null)
            {
                edit = true;
                tbox_Account.Text = name;
                tbox_Account.ReadOnly = true;
                if (ini.MD5 == false)
                {
                    DBLite.dbMe.Read("SELECT memb__pwd,memb_name,mail_addr,fpas_ques,fpas_answ FROM MEMB_INFO WHERE memb___id = '" + name + "'");
                    DBLite.dbMe.Fetch();
                    tbox_Password.Text = DBLite.dbMe.GetAsString("memb__pwd");
                    tbox_Name.Text = DBLite.dbMe.GetAsString("memb_name");
                    tbox_Email.Text = DBLite.dbMe.GetAsString("mail_addr");
                    tbox_Question.Text = DBLite.dbMe.GetAsString("fpas_ques");
                    tbox_Answer.Text = DBLite.dbMe.GetAsString("fpas_answ");
                }
                else
                {
                    DBLite.dbMe.Read("SELECT memb_name,mail_addr,fpas_ques,fpas_answ FROM MEMB_INFO WHERE memb___id = '" + name + "'");
                    DBLite.dbMe.Fetch();
                    tbox_Name.Text = DBLite.dbMe.GetAsString("memb_name");
                    tbox_Email.Text = DBLite.dbMe.GetAsString("mail_addr");
                    tbox_Question.Text = DBLite.dbMe.GetAsString("fpas_ques");
                    tbox_Answer.Text = DBLite.dbMe.GetAsString("fpas_answ");
                }
                DBLite.dbMe.Close();
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                if (ini.MD5 == false)
                {
                    DBLite.dbMe.Exec("INSERT INTO MEMB_INFO (memb___id,memb__pwd,memb_name,sno__numb,mail_addr,fpas_ques,fpas_answ,appl_days,modi_days,out__days,true_days,mail_chek,bloc_code,ctl1_code) VALUES ('" + tbox_Account.Text + "','" + tbox_Password.Text + "','" + tbox_Name + "','1','" + tbox_Email.Text + "','" + tbox_Question.Text + "','" + tbox_Answer.Text + "','20080101','20080101','20080101','20080101','1','0','0')");
                    DBLite.dbMe.Close();
                }
                else
                {
                    DBLite.dbMe.Exec("INSERT INTO MEMB_INFO (memb___id,memb_name,sno__numb,mail_addr,fpas_ques,fpas_answ,appl_days,modi_days,out__days,true_days,mail_chek,bloc_code,ctl1_code) VALUES ('" + tbox_Account.Text + "','" + tbox_Name.Text + "','1','" + tbox_Email.Text + "','" + tbox_Question.Text + "','" + tbox_Answer.Text + "','20080101','20080101','20080101','20080101','1','0','0')");
                    DBLite.dbMe.Close();
                    DBLite.dbMe.Exec("EXEC Encript '" + tbox_Password.Text + "','" + tbox_Account.Text + "'");
                    DBLite.dbMe.Close();
                }
                MessageBox.Show("Account Added", "Titan Editor", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (ini.MD5 == false)
                {
                    string Pass = "";
                    if(tbox_Password.Text.Length > 0)
                        Pass = "memb__pwd = '" + tbox_Password.Text + "',";
                    DBLite.dbMe.Exec("UPDATE MEMB_INFO SET " + Pass + "memb_name = '" + tbox_Name.Text + "',mail_addr = '" + tbox_Email.Text + "',fpas_ques = '" + tbox_Question.Text + "',fpas_answ = '" + tbox_Answer.Text + "' WHERE memb___id = '" + name + "'");
                    DBLite.dbMe.Close();
                }
                else
                {
                    DBLite.dbMe.Exec("UPDATE MEMB_INFO SET memb_name = '" + tbox_Name.Text + "',mail_addr = '" + tbox_Email.Text + "',fpas_ques = '" + tbox_Question.Text + "',fpas_answ = '" + tbox_Answer.Text + "' WHERE memb___id = '" + name + "'");
                    DBLite.dbMe.Close();
                    if (tbox_Password.Text.Length > 0)
                    {
                        DBLite.dbMe.Exec("EXEC Encript '" + tbox_Password.Text + "','" + tbox_Account.Text + "'");
                        DBLite.dbMe.Close();
                    }
                }
                MessageBox.Show("Account Updated","Titan Editor",MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
