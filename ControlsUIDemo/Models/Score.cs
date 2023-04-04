using System.ComponentModel;

namespace ControlsUIDemo
{
    public class Score
    {
        [DescriptionAttribute("Id")]
        public int Id { get; set; }

        [DescriptionAttribute("First Score")]
        public int Score1 { get; set; }

        [DescriptionAttribute("Second Score")]
        public int Score2 { get; set; }

        public Score(int id, int score1, int score2)
        {
            Id = id;
            Score1 = score1;
            Score2 = score2;
        }

        public Score()
        { }
    }
}