using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    
        public enum SortState
        {
            NameDisciplineAsc,                   // по имени по возрастанию
            NameDisciplineDesc,                      // по имени по убыванию
            NumberOfHoursOfLecturesAsc,          // по имени по возрастанию
            NumberOfHoursOfLecturesDesc,         // по имени по убыванию
            NumberOfHoursOfPracticeAsc,          // по имени по возрастанию
            NumberOfHoursOfPracticeDesc,        // по имени по убыванию
            TypeOfRportingAsc,                  // по имени по возрастанию
            TypeOfRportingDesc,                // по имени по убыванию
            TeacherIDAsc,                      // по имени по возрастанию
            TeacherIDDesc,                     // по имени по убыванию
            TypeOfDisciplineIDAsc,             // по имени по возрастанию
            TypeOfDisciplineIDDesc,             // по имени по убыванию
            SpecialtyIDAsc,                     // по имени по возрастанию
            SpecialtyIDDesc                   // по имени по убыванию
        }

    public class SortViewModel
    {
       
        public SortState NameDisciplineSort { get; set; }
        public SortState NumberOfHoursOfLecturesSort { get; set; }
        public SortState NumberOfHoursOfPracticeSort { get; set; }
        public SortState TypeOfRportingSort { get; set; }
        public SortState Current { get; set; }

        public SortViewModel(SortState sortDiscipline)
        {
            NameDisciplineSort = sortDiscipline == SortState.NameDisciplineAsc ? SortState.NameDisciplineDesc : SortState.NameDisciplineAsc;
            NumberOfHoursOfLecturesSort = sortDiscipline == SortState.NumberOfHoursOfLecturesAsc ? SortState.NumberOfHoursOfLecturesDesc : SortState.NumberOfHoursOfLecturesAsc;
            NumberOfHoursOfPracticeSort = sortDiscipline == SortState.NumberOfHoursOfPracticeAsc ? SortState.NumberOfHoursOfPracticeDesc : SortState.NumberOfHoursOfPracticeAsc;
            TypeOfRportingSort = sortDiscipline == SortState.TypeOfRportingAsc ? SortState.TypeOfRportingDesc : SortState.TypeOfRportingAsc;
            Current = sortDiscipline;
        }

    }
}
