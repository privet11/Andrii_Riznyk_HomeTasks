using Automation_Home_Project.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.HomeTask2Patterns
{

    public abstract class Builder
    {
        public abstract void BuildPartA(byte score1);
        public abstract void BuildPartB(byte score2);
        public abstract Score GetScores();
    }


    public class ConcreteBuilder : Builder
    {
        private Score scores = new Score();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.scores = new Score();
        }


        public override void BuildPartA(byte score1)
        {
            scores.Score1= score1;
        }

        public override void BuildPartB(byte score2)
        {
            scores.Score2 = score2;
        }


        public override Score GetScores()
        {
            Score result = this.scores;

            this.Reset();

            return result;
        }
    }


    public class Score
    {
        public byte Score1 { get; set; }
        public byte Score2 { get; set; }

        public static bool operator ==(Score sc1, Score sc2)
        {
            return sc1.Score1 == sc2.Score1 && sc1.Score2 == sc2.Score2;
        }

        public static bool operator !=(Score sc1, Score sc2)
        {
            return sc1.Score1 != sc2.Score1 && sc1.Score2 != sc2.Score2;
        }

    }

    public class Director
    {
        private Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }


        public void BuildMinimalViableProduct(byte score1)
        {
            this.builder.BuildPartA(score1);
        }

        public void BuildFullFeaturedProduct(byte score1, byte score2)
        {
            this.builder.BuildPartA(score1);
            this.builder.BuildPartB(score2);
        }
    }
}
