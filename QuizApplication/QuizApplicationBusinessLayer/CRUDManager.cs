﻿using System;
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

        public void SetSelectedStudent(object selectedStudent)
        {
            SelectedStudent = (Student)selectedStudent;
        }

        public void DisplaySelectedQuestion(object selectedQuestion)
        {
            SelectedQuestion = (Question)selectedQuestion;
        }


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

        public List<Question> ListAllQuestions(string username)
        {
            using (var db = new QuizBucketContext())
            {
                var questions =
                    from teacher in db.Teachers
                    join question in db.Questions on teacher.TeacherId equals question.TeacherId
                    where teacher.TeacherName == username
                    select question;

                return questions.ToList();
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

        public void CreateQuestion(string question, string name)
        {
            using (var db = new QuizBucketContext())
            {
                var newQuestion = new Question
                {
                    Question1 = question
                };

                var questionCreator = db.Teachers.Where(t => t.TeacherName == name).FirstOrDefault();
                questionCreator.Questions.Add(newQuestion);
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
                var accountExists = db.Teachers.Where(c => c.TeacherName == userName && c.TeacherPassword == password).SingleOrDefault();
                if (db.Teachers.Contains(accountExists))
                {
                    var account =
                    (from teacher in db.Teachers
                     where teacher.TeacherName == userName && teacher.TeacherPassword == password
                     select teacher).ToList();
                }
                else
                {
                    throw new ArgumentException("Invalid account credentials!");
                }
            }
        }


        // ADD AND REMOVE STUDENTS FUNCTIONS
        public void AddStudentToList(string username, string teacherName)
        {
            using (var db = new QuizBucketContext())
            {
                var addStudent =
                    from student in db.Students
                    where student.StudentName == username
                    select student;
                var relatedTeacher =
                    from teacher in db.Teachers
                    where teacher.TeacherName == teacherName
                    select teacher;
                
                int studentId = 0;
                int teacherId = 0;

                foreach (var item in addStudent)
                {
                    studentId = item.StudentId;
                }
                foreach (var item in relatedTeacher)
                {
                    teacherId = item.TeacherId;
                }

                var doesExist = db.StudentTeachers.Where(st => st.StudentId == studentId && st.TeacherId == teacherId).FirstOrDefault();

                if (!db.StudentTeachers.Contains(doesExist))
                {
                    var studentTeacher = new StudentTeacher
                    {
                        StudentId = studentId,
                        TeacherId = teacherId
                    };
                    db.StudentTeachers.Add(studentTeacher);
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Cannot duplicated student!");
                }
                
            }
        }

        public void RemoveStudentFromList(string userName, string teacherName)
        {
            using (var db = new QuizBucketContext())
            {
                var removeStudent =
                    from student in db.Students
                    join studentTeacher in db.StudentTeachers on student.StudentId equals studentTeacher.StudentId
                    join teacher in db.Teachers on studentTeacher.TeacherId equals teacher.TeacherId
                    where student.StudentName == userName && teacher.TeacherName == teacherName
                    select studentTeacher;

                foreach (var item in removeStudent)
                {
                    db.StudentTeachers.Remove(item);
                }
                db.SaveChanges();
            }
        }

        public List<Student> SearchForStudentsInList (string userName)
        {
            using (var db = new QuizBucketContext())
            {
                var searchedStudent =
                    from student in db.Students
                    where student.StudentName.Contains(userName)
                    select student;

                return searchedStudent.ToList();
            }
        }

        //UPDATE FUNCTIONS
        //public void UpdateSelectedQuestions(string question, string newQuestion)
        //{
        //    using (var db = new QuizBucketContext())
        //    {
        //        SelectedQuestion = db.Questions.Where()
        //    }
        //}

        //DELETE FUNCTIONS
        public void DeleteQuestion(string question, string name)
        {
            using (var db = new QuizBucketContext())
            {
                var selectedQuestion = db.Questions.Where(q => q.Question1 == question).FirstOrDefault();

                db.Questions.Remove(selectedQuestion);
                db.SaveChanges();
            }
        }
    }
}
