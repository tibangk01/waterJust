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
    public partial class impressionFacture : MetroFramework.Forms.MetroForm
    {
        
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        public impressionFacture()
        {
            InitializeComponent();
        }

        private void impressionFacture_Load(object sender, EventArgs e)
        {
            // sélectionne 
            // population du combo box :
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

            if (numFacture >2)
            {
                // sélection des éléménets pour la population du combobox :

                // init des variables : 
               
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "select concat('Villa N°', souscompteur.numVilla, ' - Mr ', villa.nomLocataire ), traiter.numSousCompteur, traiter.ancienneDatePassage from souscompteur inner join villa on souscompteur.numVilla = villa.numVilla inner join traiter on traiter.numSousCompteur = souscompteur.numSousCompteur where traiter.statutTraitement = 1 and numFacture = @a order by villa.numVilla";
                    cmd.Parameters.AddWithValue("@a", numFacture - 2);

                    rdr = cmd.ExecuteReader();
                    List<cbNouvelIndex> list = new List<cbNouvelIndex>();

                    while (rdr.Read())
                    {
                        list.Add(new cbNouvelIndex() {
                            libCbNouvelIndex = rdr.GetString(0),
                            numSousCompteur = rdr.GetInt32(1),
                            ancienneDate = rdr.GetDateTime(2)
                        });
                    }
                    cbUneFacture.DataSource = list;
                    cbUneFacture.ValueMember = "numSousCompteur";
                    cbUneFacture.DisplayMember = "libCbNouvelIndex";
                    lblInfoDateFacture.Text = "";
                    lblInfoDateFacture.Text = "Facture Du mois De :        " + list[0].ancienneDate.AddDays(-10).ToString().Substring(3, 2)+"/"+ list[0].ancienneDate.AddDays(-10).ToString().Substring(6, 4);
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

            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            billTempVars.numSC = cbUneFacture.SelectedValue.ToString();

            this.Hide();
            Impression a = new Impression();
            a.Show();
        }

        private Thread oMainForm;
        private void impressionFacture_FormClosing(object sender, FormClosingEventArgs e)
        {
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
