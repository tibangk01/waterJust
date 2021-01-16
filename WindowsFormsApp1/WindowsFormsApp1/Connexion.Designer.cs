namespace WindowsFormsApp1
{
    partial class Connexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tbIdConn = new MetroFramework.Controls.MetroTextBox();
            this.tbMdpConn = new MetroFramework.Controls.MetroTextBox();
            this.btnConn = new MetroFramework.Controls.MetroButton();
            this.btnCancelConn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(59, 73);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Identifiant";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(59, 106);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(88, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Mot De Passe";
            // 
            // tbIdConn
            // 
            // 
            // 
            // 
            this.tbIdConn.CustomButton.Image = null;
            this.tbIdConn.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.tbIdConn.CustomButton.Name = "";
            this.tbIdConn.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbIdConn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbIdConn.CustomButton.TabIndex = 1;
            this.tbIdConn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbIdConn.CustomButton.UseSelectable = true;
            this.tbIdConn.CustomButton.Visible = false;
            this.tbIdConn.Lines = new string[0];
            this.tbIdConn.Location = new System.Drawing.Point(153, 73);
            this.tbIdConn.MaxLength = 32767;
            this.tbIdConn.Name = "tbIdConn";
            this.tbIdConn.PasswordChar = '\0';
            this.tbIdConn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbIdConn.SelectedText = "";
            this.tbIdConn.SelectionLength = 0;
            this.tbIdConn.SelectionStart = 0;
            this.tbIdConn.ShortcutsEnabled = true;
            this.tbIdConn.Size = new System.Drawing.Size(148, 23);
            this.tbIdConn.TabIndex = 11;
            this.tbIdConn.UseSelectable = true;
            this.tbIdConn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbIdConn.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbMdpConn
            // 
            // 
            // 
            // 
            this.tbMdpConn.CustomButton.Image = null;
            this.tbMdpConn.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.tbMdpConn.CustomButton.Name = "";
            this.tbMdpConn.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbMdpConn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbMdpConn.CustomButton.TabIndex = 1;
            this.tbMdpConn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbMdpConn.CustomButton.UseSelectable = true;
            this.tbMdpConn.CustomButton.Visible = false;
            this.tbMdpConn.Lines = new string[0];
            this.tbMdpConn.Location = new System.Drawing.Point(153, 106);
            this.tbMdpConn.MaxLength = 32767;
            this.tbMdpConn.Name = "tbMdpConn";
            this.tbMdpConn.PasswordChar = '*';
            this.tbMdpConn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbMdpConn.SelectedText = "";
            this.tbMdpConn.SelectionLength = 0;
            this.tbMdpConn.SelectionStart = 0;
            this.tbMdpConn.ShortcutsEnabled = true;
            this.tbMdpConn.Size = new System.Drawing.Size(148, 23);
            this.tbMdpConn.TabIndex = 12;
            this.tbMdpConn.UseSelectable = true;
            this.tbMdpConn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbMdpConn.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(105, 146);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(79, 23);
            this.btnConn.TabIndex = 13;
            this.btnConn.Text = "Enrégistrer";
            this.btnConn.UseSelectable = true;
            this.btnConn.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnCancelConn
            // 
            this.btnCancelConn.Location = new System.Drawing.Point(191, 146);
            this.btnCancelConn.Name = "btnCancelConn";
            this.btnCancelConn.Size = new System.Drawing.Size(78, 23);
            this.btnCancelConn.TabIndex = 14;
            this.btnCancelConn.Text = "Annuler";
            this.btnCancelConn.UseSelectable = true;
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 235);
            this.Controls.Add(this.tbMdpConn);
            this.Controls.Add(this.tbIdConn);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnCancelConn);
            this.Controls.Add(this.btnConn);
            this.Name = "Connexion";
            this.Resizable = false;
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.Connexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox tbIdConn;
        private MetroFramework.Controls.MetroTextBox tbMdpConn;
        private MetroFramework.Controls.MetroButton btnConn;
        private MetroFramework.Controls.MetroButton btnCancelConn;
    }
}

