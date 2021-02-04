using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cw2.Utils;

namespace Cw2.Data
{
    public class DataReader
    {
        private readonly Options.Options options;
        
        public DataReader(Options.Options options)
        {
            this.options = options;
        }


        public IEnumerable<Student> GetRecords()
        {
            using var stream = new StreamReader(new FileInfo(options.InputFileName).OpenRead());
            
            string line;
            var students = new List<Student>();
            
            while ((line = stream.ReadLine()) != null)
            {
                var student = line.Split(',');
                if(!CheckStudentIsCorrect(student))
                    continue;
                
                var st = GetStudent(student);
                if (!students.Any(s =>
                    s.FirstName == st.FirstName && s.Surname == st.Surname && s.StudentNumber == st.StudentNumber))
                {
                    students.Add(st);
                }
            }

            return students.ToArray();
        }

        private static Student GetStudent(string[] student)
        {
            var st = new Student
            {
                FirstName = student[0],
                Surname = student[1],
                Studies = new Studies
                {
                    Name = student[2],
                    Mode = student[3]
                },
                StudentNumber = student[4],
                Birthdate = DateTime.Parse(student[5]),
                Email = student[6],
                MothersName = student[7],
                FathersName = student[8]
            };
            return st;
        }

        private bool CheckStudentIsCorrect(string[] student)
        {
            if (student.Length != 9)
            {
                Logger.LogStudent(student);
                return false;
            }

            if (student.Any(string.IsNullOrWhiteSpace))
            {
                Logger.LogStudent(student);
                return false;
            }
            
            return true;
        }
    }
}