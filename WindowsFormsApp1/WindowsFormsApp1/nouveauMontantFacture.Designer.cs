namespace WindowsFormsApp1
{
    partial class nouveauMontantFacture
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbMontantFacture = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnAnnulerMontantFacture = new MetroFramework.Controls.MetroButton();
            this.btnAjoutMontantFacture = new MetroFramework.Controls.MetroButton();
            this.dgvNouveauMontant = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indexInitial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNouveauMontant)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMontantFacture
            // 
            // 
            // 
            // 
            this.tbMontantFacture.CustomButton.Image = null;
            this.tbMontantFacture.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.tbMontantFacture.CustomButton.Name = "";
            this.tbMontantFacture.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbMontantFacture.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbMontantFacture.CustomButton.TabIndex = 1;
            this.tbMontantFacture.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbMontantFacture.CustomButton.UseSelectable = true;
            this.tbMontantFacture.CustomButton.Visible = false;
            this.tbMontantFacture.Lines = new string[0];
            this.tbMontantFacture.Location = new System.Drawing.Point(150, 77);
            this.tbMontantFacture.MaxLength = 32767;
            this.tbMontantFacture.Name = "tbMontantFacture";
            this.tbMontantFacture.PasswordChar = '\0';
            this.tbMontantFacture.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbMontantFacture.SelectedText = "";
            this.tbMontantFacture.SelectionLength = 0;
            this.tbMontantFacture.SelectionStart = 0;
            this.tbMontantFacture.ShortcutsEnabled = true;
            this.tbMontantFacture.Size = new System.Drawing.Size(148, 23);
            this.tbMontantFacture.TabIndex = 68;
            this.tbMontantFacture.UseSelectable = true;
            this.tbMontantFacture.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbMontantFacture.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(30, 77);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(114, 19);
            this.metroLabel2.TabIndex = 67;
            this.metroLabel2.Text = "Entrer Le Montant";
            // 
            // btnAnnulerMontantFacture
            // 
            this.btnAnnulerMontantFacture.Location = new System.Drawing.Point(164, 114);
            this.btnAnnulerMontantFacture.Name = "btnAnnulerMontantFacture";
            this.btnAnnulerMontantFacture.Size = new System.Drawing.Size(78, 23);
            this.btnAnnulerMontantFacture.TabIndex = 70;
            this.btnAnnulerMontantFacture.Text = "Annuler";
            this.btnAnnulerMontantFacture.UseSelectable = true;
            // 
            // btnAjoutMontantFacture
            // 
            this.btnAjoutMontantFacture.Location = new System.Drawing.Point(78, 114);
            this.btnAjoutMontantFacture.Name = "btnAjoutMontantFacture";
            this.btnAjoutMontantFacture.Size = new System.Drawing.Size(79, 23);
            this.btnAjoutMontantFacture.TabIndex = 69;
            this.btnAjoutMontantFacture.Text = "Enrégistrer";
            this.btnAjoutMontantFacture.UseSelectable = true;
            this.btnAjoutMontantFacture.Click += new System.EventHandler(this.btnAjoutMontantFacture_Click);
            // 
            // dgvNouveauMontant
            // 
            this.dgvNouveauMontant.AllowUserToAddRows = false;
            this.dgvNouveauMontant.AllowUserToDeleteRows = false;
            this.dgvNouveauMontant.AllowUserToResizeColumns = false;
            this.dgvNouveauMontant.AllowUserToResizeRows = false;
            this.dgvNouveauMontant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNouveauMontant.BackgroundColor = System.Drawing.Color.White;
            this.dgvNouveauMontant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNouveauMontant.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNouveauMontant.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNouveauMontant.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNouveauMontant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNouveauMontant.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.indexInitial,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNouveauMontant.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNouveauMontant.EnableHeadersVisualStyles = false;
            this.dgvNouveauMontant.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNouveauMontant.Location = new System.Drawing.Point(23, 154);
            this.dgvNouveauMontant.Name = "dgvNouveauMontant";
            this.dgvNouveauMontant.RowHeadersVisible = false;
            this.dgvNouveauMontant.RowTemplate.Height = 43;
            this.dgvNouveauMontant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNouveauMontant.Size = new System.Drawing.Size(284, 75);
            this.dgvNouveauMontant.TabIndex = 71;
            this.dgvNouveauMontant.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNouveauMontant_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Villas";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // indexInitial
            // 
            this.indexInitial.HeaderText = "Montant Fact.";
            this.indexInitial.Name = "indexInitial";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Modifier";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Modifier";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // nouveauMontantFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 252);
            this.Controls.Add(this.dgvNouveauMontant);
            this.Controls.Add(this.tbMontantFacture);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnAnnulerMontantFacture);
            this.Controls.Add(this.btnAjoutMontantFacture);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "nouveauMontantFacture";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Nouveau Montant";
            this.Activated += new System.EventHandler(this.nouveauMontantFacture_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.nouveauMontantFacture_FormClosing);
            this.Load += new System.EventHandler(this.nouveauMontantFacture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNouveauMontant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbMontantFacture;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnAnnulerMontantFacture;
        private MetroFramework.Controls.MetroButton btnAjoutMontantFacture;
        private System.Windows.Forms.DataGridView dgvNouveauMontant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexInitial;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}