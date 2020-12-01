using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class StudentTeacher
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
