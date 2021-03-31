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
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClassController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _db.Classes
                .Include( cl => cl.Subject)
                .ToListAsync();
            return View(classes);
        }

        public IActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(_db.Subjects, "Id", nameof(Subject.Name));
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
        //public async Task<IActionResult> Edit()
        //{
        //    return Ok();
        // }
        public async Task<IActionResult> Edit(int Id)
        {
            var classes = await _db.Classes.FirstOrDefaultAsync(g => g.Id == Id);
            ViewBag.ClassId = new SelectList(_db.Classes, "Id", nameof(Class.Name));
            ViewBag.SubjectId = new SelectList(_db.Subjects, "Id", nameof(Subject.Name));
            return View(classes);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher classes)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }
            _db.Update(classes);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var classes = new Class { Id = Id };
            _db.Entry(classes).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
