using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Subjects
{
    public class SubjectControl
    {
        public Subject[] subjects;
        public int length;

        public SubjectControl(int size)
        {

            subjects = new Subject[size];
            length = 0;
        }

        public void AddSubjectInArr(Subject subject)
        {
            if (length < subjects.Length)
            {
                subjects[length] = subject;
                length++;
            }
        }

        public Subject GetSubject(int i)
        {
            return subjects[i];
        }

        public void SortingToNameAndForm()
        {
            subjects = subjects.OrderBy(s => s.SubjectName).ThenBy(s => s.FormExam).ToArray();
        }

        public void SaveToTxt(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < length; i++)
                {
                    sw.WriteLine($"Название дисциплины: {subjects[i].SubjectName}; Семестр: {subjects[i].Halfyear}; Форма экзамена: {subjects[i].FormExam}");
                }
            }
        }
    }
}
