namespace ProjectManagementSystem
{
    partial class ProjectMember
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
            this.projectPlanGroupBox = new System.Windows.Forms.GroupBox();
            this.planContentTextBox = new System.Windows.Forms.TextBox();
            this.planContentLabel = new System.Windows.Forms.Label();
            this.percentTextBox = new System.Windows.Forms.TextBox();
            this.endTimeTextBox = new System.Windows.Forms.TextBox();
            this.beginTimeTextBox = new System.Windows.Forms.TextBox();
            this.percentLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.beginTimeLabel = new System.Windows.Forms.Label();
            this.finishStateGroupBox = new System.Windows.Forms.GroupBox();
            this.submitStateButton = new System.Windows.Forms.Button();
            this.projectRankButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.managerScoreNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.memberScoreNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.finishPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.reportTextBox = new System.Windows.Forms.TextBox();
            this.reportLabel = new System.Windows.Forms.Label();
            this.managerScoreLabel = new System.Windows.Forms.Label();
            this.memberScoreLabel = new System.Windows.Forms.Label();
            this.finishpercentLabel = new System.Windows.Forms.Label();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.allRankButton = new System.Windows.Forms.Button();
            this.projectPlanGroupBox.SuspendLayout();
            this.finishStateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerScoreNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberScoreNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishPercentNumericUpDown)).BeginInit();
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
            // projectPlanGroupBox
            // 
            this.projectPlanGroupBox.Controls.Add(this.planContentTextBox);
            this.projectPlanGroupBox.Controls.Add(this.planContentLabel);
            this.projectPlanGroupBox.Controls.Add(this.percentTextBox);
            this.projectPlanGroupBox.Controls.Add(this.endTimeTextBox);
            this.projectPlanGroupBox.Controls.Add(this.beginTimeTextBox);
            this.projectPlanGroupBox.Controls.Add(this.percentLabel);
            this.projectPlanGroupBox.Controls.Add(this.endTimeLabel);
            this.projectPlanGroupBox.Controls.Add(this.beginTimeLabel);
            this.projectPlanGroupBox.Location = new System.Drawing.Point(266, 27);
            this.projectPlanGroupBox.Name = "projectPlanGroupBox";
            this.projectPlanGroupBox.Size = new System.Drawing.Size(500, 175);
            this.projectPlanGroupBox.TabIndex = 1;
            this.projectPlanGroupBox.TabStop = false;
            this.projectPlanGroupBox.Text = "项目计划";
            // 
            // planContentTextBox
            // 
            this.planContentTextBox.Location = new System.Drawing.Point(255, 46);
            this.planContentTextBox.Multiline = true;
            this.planContentTextBox.Name = "planContentTextBox";
            this.planContentTextBox.ReadOnly = true;
            this.planContentTextBox.Size = new System.Drawing.Size(229, 105);
            this.planContentTextBox.TabIndex = 7;
            // 
            // planContentLabel
            // 
            this.planContentLabel.AutoSize = true;
            this.planContentLabel.Location = new System.Drawing.Point(253, 29);
            this.planContentLabel.Name = "planContentLabel";
            this.planContentLabel.Size = new System.Drawing.Size(53, 12);
            this.planContentLabel.TabIndex = 6;
            this.planContentLabel.Text = "计划内容";
            // 
            // percentTextBox
            // 
            this.percentTextBox.Location = new System.Drawing.Point(85, 130);
            this.percentTextBox.Name = "percentTextBox";
            this.percentTextBox.ReadOnly = true;
            this.percentTextBox.Size = new System.Drawing.Size(141, 21);
            this.percentTextBox.TabIndex = 5;
            // 
            // endTimeTextBox
            // 
            this.endTimeTextBox.Location = new System.Drawing.Point(85, 78);
            this.endTimeTextBox.Name = "endTimeTextBox";
            this.endTimeTextBox.ReadOnly = true;
            this.endTimeTextBox.Size = new System.Drawing.Size(141, 21);
            this.endTimeTextBox.TabIndex = 4;
            // 
            // beginTimeTextBox
            // 
            this.beginTimeTextBox.Location = new System.Drawing.Point(85, 26);
            this.beginTimeTextBox.Name = "beginTimeTextBox";
            this.beginTimeTextBox.ReadOnly = true;
            this.beginTimeTextBox.Size = new System.Drawing.Size(141, 21);
            this.beginTimeTextBox.TabIndex = 3;
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Location = new System.Drawing.Point(20, 133);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(53, 12);
            this.percentLabel.TabIndex = 2;
            this.percentLabel.Text = "所占比重";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(20, 81);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.endTimeLabel.TabIndex = 1;
            this.endTimeLabel.Text = "结束时间";
            // 
            // beginTimeLabel
            // 
            this.beginTimeLabel.AutoSize = true;
            this.beginTimeLabel.Location = new System.Drawing.Point(20, 29);
            this.beginTimeLabel.Name = "beginTimeLabel";
            this.beginTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.beginTimeLabel.TabIndex = 0;
            this.beginTimeLabel.Text = "起始时间";
            // 
            // finishStateGroupBox
            // 
            this.finishStateGroupBox.Controls.Add(this.submitStateButton);
            this.finishStateGroupBox.Controls.Add(this.projectRankButton);
            this.finishStateGroupBox.Controls.Add(this.label1);
            this.finishStateGroupBox.Controls.Add(this.managerScoreNumericUpDown);
            this.finishStateGroupBox.Controls.Add(this.memberScoreNumericUpDown);
            this.finishStateGroupBox.Controls.Add(this.finishPercentNumericUpDown);
            this.finishStateGroupBox.Controls.Add(this.reportTextBox);
            this.finishStateGroupBox.Controls.Add(this.reportLabel);
            this.finishStateGroupBox.Controls.Add(this.managerScoreLabel);
            this.finishStateGroupBox.Controls.Add(this.memberScoreLabel);
            this.finishStateGroupBox.Controls.Add(this.finishpercentLabel);
            this.finishStateGroupBox.Location = new System.Drawing.Point(268, 220);
            this.finishStateGroupBox.Name = "finishStateGroupBox";
            this.finishStateGroupBox.Size = new System.Drawing.Size(500, 218);
            this.finishStateGroupBox.TabIndex = 2;
            this.finishStateGroupBox.TabStop = false;
            this.finishStateGroupBox.Text = "完成情况";
            // 
            // submitStateButton
            // 
            this.submitStateButton.Location = new System.Drawing.Point(319, 169);
            this.submitStateButton.Name = "submitStateButton";
            this.submitStateButton.Size = new System.Drawing.Size(80, 30);
            this.submitStateButton.TabIndex = 21;
            this.submitStateButton.Text = "提交信息";
            this.submitStateButton.UseVisualStyleBackColor = true;
            this.submitStateButton.Click += new System.EventHandler(this.submitStateButton_Click);
            // 
            // projectRankButton
            // 
            this.projectRankButton.Location = new System.Drawing.Point(100, 169);
            this.projectRankButton.Name = "projectRankButton";
            this.projectRankButton.Size = new System.Drawing.Size(80, 30);
            this.projectRankButton.TabIndex = 20;
            this.projectRankButton.Text = "查看排名";
            this.projectRankButton.UseVisualStyleBackColor = true;
            this.projectRankButton.Click += new System.EventHandler(this.projectRankButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "%";
            // 
            // managerScoreNumericUpDown
            // 
            this.managerScoreNumericUpDown.Enabled = false;
            this.managerScoreNumericUpDown.Location = new System.Drawing.Point(83, 130);
            this.managerScoreNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.managerScoreNumericUpDown.Name = "managerScoreNumericUpDown";
            this.managerScoreNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.managerScoreNumericUpDown.TabIndex = 18;
            // 
            // memberScoreNumericUpDown
            // 
            this.memberScoreNumericUpDown.Location = new System.Drawing.Point(83, 78);
            this.memberScoreNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.memberScoreNumericUpDown.Name = "memberScoreNumericUpDown";
            this.memberScoreNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.memberScoreNumericUpDown.TabIndex = 17;
            // 
            // finishPercentNumericUpDown
            // 
            this.finishPercentNumericUpDown.Location = new System.Drawing.Point(83, 26);
            this.finishPercentNumericUpDown.Name = "finishPercentNumericUpDown";
            this.finishPercentNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.finishPercentNumericUpDown.TabIndex = 16;
            // 
            // reportTextBox
            // 
            this.reportTextBox.Location = new System.Drawing.Point(198, 45);
            this.reportTextBox.Multiline = true;
            this.reportTextBox.Name = "reportTextBox";
            this.reportTextBox.Size = new System.Drawing.Size(284, 105);
            this.reportTextBox.TabIndex = 15;
            // 
            // reportLabel
            // 
            this.reportLabel.AutoSize = true;
            this.reportLabel.Location = new System.Drawing.Point(196, 28);
            this.reportLabel.Name = "reportLabel";
            this.reportLabel.Size = new System.Drawing.Size(53, 12);
            this.reportLabel.TabIndex = 14;
            this.reportLabel.Text = "项目报告";
            // 
            // managerScoreLabel
            // 
            this.managerScoreLabel.AutoSize = true;
            this.managerScoreLabel.Location = new System.Drawing.Point(18, 132);
            this.managerScoreLabel.Name = "managerScoreLabel";
            this.managerScoreLabel.Size = new System.Drawing.Size(53, 12);
            this.managerScoreLabel.TabIndex = 10;
            this.managerScoreLabel.Text = "经理评分";
            // 
            // memberScoreLabel
            // 
            this.memberScoreLabel.AutoSize = true;
            this.memberScoreLabel.Location = new System.Drawing.Point(18, 80);
            this.memberScoreLabel.Name = "memberScoreLabel";
            this.memberScoreLabel.Size = new System.Drawing.Size(53, 12);
            this.memberScoreLabel.TabIndex = 9;
            this.memberScoreLabel.Text = "自评分数";
            // 
            // finishpercentLabel
            // 
            this.finishpercentLabel.AutoSize = true;
            this.finishpercentLabel.Location = new System.Drawing.Point(18, 28);
            this.finishpercentLabel.Name = "finishpercentLabel";
            this.finishpercentLabel.Size = new System.Drawing.Size(53, 12);
            this.finishpercentLabel.TabIndex = 8;
            this.finishpercentLabel.Text = "完成情况";
            // 
            // editProfileButton
            // 
            this.editProfileButton.Location = new System.Drawing.Point(604, 495);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(90, 30);
            this.editProfileButton.TabIndex = 3;
            this.editProfileButton.Text = "修改个人信息";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(266, 465);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(257, 12);
            this.warningLabel.TabIndex = 4;
            this.warningLabel.Text = "你受到了来自总经理的警告！请认真完成工作！";
            this.warningLabel.Visible = false;
            // 
            // allRankButton
            // 
            this.allRankButton.Location = new System.Drawing.Point(334, 495);
            this.allRankButton.Name = "allRankButton";
            this.allRankButton.Size = new System.Drawing.Size(90, 30);
            this.allRankButton.TabIndex = 5;
            this.allRankButton.Text = "查看总体排名";
            this.allRankButton.UseVisualStyleBackColor = true;
            this.allRankButton.Click += new System.EventHandler(this.allRankButton_Click);
            // 
            // ProjectMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.allRankButton);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.editProfileButton);
            this.Controls.Add(this.finishStateGroupBox);
            this.Controls.Add(this.projectPlanGroupBox);
            this.Controls.Add(this.projectsListBox);
            this.Name = "ProjectMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理模拟系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectMember_FormClosing);
            this.Load += new System.EventHandler(this.ProjectMember_Load);
            this.projectPlanGroupBox.ResumeLayout(false);
            this.projectPlanGroupBox.PerformLayout();
            this.finishStateGroupBox.ResumeLayout(false);
            this.finishStateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerScoreNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberScoreNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishPercentNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox projectsListBox;
        private System.Windows.Forms.GroupBox projectPlanGroupBox;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label beginTimeLabel;
        private System.Windows.Forms.TextBox percentTextBox;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.TextBox beginTimeTextBox;
        private System.Windows.Forms.TextBox planContentTextBox;
        private System.Windows.Forms.Label planContentLabel;
        private System.Windows.Forms.GroupBox finishStateGroupBox;
        private System.Windows.Forms.TextBox reportTextBox;
        private System.Windows.Forms.Label reportLabel;
        private System.Windows.Forms.Label managerScoreLabel;
        private System.Windows.Forms.Label memberScoreLabel;
        private System.Windows.Forms.Label finishpercentLabel;
        private System.Windows.Forms.NumericUpDown finishPercentNumericUpDown;
        private System.Windows.Forms.NumericUpDown managerScoreNumericUpDown;
        private System.Windows.Forms.NumericUpDown memberScoreNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitStateButton;
        private System.Windows.Forms.Button projectRankButton;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button allRankButton;

    }
}