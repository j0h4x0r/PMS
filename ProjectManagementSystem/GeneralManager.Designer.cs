namespace ProjectManagementSystem
{
    partial class GeneralManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.projectsListBox = new System.Windows.Forms.ListBox();
            this.membersListBox = new System.Windows.Forms.ListBox();
            this.projectFinishProgressBar = new System.Windows.Forms.ProgressBar();
            this.projectFinishPercentLabel = new System.Windows.Forms.Label();
            this.problemReportButton = new System.Windows.Forms.Button();
            this.projectRankButton = new System.Windows.Forms.Button();
            this.allRankButton = new System.Windows.Forms.Button();
            this.finishPercentLabel = new System.Windows.Forms.Label();
            this.memberScoreLabel = new System.Windows.Forms.Label();
            this.managerScoreLabel = new System.Windows.Forms.Label();
            this.finishPercentTextBox = new System.Windows.Forms.TextBox();
            this.memberScoreTextBox = new System.Windows.Forms.TextBox();
            this.managerScoreTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // projectsListBox
            // 
            this.projectsListBox.FormattingEnabled = true;
            this.projectsListBox.ItemHeight = 12;
            this.projectsListBox.Location = new System.Drawing.Point(12, 15);
            this.projectsListBox.Name = "projectsListBox";
            this.projectsListBox.Size = new System.Drawing.Size(230, 472);
            this.projectsListBox.TabIndex = 0;
            this.projectsListBox.SelectedIndexChanged += new System.EventHandler(this.projectsListBox_SelectedIndexChanged);
            // 
            // membersListBox
            // 
            this.membersListBox.FormattingEnabled = true;
            this.membersListBox.ItemHeight = 12;
            this.membersListBox.Location = new System.Drawing.Point(270, 171);
            this.membersListBox.Name = "membersListBox";
            this.membersListBox.Size = new System.Drawing.Size(180, 316);
            this.membersListBox.TabIndex = 1;
            this.membersListBox.SelectedIndexChanged += new System.EventHandler(this.membersListBox_SelectedIndexChanged);
            // 
            // projectFinishProgressBar
            // 
            this.projectFinishProgressBar.Location = new System.Drawing.Point(378, 37);
            this.projectFinishProgressBar.Name = "projectFinishProgressBar";
            this.projectFinishProgressBar.Size = new System.Drawing.Size(370, 30);
            this.projectFinishProgressBar.TabIndex = 2;
            // 
            // projectFinishPercentLabel
            // 
            this.projectFinishPercentLabel.AutoSize = true;
            this.projectFinishPercentLabel.Location = new System.Drawing.Point(285, 46);
            this.projectFinishPercentLabel.Name = "projectFinishPercentLabel";
            this.projectFinishPercentLabel.Size = new System.Drawing.Size(53, 12);
            this.projectFinishPercentLabel.TabIndex = 3;
            this.projectFinishPercentLabel.Text = "项目进度";
            // 
            // problemReportButton
            // 
            this.problemReportButton.Location = new System.Drawing.Point(310, 94);
            this.problemReportButton.Name = "problemReportButton";
            this.problemReportButton.Size = new System.Drawing.Size(90, 30);
            this.problemReportButton.TabIndex = 4;
            this.problemReportButton.Text = "项目问题报告";
            this.problemReportButton.UseVisualStyleBackColor = true;
            this.problemReportButton.Click += new System.EventHandler(this.problemReportButton_Click);
            // 
            // projectRankButton
            // 
            this.projectRankButton.Location = new System.Drawing.Point(453, 94);
            this.projectRankButton.Name = "projectRankButton";
            this.projectRankButton.Size = new System.Drawing.Size(90, 30);
            this.projectRankButton.TabIndex = 5;
            this.projectRankButton.Text = "查看项目排名";
            this.projectRankButton.UseVisualStyleBackColor = true;
            this.projectRankButton.Click += new System.EventHandler(this.projectRankButton_Click);
            // 
            // allRankButton
            // 
            this.allRankButton.Location = new System.Drawing.Point(647, 94);
            this.allRankButton.Name = "allRankButton";
            this.allRankButton.Size = new System.Drawing.Size(90, 30);
            this.allRankButton.TabIndex = 6;
            this.allRankButton.Text = "查看总体排名";
            this.allRankButton.UseVisualStyleBackColor = true;
            this.allRankButton.Click += new System.EventHandler(this.allRankButton_Click);
            // 
            // finishPercentLabel
            // 
            this.finishPercentLabel.AutoSize = true;
            this.finishPercentLabel.Location = new System.Drawing.Point(522, 224);
            this.finishPercentLabel.Name = "finishPercentLabel";
            this.finishPercentLabel.Size = new System.Drawing.Size(53, 12);
            this.finishPercentLabel.TabIndex = 7;
            this.finishPercentLabel.Text = "完成情况";
            // 
            // memberScoreLabel
            // 
            this.memberScoreLabel.AutoSize = true;
            this.memberScoreLabel.Location = new System.Drawing.Point(522, 318);
            this.memberScoreLabel.Name = "memberScoreLabel";
            this.memberScoreLabel.Size = new System.Drawing.Size(53, 12);
            this.memberScoreLabel.TabIndex = 8;
            this.memberScoreLabel.Text = "自评分数";
            // 
            // managerScoreLabel
            // 
            this.managerScoreLabel.AutoSize = true;
            this.managerScoreLabel.Location = new System.Drawing.Point(522, 412);
            this.managerScoreLabel.Name = "managerScoreLabel";
            this.managerScoreLabel.Size = new System.Drawing.Size(53, 12);
            this.managerScoreLabel.TabIndex = 9;
            this.managerScoreLabel.Text = "经理评分";
            // 
            // finishPercentTextBox
            // 
            this.finishPercentTextBox.Location = new System.Drawing.Point(614, 221);
            this.finishPercentTextBox.Name = "finishPercentTextBox";
            this.finishPercentTextBox.Size = new System.Drawing.Size(80, 21);
            this.finishPercentTextBox.TabIndex = 10;
            // 
            // memberScoreTextBox
            // 
            this.memberScoreTextBox.Location = new System.Drawing.Point(614, 315);
            this.memberScoreTextBox.Name = "memberScoreTextBox";
            this.memberScoreTextBox.Size = new System.Drawing.Size(80, 21);
            this.memberScoreTextBox.TabIndex = 11;
            // 
            // managerScoreTextBox
            // 
            this.managerScoreTextBox.Location = new System.Drawing.Point(614, 409);
            this.managerScoreTextBox.Name = "managerScoreTextBox";
            this.managerScoreTextBox.Size = new System.Drawing.Size(80, 21);
            this.managerScoreTextBox.TabIndex = 12;
            // 
            // GeneralManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.managerScoreTextBox);
            this.Controls.Add(this.memberScoreTextBox);
            this.Controls.Add(this.finishPercentTextBox);
            this.Controls.Add(this.managerScoreLabel);
            this.Controls.Add(this.memberScoreLabel);
            this.Controls.Add(this.finishPercentLabel);
            this.Controls.Add(this.allRankButton);
            this.Controls.Add(this.projectRankButton);
            this.Controls.Add(this.problemReportButton);
            this.Controls.Add(this.projectFinishPercentLabel);
            this.Controls.Add(this.projectFinishProgressBar);
            this.Controls.Add(this.membersListBox);
            this.Controls.Add(this.projectsListBox);
            this.Name = "GeneralManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理模拟系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneralManager_FormClosing);
            this.Load += new System.EventHandler(this.GeneralManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox projectsListBox;
        private System.Windows.Forms.ListBox membersListBox;
        private System.Windows.Forms.ProgressBar projectFinishProgressBar;
        private System.Windows.Forms.Label projectFinishPercentLabel;
        private System.Windows.Forms.Button problemReportButton;
        private System.Windows.Forms.Button projectRankButton;
        private System.Windows.Forms.Button allRankButton;
        private System.Windows.Forms.Label finishPercentLabel;
        private System.Windows.Forms.Label memberScoreLabel;
        private System.Windows.Forms.Label managerScoreLabel;
        private System.Windows.Forms.TextBox finishPercentTextBox;
        private System.Windows.Forms.TextBox memberScoreTextBox;
        private System.Windows.Forms.TextBox managerScoreTextBox;
    }
}