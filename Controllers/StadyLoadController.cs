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
    public class StadyLoadController : Controller
    {
        private UniversityContext _context;

        public StadyLoadController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {

            IQueryable<Discipline> disciplines = _context.Disciplins
               .Include(y => y.Specialty)
               .Include(y => y.Specialty.Pulpit);
            IQueryable<Specialty> speciaties = _context.Speciaties
                .Include(y => y.Pulpit); ;
            List<StaduLoad> result = new List<StaduLoad>();
            var stady = speciaties
               .Join(disciplines,
                   p => p.SpecialtyID,
                   t => t.SpecialtyID,
                   (p, t) => new
                   {
                       pulpit = p.Pulpit.NamePulpit,
                       cours = p.Course,
                       semestr = p.Semester,
                       name = p.NameSpecialty,
                       hour = t.NumberOfHoursOfLectures + t.NumberOfHoursOfPractice
                   });

            foreach (var item in stady)
            {
                result.Add(new StaduLoad(item.name, item.pulpit, item.hour, item.semestr, item.cours));
            }

            int pageSize = 10;   // количество элементов на странице
            var source = result.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                StadyLoads = items
            };
            return View(viewModel);

        }
    }
}
