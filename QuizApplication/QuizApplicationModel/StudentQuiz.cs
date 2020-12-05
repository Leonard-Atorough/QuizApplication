using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class StudentQuiz
    {
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public int? Score { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual Student Student { get; set; }
    }
}
