using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace divisionDeGrupos
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(args[0]);
            string pathEst = args[1], pathTemas = args[2];

            try
            {
                string[] students = System.IO.File.ReadAllLines(pathEst); //guardar lineas del archivo a un array (por lineas)
                string[] subjects = System.IO.File.ReadAllLines(pathTemas);


                List<string> studentList = new List<string>(students);
                List<string> subjectsList = new List<string>(subjects);

                // foreach (string item in studentList)
                // {
                //     Console.WriteLine(item);
                // }

                // foreach (string item in subjectsList)
                // {
                //     Console.WriteLine(item);
                // }

                int nStudents = students.Length; // 10 estudiantes, 5 grupos


                int estudiantesPorGrupo = nStudents / groups;
                int rem = nStudents % groups;

                // 2 estudiantes por grupo
                //Seleccionar estudiante aleatorio del arreglo
                //Asignarle un grupo
                //Eliminarlo del arreglo

                // if (rem != 0)
                // {

                // }


            }
            catch (Exception e)
            {
                // Console.WriteLine("Wrong format!!\nThe correct format is --> Ej: 5 C:/User1/Desktop/StudentsFile/students.txt C:/User/Desktop/Groups/groups.txt\nAlso the filn");
                Console.WriteLine(e);
                throw;
            }

            Public dividirgrupos()
            {

            }

            

            
        }


    }
}
