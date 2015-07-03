using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProjectManagementSystem
{
    public partial class UserDialogue : Form
    {
        private int flag = 0;
        private string ownerRole = "";
        private string name = "";
        private string oldRealName;

        public string RoleName {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }

        public UserDialogue(int flag, string name)
        {
            InitializeComponent();
            this.flag = flag;
            switch (flag) {
                case 1:
                    ownerRole = "projectAdmin";
                    break;
                case 3:
                    ownerRole = "projectManager";
                    this.name = name;
                    break;
                case 4:
                    ownerRole = "projectMember";
                    this.name = name;
                    break;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (CheckInfo()) {
                if (flag == 0) {
                    SystemAdmin dialogueOwner = (SystemAdmin)this.Owner;
                    dialogueOwner.UserInfo = new Dictionary<string, string>();
                    string role = null;
                    if (projectMenberCheckBox.Checked)
                        role += "projectMember,";
                    if (projectManagerCheckBox.Checked)
                        role += "projectManager,";
                    if (projectAdminCheckBox.Checked)
                        role += "projectAdmin,";
                    if (generalManagerCheckBox.Checked)
                        role += "generalManager,";
                    role.TrimEnd(',');
                    dialogueOwner.UserInfo.Add("role", role);
                    dialogueOwner.UserInfo.Add("userName", userNameTextBox.Text);
                    dialogueOwner.UserInfo.Add("password", passwordTextBox.Text);
                    dialogueOwner.UserInfo.Add("realName", realNameTextBox.Text);
                    dialogueOwner.UserInfo.Add("birthday", birthdayTimePicker.Text);
                    dialogueOwner.UserInfo.Add("joinDate", joinDateTimePicker.Text);
                    dialogueOwner.UserInfo.Add("techLevel", techLevelTextBox.Text);
                } else {
                    string info = userNameTextBox.Text + "|" + passwordTextBox.Text + "|" +
                        realNameTextBox.Text + "|" + birthdayTimePicker.Text + "|" +
                        joinDateTimePicker.Text + "|" + techLevelTextBox.Text;
                    StreamReader sr = null;
                    StreamWriter sw = null;
                    string line;
                    string content = "";
                    try {
                        sr = File.OpenText("users.dat");
                        while ((line = sr.ReadLine()) != null) {
                            content += (line + "\r\n");
                            if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(ownerRole)) {
                                if (flag <= 2) {
                                    sr.ReadLine();
                                    content += (info + "\r\n");
                                } else {
                                    while (!(line = sr.ReadLine()).Split(new char[] { '|' })[2].Equals(name))
                                        content += (line + "\r\n");
                                    content += (info + "\r\n");
                                }
                            }
                        }
                    } catch (FileNotFoundException fe) {
                        Console.WriteLine(fe.StackTrace);
                        MessageBox.Show("读取用户数据信息失败！", "提示");
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    } finally {
                        if (sr != null)
                            sr.Close();
                    }
                    try {
                        sw = File.CreateText("users.dat");
                        sw.Write(content);
                    } catch (FileNotFoundException fe) {
                        Console.WriteLine(fe.StackTrace);
                        MessageBox.Show("写入用户数据信息失败！", "提示");
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    } finally {
                        if (sw != null)
                            sw.Close();
                    }
                    UserDialogue.replaceName(oldRealName, realNameTextBox.Text);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CheckInfo()
        {
            if (userNameTextBox.Text.Equals("")
                || passwordTextBox.Text.Equals("")
                || confirmPasswordTextBox.Text.Equals("")
                || realNameTextBox.Text.Equals("")
                || techLevelTextBox.Text.Equals("")
                || (!projectMenberCheckBox.Checked && !projectManagerCheckBox.Checked
                && !projectAdminCheckBox.Checked && !generalManagerCheckBox.Checked)) {
                MessageBox.Show("填入信息不完整！", "提示");
                return false;
            } else if (!passwordTextBox.Text.Equals(confirmPasswordTextBox.Text)) {
                MessageBox.Show("两次输入的密码不匹配！", "提示");
                return false;
            } else if (flag == 0) {
                SystemAdmin dialogueOwner = (SystemAdmin)this.Owner;
                if((projectAdminCheckBox.Checked && 
                    dialogueOwner.UsersTreeView.Nodes.Find("projectAdmin", false)[0].Nodes.Count > 0) 
                    || (generalManagerCheckBox.Checked && 
                    dialogueOwner.UsersTreeView.Nodes.Find("generalManager", false)[0].Nodes.Count > 0)) {
                    MessageBox.Show("只能有一个项目管理员和总经理！", "提示");
                    return false;
                } else if (dialogueOwner.UsersTreeView.Nodes.Find(userNameTextBox.Text, true).Length > 0) {
                    MessageBox.Show("用户名已存在！", "提示");
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        }

        private void UserDialogue_Load(object sender, EventArgs e)
        {
            if (flag != 0) {
                StreamReader sr = null;
                string line;
                string content = "";
                try {
                    sr = File.OpenText("users.dat");
                    while ((line = sr.ReadLine()) != null) {
                        content += (line + "\r\n");
                        if (line.StartsWith("#") && line.Split(new char [] {'#'})[1].Equals(ownerRole)) {
                            string[] info;
                            if (flag <= 2) {
                                info = sr.ReadLine().Split(new char[] { '|' });
                            } else {
                                while (!(info = sr.ReadLine().Split(new char[] { '|' }))[2].Equals(name))
                                    continue;
                            }
                            userNameTextBox.Text = info[0];
                            passwordTextBox.Text = info[1];
                            confirmPasswordTextBox.Text = info[1];
                            realNameTextBox.Text = info[2];
                            birthdayTimePicker.Text = info[3];
                            joinDateTimePicker.Text = info[4];
                            techLevelTextBox.Text = info[5];
                            oldRealName = info[2];
                            break;
                        }
                    }
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("读取用户数据信息失败！", "提示");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                } finally {
                    if (sr != null)
                        sr.Close();
                }
                switch (flag) {
                    case 1:
                        projectAdminCheckBox.Checked = true;
                        break;
                    case 3:
                        projectManagerCheckBox.Checked = true;
                        break;
                    case 4:
                        projectMenberCheckBox.Checked = true;
                        break;
                }
                roleGroupBox.Enabled = false;
            }
        }

        public static void replaceName(string oldName, string newName)
        {
            if (!oldName.Equals(newName)) {
                StreamReader sr = null;
                StreamWriter sw = null;
                string content = null;
                string line;
                string tmp;
                string tmp2;
                try {
                    sr = File.OpenText("projects.dat");
                    while ((line = sr.ReadLine()) != null) {
                        content += (line + "\r\n");
                        if (line.StartsWith("#")) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                content += (tmp + "\r\n");
                                for (int i = 0; i < 3; i++)
                                    content += (sr.ReadLine() + "\r\n");
                                tmp2 = sr.ReadLine();
                                if (tmp2.Equals(oldName))
                                    content += (newName + "\r\n");
                                else
                                    content += (tmp2 + "\r\n");
                                tmp2 = sr.ReadLine();
                                string[] members = tmp2.Split(new char[] { '|' });
                                tmp2 = "";
                                foreach (string member in members) {
                                    if (!member.Equals(oldName))
                                        tmp2 += member + "|";
                                    else
                                        tmp2 += newName + "|";
                                }
                                content += tmp2.TrimEnd('|') + "\r\n";
                            }
                            content += "\r\n";
                        }
                    }
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("读取项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sr != null)
                        sr.Close();
                }
                try {
                    sw = File.CreateText("projects.dat");
                    sw.Write(content);
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("写入项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sw != null)
                        sw.Close();
                }

                content = "";
                tmp = "";
                try {
                    sr = File.OpenText("plans.dat");
                    while ((line = sr.ReadLine()) != null) {
                        content += (line + "\r\n");
                        if (line.StartsWith("#")) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                if (tmp.Equals(oldName))
                                    content += (newName + "\r\n");
                                else
                                    content += (tmp + "\r\n");
                                for (int i = 0; i < 4; i++)
                                    content += (sr.ReadLine() + "\r\n");
                            }
                            content += "\r\n";
                        }
                    }
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("读取项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sr != null)
                        sr.Close();
                }
                try {
                    sw = File.CreateText("plans.dat");
                    sw.Write(content);
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("写入项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sw != null)
                        sw.Close();
                }

                content = "";
                tmp = "";
                try {
                    sr = File.OpenText("states.dat");
                    while ((line = sr.ReadLine()) != null) {
                        content += (line + "\r\n");
                        if (line.StartsWith("#")) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                if (tmp.Equals(oldName))
                                    content += (newName + "\r\n");
                                else
                                    content += (tmp + "\r\n");
                                for (int i = 0; i < 4; i++)
                                    content += (sr.ReadLine() + "\r\n");
                            }
                            content += "\r\n";
                        }
                    }
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("读取项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sr != null)
                        sr.Close();
                }
                try {
                    sw = File.CreateText("states.dat");
                    sw.Write(content);
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("写入项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sw != null)
                        sw.Close();
                }

                content = "";
                tmp = "";
                try {
                    sr = File.OpenText("warning.dat");
                    while ((line = sr.ReadLine()) != null) {
                        content += (line + "\r\n");
                        if (line.StartsWith("#")) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                if (tmp.Equals(oldName))
                                    content += (newName + "\r\n");
                                else
                                    content += (tmp + "\r\n");
                            }
                            content += "\r\n";
                        }
                    }
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("读取项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sr != null)
                        sr.Close();
                }
                try {
                    sw = File.CreateText("warning.dat");
                    sw.Write(content);
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("写入项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sw != null)
                        sw.Close();
                }
            }
        }
    }
}
