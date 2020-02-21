using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Models
{
    [Table("tblRuta")]
    public class Ruta
    {
        [Key]
        public int IDRuta { get; set; }


        public PutniNalog PutniNalog { get; set; }


        [Required(ErrorMessage = "Vrijeme je potrebno")]
        public DateTime Vrijeme { get; set; }

        [Required(ErrorMessage = "Koordinata je potreban")]
        public int ACoordX{ get; set; }
        [Required(ErrorMessage = "Koordinata je potreban")]
        public int ACoordY{ get; set; }
        [Required(ErrorMessage = "Koordinata je potreban")]
        public int BCoordX{ get; set; }
        [Required(ErrorMessage = "Koordinata je potreban")]
        public int BCoordY{ get; set; }

        [Required(ErrorMessage = "PrijedeniKM je potreban")]
        public double PrijedeniKM { get; set; }

        [Required(ErrorMessage = "ProsjecniKMH je potreban")]
        public double ProsjecniKMH { get; set; }

        [Required(ErrorMessage = "PotrosenoGorivoLitre je potreban")]
        public double PotrosenoGorivoLitre { get; set; }

    }
}

