namespace FishClient
{
    partial class FormFish
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.fishCompositionControl1 = new FishClient.UIControls.FishCompositionControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fishSummaryControl1 = new FishClient.UIControls.FishSummaryControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelAll = new System.Windows.Forms.Panel();
            this.panelBotton = new System.Windows.Forms.Panel();
            this.fishSelfControl1 = new FishClient.UIControls.FishSelfControl();
            this.fishSaleControl1 = new FishClient.UIControls.FishSaleControl();
            this.fishSpotGoodsControl1 = new FishClient.UIControls.FishSpotGoodsControl();
            this.fishComfirmControl1 = new FishClient.UIControls.FishConfirmControl();
            this.fishQuoteControl1 = new FishClient.UIControls.FishQuoteControl();
            this.fishInfoControl1 = new FishClient.UIControls.FishInfoControl();
            this.panelAll.SuspendLayout();
            this.panelBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1224, 6);
            this.panel2.TabIndex = 3;
            // 
            // fishCompositionControl1
            // 
            this.fishCompositionControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fishCompositionControl1.Location = new System.Drawing.Point(0, 184);
            this.fishCompositionControl1.Name = "fishCompositionControl1";
            this.fishCompositionControl1.Size = new System.Drawing.Size(1224, 340);
            this.fishCompositionControl1.TabIndex = 4;
            this.fishCompositionControl1.Load += new System.EventHandler(this.fishCompositionControl1_Load);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Location = new System.Drawing.Point(3, 637);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1094, 6);
            this.panel3.TabIndex = 5;
            // 
            // fishSummaryControl1
            // 
            this.fishSummaryControl1.Location = new System.Drawing.Point(172, 649);
            this.fishSummaryControl1.Name = "fishSummaryControl1";
            this.fishSummaryControl1.Size = new System.Drawing.Size(359, 84);
            this.fishSummaryControl1.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 524);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1224, 6);
            this.panel4.TabIndex = 7;
            // 
            // panelAll
            // 
            this.panelAll.AutoScroll = true;
            this.panelAll.Controls.Add(this.panelBotton);
            this.panelAll.Controls.Add(this.panel4);
            this.panelAll.Controls.Add(this.fishCompositionControl1);
            this.panelAll.Controls.Add(this.panel2);
            this.panelAll.Controls.Add(this.fishInfoControl1);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(3, 55);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1241, 704);
            this.panelAll.TabIndex = 10;
            // 
            // panelBotton
            // 
            this.panelBotton.Controls.Add(this.fishSelfControl1);
            this.panelBotton.Controls.Add(this.fishSaleControl1);
            this.panelBotton.Controls.Add(this.fishSpotGoodsControl1);
            this.panelBotton.Controls.Add(this.fishComfirmControl1);
            this.panelBotton.Controls.Add(this.fishQuoteControl1);
            this.panelBotton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotton.Location = new System.Drawing.Point(0, 530);
            this.panelBotton.Name = "panelBotton";
            this.panelBotton.Size = new System.Drawing.Size(1224, 360);
            this.panelBotton.TabIndex = 10;
            // 
            // fishSelfControl1
            // 
            this.fishSelfControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fishSelfControl1.Location = new System.Drawing.Point(996, 0);
            this.fishSelfControl1.Name = "fishSelfControl1";
            this.fishSelfControl1.Size = new System.Drawing.Size(246, 360);
            this.fishSelfControl1.TabIndex = 4;
            // 
            // fishSaleControl1
            // 
            this.fishSaleControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fishSaleControl1.Location = new System.Drawing.Point(747, 0);
            this.fishSaleControl1.Name = "fishSaleControl1";
            this.fishSaleControl1.Size = new System.Drawing.Size(249, 360);
            this.fishSaleControl1.TabIndex = 3;
            // 
            // fishSpotGoodsControl1
            // 
            this.fishSpotGoodsControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fishSpotGoodsControl1.Location = new System.Drawing.Point(508, 0);
            this.fishSpotGoodsControl1.Name = "fishSpotGoodsControl1";
            this.fishSpotGoodsControl1.Size = new System.Drawing.Size(239, 360);
            this.fishSpotGoodsControl1.TabIndex = 2;
            // 
            // fishComfirmControl1
            // 
            this.fishComfirmControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fishComfirmControl1.Location = new System.Drawing.Point(265, 0);
            this.fishComfirmControl1.Name = "fishComfirmControl1";
            this.fishComfirmControl1.Size = new System.Drawing.Size(243, 360);
            this.fishComfirmControl1.TabIndex = 1;
            // 
            // fishQuoteControl1
            // 
            this.fishQuoteControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fishQuoteControl1.Location = new System.Drawing.Point(0, 0);
            this.fishQuoteControl1.Name = "fishQuoteControl1";
            this.fishQuoteControl1.Size = new System.Drawing.Size(265, 360);
            this.fishQuoteControl1.TabIndex = 0;
            // 
            // fishInfoControl1
            // 
            this.fishInfoControl1.AllowDrop = true;
            this.fishInfoControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fishInfoControl1.Location = new System.Drawing.Point(0, 0);
            this.fishInfoControl1.Name = "fishInfoControl1";
            this.fishInfoControl1.Size = new System.Drawing.Size(1224, 178);
            this.fishInfoControl1.TabIndex = 9;
            this.fishInfoControl1.Load += new System.EventHandler(this.fishInfoControl1_Load);
            this.fishInfoControl1.DoubleClick += new System.EventHandler(this.fishInfoControl1_DoubleClick);
            // 
            // FormFish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 762);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.fishSummaryControl1);
            this.Name = "FormFish";
            this.Text = "鱼粉资料";
            this.Controls.SetChildIndex(this.fishSummaryControl1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panelAll, 0);
            this.panelAll.ResumeLayout(false);
            this.panelBotton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private UIControls.FishCompositionControl fishCompositionControl1;
        private System.Windows.Forms.Panel panel3;
        private UIControls.FishSummaryControl fishSummaryControl1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Panel panelBotton;
        private UIControls.FishQuoteControl fishQuoteControl1;
        private UIControls.FishSelfControl fishSelfControl1;
        private UIControls.FishSaleControl fishSaleControl1;
        private UIControls.FishSpotGoodsControl fishSpotGoodsControl1;
        private UIControls.FishConfirmControl fishComfirmControl1;
        private UIControls.FishInfoControl fishInfoControl1;
    }
}