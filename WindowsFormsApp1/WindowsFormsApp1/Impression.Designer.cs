namespace WindowsFormsApp1
{
    partial class Impression
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvUn = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(20, 60);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(790, 550);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // crvUn
            // 
            this.crvUn.ActiveViewIndex = -1;
            this.crvUn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvUn.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvUn.DisplayStatusBar = false;
            this.crvUn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvUn.Location = new System.Drawing.Point(20, 60);
            this.crvUn.Name = "crvUn";
            this.crvUn.ShowCloseButton = false;
            this.crvUn.ShowCopyButton = false;
            this.crvUn.ShowExportButton = false;
            this.crvUn.ShowGotoPageButton = false;
            this.crvUn.ShowGroupTreeButton = false;
            this.crvUn.ShowLogo = false;
            this.crvUn.ShowPageNavigateButtons = false;
            this.crvUn.ShowParameterPanelButton = false;
            this.crvUn.ShowRefreshButton = false;
            this.crvUn.ShowTextSearchButton = false;
            this.crvUn.Size = new System.Drawing.Size(790, 550);
            this.crvUn.TabIndex = 1;
            this.crvUn.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvUn.Load += new System.EventHandler(this.crvUn_Load);
            // 
            // Impression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 630);
            this.Controls.Add(this.crvUn);
            this.Controls.Add(this.crystalReportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Impression";
            this.Resizable = false;
            this.Text = "Impression";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Impression_FormClosing);
            this.Load += new System.EventHandler(this.Impression_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvUn;
    }
}