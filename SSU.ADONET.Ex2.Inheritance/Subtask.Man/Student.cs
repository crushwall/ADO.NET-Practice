using System;

namespace SSU.ADONET.Ex2.Inheritance.Subtask.Man
{
    public class Student : Man
    {
        public DateTime StartTrainingDate { get; set; }

        public int CourseNumber { get; set; }

        public int GroupNumber { get; set; }

        public Student() { }

        public Student(Student previousStudent)
        {
            FirstName = previousStudent.FirstName;
            Age = previousStudent.Age;
            Weight = previousStudent.Weight;
            Height = previousStudent.Height;

            StartTrainingDate = previousStudent.StartTrainingDate;
            CourseNumber = previousStudent.CourseNumber;
            GroupNumber = previousStudent.GroupNumber;
        }
    }
}
