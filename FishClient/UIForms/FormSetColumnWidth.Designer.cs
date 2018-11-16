namespace FishClient.UIForms
{
    partial class FormSetColumnWidth
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
            this.tableLayoutPanelEx1 = new UILibrary.TableLayoutPanelEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.tableLayoutPanelEx1.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelEx1
            // 
            this.tableLayoutPanelEx1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelEx1.ColumnCount = 3;
            this.tableLayoutPanelEx1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanelEx1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanelEx1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 288F));
            this.tableLayoutPanelEx1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelEx1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelEx1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelEx1.Name = "tableLayoutPanelEx1";
            this.tableLayoutPanelEx1.RowCount = 2;
            this.tableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanelEx1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEx1.Size = new System.Drawing.Size(658, 295);
            this.tableLayoutPanelEx1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "列名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(168, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "列宽";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAll
            // 
            this.panelAll.AutoScroll = true;
            this.panelAll.Controls.Add(this.tableLayoutPanelEx1);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(3, 55);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(658, 413);
            this.panelAll.TabIndex = 1;
            // 
            // FormSetColumnWidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 471);
            this.Controls.Add(this.panelAll);
            this.MinimizeBox = false;
            this.Name = "FormSetColumnWidth";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置列的宽度";
            this.Load += new System.EventHandler(this.FormSetColumnWidth_Load);
            this.Controls.SetChildIndex(this.panelAll, 0);
            this.tableLayoutPanelEx1.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UILibrary.TableLayoutPanelEx tableLayoutPanelEx1;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}