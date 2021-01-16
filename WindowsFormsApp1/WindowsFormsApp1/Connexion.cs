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
    public partial class Connexion : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        //string cs = @"server=localhost;userid=root;password=cruds;database=waterjust";
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;


        public Connexion()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // verification si tout les tb sont bons :
            if (String.IsNullOrWhiteSpace(tbIdConn.Text) || String.IsNullOrWhiteSpace(tbMdpConn.Text))
            {
                DialogResult dr = MessageBox.Show("Un ou plusieurs champs sont vides, voulez-vous les complèter?", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbIdConn.Select();
                }
                else
                {
                    // retour à liinterface de gestion des utilisateurs
                    tbIdConn.Text = tbMdpConn.Text = "";
                    this.Close();
                }
            }
            else
            {
                // tester la connection :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from utilisateur where identifiantUtilisateur = @a and mdpUtilisateur = @b and statutUtilisateur = 1";
                    cmd.Parameters.AddWithValue("@a", tbIdConn.Text.ToString());
                    cmd.Parameters.AddWithValue("@b", tbMdpConn.Text.ToString());
                    

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        
                        //enregistrement des constantes de Login
                        userLogInfo.numUser = rdr.GetInt32(0);
                        userLogInfo.roleUser = rdr.GetInt32(6); 
                        
                        this.Hide();
                        Accueil accueil = new Accueil();
                        accueil.ShowDialog();

                    }
                    else
                    {
                        // Message erreur, message continuer :
                        DialogResult dr = MessageBox.Show("Erreur De Connexion. Voulez-vous reéessayer ?", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                        if (dr == DialogResult.Yes)
                        {
                            
                            tbIdConn.Select();

                        }else if(dr == DialogResult.No)
                        {

                            this.Close();

                        }
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

        private void Connexion_Load(object sender, EventArgs e)
        {

        }
    }
}
