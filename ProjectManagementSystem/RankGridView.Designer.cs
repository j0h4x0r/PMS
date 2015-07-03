namespace ProjectManagementSystem
{
    partial class RankGridView
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
            this.rankDataGridView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managerScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warning = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rankDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rankDataGridView
            // 
            this.rankDataGridView.AllowUserToAddRows = false;
            this.rankDataGridView.AllowUserToDeleteRows = false;
            this.rankDataGridView.AllowUserToResizeColumns = false;
            this.rankDataGridView.AllowUserToResizeRows = false;
            this.rankDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rankDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rankDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.project,
            this.finishPercent,
            this.memberScore,
            this.managerScore,
            this.warning});
            this.rankDataGridView.Location = new System.Drawing.Point(6, 8);
            this.rankDataGridView.Name = "rankDataGridView";
            this.rankDataGridView.RowTemplate.Height = 23;
            this.rankDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rankDataGridView.Size = new System.Drawing.Size(630, 450);
            this.rankDataGridView.TabIndex = 0;
            this.rankDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rankDataGridView_CellContentClick);
            this.rankDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.rankDataGridView_ColumnHeaderMouseClick);
            // 
            // name
            // 
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // project
            // 
            this.project.HeaderText = "所在工程";
            this.project.Name = "project";
            this.project.ReadOnly = true;
            // 
            // finishPercent
            // 
            this.finishPercent.HeaderText = "完成情况";
            this.finishPercent.Name = "finishPercent";
            this.finishPercent.ReadOnly = true;
            // 
            // memberScore
            // 
            this.memberScore.HeaderText = "自评分数";
            this.memberScore.Name = "memberScore";
            this.memberScore.ReadOnly = true;
            // 
            // managerScore
            // 
            this.managerScore.HeaderText = "经理评分";
            this.managerScore.Name = "managerScore";
            this.managerScore.ReadOnly = true;
            // 
            // warning
            // 
            this.warning.FalseValue = "false";
            this.warning.HeaderText = "警告";
            this.warning.Name = "warning";
            this.warning.TrueValue = "true";
            // 
            // RankGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 466);
            this.Controls.Add(this.rankDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RankGridView";
            this.Text = "RankGridView";
            this.Load += new System.EventHandler(this.RankGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rankDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rankDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn project;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerScore;
        private System.Windows.Forms.DataGridViewCheckBoxColumn warning;
    }
}