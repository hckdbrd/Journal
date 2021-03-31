using Journal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Journal.Controllers
{
    public class JournalController : Controller
    {
        private readonly ApplicationDbContext _db;
        public JournalController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            //var Students = await _db.Students
            //.Include(s => s.Group)
            //.ThenInclude(g => g.Teacher)
            //.Include(s => s.Specialization)
            //.ToListAsync();
            //return View(Students);
            var journals = await _db.Journals
                .Include( j => j.Class)
                .Include( j => j.Teacher)
                .Include( j => j.Student)
                .ToListAsync();
            return View(journals);
        }

        public IActionResult Create()
        {
            ViewBag.ClassId = new SelectList(_db.Subjects, "Id", nameof(Models.Class.Name));
            ViewBag.StudentId = new SelectList(_db.Students, "Id", nameof(Models.Student.LastName));
            ViewBag.TeacherId = new SelectList(_db.Teachers, "Id", nameof(Models.Teacher.LastName));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Journal.Models.Journal journal)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            await _db.Journals.AddAsync(journal);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
