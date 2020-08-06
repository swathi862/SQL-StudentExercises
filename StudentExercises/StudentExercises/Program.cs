using StudentExercises.Data;
using StudentExercises.Models;
using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository studentExercises = new Repository();

            //Console.WriteLine("Adding an exercise");
            //studentExercises.AddExercise(new Exercise { Name="DepartmentsEmployees", Language = "ADO.NET" });

            Console.WriteLine();
            Console.WriteLine("List of ALL Exercises:");

            List<Exercise> listOfAllExercises = studentExercises.GetAllExercises();

            foreach(Exercise exercise in listOfAllExercises)
            {
                Console.WriteLine($"{exercise.Id} {exercise.Name} {exercise.Language}");
            };

            Console.WriteLine();
            Console.WriteLine("List of JavaScript Exercises:");

            List<Exercise> listOfAllJSExercises = studentExercises.GetAllJSExercises();

            foreach (Exercise js in listOfAllJSExercises)
            {
                Console.WriteLine($"{js.Id} {js.Name} {js.Language}");
            };

            //Console.WriteLine();
            //Console.WriteLine("Adding an Instructor.");
            //Instructor willow = new Instructor
            //{
            //    FirstName = "Willow",
            //    LastName = "Bark",
            //    SlackHandle = "@willow",
            //    Specialty = "Tree Hugger",
            //    Cohort = new Cohort { Id = 3 }
            //};

            //studentExercises.AddInstructor(willow);

            Console.WriteLine();
            Console.WriteLine("List of ALL Instructors:");

            List<Instructor> listOfAllInstructors = studentExercises.GetAllInstructors();

            foreach(Instructor i in listOfAllInstructors)
            {
                Console.WriteLine($"{i.Id} {i.FirstName} {i.LastName} {i.SlackHandle} {i.Specialty} {i.Cohort.Name}");
            }

            //Console.WriteLine();
            //Console.WriteLine("Assigning an exercise");

            //AssignedExercise assignDeptEmp = new AssignedExercise
            //{
            //    StudentId = 21,
            //    ExerciseId = 8
            //};

            //studentExercises.AssignExercise(assignDeptEmp);

            //Console.WriteLine();
            //Console.WriteLine("List of Assigned Exercises:");

            //List<AssignedExercise> listOfAllAssignedExercises = studentExercises.GetAllAssignedExercises();

            //foreach (AssignedExercise ae in listOfAllAssignedExercises)
            //{
            //    Console.WriteLine($"{ae.Id} {ae.StudentId} {ae.ExerciseId}");
            //}

            Console.WriteLine();
            Console.WriteLine("List of Student:");

            List<Student> listOfAllStudents = studentExercises.GetAllStudents();

            foreach (Student s in listOfAllStudents)
            {
                //Console.WriteLine($"{s.Id} {ae.StudentId} {ae.ExerciseId}");
                foreach (Exercise ex in s.assignedExercises)
                {
                    Console.WriteLine($"{s.Cohort.Name}: {s.FirstName} {s.LastName} {ex.Name}");
                }
            }


        }
    }
}
