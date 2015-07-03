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
    public partial class ProjectDialogue : Form
    {
        private bool isAdd;
        private ProjectInfo newInfo;
        public ProjectDialogue(bool isAdd)
        {
            InitializeComponent();
            this.isAdd = isAdd;
        }

        public ProjectInfo NewInfo {
            get {
                return newInfo;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (CheckInfo()) {
                if (isAdd) {
                    newInfo = new ProjectInfo();
                    Dictionary<string, string> item = new Dictionary<string, string>();
                    item.Add("number", numberTextBox.Text);
                    item.Add("name", nameTextBox.Text);
                    item.Add("beginTime", beginDateTimePicker.Text);
                    item.Add("endTime", endDateTimePicker.Text);
                    item.Add("manager", managerComboBox.Text);
                    string members = "";
                    for (int i = 0; i < membersCheckedListBox.CheckedItems.Count; i++)
                        members += (membersCheckedListBox.CheckedItems[i].ToString() + "|");
                    members = members.TrimEnd('|');
                    item.Add("members", members);
                    newInfo.Info = item;
                } else {
                    ProjectAdmin dialogueOwner = (ProjectAdmin)this.Owner;
                    ProjectInfo project = (ProjectInfo)dialogueOwner.ProjectsListBox.SelectedItem;
                    project.Info["number"] = numberTextBox.Text;
                    project.Info["name"] = nameTextBox.Text;
                    project.Info["beginTime"] = beginDateTimePicker.Text;
                    project.Info["endTime"] = endDateTimePicker.Text;
                    project.Info["manager"] = managerComboBox.Text;
                    string members = "";
                    for (int i = 0; i < membersCheckedListBox.CheckedItems.Count; i++)
                        members += (membersCheckedListBox.CheckedItems[i].ToString() + "|");
                    members = members.TrimEnd('|');
                    project.Info["members"] = members;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool CheckInfo()
        {
            if (numberTextBox.Text.Equals("") || nameTextBox.Text.Equals("")
                || managerComboBox.Text.Equals("") || membersCheckedListBox.CheckedItems.Count == 0) {
                MessageBox.Show("填入信息不完整！", "提示");
                return false;
            } else if(isAdd == true && ((ProjectAdmin)this.Owner).ProjectsListBox.FindStringExact(nameTextBox.Text) >= 0){
                MessageBox.Show("项目名称不能重复！", "提示");
                return false;
            }else {
                string[] beginTime = beginDateTimePicker.Text.Split(new char[] { '年', '月', '日' });
                string[] endTime = endDateTimePicker.Text.Split(new char[] { '年', '月', '日' });
                DateTime begin = new DateTime(Int32.Parse(beginTime[0]), Int32.Parse(beginTime[1]), Int32.Parse(beginTime[2]));
                DateTime end = new DateTime(Int32.Parse(endTime[0]), Int32.Parse(endTime[1]), Int32.Parse(endTime[2]));
                if (begin.CompareTo(end) > 0) {
                    MessageBox.Show("开始时间必须早于结束时间！", "提示");
                    return false;
                } else {
                    return true;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ProjectDialogue_Load(object sender, EventArgs e)
        {
            StreamReader sr = null;
            string line;
            try {
                sr = File.OpenText("users.dat");
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#")) {
                        if (line.Split(new char[] { '#' })[1].Equals("projectManager")) {
                            string info;
                            while ((info = sr.ReadLine()) != null && !info.Equals(""))
                                managerComboBox.Items.Add(info.Split(new char[] { '|' })[2]);
                        } else if (line.Split(new char[] { '#' })[1].Equals("projectMember")) {
                            string info;
                            while ((info = sr.ReadLine()) != null && !info.Equals(""))
                                membersCheckedListBox.Items.Add(info.Split(new char[] { '|' })[2]);
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
            if (isAdd == true) {
                submitButton.Text = "添加";
            } else {
                submitButton.Text = "修改";
                ProjectAdmin dialogueOwner = (ProjectAdmin)this.Owner;
                Dictionary<string, string> itemInfo = ((ProjectInfo)dialogueOwner.ProjectsListBox.SelectedItem).Info;
                numberTextBox.Text = itemInfo["number"];
                nameTextBox.Text = itemInfo["name"];
                beginDateTimePicker.Text = itemInfo["beginTime"];
                endDateTimePicker.Text = itemInfo["endTime"];
                managerComboBox.Text = itemInfo["manager"];
                string[] members = itemInfo["members"].Split(new char[] {'|'});
                foreach (string member in members) {
                    if (membersCheckedListBox.FindStringExact(member) >= 0)
                        membersCheckedListBox.SetItemChecked(membersCheckedListBox.FindStringExact(member),true);
                }
            }
        }
    }
}
