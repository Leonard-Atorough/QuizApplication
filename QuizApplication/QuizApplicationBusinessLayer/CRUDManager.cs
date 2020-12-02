using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using QuizApplicationModel;
using Microsoft.EntityFrameworkCore;

namespace QuizApplicationBusinessLayer
{
    public class CRUDManager
    {
        static void Main(string[] args)
        {
            
        }

        // SELECT ITEMS
        public Student SelectedStudent { get; set; }
        public Question SelectedQuestion { get; set; }
        public Quiz SelectedQuiz { get; set; }


        // GENERATE LISTS
        public List<Student> ListAllStudents()
        {
            using (var db = new QuizBucketContext())
            {
                return db.Students.ToList();
            }
        }

        public List<Student> ListAssignedStudents(string teacherName)
        {
            using (var db = new QuizBucketContext())
            {
                var myStudents =
                    from teacher in db.Teachers
                    join StudentTeacher in db.StudentTeachers on teacher.TeacherId equals StudentTeacher.TeacherId
                    join student in db.Students on StudentTeacher.StudentId equals student.StudentId
                    where teacher.TeacherName == teacherName
                    select student;

                List<Student> selectStudents = new List<Student>();
                foreach (var s in myStudents)
                {
                    selectStudents.Add(s);
                }

                return selectStudents;
            }
        }

        public List<Question> ListAllQuestions()
        {
            using (var db = new QuizBucketContext())
            {
                return db.Questions.ToList();
            }
        }

        public List<Quiz> ListAllQuizzes()
        {
            using (var db = new QuizBucketContext())
            {
                return db.Quizzes.ToList();
            }
        }


        // CREATE FUNCTIONS

        public void CreateTeacherAccount(string name, string password, string email)
        {
            using (var db = new QuizBucketContext())
            {
                var accountExists = db.Teachers.Where(c => c.TeacherName == name).SingleOrDefault();

                if (!db.Teachers.Contains(accountExists))
                {
                    if (password.Length > 0 && email.Length > 0)
                    {
                        var newAccount = new Teacher
                        {
                            TeacherName = name.Trim(),
                            TeacherPassword = password.Trim(),
                            TeacherEmail = email.Trim()
                        };
                        db.Teachers.Add(newAccount);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentException("You have not inputted a password and/or email");
                    }    
                }
                else
                {
                    throw new ArgumentException("Account already exists!");
                }
            }
        }

        public void CreateStudentAccount(string name, string password, string email)
        {
            using (var db = new QuizBucketContext())
            {
                var newAccount = new Student
                {
                    StudentName = name,
                    StudentPassword = password,
                    StudentEmail = email
                };

                db.Students.Add(newAccount);
                db.SaveChanges();
            }
        }

        public void CreateQuestion(string question)
        {
            using (var db = new QuizBucketContext())
            {
                var newQuestion = new Question
                {
                    Question1 = question
                };

                db.Questions.Add(newQuestion);
                db.SaveChanges();
            }
        }

        public void CreateQuiz(string quizName)
        {
            using (var db = new QuizBucketContext())
            {
                var newQuiz = new Quiz
                {
                    QuizName = quizName
                };

                db.Quizzes.Add(newQuiz);
                db.SaveChanges();
            }
        }

        //LOGIN FUNCTIONS
        public void TeacherLogin(string userName, string password)
        {
            using (var db = new QuizBucketContext())
            {
                var accountExists = db.Teachers.Where(c => c.TeacherName == userName).SingleOrDefault();
                if (db.Teachers.Contains(accountExists))
                {
                    var account =
                    (from teacher in db.Teachers
                    where teacher.TeacherName == userName && teacher.TeacherPassword == password
                    select teacher).ToList();
                }
                else
                {
                    throw new ArgumentException("User does not exist!");
                }
            }
        }
    }
}
