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
    public partial class AjouterUtilisateur : MetroFramework.Forms.MetroForm
    {
        // déclarations des variables de connexion à la bdd :
        //string cs = @"server=localhost;userid=root;password=cruds;database=waterjust";
        string cs = @dbStr.ChaimeDeConnexion;

        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

        // trhead variables : 
        private Thread oMainForm;

        public AjouterUtilisateur()
        {
            InitializeComponent();
        }

        private void AjouterUtilisateur_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAjoutUtilisateur_Click(object sender, EventArgs e)
        {
            // vérification si le nom et le prenom sont conformes
            String Pattern = @"^[a-z-âçèéêîôû'\s]+$"; // regex pour accepter que les nom africains.

            if (String.IsNullOrWhiteSpace(tbNomUser.Text) || String.IsNullOrWhiteSpace(tbPrenomUser.Text) || String.IsNullOrWhiteSpace(tbIdUser.Text) ||  String.IsNullOrWhiteSpace(tbMdpUser.Text))
            {

               DialogResult dr = MessageBox.Show("Un ou plusieurs champs sont vides, voulez-vous les complèter? ", "Information Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // retour à l'interface d'enregistrement de l'utilisateur :
                    tbNomUser.Select();
                }
                else
                {
                    // retour à liinterface de gestion des utilisateurs
                    tbNomUser.Text = tbPrenomUser.Text = tbIdUser.Text = tbMdpUser.Text = "";
                    this.Close();
                }

               
            }else if (!Regex.IsMatch(tbNomUser.Text, Pattern, RegexOptions.IgnoreCase) || !Regex.IsMatch(tbPrenomUser.Text, Pattern, RegexOptions.IgnoreCase))
            {

                MessageBox.Show("Le Nom et/ou le prenom doivent être alphabétique", "Information Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNomUser.Select();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Etes-vous sûr de vouloir effectuer l'enregistrment?", "Message De Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // insertion du nouvel utilisateur :
                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "insert into utilisateur(nomUtilisateur, prenomUtilisateur, identifiantUtilisateur, mdpUtilisateur) values(@a, @b, @c, @d)";
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@a", tbNomUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@b", tbPrenomUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@c", tbIdUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@d", tbMdpUser.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("L'Utilisateur Ajouté.");
                        tbNomUser.Text = tbPrenomUser.Text = tbIdUser.Text = tbMdpUser.Text = "";
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
                else if (dr == DialogResult.No)
                {
                    tbNomUser.Text = tbPrenomUser.Text = tbIdUser.Text = tbMdpUser.Text = "";
                    this.Close();
                }
            }
        }

        private void btnAnnulerAjoutUtilisateur_Click(object sender, EventArgs e)
        {
            tbNomUser.Text = tbPrenomUser.Text = tbIdUser.Text = tbMdpUser.Text = "";
            tbNomUser.Select();
        }

        private void AjouterUtilisateur_FormClosed(object sender, FormClosedEventArgs e)
        {
           // MessageBox.Show("yeah !!! ");
        }

        private void AjouterUtilisateur_FormClosing(object sender, FormClosingEventArgs e)
        {
            oMainForm = new Thread(ToMainForm);
            oMainForm.SetApartmentState(ApartmentState.STA);
            oMainForm.Start();
        }

        private void ToMainForm()
        {
            Application.Run(new GestionDesUtilisateurs());

        }
    }
}
