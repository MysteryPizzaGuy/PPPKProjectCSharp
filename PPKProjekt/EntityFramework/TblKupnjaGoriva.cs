using System;
using System.Collections.Generic;

namespace PPKProjekt.EntityFramework
{
    public partial class TblKupnjaGoriva
    {
        public int IdkupnjaGoriva { get; set; }
        public int? PutniNalogId { get; set; }
        public string Lokacija { get; set; }
        public double? GorivoPoLitri { get; set; }
        public double? CijenaPoLitri { get; set; }

        public TblPutniNalog PutniNalog { get; set; }
    }
}
