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
    public partial class ProjectAdmin : Form
    {
        private List<ProjectInfo> projectInfoList = null;
        private BindingSource bs = new BindingSource();

        public ProjectAdmin()
        {
            InitializeComponent();
        }

        private void ProjectAdmin_Load(object sender, EventArgs e)
        {
            RefreshListBox();
        }

        private void ProjectAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public ListBox ProjectsListBox {
            get {
                return projectsListBox;
            }
        }

        private void ResetTextBox()
        {
            numberTextBox.Text = "";
            nameTextBox.Text = "";
            beginTimeTextBox.Text = "";
            endTimeTextBox.Text = "";
            managerTextBox.Text = "";
            membersTextBox.Text = "";
        }

        private void RefreshListBox()
        {
            projectsListBox.Items.Clear();
            ResetTextBox();
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
            bs.DataSource = projectInfoList;
            projectsListBox.DataSource = bs;
            projectsListBox.DisplayMember = "Name";
        }

        private void ProjectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> projectInfo = ((ProjectInfo)projectsListBox.SelectedItem).Info;
            numberTextBox.Text = projectInfo["number"];
            nameTextBox.Text = projectInfo["name"];
            beginTimeTextBox.Text = projectInfo["beginTime"];
            endTimeTextBox.Text = projectInfo["endTime"];
            managerTextBox.Text = projectInfo["manager"];
            string members = "";
            foreach(string member in projectInfo["members"].Split(new char[] {'|'}))
                members += member + "\r\n";
            membersTextBox.Text = members;
        }

        private void SortByNumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByNumberRadioButton.Checked == true) {
                projectInfoList.Sort(delegate(ProjectInfo x, ProjectInfo y)
                {
                    string xNumber = x.Info["number"];
                    string yNumber = y.Info["number"];
                    return xNumber.CompareTo(yNumber);
                });
                bs.ResetBindings(true);
            }
        }

        private void SortByEndTimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByEndTimeRadioButton.Checked == true) {
                projectInfoList.Sort(delegate(ProjectInfo x, ProjectInfo y)
                {
                    string[] xTime = x.Info["endTime"].Split(new char[] {'年', '月', '日'});
                    string[] yTime = y.Info["endTime"].Split(new char[] { '年', '月', '日' });
                    DateTime xDate = new DateTime(Int32.Parse(xTime[0]), Int32.Parse(xTime[1]), Int32.Parse(xTime[2]));
                    DateTime yDate = new DateTime(Int32.Parse(yTime[0]), Int32.Parse(yTime[1]), Int32.Parse(yTime[2]));
                    return xDate.CompareTo(yDate);
                });
                bs.ResetBindings(true);
            }
        }

        private void SortByBeginTimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByBeginTimeRadioButton.Checked == true) {
                projectInfoList.Sort(delegate(ProjectInfo x, ProjectInfo y)
                {
                    string[] xTime = x.Info["beginTime"].Split(new char[] { '年', '月', '日' });
                    string[] yTime = y.Info["beginTime"].Split(new char[] { '年', '月', '日' });
                    DateTime xDate = new DateTime(Int32.Parse(xTime[0]), Int32.Parse(xTime[1]), Int32.Parse(xTime[2]));
                    DateTime yDate = new DateTime(Int32.Parse(yTime[0]), Int32.Parse(yTime[1]), Int32.Parse(yTime[2]));
                    return xDate.CompareTo(yDate);
                });
                bs.ResetBindings(true);
            }
        }

        private void SortByManagerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sortByManagerRadioButton.Checked == true) {
                projectInfoList.Sort(delegate(ProjectInfo x, ProjectInfo y)
                {
                    CultureInfo tmp = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(2052); 
                    string xManager = x.Info["manager"];
                    string yManager = y.Info["manager"];
                    int result = xManager.CompareTo(yManager);
                    Thread.CurrentThread.CurrentCulture = tmp;
                    return result;
                });
                bs.ResetBindings(true);
            }
        }

        private void AddProjectButton_Click(object sender, EventArgs e)
        {
            ProjectDialogue dialogue = new ProjectDialogue(true);
            if (dialogue.ShowDialog(this) == DialogResult.OK && dialogue.NewInfo != null) {
                StreamReader sr = null;
                StreamWriter sw = null;
                string content = null;
                string line;
                try {
                    sr = File.OpenText("projects.dat");
                    while ((line = sr.ReadLine()) != null)
                        content += (line + "\r\n");
                    content += "#\r\n";
                    content += dialogue.NewInfo.Info["number"] + "\r\n";
                    content += dialogue.NewInfo.Info["name"] + "\r\n";
                    content += dialogue.NewInfo.Info["beginTime"] + "\r\n";
                    content += dialogue.NewInfo.Info["endTime"] + "\r\n";
                    content += dialogue.NewInfo.Info["manager"] + "\r\n";
                    content += dialogue.NewInfo.Info["members"] + "\r\n\r\n";
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
                projectInfoList.Add(dialogue.NewInfo);
                bs.ResetBindings(true);

                content = "";
                try {
                    sr = File.OpenText("plans.dat");
                    while ((line = sr.ReadLine()) != null)
                        content += (line + "\r\n");
                    content += ("#" + dialogue.NewInfo.Info["name"] + "\r\n");
                    foreach(string member in dialogue.NewInfo.Info["members"].Split(new char[] { '|' }))
                        content += (member + "\r\n" + 
                            dialogue.NewInfo.Info["beginTime"] + "\r\n" +
                            dialogue.NewInfo.Info["endTime"] + "\r\n" +
                            "0" + "\r\n" + "-" + "\r\n");
                    content += "\r\n";
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
                try {
                    sr = File.OpenText("states.dat");
                    while ((line = sr.ReadLine()) != null)
                        content += (line + "\r\n");
                    content += ("#" + dialogue.NewInfo.Info["name"] + "\r\n");
                    foreach (string member in dialogue.NewInfo.Info["members"].Split(new char[] { '|' }))
                        content += (member + "\r\n" + "-" + "\r\n" + "0" + "\r\n" + "0" + "\r\n" + "0" + "\r\n");
                    content += "\r\n";
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
                try {
                    sr = File.OpenText("reports.dat");
                    while ((line = sr.ReadLine()) != null)
                        content += (line + "\r\n");
                    content += ("#" + dialogue.NewInfo.Info["name"] + "\r\n\r\n");
                } catch (FileNotFoundException fe) {
                    Console.WriteLine(fe.StackTrace);
                    MessageBox.Show("读取项目数据信息失败！", "提示");
                    return;
                } finally {
                    if (sr != null)
                        sr.Close();
                }
                try {
                    sw = File.CreateText("reports.dat");
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
                try {
                    sr = File.OpenText("warning.dat");
                    while ((line = sr.ReadLine()) != null)
                        content += (line + "\r\n");
                    content += ("#" + dialogue.NewInfo.Info["name"] + "\r\n\r\n");
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

        private void RemoveProjectButton_Click(object sender, EventArgs e)
        {
            ProjectInfo project = (ProjectInfo)projectsListBox.SelectedItem;
            if (project == null) {
                MessageBox.Show("请选择要删除的项目！", "提示");
            } else {
                if (MessageBox.Show("确定要删除项目\"" + project.Name + "\"吗？",
                    "提示", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    StreamReader sr = null;
                    StreamWriter sw = null;
                    string content = null;
                    string line;
                    string tmp = null;
                    try {
                        sr = File.OpenText("projects.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#")) {
                                tmp = "";
                                tmp += (line + "\r\n");
                                tmp += (sr.ReadLine() + "\r\n");
                                line = sr.ReadLine();
                                tmp += (line + "\r\n");
                                if (line.Equals(project.Name))
                                    while ((line = sr.ReadLine()) != null && !line.Equals(""))
                                        continue;
                                else
                                    content += tmp;
                            } else {
                                content += (line + "\r\n");
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
                    projectInfoList.Remove(project);
                    bs.ResetBindings(true);

                    content = "";
                    try {
                        sr = File.OpenText("plans.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#") && line.Split(new char[] {'#'})[1].Equals(project.Name)) {
                                while ((tmp = sr.ReadLine()) != "")
                                    continue;
                            } else {
                                content += (line + "\r\n");
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
                    try {
                        sr = File.OpenText("states.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(project.Name)) {
                                while ((tmp = sr.ReadLine()) != "")
                                    continue;
                            } else {
                                content += (line + "\r\n");
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
                    try {
                        sr = File.OpenText("reports.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(project.Name)) {
                                while ((tmp = sr.ReadLine()) != "")
                                    continue;
                            } else {
                                content += (line + "\r\n");
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
                        sw = File.CreateText("reports.dat");
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
                    try {
                        sr = File.OpenText("warning.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(project.Name)) {
                                while ((tmp = sr.ReadLine()) != "")
                                    continue;
                            } else {
                                content += (line + "\r\n");
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

        private void EditInfoButton_Click(object sender, EventArgs e)
        {
            if (projectsListBox.SelectedItem == null) {
                MessageBox.Show("请选择要编辑的项目！", "提示");
            } else {
                ProjectDialogue dialogue = new ProjectDialogue(false);
                if (dialogue.ShowDialog(this) == DialogResult.OK) {
                    ProjectInfo project = (ProjectInfo)projectsListBox.SelectedItem;
                    StreamReader sr = null;
                    StreamWriter sw = null;
                    string content = null;
                    string tmp;
                    string tmp2;
                    string line;
                    try {
                        sr = File.OpenText("projects.dat");
                        while ((line = sr.ReadLine()) != null) {
                            content += (line + "\r\n");
                            if (line.StartsWith("#")) {
                                tmp = sr.ReadLine() + "\r\n";
                                if((tmp2 = sr.ReadLine()).Equals(project.Name)) {
                                    content += project.Info["number"] + "\r\n"
                                        + project.Info["name"] + "\r\n"
                                        + project.Info["beginTime"] + "\r\n"
                                        + project.Info["endTime"] + "\r\n"
                                        + project.Info["manager"] + "\r\n"
                                        + project.Info["members"] + "\r\n";
                                    for (int i = 0; i < 4; i++)
                                        sr.ReadLine();
                                } else {
                                    content += (tmp + tmp2 + "\r\n"
                                        + sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n"
                                        + sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n");
                                }
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
                    bs.ResetBindings(true);
                    ProjectsListBox_SelectedIndexChanged(null, null);

                    content = "";
                    tmp = "";
                    string[] members = project.Info["members"].Split(new char[] {'|'});
                    bool[] flag = new bool[members.Length];
                    bool isVisited;
                    try {
                        sr = File.OpenText("plans.dat");
                        while ((line = sr.ReadLine()) != null) {
                            content += (line + "\r\n");
                            if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(project.Name)) {
                                while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                    isVisited = false;
                                    for(int i = 0; i < members.Length; i++)
                                        if (members[i].Equals(tmp)) {
                                            content += (tmp + "\r\n"
                                                + sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n"
                                                + sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n");
                                            flag[i] = true;
                                            isVisited = true;
                                            break;
                                        }
                                    if (isVisited == false)
                                        for (int i = 0; i < 4; i++)
                                            sr.ReadLine();
                                }
                                for (int i = 0; i < members.Length; i++) {
                                    if(flag[i] == false) {
                                        content += (members[i] + "\r\n"
                                            + project.Info["beginTime"] + "\r\n"
                                            + project.Info["endTime"] + "\r\n"
                                            + "0" + "\r\n" + "-" + "\r\n");
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
                    for (int i = 0; i < flag.Length; i++)
                        flag[i] = false;
                    try {
                        sr = File.OpenText("states.dat");
                        while ((line = sr.ReadLine()) != null) {
                            content += (line + "\r\n");
                            if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(project.Name)) {
                                while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                    isVisited = false;
                                    for (int i = 0; i < members.Length; i++)
                                        if (members[i].Equals(tmp)) {
                                            content += (tmp + "\r\n"
                                                + sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n"
                                                + sr.ReadLine() + "\r\n" + sr.ReadLine() + "\r\n");
                                            flag[i] = true;
                                            isVisited = true;
                                            break;
                                        }
                                    if (isVisited == false)
                                        for (int i = 0; i < 4; i++)
                                            sr.ReadLine();
                                }
                                for (int i = 0; i < members.Length; i++) {
                                    if (flag[i] == false) {
                                        content += (members[i] + "\r\n" + "-" + "\r\n" + "0" + "\r\n"
                                            + "0" + "\r\n" + "0" + "\r\n");
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
                            if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(project.Name)) {
                                while ((tmp = sr.ReadLine()) != null && !tmp.Equals("")) {
                                    for (int i = 0; i < members.Length; i++)
                                        if (members[i].Equals(tmp)) {
                                            content += tmp;
                                            break;
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

                   // bs.ResetBindings(true);
                }
            }
        }

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            UserDialogue dialogue = new UserDialogue(1, "");
            if (dialogue.ShowDialog(this) == DialogResult.OK) {
                MessageBox.Show("修改成功！", "提示");
            }
        }

    }

    public class ProjectInfo
    {
        private Dictionary<string, string> info;
        private string name;

        public Dictionary<string, string> Info {
            set {
                info = value;
                name = value["name"];
            }
            get {
                return info;
            }
        }

        public string Name {
            get {
                return name;
            }
        }

    }
}
