using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApplicationModel
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int QuizId { get; set; }
        public int? TeacherId { get; set; }
        public string QuizName { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
