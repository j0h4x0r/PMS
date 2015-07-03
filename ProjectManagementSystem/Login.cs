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
    public partial class Login : Form
    {
        private String username;
        private String password;
        private enum Roles {
            projectMember,
            projectManager,
            generalManager,
            projectAdmin,
            systemAdmin
        };
        private Roles role;

        public String Username
        {
            get {
                return username;
            }
            set {
                username = value;
            }
        }

        public String Password
        {
            get {
                return password;
            }
            set {
                password = value;
            }
        }

        public string Role
        {
            get {
                return role.ToString();
            }
            set {
                if (value.Equals("项目组员"))
                    role = Roles.projectMember;
                else if (value.Equals("项目经理"))
                    role = Roles.projectManager;
                else if (value.Equals("总经理"))
                    role = Roles.generalManager;
                else if (value.Equals("项目管理员"))
                    role = Roles.projectAdmin;
                else if (value.Equals("系统管理员"))
                    role = Roles.systemAdmin;
/*                if (Enum.IsDefined(typeof(Roles), value))
                    role = (Roles)Enum.Parse(typeof(Roles), value);*/
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Username = usernameTextBox.Text;
            Password = passwordTextBox.Text;
            Role = roleComboBox.Text;
            int flag = CheckLogin(Username, Password, Role);
            if (flag == 1) {
                this.Visible = false;
                if (Role.Equals("projectMember")) {
                    StreamReader sr = null;
                    string line;
                    try {
                        sr = File.OpenText("users.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#") && (line.Split(new char[] { '#' })[1]).Equals(Role)) {
                                string info;
                                while ((info = sr.ReadLine()) != null && !info.Equals("")) {
                                    string[] userInfo = info.Split(new char[] { '|' });
                                    string name = userInfo[0];
                                    string passwd = userInfo[1];
                                    if (name.Equals(username)) {
                                        ProjectMember projectMemberForm = new ProjectMember(userInfo[2]);
                                        projectMemberForm.Show();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    } catch (FileNotFoundException fe) {
                        Console.WriteLine(fe.StackTrace);
                        MessageBox.Show("读取用户数据信息失败！", "提示");
                    } finally {
                        if (sr != null)
                            sr.Close();
                    }
                } else if (Role.Equals("projectManager")) {
                    StreamReader sr = null;
                    string line;
                    try {
                        sr = File.OpenText("users.dat");
                        while ((line = sr.ReadLine()) != null) {
                            if (line.StartsWith("#") && (line.Split(new char[] { '#' })[1]).Equals(Role)) {
                                string info;
                                while ((info = sr.ReadLine()) != null && !info.Equals("")) {
                                    string[] userInfo = info.Split(new char[] { '|' });
                                    string name = userInfo[0];
                                    string passwd = userInfo[1];
                                    if (name.Equals(username)) {
                                        ProjectManager projectManagerForm = new ProjectManager(userInfo[2]);
                                        projectManagerForm.Show();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    } catch (FileNotFoundException fe) {
                        Console.WriteLine(fe.StackTrace);
                        MessageBox.Show("读取用户数据信息失败！", "提示");
                    } finally {
                        if (sr != null)
                            sr.Close();
                    }
                } else if (Role.Equals("generalManager")) {
                    GeneralManager generalManagerForm = new GeneralManager();
                    generalManagerForm.Show();
                } else if (Role.Equals("projectAdmin")) {
                    ProjectAdmin projectAdminForm = new ProjectAdmin();
                    projectAdminForm.Show();
                } else if (Role.Equals("systemAdmin")) {
                    SystemAdmin systemAdminForm = new SystemAdmin();
                    systemAdminForm.Show();
                }
            } else if(flag == 0)
                MessageBox.Show("用户名或密码错误！", "提示");
        }

        private int CheckLogin(string username, string password, String role)
        {
            StreamReader sr = null;
            string line;
            int flag = 0;
            try {
                sr = File.OpenText("users.dat");
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") && (line.Split(new char[] {'#'})[1]).Equals(role)) {
                        string info;
                        while ((info = sr.ReadLine()) != null && !info.Equals("")) {
                            string[] userInfo = info.Split(new char[] { '|' });
                            string name = userInfo[0];
                            string passwd = userInfo[1];
                            if (name.Equals(username) && passwd.Equals(password)) {
                                flag = 1;
                                break;
                            }
                        }
                        break;
                    }
                }
            } catch (FileNotFoundException e) {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("读取用户数据信息失败！", "提示");
                flag = 2;
            } finally {
                if(sr != null)
                    sr.Close();
            }
            return flag;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SplashForm splashForm = new SplashForm();
            splashForm.ShowDialog(this);
        }
    }
}
