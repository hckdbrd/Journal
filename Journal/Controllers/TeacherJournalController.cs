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
    public class TeacherJournalController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherJournalController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var teachersJournals = await _db.TeachersJournals
                .Include(tj => tj.Teacher)
                .Include(tj => tj.Journal)
                .ToListAsync();
            return View(teachersJournals);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherJournal teacherJournal)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            await _db.TeachersJournals.AddAsync(teacherJournal);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
