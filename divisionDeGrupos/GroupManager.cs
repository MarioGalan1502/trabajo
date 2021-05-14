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
        //metodo sacar numeros random (rango especificado) que
        public int RandomNumWithExceptions(int inicio, int final, List<int> exceptions)
        {
            int randomIndex = 0;
            var rand = new Random();

            if (exceptions == null)
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
            // IEnumerable<int> range;
            // int exceptionsCount = exceptions == null ? 0 : exceptions.Count;

            // if (exceptions == null)
            // {
            //     range = Enumerable.Range(inicio, final);
            // }
            // else
            // {
            //     range = Enumerable.Range(inicio, final).Where(i => !exceptions.Contains(i));
            // }

            // var rand = new Random();
            // //[0,3,4
            // //
            // int index = rand.Next(inicio, final - exceptionsCount);
            // return range.ElementAt(index);
        }
        public List<string> GetFileList(string directory)
        {
            string[] fileList = File.ReadAllLines(directory);


            return new List<string>(fileList);

        }
        //do {numero = random()} while(numero == x || numero == y)

        //metodo para dividir de manera random 
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
                int groupNumber = RandomNumWithExceptions(0, numberOfGroups, null);
                //<3,3,3,2,3>

                //1
                if (groups[groupNumber].Count == maxGroupMembers)
                {

                    if (exceptions.Count == numberOfGroups)
                    {
                        exceptions.Clear();
                        numberOfGroups++;
                    }

                    groupNumber = RandomNumWithExceptions(0, numberOfGroups, exceptions);
                    groups[groupNumber].Add(elementString);

                }
                else
                {
                    groups[groupNumber].Add(elementString);


                }

                if (groups[groupNumber].Count == maxGroupMembers)
                {
                    exceptions.Add(groupNumber);
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
        // private string[][] GetRandomizedGroups(List<string> elements, int numberOfGroups)
        // {
        //     Random random = new Random();
        //     int indexElement = random.Next(elements.Count);
        //     int numeroDeIntegrantesPorGrupo = elements.Count / numberOfGroups;
        //     int remanente = elements.Count % numberOfGroups;


        //     RandomizeGroups(elements, numberOfGroups);

        //     //Condicion de remanente (remanente > 0)
        //     //numeroDeIntegrantesPorGrupo++
        //     //randomizeGroups()



        // }

        //getDistributionGroups(List<string> estudiantes, list temas) : List<Group>
        // Group -> {estudiantes, temas}
        // Input: Lista de estudiantes, lista de temas, el numero de grupos
        // Asignar estudiantes a x grupos random
        //Asignar temas a x grupos random
        // Output: [{},{},{}]
        //class Grupo { property estudiantes, temas}
        // List<Grupo>
        //Lista de arreglos de grupos: [ {hd, dh,ndj,jd}, {hs,hsy,shs,js}, {}, {}, {}]
        //Lista de arreglos de grupos: [ {tema 1}, {tema2}, {}, {}, {}]
        //Output: Lista[0]

    }
}