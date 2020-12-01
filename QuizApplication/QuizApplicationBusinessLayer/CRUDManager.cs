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
                var newAccount = new Teacher
                {
                    TeacherName = name,
                    TeacherPassword = password,
                    TeacherEmail = email
                };

                db.Teachers.Add(newAccount);
                db.SaveChanges();
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
    }
}
