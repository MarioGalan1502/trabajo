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
            Console.WriteLine("\nBienvenido, aqui esta su division de grupo\n");

            int groups = int.Parse(args[0]);
            string pathEst = args[1], pathTemas = args[2];

            try
            {
                string[] students = System.IO.File.ReadAllLines(pathEst); //guardar lineas del archivo a un array (por lineas)
                string[] subjects = System.IO.File.ReadAllLines(pathTemas);


                List<string> studentList = new List<string>(students);
                List<string> subjectsList = new List<string>(subjects);

                GroupManager manager = new GroupManager();

                Group[] arrangedGroups = manager.GetRandomizedGroups(studentList, subjectsList, groups);

                foreach (var group in arrangedGroups)
                {
                    group.Print();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong format!!\nThe correct format is --> Ej: 5 C:/User1/Desktop/StudentsFile/students.txt C:/User/Desktop/Groups/groups.txt\nAlso the filn");
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
