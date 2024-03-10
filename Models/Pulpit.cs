using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Pulpit
    {
        [Key]
        [Display(Name = "ID Кафедры")]
        public int PulpitID { get; set; }
        [Display(Name = "Наименование кафедры")]
        public string NamePulpit { get; set; }
        [Display(Name = "Вид кафедры")]
        public string KindOfChair { get; set; }
        [Display(Name = "ID Факультета")]
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
    }
}
