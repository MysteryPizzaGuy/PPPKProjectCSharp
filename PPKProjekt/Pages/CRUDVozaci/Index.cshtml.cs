using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPKProjekt;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDVozaci
{
    public class IndexModel : PageModel
    {
        private readonly IVozacRepository repo;

        public IndexModel()
        {
            repo = new VozacRepository();
        }
        public void OnPost()
        {
            repo.InsertTestCase();
            Vozac = repo.FindAll().ToList();


        }
        public IList<Vozac> Vozac { get;set; }

        public void OnGet()
        {
            Vozac = repo.FindAll().ToList();
            
        }
    }
}
