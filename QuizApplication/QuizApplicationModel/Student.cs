using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class Student
    {
        public Student()
        {
            StudentAnswerQuestions = new HashSet<StudentAnswer>();
            StudentAnswerStudents = new HashSet<StudentAnswer>();
            StudentQuizQuizzes = new HashSet<StudentQuiz>();
            StudentQuizStudents = new HashSet<StudentQuiz>();
            StudentTeachers = new HashSet<StudentTeacher>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentPassword { get; set; }
        public string StudentEmail { get; set; }

        public virtual ICollection<StudentAnswer> StudentAnswerQuestions { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswerStudents { get; set; }
        public virtual ICollection<StudentQuiz> StudentQuizQuizzes { get; set; }
        public virtual ICollection<StudentQuiz> StudentQuizStudents { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
