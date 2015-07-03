namespace ProjectManagementSystem
{
    partial class ProjectDialogue
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
            this.numberLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.beginTimeLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.managerLabel = new System.Windows.Forms.Label();
            this.membersLabel = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.managerComboBox = new System.Windows.Forms.ComboBox();
            this.membersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(77, 50);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(53, 12);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.Text = "项目编号";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(77, 104);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 12);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "项目名称";
            // 
            // beginTimeLabel
            // 
            this.beginTimeLabel.AutoSize = true;
            this.beginTimeLabel.Location = new System.Drawing.Point(77, 158);
            this.beginTimeLabel.Name = "beginTimeLabel";
            this.beginTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.beginTimeLabel.TabIndex = 2;
            this.beginTimeLabel.Text = "起始时间";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(77, 212);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.endTimeLabel.TabIndex = 3;
            this.endTimeLabel.Text = "结束时间";
            // 
            // managerLabel
            // 
            this.managerLabel.AutoSize = true;
            this.managerLabel.Location = new System.Drawing.Point(77, 266);
            this.managerLabel.Name = "managerLabel";
            this.managerLabel.Size = new System.Drawing.Size(53, 12);
            this.managerLabel.TabIndex = 4;
            this.managerLabel.Text = "项目经理";
            // 
            // membersLabel
            // 
            this.membersLabel.AutoSize = true;
            this.membersLabel.Location = new System.Drawing.Point(77, 320);
            this.membersLabel.Name = "membersLabel";
            this.membersLabel.Size = new System.Drawing.Size(53, 12);
            this.membersLabel.TabIndex = 5;
            this.membersLabel.Text = "项目成员";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(185, 47);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(218, 21);
            this.numberTextBox.TabIndex = 6;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(185, 101);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(218, 21);
            this.nameTextBox.TabIndex = 7;
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Location = new System.Drawing.Point(185, 154);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.Size = new System.Drawing.Size(218, 21);
            this.beginDateTimePicker.TabIndex = 8;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(185, 208);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(218, 21);
            this.endDateTimePicker.TabIndex = 9;
            // 
            // managerComboBox
            // 
            this.managerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.managerComboBox.FormattingEnabled = true;
            this.managerComboBox.Location = new System.Drawing.Point(185, 263);
            this.managerComboBox.Name = "managerComboBox";
            this.managerComboBox.Size = new System.Drawing.Size(218, 20);
            this.managerComboBox.TabIndex = 10;
            // 
            // membersCheckedListBox
            // 
            this.membersCheckedListBox.CheckOnClick = true;
            this.membersCheckedListBox.FormattingEnabled = true;
            this.membersCheckedListBox.Location = new System.Drawing.Point(185, 311);
            this.membersCheckedListBox.Name = "membersCheckedListBox";
            this.membersCheckedListBox.Size = new System.Drawing.Size(218, 68);
            this.membersCheckedListBox.TabIndex = 11;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(96, 422);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(104, 35);
            this.submitButton.TabIndex = 12;
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(264, 422);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(104, 35);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ProjectDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 566);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.membersCheckedListBox);
            this.Controls.Add(this.managerComboBox);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.beginDateTimePicker);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.membersLabel);
            this.Controls.Add(this.managerLabel);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.beginTimeLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.numberLabel);
            this.Name = "ProjectDialogue";
            this.Text = "添加/编辑项目";
            this.Load += new System.EventHandler(this.ProjectDialogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label beginTimeLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label managerLabel;
        private System.Windows.Forms.Label membersLabel;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.ComboBox managerComboBox;
        private System.Windows.Forms.CheckedListBox membersCheckedListBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
    }
}