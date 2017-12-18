using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "ID Преподаватели")]
        public int TeacherID { get; set; }
        [Display(Name = "ФИО преподавателя")]
        public string FullName { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        [Display(Name = "Телефон")]
        public int Phone { get; set; }
        public ICollection<Discipline> Disciplins { get; set; }
    }
}
