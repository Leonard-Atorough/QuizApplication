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



    }
}
