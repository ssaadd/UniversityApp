using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class TypeOfDiscipline
    {
        [Key]
        [Display(Name = "ID Вида дисциплины")]
        public int TypeOfDisciplineID { get; set; }
        [Display(Name = "Наименование вида дисциплины")]
        public string NameTypeOfDiscipline { get; set; }
        public ICollection<Discipline> Disciplins { get; set; }
    }
}
