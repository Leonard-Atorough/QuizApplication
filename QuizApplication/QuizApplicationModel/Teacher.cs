using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class Teacher
    {
        public Teacher()
        {
            Questions = new HashSet<Question>();
            StudentTeachers = new HashSet<StudentTeacher>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherPassword { get; set; }
        public string TeacherEmail { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
