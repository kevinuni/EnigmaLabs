using System.ComponentModel;

namespace ConsoleTest.GetStudentModel
{
    public class Qualifications
    {
        [DescriptionAttribute("Id")]
        public int Id { get; set; }

        [DescriptionAttribute("Primera nota")]
        public int Score1 { get; set; }

        [DescriptionAttribute("Segunda nota")]
        public int Score2 { get; set; }

        public Qualifications(int id, int nota1, int nota2)
        {
            Id = id;
            Score1 = nota1;
            Score2 = nota2;
        }

        public Qualifications()
        { }
    }
}