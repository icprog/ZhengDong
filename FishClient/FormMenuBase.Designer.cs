namespace FishClient
{
    partial class FormMenuBase
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
            if (disposing && (components != null))
            {
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
            this.tmiAdd = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiQuery = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiModify = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiDelete = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiSave = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiCancel = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiExport = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiPrevious = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiNext = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiClose = new FishClient.UIControls.ToolStripMenuItemEx();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmiReview = new FishClient.UIControls.ToolStripMenuItemEx();
            this.tmiprint = new FishClient.UIControls.ToolStripMenuItemEx();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmiAdd
            // 
            this.tmiAdd.FunCode = "01";
            this.tmiAdd.Name = "tmiAdd";
            this.tmiAdd.Size = new System.Drawing.Size(44, 21);
            this.tmiAdd.Tag = "01";
            this.tmiAdd.Text = "新增";
            this.tmiAdd.Click += new System.EventHandler(this.tmiAdd_Click);
            // 
            // tmiQuery
            // 
            this.tmiQuery.FunCode = "02";
            this.tmiQuery.Name = "tmiQuery";
            this.tmiQuery.Size = new System.Drawing.Size(44, 21);
            this.tmiQuery.Tag = "02";
            this.tmiQuery.Text = "查询";
            this.tmiQuery.Click += new System.EventHandler(this.tmiQuery_Click);
            // 
            // tmiModify
            // 
            this.tmiModify.FunCode = "03";
            this.tmiModify.Name = "tmiModify";
            this.tmiModify.Size = new System.Drawing.Size(44, 21);
            this.tmiModify.Tag = "03";
            this.tmiModify.Text = "修改";
            this.tmiModify.Click += new System.EventHandler(this.tmiModify_Click);
            // 
            // tmiDelete
            // 
            this.tmiDelete.FunCode = "04";
            this.tmiDelete.Name = "tmiDelete";
            this.tmiDelete.Size = new System.Drawing.Size(44, 21);
            this.tmiDelete.Tag = "04";
            this.tmiDelete.Text = "删除";
            this.tmiDelete.Click += new System.EventHandler(this.tmiDelete_Click);
            // 
            // tmiSave
            // 
            this.tmiSave.FunCode = "05";
            this.tmiSave.Name = "tmiSave";
            this.tmiSave.Size = new System.Drawing.Size(44, 21);
            this.tmiSave.Tag = "05";
            this.tmiSave.Text = "保存";
            this.tmiSave.Click += new System.EventHandler(this.tmiSave_Click);
            // 
            // tmiCancel
            // 
            this.tmiCancel.FunCode = "06";
            this.tmiCancel.Name = "tmiCancel";
            this.tmiCancel.Size = new System.Drawing.Size(44, 21);
            this.tmiCancel.Tag = "06";
            this.tmiCancel.Text = "取消";
            this.tmiCancel.Click += new System.EventHandler(this.tmiCancel_Click);
            // 
            // tmiExport
            // 
            this.tmiExport.FunCode = "07";
            this.tmiExport.Name = "tmiExport";
            this.tmiExport.Size = new System.Drawing.Size(44, 21);
            this.tmiExport.Tag = "07";
            this.tmiExport.Text = "导出";
            this.tmiExport.Click += new System.EventHandler(this.tmiExport_Click);
            // 
            // tmiPrevious
            // 
            this.tmiPrevious.FunCode = "08";
            this.tmiPrevious.Name = "tmiPrevious";
            this.tmiPrevious.Size = new System.Drawing.Size(56, 21);
            this.tmiPrevious.Tag = "08";
            this.tmiPrevious.Text = "上一个";
            this.tmiPrevious.Click += new System.EventHandler(this.tmiPrevious_Click);
            // 
            // tmiNext
            // 
            this.tmiNext.FunCode = "09";
            this.tmiNext.Name = "tmiNext";
            this.tmiNext.Size = new System.Drawing.Size(56, 21);
            this.tmiNext.Tag = "09";
            this.tmiNext.Text = "下一个";
            this.tmiNext.Click += new System.EventHandler(this.tmiNext_Click);
            // 
            // tmiClose
            // 
            this.tmiClose.FunCode = "10";
            this.tmiClose.Name = "tmiClose";
            this.tmiClose.Size = new System.Drawing.Size(44, 21);
            this.tmiClose.Tag = "10";
            this.tmiClose.Text = "关闭";
            this.tmiClose.Click += new System.EventHandler(this.tmiClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiAdd,
            this.tmiQuery,
            this.tmiModify,
            this.tmiDelete,
            this.tmiReview,
            this.tmiSave,
            this.tmiCancel,
            this.tmiExport,
            this.tmiprint,
            this.tmiPrevious,
            this.tmiNext,
            this.tmiClose});
            this.menuStrip1.Location = new System.Drawing.Point(3, 30);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tmiReview
            // 
            this.tmiReview.FunCode = "11";
            this.tmiReview.Name = "tmiReview";
            this.tmiReview.Size = new System.Drawing.Size(44, 21);
            this.tmiReview.Text = "送审";
            this.tmiReview.Click += new System.EventHandler(this.tmiReview_Click);
            // 
            // tmiprint
            // 
            this.tmiprint.FunCode = "12";
            this.tmiprint.Name = "tmiprint";
            this.tmiprint.Size = new System.Drawing.Size(44, 21);
            this.tmiprint.Text = "打印";
            this.tmiprint.Click += new System.EventHandler(this.tmiprint_Click);
            // 
            // FormMenuBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 418);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenuBase";
            this.Text = "FormMenuBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuBase_FormClosing);
            this.Load += new System.EventHandler(this.FormMenuBase_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected UIControls.ToolStripMenuItemEx tmiAdd;
        protected UIControls.ToolStripMenuItemEx tmiQuery;
        protected UIControls.ToolStripMenuItemEx tmiModify;
        public UIControls.ToolStripMenuItemEx tmiDelete;
        public UIControls.ToolStripMenuItemEx tmiSave;
        public UIControls.ToolStripMenuItemEx tmiCancel;
        protected UIControls.ToolStripMenuItemEx tmiExport;
        protected UIControls.ToolStripMenuItemEx tmiPrevious;
        protected UIControls.ToolStripMenuItemEx tmiNext;
        protected UIControls.ToolStripMenuItemEx tmiClose;
        protected System.Windows.Forms.MenuStrip menuStrip1;
        protected UIControls.ToolStripMenuItemEx tmiReview;
        protected UIControls.ToolStripMenuItemEx tmiprint;
    }
}