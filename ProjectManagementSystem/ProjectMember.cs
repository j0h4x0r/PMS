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
    public partial class ProjectMember : Form
    {
        private List<string> projectInfoList = null;
        private BindingSource bsProjectInfo = new BindingSource();
        private List<Dictionary<string, string>> projectPlanList = null;
        private List<Dictionary<string, string>> memberStateList = null;
        private string memberName = null;

        public ProjectMember(string name)
        {
            InitializeComponent();
            this.memberName = name;
        }

        private void ProjectMember_Load(object sender, EventArgs e)
        {
            ProjectsInfo_Load();
            ProjectsPlan_Load();
            MemberState_Load();
            projectsListBox_SelectedIndexChanged(null, null);
        }

        private void ProjectsInfo_Load()
        {
            StreamReader sr = null;
            string line;
            string member;
            try {
                sr = File.OpenText("projects.dat");
                projectInfoList = new List<string>();
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#")) {
                        sr.ReadLine();
                        line = sr.ReadLine();
                        for (int i = 0; i < 3; i++)
                            sr.ReadLine();
                        member = sr.ReadLine();
                        if (member.Split(new char[] { '|' }).Contains(memberName))
                            projectInfoList.Add(line);
                    }
                }
            } catch (FileNotFoundException fe) {
                Console.WriteLine(fe.StackTrace);
                MessageBox.Show("读取项目数据信息失败！", "提示");
                Application.Exit();
            } finally {
                if (sr != null)
                    sr.Close();
            }
            bsProjectInfo.DataSource = projectInfoList;
            projectsListBox.DataSource = bsProjectInfo;
        }

        private void ProjectsPlan_Load()
        {
            StreamReader sr = null;
            string line;
            string tmp;
            int index;
            try {
                sr = File.OpenText("plans.dat");
                projectPlanList = new List<Dictionary<string, string>>();
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") && (index = projectsListBox.FindStringExact(line.Split(new char[] { '#' })[1])) >= 0) {
                        Dictionary<string, string> projectPlan = new Dictionary<string, string>();
                        projectPlan.Add("project", (string)projectsListBox.Items[index]);
                        while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                            if (tmp.Equals(memberName)) {
                                projectPlan.Add("beginTime", sr.ReadLine());
                                projectPlan.Add("endTime", sr.ReadLine());
                                projectPlan.Add("percent", sr.ReadLine());
                                projectPlan.Add("content", sr.ReadLine());
                                projectPlanList.Add(projectPlan);
                                break;
                            }
                        }
                    }
                }
            } catch (FileNotFoundException fe) {
                Console.WriteLine(fe.StackTrace);
                MessageBox.Show("读取项目数据信息失败！", "提示");
                Application.Exit();
            } finally {
                if (sr != null)
                    sr.Close();
            }
        }

        private void MemberState_Load()
        {
            StreamReader sr = null;
            string line;
            string tmp;
            int index;
            try {
                sr = File.OpenText("states.dat");
                memberStateList = new List<Dictionary<string, string>>();
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") && (index = projectsListBox.FindStringExact(line.Split(new char[] { '#' })[1])) >= 0) {
                        Dictionary<string, string> memberState = new Dictionary<string, string>();
                        memberState.Add("project", (string)projectsListBox.Items[index]);
                        while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                            if (tmp.Equals(memberName)) {
                                memberState.Add("report", sr.ReadLine());
                                memberState.Add("percent", sr.ReadLine());
                                memberState.Add("memberScore", sr.ReadLine());
                                memberState.Add("managerScore", sr.ReadLine());
                                memberStateList.Add(memberState);
                                break;
                            }
                        }
                    }
                }
            } catch (FileNotFoundException fe) {
                Console.WriteLine(fe.StackTrace);
                MessageBox.Show("读取项目数据信息失败！", "提示");
                Application.Exit();
            } finally {
                if (sr != null)
                    sr.Close();
            }
        }

        private void ProjectMember_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool FindMatcher(Dictionary<string, string> match)
        {
            return match["project"].Equals(projectsListBox.SelectedItem);
        }

        private void projectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> plan = projectPlanList.Find(FindMatcher);
            if (plan != null) {
                beginTimeTextBox.Text = plan["beginTime"];
                endTimeTextBox.Text = plan["endTime"];
                percentTextBox.Text = plan["percent"];
                planContentTextBox.Text = plan["content"];
            } else {
                ResetProjectPlanGroupBox();
            }
            Dictionary<string, string> state = memberStateList.Find(FindMatcher);
            if (state != null) {
                reportTextBox.Text = state["report"];
                finishPercentNumericUpDown.Value = Decimal.Parse(state["percent"].Equals("") 
                    ? "0" : state["percent"]);
                memberScoreNumericUpDown.Value = Decimal.Parse(state["memberScore"].Equals("") 
                    ? "0" : state["memberScore"]);
                managerScoreNumericUpDown.Value = Decimal.Parse(state["managerScore"].Equals("") 
                    ? "0" : state["managerScore"]);
            } else {
                ResetFinishStateGroupBox();
            }
            warningLabel.Visible = false;
            StreamReader sr = null;
            string line;
            string name;
            try {
                sr = File.OpenText("warning.dat");
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") && line.Split(new char[] {'#'})[1].Equals(projectsListBox.SelectedItem)) {
                        while ((name = sr.ReadLine()) != null && !name.Equals("")) {
                            if (name.Equals(memberName))
                                warningLabel.Visible = true;
                        }
                            break;
                    }
                }
            } catch (FileNotFoundException fe) {
                Console.WriteLine(fe.StackTrace);
                MessageBox.Show("读取项目数据信息失败！", "提示");
                this.Close();
            } finally {
                if (sr != null)
                    sr.Close();
            }
        }

        private void ResetProjectPlanGroupBox()
        {
            beginTimeTextBox.Text = "";
            endTimeTextBox.Text = "";
            percentTextBox.Text = "";
            planContentTextBox.Text = "";
        }

        private void ResetFinishStateGroupBox()
        {
            reportTextBox.Text = "";
            finishPercentNumericUpDown.Value = 0;
            memberScoreNumericUpDown.Value = 0;
            managerScoreNumericUpDown.Value = 0;
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            UserDialogue dialogue = new UserDialogue(4, memberName);
            if (dialogue.ShowDialog(this) == DialogResult.OK) {
                memberName = dialogue.RoleName;
                MessageBox.Show("修改成功！", "提示");
            }
        }

        private void submitStateButton_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            string content = null;
            string line;
            try {
                sr = File.OpenText("states.dat");
                while ((line = sr.ReadLine()) != null) {
                    content += (line + "\r\n");
                    if (line.StartsWith("#") &&
                        ((string)projectsListBox.SelectedItem).Equals(line.Split(new char[] { '#' })[1])) {
                        while ((line = sr.ReadLine()) != null && !line.Equals("")) {
                            content += (line + "\r\n");
                            if (line.Equals(memberName)) {
                                for (int i = 0; i < 3; i++)
                                    sr.ReadLine();
                                content += (reportTextBox.Text + "\r\n");
                                content += (finishPercentNumericUpDown.Value + "\r\n");
                                content += (memberScoreNumericUpDown.Value + "\r\n");
                                content += (sr.ReadLine() + "\r\n");
                            } else {
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
            Dictionary<string, string> state = memberStateList.Find(FindMatcher);
            state["report"] = reportTextBox.Text;
            state["percent"] = finishPercentNumericUpDown.Value.ToString();
            state["memberScore"] = memberScoreNumericUpDown.Value.ToString();
            MessageBox.Show("提交成功！", "提示");
        }

        private void allRankButton_Click(object sender, EventArgs e)
        {
            RankGridView dialogue = new RankGridView("", 0);
            dialogue.ShowDialog(this);
        }

        private void projectRankButton_Click(object sender, EventArgs e)
        {
            if (projectsListBox.SelectedItem == null) {
                MessageBox.Show("请选择项目！", "提示");
                return;
            }
            RankGridView dialogue = new RankGridView((string)projectsListBox.SelectedItem, 0);
            dialogue.ShowDialog(this);
        }

    }
}
