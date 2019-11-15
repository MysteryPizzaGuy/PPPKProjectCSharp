using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDVozila
{
    public class DetailsModel : PageModel
    {
        private readonly IVoziloRepository repo;

        public DetailsModel()
        {
            repo = new VoziloRepository();
        }
        public Vozilo Vozilo{ get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vozilo = repo.FindAll().FirstOrDefault(m => m.IDVozilo == id);

            if (Vozilo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}