using System;
using System.Collections.Generic;
using System.Text;

namespace Subjects
{
    public class Subject
    {
        public string SubjectName { get; set; }

        public int Halfyear { get; set; }

        public string FormExam { get; set; }

        public Subject () { }

        public Subject (string subjectName, int halfYear, string formExam)
        {
            SubjectName = subjectName;
            Halfyear = halfYear;
            FormExam = formExam;
        }
    }
}
