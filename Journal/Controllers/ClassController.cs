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
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClassController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _db.Classes.ToListAsync();
            return View(classes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Class cl)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            await _db.Classes.AddAsync(cl);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
