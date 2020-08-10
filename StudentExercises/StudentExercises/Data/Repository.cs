using StudentExercises.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;

namespace StudentExercises.Data
{
    class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        //Query the database for all the Exercises.
        public List<Exercise> GetAllExercises()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int nameColumnPosition = reader.GetOrdinal("Name");
                        string nameValue = reader.GetString(nameColumnPosition);

                        int languageColumnPosition = reader.GetOrdinal("Language");
                        string languageValue = reader.GetString(languageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = nameValue,
                            Language = languageValue
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        //Find all the exercises in the database where the language is JavaScript.
        public List<Exercise> GetAllJSExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise WHERE Language = 'Javascript'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int nameColumnPosition = reader.GetOrdinal("Name");
                        string nameValue = reader.GetString(nameColumnPosition);

                        int languageColumnPosition = reader.GetOrdinal("Language");
                        string languageValue = reader.GetString(languageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = nameValue,
                            Language = languageValue
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        //Insert a new exercise into the database.
        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Exercise (Name, Language) OUTPUT INSERTED.Id Values (@name, @language)";
                    cmd.Parameters.Add(new SqlParameter("@name", exercise.Name));
                    cmd.Parameters.Add(new SqlParameter("@language", exercise.Language));

                    int id = (int)cmd.ExecuteScalar();

                    exercise.Id = id;
                }
            }
        }

        //Find all instructors in the database. Include each instructor's cohort.
        public List<Instructor> GetAllInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Instructor.Id, FirstName, LastName, SlackHandle, Speciality, Name FROM Instructor LEFT JOIN Cohort ON Instructor.CohortId = Cohort.Id;";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int FirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(FirstNameColumnPosition);

                        int LastNameColumnPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(LastNameColumnPosition);

                        int SlackHandleColumnPosition = reader.GetOrdinal("SlackHandle");
                        string slackValue = reader.GetString(SlackHandleColumnPosition);

                        int SpecialityColumnPosition = reader.GetOrdinal("Speciality");
                        string specialityValue = reader.GetString(SpecialityColumnPosition);

                        int CohortNameColumnPosition = reader.GetOrdinal("Name");
                        string cohortNameValue = reader.GetString(CohortNameColumnPosition);

                        Instructor instructor = new Instructor
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            SlackHandle = slackValue,
                            Specialty = specialityValue,
                            Cohort = new Cohort { Name = cohortNameValue }
                        };

                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return instructors;
                }
            }
        }

        //Insert a new instructor into the database.Assign the instructor to an existing cohort.
        public void AddInstructor(Instructor instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Instructor (FirstName, LastName, SlackHandle, Speciality, CohortId) OUTPUT INSERTED.Id Values (@firstName, @lastName, @slack, @speciality, @cohortId)";
                    cmd.Parameters.Add(new SqlParameter("@firstName", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@slack", instructor.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@speciality", instructor.Specialty));
                    cmd.Parameters.Add(new SqlParameter("@cohortId", instructor.Cohort.Id));

                    int id = (int)cmd.ExecuteScalar();

                    instructor.Id = id;
                }
            }
        }

        //Assign an existing exercise to an existing student.
        public void AssignExercise(AssignedExercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO AssignedExercise (StudentId, ExerciseId) OUTPUT INSERTED.Id Values (@studentId, @exerciseId)";
                    cmd.Parameters.Add(new SqlParameter("@studentId", exercise.StudentId));
                    cmd.Parameters.Add(new SqlParameter("@exerciseId", exercise.ExerciseId));

                    int id = (int)cmd.ExecuteScalar();

                    exercise.Id = id;
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Student.Id, Student.FirstName, Student.LastName, Exercise.Name AS ExerciseName, Cohort.Name AS CohortName FROM Student LEFT JOIN AssignedExercise ON AssignedExercise.StudentId = Student.Id LEFT JOIN Exercise ON AssignedExercise.ExerciseId = Exercise.Id LEFT JOIN Cohort ON Student.CohortId = Cohort.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int FirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(FirstNameColumnPosition);

                        int LastNameColumnPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(LastNameColumnPosition);

                        int CohortNameColumnPosition = reader.GetOrdinal("CohortName");
                        string cohortNameValue = reader.GetString(CohortNameColumnPosition);

                        Student student = new Student
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            Cohort = new Cohort { Name = cohortNameValue }
                        };



                        //Conditional for if the student does NOT already exist in the 'students' list
                        if (students.Any(stud => stud.Id == student.Id) == false)
                        {
                            //Conditional for if the student has atleast one exercise assigned to them, this code runs; reads as if "ExerciseName" does NOT return a null value
                            if (!reader.IsDBNull(reader.GetOrdinal("ExerciseName")))
                            {
                                //Create instance of Exercise
                                Exercise exercise = new Exercise
                                {
                                    Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                    Language = ""
                                };

                                //Add it to the student's assignedExercises list
                                student.assignedExercises.Add(exercise);

                            }
                            //Add the student to the students list to be returned
                            students.Add(student);
                        }

                        //If the student does already exist in the students list (i.e. the same student prints multiple times if they have more than one exercise assigned to them)
                        else
                        {
                            //If "ExerciseName" does NOT return a null value; meaning the existing student has more exercises assigned to them
                            if (!reader.IsDBNull(reader.GetOrdinal("ExerciseName")))
                            {
                                //Create instance of exercise
                                Exercise exercise = new Exercise
                                {
                                    Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                    Language = ""
                                };

                                //Add the exercise to the student's assignedExercises list; FirstOrDefault refers to the first (or default) student id that pops up and matches
                                students.FirstOrDefault(s => s.Id == student.Id).assignedExercises.Add(exercise);
                            }

                        }

                    }

                    reader.Close();

                    return students;

                }
            }
        }

        //Write a method in the Repository class that accepts an Exercise and a Cohort and assigns that exercise to
        //    each student in the cohort IF and ONLY IF the student has not already been assigned the exercise.
        public void AssignExerciseToCohort(Exercise exercise, Cohort cohort)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Student.Id, FirstName, LastName, CohortId, Exercise.Name AS ExerciseName FROM Student LEFT JOIN AssignedExercise ON Student.Id = AssignedExercise.StudentId LEFT JOIN Exercise ON AssignedExercise.ExerciseId = Exercise.Id WHERE Student.CohortId = @cohortid; ";
                    cmd.Parameters.Add(new SqlParameter("@cohortid", cohort.Id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int FirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(FirstNameColumnPosition);

                        int LastNameColumnPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(LastNameColumnPosition);

                        int CohortIdColumnPosition = reader.GetOrdinal("CohortId");
                        int cohortIdValue = reader.GetInt32(CohortIdColumnPosition);

                        Student student = new Student
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            Cohort = new Cohort { Id = cohortIdValue }
                        };

                        if (cohort.listOfStudents.Any(stud => stud.Id == student.Id) == false)
                        {
                            //Conditional for if the student has atleast one exercise assigned to them, this code runs; reads as if "ExerciseName" does NOT return a null value
                            if (!reader.IsDBNull(reader.GetOrdinal("ExerciseName")))
                            {
                                //Create instance of Exercise
                                Exercise existingExercise = new Exercise
                                {
                                    Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                    Language = ""
                                };

                                //Add it to the student's assignedExercises list
                                student.assignedExercises.Add(exercise);

                            }
                            //Add the student to the cohort's list of students
                            cohort.listOfStudents.Add(student);
                        }

                        //If the student does already exist in the cohort's list (i.e. the same student prints multiple times if they have more than one exercise assigned to them)
                        else
                        {
                            //If "ExerciseName" does NOT return a null value; meaning the existing student has more exercises assigned to them
                            if (!reader.IsDBNull(reader.GetOrdinal("ExerciseName")))
                            {
                                //Create instance of exercise
                                Exercise existingExercise = new Exercise
                                {
                                    Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                    Language = ""
                                };

                                //Add the exercise to the student's assignedExercises list; FirstOrDefault refers to the first (or default) student id that pops up and matches
                                cohort.listOfStudents.FirstOrDefault(s => s.Id == student.Id).assignedExercises.Add(existingExercise);
                            }

                        }
                    }
                    reader.Close();

                    //By now, each student in the cohort should have a list of assigned exercises, so we can grab each student in the cohort to check thier assignedExercises
                    foreach (Student cohortStudent in cohort.listOfStudents)
                    {
                            //if the student has not been assigned the exercise, assign it
                            if (cohortStudent.assignedExercises.Exists(ex => ex.Id == exercise.Id) == false)
                            {
                                    Console.WriteLine($"I'm in here!!!!!!!!!!!!!");
                                    cmd.CommandText += $"INSERT INTO AssignedExercise (StudentId, ExerciseId) OUTPUT INSERTED.Id Values ({cohortStudent.Id}, @getExerciseId)";

                            }
                    }

                    cmd.Parameters.Add(new SqlParameter("@getExerciseId", exercise.Id));

                    //Use this if you don't need to return anything
                    cmd.ExecuteNonQuery();

                    //use int id = (int)cmd.ExecuteScalar(); if you need to return an id in the first column
                }

            }

        }

    }

}
