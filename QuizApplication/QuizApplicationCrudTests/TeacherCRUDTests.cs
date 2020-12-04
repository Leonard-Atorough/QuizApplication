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
        //CRUDManager _crudManager = new CRUDManager();
        //[SetUp]
        //public void Setup()
        //{
        //    using (var db = new QuizBucketContext())
        //    {

        //        var selectedTeacher =
        //        from t in db.Teachers
        //        where t.TeacherName == "Derek Brown"
        //        select t;

        //        foreach (var c in selectedTeacher)
        //        {
        //            db.Teachers.Remove(c);
        //        }
        //        db.SaveChanges();
        //    }
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    using (var db = new QuizBucketContext())
        //    {
        //        var selectedTeacher =
        //        from t in db.Teachers
        //        where t.TeacherName == "Derek Brown"
        //        select t;

        //        foreach (var c in selectedTeacher)
        //        {
        //            db.Teachers.Remove(c);
        //        }
        //        db.SaveChanges();
        //    }
        //}

        //[Test]
        //public void AccountIsCreated()
        //{
        //    using(var db = new QuizBucketContext())

        //    {
        //        var numberOfCustomersBefore = db.Teachers.ToList().Count();
        //        _crudManager.CreateTeacherAccount("MAND", "Nish Mandal", "Sparta Global");
        //        var numberOfCustomersAfter = db.Teachers.ToList().Count();

        //        Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);
        //    }
        //}
    }
}