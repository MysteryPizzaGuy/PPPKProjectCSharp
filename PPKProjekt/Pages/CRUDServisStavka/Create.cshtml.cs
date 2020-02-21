using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDServisStavka
{
    public class CreateModel : PageModel
    {
        private IServisStavkaRepository servisStavkaRepository;

        public CreateModel()
        {
            servisStavkaRepository = new ServisStavkaRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServisStavka ServisStavka { get; set; }

        public IActionResult  OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            servisStavkaRepository.Create(ServisStavka);

            return RedirectToPage("./Index");
        }
    }
}