namespace FishClient
{
    partial class FormRoles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRoles));
            this.treeViewRoles = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeViewFunCode = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewRoles
            // 
            this.treeViewRoles.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewRoles.HideSelection = false;
            this.treeViewRoles.ImageIndex = 1;
            this.treeViewRoles.ImageList = this.imageList1;
            this.treeViewRoles.ItemHeight = 25;
            this.treeViewRoles.Location = new System.Drawing.Point(3, 55);
            this.treeViewRoles.Name = "treeViewRoles";
            this.treeViewRoles.SelectedImageKey = "role.png";
            this.treeViewRoles.Size = new System.Drawing.Size(194, 374);
            this.treeViewRoles.TabIndex = 1;
            this.treeViewRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoles_AfterSelect);
            this.treeViewRoles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewRoles_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "role.png");
            this.imageList1.Images.SetKeyName(1, "role2.png");
            this.imageList1.Images.SetKeyName(2, "funcode.png");
            // 
            // treeViewFunCode
            // 
            this.treeViewFunCode.CheckBoxes = true;
            this.treeViewFunCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFunCode.HideSelection = false;
            this.treeViewFunCode.ItemHeight = 20;
            this.treeViewFunCode.Location = new System.Drawing.Point(197, 55);
            this.treeViewFunCode.Name = "treeViewFunCode";
            this.treeViewFunCode.Size = new System.Drawing.Size(502, 374);
            this.treeViewFunCode.TabIndex = 2;
            this.treeViewFunCode.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFunCode_AfterCheck);
            this.treeViewFunCode.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFunCode_AfterSelect);
            this.treeViewFunCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewFunCode_MouseDoubleClick);
            // 
            // FormRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 432);
            this.Controls.Add(this.treeViewFunCode);
            this.Controls.Add(this.treeViewRoles);
            this.Name = "FormRoles";
            this.Text = "权限管理";
            this.Load += new System.EventHandler(this.FormRoles_Load);
            this.Controls.SetChildIndex(this.treeViewRoles, 0);
            this.Controls.SetChildIndex(this.treeViewFunCode, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewRoles;
        private System.Windows.Forms.TreeView treeViewFunCode;
        private System.Windows.Forms.ImageList imageList1;
    }
}