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
    public partial class traiterImpayes : MetroFramework.Forms.MetroForm
    {
        public traiterImpayes()
        {
            InitializeComponent();
        }

        private Thread oMainForm;

        private void traiterImpayes_FormClosing(object sender, FormClosingEventArgs e)
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
