using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDServis
{
    public class EditModel : PageModel
    {
        private IServisRepository servrepo;
        private IVoziloRepository voziloRepo;
        private IServisStavkaRepository servisStavka;

        public EditModel()
        {
            servrepo = new ServisRepository();
            voziloRepo = new VoziloRepository();
            servisStavka = new ServisStavkaRepository();
        }

        [BindProperty]
        public Servis Servis { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Servis = servrepo.FindById((int)id);

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


            if (Servis == null)
            {
                return NotFound();
            }


            Vozilo = Servis.Vozilo.IDVozilo;
            ServisStavka = Servis.ServisStavka.IDServisStavka;

            return Page();
        }

        [BindProperty]
        public int Vozilo { get; set; }
        [BindProperty]
        public int ServisStavka { get; set; }
        public List<SelectListItem> ServisStavke { get; set; }
        public List<SelectListItem> Vozila { get; set; }

        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Servis.ServisStavka = servisStavka.FindById(ServisStavka);
            Servis.Vozilo = voziloRepo.FindById(Vozilo);
            try
            {
                servrepo.Update(Servis);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServisExists(Servis.IDServis))
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

        private bool ServisExists(int id)
        {
            return servrepo.FindById(id) != null;
        }
    }
}
