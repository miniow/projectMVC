using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public float Value { get; set; }
        public float Wieght { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public int TeacherID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }

        public virtual Teacher Teacher { get; set;}
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}