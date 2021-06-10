using ArriendoDeAutosASP.Data;
using ArriendoDeAutosASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Lista Get
        public IActionResult Index()
        {
            IEnumerable<Vehicle> listVehicle = _context.Vehicle;
            return View(listVehicle);
        }
        //Create Post
        public IActionResult Create()
        {
            return View();
        }
    }
}
