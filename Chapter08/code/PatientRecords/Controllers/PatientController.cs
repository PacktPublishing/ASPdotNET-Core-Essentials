using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientRecords.Controllers
{
    public class PatientController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id, string name = "Unknown")
        {
            ViewData["PatientId"] = id;
            ViewData["PatientName"] = name;
            return View();
        }

    }
}
