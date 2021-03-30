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
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _db.Teachers.ToListAsync();
            return View(teachers);
        }

        public IActionResult Create()
        {
            //ViewBag.Teacher = await _db.Teachers.
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var teacher = await _db.Teachers.FirstOrDefaultAsync(g => g.Id == Id);
            ViewBag.TeacherId = new SelectList(_db.Teachers, "Id", nameof(Teacher.FirstName));
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }
            _db.Update(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var teacher = new Teacher { Id = Id };
            _db.Entry(teacher).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
