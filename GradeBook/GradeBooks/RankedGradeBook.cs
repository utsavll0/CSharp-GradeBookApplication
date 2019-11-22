
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
            var totalStudents = Students.Count;
            var perCentCount = (cntGreaterThanGiven / totalStudents) * 100;
            if(perCentCount<=20)
            {
                return 'A';
            }
            if (perCentCount <= 40 && perCentCount>20)
            {
                return 'B';
            }
            if (perCentCount <= 60 && perCentCount >40)
            {
                return 'C';
            }
            if(perCentCount<=80 && perCentCount>60)
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
