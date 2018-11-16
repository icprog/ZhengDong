namespace FishClient
{
    partial class FormSetReview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userName,
            this.userNum,
            this.programId,
            this.programName,
            this.level});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(795, 377);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // userName
            // 
            this.userName.HeaderText = "用户名";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Width = 150;
            // 
            // userNum
            // 
            this.userNum.HeaderText = "人员姓名";
            this.userNum.Name = "userNum";
            this.userNum.ReadOnly = true;
            this.userNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.userNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.userNum.Width = 150;
            // 
            // programId
            // 
            this.programId.HeaderText = "程序编码";
            this.programId.Name = "programId";
            this.programId.ReadOnly = true;
            this.programId.Width = 150;
            // 
            // programName
            // 
            this.programName.HeaderText = "程序名称";
            this.programName.Name = "programName";
            this.programName.ReadOnly = true;
            this.programName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.programName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.programName.Width = 150;
            // 
            // level
            // 
            this.level.HeaderText = "审核权限";
            this.level.Name = "level";
            this.level.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.level.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.level.Width = 150;
            // 
            // FormSetReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 435);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSetReview";
            this.Text = "审核权限设置";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . DataGridView dataGridView1;
        private System . Windows . Forms . DataGridViewTextBoxColumn userName;
        private System . Windows . Forms . DataGridViewTextBoxColumn userNum;
        private System . Windows . Forms . DataGridViewTextBoxColumn programId;
        private System . Windows . Forms . DataGridViewTextBoxColumn programName;
        private System . Windows . Forms . DataGridViewCheckBoxColumn level;
    }
}