using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class StaduLoad
    {
        public string NameSpetiality { get; set; }
        public string NamePulpit { get; set; }
        public int CountHour { get; set; }
        public int Semestr { get; set; }
        public int Course { get; set; }

        public StaduLoad(string NameSpetiality, string NamePulpit, int CountHour, int Semestr, int Course)
        {
            this.NameSpetiality = NameSpetiality;
            this.NamePulpit = NamePulpit;
            this.CountHour = CountHour;
            this.Semestr = Semestr;
            this.Course = Course;
        }
    }
}
