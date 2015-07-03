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
    public partial class ProjectManager : Form
    {
        private List<ProjectInfo> projectInfoList = null;
        private BindingSource bsProjectInfo = new BindingSource();
        private List<Dictionary<string, string>> projectPlanList = null;
        private List<Dictionary<string, string>> memberStateList = null;
        private List<string> membersList = new List<string>();
        private BindingSource bsMembers = new BindingSource();
        private Dictionary<string, string> tmpProjectPlan = null;
        private decimal tmpFinishPercent = 0;
        private string managerName;

        public ProjectManager(string name)
        {
            InitializeComponent();
            this.managerName = name;
        }

        public ListBox ProjectsInfoListBox {
            get {
                return this.projectsListBox;
            }
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {
            ProjectInfoTab_Load();
            DevelopPlanTab_Load();
            MemberStateTab_Load();
            CalculateProgressBar();
        }

        private void ProjectInfoTab_Load()
        {
            StreamReader sr = null;
            string line;
            try {
                sr = File.OpenText("projects.dat");
                projectInfoList = new List<ProjectInfo>();
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#")) {
                        Dictionary<string, string> item = new Dictionary<string, string>();
                        item.Add("number", sr.ReadLine());
                        item.Add("name", sr.ReadLine());
                        item.Add("beginTime", sr.ReadLine());
                        item.Add("endTime", sr.ReadLine());
                        item.Add("manager", sr.ReadLine());
                        item.Add("members", sr.ReadLine());
                        ProjectInfo projectInfo = new ProjectInfo();
                        projectInfo.Info = item;
                        if (projectInfo.Info["manager"].Equals(managerName))
                            projectInfoList.Add(projectInfo);
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
            projectsListBox.DisplayMember = "Name";
        }

        private void DevelopPlanTab_Load()
        {
            StreamReader sr = null;
            string line;
            string tmp;
            try {
                sr = File.OpenText("plans.dat");
                projectPlanList = new List<Dictionary<string, string>>();
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") && projectsListBox.FindStringExact(line.Split(new char[] { '#' })[1]) >= 0) {
                        while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                            Dictionary<string, string> projectPlan = new Dictionary<string, string>();
                            projectPlan.Add("project", line.Split(new char[] { '#' })[1]);
                            projectPlan.Add("member", tmp);
                            projectPlan.Add("beginTime", sr.ReadLine());
                            projectPlan.Add("endTime", sr.ReadLine());
                            projectPlan.Add("percent", sr.ReadLine());
                            projectPlan.Add("content", sr.ReadLine());
                            projectPlanList.Add(projectPlan);
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

        private void MemberStateTab_Load()
        {
            StreamReader sr = null;
            string line;
            string tmp;
            try {
                sr = File.OpenText("states.dat");
                memberStateList = new List<Dictionary<string, string>>();
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") && projectsListBox.FindStringExact(line.Split(new char[] { '#' })[1]) >= 0) {
                        while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                            Dictionary<string, string> memberState = new Dictionary<string, string>();
                            memberState.Add("project", line.Split(new char[] { '#' })[1]);
                            memberState.Add("member", tmp);
                            memberState.Add("report", sr.ReadLine());
                            memberState.Add("percent", sr.ReadLine());
                            memberState.Add("memberScore", sr.ReadLine());
                            memberState.Add("managerScore", sr.ReadLine());
                            memberStateList.Add(memberState);
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

        private void ProjectManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ResetDevelopPlanTabTextBox()
        {
            planBeginTimeTextBox.Text = "";
            planEndTimeTextBox.Text = "";
            planPercentTextBox.Text = "";
            planContentTextBox.Text = "";
            planBeginTimePicker.ResetText();
            planEndTimePicker.ResetText();
        }

        private void ResetMemberStateTab()
        {
            memberReportTextBox.Text = "";
            memberFinishPercentNumericUpDown.Value = 0;
            memberScoreNumericUpDown.Value = 0;
            managerScoreNumericUpDown.Value = 0;
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            UserDialogue dialogue = new UserDialogue(3, managerName);
            if (dialogue.ShowDialog(this) == DialogResult.OK) {
                managerName = dialogue.RoleName;
                MessageBox.Show("修改成功！", "提示");
            }
        }

        private void projectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectsListBox.SelectedItem != null) {
                if (tabControl.SelectedTab.Name.Equals("projectInfoTab")) {
                    Dictionary<string, string> projectInfo = ((ProjectInfo)projectsListBox.SelectedItem).Info;
                    numberTextBox.Text = projectInfo["number"];
                    nameTextBox.Text = projectInfo["name"];
                    beginTimeTextBox.Text = projectInfo["beginTime"];
                    endTimeTextBox.Text = projectInfo["endTime"];
                    string members = "";
                    foreach (string member in projectInfo["members"].Split(new char[] { '|' }))
                        members += member + "\r\n";
                    membersTextBox.Text = members;
                    if (projectPlanList != null && memberStateList != null) {
                        CalculateProgressBar();
                    }
                }
                if (tabControl.SelectedTab.Name.Equals("developPlanTab")) {
                    string[] members = ((ProjectInfo)projectsListBox.SelectedItem)
                        .Info["members"].Split(new char[] { '|' });
                    membersListBox1.Items.Clear();
                    membersListBox1.Items.AddRange(members);
                    ResetDevelopPlanTabTextBox();
                }
                if (tabControl.SelectedTab.Name.Equals("memberStateTab")) {
                    string[] members = ((ProjectInfo)projectsListBox.SelectedItem)
                        .Info["members"].Split(new char[] { '|' });
                    membersList.Clear();
                    membersList.AddRange(members);
                    membersListBox2.DataSource = bsMembers;
                    bsMembers.DataSource = membersList;
                    bsMembers.ResetBindings(true);
                    ResetMemberStateTab();
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectsListBox_SelectedIndexChanged(sender, e);
        }

        private void membersListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> selectedPlan = projectPlanList.Find(PlanFindMatcher);
            if (selectedPlan != null) {
                planBeginTimeTextBox.Text = selectedPlan["beginTime"];
                planEndTimeTextBox.Text = selectedPlan["endTime"];
                planPercentTextBox.Text = selectedPlan["percent"];
                planContentTextBox.Text = selectedPlan["content"];
            } else {
                ResetDevelopPlanTabTextBox();
            }
        }

        private void membersListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> selectedState = memberStateList.Find(StateFindMatcher);
            if (selectedState != null) {
                memberReportTextBox.Text = selectedState["report"];
                memberFinishPercentNumericUpDown.Value = Decimal.Parse(selectedState["percent"].Equals("") 
                    ? "0" : selectedState["percent"]);
                memberScoreNumericUpDown.Value = Decimal.Parse(selectedState["memberScore"].Equals("") 
                    ? "0" : selectedState["memberScore"]);
                managerScoreNumericUpDown.Value = Decimal.Parse(selectedState["managerScore"].Equals("") 
                    ? "0" : selectedState["managerScore"]);
            } else {
                ResetMemberStateTab();
            }
            finishPercentConfirmButton.Enabled = false;
            finishPercentCancelButton.Enabled = false;
            tmpFinishPercent = memberFinishPercentNumericUpDown.Value;
        }

        private void CalculateProgressBar()
        {
            double sumTask = 0;
            double sumFinish = 0;
            if (projectsListBox.SelectedItem != null) {
                Dictionary<string, string> projectInfo = ((ProjectInfo)projectsListBox.SelectedItem).Info;
                string project = ((ProjectInfo)projectsListBox.SelectedItem).Name;
                foreach (string member in projectInfo["members"].Split(new char[] { '|' })) {
                    Dictionary<string, string> plan = projectPlanList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["project"].Equals(project) && match["member"].Equals(member);
                    });
                    Dictionary<string, string> state = memberStateList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["project"].Equals(project) && match["member"].Equals(member);
                    });
                    if (plan != null && state != null) {
                        sumTask += Double.Parse(plan["percent"]);
                        sumFinish += Double.Parse(plan["percent"]) * Double.Parse(state["percent"]);
                    }
                }
            }
            if (sumTask != 0)
                projectFinishProgressBar.Value = (int)(sumFinish / sumTask);
            else
                projectFinishProgressBar.Value = 0;
        }

        private bool PlanFindMatcher(Dictionary<string, string> match)
        {
            return match["project"].Equals(((ProjectInfo)projectsListBox.SelectedItem).Name) 
                && match["member"].Equals(membersListBox1.SelectedItem);
        }

        private bool StateFindMatcher(Dictionary<string, string> match)
        {
            return match["project"].Equals(((ProjectInfo)projectsListBox.SelectedItem).Name) 
                && match["member"].Equals(membersListBox2.SelectedItem);
        }

        private void ChangeProjectPlanTabStyle()
        {
            planBeginTimeTextBox.Visible = !planBeginTimeTextBox.Visible;
            planBeginTimePicker.Visible = !planBeginTimePicker.Visible;
            planEndTimeTextBox.Visible = !planEndTimeTextBox.Visible;
            planEndTimePicker.Visible = !planEndTimePicker.Visible;
            planPercentTextBox.ReadOnly = !planPercentTextBox.ReadOnly;
            planContentTextBox.ReadOnly = !planContentTextBox.ReadOnly;
            editPlanButton.Visible = !editPlanButton.Visible;
            saveEditButton.Visible = !saveEditButton.Visible;
            abortEditButton.Visible = !abortEditButton.Visible;
            projectsListBox.Enabled = !projectsListBox.Enabled;
            membersListBox1.Enabled = !membersListBox1.Enabled;
            editProfileButton.Enabled = !editProfileButton.Enabled;
        }

        private void editPlanButton_Click(object sender, EventArgs e)
        {
            if (membersListBox1.SelectedItem == null) {
                MessageBox.Show("请选择要编辑计划的组员！", "提示");
                return;
            }
            ChangeProjectPlanTabStyle();
            if (!planBeginTimeTextBox.Text.Equals(""))
                planBeginTimePicker.Text = planBeginTimeTextBox.Text;
            if (!planEndTimeTextBox.Text.Equals(""))
                planEndTimePicker.Text = planEndTimeTextBox.Text;
            tmpProjectPlan = null;
            tmpProjectPlan = projectPlanList.Find(PlanFindMatcher);
        }

        private void abortEditButton_Click(object sender, EventArgs e)
        {
            if (tmpProjectPlan != null) {
                planBeginTimeTextBox.Text = tmpProjectPlan["beginTime"];
                planEndTimeTextBox.Text = tmpProjectPlan["endTime"];
                planPercentTextBox.Text = tmpProjectPlan["percent"];
                planContentTextBox.Text = tmpProjectPlan["content"];
            } else {
                ResetDevelopPlanTabTextBox();
            }
            ChangeProjectPlanTabStyle();
        }

        private void saveEditButton_Click(object sender, EventArgs e)
        {
            if (!CheckPlanEdit()) {
                MessageBox.Show("计划起止时间必须在项目起止时间之内！", "提示");
                return;
            }
            string info = membersListBox1.SelectedItem + "\r\n"
                + planBeginTimePicker.Text + "\r\n" + planEndTimePicker.Text + "\r\n"
                + planPercentTextBox.Text + "\r\n" + planContentTextBox.Text + "\r\n";
            StreamReader sr = null;
            StreamWriter sw = null;
            string content = null;
            string line;
            bool flag = false;
            try {
                sr = File.OpenText("plans.dat");
                while ((line = sr.ReadLine()) != null) {
                    content += (line + "\r\n");
                    if (line.StartsWith("#") && 
                        ((ProjectInfo)projectsListBox.SelectedItem).Name.Equals(line.Split(new char[] {'#'})[1])) {
                            while ((line = sr.ReadLine()) != null && !line.Equals("")) {
                                if (line.Equals(membersListBox1.SelectedItem)) {
                                    for (int i = 0; i < 4; i++)
                                        sr.ReadLine();
                                    content += info;
                                    flag = true;
                                } else {
                                    content += (line + "\r\n");
                                    for (int i = 0; i < 4; i++)
                                        content += (sr.ReadLine() + "\r\n");
                                }
                            }
                            if (flag == false)
                                content += (info + "\r\n");
                            else
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
            ChangeProjectPlanTabStyle();
            DevelopPlanTab_Load();
            membersListBox1_SelectedIndexChanged(null, null);
        }

        private bool CheckPlanEdit()
        {
            string[] begin = ((ProjectInfo)projectsListBox.SelectedItem).Info["beginTime"]
                .Split(new char[] { '年', '月', '日' });
            string[] end = ((ProjectInfo)projectsListBox.SelectedItem).Info["endTime"]
                .Split(new char[] { '年', '月', '日' });
            string[] beginTime = planBeginTimePicker.Text.Split(new char[] { '年', '月', '日' });
            string[] endTime = planEndTimePicker.Text.Split(new char[] { '年', '月', '日' });
            DateTime beginDate = new DateTime(Int32.Parse(begin[0]), Int32.Parse(begin[1]), Int32.Parse(begin[2]));
            DateTime endDate = new DateTime(Int32.Parse(end[0]), Int32.Parse(end[1]), Int32.Parse(end[2]));
            DateTime planBeginDate = new DateTime(Int32.Parse(beginTime[0]), Int32.Parse(beginTime[1]), Int32.Parse(beginTime[2]));
            DateTime planEndDate = new DateTime(Int32.Parse(endTime[0]), Int32.Parse(endTime[1]), Int32.Parse(endTime[2]));
            return (beginDate.CompareTo(planBeginDate) <= 0 && endDate.CompareTo(planEndDate) >= 0);
        }

        private void memberFinishPercentNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            finishPercentConfirmButton.Enabled = true;
            finishPercentCancelButton.Enabled = true;
        }

        private void finishPercentCancelButton_Click(object sender, EventArgs e)
        {
            memberFinishPercentNumericUpDown.Value = tmpFinishPercent;
            finishPercentConfirmButton.Enabled = false;
            finishPercentCancelButton.Enabled = false;
        }

        private void finishPercentConfirmButton_Click(object sender, EventArgs e)
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
                        ((ProjectInfo)projectsListBox.SelectedItem).Name.Equals(line.Split(new char[] { '#' })[1])) {
                        while ((line = sr.ReadLine()) != null && !line.Equals("")) {
                            content += (line + "\r\n");
                            if (line.Equals(membersListBox2.SelectedItem)) {
                                content += (sr.ReadLine() + "\r\n");
                                sr.ReadLine();
                                content += (memberFinishPercentNumericUpDown.Value + "\r\n");
                                content += (sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n");
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
            Dictionary<string, string> state = memberStateList.Find(delegate(Dictionary<string, string> match)
            {
                return match["member"].Equals(membersListBox2.SelectedItem);
            });
            state["percent"] = memberFinishPercentNumericUpDown.Value.ToString();
            finishPercentConfirmButton.Enabled = false;
            finishPercentCancelButton.Enabled = false;
        }

        private void managerScoreConfirmButton_Click(object sender, EventArgs e)
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
                        ((ProjectInfo)projectsListBox.SelectedItem).Name.Equals(line.Split(new char[] { '#' })[1])) {
                        while ((line = sr.ReadLine()) != null && !line.Equals("")) {
                            content += (line + "\r\n");
                            if (line.Equals(membersListBox2.SelectedItem)) {
                                for(int i = 0; i < 3; i++)
                                    content += (sr.ReadLine() + "\r\n");
                                sr.ReadLine();
                                content += (managerScoreNumericUpDown.Value + "\r\n");
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
            Dictionary<string, string> state = memberStateList.Find(delegate(Dictionary<string, string> match)
            {
                return match["member"].Equals(membersListBox2.SelectedItem);
            });
            state["managerScore"] = managerScoreNumericUpDown.Value.ToString();
            MessageBox.Show("评分成功！", "提示");
        }

        private void sortByFinishPercentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByFinishPercentRadioButton.Checked == true) {
                membersList.Sort(delegate(string x, string y)
                {
                    Dictionary<string, string> state1 = memberStateList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["member"].Equals(x);
                    });
                    Dictionary<string, string> state2 = memberStateList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["member"].Equals(y);
                    });
                    return (Int32.Parse(state2["percent"].Equals("") ? "0" : state2["percent"]) 
                        - Int32.Parse(state1["percent"].Equals("") ? "0" : state1["percent"]));
                });
                bsMembers.ResetBindings(true);
            }
        }

        private void sortByMemberScoreRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByMemberScoreRadioButton.Checked == true) {
                membersList.Sort(delegate(string x, string y)
                {
                    Dictionary<string, string> state1 = memberStateList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["member"].Equals(x);
                    });
                    Dictionary<string, string> state2 = memberStateList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["member"].Equals(y);
                    });
                    return (Int32.Parse(state2["memberScore"].Equals("") ? "0" : state2["memberScore"])
                        - Int32.Parse(state1["memberScore"].Equals("") ? "0" : state1["memberScore"]));
                });
                bsMembers.ResetBindings(true);
            }
        }

        private void sortByManagerScoreRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByManagerScoreRadioButton.Checked == true) {
                membersList.Sort(delegate(string x, string y)
                {
                    Dictionary<string, string> state1 = memberStateList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["member"].Equals(x);
                    });
                    Dictionary<string, string> state2 = memberStateList.Find(delegate(Dictionary<string, string> match)
                    {
                        return match["member"].Equals(y);
                    });
                    return (Int32.Parse(state2["managerScore"].Equals("") ? "0" : state2["managerScore"])
                        - Int32.Parse(state1["managerScore"].Equals("") ? "0" : state1["managerScore"]));
                });
                bsMembers.ResetBindings(true);
            }
        }

        private void editProblemReportButton_Click(object sender, EventArgs e)
        {
            if (projectsListBox.SelectedItem == null) {
                MessageBox.Show("请选择要编辑报告的项目！", "提示");
                return;
            }
            ProblemReport dialogue = new ProblemReport(false, ((ProjectInfo)projectsListBox.SelectedItem).Name);
            if(dialogue.ShowDialog(this) == DialogResult.OK)
                MessageBox.Show("提交成功！", "提示");
        }

        private void projectRankButton_Click(object sender, EventArgs e)
        {
            if (projectsListBox.SelectedItem == null) {
                MessageBox.Show("请选择项目！", "提示");
                return;
            }
            RankGridView dialogue = new RankGridView(((ProjectInfo)projectsListBox.SelectedItem).Name, 1);
            dialogue.ShowDialog(this);
        }

    }
}
