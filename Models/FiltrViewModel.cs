
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using University.Models;

namespace University.Models
{
    public class FiltrViewModel
    {
        public IEnumerable<Specialty> Specialties { get; set; }
        public IEnumerable<Discipline> Disciplines { get; set; }
        public string NameSpecialty { get; set; }
        public int Course { get; set; }
        public int Semester { get; set; }

        public FiltrViewModel(IEnumerable<Specialty> Specialties, string NameSpecialty, int Course, int Semester)
        {
            this.Specialties = Specialties;
            this.NameSpecialty = NameSpecialty;
            this.Course = Course;
            this.Semester = Semester;
        }

        public FiltrViewModel(IEnumerable<Discipline> Disciplines, string NameSpecialty, int Course, int Semester)
        {
            this.Disciplines = Disciplines;
            this.NameSpecialty = NameSpecialty;
            this.Course = Course;
            this.Semester = Semester;
        }
    }
}