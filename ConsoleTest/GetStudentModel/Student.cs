using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleTest.GetStudentModel
{
    public class Student
    {
        [DescriptionAttribute("Id")]
        public int Id { get; set; }

        [DescriptionAttribute("Student First Name")]
        public string FirstName { get; set; }

        [DescriptionAttribute("Student Last Name")]
        public string LastName { get; set; }

        [DescriptionAttribute("Qualifications")]
        public List<Qualifications> lstQualifications = new List<Qualifications>();

        [DescriptionAttribute("Course Names")]
        public List<Course> lstCourses = new List<Course>();

        public Student()
        {
        }

        public static List<Student> getStudents()
        {
            List<Student> list = new List<Student>()
            {
                new Student() { 
                    Id = 1, 
                    FirstName = "Morty", 
                    LastName = "Smith", 
                    lstQualifications = {
                        new Qualifications(1, 10, 15),
                        new Qualifications(2, 12, 20),
                        new Qualifications(3, 5, 23)
                    }, 
                    lstCourses = {
                        new Course() { Subject = "Principal", Teacher = "Gene Vagina", Credits = 10 },
                        new Course() { Subject = "Math", Teacher = "Mr. Goldenfold", Credits = 10 }
                    },
                },
                new Student() { 
                    Id = 1, 
                    FirstName = "Rick", 
                    LastName = "Sanchez",
                    lstQualifications = {
                        new Qualifications(4, 44, 90),
                        new Qualifications(5, 55, 80),
                        new Qualifications(6, 66, 70)
                    },
                    lstCourses = {
                        new Course() { Subject = "Science", Teacher = "Mr Hide", Credits = 4 },
                        new Course() { Subject = "Laws", Teacher = "Dr. Jekyll", Credits = 7 }
                    },
                },
                new Student() { 
                    Id = 1, 
                    FirstName = "John", 
                    LastName = "Doe",
                    lstQualifications = {
                        new Qualifications(7, 37, 94),
                        new Qualifications(8, 45, 84),
                        new Qualifications(9, 89, 74)
                    },
                    lstCourses = {
                        new Course() { Subject = "Principal", Teacher = "Chester", Credits = 8 },
                        new Course() { Subject = "Math", Teacher = "Spike", Credits = 3 }
                    },
                }
            };

            return list;
        }
    }
}