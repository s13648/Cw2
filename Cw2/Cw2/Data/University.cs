using System;
using System.Collections.Generic;

namespace Cw2.Data
{
    public class University
    {
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public Student[] Students { get; set; }
        public Studies[] ActiveStudies { get; set; }
    }
}