using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class tabNewInexNumSc : IEquatable<tabNewInexNumSc>
    {
        public int numSousCompteur { get; set; }
        public int nouvelIndex { get; set; }
        public String datePassgeInitial { get; set; }

        bool IEquatable<tabNewInexNumSc>.Equals(tabNewInexNumSc other)
        {
            throw new NotImplementedException();
        }
    }
}
