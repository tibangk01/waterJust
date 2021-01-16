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
    public partial class Accueil : MetroFramework.Forms.MetroForm
    {
        // objets de la base de données :
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        private Thread ofNewMontant;
        private Thread ofNewIndexs;
        private Thread ofPrintMonthBill;
        private Thread ofGestUsers;
        private Thread ofRefVilla;
        private Thread ofStateLists;

        public Accueil()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // inititalmisation des variables : 
            int aucuneFactureExiste = -1;
            int villasEnreg = -1;
            int numNewFacture = 1;
            List<tabNewInexNumSc> elementsTab1 = new List<tabNewInexNumSc>();
            List<sousCompteursActifs> elementsTab2 = new List<sousCompteursActifs>();



            if (userLogInfo.roleUser == 1)
            {
                TileGestUser.Visible = false;
                TileStateList.Visible = false;
                TileHousesRef.Visible = false;

            }

            // si au démarage aucune facture n'existe générer la première facture :
            // test si aucune facture n'existe :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                // verif si le g�rant existe :
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(numFacture) from facture";
                cmd.Prepare();

                aucuneFactureExiste = Convert.ToInt32(cmd.ExecuteScalar());
                
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

            // opérations si aucune facture n'existe :

            if (aucuneFactureExiste == 0)
            {
                    // générer la nouvelle fature : 
                    try
                    {
                        // insertion du lib�l� du mois :
                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;

                        //insertion des autres informations dans la table sous-compteur :
                        cmd.CommandText = "insert into facture(montantFacture) values(@a)";
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@a", 0);

                        cmd.ExecuteNonQuery();

                       // MessageBox.Show(" J'ai bien insérer la facture .....");
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

                    

                    // séléction des sous Compteurs actifs à la date de la nouvelle facture :
                    try
                    {

                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;

                        cmd.CommandText = "SELECT numSousCompteur, indexInitial, datePassgeInitial FROM souscompteur where statutSousCompteur = @a";
                        cmd.Parameters.AddWithValue("@a", 1);

                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            elementsTab1.Add(new tabNewInexNumSc
                            {
                                numSousCompteur = rdr.GetInt32(0),
                                nouvelIndex = rdr.GetInt32(1),
                                datePassgeInitial = rdr.GetString(2)
                            });

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


                // insertion dans la base de donn�es :
                foreach (tabNewInexNumSc unElem in elementsTab1)
                    {
                        // Pr�paration des variables :
                        int ancienIndex = unElem.nouvelIndex;
                        int numFact = 1;
                        int numUser = userLogInfo.numUser;
                        int numSC = unElem.numSousCompteur;
                        String datePassageInitial = unElem.datePassgeInitial;

                        // insertion dans la base de donn�es :
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;

                            cmd.CommandText = "insert into traiter(numFacture, numSousCompteur, numUtilisateur, ancienIndex, ancienneDatePassage) values(@a, @b, @c, @d, @e)";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", numFact);
                            cmd.Parameters.AddWithValue("@b", numSC);
                            cmd.Parameters.AddWithValue("@c", numUser);
                            cmd.Parameters.AddWithValue("@d", ancienIndex);
                            cmd.Parameters.AddWithValue("@e", datePassageInitial.ToString().Substring(6, 4) + '-' + datePassageInitial.ToString().Substring(3, 2) + '-' + datePassageInitial.ToString().Substring(0, 2));

                            cmd.ExecuteNonQuery();

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
            else
            {

            }



            // on vérifie si on a au moins deux villas enregistrées. si non on grise toutes les tiles sauf enregistrer villa :
            // test :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                // verif si le g�rant existe :
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(numVilla) from villa";
                cmd.Prepare();

                villasEnreg = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show(villasEnreg.ToString());
                if (villasEnreg < 2)
                {
                    metroTile1.Enabled = false;
                    metroTile2.Enabled = false;
                    metroTile3.Enabled = false;
                    metroTile5.Enabled = false;
                    metroTile6.Enabled = false;
                    TileStateList.Enabled = false;
                }
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

            // grise l'enregistrement des index tant que le montant de la facture n'est pas enr.
            //test si le montant de la dernière facture est enregistrée ...
            bool montantDerniereFacureEnreg = true;
            int numLastBill = -1;
            // test :
            // séléction du numéro de la derniere fact : 
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select max(numFacture) from facture";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    numLastBill = rdr.GetInt32(0);
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
            // sélection du statut d'enreg du montant et reformatage du booléen :
            try
            {

                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT statutEnregMontant FROM facture where numFacture = @a";
                cmd.Parameters.AddWithValue("@a", numLastBill);

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    if (rdr.GetInt32(0) == 0)
                    {
                        montantDerniereFacureEnreg = false;
                    }
                    

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
            if (montantDerniereFacureEnreg == false)
            {
                metroTile2.Enabled = false;
            }


        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            this.Close();
            ofRefVilla = new Thread(TofRefVilla);
            ofRefVilla.SetApartmentState(ApartmentState.STA);
            ofRefVilla.Start();
        }

        private void TofRefVilla()
        {
            Application.Run(new ReferencementVilla());
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            this.Close();
            ofGestUsers = new Thread(TofGestUsers);
            ofGestUsers.SetApartmentState(ApartmentState.STA);
            ofGestUsers.Start();
        }

        private void TofGestUsers()
        {
            Application.Run(new GestionDesUtilisateurs());

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
            ofNewMontant = new Thread(TofNewMontant);
            ofNewMontant.SetApartmentState(ApartmentState.STA);
            ofNewMontant.Start();

            //this.Hide();
            //nouveauMontantFacture unMontant = new nouveauMontantFacture();
            //unMontant.ShowDialog();
           
        }

        private void TofNewMontant()
        {
            Application.Run(new nouveauMontantFacture());
        }


        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Close();
            ofNewIndexs = new Thread(TofNewIndexs);
            ofNewIndexs.SetApartmentState(ApartmentState.STA);
            ofNewIndexs.Start();

        }

        private void TofNewIndexs()
        {
            Application.Run(new EnregistrerNouveauxIndexes());

            //throw new NotImplementedException();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            this.Close();
            ofStateLists = new Thread(TofStateLists);
            ofStateLists.SetApartmentState(ApartmentState.STA);
            ofStateLists.Start();
        }

        private void TofStateLists()
        {
            Application.Run(new ListeDesEtats());
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            this.Close();
            ofPrintMonthBill = new Thread(TofPrintMonthBill);
            ofPrintMonthBill.SetApartmentState(ApartmentState.STA);
            ofPrintMonthBill.Start();
        }

        private void TofPrintMonthBill()
        {
            Application.Run(new impressionFacture());

        }

        private void Accueil_Activated(object sender, EventArgs e)
        {

        }

        private void Accueil_Shown(object sender, EventArgs e)
        {

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Voulez-vous vraiment Quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private Thread ofVB;

        private void metroTile5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            ofVB = new Thread(TofVB);
            ofVB.SetApartmentState(ApartmentState.STA);
            ofVB.Start();
        }

        private void TofVB()
        {
            Application.Run(new validationFacture());
        }

        private Thread ofTNPayment;

        private void metroTile6_Click_1(object sender, EventArgs e)
        {
            this.Close();
            ofTNPayment = new Thread(TofTNPayment);
            ofTNPayment.SetApartmentState(ApartmentState.STA);
            ofTNPayment.Start();

        }

        private void TofTNPayment()
        {
            Application.Run(new traiterImpayes());
        }
    }
}
