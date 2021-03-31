using Journal.Data;
using Microsoft.AspNetCore.Mvc;
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
            var journals = await _db.Journals.ToListAsync();
            return View(journals);
        }

        public IActionResult Create()
        {
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
