namespace WindowsFormsApp1
{
    partial class modifierNouvelIndex
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
            this.tbModifIndex = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnResetIndex = new MetroFramework.Controls.MetroButton();
            this.btnModifIndex = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblInfoLoc = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // tbModifIndex
            // 
            // 
            // 
            // 
            this.tbModifIndex.CustomButton.Image = null;
            this.tbModifIndex.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.tbModifIndex.CustomButton.Name = "";
            this.tbModifIndex.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbModifIndex.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbModifIndex.CustomButton.TabIndex = 1;
            this.tbModifIndex.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbModifIndex.CustomButton.UseSelectable = true;
            this.tbModifIndex.CustomButton.Visible = false;
            this.tbModifIndex.Lines = new string[0];
            this.tbModifIndex.Location = new System.Drawing.Point(151, 115);
            this.tbModifIndex.MaxLength = 32767;
            this.tbModifIndex.Name = "tbModifIndex";
            this.tbModifIndex.PasswordChar = '\0';
            this.tbModifIndex.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbModifIndex.SelectedText = "";
            this.tbModifIndex.SelectionLength = 0;
            this.tbModifIndex.SelectionStart = 0;
            this.tbModifIndex.ShortcutsEnabled = true;
            this.tbModifIndex.Size = new System.Drawing.Size(148, 23);
            this.tbModifIndex.TabIndex = 76;
            this.tbModifIndex.UseSelectable = true;
            this.tbModifIndex.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbModifIndex.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(31, 117);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(85, 19);
            this.metroLabel2.TabIndex = 75;
            this.metroLabel2.Text = "Nouvel Index";
            // 
            // btnResetIndex
            // 
            this.btnResetIndex.Location = new System.Drawing.Point(165, 152);
            this.btnResetIndex.Name = "btnResetIndex";
            this.btnResetIndex.Size = new System.Drawing.Size(78, 23);
            this.btnResetIndex.TabIndex = 78;
            this.btnResetIndex.Text = "Effacer";
            this.btnResetIndex.UseSelectable = true;
            this.btnResetIndex.Click += new System.EventHandler(this.btnResetIndex_Click);
            // 
            // btnModifIndex
            // 
            this.btnModifIndex.Location = new System.Drawing.Point(79, 152);
            this.btnModifIndex.Name = "btnModifIndex";
            this.btnModifIndex.Size = new System.Drawing.Size(79, 23);
            this.btnModifIndex.TabIndex = 77;
            this.btnModifIndex.Text = "Modifier";
            this.btnModifIndex.UseSelectable = true;
            this.btnModifIndex.Click += new System.EventHandler(this.btnModifIndex_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(33, 19);
            this.metroLabel1.TabIndex = 79;
            this.metroLabel1.Text = "Villa";
            // 
            // lblInfoLoc
            // 
            this.lblInfoLoc.AutoSize = true;
            this.lblInfoLoc.BackColor = System.Drawing.Color.White;
            this.lblInfoLoc.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblInfoLoc.ForeColor = System.Drawing.Color.Black;
            this.lblInfoLoc.Location = new System.Drawing.Point(144, 80);
            this.lblInfoLoc.Name = "lblInfoLoc";
            this.lblInfoLoc.Size = new System.Drawing.Size(0, 0);
            this.lblInfoLoc.TabIndex = 80;
            // 
            // modifierNouvelIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 252);
            this.Controls.Add(this.lblInfoLoc);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tbModifIndex);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnResetIndex);
            this.Controls.Add(this.btnModifIndex);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "modifierNouvelIndex";
            this.Resizable = false;
            this.Text = "Modifer Index";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.modifierNouvelIndex_FormClosing);
            this.Load += new System.EventHandler(this.modifierNouvelIndex_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbModifIndex;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnResetIndex;
        private MetroFramework.Controls.MetroButton btnModifIndex;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel lblInfoLoc;
    }
}