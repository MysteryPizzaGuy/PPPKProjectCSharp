using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDPutniNalog
{
    public class CreateModel : PageModel
    {
        private readonly IPutniNalogRepository repo;
        private readonly IVozacRepository vozacRepo;
        private readonly IVoziloRepository voziloRepo;
        

        public CreateModel()
        {
            repo = new PutniNalogRepository();
            vozacRepo = new VozacRepository();
            voziloRepo= new VoziloRepository();
            
        }

        public IActionResult OnGet()
        {
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

            return Page();
        }



        [BindProperty]
        public PutniNalog PutniNalog { get; set; }



        [BindProperty]
        public int Vozilo { get; set; }
        [BindProperty]
        public int Vozac { get; set; }
        public List<SelectListItem> Vozaci { get; set; }
        public List<SelectListItem> Vozila { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            PutniNalog.Vozilo = voziloRepo.FindById(Vozilo);
            PutniNalog.Vozac = vozacRepo.FindById(Vozac);
            if (!repo.FindBetweenDates(PutniNalog.StartDate,PutniNalog.StopDate).Any())
            {
                

                if (!ModelState.IsValid)
                {
                    return Page();
                }

            
                repo.Create(PutniNalog);

                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToPage("./VoziloZauzeto");

            }

        }
    }
}