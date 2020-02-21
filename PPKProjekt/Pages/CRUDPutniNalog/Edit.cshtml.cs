using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDPutniNalog
{
    public class EditModel : PageModel
    {
        private readonly IPutniNalogRepository repo;
        private readonly IVozacRepository vozacRepo;
        private readonly IVoziloRepository voziloRepo;

        public EditModel()
        {
            repo = new PutniNalogRepository();
            vozacRepo = new VozacRepository();
            voziloRepo = new VoziloRepository();
        }
        [BindProperty]
        public PutniNalog PutniNalog { get; set; }
        [BindProperty]
        public int Vozilo { get; set; }
        [BindProperty]
        public int Vozac { get; set; }
        public List<SelectListItem> Vozaci { get; set; }
        public List<SelectListItem> Vozila { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PutniNalog = repo.FindAll().FirstOrDefault(m => m.IDPutniNalog == id);
            Vozaci = vozacRepo.FindAll().Select(x => new SelectListItem
            {
                Value = x.IDVozac.ToString(),
                Text = $"{x.Ime} {x.Prezime}"
            }).ToList();
            Vozila = voziloRepo.FindAll().Select(x => new SelectListItem
            {
                Value = x.IDVozilo.ToString(),
                Text = $"{x.Tip} {x.Marka}"
            }).ToList();
            Vozac = PutniNalog.Vozac.IDVozac;
            Vozilo = PutniNalog.Vozilo.IDVozilo;
            if (PutniNalog == null)
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
                PutniNalog.Vozilo = voziloRepo.FindById(Vozilo);
                PutniNalog.Vozac = vozacRepo.FindById(Vozac);
                if (!repo.FindBetweenDates(PutniNalog.StartDate, PutniNalog.StopDate).Any(x=>x.IDPutniNalog!=PutniNalog.IDPutniNalog))
                {
                    repo.Update(PutniNalog);
                    return RedirectToPage("./Index");

                }
                else {
                    return RedirectToPage("./VoziloZauzeto");

                }
            }
            catch (SqlException)
            {
                if (!PutniNalogExists(PutniNalog.IDPutniNalog))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        private bool PutniNalogExists(int id)
        {
            return repo.FindAll().Any(e => e.IDPutniNalog == id);
        }

    }
}