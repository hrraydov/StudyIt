using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
