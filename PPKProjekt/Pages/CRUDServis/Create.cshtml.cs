using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDServis
{
    public class CreateModel : PageModel
    {
        private IServisRepository servrepo;
        private IVoziloRepository voziloRepo;
        private IServisStavkaRepository servisStavka;

        public CreateModel()
        {
            servrepo = new ServisRepository();
            voziloRepo = new VoziloRepository();
            servisStavka = new ServisStavkaRepository();
        }


        public IActionResult OnGet()
        {
            ServisStavke = servisStavka.FindAll().Select(x => new SelectListItem
            {
                Value = x.IDServisStavka.ToString(),
                Text = $"{x.Naziv}"
            }).ToList();
            Vozila = voziloRepo.FindAll().Select(x => new SelectListItem
            {
                Value = x.IDVozilo.ToString(),
                Text = $"{x.Tip} {x.Marka}"
            }).ToList();
            return Page();
        }

        [BindProperty]
        public int Vozilo { get; set; }
        [BindProperty]
        public int ServisStavka{ get; set; }
        public List<SelectListItem> ServisStavke { get; set; }
        public List<SelectListItem> Vozila { get; set; }


        [BindProperty]
        public Servis Servis { get; set; }

        public IActionResult OnPost()
        {

            Servis.Vozilo = voziloRepo.FindById(Vozilo);
            Servis.ServisStavka = servisStavka.FindById(ServisStavka);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            servrepo.Create(Servis);

            return RedirectToPage("./Index");
        }
    }
}