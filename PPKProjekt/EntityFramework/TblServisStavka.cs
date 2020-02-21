using System;
using System.Collections.Generic;

namespace PPKProjekt.EntityFramework
{
    public partial class TblServisStavka
    {
        public TblServisStavka()
        {
            TblServis = new HashSet<TblServis>();
        }

        public int IdservisStavka { get; set; }
        public string Naziv { get; set; }

        public ICollection<TblServis> TblServis { get; set; }
    }
}
