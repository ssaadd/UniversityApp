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
    public class TypeOfDisciplinesController : Controller
    {
        private UniversityContext _context;

        public TypeOfDisciplinesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: TypeOfDisciplines
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице

            var source = _context.TypeOfDisciplins.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                TypeOfDisciplines = items
            };
            return View(viewModel);
            //return View(await _context.TypeOfDisciplins.ToListAsync());

        }
        // GET: TypeOfDisciplines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfDiscipline = await _context.TypeOfDisciplins
                .SingleOrDefaultAsync(m => m.TypeOfDisciplineID == id);
            if (typeOfDiscipline == null)
            {
                return NotFound();
            }

            return View(typeOfDiscipline);
        }

        // GET: TypeOfDisciplines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfDisciplines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfDisciplineID,NameTypeOfDiscipline")] TypeOfDiscipline typeOfDiscipline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfDiscipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfDiscipline);
        }

        // GET: TypeOfDisciplines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfDiscipline = await _context.TypeOfDisciplins.SingleOrDefaultAsync(m => m.TypeOfDisciplineID == id);
            if (typeOfDiscipline == null)
            {
                return NotFound();
            }
            return View(typeOfDiscipline);
        }

        // POST: TypeOfDisciplines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeOfDisciplineID,NameTypeOfDiscipline")] TypeOfDiscipline typeOfDiscipline)
        {
            if (id != typeOfDiscipline.TypeOfDisciplineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfDiscipline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfDisciplineExists(typeOfDiscipline.TypeOfDisciplineID))
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
            return View(typeOfDiscipline);
        }

        // GET: TypeOfDisciplines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfDiscipline = await _context.TypeOfDisciplins
                .SingleOrDefaultAsync(m => m.TypeOfDisciplineID == id);
            if (typeOfDiscipline == null)
            {
                return NotFound();
            }

            return View(typeOfDiscipline);
        }

        // POST: TypeOfDisciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfDiscipline = await _context.TypeOfDisciplins.SingleOrDefaultAsync(m => m.TypeOfDisciplineID == id);
            _context.TypeOfDisciplins.Remove(typeOfDiscipline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfDisciplineExists(int id)
        {
            return _context.TypeOfDisciplins.Any(e => e.TypeOfDisciplineID == id);
        }
    }
}
