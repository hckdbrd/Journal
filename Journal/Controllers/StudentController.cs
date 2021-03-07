﻿using Journal.Data;
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
            var Students = await _db.Students.ToListAsync();
            return View(Students);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SpecializationId = await _db.Specializations.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            })
                .ToListAsync();

            ViewBag.GroupId = await _db.Groups.Select(g => new SelectListItem()
            {
                Text = g.Name,
                Value = g.Id.ToString()
            })
                .ToListAsync();

            return View();
        }
    }
}
