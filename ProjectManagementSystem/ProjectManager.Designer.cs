namespace ProjectManagementSystem
{
    partial class ProjectManager
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.projectInfoTab = new System.Windows.Forms.TabPage();
            this.projectFinishProgressLabel = new System.Windows.Forms.Label();
            this.projectFinishProgressBar = new System.Windows.Forms.ProgressBar();
            this.membersTextBox = new System.Windows.Forms.TextBox();
            this.endTimeTextBox = new System.Windows.Forms.TextBox();
            this.beginTimeTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.membersLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.beginTimeLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.developPlanTab = new System.Windows.Forms.TabPage();
            this.planEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.planBeginTimePicker = new System.Windows.Forms.DateTimePicker();
            this.abortEditButton = new System.Windows.Forms.Button();
            this.editPlanButton = new System.Windows.Forms.Button();
            this.saveEditButton = new System.Windows.Forms.Button();
            this.planContentTextBox = new System.Windows.Forms.TextBox();
            this.planPercentTextBox = new System.Windows.Forms.TextBox();
            this.planEndTimeTextBox = new System.Windows.Forms.TextBox();
            this.planBeginTimeTextBox = new System.Windows.Forms.TextBox();
            this.planContentLabel = new System.Windows.Forms.Label();
            this.planPercentLabel = new System.Windows.Forms.Label();
            this.planEndTimeLabel = new System.Windows.Forms.Label();
            this.planBeginTimeLabel = new System.Windows.Forms.Label();
            this.membersListBox1 = new System.Windows.Forms.ListBox();
            this.memberStateTab = new System.Windows.Forms.TabPage();
            this.projectRankButton = new System.Windows.Forms.Button();
            this.sortByManagerScoreRadioButton = new System.Windows.Forms.RadioButton();
            this.sortByMemberScoreRadioButton = new System.Windows.Forms.RadioButton();
            this.sortByFinishPercentRadioButton = new System.Windows.Forms.RadioButton();
            this.managerScoreConfirmButton = new System.Windows.Forms.Button();
            this.finishPercentCancelButton = new System.Windows.Forms.Button();
            this.finishPercentConfirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.managerScoreNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.memberScoreNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.memberFinishPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.memberReportTextBox = new System.Windows.Forms.TextBox();
            this.managerScoreLabel = new System.Windows.Forms.Label();
            this.memberScoreLabel = new System.Windows.Forms.Label();
            this.memberFinishPercentLabel = new System.Windows.Forms.Label();
            this.memberReportLabel = new System.Windows.Forms.Label();
            this.membersListBox2 = new System.Windows.Forms.ListBox();
            this.projectsListBox = new System.Windows.Forms.ListBox();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.editProblemReportButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.projectInfoTab.SuspendLayout();
            this.developPlanTab.SuspendLayout();
            this.memberStateTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerScoreNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberScoreNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberFinishPercentNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.projectInfoTab);
            this.tabControl.Controls.Add(this.developPlanTab);
            this.tabControl.Controls.Add(this.memberStateTab);
            this.tabControl.Location = new System.Drawing.Point(248, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(539, 480);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // projectInfoTab
            // 
            this.projectInfoTab.Controls.Add(this.projectFinishProgressLabel);
            this.projectInfoTab.Controls.Add(this.projectFinishProgressBar);
            this.projectInfoTab.Controls.Add(this.membersTextBox);
            this.projectInfoTab.Controls.Add(this.endTimeTextBox);
            this.projectInfoTab.Controls.Add(this.beginTimeTextBox);
            this.projectInfoTab.Controls.Add(this.nameTextBox);
            this.projectInfoTab.Controls.Add(this.numberTextBox);
            this.projectInfoTab.Controls.Add(this.membersLabel);
            this.projectInfoTab.Controls.Add(this.endTimeLabel);
            this.projectInfoTab.Controls.Add(this.beginTimeLabel);
            this.projectInfoTab.Controls.Add(this.nameLabel);
            this.projectInfoTab.Controls.Add(this.numberLabel);
            this.projectInfoTab.Location = new System.Drawing.Point(4, 21);
            this.projectInfoTab.Name = "projectInfoTab";
            this.projectInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.projectInfoTab.Size = new System.Drawing.Size(531, 455);
            this.projectInfoTab.TabIndex = 0;
            this.projectInfoTab.Text = "项目信息";
            this.projectInfoTab.UseVisualStyleBackColor = true;
            // 
            // projectFinishProgressLabel
            // 
            this.projectFinishProgressLabel.AutoSize = true;
            this.projectFinishProgressLabel.Location = new System.Drawing.Point(35, 412);
            this.projectFinishProgressLabel.Name = "projectFinishProgressLabel";
            this.projectFinishProgressLabel.Size = new System.Drawing.Size(53, 12);
            this.projectFinishProgressLabel.TabIndex = 12;
            this.projectFinishProgressLabel.Text = "项目进度";
            // 
            // projectFinishProgressBar
            // 
            this.projectFinishProgressBar.Location = new System.Drawing.Point(125, 403);
            this.projectFinishProgressBar.Name = "projectFinishProgressBar";
            this.projectFinishProgressBar.Size = new System.Drawing.Size(370, 30);
            this.projectFinishProgressBar.TabIndex = 11;
            // 
            // membersTextBox
            // 
            this.membersTextBox.Location = new System.Drawing.Point(219, 317);
            this.membersTextBox.Multiline = true;
            this.membersTextBox.Name = "membersTextBox";
            this.membersTextBox.ReadOnly = true;
            this.membersTextBox.Size = new System.Drawing.Size(218, 63);
            this.membersTextBox.TabIndex = 10;
            // 
            // endTimeTextBox
            // 
            this.endTimeTextBox.Location = new System.Drawing.Point(219, 252);
            this.endTimeTextBox.Name = "endTimeTextBox";
            this.endTimeTextBox.ReadOnly = true;
            this.endTimeTextBox.Size = new System.Drawing.Size(218, 21);
            this.endTimeTextBox.TabIndex = 9;
            // 
            // beginTimeTextBox
            // 
            this.beginTimeTextBox.Location = new System.Drawing.Point(219, 187);
            this.beginTimeTextBox.Name = "beginTimeTextBox";
            this.beginTimeTextBox.ReadOnly = true;
            this.beginTimeTextBox.Size = new System.Drawing.Size(218, 21);
            this.beginTimeTextBox.TabIndex = 8;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(219, 122);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(218, 21);
            this.nameTextBox.TabIndex = 7;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(219, 57);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.ReadOnly = true;
            this.numberTextBox.Size = new System.Drawing.Size(218, 21);
            this.numberTextBox.TabIndex = 6;
            // 
            // membersLabel
            // 
            this.membersLabel.AutoSize = true;
            this.membersLabel.Location = new System.Drawing.Point(93, 320);
            this.membersLabel.Name = "membersLabel";
            this.membersLabel.Size = new System.Drawing.Size(53, 12);
            this.membersLabel.TabIndex = 5;
            this.membersLabel.Text = "项目成员";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(93, 255);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.endTimeLabel.TabIndex = 4;
            this.endTimeLabel.Text = "结束时间";
            // 
            // beginTimeLabel
            // 
            this.beginTimeLabel.AutoSize = true;
            this.beginTimeLabel.Location = new System.Drawing.Point(93, 190);
            this.beginTimeLabel.Name = "beginTimeLabel";
            this.beginTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.beginTimeLabel.TabIndex = 3;
            this.beginTimeLabel.Text = "起始时间";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(93, 125);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 12);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "项目名称";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(93, 60);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(53, 12);
            this.numberLabel.TabIndex = 1;
            this.numberLabel.Text = "项目编号";
            // 
            // developPlanTab
            // 
            this.developPlanTab.Controls.Add(this.planEndTimePicker);
            this.developPlanTab.Controls.Add(this.planBeginTimePicker);
            this.developPlanTab.Controls.Add(this.abortEditButton);
            this.developPlanTab.Controls.Add(this.editPlanButton);
            this.developPlanTab.Controls.Add(this.saveEditButton);
            this.developPlanTab.Controls.Add(this.planContentTextBox);
            this.developPlanTab.Controls.Add(this.planPercentTextBox);
            this.developPlanTab.Controls.Add(this.planEndTimeTextBox);
            this.developPlanTab.Controls.Add(this.planBeginTimeTextBox);
            this.developPlanTab.Controls.Add(this.planContentLabel);
            this.developPlanTab.Controls.Add(this.planPercentLabel);
            this.developPlanTab.Controls.Add(this.planEndTimeLabel);
            this.developPlanTab.Controls.Add(this.planBeginTimeLabel);
            this.developPlanTab.Controls.Add(this.membersListBox1);
            this.developPlanTab.Location = new System.Drawing.Point(4, 21);
            this.developPlanTab.Name = "developPlanTab";
            this.developPlanTab.Padding = new System.Windows.Forms.Padding(3);
            this.developPlanTab.Size = new System.Drawing.Size(531, 455);
            this.developPlanTab.TabIndex = 1;
            this.developPlanTab.Text = "开发计划";
            this.developPlanTab.UseVisualStyleBackColor = true;
            // 
            // planEndTimePicker
            // 
            this.planEndTimePicker.Location = new System.Drawing.Point(288, 106);
            this.planEndTimePicker.Name = "planEndTimePicker";
            this.planEndTimePicker.Size = new System.Drawing.Size(218, 21);
            this.planEndTimePicker.TabIndex = 13;
            this.planEndTimePicker.Visible = false;
            // 
            // planBeginTimePicker
            // 
            this.planBeginTimePicker.Location = new System.Drawing.Point(288, 42);
            this.planBeginTimePicker.Name = "planBeginTimePicker";
            this.planBeginTimePicker.Size = new System.Drawing.Size(218, 21);
            this.planBeginTimePicker.TabIndex = 12;
            this.planBeginTimePicker.Visible = false;
            // 
            // abortEditButton
            // 
            this.abortEditButton.Location = new System.Drawing.Point(406, 405);
            this.abortEditButton.Name = "abortEditButton";
            this.abortEditButton.Size = new System.Drawing.Size(80, 30);
            this.abortEditButton.TabIndex = 11;
            this.abortEditButton.Text = "放弃修改";
            this.abortEditButton.UseVisualStyleBackColor = true;
            this.abortEditButton.Visible = false;
            this.abortEditButton.Click += new System.EventHandler(this.abortEditButton_Click);
            // 
            // editPlanButton
            // 
            this.editPlanButton.Location = new System.Drawing.Point(406, 405);
            this.editPlanButton.Name = "editPlanButton";
            this.editPlanButton.Size = new System.Drawing.Size(80, 30);
            this.editPlanButton.TabIndex = 9;
            this.editPlanButton.Text = "编辑计划";
            this.editPlanButton.UseVisualStyleBackColor = true;
            this.editPlanButton.Click += new System.EventHandler(this.editPlanButton_Click);
            // 
            // saveEditButton
            // 
            this.saveEditButton.Location = new System.Drawing.Point(255, 405);
            this.saveEditButton.Name = "saveEditButton";
            this.saveEditButton.Size = new System.Drawing.Size(80, 30);
            this.saveEditButton.TabIndex = 10;
            this.saveEditButton.Text = "保存修改";
            this.saveEditButton.UseVisualStyleBackColor = true;
            this.saveEditButton.Visible = false;
            this.saveEditButton.Click += new System.EventHandler(this.saveEditButton_Click);
            // 
            // planContentTextBox
            // 
            this.planContentTextBox.Location = new System.Drawing.Point(288, 234);
            this.planContentTextBox.Multiline = true;
            this.planContentTextBox.Name = "planContentTextBox";
            this.planContentTextBox.ReadOnly = true;
            this.planContentTextBox.Size = new System.Drawing.Size(218, 147);
            this.planContentTextBox.TabIndex = 8;
            // 
            // planPercentTextBox
            // 
            this.planPercentTextBox.Location = new System.Drawing.Point(288, 170);
            this.planPercentTextBox.Name = "planPercentTextBox";
            this.planPercentTextBox.ReadOnly = true;
            this.planPercentTextBox.Size = new System.Drawing.Size(218, 21);
            this.planPercentTextBox.TabIndex = 7;
            // 
            // planEndTimeTextBox
            // 
            this.planEndTimeTextBox.Location = new System.Drawing.Point(288, 106);
            this.planEndTimeTextBox.Name = "planEndTimeTextBox";
            this.planEndTimeTextBox.ReadOnly = true;
            this.planEndTimeTextBox.Size = new System.Drawing.Size(218, 21);
            this.planEndTimeTextBox.TabIndex = 6;
            // 
            // planBeginTimeTextBox
            // 
            this.planBeginTimeTextBox.Location = new System.Drawing.Point(288, 42);
            this.planBeginTimeTextBox.Name = "planBeginTimeTextBox";
            this.planBeginTimeTextBox.ReadOnly = true;
            this.planBeginTimeTextBox.Size = new System.Drawing.Size(218, 21);
            this.planBeginTimeTextBox.TabIndex = 5;
            // 
            // planContentLabel
            // 
            this.planContentLabel.AutoSize = true;
            this.planContentLabel.Location = new System.Drawing.Point(214, 237);
            this.planContentLabel.Name = "planContentLabel";
            this.planContentLabel.Size = new System.Drawing.Size(53, 12);
            this.planContentLabel.TabIndex = 4;
            this.planContentLabel.Text = "计划内容";
            // 
            // planPercentLabel
            // 
            this.planPercentLabel.AutoSize = true;
            this.planPercentLabel.Location = new System.Drawing.Point(214, 173);
            this.planPercentLabel.Name = "planPercentLabel";
            this.planPercentLabel.Size = new System.Drawing.Size(53, 12);
            this.planPercentLabel.TabIndex = 3;
            this.planPercentLabel.Text = "所占比重";
            // 
            // planEndTimeLabel
            // 
            this.planEndTimeLabel.AutoSize = true;
            this.planEndTimeLabel.Location = new System.Drawing.Point(214, 109);
            this.planEndTimeLabel.Name = "planEndTimeLabel";
            this.planEndTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.planEndTimeLabel.TabIndex = 2;
            this.planEndTimeLabel.Text = "结束时间";
            // 
            // planBeginTimeLabel
            // 
            this.planBeginTimeLabel.AutoSize = true;
            this.planBeginTimeLabel.Location = new System.Drawing.Point(214, 45);
            this.planBeginTimeLabel.Name = "planBeginTimeLabel";
            this.planBeginTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.planBeginTimeLabel.TabIndex = 1;
            this.planBeginTimeLabel.Text = "起始时间";
            // 
            // membersListBox1
            // 
            this.membersListBox1.FormattingEnabled = true;
            this.membersListBox1.ItemHeight = 12;
            this.membersListBox1.Location = new System.Drawing.Point(25, 31);
            this.membersListBox1.Name = "membersListBox1";
            this.membersListBox1.Size = new System.Drawing.Size(165, 352);
            this.membersListBox1.TabIndex = 0;
            this.membersListBox1.SelectedIndexChanged += new System.EventHandler(this.membersListBox1_SelectedIndexChanged);
            // 
            // memberStateTab
            // 
            this.memberStateTab.Controls.Add(this.projectRankButton);
            this.memberStateTab.Controls.Add(this.sortByManagerScoreRadioButton);
            this.memberStateTab.Controls.Add(this.sortByMemberScoreRadioButton);
            this.memberStateTab.Controls.Add(this.sortByFinishPercentRadioButton);
            this.memberStateTab.Controls.Add(this.managerScoreConfirmButton);
            this.memberStateTab.Controls.Add(this.finishPercentCancelButton);
            this.memberStateTab.Controls.Add(this.finishPercentConfirmButton);
            this.memberStateTab.Controls.Add(this.label1);
            this.memberStateTab.Controls.Add(this.managerScoreNumericUpDown);
            this.memberStateTab.Controls.Add(this.memberScoreNumericUpDown);
            this.memberStateTab.Controls.Add(this.memberFinishPercentNumericUpDown);
            this.memberStateTab.Controls.Add(this.memberReportTextBox);
            this.memberStateTab.Controls.Add(this.managerScoreLabel);
            this.memberStateTab.Controls.Add(this.memberScoreLabel);
            this.memberStateTab.Controls.Add(this.memberFinishPercentLabel);
            this.memberStateTab.Controls.Add(this.memberReportLabel);
            this.memberStateTab.Controls.Add(this.membersListBox2);
            this.memberStateTab.Location = new System.Drawing.Point(4, 21);
            this.memberStateTab.Name = "memberStateTab";
            this.memberStateTab.Size = new System.Drawing.Size(531, 455);
            this.memberStateTab.TabIndex = 2;
            this.memberStateTab.Text = "组员情况";
            this.memberStateTab.UseVisualStyleBackColor = true;
            // 
            // projectRankButton
            // 
            this.projectRankButton.Location = new System.Drawing.Point(426, 393);
            this.projectRankButton.Name = "projectRankButton";
            this.projectRankButton.Size = new System.Drawing.Size(80, 30);
            this.projectRankButton.TabIndex = 16;
            this.projectRankButton.Text = "查看排名";
            this.projectRankButton.UseVisualStyleBackColor = true;
            this.projectRankButton.Click += new System.EventHandler(this.projectRankButton_Click);
            // 
            // sortByManagerScoreRadioButton
            // 
            this.sortByManagerScoreRadioButton.AutoSize = true;
            this.sortByManagerScoreRadioButton.Location = new System.Drawing.Point(304, 400);
            this.sortByManagerScoreRadioButton.Name = "sortByManagerScoreRadioButton";
            this.sortByManagerScoreRadioButton.Size = new System.Drawing.Size(107, 16);
            this.sortByManagerScoreRadioButton.TabIndex = 15;
            this.sortByManagerScoreRadioButton.TabStop = true;
            this.sortByManagerScoreRadioButton.Text = "按经理评分排序";
            this.sortByManagerScoreRadioButton.UseVisualStyleBackColor = true;
            this.sortByManagerScoreRadioButton.CheckedChanged += new System.EventHandler(this.sortByManagerScoreRadioButton_CheckedChanged);
            // 
            // sortByMemberScoreRadioButton
            // 
            this.sortByMemberScoreRadioButton.AutoSize = true;
            this.sortByMemberScoreRadioButton.Location = new System.Drawing.Point(163, 400);
            this.sortByMemberScoreRadioButton.Name = "sortByMemberScoreRadioButton";
            this.sortByMemberScoreRadioButton.Size = new System.Drawing.Size(107, 16);
            this.sortByMemberScoreRadioButton.TabIndex = 14;
            this.sortByMemberScoreRadioButton.TabStop = true;
            this.sortByMemberScoreRadioButton.Text = "按自评分数排序";
            this.sortByMemberScoreRadioButton.UseVisualStyleBackColor = true;
            this.sortByMemberScoreRadioButton.CheckedChanged += new System.EventHandler(this.sortByMemberScoreRadioButton_CheckedChanged);
            // 
            // sortByFinishPercentRadioButton
            // 
            this.sortByFinishPercentRadioButton.AutoSize = true;
            this.sortByFinishPercentRadioButton.Location = new System.Drawing.Point(22, 400);
            this.sortByFinishPercentRadioButton.Name = "sortByFinishPercentRadioButton";
            this.sortByFinishPercentRadioButton.Size = new System.Drawing.Size(107, 16);
            this.sortByFinishPercentRadioButton.TabIndex = 13;
            this.sortByFinishPercentRadioButton.TabStop = true;
            this.sortByFinishPercentRadioButton.Text = "按完成情况排序";
            this.sortByFinishPercentRadioButton.UseVisualStyleBackColor = true;
            this.sortByFinishPercentRadioButton.CheckedChanged += new System.EventHandler(this.sortByFinishPercentRadioButton_CheckedChanged);
            // 
            // managerScoreConfirmButton
            // 
            this.managerScoreConfirmButton.Location = new System.Drawing.Point(395, 339);
            this.managerScoreConfirmButton.Name = "managerScoreConfirmButton";
            this.managerScoreConfirmButton.Size = new System.Drawing.Size(53, 21);
            this.managerScoreConfirmButton.TabIndex = 12;
            this.managerScoreConfirmButton.Text = "评价";
            this.managerScoreConfirmButton.UseVisualStyleBackColor = true;
            this.managerScoreConfirmButton.Click += new System.EventHandler(this.managerScoreConfirmButton_Click);
            // 
            // finishPercentCancelButton
            // 
            this.finishPercentCancelButton.Enabled = false;
            this.finishPercentCancelButton.Location = new System.Drawing.Point(463, 207);
            this.finishPercentCancelButton.Name = "finishPercentCancelButton";
            this.finishPercentCancelButton.Size = new System.Drawing.Size(53, 21);
            this.finishPercentCancelButton.TabIndex = 11;
            this.finishPercentCancelButton.Text = "取消";
            this.finishPercentCancelButton.UseVisualStyleBackColor = true;
            this.finishPercentCancelButton.Click += new System.EventHandler(this.finishPercentCancelButton_Click);
            // 
            // finishPercentConfirmButton
            // 
            this.finishPercentConfirmButton.Enabled = false;
            this.finishPercentConfirmButton.Location = new System.Drawing.Point(395, 207);
            this.finishPercentConfirmButton.Name = "finishPercentConfirmButton";
            this.finishPercentConfirmButton.Size = new System.Drawing.Size(53, 21);
            this.finishPercentConfirmButton.TabIndex = 10;
            this.finishPercentConfirmButton.Text = "修改";
            this.finishPercentConfirmButton.UseVisualStyleBackColor = true;
            this.finishPercentConfirmButton.Click += new System.EventHandler(this.finishPercentConfirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "%";
            // 
            // managerScoreNumericUpDown
            // 
            this.managerScoreNumericUpDown.Location = new System.Drawing.Point(288, 341);
            this.managerScoreNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.managerScoreNumericUpDown.Name = "managerScoreNumericUpDown";
            this.managerScoreNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.managerScoreNumericUpDown.TabIndex = 8;
            // 
            // memberScoreNumericUpDown
            // 
            this.memberScoreNumericUpDown.Enabled = false;
            this.memberScoreNumericUpDown.Location = new System.Drawing.Point(288, 275);
            this.memberScoreNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.memberScoreNumericUpDown.Name = "memberScoreNumericUpDown";
            this.memberScoreNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.memberScoreNumericUpDown.TabIndex = 7;
            // 
            // memberFinishPercentNumericUpDown
            // 
            this.memberFinishPercentNumericUpDown.Location = new System.Drawing.Point(288, 209);
            this.memberFinishPercentNumericUpDown.Name = "memberFinishPercentNumericUpDown";
            this.memberFinishPercentNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.memberFinishPercentNumericUpDown.TabIndex = 6;
            this.memberFinishPercentNumericUpDown.ValueChanged += new System.EventHandler(this.memberFinishPercentNumericUpDown_ValueChanged);
            // 
            // memberReportTextBox
            // 
            this.memberReportTextBox.Location = new System.Drawing.Point(288, 42);
            this.memberReportTextBox.Multiline = true;
            this.memberReportTextBox.Name = "memberReportTextBox";
            this.memberReportTextBox.Size = new System.Drawing.Size(218, 126);
            this.memberReportTextBox.TabIndex = 5;
            // 
            // managerScoreLabel
            // 
            this.managerScoreLabel.AutoSize = true;
            this.managerScoreLabel.Location = new System.Drawing.Point(214, 343);
            this.managerScoreLabel.Name = "managerScoreLabel";
            this.managerScoreLabel.Size = new System.Drawing.Size(53, 12);
            this.managerScoreLabel.TabIndex = 4;
            this.managerScoreLabel.Text = "经理评分";
            // 
            // memberScoreLabel
            // 
            this.memberScoreLabel.AutoSize = true;
            this.memberScoreLabel.Location = new System.Drawing.Point(214, 277);
            this.memberScoreLabel.Name = "memberScoreLabel";
            this.memberScoreLabel.Size = new System.Drawing.Size(53, 12);
            this.memberScoreLabel.TabIndex = 3;
            this.memberScoreLabel.Text = "自评分数";
            // 
            // memberFinishPercentLabel
            // 
            this.memberFinishPercentLabel.AutoSize = true;
            this.memberFinishPercentLabel.Location = new System.Drawing.Point(214, 211);
            this.memberFinishPercentLabel.Name = "memberFinishPercentLabel";
            this.memberFinishPercentLabel.Size = new System.Drawing.Size(53, 12);
            this.memberFinishPercentLabel.TabIndex = 2;
            this.memberFinishPercentLabel.Text = "完成情况";
            // 
            // memberReportLabel
            // 
            this.memberReportLabel.AutoSize = true;
            this.memberReportLabel.Location = new System.Drawing.Point(214, 45);
            this.memberReportLabel.Name = "memberReportLabel";
            this.memberReportLabel.Size = new System.Drawing.Size(53, 12);
            this.memberReportLabel.TabIndex = 1;
            this.memberReportLabel.Text = "项目报告";
            // 
            // membersListBox2
            // 
            this.membersListBox2.FormattingEnabled = true;
            this.membersListBox2.ItemHeight = 12;
            this.membersListBox2.Location = new System.Drawing.Point(25, 31);
            this.membersListBox2.Name = "membersListBox2";
            this.membersListBox2.Size = new System.Drawing.Size(165, 352);
            this.membersListBox2.TabIndex = 0;
            this.membersListBox2.SelectedIndexChanged += new System.EventHandler(this.membersListBox2_SelectedIndexChanged);
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
            // editProfileButton
            // 
            this.editProfileButton.Location = new System.Drawing.Point(610, 512);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(90, 30);
            this.editProfileButton.TabIndex = 1;
            this.editProfileButton.Text = "修改个人信息";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // editProblemReportButton
            // 
            this.editProblemReportButton.Location = new System.Drawing.Point(432, 512);
            this.editProblemReportButton.Name = "editProblemReportButton";
            this.editProblemReportButton.Size = new System.Drawing.Size(90, 30);
            this.editProblemReportButton.TabIndex = 2;
            this.editProblemReportButton.Text = "项目问题报告";
            this.editProblemReportButton.UseVisualStyleBackColor = true;
            this.editProblemReportButton.Click += new System.EventHandler(this.editProblemReportButton_Click);
            // 
            // ProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.editProblemReportButton);
            this.Controls.Add(this.editProfileButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.projectsListBox);
            this.Name = "ProjectManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理模拟系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectManager_FormClosing);
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            this.tabControl.ResumeLayout(false);
            this.projectInfoTab.ResumeLayout(false);
            this.projectInfoTab.PerformLayout();
            this.developPlanTab.ResumeLayout(false);
            this.developPlanTab.PerformLayout();
            this.memberStateTab.ResumeLayout(false);
            this.memberStateTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerScoreNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberScoreNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberFinishPercentNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage projectInfoTab;
        private System.Windows.Forms.TabPage developPlanTab;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.TabPage memberStateTab;
        private System.Windows.Forms.ListBox projectsListBox;
        private System.Windows.Forms.Label membersLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label beginTimeLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.TextBox beginTimeTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox membersTextBox;
        private System.Windows.Forms.ListBox membersListBox1;
        private System.Windows.Forms.TextBox planContentTextBox;
        private System.Windows.Forms.TextBox planPercentTextBox;
        private System.Windows.Forms.TextBox planEndTimeTextBox;
        private System.Windows.Forms.TextBox planBeginTimeTextBox;
        private System.Windows.Forms.Label planContentLabel;
        private System.Windows.Forms.Label planPercentLabel;
        private System.Windows.Forms.Label planEndTimeLabel;
        private System.Windows.Forms.Label planBeginTimeLabel;
        private System.Windows.Forms.Button editPlanButton;
        private System.Windows.Forms.Button saveEditButton;
        private System.Windows.Forms.Button abortEditButton;
        private System.Windows.Forms.DateTimePicker planEndTimePicker;
        private System.Windows.Forms.DateTimePicker planBeginTimePicker;
        private System.Windows.Forms.ListBox membersListBox2;
        private System.Windows.Forms.Label managerScoreLabel;
        private System.Windows.Forms.Label memberScoreLabel;
        private System.Windows.Forms.Label memberFinishPercentLabel;
        private System.Windows.Forms.Label memberReportLabel;
        private System.Windows.Forms.TextBox memberReportTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown managerScoreNumericUpDown;
        private System.Windows.Forms.NumericUpDown memberScoreNumericUpDown;
        private System.Windows.Forms.NumericUpDown memberFinishPercentNumericUpDown;
        private System.Windows.Forms.Button managerScoreConfirmButton;
        private System.Windows.Forms.Button finishPercentCancelButton;
        private System.Windows.Forms.Button finishPercentConfirmButton;
        private System.Windows.Forms.RadioButton sortByManagerScoreRadioButton;
        private System.Windows.Forms.RadioButton sortByMemberScoreRadioButton;
        private System.Windows.Forms.RadioButton sortByFinishPercentRadioButton;
        private System.Windows.Forms.ProgressBar projectFinishProgressBar;
        private System.Windows.Forms.Label projectFinishProgressLabel;
        private System.Windows.Forms.Button editProblemReportButton;
        private System.Windows.Forms.Button projectRankButton;
    }
}