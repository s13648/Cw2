using System;
using System.ComponentModel;

namespace Cw2.Data
{
    /*
     * Paweł,Nowak1,Informatyka dzienne,Dzienne,459,2000-02-12
00:00:00.000,nowak@pjwstk.edu.pl,Alina,Adam
     */
    public class Student
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Studies Studies { get; set; }
        public string StudentNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
    }
}