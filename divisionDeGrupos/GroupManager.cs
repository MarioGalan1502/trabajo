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
        public List<string> GetFileList(string directory)
        {
            string[] fileList = File.ReadAllLines(directory);
            

            return new List<string>(fileList);

        }
        //do {numero = random()} while(numero == x || numero == y)
        public string[][] randomizeInGroups(List<string> elements, int numberOfGroups)
        {
            Random random = new Random();
            int indexElement = random.Next(elements.Length);
            
            
            //bucle (mientras haya elementos en la lista)
            // Generar num random de 0 a length (tiene que ser ajustado cada vez al length actual)
            // tomar elemento en indice generado por random
            // Borrarlo de la lista inicial
            //Generar num random de 0 a numberOfGroups
            //Chequear si arreglo de indice numero random esta lleno, si lo esta, generar nuevo numero hasta que no este lleno.
            //Insertar elemento en el arreglo de indice numero random
            

        }

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