using System;
using System.Collections.Generic;

namespace PPKProjekt.EntityFramework
{
    public partial class TblPutniNalog
    {
        public TblPutniNalog()
        {
            TblKupnjaGoriva = new HashSet<TblKupnjaGoriva>();
            TblRuta = new HashSet<TblRuta>();
        }

        public int IdputniNalog { get; set; }
        public int? VozacId { get; set; }
        public int? VoziloId { get; set; }
        public string StartGrad { get; set; }
        public string StopGrad { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StopDate { get; set; }

        public TblVozac Vozac { get; set; }
        public TblVozilo Vozilo { get; set; }
        public ICollection<TblKupnjaGoriva> TblKupnjaGoriva { get; set; }
        public ICollection<TblRuta> TblRuta { get; set; }
    }
}
