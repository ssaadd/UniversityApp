using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Specialty
    {
        [Key]
        [Display(Name = "ID Специальности")]
        public int SpecialtyID { get; set; }
        [Display(Name = "Наименование специальности")]
        public string NameSpecialty { get; set; }
        [Display(Name = "ID Кафедры")]
        public int PulpitID { get; set; }
        [Display(Name = "Курс")]
        public int Course { get; set; }
        [Display(Name = "Семестр")]
        public int Semester { get; set; }
        public Pulpit Pulpit { get; set; }
        public ICollection<Discipline> Disciplins { get; set; }
    }
}
