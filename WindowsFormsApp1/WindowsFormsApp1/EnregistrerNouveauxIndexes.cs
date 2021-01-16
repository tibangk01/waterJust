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
    public partial class EnregistrerNouveauxIndexes : MetroFramework.Forms.MetroForm
    {
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        // déclaration des variables de thread :
        private Thread oMainForm;

        public EnregistrerNouveauxIndexes()
        {
            InitializeComponent();
        }

       

        private void EnregistrerNouveauxIndexes_Activated(object sender, EventArgs e)
        {
            
            // séléction et population du cb :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "select concat('Villa N°', souscompteur.numVilla, ' - Mr ', villa.nomLocataire ), traiter.numSousCompteur from souscompteur inner join villa on souscompteur.numVilla = villa.numVilla inner join traiter on traiter.numSousCompteur = souscompteur.numSousCompteur where traiter.statutTraitement = 0 order by villa.numVilla";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
                List<cbNouvelIndex> list = new List<cbNouvelIndex>();

                while (rdr.Read())
                {
                    list.Add(new cbNouvelIndex() { libCbNouvelIndex = rdr.GetString(0), numSousCompteur = rdr.GetInt32(1)});
                }
                cbAddNouveauIndex.DataSource = list;
                cbAddNouveauIndex.ValueMember = "numSousCompteur";
                cbAddNouveauIndex.DisplayMember = "libCbNouvelIndex";
            }
            catch (MySqlException ex)
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

            if (numFacture > 0)
            {
                //selection des éléments souhaités :
                try
                {

                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT concat('Villa N°', villa.numVilla), traiter.nouvelIndex, traiter.numFacture, traiter.numSousCompteur from souscompteur INNER join villa ON souscompteur.numVilla = villa.numVilla INNER JOIN traiter on traiter.numSousCompteur = souscompteur.numSousCompteur where traiter.numFacture = @a";
                    cmd.Parameters.AddWithValue("@a", numFacture);
                  
                    rdr = cmd.ExecuteReader();

                    dgvNouvelIndexes.Rows.Clear();
                    while (rdr.Read())
                    {
                        if (rdr.GetInt32(1) != 0)
                        {
                            // polulation du dgv :
                            string libVilla = rdr.GetString(0);
                            int nouvelIndex = rdr.GetInt32(1);
                            int numFact = rdr.GetInt32(2);
                            int numSC = rdr.GetInt32(3);

                            dgvNouvelIndexes.Rows.Add(
                               new object[]
                               {
                                   libVilla,
                                   nouvelIndex,
                                   numFact,
                                   numSC
                               }

                            );
                        }
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

                // griser tous les tbs si tous les sous compteurs actifs sont dejas traité :
                bool scDejaTraite = true;
                // séléction de tous les statutTraitement pour cette facture :
                try
                {

                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT statutTraitement FROM traiter where numFacture = @a";
                    cmd.Parameters.AddWithValue("@a", numFacture);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        if(rdr.GetInt32(0) == 0)
                        {
                            scDejaTraite = false;
                            break;
                        }
                        
                    }

                    if (scDejaTraite == true)
                    {
                        tbNouvelIndex.Enabled = false;
                        dtNouvelIndex.Enabled = false;
                        cbAddNouveauIndex.Enabled = false;
                        btnEnregNouvelIndex.Enabled = false;

                        //// maj de la facture en tant que facture traitée :
                        //try
                        //{
                        //    conn = new MySqlConnection(cs);
                        //    conn.Open();

                        //    MySqlCommand cmd2 = new MySqlCommand();
                        //    cmd2.Connection = conn;
                        //    cmd2.CommandText = "update facture set statutTraitementFacture = @b where numFacture = @a";
                        //    cmd2.Prepare();

                        //    cmd2.Parameters.AddWithValue("@a", numFacture);
                        //    cmd2.Parameters.AddWithValue("@b", 1);
                        //    cmd2.ExecuteNonQuery();
                            
                        //}
                        //catch (Exception ex)
                        //{
                        //    //MessageBox.Show(ex.Message);
                        //}
                        //finally
                        //{
                        //    if (conn != null)
                        //    {
                        //        conn.Close();
                        //    }
                        //}
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
        }

        private void btnEnregNouvelIndex_Click(object sender, EventArgs e)
        {
            // enregistrement d'un nouvel index :
            String Pattern = @"^\-?[0-9]+$"; // regex pour accepter que des valeurs numériques 

            if (String.IsNullOrWhiteSpace(tbNouvelIndex.Text))
            {
                // msg erreur et demande de confirmation
                DialogResult dr = MessageBox.Show("Le Champs est vide, voulez-vous le complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbNouvelIndex.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbNouvelIndex.Text = "";
                    this.Close();
                }

            }
            else if (!Regex.IsMatch(tbNouvelIndex.Text, Pattern, RegexOptions.IgnoreCase))
            {
                // ce n'est pas un numérique donc msg : le montant doit être un numérique.
                DialogResult dr = MessageBox.Show("Le nouvel index doit être numérique valide, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbNouvelIndex.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbNouvelIndex.Text = "";
                    this.Close();
                }
            }
            else if (Int32.Parse(tbNouvelIndex.Text) <= 0)
            {
                DialogResult dr = MessageBox.Show("Le nouvel index doit être supérieur à 0, voulez-vous les rectifier? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbNouvelIndex.Select();
                }
                else
                {
                    // on ferme le formulaire d'enregistreùent du montant de la facture:
                    tbNouvelIndex.Text = "";
                    this.Close();
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
                numSC = cbAddNouveauIndex.SelectedValue.ToString();
                
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

                if (ancienIndex > Int32.Parse(tbNouvelIndex.Text))
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
                        cmd.CommandText = "update traiter set nouvelIndex =@a, statutTraitement = @b, nouvelleDatePassage = @e  where numFacture = @c and numSousCompteur = @d";
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@a", tbNouvelIndex.Text);
                        cmd.Parameters.AddWithValue("@b", 0);
                        cmd.Parameters.AddWithValue("@c", numFacture);
                        cmd.Parameters.AddWithValue("@d", numSC );
                        cmd.Parameters.AddWithValue("@e", dtNouvelIndex.Value.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();


                        MessageBox.Show("L'enregistrement a été correctement effectuée.");
                        tbNouvelIndex.Text = "";

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

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void EnregistrerNouveauxIndexes_Load(object sender, EventArgs e)
        {

        }

        private void EnregistrerNouveauxIndexes_FormClosing(object sender, FormClosingEventArgs e)
        {
            oMainForm = new Thread(ToMainForm);
            oMainForm.SetApartmentState(ApartmentState.STA);
            oMainForm.Start();
        }

        private void ToMainForm()
        {
            Application.Run(new Accueil());
        }

        private void dgvNouvelIndexes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {
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
                        montantUpdateInfo.numSC = dgvNouvelIndexes.Rows[e.RowIndex].Cells[3].Value.ToString();
                        montantUpdateInfo.nouvelIndex = dgvNouvelIndexes.Rows[e.RowIndex].Cells[1].Value.ToString();
                        montantUpdateInfo.villa = dgvNouvelIndexes.Rows[e.RowIndex].Cells[0].Value.ToString();
                        //1. fermeture de la fenetre enreg et ouverture de la fenêtre modif :
                        this.Hide();
                        modifierNouvelIndex newModif = new modifierNouvelIndex();
                        newModif.Show();



                    }
                    else if (dr == DialogResult.No)
                    {
                        // on ferme la boite de dialogue :
                        this.Close();

                    }

                }

            }
        }
    }
}
