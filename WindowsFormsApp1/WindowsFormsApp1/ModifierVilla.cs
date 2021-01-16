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
using System.Text.RegularExpressions; // librairie pour utiliser les regex.
using MySql.Data.MySqlClient; // ajout de la reférence à la librairie Mysql

namespace WindowsFormsApp1
{
    public partial class ModifierVilla : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        string cs = @dbStr.ChaimeDeConnexion;
        MySqlConnection conn = null;
       // MySqlDataReader rdr = null;

        public ModifierVilla()
        {
            InitializeComponent();
        }

        private void ModifierVilla_Load(object sender, EventArgs e)
        {
            tbUpdateNomLoc.Text = refVillaUpdateInfo.nomLoc;
            tbUpdatePrenomLoc.Text = refVillaUpdateInfo.prenomLoc;
            tbUpdateIndexInitial.Text = refVillaUpdateInfo.indexInitial.ToString();
        }

        private void btnCancelUpdateRefVilla_Click(object sender, EventArgs e)
        {
            tbUpdateNomLoc.Text = tbUpdatePrenomLoc.Text = tbUpdateIndexInitial.Text = "";
        }

        private void btnUpdateRefVilla_Click(object sender, EventArgs e)
        {
            // vérification si le nom et le prenom sont conformes
            String Pattern = @"^[a-z-âçèéêîôû'\s]+$"; // regex pour accepter que les nom africains.
            String Pattern2 = @"^[0-9]+$"; // regex pour accepter que les numériques

            // verification si tous les tbs sont bon :
            if (String.IsNullOrWhiteSpace(tbUpdateNomLoc.Text) || String.IsNullOrWhiteSpace(tbUpdatePrenomLoc.Text) || String.IsNullOrWhiteSpace(tbUpdateIndexInitial.Text))
            {
                DialogResult dr = MessageBox.Show("Un ou plusieurs champs sont vides, voulez-vous les complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    tbUpdateNomLoc.Select();
                }
                else
                {
                    tbUpdateNomLoc.Text = tbUpdatePrenomLoc.Text = tbUpdateIndexInitial.Text = "";
                    this.Close();
                }

            }
            else if (!Regex.IsMatch(tbUpdateNomLoc.Text, Pattern, RegexOptions.IgnoreCase) || !Regex.IsMatch(tbUpdatePrenomLoc.Text, Pattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Le Nom et/ou le prenom doivent être alphabétique", "Information Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUpdateNomLoc.Select();
            }
            else if (!Regex.IsMatch(tbUpdateIndexInitial.Text, Pattern2, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("La valeur initiale du sous compteur doit être numérique", "Information Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUpdateIndexInitial.Select();

            }
            else
            {
                // insertion dans la table villa, selection du numero du dernier enregistrement, insertion des autres informations dans la table sous-compteur :

                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    //insertion du nom et prenom du locataire dans la table villa :
                    cmd.CommandText = "update villa set nomLocataire = @a, prenomLocataire = @b where numVilla = @c";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@a", tbUpdateNomLoc.Text.ToString());
                    cmd.Parameters.AddWithValue("@b", tbUpdatePrenomLoc.Text.ToString());
                    cmd.Parameters.AddWithValue("@c", refVillaUpdateInfo.numVilla);
                    cmd.ExecuteNonQuery();

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


                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    //insertion des autres informations dans la table sous-compteur :
                    cmd.CommandText = "update souscompteur set indexInitial = @a where numSousCompteur = @b";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@a", tbUpdateIndexInitial.Text.ToString());
                    cmd.Parameters.AddWithValue("@b", refVillaUpdateInfo.numSousComp);
                    cmd.ExecuteNonQuery();

                    // reinitialisation des constantes :
                    refVillaUpdateInfo.numVilla = 0;
                    refVillaUpdateInfo.numVilla = 0;
                    refVillaUpdateInfo.nomLoc = refVillaUpdateInfo.prenomLoc = "";
                    refVillaUpdateInfo.indexInitial = 0;

                    // message d'insertion reussi :

                    DialogResult dr2 = MessageBox.Show("Les informations ont été bien modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dr2 == DialogResult.OK)
                    {
                        this.Close();
                    }
                    //MessageBox.Show("Les Informations ont été bien Modifiées");
                    tbUpdateNomLoc.Text = tbUpdatePrenomLoc.Text = tbUpdateIndexInitial.Text = "";
                    //this.Close();
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

        private Thread ofRefVilla;
        private void ModifierVilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofRefVilla = new Thread(TofRefVilla);
            ofRefVilla.SetApartmentState(ApartmentState.STA);
            ofRefVilla.Start();
        }

        private void TofRefVilla()
        {
            Application.Run(new ReferencementVilla());

        }
    }
}
