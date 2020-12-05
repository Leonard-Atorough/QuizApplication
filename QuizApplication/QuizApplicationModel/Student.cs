using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class Student
    {
        public Student()
        {
            StudentAnswers = new HashSet<StudentAnswer>();
            StudentQuizzes = new HashSet<StudentQuiz>();
            StudentTeachers = new HashSet<StudentTeacher>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentPassword { get; set; }
        public string StudentEmail { get; set; }

        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
        public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
