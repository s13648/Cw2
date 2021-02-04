using System;
using System.Collections.Generic;
using System.Linq;

namespace Cw2.Data
{
    [Serializable]
    public class University
    {
        public University()
        {
            
        }
        public University(IEnumerable<Student> students, string author)
        {
            CreatedAt = DateTime.Now;
            Author = author;
            Students = students.ToArray();
            SetStudies();
        }

        private void SetStudies()
        {
            var st = new Dictionary<string,int>();
            foreach (var student in Students)
            {
                if (st.ContainsKey(student.Studies.Name))
                {
                    st[student.Studies.Name] = st[student.Studies.Name] + 1;
                }
                else
                {
                    st[student.Studies.Name] = 1;
                }
            }

            ActiveStudies = st
                .Select(n => new ActiveStudies
                {
                    Name = n.Key,
                    
                    NumberOfStudents = n.Value
                })
                .ToArray();
        }

        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public Student[] Students { get; set; }
        public ActiveStudies[] ActiveStudies { get; set; }
    }
}