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
    public class DeleteModel : PageModel
    {
        private readonly IVoziloRepository repo;

        public DeleteModel()
        {
            repo = new VoziloRepository();
        }

        [BindProperty]
        public Vozilo Vozilo{ get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vozilo = repo.FindAll().FirstOrDefault(m => m.IDVozilo == id);
            /*await _context.Vozaci.FirstOrDefaultAsync(m => m.IDVozac == id);*/

            if (Vozilo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            if (Vozilo != null)
            {
                repo.Delete(Vozilo);
            }

            return RedirectToPage("./Index");
        }
    }
}