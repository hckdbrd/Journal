using Journal.Data;
using Journal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index()
        {
            var groups = await _db.Groups.Include(g => g.Teacher).ToListAsync();
            return View(groups);
        }

        public IActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(_db.Teachers, "Id", nameof(Teacher.FirstName));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Group group)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            await _db.Groups.AddAsync(group);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var group = await _db.Groups.FirstOrDefaultAsync(g => g.Id == Id);
            ViewBag.TeacherId = new SelectList(_db.Teachers, "Id", nameof(Teacher.FirstName));
            return View(group);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Group group)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }
            _db.Update(group);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var group = new Group { Id = Id };
            _db.Entry(group).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
