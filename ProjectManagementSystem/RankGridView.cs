using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

namespace ProjectManagementSystem
{
    public partial class RankGridView : Form
    {
        private string projectName = null;
        private int role;
        private List<StateInfo> stateList = null;
        private BindingSource bs = new BindingSource();

        public RankGridView(string project, int role)
        {
            InitializeComponent();
            this.projectName = project;
            this.role = role;
        }

        private void RankGridView_Load(object sender, EventArgs e)
        {
            if (projectName.Equals("")) {
                StreamReader sr = null;
                string line;
                string tmp;
                try {
                    sr = File.OpenText("states.dat");
                    stateList = new List<StateInfo>();
                    while ((line = sr.ReadLine()) != null) {
                        if (line.StartsWith("#")) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                StateInfo state = new StateInfo();
                                state.Project = line.Split(new char[] { '#' })[1];
                                state.Name = tmp;
                                sr.ReadLine();
                                state.FinishPercent = sr.ReadLine();
                                state.MemberScore = sr.ReadLine();
                                state.ManagerScore = sr.ReadLine();
                                state.IsWarning = "false";
                                stateList.Add(state);
                            }
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
            } else {
                StreamReader sr = null;
                string line;
                string tmp;
                try {
                    sr = File.OpenText("states.dat");
                    stateList = new List<StateInfo>();
                    while ((line = sr.ReadLine()) != null) {
                        if (line.StartsWith("#") && line.Split(new char[] {'#'})[1].Equals(projectName)) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                StateInfo state = new StateInfo();
                                state.Project = projectName;
                                state.Name = tmp;
                                sr.ReadLine();
                                state.FinishPercent = sr.ReadLine();
                                state.MemberScore = sr.ReadLine();
                                state.ManagerScore = sr.ReadLine();
                                state.IsWarning = "false";
                                stateList.Add(state);
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
            Warning_Load();
            if (!projectName.Equals("")) {
                rankDataGridView.Columns["project"].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (role == 0) {
                    rankDataGridView.Columns["project"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    rankDataGridView.Columns["finishPercent"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    rankDataGridView.Columns["managerScore"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    rankDataGridView.Columns["memberScore"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    stateList.Sort(delegate(StateInfo x, StateInfo y)
                    {
                        int xManagerScore = Int32.Parse(x.ManagerScore);
                        int yManagerScore = Int32.Parse(y.ManagerScore);
                        return yManagerScore - xManagerScore;
                    });
                }
            }
            rankDataGridView.AutoGenerateColumns = false;
            rankDataGridView.RowHeadersVisible = false;
            bs.DataSource = stateList;
            rankDataGridView.DataSource = bs;
            rankDataGridView.Columns["name"].DataPropertyName = "Name";
            rankDataGridView.Columns["project"].DataPropertyName = "Project";
            rankDataGridView.Columns["finishPercent"].DataPropertyName = "finishPercent";
            rankDataGridView.Columns["memberScore"].DataPropertyName = "memberScore";
            rankDataGridView.Columns["managerScore"].DataPropertyName = "managerScore";
            rankDataGridView.Columns["warning"].DataPropertyName = "IsWarning";
        }

        private void Warning_Load()
        {
            StreamReader sr = null;
            string line;
            string name;
            StateInfo state;
            try {
                sr = File.OpenText("warning.dat");
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#")) {
                        while ((name = sr.ReadLine()) != null && !name.Equals("")) {
                            if((state = stateList.Find(delegate(StateInfo match)
                            {
                                return match.Project.Equals(line.Split(new char[] {'#'})[1]) && match.Name.Equals(name);
                            })) != null) {
                                state.IsWarning = "true";
                            }
                        }
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
            if (role != 2)
                rankDataGridView.Columns["warning"].ReadOnly = true;
        }

        private void rankDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex) {
                case 1:
                    if (projectName.Equals("")) {
                        stateList.Sort(delegate(StateInfo x, StateInfo y)
                        {
                            CultureInfo tmp = Thread.CurrentThread.CurrentCulture;
                            Thread.CurrentThread.CurrentCulture = new CultureInfo(2052);
                            int result = x.Project.CompareTo(y.Project);
                            Thread.CurrentThread.CurrentCulture = tmp;
                            return result;
                        });
                    }
                    break;
                case 2:
                    if (role > 0 || projectName.Equals("")) {
                        stateList.Sort(delegate(StateInfo x, StateInfo y)
                        {
                            int xPercent = Int32.Parse(x.FinishPercent);
                            int yPercent = Int32.Parse(y.FinishPercent);
                            return yPercent - xPercent;
                        });
                    }
                    break;
                case 3:
                    if (role > 0 || projectName.Equals("")) {
                        stateList.Sort(delegate(StateInfo x, StateInfo y)
                        {
                            int xmemberScore = Int32.Parse(x.MemberScore);
                            int ymemberScore = Int32.Parse(y.MemberScore);
                            return ymemberScore - xmemberScore;
                        });
                    }
                    break;
                case 4:
                    stateList.Sort(delegate(StateInfo x, StateInfo y)
                    {
                        int xManagerScore = Int32.Parse(x.ManagerScore);
                        int yManagerScore = Int32.Parse(y.ManagerScore);
                        return yManagerScore - xManagerScore;
                    });
                    break;
            }
            bs.ResetBindings(true);
        }

        private void rankDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && role == 2) {
                string name = rankDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string project = rankDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                StateInfo state;
                if ((state = stateList.Find(delegate(StateInfo match)
                {
                    return match.Project.Equals(project) && match.Name.Equals(name);
                })) != null) {
                    state.IsWarning = (state.IsWarning.Equals("true")) ? "false" : "true";
                }
                StreamReader sr = null;
                StreamWriter sw = null;
                string line;
                string tmp;
                string content = null;
                try {
                    sr = File.OpenText("warning.dat");
                    while ((line = sr.ReadLine()) != null) {
                        content += (line + "\r\n");
                        if (line.StartsWith("#")) {
                            while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                if (!(line.Split(new char[] {'#'})[1].Equals(project) && tmp.Equals(name))) {
                                    content += (tmp + "\r\n");
                                }
                            }
                            if (line.Split(new char[] {'#'})[1].Equals(project) 
                                && rankDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("true"))
                                content += (name + "\r\n");
                            content += "\r\n";
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

    public class StateInfo
    {
        private string name;
        private string project;
        private string finishPercent;
        private string memberScore;
        private string managerScore;
        private bool isWarning;

        public string Name {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }

        public string Project {
            get {
                return project;
            }
            set {
                this.project = value;
            }
        }

        public string FinishPercent {
            get {
                return finishPercent;
            }
            set {
                this.finishPercent = value;
            }
        }

        public string MemberScore {
            get {
                return memberScore;
            }
            set {
                this.memberScore = value;
            }
        }

        public string ManagerScore {
            get {
                return managerScore;
            }
            set {
                this.managerScore = value;
            }
        }

        public string IsWarning {
            get {
                return (isWarning == true) ? "true" : "false";
            }
            set {
                this.isWarning = (value.Equals("true")) ? true : false;
            }
        }
    }
}
