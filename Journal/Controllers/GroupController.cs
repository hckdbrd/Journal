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
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GroupController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task <IActionResult> Index()
        {
            var Groups = await _db.Groups.ToListAsync();
            return View(Groups);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Group group)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }
            await _db.Groups.AddAsync(group);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
