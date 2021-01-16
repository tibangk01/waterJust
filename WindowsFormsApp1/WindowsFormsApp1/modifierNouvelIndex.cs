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
    public partial class modifierNouvelIndex : MetroFramework.Forms.MetroForm
    {
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        public modifierNouvelIndex()
        {
            InitializeComponent();
        }

        private void modifierNouvelIndex_Load(object sender, EventArgs e)
        {
            if (montantUpdateInfo.villa != "")
            {
                lblInfoLoc.Text = montantUpdateInfo.villa+" Mr ...";
                tbModifIndex.Text = montantUpdateInfo.nouvelIndex;
                montantUpdateInfo.villa = "";
                montantUpdateInfo.nouvelIndex = "";
            }

        }

        private void btnResetIndex_Click(object sender, EventArgs e)
        {
            tbModifIndex.Text = "";
        }

        private void btnModifIndex_Click(object sender, EventArgs e)
        {
            String Pattern = @"^\-?[0-9]+$"; // regex pour accepter que des valeurs numériques 

            if (String.IsNullOrWhiteSpace(tbModifIndex.Text))
            {
                // msg erreur et demande de confirmation
                DialogResult dr = MessageBox.Show("Le Champs est vide, voulez-vous le complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbModifIndex.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbModifIndex.Text = "";
                    this.Hide();
                    EnregistrerNouveauxIndexes a = new EnregistrerNouveauxIndexes();
                    a.Show();
                }

            }
            else if (!Regex.IsMatch(tbModifIndex.Text, Pattern, RegexOptions.IgnoreCase))
            {
                // ce n'est pas un numérique donc msg : le montant doit être un numérique.
                DialogResult dr = MessageBox.Show("Le nouvel index doit être numérique valide, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.OK)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbModifIndex.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbModifIndex.Text = "";
                    this.Hide();
                    EnregistrerNouveauxIndexes a = new EnregistrerNouveauxIndexes();
                    a.Show();
                }
            }
            else if (Int32.Parse(tbModifIndex.Text) <= 0)
            {
                DialogResult dr = MessageBox.Show("Le nouvel index doit être supérieur à 0, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbModifIndex.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbModifIndex.Text = "";
                    this.Hide();
                    EnregistrerNouveauxIndexes a = new EnregistrerNouveauxIndexes();
                    a.Show();
                }
            }
            else
            {
                // on va vérifier que le nouvel index est supérieur à l'ancien index ;

                /*
                 * 1. sélection de l'ancien index correspondant numéro du sousCompteur correspondant :
                 * 2. comparaison avec tbNouvelIndex
                 *  a. si plus petit alors msg erreur
                 *  b. sinon on fait l'enregistrement.
                 */

                // 1. sélection de l'ancien index correspondant au sous-compteur correspondant :

                // initialisation des variables :
                int trouver = 0;
                int numFacture = -1;
                String numSC = "";
                int ancienIndex = -1;

                // reception du numéro du sous compteur :
                numSC = montantUpdateInfo.numSC;

                // test si une facture existe au moins ou non :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    // verif si le gérant existe :
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select count(numFacture) from facture";
                    cmd.Prepare();

                    trouver = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (MySqlException ex)
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

                // sélection du numéro de la facture si au moins une existe :
                if (trouver != 0)
                {

                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;

                        cmd.CommandText = "select numFacture from facture order by numFacture desc LIMIT 1 OFFSET 0";
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            numFacture = rdr.GetInt32(0);
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

                // sélection de l'ancien index correspondant à la dernière facture et au numéro du sous compteur choisi :
                try
                {

                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT ancienIndex from traiter where numFacture = @a and numSousCompteur = @b";
                    cmd.Parameters.AddWithValue("@a", numFacture);
                    cmd.Parameters.AddWithValue("@b", numSC);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ancienIndex = rdr.GetInt32(0);
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

                // comparaison et affichage de message d'erreur :

                if (ancienIndex > Int32.Parse(tbModifIndex.Text))
                {
                    // message d'erreur
                    MessageBox.Show("Erreur! L'indexe entrée est erronée ! ", "Information Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // insertion dans la table traiter du nouvel index et maj de statuttraitement à true :
                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "update traiter set nouvelIndex =@a where numFacture = @c and numSousCompteur = @d";
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@a", tbModifIndex.Text);
                        cmd.Parameters.AddWithValue("@c", numFacture);
                        cmd.Parameters.AddWithValue("@d", numSC);
                        cmd.ExecuteNonQuery();

                        DialogResult dr = MessageBox.Show("L'index a été bien modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            this.Close();
                        }

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

        private Thread ofNexIndex;

        private void modifierNouvelIndex_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofNexIndex = new Thread(TofNexIndex);
            ofNexIndex.SetApartmentState(ApartmentState.STA);
            ofNexIndex.Start();
        }

        private void TofNexIndex()
        {
            Application.Run(new EnregistrerNouveauxIndexes());

        }
    }
}