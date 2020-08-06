using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    public class Cohort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> listOfStudents { get; set; } = new List<Student>();
        public List<Instructor> listOfInstructors { get; set; } = new List<Instructor>();

        //public Cohort(string name)
        //{
        //    Name = name;
        //}
    }
}
