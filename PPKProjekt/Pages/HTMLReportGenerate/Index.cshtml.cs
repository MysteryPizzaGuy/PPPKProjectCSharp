using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPKProjekt.EntityFramework;

namespace PPKProjekt.Pages.HTMLReportGenerate
{
    public class IndexModel : PageModel
    {
        private readonly PPKProjekt.EntityFramework.VehicleControlContext _context;

        public IndexModel(PPKProjekt.EntityFramework.VehicleControlContext context)
        {
            _context = context;
        }

        public IList<TblVozilo> TblVozilo { get;set; }

        public void  OnGetAsync()
        {
            TblVozilo = _context.TblVozilo.ToList();
        }
    }
}
