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
    public partial class GeneralManager : Form
    {
        private class Info
        {
            private string name;
            private string[] members;
            private decimal progress;

            public string Name {
                get {
                    return name;
                }
                set {
                    this.name = value;
                }
            }

            public string[] Members {
                get {
                    return members;
                }
                set {
                    this.members = value;
                }
            }

            public decimal Progress {
                get {
                    return progress;
                }
                set {
                    this.progress = value;
                }
            }
        }

        private List<Info> projectInfoList = null;
        private BindingSource bsProjectInfo = new BindingSource();
        private List<Dictionary<string, string>> stateList = null;

        public GeneralManager()
        {
            InitializeComponent();
        }

        private void GeneralManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void GeneralManager_Load(object sender, EventArgs e)
        {
            ProjectsInfo_Load();
            StateInfo_Load();
            projectsListBox_SelectedIndexChanged(null, null);
        }

        private void ProjectsInfo_Load()
        {
            StreamReader sr = null;
            string line;
            try {
                sr = File.OpenText("projects.dat");
                projectInfoList = new List<Info>();
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#")) {
                        Info item = new Info();
                        sr.ReadLine();
                        item.Name = sr.ReadLine();
                        for (int i = 0; i < 3; i++)
                            sr.ReadLine();
                        item.Members = sr.ReadLine().Split(new char[] { '|' });
                        projectInfoList.Add(item);
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

        private void StateInfo_Load()
        {
            double sumTask;
            double sumFinish;
            stateList = new List<Dictionary<string, string>>();
            foreach (Info project in projectsListBox.Items) {
                string name = project.Name;
                sumTask = 0;
                sumFinish = 0;
                StreamReader sr = null;
                string line;
                string tmp;
                string task;
                try {
                    sr = File.OpenText("plans.dat");
                    while ((line = sr.ReadLine()) != null) {
                        if (line.StartsWith("#") && (line.Split(new char[] { '#' })[1]).Equals(name)) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                sr.ReadLine();
                                sr.ReadLine();
                                project.Progress = Decimal.Parse((task = sr.ReadLine()).Equals("") ? "0" : task);
                                sumTask += Decimal.ToDouble(project.Progress);
                                sr.ReadLine();
                            }
                            break;
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

                try {
                    sr = File.OpenText("states.dat");
                    while ((line = sr.ReadLine()) != null) {
                        if (line.StartsWith("#") && (line.Split(new char[] { '#' })[1]).Equals(name)) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                Dictionary<string, string> state = new Dictionary<string, string>();
                                state.Add("project", name);
                                state.Add("member", tmp);
                                sr.ReadLine();
                                state.Add("percent", sr.ReadLine());
                                sumFinish += Decimal.ToDouble((Decimal.Parse(state["percent"]) * project.Progress));
                                state.Add("memberScore", sr.ReadLine());
                                state.Add("managerScore", sr.ReadLine());
                                stateList.Add(state);
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

                if (sumTask != 0)
                    project.Progress = (int)(sumFinish / sumTask);
                else
                    project.Progress = 0;
            }
        }

        private void projectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] members = ((Info)projectsListBox.SelectedItem).Members;
            membersListBox.Items.Clear();
            membersListBox.Items.AddRange(members);
            projectFinishProgressBar.Value = Decimal.ToInt32(((Info)projectsListBox.SelectedItem).Progress);
            finishPercentTextBox.Text = "";
            memberScoreTextBox.Text = "";
            managerScoreTextBox.Text = "";
        }

        private void membersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> state = stateList.Find(delegate(Dictionary<string, string> match)
            {
                return match["project"].Equals(((Info)projectsListBox.SelectedItem).Name)
                    && match["member"].Equals(membersListBox.SelectedItem);
            });
            if (state != null) {
                finishPercentTextBox.Text = state["percent"];
                memberScoreTextBox.Text = state["memberScore"];
                managerScoreTextBox.Text = state["managerScore"];
            }
        }

        private void problemReportButton_Click(object sender, EventArgs e)
        {
            if (projectsListBox.SelectedItem == null) {
                MessageBox.Show("请选择要查看报告的项目！", "提示");
                return;
            }
            ProblemReport dialogue = new ProblemReport(true, ((Info)projectsListBox.SelectedItem).Name);
            dialogue.ShowDialog(this);
        }

        private void projectRankButton_Click(object sender, EventArgs e)
        {
            if (projectsListBox.SelectedItem == null) {
                MessageBox.Show("请选择项目！", "提示");
                return;
            }
            RankGridView dialogue = new RankGridView(((Info)projectsListBox.SelectedItem).Name, 2);
            dialogue.ShowDialog(this);
        }

        private void allRankButton_Click(object sender, EventArgs e)
        {
            RankGridView dialogue = new RankGridView("", 2);
            dialogue.ShowDialog(this);
        }

    }
}
