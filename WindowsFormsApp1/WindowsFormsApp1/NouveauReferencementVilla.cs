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
using MySql.Data.MySqlClient; // librairie pour utiliser les objets Mysql.

namespace WindowsFormsApp1
{
    public partial class NouveauReferencementVilla : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        //string cs = @"server=localhost;userid=root;password=cruds;database=waterjust";
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        public NouveauReferencementVilla()
        {
            InitializeComponent();
        }

        private void btnAddNewRef_Click(object sender, EventArgs e)
        {
            // vérification si le nom et le prenom sont conformes
            String Pattern = @"^[a-z-âçèéêîôû'\s]+$"; // regex pour accepter que les nom africains.
            String Pattern2 = @"^[0-9]+$"; // regex pour accepter que les numériques

            // verification si tous les tbs sont bon :
            if (String.IsNullOrWhiteSpace(tbNomLoc.Text) || String.IsNullOrWhiteSpace(tbPrenomLoc.Text) || String.IsNullOrWhiteSpace(tbIndexIniSousComp.Text))
            {
                DialogResult dr = MessageBox.Show("Un ou plusieurs champs sont vides, voulez-vous les complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    tbNomLoc.Select();
                }
                else
                {
                    tbNomLoc.Text = tbPrenomLoc.Text = tbIndexIniSousComp.Text = "";
                    this.Close();

                }
            }else if (!Regex.IsMatch(tbNomLoc.Text, Pattern, RegexOptions.IgnoreCase) || !Regex.IsMatch(tbPrenomLoc.Text, Pattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Le Nom et/ou le prenom doivent être alphabétique", "Information Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNomLoc.Select();

            }
            else if (!Regex.IsMatch(tbIndexIniSousComp.Text, Pattern2, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("La valeur initiale du sous compteur doit être numérique", "Information Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbIndexIniSousComp.Select();

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
                    cmd.CommandText = "insert into villa(nomLocataire, prenomLocataire) values(@a, @b)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@a", tbNomLoc.Text.ToString());
                    cmd.Parameters.AddWithValue("@b", tbPrenomLoc.Text.ToString());
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



                // selection du dernier enregistrement dansla table villa :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "select numVilla from villa where statutVilla = 1 order by numVilla desc limit 1 offset 0";
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        refVillaInfo.numVilla = rdr.GetInt32(0);
                        // MessageBox.Show(numVilla.ToString());
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


                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    //insertion des autres informations dans la table sous-compteur :
                    cmd.CommandText = "insert into souscompteur(indexInitial, numVilla, datePassgeInitial, statutInitialisation) values(@a, @b, @c, @d)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@a", tbIndexIniSousComp.Text.ToString());
                    cmd.Parameters.AddWithValue("@b", refVillaInfo.numVilla);
                    cmd.Parameters.AddWithValue("@d", 1);
                    cmd.Parameters.AddWithValue("@c", dtDateInitial.Value.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();

                    // reinitialisation de la constante :
                    refVillaInfo.numVilla = 0;

                    // message d'insertion reussi :

                    MessageBox.Show("Les Informations ont été bien enregistrées");
                    tbNomLoc.Text = tbPrenomLoc.Text = tbIndexIniSousComp.Text = "";
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

        private void btnCancelAddNewRef_Click(object sender, EventArgs e)
        {
            tbNomLoc.Text = tbPrenomLoc.Text = tbIndexIniSousComp.Text = "";
            tbNomLoc.Select();
        }

        private void NouveauReferencementVilla_Load(object sender, EventArgs e)
        {

        }

        private Thread ofRefVilla;
        private void NouveauReferencementVilla_FormClosing(object sender, FormClosingEventArgs e)
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
