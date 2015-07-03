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
    public partial class SystemAdmin : Form
    {
        private string[] Roles = {
            "projectMember", 
            "projectManager", 
            "generalManager", 
            "projectAdmin", 
            "systemAdmin"
        };

        private Dictionary<string, string> userInfo = null;

        public Dictionary<string, string> UserInfo {
            set {
                userInfo = value;
            }
            get {
                return userInfo;
            }
        }

        public TreeView UsersTreeView
        {
            get {
                return usersTreeView;
            }
        }

        public SystemAdmin()
        {
            InitializeComponent();
        }

        private void SystemAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void SystemAdmin_Load(object sender, EventArgs e)
        {
            RefreshTreeView();
        }

        private void ResetTextBox()
        {
            userNameTextBox.Text = "";
            passwordTextBox.Text = "";
            realNameTextBox.Text = "";
            birthdayTextBox.Text = "";
            joinDateTextBox.Text = "";
            techLevelTextBox.Text = "";
        }

        private void RefreshTreeView()
        {
            foreach (TreeNode node in usersTreeView.Nodes)
                node.Nodes.Clear();
            ResetTextBox();
            StreamReader sr = null;
            string line;
            try {
                sr = File.OpenText("users.dat");
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#")) {
                        string role = line.Split(new char[] { '#' })[1];
                        string info;
                        while ((info = sr.ReadLine()) != null && !info.Equals("")) {
                            string[] infoSet = info.Split(new char[] { '|' });
                            Dictionary<string, string> item = new Dictionary<string, string>();
                            item.Add("userName", infoSet[0]);
                            item.Add("password", infoSet[1]);
                            TreeNode treeNode1 = new TreeNode(infoSet[0]);
                            treeNode1.Name = infoSet[0];
                            if (!role.Equals("systemAdmin")) {
                                item.Add("realName", infoSet[2]);
                                item.Add("birthday", infoSet[3]);
                                item.Add("joinDate", infoSet[4]);
                                item.Add("techLevel", infoSet[5]);
                            }
                            treeNode1.Tag = item;
                            (usersTreeView.Nodes.Find(role, false)[0]).Nodes.Add(treeNode1);
                        }
                    }
                }
            } catch (FileNotFoundException fe) {
                Console.WriteLine(fe.StackTrace);
                MessageBox.Show("读取用户数据信息失败！", "提示");
                Application.Exit();
            } finally {
                if (sr != null)
                    sr.Close();
            }
        }

        private void usersTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodeName = e.Node.Name;
            if (e.Node.Parent == null || (e.Node.Parent != null && e.Node.Parent.Name.Equals("systemAdmin")))
                removeUserButton.Enabled = false;
            else
                removeUserButton.Enabled = true;
            if (e.Node.Parent == null)
                editInfoButton.Enabled = false;
            else
                editInfoButton.Enabled = true;
            bool flag = true;
            foreach(string role in Roles) {
                if (nodeName.Equals(role)) {
                    flag = false;
                    break;
                }
            }
            Dictionary<string, string> item = (Dictionary<string, string>)e.Node.Tag;
            if (flag) {
                userNameTextBox.Text = item["userName"];
                passwordTextBox.Text = item["password"];
                if (!e.Node.Parent.Name.Equals("systemAdmin")) {
                    realNameTextBox.Text = item["realName"];
                    birthdayTextBox.Text = item["birthday"];
                    joinDateTextBox.Text = item["joinDate"];
                    techLevelTextBox.Text = item["techLevel"];
                }
            } else {
                ResetTextBox();
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            UserDialogue dialogue = new UserDialogue(0, "");
            addUserButton.Enabled = false;
            if (dialogue.ShowDialog(this) == DialogResult.OK && userInfo != null) {
                StreamReader sr = null;
                StreamWriter sw = null;
                string content = null;
                string line;
                try {
                    sr = File.OpenText("users.dat");
                    while ((line = sr.ReadLine()) != null) {
                        content += (line + "\r\n");
                        if (line.StartsWith("#")) {
                            foreach (string role in userInfo["role"].Split(new char[] { ',' })) {
                                if (line.Split(new char[] { '#' })[1].Equals(role)) {
                                    content += (userInfo["userName"] + "|"
                                        + userInfo["password"] + "|"
                                        + userInfo["realName"] + "|"
                                        + userInfo["birthday"] + "|"
                                        + userInfo["joinDate"] + "|"
                                        + userInfo["techLevel"] + "\r\n");
                                    break;
                                }
                            }
                        }
                    }
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("读取用户数据信息失败！", "提示");
                    return;
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
                    return;
                } finally {
                    if (sw != null)
                        sw.Close();
                }
                RefreshTreeView();
            }
            addUserButton.Enabled = true;
        }

        private void removeUserButton_Click(object sender, EventArgs e)
        {
            TreeNode node = usersTreeView.SelectedNode;
            if (node == null) {
                MessageBox.Show("请选择要删除的用户！", "提示");
            } else {
                if (MessageBox.Show("确定要删除用户\"" + node.Text + "\"吗？", 
                    "提示", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    StreamReader sr = null;
                    StreamWriter sw = null;
                    string content = null;
                    string line;
                    try {
                        sr = File.OpenText("users.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#") || line.Equals("") ||
                                !(line.Split(new char[] { '|' })[0].Equals(node.Name))) {
                                content += (line + "\r\n");
                            }
                        }
                    } catch (FileNotFoundException fe) {
                        Console.WriteLine(fe.StackTrace);
                        MessageBox.Show("读取用户数据信息失败！", "提示");
                        return;
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
                        return;
                    } finally {
                        if (sw != null)
                            sw.Close();
                    }
                    RefreshTreeView();

                    string realName = ((Dictionary<string, string>)node.Tag)["realName"];
                    content = "";
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
                                    if (tmp2.Equals(realName))
                                        content += "-\r\n";
                                    else
                                        content += (tmp2 + "\r\n");
                                    tmp2 = sr.ReadLine();
                                    string[] members = tmp2.Split(new char[] { '|' });
                                    tmp2 = "";
                                    foreach (string member in members) {
                                        if (!member.Equals(realName))
                                            tmp2 += member + "|";
                                    }
                                    if (tmp2.Equals(""))
                                        content += "|\r\n";
                                    else
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
                                    if(tmp.Equals(realName)) {
                                        for(int i = 0; i < 4; i++)
                                            sr.ReadLine();
                                    } else {
                                        content += (tmp + "\r\n");
                                        for (int i = 0; i < 4; i++)
                                            content += (sr.ReadLine() + "\r\n");
                                    }
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
                                    if (tmp.Equals(realName)) {
                                        for (int i = 0; i < 4; i++)
                                            sr.ReadLine();
                                    } else {
                                        content += (tmp + "\r\n");
                                        for (int i = 0; i < 4; i++)
                                            content += (sr.ReadLine() + "\r\n");
                                    }
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
                                    if (!tmp.Equals(realName)) {
                                        content += (tmp + "\r\n");
                                    }
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

        private void ChangeStyle()
        {
            userNameTextBox.ReadOnly = !userNameTextBox.ReadOnly;
            editPasswordButton.Visible = !editPasswordButton.Visible;
            if (!usersTreeView.SelectedNode.Parent.Name.Equals("systemAdmin")) {
                realNameTextBox.ReadOnly = !realNameTextBox.ReadOnly;
                birthdayTextBox.Visible = !birthdayTextBox.Visible;
                birthdayTimePicker.Visible = !birthdayTextBox.Visible;
                joinDateTextBox.Visible = !joinDateTextBox.Visible;
                joinDateTimePicker.Visible = !joinDateTimePicker.Visible;
                techLevelTextBox.ReadOnly = !techLevelTextBox.ReadOnly;
            }
            editInfoButton.Visible = !editInfoButton.Visible;
            saveEditButton.Visible = !saveEditButton.Visible;
            abortEditButton.Visible = !abortEditButton.Visible;
            usersTreeView.Enabled = !usersTreeView.Enabled;
            addUserButton.Enabled = !addUserButton.Enabled;
            removeUserButton.Enabled = !removeUserButton.Enabled;
        }

        private void editInfoButton_Click(object sender, EventArgs e)
        {
            ChangeStyle();
            userInfo = (Dictionary<string, string>)usersTreeView.SelectedNode.Tag;
        }

        private void editPasswordButton_Click(object sender, EventArgs e)
        {
            ResetPassword dialogue = new ResetPassword();
            if (dialogue.ShowDialog(this) == DialogResult.OK && dialogue.Password != null)
                passwordTextBox.Text = dialogue.Password;
        }

        private void abortEditButton_Click(object sender, EventArgs e)
        {
            userNameTextBox.Text = userInfo["userName"];
            passwordTextBox.Text = userInfo["password"];
            if (!usersTreeView.SelectedNode.Parent.Name.Equals("systemAdmin")) {
                realNameTextBox.Text = userInfo["realName"];
                birthdayTextBox.Text = userInfo["birthday"];
                joinDateTextBox.Text = userInfo["joinDate"];
                techLevelTextBox.Text = userInfo["techLevel"];
            }
            ChangeStyle();
        }

        private void saveEditButton_Click(object sender, EventArgs e)
        {
            string info = userNameTextBox.Text + "|" + passwordTextBox.Text;
            if (!usersTreeView.SelectedNode.Parent.Name.Equals("systemAdmin"))
                info += ("|" + realNameTextBox.Text + "|" + birthdayTimePicker.Text + "|"
                    + joinDateTimePicker.Text + "|" + techLevelTextBox.Text);
            string oldName = userInfo["realName"];
            string newName = realNameTextBox.Text;

            StreamReader sr = null;
            StreamWriter sw = null;
            string content = null;
            string line;
            try {
                sr = File.OpenText("users.dat");
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") || line.Equals("") ||
                        !(line.Split(new char[] { '|' })[0].Equals(usersTreeView.SelectedNode.Name))) {
                        content += (line + "\r\n");
                    } else {
                        content += (info + "\r\n");
                    }
                }
            } catch (FileNotFoundException fe) {
                Console.WriteLine(fe.StackTrace);
                MessageBox.Show("读取用户数据信息失败！", "提示");
                return;
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
                return;
            } finally {
                if (sw != null)
                    sw.Close();
            }
            ChangeStyle();
            RefreshTreeView();

            UserDialogue.replaceName(oldName, newName);
        }

    }
}
