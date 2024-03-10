using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace University.Models
{
    public class Faculty
    {
        [Key]
        [Display(Name = "ID Факультета")]
        public int FacultyID { get; set; }
        [Display(Name = "Название факультета")]
        public string NameFaculty { get; set; }
        public ICollection<Pulpit> Pulpits { get; set; }
    }
}
