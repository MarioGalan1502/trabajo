using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace divisionDeGrupos
{
    public class Group
    {
        public int Number { get; set; }
        public string[] Students { get; set; }

        public string[] Subjects { get; set; }

        public void Print()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.Write($"Grupo: {Number}");
            Console.Write("  Temas: ");
            for (int i = 0; i < Subjects.Length; i++)
            {
                Console.Write($" {Subjects[i]},");
            }
            Console.WriteLine(" ");
            for (int i = 0; i < Students.Length; i++)
            {
                Console.WriteLine($"{Students[i]}");
            }
        }
    }
}

// Grupo #1 (Temas: Historia, Cultura )
//  Fulano
//  Mengano

//getDistributionGroups(List<string> estudiantes, list temas) : List<Group>
// Group -> { List<string> estudiantes, temas}

// Input: Lista de estudiantes, lista de temas, el numero de grupos
// Asignar estudiantes a x grupos random
//Asignar temas a x grupos random
// Output: [{},{},{}]
//class Grupo { property estudiantes, temas}
// List<Grupo>
//Lista de arreglos de grupos: [ {hd, dh,ndj,jd}, {hs,hsy,shs,js}, {}, {}, {}]
//Lista de arreglos de grupos: [ {tema 1}, {tema2}, {}, {}, {}]
//Output: Lista[0]