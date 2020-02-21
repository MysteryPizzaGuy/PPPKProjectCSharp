using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Models
{
    [Table("tblKupnjaGoriva")]
    public class KupnjaGoriva
    {

        [Key]
        public int IDKupnjaGoriva { get; set; }


        public PutniNalog PutniNalog { get; set; }


        [Required(ErrorMessage = "Lokacija je potreban")]
        [StringLength(100, ErrorMessage = "100 znakova ili manje")]
        public string Lokacija { get; set; }

        [Required(ErrorMessage = "GorivoPoLitri je potrebno")]
      
        public float GorivoPoLitri { get; set; }

        [Required(ErrorMessage = "CijenaPoLitri je potrebna")]
        public float CijenaPoLitri { get; set; }


    }
}
