using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class ResetPassword : Form
    {
        private string password = null;

        public string Password {
            set {
                password = value;
            }
            get {
                return password;
            }
        }

        public ResetPassword()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!newPasswordTextBox.Text.Equals(confirmPasswordTextBox.Text)) {
                MessageBox.Show("两次输入的密码不匹配", "提示");
            } else {
                password = newPasswordTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
