using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Novateca.Web.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admins/Config/5
        public IActionResult Config()
        {
            return View();
        }
    }
}