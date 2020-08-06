using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }

        public List<Student> assignedStudents { get; set; } = new List<Student>();


        //public Exercise(string name, string language)
        //{
        //    Name = name;
        //    Language = language;
        //}
    }
}
