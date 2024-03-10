using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Models;
using Microsoft.AspNetCore.Authorization;


namespace University.Controllers
{
    [Authorize]
    public class DisciplinController : Controller
    {
        private UniversityContext _context;

        public DisciplinController(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string nameSpecialty, int course, int semester, int page = 1)
        {
            /* var universityContext = _context.Disciplins.Include(d => d.Specialty).Include(d => d.Teachers).Include(d => d.TypeOfDiscipline);
                return View(await universityContext.ToListAsync());*/


            IQueryable<Discipline> disciplines = _context.Disciplins
                .Include(x => x.Teachers)
                .Include(y => y.Specialty)
                .Include(z => z.TypeOfDiscipline);

            if (!String.IsNullOrEmpty(nameSpecialty))
            {
                disciplines = disciplines.Where(p => p.Specialty.NameSpecialty.Contains(nameSpecialty));
            }

            if (course != 0)
            {
                disciplines = disciplines.Where(p => p.Specialty.Course == course);
            }

            if (semester != 0)
            {
                disciplines = disciplines.Where(p => p.Specialty.Semester == semester);
            }
            FiltrViewModel filtrViewModel = new FiltrViewModel(disciplines, nameSpecialty, course, semester);
            int pageSize = 10;   // количество элементов на странице

            var source = disciplines.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                FiltrViewModel = filtrViewModel,
                Disciplines = items
            };
            return View(viewModel);
        }
    }
}