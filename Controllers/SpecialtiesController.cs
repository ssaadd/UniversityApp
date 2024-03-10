using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Models;
using Microsoft.AspNetCore.Authorization;

namespace University.Views
{
    [Authorize]
    public class SpecialtiesController : Controller
    {
        private UniversityContext _context;

        public SpecialtiesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Specialties
        public IActionResult Index(string nameSpecialty, int course, int semester,  int page = 1 )
        {

            IQueryable<Specialty> specialties = _context.Speciaties
                .Include(o => o.Disciplins)
                .Include(o => o.Pulpit);

            

            if (!String.IsNullOrEmpty(nameSpecialty))
            {
                specialties = specialties.Where(p => p.NameSpecialty.Contains(nameSpecialty));
            }

            if (course != 0)
            {
                specialties = specialties.Where(p => p.Course == course);
            }

            if (semester!= 0)
            {
                specialties = specialties.Where(p => p.Semester == semester);
            }



            FiltrViewModel filtrViewModel = new FiltrViewModel(specialties, nameSpecialty, course, semester);

            int pageSize = 10;   // количество элементов на странице

            var source = specialties.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                FiltrViewModel = filtrViewModel,
                Specialties = items
            };
            return View(viewModel);
        
        /* var universityContext = _context.Speciaties.Include(s => s.Pulpit);
         return View(await universityContext.ToListAsync());*/
    }

        // GET: Specialties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Speciaties
                .Include(s => s.Pulpit)
                .SingleOrDefaultAsync(m => m.SpecialtyID == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // GET: Specialties/Create
        public IActionResult Create()
        {
            ViewData["PulpitID"] = new SelectList(_context.Pulpits, "PulpitID", "NamePulpit");
            return View();
        }

        // POST: Specialties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialtyID,NameSpecialty,PulpitID,Course,Semester")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PulpitID"] = new SelectList(_context.Pulpits, "PulpitID", "NamePulpit", specialty.PulpitID);
            return View(specialty);
        }

        // GET: Specialties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Speciaties.SingleOrDefaultAsync(m => m.SpecialtyID == id);
            if (specialty == null)
            {
                return NotFound();
            }
            ViewData["PulpitID"] = new SelectList(_context.Pulpits, "PulpitID", "NamePulpit", specialty.PulpitID);
            return View(specialty);
        }

        // POST: Specialties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialtyID,NameSpecialty,PulpitID,Course,Semester")] Specialty specialty)
        {
            if (id != specialty.SpecialtyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialtyExists(specialty.SpecialtyID))
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
            ViewData["PulpitID"] = new SelectList(_context.Pulpits, "PulpitID", "NamePulpit", specialty.PulpitID);
            return View(specialty);
        }

        // GET: Specialties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Speciaties
                .Include(s => s.Pulpit)
                .SingleOrDefaultAsync(m => m.SpecialtyID == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // POST: Specialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialty = await _context.Speciaties.SingleOrDefaultAsync(m => m.SpecialtyID == id);
            _context.Speciaties.Remove(specialty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialtyExists(int id)
        {
            return _context.Speciaties.Any(e => e.SpecialtyID == id);
        }
    }
}
