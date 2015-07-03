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
    public partial class ProblemReport : Form
    {
        private bool readOnly;
        private string projectName;

        public ProblemReport(bool flag, string projectName)
        {
            InitializeComponent();
            this.readOnly = flag;
            this.projectName = projectName;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            string content = null;
            string line;
            try {
                sr = File.OpenText("reports.dat");
                while ((line = sr.ReadLine()) != null) {
                    content += (line + "\r\n");
                    if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(projectName)) {
                        while ((line = sr.ReadLine()) != null && !line.Equals(""))
                            continue;
                        foreach (string singleLine in reportRichTextBox.Lines)
                            content += (singleLine + "\r\n");
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ProblemReport_Load(object sender, EventArgs e)
        {
            StreamReader sr = null;
            string content = "";
            string line;
            try {
                sr = File.OpenText("reports.dat");
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith("#") && line.Split(new char[] { '#' })[1].Equals(projectName)) {
                        while ((line = sr.ReadLine()) != null && !line.Equals(""))
                            content += (line + "\n");
                        if(!line.Equals(""))
                            content.TrimEnd('\n');
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
            reportRichTextBox.Lines = content.Split(new char[] { '\n' });
            if (readOnly == true) {
                submitButton.Visible = false;
                cancelButton.Visible = false;
                reportRichTextBox.ReadOnly = true;
            }
        }

        private void ProblemReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
