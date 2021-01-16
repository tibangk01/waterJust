using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class sousCompteursActifs : IEquatable<sousCompteursActifs>
    {
        public int numSCActif { get; set; }

        bool IEquatable<sousCompteursActifs>.Equals(sousCompteursActifs other)
        {
            throw new NotImplementedException();
        }
    }
}
