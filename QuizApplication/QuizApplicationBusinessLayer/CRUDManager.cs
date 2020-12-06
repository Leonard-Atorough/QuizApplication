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

        public void SetSelectedQuiz(object selectedQuiz)
        {
            SelectedQuiz = (Quiz)selectedQuiz;
        }

        public void SetSelectedStudent(object selectedStudent)
        {
            SelectedStudent = (Student)selectedStudent;
        }

        public void SetSelectedQuestion(object selectedQuestion)
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

        public List<Quiz> ListAllQuizzes(string username)
        {
            using (var db = new QuizBucketContext())
            {
                var quizSelect =
                    from teacher in db.Teachers
                    join quiz in db.Quizzes on teacher.TeacherId equals quiz.TeacherId
                    where teacher.TeacherName == username
                    select quiz;

                return quizSelect.ToList();
            }
        }
        public List<Quiz> ListStudentQuizzes(string username)
        {
            using (var db = new QuizBucketContext())
            {
                var quizSelect =
                    from student in db.Students
                    join studentQuiz in db.StudentQuizzes on student.StudentId equals studentQuiz.StudentId
                    join quiz in db.Quizzes on studentQuiz.QuizId equals quiz.QuizId
                    where student.StudentName == username
                    select quiz;
                return quizSelect.ToList();
            }
        }

        public List<Question> ListStudentQuizQuestions(int quizId)
        {
            using (var db = new QuizBucketContext())
            {
                var quizQuestions =
                    from quiz in db.Quizzes
                    join question in db.Questions on quiz.QuizId equals question.QuizId
                    where quiz.QuizId == quizId
                    select question;

                return quizQuestions.ToList();
            }
        }



        public List<Question> ListAllQuestionsInQuiz(string username, string quizName)
        {
            using (var db = new QuizBucketContext())
            {
                var questions =
                    from teacher in db.Teachers
                    join quiz in db.Quizzes on teacher.TeacherId equals quiz.TeacherId
                    join question in db.Questions on quiz.QuizId equals question.QuizId
                    where teacher.TeacherName == username && quiz.QuizName == quizName
                    select question;

                return questions.ToList();
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
                var accountExists = db.Teachers.Where(c => c.TeacherName == name).SingleOrDefault();

                if (!db.Teachers.Contains(accountExists))
                {
                    if (password.Length > 0 && email.Length > 0)
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

        public void CreateQuiz(string quizName, string name)
        {
            using (var db = new QuizBucketContext())
            {
                if (quizName != null)
                {
                    var newQuiz = new Quiz
                    {
                        QuizName = quizName
                    };
                    var quizCreator = db.Teachers.Where(t => t.TeacherName == name).FirstOrDefault();
                    quizCreator.Quizzes.Add(newQuiz);
                    db.Quizzes.Add(newQuiz);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Quiz must have a name");
                }
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
        public void StudentLogin(string userName, string password)
        {
            using (var db = new QuizBucketContext())
            {
                var accountExists = db.Students.Where(c => c.StudentName == userName && c.StudentPassword == password).SingleOrDefault();
                if (db.Students.Contains(accountExists))
                {
                    var account =
                    (from student in db.Students
                     where student.StudentName == userName && student.StudentPassword == password
                     select student).ToList();
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

        public List<Student> SearchForStudentsInList(string userName)
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

        //UPDATE AND DELETE QUESTIONS
        public void UpdateSelectedQuestion(string question, string newQuestion)
        {
            using (var db = new QuizBucketContext())
            {
                SelectedQuestion = db.Questions.Where(q => q.Question1 == question).FirstOrDefault();
                SelectedQuestion.Question1 = newQuestion;
                db.SaveChanges();
            }
        }
        public void DeleteQuestion(string question, string name)
        {
            using (var db = new QuizBucketContext())
            {
                var selectedQuestion = db.Questions.Where(q => q.Question1 == question).FirstOrDefault();

                var associatedAnswers = db.StudentAnswers.Where(a => a.QuestionId == selectedQuestion.QuestionId).ToList();

                foreach (var item in associatedAnswers)
                {
                    db.StudentAnswers.Remove(item);
                }
                selectedQuestion.QuizId = null;
                db.Questions.Remove(selectedQuestion);
                db.SaveChanges();
            }
        }

        //QUIZ PAGE FUNCTIONS

        public void PublishQuiz(string quizName, string name)
        {
            using (var db = new QuizBucketContext())
            {
                if (quizName != null)
                {
                    var selectedQuiz = db.Quizzes.Where(q => q.QuizName == quizName).FirstOrDefault();
                    var assignedStudents =
                            from teacher in db.Teachers
                            join studentTeacher in db.StudentTeachers on teacher.TeacherId equals studentTeacher.TeacherId
                            join student in db.Students on studentTeacher.StudentId equals student.StudentId
                            where teacher.TeacherName == name
                            select student.StudentId;

                    foreach (var item in assignedStudents)
                    {
                        var AssignQuiz = new StudentQuiz
                        {
                            QuizId = selectedQuiz.QuizId,
                            StudentId = item

                        };
                        db.StudentQuizzes.Add(AssignQuiz);
                    }
                    db.SaveChanges();
                }
                else if (quizName == null)
                {
                    throw new Exception("Please select a quiz to publish.");
                }
                
            }
        }
        public List<Quiz> SearchForQuizInList(string quizName)
        {
            using (var db = new QuizBucketContext())
            {
                var searchedQuiz =
                    from quiz in db.Quizzes
                    where quiz.QuizName.Contains(quizName)
                    select quiz;

                return searchedQuiz.ToList();
            }
        }
        public void AddQuestionToQuiz(string quizName, string questionText)
        {
            using (var db = new QuizBucketContext())
            {
                if (quizName != null && questionText != null)
                {
                    var selectedQuiz = db.Quizzes.Where(q => q.QuizName == quizName).FirstOrDefault();
                    var selectedQuestion = db.Questions.Where(q => q.Question1 == questionText).FirstOrDefault();

                    selectedQuiz.Questions.Add(selectedQuestion);
                    selectedQuestion.QuizId = SelectedQuiz.QuizId;
                    db.SaveChanges();

                }
                else
                {
                    throw new Exception("Please select a valid question and a quiz");
                }

            }
        }
        public void RemoveQuestionsFromQuiz(string questionText)
        {
            using (var db = new QuizBucketContext())
            {
                if (questionText != null)
                {

                    var selectedQuestion =
                        (from question in db.Questions
                         join quiz in db.Quizzes on question.QuizId equals quiz.QuizId
                         where question.Question1 == questionText
                         select question).FirstOrDefault();

                    selectedQuestion.QuizId = null;
                    db.SaveChanges();

                }
                else
                {
                    throw new Exception("Please select a question");
                }

            }
        }
        public void DeleteQuiz(string quizName, string name)
        {
            using (var db = new QuizBucketContext())
            {
                if (quizName != null)
                {
                    var clearAnswers =
                        from quiz in db.Quizzes
                        join question in db.Questions on quiz.QuizId equals question.QuizId
                        join answers in db.StudentAnswers on question.QuestionId equals answers.QuestionId
                        where quiz.QuizName == quizName
                        select answers;

                    var unassignQuiz =
                        from quiz in db.Quizzes
                        join studentQuiz in db.StudentQuizzes on quiz.QuizId equals studentQuiz.QuizId
                        where quiz.QuizName == quizName
                        select studentQuiz;

                    var Questions =
                        from quiz in db.Quizzes
                        join question in db.Questions on quiz.QuizId equals question.QuizId
                        where quiz.QuizName == quizName
                        select question;

                    foreach (var item in clearAnswers)
                    {
                        db.StudentAnswers.Remove(item);
                    }
                    foreach (var item in unassignQuiz)
                    {
                        db.StudentQuizzes.Remove(item);
                    }
                    foreach (var item in Questions)
                    {
                        RemoveQuestionsFromQuiz(item.Question1);
                    }
                    var removeQuiz = db.Quizzes.Where(q => q.QuizName == quizName).FirstOrDefault();
                    db.Quizzes.Remove(removeQuiz);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Please select a quiz to delete");
                }
            }
        }

        public string DisplaySelectedQuestionAnswer(string name, int questionId)
        {
            using (var db = new QuizBucketContext())
            {
                int userId = db.Students.Where(s => s.StudentName == name).Select(i => i.StudentId).FirstOrDefault();
                var studentsAnswer = db.StudentAnswers.Where(s => s.StudentId == userId && s.QuestionId == questionId).FirstOrDefault();
                if (studentsAnswer != null)
                {
                    return studentsAnswer.Answer.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public void UpdateAnswer(string name, int questionId, string answer)
        {
            using (var db = new QuizBucketContext())
            {
                int userId = db.Students.Where(s => s.StudentName == name).Select(i => i.StudentId).FirstOrDefault();
                var StudentAnswerExists = db.StudentAnswers.Where(s => s.StudentId == userId && s.QuestionId == questionId).FirstOrDefault();
                
                if (StudentAnswerExists == null)
                {
                    var addAnswer = new StudentAnswer
                    {
                        StudentId = userId,
                        QuestionId = questionId,
                        Answer = answer
                    };
                    db.StudentAnswers.Add(addAnswer);
                }
                else
                {
                    StudentAnswerExists.Answer = answer;
                }
                db.SaveChanges();
            }
        }
    }
}
