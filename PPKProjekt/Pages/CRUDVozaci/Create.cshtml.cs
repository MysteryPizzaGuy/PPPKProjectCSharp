using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDVozaci
{
    public class CreateModel : PageModel
    {
        private readonly IVozacRepository repo;

        public CreateModel()
        {
            repo = new VozacRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vozac Vozac { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repo.Create(Vozac);

            return RedirectToPage("./Index");
        }
    }
}