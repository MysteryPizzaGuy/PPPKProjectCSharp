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
    public class CreateModel : PageModel
    {
        private readonly IVoziloRepository repo;

        public CreateModel()
        {
            repo = new VoziloRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Vozilo Vozilo{ get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repo.Create(Vozilo);

            return RedirectToPage("./Index");
        }
    }
}