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
    public class DeleteModel : PageModel
    {
        private readonly IVozacRepository repo;
        private readonly IPutniNalogRepository putniRepo;

        public DeleteModel()
        {
            repo = new VozacRepository();
            putniRepo = new PutniNalogRepository();
        }

        [BindProperty]
        public Vozac Vozac { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vozac = repo.FindAll().FirstOrDefault(m => m.IDVozac == id);
                /*await _context.Vozaci.FirstOrDefaultAsync(m => m.IDVozac == id);*/

            if (Vozac == null)
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

            

            if (Vozac != null)
            {

                if (!putniRepo.FindAll().Any(x=> x.Vozac.IDVozac==Vozac.IDVozac))
                {
                    repo.Delete(Vozac);
                }
                else
                {

                }
            }

            return RedirectToPage("./Index");
        }
        public IActionResult OnPostIsViable()
        {
            if (putniRepo.FindAll().Any(m => m.Vozac.IDVozac == Vozac.IDVozac))
            {
                return new JsonResult(false);
            }
            else
            {
                return new JsonResult(true);
            }
        }
    }
}
