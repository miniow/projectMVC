using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }

        public int TeacherID{ get; set; }
        public virtual Teacher Teacher { get; set; }
        public ICollection<Grade> Grades { get; set;}

    }
}