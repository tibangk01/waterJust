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
    public partial class validationFacture : MetroFramework.Forms.MetroForm
    {
        // objets de la base de données :
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        // déclaration des variables de thread :
        private Thread oMainForm;

        public validationFacture()
        {
            InitializeComponent();
        }

        private void validationFacture_FormClosing(object sender, FormClosingEventArgs e)
        {
            oMainForm = new Thread(ToMainForm);
            oMainForm.SetApartmentState(ApartmentState.STA);
            oMainForm.Start();
        }

        private void ToMainForm()
        {
            Application.Run(new Accueil());

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // déclaration des variables :
            int trouver = -1;
            int numNewFacture = -1;
            // déclatation des tableaux dynamiques :
            List<tabNewInexNumSc> elementsTab1 = new List<tabNewInexNumSc>();
            List<sousCompteursActifs> elementsTab2 = new List<sousCompteursActifs>();

            // on veérifie si  au moins une facture existe :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                // verif si le g�rant existe :
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(numFacture) from facture";
                cmd.Prepare();

                trouver = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show(trouver.ToString());
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

            if (trouver > 0)
            {
                // déclaration des variavbles : 
                int numFacture = -1;
                // si oui alors on séléctionne le munéro de la dernière facture :
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
                        numFacture = rdr.GetInt32(0);
                        // MessageBox.Show(numNewFacture.ToString());
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

                if (numFacture != -1)
                {
                    // on teste si la facture a été énregistré ainsis sque tous les sosu compteure :

                    // déclaration des booblé : 
                    bool fact = true;
                    bool scs = true;


                    // test de la facture :
                    try
                    {

                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;

                        cmd.CommandText = "SELECT montantFacture FROM facture where numFacture = @a";
                        cmd.Parameters.AddWithValue("@a", numFacture);

                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                                
                            if (rdr.GetInt32(0) == 0)
                            {
                                fact = false;
                            
                            }

                        }
                        //MessageBox.Show(fact.ToString());

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


                    // test des sous compteure :
                    try
                    {

                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;

                        cmd.CommandText = "SELECT nouvelIndex FROM traiter where numFacture = @a";
                        cmd.Parameters.AddWithValue("@a", numFacture);

                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {

                            if (rdr.GetInt32(0) == 0)
                            {
                                scs = false;
                                break;
                            }

                        }
                       // MessageBox.Show(scs.ToString());
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

                    if (fact == true && scs == true)
                    {
                        //  mis à jour de la table facture et traiter : 

                        // maj facture :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update facture set statutTraitementFacture  = 1  where numFacture = @a";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", numFacture);
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

                        // maj des sous compteurs : 
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update traiter set statutTraitement  = 1  where numFacture = @a";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", numFacture);
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



                        // insertion d'une nouvelle factuer a partir de l'ancienen ;

                        // séléctionne tous les sous compteurs actif et leurs anciens index :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;

                            cmd.CommandText = "select souscompteur.numSousCompteur, traiter.nouvelIndex, traiter.nouvelleDatePassage from traiter INNER JOIN souscompteur on traiter.numSousCompteur = souscompteur.numSousCompteur where souscompteur.statutSousCompteur = 1 and traiter.numFacture =@a";
                            cmd.Parameters.AddWithValue("@a", numFacture);

                            rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {
                                elementsTab1.Add(new tabNewInexNumSc
                                {
                                    numSousCompteur = rdr.GetInt32(0),
                                    nouvelIndex = rdr.GetInt32(1),
                                    datePassgeInitial = rdr.GetString(2)
                                });
                                // MessageBox.Show(rdr.GetString(2));
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

                        // insertion d'une nouvelle facture :
                        try
                        {
                            // insertion du libélé du mois :
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;

                            //insertion des autres informations dans la table sous-compteur :
                            cmd.CommandText = "insert into facture(montantFacture) values(@a)";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", 0);

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

                        // séléction du nouveau numéro de la dernière facture :
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
                                numNewFacture = rdr.GetInt32(0);
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

                        // séléction des sous Compteurs actifs à la date de la nouvelle facture :
                        try
                        {


                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;

                            cmd.CommandText = "select numSousCompteur from souscompteur where statutSousCompteur = 1";

                            rdr = cmd.ExecuteReader();

                            while (rdr.Read())
                            {

                                elementsTab2.Add(new sousCompteursActifs { numSCActif = rdr.GetInt32(0) });

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

                        // insertion de tous les sous compteurs actifs ainsi que leurs anciens et leurs ancienne datePassage indexs dans la table traiter :
                        foreach (sousCompteursActifs unSCA in elementsTab2)
                        {
                            // Préparation des variables :
                            int ancienIndex = 0;
                            int numFact = numNewFacture;
                            int numUser = userLogInfo.numUser;
                            int numSC = unSCA.numSCActif;
                            String ancienneDatePassage = "";

                            foreach (tabNewInexNumSc unElem in elementsTab1)
                            {
                                if (unSCA.numSCActif == unElem.numSousCompteur)
                                {
                                    ancienIndex = unElem.nouvelIndex;
                                    ancienneDatePassage = unElem.datePassgeInitial;
                                    // MessageBox.Show(ancienneDatePassage);
                                }

                            }

                            // MessageBox.Show(ancienneDatePassage);
                            // insertion dans la base de données :
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
                                cmd.Parameters.AddWithValue("@e", ancienneDatePassage.ToString().Substring(6, 4) + '-' + ancienneDatePassage.ToString().Substring(3, 2) + '-' + ancienneDatePassage.ToString().Substring(0, 2)); // reformatage de la date pour corresondre au format de la base de données.

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
                        MessageBox.Show("La facture a été bien traitée.");
                    }
                    else
                    {
                        MessageBox.Show(" Veillez remplir tous éléments de la facture en cours.");
                    }
                }

               
                // avec le numéro recu on teste si la factura a été enregistre et si tous les sous compteurs ont été enregistré

                // si oui alors on  fait la mis à jour de la table facture ainsi que tous les sous compteurs  et on fait l'insertion d'une 
                // nouvelle facture à partir de l'ancienne :

                // si non on affciche un message erreur :
            }


        }
    }
}
