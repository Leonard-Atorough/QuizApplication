using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class StudentAnswer
    {
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }

        public virtual Question Question { get; set; }
        public virtual Student Student { get; set; }
    }
}
