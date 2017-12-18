using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Discipline
    {
        [Key]
        [Display(Name = "IDДисциплины")]
        public int DisciplineID { get; set; }
        [Display(Name = "Название дисциплины")]
        public string NameDiscipline { get; set; }
        [Display(Name = "Количество часов лекций")]
        public int NumberOfHoursOfLectures { get; set; }
        [Display(Name = "Количество часов практик")]
        public int NumberOfHoursOfPractice { get; set; }
        [Display(Name = "Вид отчетности")]
        public string TypeOfRporting { get; set; }
        [Display(Name = "ID Преподаватели")]
        public int TeacherID { get; set; }
        [Display(Name = "ID Вида дисциплины")]
        public int TypeOfDisciplineID { get; set; }
        [Display(Name = "ID Специальности")]
        public int SpecialtyID { get; set; }
        public Teacher Teachers { get; set; }
        public TypeOfDiscipline TypeOfDiscipline { get; set; }
        public Specialty Specialty { get; set; }
    }
}
