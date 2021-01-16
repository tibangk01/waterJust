namespace WindowsFormsApp1
{
    partial class EnregistrerNouveauxIndexes
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
            this.tbNouvelIndex = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.btnEnregNouvelIndex = new MetroFramework.Controls.MetroButton();
            this.cbAddNouveauIndex = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dgvNouvelIndexes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indexInitial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtNouvelIndex = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNouvelIndexes)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNouvelIndex
            // 
            // 
            // 
            // 
            this.tbNouvelIndex.CustomButton.Image = null;
            this.tbNouvelIndex.CustomButton.Location = new System.Drawing.Point(141, 1);
            this.tbNouvelIndex.CustomButton.Name = "";
            this.tbNouvelIndex.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbNouvelIndex.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbNouvelIndex.CustomButton.TabIndex = 1;
            this.tbNouvelIndex.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbNouvelIndex.CustomButton.UseSelectable = true;
            this.tbNouvelIndex.CustomButton.Visible = false;
            this.tbNouvelIndex.Lines = new string[0];
            this.tbNouvelIndex.Location = new System.Drawing.Point(140, 142);
            this.tbNouvelIndex.MaxLength = 32767;
            this.tbNouvelIndex.Name = "tbNouvelIndex";
            this.tbNouvelIndex.PasswordChar = '\0';
            this.tbNouvelIndex.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbNouvelIndex.SelectedText = "";
            this.tbNouvelIndex.SelectionLength = 0;
            this.tbNouvelIndex.SelectionStart = 0;
            this.tbNouvelIndex.ShortcutsEnabled = true;
            this.tbNouvelIndex.Size = new System.Drawing.Size(163, 23);
            this.tbNouvelIndex.TabIndex = 54;
            this.tbNouvelIndex.UseSelectable = true;
            this.tbNouvelIndex.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbNouvelIndex.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 142);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(85, 19);
            this.metroLabel2.TabIndex = 53;
            this.metroLabel2.Text = "Nouvel Index";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(172, 181);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(78, 23);
            this.metroButton2.TabIndex = 56;
            this.metroButton2.Text = "Annuler";
            this.metroButton2.UseSelectable = true;
            // 
            // btnEnregNouvelIndex
            // 
            this.btnEnregNouvelIndex.Location = new System.Drawing.Point(86, 181);
            this.btnEnregNouvelIndex.Name = "btnEnregNouvelIndex";
            this.btnEnregNouvelIndex.Size = new System.Drawing.Size(79, 23);
            this.btnEnregNouvelIndex.TabIndex = 55;
            this.btnEnregNouvelIndex.Text = "Enrégistrer";
            this.btnEnregNouvelIndex.UseSelectable = true;
            this.btnEnregNouvelIndex.Click += new System.EventHandler(this.btnEnregNouvelIndex_Click);
            // 
            // cbAddNouveauIndex
            // 
            this.cbAddNouveauIndex.FormattingEnabled = true;
            this.cbAddNouveauIndex.ItemHeight = 23;
            this.cbAddNouveauIndex.Location = new System.Drawing.Point(140, 77);
            this.cbAddNouveauIndex.Name = "cbAddNouveauIndex";
            this.cbAddNouveauIndex.Size = new System.Drawing.Size(162, 29);
            this.cbAddNouveauIndex.TabIndex = 58;
            this.cbAddNouveauIndex.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 19);
            this.metroLabel1.TabIndex = 59;
            this.metroLabel1.Text = "Choisir Une Villa";
            // 
            // dgvNouvelIndexes
            // 
            this.dgvNouvelIndexes.AllowUserToAddRows = false;
            this.dgvNouvelIndexes.AllowUserToDeleteRows = false;
            this.dgvNouvelIndexes.AllowUserToResizeColumns = false;
            this.dgvNouvelIndexes.AllowUserToResizeRows = false;
            this.dgvNouvelIndexes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNouvelIndexes.BackgroundColor = System.Drawing.Color.White;
            this.dgvNouvelIndexes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNouvelIndexes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNouvelIndexes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNouvelIndexes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNouvelIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNouvelIndexes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.indexInitial,
            this.Column2,
            this.numSC,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNouvelIndexes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNouvelIndexes.EnableHeadersVisualStyles = false;
            this.dgvNouvelIndexes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNouvelIndexes.Location = new System.Drawing.Point(12, 215);
            this.dgvNouvelIndexes.Name = "dgvNouvelIndexes";
            this.dgvNouvelIndexes.RowHeadersVisible = false;
            this.dgvNouvelIndexes.RowHeadersWidth = 35;
            this.dgvNouvelIndexes.RowTemplate.Height = 43;
            this.dgvNouvelIndexes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNouvelIndexes.Size = new System.Drawing.Size(326, 111);
            this.dgvNouvelIndexes.TabIndex = 60;
            this.dgvNouvelIndexes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNouvelIndexes_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Villas";
            this.Column1.Name = "Column1";
            // 
            // indexInitial
            // 
            this.indexInitial.HeaderText = "Nouvel Ind.";
            this.indexInitial.Name = "indexInitial";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "numFact";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // numSC
            // 
            this.numSC.HeaderText = "numSC";
            this.numSC.Name = "numSC";
            this.numSC.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Modifier";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Modifier";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // dtNouvelIndex
            // 
            this.dtNouvelIndex.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNouvelIndex.Location = new System.Drawing.Point(140, 109);
            this.dtNouvelIndex.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtNouvelIndex.Name = "dtNouvelIndex";
            this.dtNouvelIndex.Size = new System.Drawing.Size(162, 29);
            this.dtNouvelIndex.TabIndex = 61;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(30, 114);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(106, 19);
            this.metroLabel3.TabIndex = 62;
            this.metroLabel3.Text = "Date De Passage";
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // EnregistrerNouveauxIndexes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 346);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtNouvelIndex);
            this.Controls.Add(this.dgvNouvelIndexes);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbAddNouveauIndex);
            this.Controls.Add(this.tbNouvelIndex);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnEnregNouvelIndex);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "EnregistrerNouveauxIndexes";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Nouveaux Indexes";
            this.Activated += new System.EventHandler(this.EnregistrerNouveauxIndexes_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnregistrerNouveauxIndexes_FormClosing);
            this.Load += new System.EventHandler(this.EnregistrerNouveauxIndexes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNouvelIndexes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox tbNouvelIndex;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton btnEnregNouvelIndex;
        private MetroFramework.Controls.MetroComboBox cbAddNouveauIndex;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView dgvNouvelIndexes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexInitial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSC;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private MetroFramework.Controls.MetroDateTime dtNouvelIndex;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}