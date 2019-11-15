using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDPutniNalog
{
    public class DeleteModel : PageModel
    {
        private readonly IPutniNalogRepository repo;

        public DeleteModel()
        {
            repo = new PutniNalogRepository();
        }

        [BindProperty]
        public PutniNalog PutniNalog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PutniNalog = repo.FindAll().FirstOrDefault(m => m.IDPutniNalog == id);
            /*await _context.Vozaci.FirstOrDefaultAsync(m => m.IDVozac == id);*/

            if (PutniNalog == null)
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



            if (PutniNalog != null)
            {
                repo.Delete(PutniNalog);
            }

            return RedirectToPage("./Index");
        }
    }
}