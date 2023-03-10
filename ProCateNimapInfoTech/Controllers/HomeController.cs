using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProCateNimapInfoTech.Models;

namespace ProCateNimapInfoTech.Controllers
{
    public class HomeController : Controller
    {
        // GET: Hom
        public ActionResult Index(int? pageNumber)
        {
            BAL bl = new BAL();
            ModelState.Clear();
            return View(bl.Alldetails().ToPagedList(pageNumber ?? 1, 10));
        }

    }
}
