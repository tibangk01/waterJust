using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // ajout de la reférence à la librairie Mysql


namespace WindowsFormsApp1
{
    public partial class ReferencementVilla : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        //string cs = @"server=localhost;userid=root;password=cruds;database=waterjust";
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        public ReferencementVilla()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accueil accueil = new Accueil();
            accueil.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Hide();
            NouveauReferencementVilla newRefVilla = new NouveauReferencementVilla();
            newRefVilla.Show();
        }

        private void RefVilla_Load(object sender, EventArgs e)
        {


        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            ModifierVilla modifierVilla = new ModifierVilla();
            modifierVilla.ShowDialog();
        }

        private void ReferencementVilla_Activated(object sender, EventArgs e)
        {
            dgvRefVilla.Rows.Clear();

            // selection et remplissage de la datagrid :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                string stm = "SELECT villa.numVilla as a, villa.nomLocataire as b, villa.prenomLocataire as c, souscompteur.numSousCompteur as d, souscompteur.indexInitial as e from villa INNER join souscompteur on villa.numVilla = souscompteur.numVilla where villa.statutVilla = 1 and souscompteur.statutSousCompteur = 1";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
                // population of the dgv:
                while (rdr.Read())
                {
                    string numVilla = rdr.GetInt32(0).ToString();
                    string nomLoc = rdr.GetString(1);
                    string prenomLoc = rdr.GetString(2);
                    string numSousComp = rdr.GetInt32(3).ToString();
                    string indexInitial = rdr.GetInt32(4).ToString();
                    dgvRefVilla.Rows.Add(
                       new object[]
                       {
                            numVilla,
                            numSousComp,
                            nomLoc,
                            prenomLoc,
                            indexInitial
                       }

                    );
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }

            }

        }

        private void dgvRefVilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 5)
                {
                    DialogResult dr = MessageBox.Show(" Voulez-vous vraiment Modifier cet élément? ", "Confirmation De Modification", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        // sélection et remplissage des tbs de l'interface de modification :
                        try
                        {
                            // sélection des données de la base de données :
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;

                            cmd.CommandText = "SELECT villa.numVilla as a, villa.nomLocataire as b, villa.prenomLocataire as c, souscompteur.numSousCompteur as d, souscompteur.indexInitial as e from villa INNER join souscompteur on villa.numVilla = souscompteur.numVilla where villa.statutVilla = 1 and souscompteur.statutSousCompteur = 1 and villa.numVilla = @a and souscompteur.numSousCompteur = @b";
                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dgvRefVilla.Rows[e.RowIndex].Cells["numVilla"].Value.ToString()));
                            cmd.Parameters.AddWithValue("@b", Convert.ToInt32(dgvRefVilla.Rows[e.RowIndex].Cells["numSousCompt"].Value.ToString()));

                            rdr = cmd.ExecuteReader();

                            if (rdr.Read())
                            {
                                // enregistrement des variables en constantes :
                                refVillaUpdateInfo.numVilla = rdr.GetInt32(0);
                                refVillaUpdateInfo.numSousComp = rdr.GetInt32(3);
                                refVillaUpdateInfo.nomLoc = rdr.GetString(1);
                                refVillaUpdateInfo.prenomLoc = rdr.GetString(2);
                                refVillaUpdateInfo.indexInitial = rdr.GetInt32(4);

                                // affichage de l'interface de connexion avec les tbs remplis des données de la base de données :
                                this.Hide();
                                ModifierVilla modifierVilla = new ModifierVilla();
                                modifierVilla.Show();

                            }

                        }
                        catch (MySqlException exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        finally
                        {
                            if (rdr != null)
                            {
                                rdr.Close();
                            }
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
                    }

                }
                else if (e.ColumnIndex == 6)
                {
                    // desactivation d'une villa: 

                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet élément? ", "Confirmation De Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update villa set statutVilla = 0  where numVilla = @a";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dgvRefVilla.Rows[e.RowIndex].Cells["numVilla"].Value.ToString()));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show(" L'utilisateur a été correctement supprimé.");

                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }

                    }
                }
            }
                  
        }

        private void ReferencementVilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Accueil accueil = new Accueil();
            accueil.ShowDialog();
        }
    }
}
