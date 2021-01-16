using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ancienIndexSCEncoreNull : IEquatable<sousCompteursActifs>
    {
        public int numSCEncoreActifs { get; set; }
        public int indexInitial { get; set; }

        bool IEquatable<sousCompteursActifs>.Equals(sousCompteursActifs other)
        {
            throw new NotImplementedException();
        }
    }
}
