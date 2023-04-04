using System.Collections.Generic;

namespace ControlsUIDemo
{
    public class Course
    {
        public string Subject { get; set; }

        public string Teacher { get; set; }

        public int Credits { get; set; }

        public Course()
        { }

        public Course(string subject, string teacher)
        {
            Subject = subject;
            Teacher = teacher;
        }
    }
}