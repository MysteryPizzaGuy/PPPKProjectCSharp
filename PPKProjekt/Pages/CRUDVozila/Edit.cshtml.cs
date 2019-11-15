using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDVozila
{
    public class EditModel : PageModel
    {
        private readonly IVoziloRepository repo;

        public EditModel()
        {
            repo = new VoziloRepository();
        }
        [BindProperty]
        public Vozilo Vozilo { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Vozac).State = EntityState.Modified;


            try
            {
                repo.Update(Vozilo);
            }
            catch (SqlException)
            {
                if (!VozacExists(Vozilo.IDVozilo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VozacExists(int id)
        {
            return repo.FindAll().Any(e => e.IDVozilo == id);
        }

    }
}