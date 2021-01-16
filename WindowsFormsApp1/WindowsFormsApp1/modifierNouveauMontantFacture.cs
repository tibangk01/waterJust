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
using System.Text.RegularExpressions; // utilisation des expressions régulières



namespace WindowsFormsApp1
{
    public partial class modifierNouveauMontantFacture : MetroFramework.Forms.MetroForm
    {
        string cs = @dbStr.ChaimeDeConnexion;


        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        // déclaration des variables de threads :
        private Thread ofNewMontantFacture;

        public modifierNouveauMontantFacture()
        {
            InitializeComponent();
        }

        private void modifierNouveauMontantFacture_Load(object sender, EventArgs e)
        {
            // on charge les informations dans le tb :
            tbModifMontantFacture.Text = montantUpdateInfo.montantFacture;
            montantUpdateInfo.montantFacture = "";


        }

        private void btnResetMontantFacture_Click(object sender, EventArgs e)
        {
            tbModifMontantFacture.Text = "";
            tbModifMontantFacture.Select();
            
        }

        private void btnModifMontantFacture_Click(object sender, EventArgs e)
        {
            String Pattern = @"^\-?[0-9]+$"; // regex pour accepter que des valeurs numériques 

            if (String.IsNullOrWhiteSpace(tbModifMontantFacture.Text))
            {
                // msg erreur et demande de confirmation
                DialogResult dr = MessageBox.Show("Le Champs est vide, voulez-vous le complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbModifMontantFacture.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbModifMontantFacture.Text = "";
                    this.Close();
                }

            }
            else if (!Regex.IsMatch(tbModifMontantFacture.Text, Pattern, RegexOptions.IgnoreCase))
            {
                // ce n'est pas un numérique donc msg : le montant doit être un numérique.
                DialogResult dr = MessageBox.Show("Le montant doit être numérique valide, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbModifMontantFacture.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbModifMontantFacture.Text = "";
                    this.Close();
                }
            }
            else if (Int32.Parse(tbModifMontantFacture.Text) <= 850)
            {
                DialogResult dr = MessageBox.Show("Le montant doit être supérieur à 850, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbModifMontantFacture.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbModifMontantFacture.Text = "";
                    this.Close();
                }
            }
            else
            {
                // tout est bon pour enregistrer dans la base de données :

                DialogResult dr = MessageBox.Show("Etes-vous sûr de vouloir modifier le montant? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // modification :
                    // initialisation des variables :
                    int trouver = 0;
                    int numFacture = -1;

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

                    if (trouver != 0)
                    {
                        int statutEnregMontant = -1;

                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;

                            cmd.CommandText = "select numFacture, statutEnregMontant from facture order by numFacture desc LIMIT 1 OFFSET 0";
                            rdr = cmd.ExecuteReader();

                            if (rdr.Read())
                            {
                                numFacture = rdr.GetInt32(0);
                                statutEnregMontant = rdr.GetInt32(1);
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

                        if (statutEnregMontant == 1)
                        {
                            // on peut faire la mise à jour :
                            try
                            {
                                conn = new MySqlConnection(cs);
                                conn.Open();

                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = conn;
                                cmd.CommandText = "update facture set montantFacture =@a  where numFacture = @b";
                                cmd.Prepare();

                                cmd.Parameters.AddWithValue("@a", tbModifMontantFacture.Text);
                                cmd.Parameters.AddWithValue("@b", numFacture);
                                cmd.ExecuteNonQuery();

                                // msg succès d'enregistrement :
                                tbModifMontantFacture.Text = "";
                                //  this.Close();
                                DialogResult dr2 = MessageBox.Show("Le montant a été bien modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (dr2 == DialogResult.OK)
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
                else
                {
                    // fermeture du formulaire :
                    tbModifMontantFacture.Text = "";
                    this.Close();
                }
                
            }
        }

        private void modifierNouveauMontantFacture_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofNewMontantFacture = new Thread(TofNewMontantFacture);
            ofNewMontantFacture.SetApartmentState(ApartmentState.STA);
            ofNewMontantFacture.Start();
        }

        private void TofNewMontantFacture()
        {
            Application.Run(new nouveauMontantFacture());

        }
    }
}
