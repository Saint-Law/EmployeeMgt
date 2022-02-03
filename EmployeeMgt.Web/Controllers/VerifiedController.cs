using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Web.Controllers
{
    public class VerifiedController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult EmployeeDashboard()
        {
            return View();
        }
    }
}
