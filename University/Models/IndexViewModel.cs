using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Discipline> Disciplines { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Pulpit> Pulpits { get; set; }
        public IEnumerable<Specialty> Specialties { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<TypeOfDiscipline> TypeOfDisciplines { get; set; }
        public IEnumerable<StaduLoad> StadyLoads { get; set; }

        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public FiltrViewModel FiltrViewModel { get; set; }
    }
}
