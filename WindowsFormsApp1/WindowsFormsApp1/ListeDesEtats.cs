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

namespace WindowsFormsApp1
{
    public partial class ListeDesEtats : MetroFramework.Forms.MetroForm
    {
        public ListeDesEtats()
        {
            InitializeComponent();
        }
        

        private void metroTile5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accueil a = new Accueil();
            a.Show();
        }

        private Thread oMainForm;
        private void ListeDesEtats_FormClosing(object sender, FormClosingEventArgs e)
        {
            oMainForm = new Thread(ToMainForm);
            oMainForm.SetApartmentState(ApartmentState.STA);
            oMainForm.Start();
        }

        private void ToMainForm()
        {
            Application.Run(new Accueil());

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FactureSpecifique factureSpecifique = new FactureSpecifique();
            factureSpecifique.Show();
        }
    }
}
