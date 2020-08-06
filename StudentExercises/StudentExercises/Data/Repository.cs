using StudentExercises.Models;
using System;
using System.Collections.Generic;
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

        public List<AssignedExercise> GetAllAssignedExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CONCAT(Student.FirstName, ' ', Student.LastName), Exercise.Name FROM AssignedExercise LEFT JOIN Student ON AssignedExercise.StudentId = Student.Id LEFT JOIN Exercise ON AssignedExercise.ExerciseId = Exercise.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<AssignedExercise> assignedExercises = new List<AssignedExercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("AssignedExercise.Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int StudentIdColumnPosition = reader.GetOrdinal("StudentId");
                        int studentdIdValue = reader.GetInt32(StudentIdColumnPosition); 

                        int ExerciseIdColumnPosition = reader.GetOrdinal("ExerciseId");
                        int exerciseIdValue = reader.GetInt32(ExerciseIdColumnPosition);

                        //int FirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        //string firstNameValue = reader.GetString(FirstNameColumnPosition);

                        //int LastNameColumnPosition = reader.GetOrdinal("LastName");
                        //string lastNameValue = reader.GetString(LastNameColumnPosition);

                        //int ExerciseNameColumnPosition = reader.GetOrdinal("Name");
                        //string exNameValue = reader.GetString(ExerciseNameColumnPosition);

                        AssignedExercise assignedExercise = new AssignedExercise
                        {
                            Id = idValue,
                            StudentId = studentdIdValue,
                            ExerciseId = exerciseIdValue
                        };

                        assignedExercises.Add(assignedExercise);
                    }

                    reader.Close();

                    return assignedExercises;
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

                        //if (students)
                        Student student = new Student
                        {
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            Cohort = new Cohort { Name = cohortNameValue }
                            //SlackHandle = slackValue,
                            //Cohort = new Cohort { Name = cohortNameValue }
                        };

                        
                        

                        if (students.Any(stud => stud.FirstName == student.FirstName) == false)
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("ExerciseName")))
                            {
                                Exercise exercise = new Exercise
                                {
                                    Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                    Language = "hi"
                                };

                                student.assignedExercises.Add(exercise);

                            }
                            
                            students.Add(student);
                        }
                        else
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("ExerciseName")))
                            {
                                Exercise exercise = new Exercise
                                {
                                    Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                    Language = "hi"
                                };

                                students.FirstOrDefault(s => s.FirstName == student.FirstName).assignedExercises.Add(exercise);
                            }

                        }
                        
                    }

                    reader.Close();

                    return students;
                }
            }
        }



    }

}
