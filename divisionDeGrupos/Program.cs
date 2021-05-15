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
            try
            {
                int groups = int.Parse(args[0]);
                string pathEst = args[1], pathTemas = args[2];

                string[] students = System.IO.File.ReadAllLines(pathEst); //guardar lineas del archivo a un array (por lineas)
                string[] subjects = System.IO.File.ReadAllLines(pathTemas);


                List<string> studentList = new List<string>(students);
                List<string> subjectsList = new List<string>(subjects);

                if (groups > studentList.Count)
                {
                    throw new ArgumentException("La cantidad de grupos no puede ser mayor que la cantidad de estudiantes");
                }
                if (groups > subjectsList.Count)
                {
                    throw new ArgumentException("La cantidad de grupos no puede ser mayor que la cantidad de temas");
                }
                
                GroupManager manager = new GroupManager();

                Group[] arrangedGroups = manager.GetRandomizedGroups(studentList, subjectsList, groups);

                Console.WriteLine("\nBienvenido, aqui esta su division de grupo:");
                foreach (var group in arrangedGroups)
                {
                    group.Print();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong format!!\nThe correct format is --> Ej: (numberOfGroups)5 (FileDirection)students.txt (FileDirection)groups.txt\nAlso the file");
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
