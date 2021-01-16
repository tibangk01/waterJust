using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // ajout de la reférence à la librairie Mysql


namespace WindowsFormsApp1
{
    public partial class GestionDesUtilisateurs : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        //string cs = @"server=localhost;userid=root;password=cruds;database=waterjust";
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;


        // variables de thread :
        private Thread oMainForm;
  
        public GestionDesUtilisateurs()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
            Accueil a = new Accueil();
            a.Show();
            //oMainForm2 = new Thread(ToMainForm2);
            //oMainForm2.SetApartmentState(ApartmentState.STA);
            //oMainForm2.Start();
        }

        //private void ToMainForm2()
        //{
        //    Application.Run(new Accueil());

        //}

    



        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void GestionDesUtilisateurs_Activated(object sender, EventArgs e)
        {
            dgvGestUser.Rows.Clear();

            // selection et remplissage de la datagrid :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                string stm = "SELECT * FROM utilisateur where statutUtilisateur = 1";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
                // population of the dgv:
                while (rdr.Read())
                {
                    string numUser = rdr.GetInt32(0).ToString();
                    string nomUser = rdr.GetString(1);
                    string prenomUser = rdr.GetString(2);
                    string identifiantUser = rdr.GetString(3);
                    string mdpUser = rdr.GetString(4);
                    dgvGestUser.Rows.Add(
                       new object[]
                       {
                            numUser,
                            nomUser,
                            prenomUser,
                            identifiantUser,
                            mdpUser,
                            "Modifier",
                            "Supprimer"
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

        private void dgvGestUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 5)
                {
                    // modification :

                    DialogResult dr = MessageBox.Show(" Voulez-vous vraiment Modifier cet élément? ", "Confirmation De Modification", MessageBoxButtons.YesNo);

                    if ( dr == DialogResult.Yes)
                    {
                        // sélection et remplissage des tbs de l'interface de modification :
                        try
                        {
                            // sélection des données de la base de données :
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;                   

                            cmd.CommandText = "select numUtilisateur, nomUtilisateur, prenomUtilisateur, identifiantUtilisateur, mdpUtilisateur from utilisateur where numUtilisateur = @a";
                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dgvGestUser.Rows[e.RowIndex].Cells["numUser"].Value.ToString()));

                            rdr = cmd.ExecuteReader();

                            if (rdr.Read())
                            {
                                // enregistrement des variables en constantes :
                                userUpdateInfo.numUser = rdr.GetInt32(0);
                                userUpdateInfo.nomUser = rdr.GetString(1);
                                userUpdateInfo.prenomUser = rdr.GetString(2);
                                userUpdateInfo.idenifiantUser = rdr.GetString(3);
                                userUpdateInfo.mdpUser = rdr.GetString(4);

                                // affichage de l'interface de connexion avec les tbs remplis des données de la base de données :
                                this.Hide();
                                Modifier_Utilisateur modifierUser = new Modifier_Utilisateur();
                                modifierUser.Show();

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
                       
                        

                    }else if ( dr == DialogResult.No)
                    {

                    }


                }
                else if(e.ColumnIndex == 6)
                {
                    // desactivation d'un utilisateur : 

                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet élément? ", "Confirmation De Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update utilisateur set statutUtilisateur = 0  where numUtilisateur = @a";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(dgvGestUser.Rows[e.RowIndex].Cells["numUser"].Value.ToString()));
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

        private void ToMainFormX()
        {
            Application.Run(new Modifier_Utilisateur());

        }

        private void GestionDesUtilisateurs_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
            oMainForm = new Thread(ToMainForm);
            oMainForm.SetApartmentState(ApartmentState.STA);
            oMainForm.Start();
        }

        private void ToMainForm()
        {
            //Environment.Exit(1);
            Application.Run(new Accueil());
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterUtilisateur a = new AjouterUtilisateur();
            a.Show();

        }
    }
}
