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
    public partial class Impression : MetroFramework.Forms.MetroForm
    {
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        public Impression()
        {
            InitializeComponent();
        }

        private void crvUn_Load(object sender, EventArgs e)
        {
            // initialisation des variables : 
            int numFacture = -1;
            String nomLoc = "";
            DateTime ancDatePassage = new DateTime();
            DateTime nouvellePassage = new DateTime();
            int nouvelIndex = -1;
            int ancienneIndex = -1;
            DateTime datePassageMoisSuivant = new DateTime();
            int nouvelIndexMoisProchain = -1;
            DateTime MoisDeLaFacture = new DateTime();
            String Rubrique = "Eau Tranche ";
            int PU = 0;
            DateTime dateAPayerAvant = new DateTime();
            double nbJourConso = 0;
            int locationCompteur = 720;
            // sélection du numéro de la facture dont  on veut imprimer les éléments sur la facture : 
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select numFacture from facture order by numFacture desc LIMIT 1 OFFSET 2";
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
            // sélection 1 : des éléments de la première facture  :) 
            try
            {

                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT villa.nomLocataire, traiter.ancienneDatePassage, traiter.nouvelleDatePassage, traiter.ancienIndex, traiter.nouvelIndex from villa inner join souscompteur on villa.numVilla = souscompteur.numVilla inner join traiter on traiter.numSousCompteur = souscompteur.numSousCompteur where traiter.numSousCompteur = @b and traiter.numFacture = @a";
                cmd.Parameters.AddWithValue("@a", numFacture);
                cmd.Parameters.AddWithValue("@b", billTempVars.numSC);

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    nomLoc = rdr.GetString(0);
                    ancDatePassage = rdr.GetDateTime(1);
                    nouvellePassage = rdr.GetDateTime(2);
                    ancienneIndex = rdr.GetInt32(3);
                    nouvelIndex = rdr.GetInt32(4);
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

            // sélection du numéro de la deuxième facture :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select numFacture from facture order by numFacture desc LIMIT 1 OFFSET 1";
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
            // sélection 2 : séléction des élémens de la nouvelle facture : 
            try
            {

                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT nouvelleDatePassage, nouvelIndex from traiter where numFacture = @a and numSousCompteur = @b";
                cmd.Parameters.AddWithValue("@a", numFacture);
                cmd.Parameters.AddWithValue("@b", billTempVars.numSC);

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    datePassageMoisSuivant = rdr.GetDateTime(0);
                    nouvelIndexMoisProchain = rdr.GetInt32(1);
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
            /*
             *      Traitement des variables une à une : 
             */

            // détermination du mois de la facture : 
            MoisDeLaFacture = ancDatePassage.AddDays(+10);


            // détermination de la rubrique :
            int conso = nouvelIndex - ancienneIndex;
            if (conso <= 10)
            {
                Rubrique += 1;
                PU = 190;
            }else if (conso <= 30)
            {
                Rubrique += 2;
                PU = 380;
            }else if (conso > 30)
            {
                Rubrique += 3;
                PU = 500;
            }
            else
            {
                MessageBox.Show(" Erreur Fatal !!!! L'application va maintenant se fermer !");
                this.Close();
            }
            //MessageBox.Show(Rubrique);

            // détermination de la date avant laquelle on doit payer la facture:
            dateAPayerAvant = nouvellePassage.AddDays(44);
            //MessageBox.Show(dateAPayerAvant.ToString());

            // calcul du nombre de jours de consommation d'eau :
            nbJourConso = (nouvellePassage.Date - ancDatePassage.Date).TotalDays;


            // création du datatable : 
            DataTable uneFacture = new DataTable();
            uneFacture.Columns.Add("nomLocataire", typeof(String));
            uneFacture.Columns.Add("ancienneDatePassage", typeof(DateTime));
            uneFacture.Columns.Add("nouvelleDatePassage", typeof(DateTime));
            uneFacture.Columns.Add("ancienIndex", typeof(Int32));
            uneFacture.Columns.Add("nouvelleIndex", typeof(Int32));
            uneFacture.Columns.Add("locationCompt", typeof(Int32));
            uneFacture.Columns.Add("nouvelIndexMoisProchain", typeof(Int32));
            uneFacture.Columns.Add("datePassageReleveur", typeof(DateTime));
            uneFacture.Columns.Add("libMoisFacture", typeof(String));
            uneFacture.Columns.Add("rubriqueTranche", typeof(String));
            uneFacture.Columns.Add("prixUnitaire", typeof(Int32));
            uneFacture.Columns.Add("aPayerAvant", typeof(DateTime));
            uneFacture.Columns.Add("nbJoursConso", typeof(Int32));

            // population de l'objet :
            uneFacture.Rows.Add(
                nomLoc,
                ancDatePassage,//.ToString().Substring(0, 4),
                nouvellePassage,//.ToString().Substring(0, 10),
                ancienneIndex,
                nouvelIndex,
                locationCompteur,
                nouvelIndexMoisProchain,
                datePassageMoisSuivant,//.ToString().Substring(0, 10),
                MoisDeLaFacture.ToString().Substring(3,7),
                Rubrique,
                PU,
                dateAPayerAvant.ToString().Substring(0, 10),
                nbJourConso                
                );

            Raports.uneFacture un = new Raports.uneFacture();
            un.Database.Tables["FactureLocataire"].SetDataSource(uneFacture);
            crvUn.ReportSource = null;
            crvUn.ReportSource = un;
            crvUn.Refresh();
            crvUn.Zoom(90);
        }

        private void Impression_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(userLogInfo.numSC);
        }

        private Thread oMainForm;

        private void Impression_FormClosing(object sender, FormClosingEventArgs e)
        {
            oMainForm = new Thread(ToMainForm);
            oMainForm.SetApartmentState(ApartmentState.STA);
            oMainForm.Start();
        }

        private void ToMainForm()
        {
            Application.Run(new impressionFacture());

        }
    }
}
