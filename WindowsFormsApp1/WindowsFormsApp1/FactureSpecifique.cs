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
    public partial class FactureSpecifique : MetroFramework.Forms.MetroForm
    {
        public FactureSpecifique()
        {
            InitializeComponent();
        }

        private void FactureSpecifique_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            ListeDesEtats a = new ListeDesEtats();
            a.Show();
        }
    }
}
