using System;
using System.Collections.Generic;

namespace PPKProjekt.EntityFramework
{
    public partial class TblRuta
    {
        public int Idruta { get; set; }
        public int? PutniNalogId { get; set; }
        public DateTime? Vrijeme { get; set; }
        public int? AcoordX { get; set; }
        public int? AcoordY { get; set; }
        public int? BcoordX { get; set; }
        public int? BcoordY { get; set; }
        public double? PrijedeniKm { get; set; }
        public double? ProsjecniKmh { get; set; }
        public double? PotrosenoGorivoLitre { get; set; }

        public TblPutniNalog PutniNalog { get; set; }
    }
}
