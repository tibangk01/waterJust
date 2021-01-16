namespace WindowsFormsApp1
{
    partial class ReferencementVilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferencementVilla));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.dgvRefVilla = new System.Windows.Forms.DataGridView();
            this.numVilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSousCompt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indexInitial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefVilla)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(120, 201);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(432, 111);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile1.TabIndex = 1;
            this.metroTile1.Text = "Retourner A L\'accueil";
            this.metroTile1.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile1.TileImage")));
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(558, 201);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(146, 111);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile2.TabIndex = 2;
            this.metroTile2.Text = "Ajouter";
            this.metroTile2.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile2.TileImage")));
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // dgvRefVilla
            // 
            this.dgvRefVilla.AllowUserToAddRows = false;
            this.dgvRefVilla.AllowUserToDeleteRows = false;
            this.dgvRefVilla.AllowUserToResizeColumns = false;
            this.dgvRefVilla.AllowUserToResizeRows = false;
            this.dgvRefVilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRefVilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvRefVilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRefVilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRefVilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefVilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefVilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefVilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numVilla,
            this.numSousCompt,
            this.Column1,
            this.Column2,
            this.indexInitial,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefVilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRefVilla.EnableHeadersVisualStyles = false;
            this.dgvRefVilla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRefVilla.Location = new System.Drawing.Point(120, 321);
            this.dgvRefVilla.Name = "dgvRefVilla";
            this.dgvRefVilla.RowHeadersVisible = false;
            this.dgvRefVilla.RowTemplate.Height = 43;
            this.dgvRefVilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefVilla.Size = new System.Drawing.Size(584, 228);
            this.dgvRefVilla.TabIndex = 4;
            this.dgvRefVilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefVilla_CellClick);
            // 
            // numVilla
            // 
            this.numVilla.HeaderText = "Column5";
            this.numVilla.Name = "numVilla";
            this.numVilla.Visible = false;
            // 
            // numSousCompt
            // 
            this.numSousCompt.HeaderText = "Column5";
            this.numSousCompt.Name = "numSousCompt";
            this.numSousCompt.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nom Loc.";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Prénom Loc.";
            this.Column2.Name = "Column2";
            // 
            // indexInitial
            // 
            this.indexInitial.HeaderText = "Index Ini.";
            this.indexInitial.Name = "indexInitial";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Modifier";
            this.Column3.Name = "Column3";
            this.Column3.Text = "Modifier";
            this.Column3.UseColumnTextForButtonValue = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Supprimer";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Supprimer";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // ReferencementVilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 630);
            this.Controls.Add(this.dgvRefVilla);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ReferencementVilla";
            this.Opacity = 0.99D;
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Référencement Des Villas";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Activated += new System.EventHandler(this.ReferencementVilla_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReferencementVilla_FormClosing);
            this.Load += new System.EventHandler(this.RefVilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefVilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private System.Windows.Forms.DataGridView dgvRefVilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn numVilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSousCompt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexInitial;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}