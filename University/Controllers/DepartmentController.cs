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
    public class DepartmentController : Controller
    {
        private UniversityContext _context;

        public DepartmentController(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            /* var universityContext = _context.Disciplins.Include(d => d.Specialty).Include(d => d.Teachers).Include(d => d.TypeOfDiscipline);
                return View(await universityContext.ToListAsync());*/


            IQueryable<Discipline> disciplines = _context.Disciplins
                .Include(x => x.Teachers)
                .Include(y => y.Specialty)
                .Include(z => z.TypeOfDiscipline);

            int pageSize = 10;   // количество элементов на странице

            var source = disciplines.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Disciplines = items
            };
            return View(viewModel);
        }
    }
}