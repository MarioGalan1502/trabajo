using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace divisionDeGrupos
{
    public class GroupManager
    {
<<<<<<< HEAD

        //metodo sacar numeros random (rango especificado) que
=======
        //Metodo sacar numeros random (rango especificado)
>>>>>>> 5e74942e4fa434795312b2efe21761c901c0aec0
        public int RandomNumWithExceptions(int inicio, int final, List<int> exceptions)
        {
            int randomIndex = 0;
            var rand = new Random();

            if (exceptions == null || exceptions.Count == 0)
            {
                return rand.Next(inicio, final);
            }
            else
            {
                do
                {
                    randomIndex = rand.Next(inicio, final);
                }
                while (exceptions.Contains(randomIndex));
            }

            return randomIndex;
        }

        public List<string> GetFileList(string directory)
        {
            string[] fileList = File.ReadAllLines(directory);
            return new List<string>(fileList);
        }

        //Metodo para dividir de manera random 
        public List<string>[] RandomizeGroups(List<string> elements, int numberOfGroups)
        {
            int maxGroupMembers = elements.Count / numberOfGroups;
            List<string>[] groups = new List<string>[numberOfGroups];

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = new List<string>();
            }

            List<int> exceptions = new List<int>();

            while (elements.Count > 0)
            {
                int elementIndex = RandomNumWithExceptions(0, elements.Count, null);

                string elementString = elements[elementIndex];

                elements.RemoveAt(elementIndex);
                int groupNumber = RandomNumWithExceptions(0, numberOfGroups, exceptions);

                groups[groupNumber].Add(elementString);

                if (groups[groupNumber].Count == maxGroupMembers)
                {
                    exceptions.Add(groupNumber);

                    if (exceptions.Count == numberOfGroups)
                    {
                        exceptions.Clear();
                        maxGroupMembers++;
                    }


                }

            }
            return groups;
            //bucle (mientras haya elementos en la lista)
            // Generar num random de 0 a length (tiene que ser ajustado cada vez al length actual)
            // tomar elemento en indice generado por random
            // Borrarlo de la lista inicial
            //Generar num random de 0 a numberOfGroups
            //Chequear si arreglo de indice numero random esta lleno, si lo esta, llamar a funcion del random hasta que el grupo no este lleno
            //Insertar elemento en el arreglo de indice numero random
        }

        //Retorna un arreglo con las listas de estudiantes y temas ya randomizados
        public Group[] GetRandomizedGroups(List<string> students, List<string> subjects, int numberOfGroups)
        {
            List<string>[] arrangedStudents = RandomizeGroups(students, numberOfGroups);
            List<string>[] arrangedSubjects = RandomizeGroups(subjects, numberOfGroups);
            Group[] arrangedGroups = new Group[numberOfGroups];

            for (int i = 0; i < arrangedGroups.Length; i++)
            {
                arrangedGroups[i] = new Group();

                arrangedGroups[i].Number = i + 1;
                arrangedGroups[i].Students = arrangedStudents[i].ToArray();
                arrangedGroups[i].Subjects = arrangedSubjects[i].ToArray();
            }

            return arrangedGroups;
        }
    }
}