using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using project.Models;
namespace project.Controllers
{
    public class HomeController : Controller
    {
            DbModel db = new DbModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            var searc = db.Users.ToList();
            return View(searc);
        }
        [HttpGet]
        public async Task<ActionResult> Search(string usersearch)
        {
            ViewData["userserach"] = usersearch;
            var emptquery = from x in db.Users select x;
            if(!string.IsNullOrEmpty(usersearch))
            {
                emptquery = emptquery.Where(x => x.FirstName.Contains(usersearch) || x.LastName.Contains(usersearch) ||
                  x.Email.Contains(usersearch));
            }
            return View(await emptquery.AsNoTracking().ToListAsync());
        }
       
    }
}