namespace ProjectManagementSystem
{
    partial class SystemAdmin
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("项目组员");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("项目经理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("总经理");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("项目管理员");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("系统管理员");
            this.usersTreeView = new System.Windows.Forms.TreeView();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.realNameLabel = new System.Windows.Forms.Label();
            this.birthday = new System.Windows.Forms.Label();
            this.joinDateLabel = new System.Windows.Forms.Label();
            this.techLevelLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.realNameTextBox = new System.Windows.Forms.TextBox();
            this.birthdayTextBox = new System.Windows.Forms.TextBox();
            this.joinDateTextBox = new System.Windows.Forms.TextBox();
            this.techLevelTextBox = new System.Windows.Forms.TextBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.removeUserButton = new System.Windows.Forms.Button();
            this.editInfoButton = new System.Windows.Forms.Button();
            this.editPasswordButton = new System.Windows.Forms.Button();
            this.saveEditButton = new System.Windows.Forms.Button();
            this.birthdayTimePicker = new System.Windows.Forms.DateTimePicker();
            this.joinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.abortEditButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usersTreeView
            // 
            this.usersTreeView.Location = new System.Drawing.Point(53, 38);
            this.usersTreeView.Name = "usersTreeView";
            treeNode1.Name = "projectMember";
            treeNode1.Text = "项目组员";
            treeNode2.Name = "projectManager";
            treeNode2.Text = "项目经理";
            treeNode3.Name = "generalManager";
            treeNode3.Text = "总经理";
            treeNode4.Name = "projectAdmin";
            treeNode4.Text = "项目管理员";
            treeNode5.Name = "systemAdmin";
            treeNode5.Text = "系统管理员";
            this.usersTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.usersTreeView.Size = new System.Drawing.Size(230, 400);
            this.usersTreeView.TabIndex = 0;
            this.usersTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.usersTreeView_NodeMouseClick);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(329, 80);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(53, 12);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "用 户 名";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(329, 143);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 12);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "密　　码";
            // 
            // realNameLabel
            // 
            this.realNameLabel.AutoSize = true;
            this.realNameLabel.Location = new System.Drawing.Point(329, 206);
            this.realNameLabel.Name = "realNameLabel";
            this.realNameLabel.Size = new System.Drawing.Size(53, 12);
            this.realNameLabel.TabIndex = 3;
            this.realNameLabel.Text = "真实姓名";
            // 
            // birthday
            // 
            this.birthday.AutoSize = true;
            this.birthday.Location = new System.Drawing.Point(329, 269);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(53, 12);
            this.birthday.TabIndex = 4;
            this.birthday.Text = "出生年月";
            // 
            // joinDateLabel
            // 
            this.joinDateLabel.AutoSize = true;
            this.joinDateLabel.Location = new System.Drawing.Point(329, 332);
            this.joinDateLabel.Name = "joinDateLabel";
            this.joinDateLabel.Size = new System.Drawing.Size(53, 12);
            this.joinDateLabel.TabIndex = 5;
            this.joinDateLabel.Text = "入职时间";
            // 
            // techLevelLabel
            // 
            this.techLevelLabel.AutoSize = true;
            this.techLevelLabel.Location = new System.Drawing.Point(329, 395);
            this.techLevelLabel.Name = "techLevelLabel";
            this.techLevelLabel.Size = new System.Drawing.Size(53, 12);
            this.techLevelLabel.TabIndex = 6;
            this.techLevelLabel.Text = "技术级别";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(452, 77);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.ReadOnly = true;
            this.userNameTextBox.Size = new System.Drawing.Size(218, 21);
            this.userNameTextBox.TabIndex = 7;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(452, 140);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.ReadOnly = true;
            this.passwordTextBox.Size = new System.Drawing.Size(218, 21);
            this.passwordTextBox.TabIndex = 8;
            // 
            // realNameTextBox
            // 
            this.realNameTextBox.Location = new System.Drawing.Point(452, 203);
            this.realNameTextBox.Name = "realNameTextBox";
            this.realNameTextBox.ReadOnly = true;
            this.realNameTextBox.Size = new System.Drawing.Size(218, 21);
            this.realNameTextBox.TabIndex = 9;
            // 
            // birthdayTextBox
            // 
            this.birthdayTextBox.Location = new System.Drawing.Point(452, 266);
            this.birthdayTextBox.Name = "birthdayTextBox";
            this.birthdayTextBox.ReadOnly = true;
            this.birthdayTextBox.Size = new System.Drawing.Size(218, 21);
            this.birthdayTextBox.TabIndex = 10;
            // 
            // joinDateTextBox
            // 
            this.joinDateTextBox.Location = new System.Drawing.Point(452, 329);
            this.joinDateTextBox.Name = "joinDateTextBox";
            this.joinDateTextBox.ReadOnly = true;
            this.joinDateTextBox.Size = new System.Drawing.Size(218, 21);
            this.joinDateTextBox.TabIndex = 11;
            // 
            // techLevelTextBox
            // 
            this.techLevelTextBox.Location = new System.Drawing.Point(452, 392);
            this.techLevelTextBox.Name = "techLevelTextBox";
            this.techLevelTextBox.ReadOnly = true;
            this.techLevelTextBox.Size = new System.Drawing.Size(218, 21);
            this.techLevelTextBox.TabIndex = 12;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(65, 470);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(80, 30);
            this.addUserButton.TabIndex = 13;
            this.addUserButton.Text = "添加用户";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // removeUserButton
            // 
            this.removeUserButton.Enabled = false;
            this.removeUserButton.Location = new System.Drawing.Point(190, 470);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(80, 30);
            this.removeUserButton.TabIndex = 14;
            this.removeUserButton.Text = "删除用户";
            this.removeUserButton.UseVisualStyleBackColor = true;
            this.removeUserButton.Click += new System.EventHandler(this.removeUserButton_Click);
            // 
            // editInfoButton
            // 
            this.editInfoButton.Location = new System.Drawing.Point(572, 470);
            this.editInfoButton.Name = "editInfoButton";
            this.editInfoButton.Size = new System.Drawing.Size(80, 30);
            this.editInfoButton.TabIndex = 15;
            this.editInfoButton.Text = "修改信息";
            this.editInfoButton.UseVisualStyleBackColor = true;
            this.editInfoButton.Click += new System.EventHandler(this.editInfoButton_Click);
            // 
            // editPasswordButton
            // 
            this.editPasswordButton.Location = new System.Drawing.Point(698, 140);
            this.editPasswordButton.Name = "editPasswordButton";
            this.editPasswordButton.Size = new System.Drawing.Size(53, 21);
            this.editPasswordButton.TabIndex = 16;
            this.editPasswordButton.Text = "修改";
            this.editPasswordButton.UseVisualStyleBackColor = true;
            this.editPasswordButton.Visible = false;
            this.editPasswordButton.Click += new System.EventHandler(this.editPasswordButton_Click);
            // 
            // saveEditButton
            // 
            this.saveEditButton.Location = new System.Drawing.Point(461, 470);
            this.saveEditButton.Name = "saveEditButton";
            this.saveEditButton.Size = new System.Drawing.Size(80, 30);
            this.saveEditButton.TabIndex = 17;
            this.saveEditButton.Text = "保存修改";
            this.saveEditButton.UseVisualStyleBackColor = true;
            this.saveEditButton.Visible = false;
            this.saveEditButton.Click += new System.EventHandler(this.saveEditButton_Click);
            // 
            // birthdayTimePicker
            // 
            this.birthdayTimePicker.Location = new System.Drawing.Point(452, 266);
            this.birthdayTimePicker.Name = "birthdayTimePicker";
            this.birthdayTimePicker.Size = new System.Drawing.Size(218, 21);
            this.birthdayTimePicker.TabIndex = 18;
            this.birthdayTimePicker.Visible = false;
            // 
            // joinDateTimePicker
            // 
            this.joinDateTimePicker.Location = new System.Drawing.Point(452, 329);
            this.joinDateTimePicker.Name = "joinDateTimePicker";
            this.joinDateTimePicker.Size = new System.Drawing.Size(218, 21);
            this.joinDateTimePicker.TabIndex = 19;
            this.joinDateTimePicker.Visible = false;
            // 
            // abortEditButton
            // 
            this.abortEditButton.Location = new System.Drawing.Point(572, 470);
            this.abortEditButton.Name = "abortEditButton";
            this.abortEditButton.Size = new System.Drawing.Size(80, 30);
            this.abortEditButton.TabIndex = 20;
            this.abortEditButton.Text = "放弃修改";
            this.abortEditButton.UseVisualStyleBackColor = true;
            this.abortEditButton.Visible = false;
            this.abortEditButton.Click += new System.EventHandler(this.abortEditButton_Click);
            // 
            // SystemAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.abortEditButton);
            this.Controls.Add(this.joinDateTimePicker);
            this.Controls.Add(this.birthdayTimePicker);
            this.Controls.Add(this.saveEditButton);
            this.Controls.Add(this.editPasswordButton);
            this.Controls.Add(this.editInfoButton);
            this.Controls.Add(this.removeUserButton);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.techLevelTextBox);
            this.Controls.Add(this.joinDateTextBox);
            this.Controls.Add(this.birthdayTextBox);
            this.Controls.Add(this.realNameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.techLevelLabel);
            this.Controls.Add(this.joinDateLabel);
            this.Controls.Add(this.birthday);
            this.Controls.Add(this.realNameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.usersTreeView);
            this.Name = "SystemAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理模拟系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SystemAdmin_FormClosing);
            this.Load += new System.EventHandler(this.SystemAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView usersTreeView;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label realNameLabel;
        private System.Windows.Forms.Label birthday;
        private System.Windows.Forms.Label joinDateLabel;
        private System.Windows.Forms.Label techLevelLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox realNameTextBox;
        private System.Windows.Forms.TextBox birthdayTextBox;
        private System.Windows.Forms.TextBox joinDateTextBox;
        private System.Windows.Forms.TextBox techLevelTextBox;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button removeUserButton;
        private System.Windows.Forms.Button editInfoButton;
        private System.Windows.Forms.Button editPasswordButton;
        private System.Windows.Forms.Button saveEditButton;
        private System.Windows.Forms.DateTimePicker birthdayTimePicker;
        private System.Windows.Forms.DateTimePicker joinDateTimePicker;
        private System.Windows.Forms.Button abortEditButton;
    }
}