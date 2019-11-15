using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Models
{
    public class PutniNalog
    {
        [Key]
        public int IDPutniNalog { get; set; }

        public Vozac Vozac { get; set; }

        public Vozilo Vozilo { get; set; }

        

        [Required(ErrorMessage = "Tip je potreban")]
        [StringLength(50, ErrorMessage = "50 znakova ili manje")]
        public string StartGrad { get; set; }

        [Required(ErrorMessage = "Marka je potrebna")]
        [StringLength(50, ErrorMessage = "50 znakova ili manje")]
        public string StopGrad { get; set; }

        [Required(ErrorMessage = "StartDate je potrebna")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "StopDate je potrebna")]
        public DateTime StopDate { get; set; }

    }
}
