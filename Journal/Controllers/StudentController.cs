using Journal.Data;
using Journal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ApplicationDbContext _db;

        public StudentController(ILogger<StudentController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var Students = await _db.Students
                .Include(s => s.Group)
                .ThenInclude(g => g.Teacher)
                .Include(s => s.Specialization)
                .ToListAsync();
            return View(Students);
        }
       

        public async Task<IActionResult> Create()
        {

            ViewBag.SpecializationId = new SelectList(_db.Specializations, "Id", nameof(Specialization.Name));
            ViewBag.GroupId = new SelectList(_db.Groups, "Id", nameof(Group.Name));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
         {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
