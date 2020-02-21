using System;
using System.Collections.Generic;

namespace PPKProjekt.EntityFramework
{
    public partial class TblServis
    {
        public int Idservis { get; set; }
        public int? VoziloId { get; set; }
        public int? ServisStavkaId { get; set; }
        public DateTime? Datum { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double? Cijena { get; set; }

        public TblServisStavka ServisStavka { get; set; }
        public TblVozilo Vozilo { get; set; }
    }
}
