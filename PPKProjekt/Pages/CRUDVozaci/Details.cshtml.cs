using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDVozaci
{
    public class DetailsModel : PageModel
    {
        private readonly IVozacRepository repo;

        public DetailsModel()
        {
            repo = new VozacRepository();
        }

        public Vozac Vozac { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vozac = repo.FindAll().FirstOrDefault(m => m.IDVozac == id);

            if (Vozac == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
