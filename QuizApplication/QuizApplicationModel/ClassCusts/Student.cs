using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApplicationModel
{
    public partial class Student
    {
        public override string ToString()
        {
            return $"{StudentName} - {StudentEmail}";
        }
    }
}
