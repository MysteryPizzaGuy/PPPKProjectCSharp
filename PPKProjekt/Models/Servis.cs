using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Models
{
    [Table("tblServis")]

    public class Servis
    {
            [Key]
            public int IDServis { get; set; }


            public Vozilo Vozilo{ get; set; }

            public ServisStavka ServisStavka { get; set; }

            [Required(ErrorMessage = "Datum je potrebno")]
            public DateTime Datum { get; set; }

            [Required(ErrorMessage = "Naziv je potreban")]
            public String Naziv { get; set; }
            [Required(ErrorMessage = "Opis je potreban")]
            public String Opis { get; set; }
            [Required(ErrorMessage = "Cijena je potreban")]
            public double Cijena { get; set; }

    }
}
