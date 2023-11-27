using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Student: User
    {
        public int StudentID { get; set; }
        public int? ClassID { get; set; }
        public virtual Class Class { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

    }
}