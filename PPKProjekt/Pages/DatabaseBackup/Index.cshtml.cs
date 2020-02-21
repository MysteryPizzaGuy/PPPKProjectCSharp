using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPKProjekt.DataSet;

namespace PPKProjekt.Pages.DatabaseBackup
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public void OnPostBackup()
        {
            RouteDataSet.BackupDatabaseToXML();
        }
        public void OnPostRestore()
        {
            RouteDataSet.DeleteDBAndRestoreFromXML();
        }
        public void OnPostRouteWrite()
        {
            RouteDataSet.WriteRoutesToXML("RouteTableBackup.xml");
        }
        public void OnPostRouteRead()
        {
            RouteDataSet.ReadRoutesFromXML("RouteTableBackup.xml");
        }
    }
}