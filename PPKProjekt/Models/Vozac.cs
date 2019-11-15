using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Models
{
    [Table("tblVozac")]
    public class Vozac
    {

        //IDVozac int primary key identity,
        //Ime nvarchar(50),
        //Prezime nvarchar(50),
        //BrojMobitela nvarchar(50),
        //SerijskiBrojVozacke nvarchar(8),

        [Key]
        public int IDVozac { get; set; }
        [Required(ErrorMessage ="Ime je potrebno")]
        [StringLength(50,ErrorMessage ="Nemoze biti duze od 50 znakova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je potrebno")]
        [StringLength(50, ErrorMessage = "Nemoze biti duze od 50 znakova")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Broj mobitela je potreban")]
        [StringLength(50, ErrorMessage = "Nemoze biti duze od 50 znakova")]
        public string BrojMobitela { get; set; }


        [Required(ErrorMessage = "Ime je potrebno")]
        [StringLength(50, ErrorMessage = "Nemoze biti duze od 50 znakova")]
        public string SerijskiBrojVozacke { get; set; }
    }
}
