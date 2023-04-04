using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ControlsUIDemo
{
    public class Person
    {
        [DescriptionAttribute("Id")]
        public int Id { get; set; }

        [DescriptionAttribute("First Name")]
        public string FirstName { get; set; }

        [DescriptionAttribute("Last Name")]
        public string LastName { get; set; }

        [DescriptionAttribute("Scores")]
        public List<Score> lstScores = new List<Score>();

        public Person()
        {
        }

        public Person(int id, string nombre, string apellido, List<Score> notas)
        {
            FirstName = nombre;
            LastName = apellido;
            Id = id;
            lstScores = notas;
        }

        public static List<Person> GetPersons()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person(1, "Bart", "Simpson", 
                new List<Score>{
                    new Score(1, 10, 15),
                    new Score(2, 12, 20),
                    new Score(3, 5, 23)
            }));
            list.Add(new Person(2, "Clarck", "Kent", new List<Score>{
                    new Score(4, 67, 46),
                    new Score(4, 33, 83),
                    new Score(5, 99, 36)
            }));
            list.Add(new Person(3, "Bruno", "Diaz", new List<Score>{
                    new Score(6, 46, 87),
                    new Score(7, 44, 38),
                    new Score(9, 56, 90)
            }));

            return list;
        }

    }
}