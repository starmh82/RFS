using Microsoft.AspNetCore.Mvc;
using RFS.RepositoriesCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFS.MVC6.Controllers
{
    public class EmployeesController: Controller
    {
        private RFSContext db ;
        public EmployeesController(RFSContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }
    }
}
