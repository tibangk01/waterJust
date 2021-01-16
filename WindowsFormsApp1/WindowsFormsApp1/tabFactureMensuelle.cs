using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class tabFactureMensuelle : IEquatable<tabFactureMensuelle>
    {
        // Implémentation des variables: 
        public int numSousCompteur { get; set; }
        public String nomLocataire { get; set; }
        public int nouvelIndex { get; set; }
        public int ancienIndex { get; set; }
        public String ancienneDatePassage { get; set; }
        public String nouvelleDatePassage { get; set; }


        bool IEquatable<tabFactureMensuelle>.Equals(tabFactureMensuelle other)
        {
            throw new NotImplementedException();
        }
    }
}
