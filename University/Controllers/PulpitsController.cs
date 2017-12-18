using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Models;
using Microsoft.AspNetCore.Authorization;

namespace University.Views
{
    [Authorize]
    public class PulpitsController : Controller
    {
        private UniversityContext _context;

        public PulpitsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Pulpits
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице

            var source = _context.Pulpits.Include(p => p.Faculty).ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Pulpits = items
            };
            return View(viewModel);
        /* var universityContext = _context.Pulpits.Include(p => p.Faculty);
         return View(await universityContext.ToListAsync());*/
    }

        // GET: Pulpits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pulpit = await _context.Pulpits
                .Include(p => p.Faculty)
                .SingleOrDefaultAsync(m => m.PulpitID == id);
            if (pulpit == null)
            {
                return NotFound();
            }

            return View(pulpit);
        }

        // GET: Pulpits/Create
        public IActionResult Create()
        {
            ViewData["FacultyID"] = new SelectList(_context.Faculties, "FacultyID", "NameFaculty");
            return View();
        }

        // POST: Pulpits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PulpitID,NamePulpit,KindOfChair,FacultyID")] Pulpit pulpit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pulpit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyID"] = new SelectList(_context.Faculties, "FacultyID", "NameFaculty", pulpit.FacultyID);
            return View(pulpit);
        }

        // GET: Pulpits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pulpit = await _context.Pulpits.SingleOrDefaultAsync(m => m.PulpitID == id);
            if (pulpit == null)
            {
                return NotFound();
            }
            ViewData["FacultyID"] = new SelectList(_context.Faculties, "FacultyID", "NameFaculty", pulpit.FacultyID);
            return View(pulpit);
        }

        // POST: Pulpits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PulpitID,NamePulpit,KindOfChair,FacultyID")] Pulpit pulpit)
        {
            if (id != pulpit.PulpitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pulpit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PulpitExists(pulpit.PulpitID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyID"] = new SelectList(_context.Faculties, "FacultyID", "NameFaculty", pulpit.FacultyID);
            return View(pulpit);
        }

        // GET: Pulpits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pulpit = await _context.Pulpits
                .Include(p => p.Faculty)
                .SingleOrDefaultAsync(m => m.PulpitID == id);
            if (pulpit == null)
            {
                return NotFound();
            }

            return View(pulpit);
        }

        // POST: Pulpits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pulpit = await _context.Pulpits.SingleOrDefaultAsync(m => m.PulpitID == id);
            _context.Pulpits.Remove(pulpit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PulpitExists(int id)
        {
            return _context.Pulpits.Any(e => e.PulpitID == id);
        }
    }
}
