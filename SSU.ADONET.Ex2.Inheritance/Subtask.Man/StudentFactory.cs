using System;

namespace SSU.ADONET.Ex2.Inheritance.Subtask.Man
{
    public class StudentFactory
    {
        private Student _student = new Student();

        public void CreateStudent(string firstName = "Noname", int age = 0, double weight = 0, double height = 0,
            DateTime startTrainingDate = new DateTime(), int courseNumber = 0, int groupNumber = 0)
        {
            _student.FirstName = firstName;
            _student.Age = age;
            _student.Weight = weight;
            _student.Height = height;

            _student.StartTrainingDate = startTrainingDate;
            _student.CourseNumber = courseNumber;
            _student.GroupNumber = groupNumber;
        }

        public Student GetStudent()
        {
            Man tmp = new Student(_student);
            _student = new Student();

            return _student;
        }
    }
}
