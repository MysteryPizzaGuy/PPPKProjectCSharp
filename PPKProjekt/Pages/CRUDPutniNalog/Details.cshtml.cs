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
    public class DetailsModel : PageModel
    {
        private readonly IPutniNalogRepository repo;

        public DetailsModel()
        {
            repo = new PutniNalogRepository();
        }
        public PutniNalog PutniNalog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PutniNalog = repo.FindAll().FirstOrDefault(m => m.IDPutniNalog == id);

            if (PutniNalog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}