using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace divisionDeGrupos
{
    public class InputClass
    {
        public void ArgumentsInput(string[] args)
        {
            if (args[1] is null || args[2] is null)
            {
                throw new ArgumentNullException();
            }

            string[] students;
            string[] subjects;
            int groups;

            try
            {
                groups = int.Parse(args[0]);
                string pathEst = args[1], pathTemas = args[2];

                if (groups == 0)
                {
                    throw new DivideByZeroException("No puede haber 0 grupos.");
                }
                else if (groups < 0)
                {
                    throw new ArgumentException("La cantidad de grupos debe ser positiva: mayor o igual a 1.");
                }
                // try
                // {

                // }
                // catch (FileNotFoundException e)
                // {

                // }
                students = System.IO.File.ReadAllLines(pathEst); //guardar lineas del archivo a un array (por lineas)
                subjects = System.IO.File.ReadAllLines(pathTemas);

            }
            catch (Exception)
            {
                Console.WriteLine("\nWrong format!!\nThe correct format is --> Ej: (numberOfGroups)5 (FileDirection)students.txt (FileDirection)groups.txt\nAlso you need to put the file in the correct folder\n");
                throw;
            }
            List<string> studentList = new List<string>(students);
            List<string> subjectsList = new List<string>(subjects);

            GroupManager manager = new GroupManager();

            Group[] arrangedGroups = manager.GetRandomizedGroups(studentList, subjectsList, groups);

            Console.WriteLine("\nBienvenido, aqui esta su division de grupo:");
            foreach (var group in arrangedGroups)
            {
                group.Print();
            }
        }
    }
}