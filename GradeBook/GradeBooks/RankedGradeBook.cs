
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count<5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            var cntGreaterThanGiven = 0;
            foreach(var student in Students)
            {
                if(averageGrade>student.AverageGrade)
                {
                    cntGreaterThanGiven++;
                }
            }
            var thresholdCount20 = Students.Count * 0.2;
            var thresholdCount40 = Students.Count * 0.4;
            var thresholdCount60 = Students.Count * 0.6;
            var thresholdCount80 = Students.Count * 0.8;
            if (cntGreaterThanGiven<=thresholdCount20)
            {
                return 'A';
            }
            if (cntGreaterThanGiven <= thresholdCount40)
            {
                return 'B';
            }
            if (cntGreaterThanGiven <= thresholdCount60)
            {
                return 'C';
            }
            if(cntGreaterThanGiven <= thresholdCount80)
            {
                return 'D';
            }
            return 'F';
        }

        public RankedGradeBook(string name):base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
    }
}
