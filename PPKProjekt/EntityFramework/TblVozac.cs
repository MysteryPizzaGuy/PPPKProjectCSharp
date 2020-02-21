using System;
using System.Collections.Generic;

namespace PPKProjekt.EntityFramework
{
    public partial class TblVozac
    {
        public TblVozac()
        {
            TblPutniNalog = new HashSet<TblPutniNalog>();
        }

        public int Idvozac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojMobitela { get; set; }
        public string SerijskiBrojVozacke { get; set; }

        public ICollection<TblPutniNalog> TblPutniNalog { get; set; }
    }
}
