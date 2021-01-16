namespace WindowsFormsApp1
{
    partial class Accueil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.TileStateList = new MetroFramework.Controls.MetroTile();
            this.TileGestUser = new MetroFramework.Controls.MetroTile();
            this.TileHousesRef = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(743, 602);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "12:12:23";
            // 
            // metroTile6
            // 
            this.metroTile6.ActiveControl = null;
            this.metroTile6.Location = new System.Drawing.Point(167, 326);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(150, 107);
            this.metroTile6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile6.TabIndex = 14;
            this.metroTile6.Text = "Traiter Les Impayés";
            this.metroTile6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile6.TileImage = global::WindowsFormsApp1.Properties.Resources.coins_64px;
            this.metroTile6.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile6.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile6.UseSelectable = true;
            this.metroTile6.UseTileImage = true;
            this.metroTile6.Click += new System.EventHandler(this.metroTile6_Click_1);
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.Location = new System.Drawing.Point(323, 326);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(340, 107);
            this.metroTile5.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile5.TabIndex = 13;
            this.metroTile5.Text = "Valider La Facture En Cours";
            this.metroTile5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile5.TileImage = global::WindowsFormsApp1.Properties.Resources.validation_64px;
            this.metroTile5.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile5.UseSelectable = true;
            this.metroTile5.UseTileImage = true;
            this.metroTile5.Click += new System.EventHandler(this.metroTile5_Click_1);
            // 
            // TileStateList
            // 
            this.TileStateList.ActiveControl = null;
            this.TileStateList.Location = new System.Drawing.Point(350, 439);
            this.TileStateList.Name = "TileStateList";
            this.TileStateList.Size = new System.Drawing.Size(137, 117);
            this.TileStateList.Style = MetroFramework.MetroColorStyle.Silver;
            this.TileStateList.TabIndex = 12;
            this.TileStateList.Text = "Liste Des Etats";
            this.TileStateList.TileImage = ((System.Drawing.Image)(resources.GetObject("TileStateList.TileImage")));
            this.TileStateList.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TileStateList.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.TileStateList.UseSelectable = true;
            this.TileStateList.UseTileImage = true;
            this.TileStateList.Click += new System.EventHandler(this.metroTile7_Click);
            // 
            // TileGestUser
            // 
            this.TileGestUser.ActiveControl = null;
            this.TileGestUser.Location = new System.Drawing.Point(167, 439);
            this.TileGestUser.Name = "TileGestUser";
            this.TileGestUser.Size = new System.Drawing.Size(177, 117);
            this.TileGestUser.Style = MetroFramework.MetroColorStyle.Blue;
            this.TileGestUser.TabIndex = 11;
            this.TileGestUser.Text = "Gérer Les Utilisateurs";
            this.TileGestUser.TileImage = ((System.Drawing.Image)(resources.GetObject("TileGestUser.TileImage")));
            this.TileGestUser.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TileGestUser.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.TileGestUser.UseSelectable = true;
            this.TileGestUser.UseTileImage = true;
            this.TileGestUser.Click += new System.EventHandler(this.metroTile6_Click);
            // 
            // TileHousesRef
            // 
            this.TileHousesRef.ActiveControl = null;
            this.TileHousesRef.Location = new System.Drawing.Point(493, 439);
            this.TileHousesRef.Name = "TileHousesRef";
            this.TileHousesRef.Size = new System.Drawing.Size(170, 117);
            this.TileHousesRef.Style = MetroFramework.MetroColorStyle.Purple;
            this.TileHousesRef.TabIndex = 10;
            this.TileHousesRef.Text = "Référencer Les Villas";
            this.TileHousesRef.TileImage = ((System.Drawing.Image)(resources.GetObject("TileHousesRef.TileImage")));
            this.TileHousesRef.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TileHousesRef.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.TileHousesRef.UseSelectable = true;
            this.TileHousesRef.UseTileImage = true;
            this.TileHousesRef.Click += new System.EventHandler(this.metroTile5_Click);
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Location = new System.Drawing.Point(447, 85);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(216, 235);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile3.TabIndex = 8;
            this.metroTile3.Text = "Imprimer La Facture Du Mois";
            this.metroTile3.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile3.TileImage")));
            this.metroTile3.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.UseTileImage = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(167, 211);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(274, 109);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTile2.TabIndex = 7;
            this.metroTile2.Text = "Enregistrer Les Nouveaux Indexes";
            this.metroTile2.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile2.TileImage")));
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(167, 85);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(274, 120);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "Enregistrer Le Montant De La  Facture";
            this.metroTile1.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile1.TileImage")));
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(830, 630);
            this.Controls.Add(this.metroTile6);
            this.Controls.Add(this.metroTile5);
            this.Controls.Add(this.TileStateList);
            this.Controls.Add(this.TileGestUser);
            this.Controls.Add(this.TileHousesRef);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTile1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Accueil";
            this.Opacity = 0.9D;
            this.Resizable = false;
            this.Text = "Bienvenue Admin";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Activated += new System.EventHandler(this.Accueil_Activated);
            this.Load += new System.EventHandler(this.Home_Load);
            this.Shown += new System.EventHandler(this.Accueil_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile TileHousesRef;
        private MetroFramework.Controls.MetroTile TileGestUser;
        private MetroFramework.Controls.MetroTile TileStateList;
        private MetroFramework.Controls.MetroTile metroTile5;
        private MetroFramework.Controls.MetroTile metroTile6;
    }
}