namespace WindowsFormsApp1
{
    partial class modifierNouveauMontantFacture
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
            this.tbModifMontantFacture = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnResetMontantFacture = new MetroFramework.Controls.MetroButton();
            this.btnModifMontantFacture = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // tbModifMontantFacture
            // 
            // 
            // 
            // 
            this.tbModifMontantFacture.CustomButton.Image = null;
            this.tbModifMontantFacture.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.tbModifMontantFacture.CustomButton.Name = "";
            this.tbModifMontantFacture.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbModifMontantFacture.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbModifMontantFacture.CustomButton.TabIndex = 1;
            this.tbModifMontantFacture.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbModifMontantFacture.CustomButton.UseSelectable = true;
            this.tbModifMontantFacture.CustomButton.Visible = false;
            this.tbModifMontantFacture.Lines = new string[0];
            this.tbModifMontantFacture.Location = new System.Drawing.Point(151, 95);
            this.tbModifMontantFacture.MaxLength = 32767;
            this.tbModifMontantFacture.Name = "tbModifMontantFacture";
            this.tbModifMontantFacture.PasswordChar = '\0';
            this.tbModifMontantFacture.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbModifMontantFacture.SelectedText = "";
            this.tbModifMontantFacture.SelectionLength = 0;
            this.tbModifMontantFacture.SelectionStart = 0;
            this.tbModifMontantFacture.ShortcutsEnabled = true;
            this.tbModifMontantFacture.Size = new System.Drawing.Size(148, 23);
            this.tbModifMontantFacture.TabIndex = 72;
            this.tbModifMontantFacture.UseSelectable = true;
            this.tbModifMontantFacture.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbModifMontantFacture.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(31, 95);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(114, 19);
            this.metroLabel2.TabIndex = 71;
            this.metroLabel2.Text = "Nouveau Montant";
            // 
            // btnResetMontantFacture
            // 
            this.btnResetMontantFacture.Location = new System.Drawing.Point(165, 132);
            this.btnResetMontantFacture.Name = "btnResetMontantFacture";
            this.btnResetMontantFacture.Size = new System.Drawing.Size(78, 23);
            this.btnResetMontantFacture.TabIndex = 74;
            this.btnResetMontantFacture.Text = "Annuler";
            this.btnResetMontantFacture.UseSelectable = true;
            this.btnResetMontantFacture.Click += new System.EventHandler(this.btnResetMontantFacture_Click);
            // 
            // btnModifMontantFacture
            // 
            this.btnModifMontantFacture.Location = new System.Drawing.Point(79, 132);
            this.btnModifMontantFacture.Name = "btnModifMontantFacture";
            this.btnModifMontantFacture.Size = new System.Drawing.Size(79, 23);
            this.btnModifMontantFacture.TabIndex = 73;
            this.btnModifMontantFacture.Text = "Modifier";
            this.btnModifMontantFacture.UseSelectable = true;
            this.btnModifMontantFacture.Click += new System.EventHandler(this.btnModifMontantFacture_Click);
            // 
            // modifierNouveauMontantFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 252);
            this.Controls.Add(this.tbModifMontantFacture);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnResetMontantFacture);
            this.Controls.Add(this.btnModifMontantFacture);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "modifierNouveauMontantFacture";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Modifier Le Montant";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.modifierNouveauMontantFacture_FormClosing);
            this.Load += new System.EventHandler(this.modifierNouveauMontantFacture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbModifMontantFacture;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnResetMontantFacture;
        private MetroFramework.Controls.MetroButton btnModifMontantFacture;
    }
}