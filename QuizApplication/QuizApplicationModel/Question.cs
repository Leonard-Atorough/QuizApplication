using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class Question
    {
        public Question()
        {
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int QuestionId { get; set; }
        public int? QuizId { get; set; }
        public int? TeacherId { get; set; }
        public string Question1 { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
