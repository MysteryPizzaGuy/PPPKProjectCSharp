using System;
using System.Collections.Generic;

namespace PPKProjekt.EntityFramework
{
    public partial class TblVozilo
    {
        public TblVozilo()
        {
            TblPutniNalog = new HashSet<TblPutniNalog>();
            TblServis = new HashSet<TblServis>();
        }

        public int Idvozilo { get; set; }
        public string Tip { get; set; }
        public string Marka { get; set; }
        public DateTime? GodinaProizvodnje { get; set; }
        public int? InicijalniKm { get; set; }

        public ICollection<TblPutniNalog> TblPutniNalog { get; set; }
        public ICollection<TblServis> TblServis { get; set; }
    }
}
