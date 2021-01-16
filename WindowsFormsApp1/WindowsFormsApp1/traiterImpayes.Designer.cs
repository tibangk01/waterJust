namespace WindowsFormsApp1
{
    partial class traiterImpayes
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbAddNouveauIndex = new MetroFramework.Controls.MetroComboBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 99);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(111, 19);
            this.metroLabel1.TabIndex = 61;
            this.metroLabel1.Text = "Liste Des Impayés";
            // 
            // cbAddNouveauIndex
            // 
            this.cbAddNouveauIndex.FormattingEnabled = true;
            this.cbAddNouveauIndex.ItemHeight = 23;
            this.cbAddNouveauIndex.Location = new System.Drawing.Point(147, 95);
            this.cbAddNouveauIndex.Name = "cbAddNouveauIndex";
            this.cbAddNouveauIndex.Size = new System.Drawing.Size(162, 29);
            this.cbAddNouveauIndex.TabIndex = 60;
            this.cbAddNouveauIndex.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(74, 136);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(183, 33);
            this.metroButton1.TabIndex = 69;
            this.metroButton1.Text = "Traiter L\'impayé";
            this.metroButton1.UseSelectable = true;
            // 
            // traiterImpayes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 252);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbAddNouveauIndex);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "traiterImpayes";
            this.Resizable = false;
            this.Text = "Traiter Les Impayés";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.traiterImpayes_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbAddNouveauIndex;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}