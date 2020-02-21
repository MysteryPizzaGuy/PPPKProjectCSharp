using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.Models;
using PPKProjekt.Repository;

namespace PPKProjekt.Pages.CRUDServis
{
    public class IndexModel : PageModel
    {
        private IServisRepository servrepo;

        public IndexModel()
        {
            servrepo= new ServisRepository();
        }

        public IList<Servis> Servis { get;set; }

        public void OnGet()
        {
            Servis = servrepo.FindAll().ToList();
        }
    }
}
