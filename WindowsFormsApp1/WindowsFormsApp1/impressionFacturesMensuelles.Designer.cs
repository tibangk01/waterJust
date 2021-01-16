namespace WindowsFormsApp1
{
    partial class impressionFacture
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbUneFacture = new MetroFramework.Controls.MetroComboBox();
            this.lblInfoDateFacture = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.lblInfoDateFacture);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.cbUneFacture);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(244, 152);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(359, 264);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(93, 147);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(183, 33);
            this.metroButton1.TabIndex = 62;
            this.metroButton1.Text = "Générer La Facture";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 103);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(126, 19);
            this.metroLabel1.TabIndex = 61;
            this.metroLabel1.Text = "Choisir Un Locataire";
            // 
            // cbUneFacture
            // 
            this.cbUneFacture.FormattingEnabled = true;
            this.cbUneFacture.ItemHeight = 23;
            this.cbUneFacture.Location = new System.Drawing.Point(162, 99);
            this.cbUneFacture.Name = "cbUneFacture";
            this.cbUneFacture.Size = new System.Drawing.Size(162, 29);
            this.cbUneFacture.TabIndex = 60;
            this.cbUneFacture.UseSelectable = true;
            // 
            // lblInfoDateFacture
            // 
            this.lblInfoDateFacture.AutoSize = true;
            this.lblInfoDateFacture.BackColor = System.Drawing.Color.White;
            this.lblInfoDateFacture.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblInfoDateFacture.ForeColor = System.Drawing.Color.Black;
            this.lblInfoDateFacture.Location = new System.Drawing.Point(32, 49);
            this.lblInfoDateFacture.Name = "lblInfoDateFacture";
            this.lblInfoDateFacture.Size = new System.Drawing.Size(146, 19);
            this.lblInfoDateFacture.TabIndex = 81;
            this.lblInfoDateFacture.Text = "Facture Du Mois De :";
            // 
            // impressionFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 630);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "impressionFacture";
            this.Resizable = false;
            this.Text = "Impression Des Factures Mensuelles";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.impressionFacture_FormClosing);
            this.Load += new System.EventHandler(this.impressionFacture_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbUneFacture;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel lblInfoDateFacture;
    }
}