namespace ProjectManagementSystem
{
    partial class ProjectAdmin
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
            this.numberLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.beginTimeLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.managerLabel = new System.Windows.Forms.Label();
            this.membersLabel = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.beginTimeTextBox = new System.Windows.Forms.TextBox();
            this.endTimeTextBox = new System.Windows.Forms.TextBox();
            this.managerTextBox = new System.Windows.Forms.TextBox();
            this.membersTextBox = new System.Windows.Forms.TextBox();
            this.sortByNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.addProjectButton = new System.Windows.Forms.Button();
            this.sortByBeginTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.removeProjectButton = new System.Windows.Forms.Button();
            this.sortByEndTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.sortByManagerRadioButton = new System.Windows.Forms.RadioButton();
            this.editInfoButton = new System.Windows.Forms.Button();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectsListBox
            // 
            this.projectsListBox.FormattingEnabled = true;
            this.projectsListBox.ItemHeight = 12;
            this.projectsListBox.Location = new System.Drawing.Point(53, 38);
            this.projectsListBox.Name = "projectsListBox";
            this.projectsListBox.Size = new System.Drawing.Size(230, 400);
            this.projectsListBox.TabIndex = 0;
            this.projectsListBox.SelectedIndexChanged += new System.EventHandler(this.ProjectsListBox_SelectedIndexChanged);
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(329, 53);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(53, 12);
            this.numberLabel.TabIndex = 1;
            this.numberLabel.Text = "项目编号";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(329, 116);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 12);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "项目名称";
            // 
            // beginTimeLabel
            // 
            this.beginTimeLabel.AutoSize = true;
            this.beginTimeLabel.Location = new System.Drawing.Point(329, 179);
            this.beginTimeLabel.Name = "beginTimeLabel";
            this.beginTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.beginTimeLabel.TabIndex = 3;
            this.beginTimeLabel.Text = "起始时间";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(329, 242);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.endTimeLabel.TabIndex = 4;
            this.endTimeLabel.Text = "结束时间";
            // 
            // managerLabel
            // 
            this.managerLabel.AutoSize = true;
            this.managerLabel.Location = new System.Drawing.Point(329, 305);
            this.managerLabel.Name = "managerLabel";
            this.managerLabel.Size = new System.Drawing.Size(53, 12);
            this.managerLabel.TabIndex = 5;
            this.managerLabel.Text = "项目经理";
            // 
            // membersLabel
            // 
            this.membersLabel.AutoSize = true;
            this.membersLabel.Location = new System.Drawing.Point(329, 368);
            this.membersLabel.Name = "membersLabel";
            this.membersLabel.Size = new System.Drawing.Size(53, 12);
            this.membersLabel.TabIndex = 6;
            this.membersLabel.Text = "项目成员";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(452, 50);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.ReadOnly = true;
            this.numberTextBox.Size = new System.Drawing.Size(218, 21);
            this.numberTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(452, 113);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(218, 21);
            this.nameTextBox.TabIndex = 8;
            // 
            // beginTimeTextBox
            // 
            this.beginTimeTextBox.Location = new System.Drawing.Point(452, 176);
            this.beginTimeTextBox.Name = "beginTimeTextBox";
            this.beginTimeTextBox.ReadOnly = true;
            this.beginTimeTextBox.Size = new System.Drawing.Size(218, 21);
            this.beginTimeTextBox.TabIndex = 9;
            // 
            // endTimeTextBox
            // 
            this.endTimeTextBox.Location = new System.Drawing.Point(452, 239);
            this.endTimeTextBox.Name = "endTimeTextBox";
            this.endTimeTextBox.ReadOnly = true;
            this.endTimeTextBox.Size = new System.Drawing.Size(218, 21);
            this.endTimeTextBox.TabIndex = 10;
            // 
            // managerTextBox
            // 
            this.managerTextBox.Location = new System.Drawing.Point(452, 302);
            this.managerTextBox.Name = "managerTextBox";
            this.managerTextBox.ReadOnly = true;
            this.managerTextBox.Size = new System.Drawing.Size(218, 21);
            this.managerTextBox.TabIndex = 11;
            // 
            // membersTextBox
            // 
            this.membersTextBox.Location = new System.Drawing.Point(452, 365);
            this.membersTextBox.Multiline = true;
            this.membersTextBox.Name = "membersTextBox";
            this.membersTextBox.ReadOnly = true;
            this.membersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.membersTextBox.Size = new System.Drawing.Size(218, 63);
            this.membersTextBox.TabIndex = 12;
            // 
            // sortByNumberRadioButton
            // 
            this.sortByNumberRadioButton.AutoSize = true;
            this.sortByNumberRadioButton.Location = new System.Drawing.Point(60, 460);
            this.sortByNumberRadioButton.Name = "sortByNumberRadioButton";
            this.sortByNumberRadioButton.Size = new System.Drawing.Size(107, 16);
            this.sortByNumberRadioButton.TabIndex = 13;
            this.sortByNumberRadioButton.TabStop = true;
            this.sortByNumberRadioButton.Text = "按项目编号排序";
            this.sortByNumberRadioButton.UseVisualStyleBackColor = true;
            this.sortByNumberRadioButton.CheckedChanged += new System.EventHandler(this.SortByNumberRadioButton_CheckedChanged);
            // 
            // addProjectButton
            // 
            this.addProjectButton.Location = new System.Drawing.Point(321, 471);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(80, 30);
            this.addProjectButton.TabIndex = 14;
            this.addProjectButton.Text = "添加项目";
            this.addProjectButton.UseVisualStyleBackColor = true;
            this.addProjectButton.Click += new System.EventHandler(this.AddProjectButton_Click);
            // 
            // sortByBeginTimeRadioButton
            // 
            this.sortByBeginTimeRadioButton.AutoSize = true;
            this.sortByBeginTimeRadioButton.Location = new System.Drawing.Point(173, 495);
            this.sortByBeginTimeRadioButton.Name = "sortByBeginTimeRadioButton";
            this.sortByBeginTimeRadioButton.Size = new System.Drawing.Size(107, 16);
            this.sortByBeginTimeRadioButton.TabIndex = 18;
            this.sortByBeginTimeRadioButton.TabStop = true;
            this.sortByBeginTimeRadioButton.Text = "按起始时间排序";
            this.sortByBeginTimeRadioButton.UseVisualStyleBackColor = true;
            this.sortByBeginTimeRadioButton.CheckedChanged += new System.EventHandler(this.SortByBeginTimeRadioButton_CheckedChanged);
            // 
            // removeProjectButton
            // 
            this.removeProjectButton.Location = new System.Drawing.Point(430, 471);
            this.removeProjectButton.Name = "removeProjectButton";
            this.removeProjectButton.Size = new System.Drawing.Size(80, 30);
            this.removeProjectButton.TabIndex = 16;
            this.removeProjectButton.Text = "删除项目";
            this.removeProjectButton.UseVisualStyleBackColor = true;
            this.removeProjectButton.Click += new System.EventHandler(this.RemoveProjectButton_Click);
            // 
            // sortByEndTimeRadioButton
            // 
            this.sortByEndTimeRadioButton.AutoSize = true;
            this.sortByEndTimeRadioButton.Location = new System.Drawing.Point(60, 495);
            this.sortByEndTimeRadioButton.Name = "sortByEndTimeRadioButton";
            this.sortByEndTimeRadioButton.Size = new System.Drawing.Size(107, 16);
            this.sortByEndTimeRadioButton.TabIndex = 17;
            this.sortByEndTimeRadioButton.TabStop = true;
            this.sortByEndTimeRadioButton.Text = "按结束时间排序";
            this.sortByEndTimeRadioButton.UseVisualStyleBackColor = true;
            this.sortByEndTimeRadioButton.CheckedChanged += new System.EventHandler(this.SortByEndTimeRadioButton_CheckedChanged);
            // 
            // sortByManagerRadioButton
            // 
            this.sortByManagerRadioButton.AutoSize = true;
            this.sortByManagerRadioButton.Location = new System.Drawing.Point(173, 460);
            this.sortByManagerRadioButton.Name = "sortByManagerRadioButton";
            this.sortByManagerRadioButton.Size = new System.Drawing.Size(107, 16);
            this.sortByManagerRadioButton.TabIndex = 15;
            this.sortByManagerRadioButton.TabStop = true;
            this.sortByManagerRadioButton.Text = "按项目经理排序";
            this.sortByManagerRadioButton.UseVisualStyleBackColor = true;
            this.sortByManagerRadioButton.CheckedChanged += new System.EventHandler(this.SortByManagerRadioButton_CheckedChanged);
            // 
            // editInfoButton
            // 
            this.editInfoButton.Location = new System.Drawing.Point(539, 471);
            this.editInfoButton.Name = "editInfoButton";
            this.editInfoButton.Size = new System.Drawing.Size(80, 30);
            this.editInfoButton.TabIndex = 19;
            this.editInfoButton.Text = "修改信息";
            this.editInfoButton.UseVisualStyleBackColor = true;
            this.editInfoButton.Click += new System.EventHandler(this.EditInfoButton_Click);
            // 
            // editProfileButton
            // 
            this.editProfileButton.Location = new System.Drawing.Point(666, 471);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(90, 30);
            this.editProfileButton.TabIndex = 20;
            this.editProfileButton.Text = "修改个人信息";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.EditProfileButton_Click);
            // 
            // ProjectAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.editProfileButton);
            this.Controls.Add(this.editInfoButton);
            this.Controls.Add(this.sortByManagerRadioButton);
            this.Controls.Add(this.sortByEndTimeRadioButton);
            this.Controls.Add(this.removeProjectButton);
            this.Controls.Add(this.sortByBeginTimeRadioButton);
            this.Controls.Add(this.addProjectButton);
            this.Controls.Add(this.sortByNumberRadioButton);
            this.Controls.Add(this.membersTextBox);
            this.Controls.Add(this.managerTextBox);
            this.Controls.Add(this.endTimeTextBox);
            this.Controls.Add(this.beginTimeTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.membersLabel);
            this.Controls.Add(this.managerLabel);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.beginTimeLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.projectsListBox);
            this.Name = "ProjectAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理模拟系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectAdmin_FormClosing);
            this.Load += new System.EventHandler(this.ProjectAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox projectsListBox;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label beginTimeLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label managerLabel;
        private System.Windows.Forms.Label membersLabel;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox beginTimeTextBox;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.TextBox managerTextBox;
        private System.Windows.Forms.TextBox membersTextBox;
        private System.Windows.Forms.RadioButton sortByNumberRadioButton;
        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.RadioButton sortByBeginTimeRadioButton;
        private System.Windows.Forms.Button removeProjectButton;
        private System.Windows.Forms.RadioButton sortByEndTimeRadioButton;
        private System.Windows.Forms.RadioButton sortByManagerRadioButton;
        private System.Windows.Forms.Button editInfoButton;
        private System.Windows.Forms.Button editProfileButton;
    }
}