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
    public partial class nouveauMontantFacture : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        //string cs = @"server=localhost;userid=root;password=cruds;database=waterjust";
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        // déclaration des threads :
        private Thread oMainForm;

        public nouveauMontantFacture()
        {
            InitializeComponent();
        }

        private void nouveauMontantFacture_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAjoutMontantFacture_Click(object sender, EventArgs e)
        {
            String Pattern = @"^\-?[0-9]+$"; // regex pour accepter que des valeurs numériques 

            if (String.IsNullOrWhiteSpace(tbMontantFacture.Text))
            {
                // msg erreur et demande de confirmation
                DialogResult dr = MessageBox.Show("Le Champs est vide, voulez-vous le complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbMontantFacture.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbMontantFacture.Text = "";
                    this.Close();
                }

            }else if (!Regex.IsMatch(tbMontantFacture.Text, Pattern, RegexOptions.IgnoreCase))
            {
                // ce n'est pas un numérique donc msg : le montant doit être un numérique.
                DialogResult dr = MessageBox.Show("Le montant doit être numérique valide, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbMontantFacture.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbMontantFacture.Text = "";
                    this.Close();
                }
            }else if (Int32.Parse(tbMontantFacture.Text) <= 850)
            {
                DialogResult dr = MessageBox.Show("Le montant doit être supérieur à 850, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbMontantFacture.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbMontantFacture.Text = "";
                    this.Close();
                }
            }
            else
            {
                // tout est bon pour enregistrer dans la base de données :

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
                    MessageBox.Show(ex.Message);
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

                        MessageBox.Show(ex.Message);

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

                    if (statutEnregMontant == 0)
                    {
                        // on peut faire la mise à jour :
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update facture set montantFacture =@a, statutEnregMontant = @b  where numFacture = @c";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", tbMontantFacture.Text);
                            cmd.Parameters.AddWithValue("@b", 1);
                            cmd.Parameters.AddWithValue("@c", numFacture);
                            cmd.ExecuteNonQuery();

                            // msg succès d'enregistrement :
                            DialogResult dr2 = MessageBox.Show("Le Montant a été bien enrégistrer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr2 == DialogResult.OK)
                            {
                                this.Close();
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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

        private void dgvNouveauMontant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // click du bouton :
            if (e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 2)
                {
                    // modification :

                    DialogResult dr = MessageBox.Show(" Voulez-vous vraiment Modifier cet élément? ", "Confirmation De Modification", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        // si on veut vraiment modifer l élément alors : 
                        /*
                         * 1. on ferme la fenetre enregistrer
                         * 2. on ouvre la fenetre modifer
                         * 3. on charge les informations dans cette fanêtre
                         * 4. en cas de modif : 
                         *  a. on ferme la fenetre modif et on rouvre la fenêtre enreg
                         *  b. sinon on ferme simplement la fenêtre modif.
                         */
                        // 0. enregistrement du nunérode la facture en constante :
                        montantUpdateInfo.numFacture = dgvNouveauMontant.Rows[e.RowIndex].Cells[0].Value.ToString();
                        montantUpdateInfo.montantFacture = dgvNouveauMontant.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //1. fermeture de la fenetre enreg et ouverture de la fenêtre modif :
                        this.Hide();
                        modifierNouveauMontantFacture newModif = new modifierNouveauMontantFacture();
                        newModif.Show();

                        
                        
                    }
                    else if (dr == DialogResult.No)
                    {
                        // on ferme la boite de dialogue :
                        this.Close();

                    }


                }
                // fin du if

            }


        }

        private void nouveauMontantFacture_Activated(object sender, EventArgs e)
        {
            // disable tb si la dernière facture est déja traitée
            try
            {
                int statutEnregMontant = -1;
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select statutEnregMontant from facture order by numFacture desc LIMIT 1 OFFSET 0";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    statutEnregMontant = rdr.GetInt32(0);
                }

                if (statutEnregMontant == 1)
                {
                    tbMontantFacture.Enabled = false;
                    btnAjoutMontantFacture.Enabled = false;
                    btnAnnulerMontantFacture.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

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

            // population du datagridview :
            dgvNouveauMontant.Rows.Clear();
            
            //sélection du montant le la facture :
            int montantFacture = 0;
            try
            {
                
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select montantFacture from facture order by numFacture desc LIMIT 1 OFFSET 0";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    montantFacture = rdr.GetInt32(0);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

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

            // si le montant est maintenant different de 0 alors on popule le dgv :

            if (montantFacture != 0)
            {
                // sélection et remplissage :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    string stm = "SELECT numFacture, montantFacture from facture order by numFacture desc limit 1 offset 0";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    rdr = cmd.ExecuteReader();
                    // population of the dgv:
                    if (rdr.Read())
                    {
                        string numFact = rdr.GetInt32(0).ToString();
                        string montantFact = rdr.GetString(1);

                        dgvNouveauMontant.Rows.Add(
                           new object[]
                           {
                            numFact,
                            montantFact,
                           }

                        );
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private void nouveauMontantFacture_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close();
            oMainForm = new Thread(ToMainForm);
            oMainForm.SetApartmentState(ApartmentState.STA);
            oMainForm.Start();
        }

        private void ToMainForm()
        {
            Application.Run(new Accueil());
        }
    }
}
