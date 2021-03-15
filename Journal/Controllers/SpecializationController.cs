using Journal.Data;
using Journal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SpecializationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task <IActionResult> Index()
        {
            var Specializations = await _db.Specializations.ToListAsync();
            return View(Specializations);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Specialization specialization)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }
            await _db.Specializations.AddAsync(specialization);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
