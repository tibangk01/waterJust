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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient; // ajout de la reférence à la librairie Mysql


namespace WindowsFormsApp1
{
    public partial class Modifier_Utilisateur : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        //string cs = @"server=localhost;userid=root;password=cruds;database=waterjust";
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;

        // trhead variables :
        private Thread ofGestUser;

        public Modifier_Utilisateur()
        {
            InitializeComponent();
        }


        private void Modifier_Utilisateur_Load(object sender, EventArgs e)
        {
            tbUpdateNomUser.Text = userUpdateInfo.nomUser;
            tbUpdatePrenomUser.Text = userUpdateInfo.prenomUser;
            tbUpdateIdUser.Text = userUpdateInfo.idenifiantUser;
            tbUpdateMdpUser.Text = userUpdateInfo.mdpUser;

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // vérification si le nom et le prenom sont conformes
            String Pattern = @"^[a-z-âçèéêîôû'\s]+$"; // regex pour accepter que les nom africains.

            //verification si tout les tb sont OK : 
            if (String.IsNullOrWhiteSpace(tbUpdateNomUser.Text) || String.IsNullOrWhiteSpace(tbUpdatePrenomUser.Text) || String.IsNullOrWhiteSpace(tbUpdateIdUser.Text) || String.IsNullOrWhiteSpace(tbUpdateMdpUser.Text))
            {
                DialogResult dr = MessageBox.Show("Un ou plusieurs champs sont vides, voulez-vous les complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbUpdateNomUser.Select();
                }
                else
                {
                    // retour à liinterface de gestion des utilisateurs
                    userUpdateInfo.numUser = -1;
                    userUpdateInfo.nomUser = "";
                    userUpdateInfo.prenomUser = "";
                    userUpdateInfo.idenifiantUser = "";
                    userUpdateInfo.mdpUser = "";
                    this.Close();
                }

            }
            else if (!Regex.IsMatch(tbUpdateNomUser.Text, Pattern, RegexOptions.IgnoreCase) || !Regex.IsMatch(tbUpdatePrenomUser.Text, Pattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Le Nom ou/et le prenom doivent être des lettres", "Information Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUpdateNomUser.Select();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Etes-vous sûr de vouloir effectuer l'enregistrment?", "Message De Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // insertion du nouvel utilisateur :
                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "update utilisateur set nomUtilisateur =@a, prenomUtilisateur = @b, identifiantUtilisateur = @c, mdpUtilisateur = @d where numUtilisateur = @e";
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@a", tbUpdateNomUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@b", tbUpdatePrenomUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@c", tbUpdateIdUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@d", tbUpdateMdpUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@e", userUpdateInfo.numUser.ToString());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Les informations ont bien été modifier.");

                        //purge des tbs :
                        tbUpdateNomUser.Text = tbUpdatePrenomUser.Text = tbUpdateIdUser.Text = tbUpdateMdpUser.Text = "";

                        // purge des constantes :
                        userUpdateInfo.numUser = -1;
                        userUpdateInfo.nomUser = "";
                        userUpdateInfo.prenomUser = "";
                        userUpdateInfo.idenifiantUser = "";
                        userUpdateInfo.mdpUser = "";

                        // fermeture du formulaire :
                        this.Close();
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

        private void btnCancelUpdateUser_Click(object sender, EventArgs e)
        {
            tbUpdateNomUser.Text = tbUpdatePrenomUser.Text = tbUpdateIdUser.Text = tbUpdateMdpUser.Text = "";
            tbUpdateNomUser.Select();
        }

        private void Modifier_Utilisateur_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.Close();
            ofGestUser = new Thread(TofGestUser);
            ofGestUser.SetApartmentState(ApartmentState.STA);
            ofGestUser.Start();
        }

        private void TofGestUser()
        {
            Application.Run(new GestionDesUtilisateurs());

        }
    }
}
