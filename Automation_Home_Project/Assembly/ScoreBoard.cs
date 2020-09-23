using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.Assembly
{
    class ScoreBoard
    {

        //public Score GetScore(string team1, string team2)
        //{

        //}

    }

    public class Score
    {
        public byte Score1 { get; set; }
        public byte Score2 { get; set; }

        public static bool operator ==(Score sc1, Score sc2)
        {
            return sc1.Score1==sc2.Score1 && sc1.Score2 == sc2.Score2;
        }

        public static bool operator !=(Score sc1, Score sc2)
        {
            return sc1.Score1 != sc2.Score1 && sc1.Score2 != sc2.Score2;
        }

    }
}
