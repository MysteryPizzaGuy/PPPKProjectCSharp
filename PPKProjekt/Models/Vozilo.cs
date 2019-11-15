using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Models
{
    [Table("tblVozilo")]
    public class Vozilo
    {
        //        IDVozilo int primary key identity,
        //Tip nvarchar(50),
        //Marka nvarchar(50),
        //GodinaProizvodnje int,
        //InicijalniKM int,
        [Key]
        public int IDVozilo { get; set; }

        [Required(ErrorMessage ="Tip je potreban")]
        [StringLength(50,ErrorMessage ="50 znakova ili manje")]
        public string Tip { get; set; }

        [Required(ErrorMessage = "Marka je potrebna")]
        [StringLength(50, ErrorMessage = "50 znakova ili manje")]
        public string Marka { get; set; }

        [Required(ErrorMessage = "GodinaProizvodnje je potrebna")]
        public DateTime GodinaProizvodnje{ get; set; }

        [Required(ErrorMessage = "InicijalniKM je potreban")]
        public int InicijalniKM { get; set; }

    }
}
