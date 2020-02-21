using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Models
{

    [Table("tblServisStavka")]
    public class ServisStavka
    {
        [Key]
        public int IDServisStavka { get; set; }

        [Required(ErrorMessage = "Naziv je potrebno")]

        public String Naziv { get; set; }
    }
}
