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
    public class DisciplinesController : Controller
    {
        private UniversityContext _context;

        public DisciplinesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Disciplines
        public async Task<IActionResult> Index( int page=1, SortState sortUniversity = SortState.NameDisciplineAsc)
        {
            /* var universityContext = _context.Disciplins.Include(d => d.Specialty).Include(d => d.Teachers).Include(d => d.TypeOfDiscipline);
             return View(await universityContext.ToListAsync());*/


            IQueryable<Discipline> disciplines = _context.Disciplins
                .Include(x => x.Teachers)
                .Include(y => y.Specialty)
                .Include(z => z.TypeOfDiscipline);
           
            switch (sortUniversity)
            {
                case SortState.NameDisciplineAsc:
                    disciplines = disciplines.OrderBy(s => s.NameDiscipline);
                    break;
                case SortState.NameDisciplineDesc:
                    disciplines = disciplines.OrderByDescending(s => s.NameDiscipline);
                    break;
                case SortState.NumberOfHoursOfLecturesAsc:
                    disciplines = disciplines.OrderBy(s => s.NumberOfHoursOfLectures);
                    break;
                case SortState.NumberOfHoursOfLecturesDesc:
                    disciplines = disciplines.OrderByDescending(s => s.NumberOfHoursOfLectures);
                    break;
                case SortState.NumberOfHoursOfPracticeAsc:
                    disciplines = disciplines.OrderBy(s => s.NumberOfHoursOfPractice);
                    break;
                case SortState.NumberOfHoursOfPracticeDesc:
                    disciplines = disciplines.OrderByDescending(s => s.NumberOfHoursOfPractice);
                    break;
                case SortState.TypeOfRportingAsc:
                    disciplines = disciplines.OrderBy(s => s.TypeOfRporting);
                    break;
                case SortState.TypeOfRportingDesc:
                    disciplines = disciplines.OrderByDescending(s => s.TypeOfRporting);
                    break;
               default:
                    disciplines = disciplines.OrderByDescending(s => s.NameDiscipline);
                    break;
            }
           
            int pageSize = 10;   // количество элементов на странице

            var source = disciplines.ToList();
             var count = source.Count();
             var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

             PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

             IndexViewModel viewModel = new IndexViewModel
             {
                 PageViewModel = pageViewModel,
                 SortViewModel = new SortViewModel(sortUniversity),
                 Disciplines = items
             };
             return View(viewModel);
        }

        // GET: Disciplines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplins
                .Include(d => d.Specialty)
                .Include(d => d.Teachers)
                .Include(d => d.TypeOfDiscipline)
                .SingleOrDefaultAsync(m => m.DisciplineID == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // GET: Disciplines/Create
        public IActionResult Create()
        {
            ViewData["SpecialtyID"] = new SelectList(_context.Speciaties, "SpecialtyID", "NameSpecialty");
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "FullName");
            ViewData["TypeOfDisciplineID"] = new SelectList(_context.TypeOfDisciplins, "TypeOfDisciplineID", "NameTypeOfDiscipline");
            return View();
        }

        // POST: Disciplines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisciplineID,NameDiscipline,NumberOfHoursOfLectures,NumberOfHoursOfPractice,TypeOfRporting,TeacherID,TypeOfDisciplineID,SpecialtyID")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecialtyID"] = new SelectList(_context.Speciaties, "SpecialtyID", "NameSpecialty", discipline.SpecialtyID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "FullName", discipline.TeacherID);
            ViewData["TypeOfDisciplineID"] = new SelectList(_context.TypeOfDisciplins, "TypeOfDisciplineID", "NameTypeOfDiscipline", discipline.TypeOfDisciplineID);
            return View(discipline);
        }

        // GET: Disciplines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplins.SingleOrDefaultAsync(m => m.DisciplineID == id);
            if (discipline == null)
            {
                return NotFound();
            }
            ViewData["SpecialtyID"] = new SelectList(_context.Speciaties, "SpecialtyID", "NameSpecialty", discipline.SpecialtyID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "FullName", discipline.TeacherID);
            ViewData["TypeOfDisciplineID"] = new SelectList(_context.TypeOfDisciplins, "TypeOfDisciplineID", "NameTypeOfDiscipline", discipline.TypeOfDisciplineID);
            return View(discipline);
        }

        // POST: Disciplines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisciplineID,NameDiscipline,NumberOfHoursOfLectures,NumberOfHoursOfPractice,TypeOfRporting,TeacherID,TypeOfDisciplineID,SpecialtyID")] Discipline discipline)
        {
            if (id != discipline.DisciplineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discipline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineExists(discipline.DisciplineID))
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
            ViewData["SpecialtyID"] = new SelectList(_context.Speciaties, "SpecialtyID", "NameSpecialty", discipline.SpecialtyID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "FullName", discipline.TeacherID);
            ViewData["TypeOfDisciplineID"] = new SelectList(_context.TypeOfDisciplins, "TypeOfDisciplineID", "NameTypeOfDiscipline", discipline.TypeOfDisciplineID);
            return View(discipline);
        }

        // GET: Disciplines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplins
                .Include(d => d.Specialty)
                .Include(d => d.Teachers)
                .Include(d => d.TypeOfDiscipline)
                .SingleOrDefaultAsync(m => m.DisciplineID == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: Disciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discipline = await _context.Disciplins.SingleOrDefaultAsync(m => m.DisciplineID == id);
            _context.Disciplins.Remove(discipline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineExists(int id)
        {
            return _context.Disciplins.Any(e => e.DisciplineID == id);
        }
    }
}
