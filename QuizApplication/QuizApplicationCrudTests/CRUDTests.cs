using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuizApplicationBusinessLayer;
using QuizApplicationModel;
using NUnit.Framework;

namespace QuizApplicationCrudTests
{
    public class Tests
    {
        CRUDManager _crudManager = new CRUDManager();
        [SetUp]
        public void Setup()
        {
            using (var db = new QuizBucketContext())
            {

                var selectedTeacher =
                from t in db.Teachers
                where t.TeacherName == "Derek Brown"
                select t;

                foreach (var c in selectedTeacher)
                {
                    db.Teachers.Remove(c);
                }
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new QuizBucketContext())
            {
                var selectedTeacher =
                from t in db.Teachers
                where t.TeacherName == "Derek Brown"
                select t;

                foreach (var c in selectedTeacher)
                {
                    db.Teachers.Remove(c);
                }
                db.SaveChanges();
            }
        }

        [Test]
        public void AccountIsCreated_NumberOfAccountsIncreaseByOne()
        {
            using (var db = new QuizBucketContext())

            {
                var numberOfTeachersBefore = db.Teachers.Count();
                _crudManager.CreateTeacherAccount("Derek Brown", "Nish Mandal", "Sparta Global");
                var numberOfTeachersAfter = db.Teachers.Count();

                Assert.AreEqual(numberOfTeachersBefore + 1, numberOfTeachersAfter);
            }
        }
        [Test]
        public void WhenQueriedForUserDetails_TheDatabaseReturnsExpectedDetails()
        {
            using (var db = new QuizBucketContext())
            {
                var createTeacher = new Teacher
                {
                    TeacherName = "Derek Brown",
                    TeacherPassword = "digbyB1",
                    TeacherEmail = "dbrown@gmail.com"
                };
                db.Teachers.Add(createTeacher);
                db.SaveChanges();

                var findUser = db.Teachers.Where(t => t.TeacherName == "Derek Brown").FirstOrDefault();
                Assert.AreEqual("Derek Brown", findUser.TeacherName);
                Assert.AreEqual("digbyB1", findUser.TeacherPassword);
                Assert.AreEqual("dbrown@gmail.com", findUser.TeacherEmail);
            }
        }

        [Test]
        public void ASuccessfulLoginWillNotThrowAnException()
        {
            using (var db = new QuizBucketContext())
            {
                var createTeacher = new Teacher
                {
                    TeacherName = "Derek Brown",
                    TeacherPassword = "digbyB1",
                    TeacherEmail = "dbrown@gmail.com"
                };
                db.Teachers.Add(createTeacher);
                db.SaveChanges();
 

                Assert.DoesNotThrow(() => _crudManager.TeacherLogin("Derek Brown", "digbyB1"));
            }
        }
        [Test]
        public void AnIncorrectLoginWillThrowAnException()
        {
            using (var db = new QuizBucketContext())
            {
                var createTeacher = new Teacher
                {
                    TeacherName = "Derek Brown",
                    TeacherPassword = "digbyB1",
                    TeacherEmail = "dbrown@gmail.com"
                };
                db.Teachers.Add(createTeacher);
                db.SaveChanges();

                string message = "";
                try
                {
                    _crudManager.TeacherLogin("Derek Brown", "digbyB2");
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                Assert.AreEqual("Invalid account credentials!", message);
            }
        }
    }
}