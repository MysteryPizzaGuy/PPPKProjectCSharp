using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDRute
{
    public class DetailsModel : PageModel
    {
        private IRutaRepository rutarepo;

        public DetailsModel()
        {
            this.rutarepo = new RutaRepository();
        }

        public Ruta Ruta { get; set; }

        public  IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ruta = rutarepo.FindById((int)id);

            if (Ruta == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
