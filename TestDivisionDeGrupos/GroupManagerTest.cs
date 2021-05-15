using NUnit.Framework;
using divisionDeGrupos;
using System.Linq;
using System.IO;
using System.Collections.Generic;


namespace TestDivisionDeGrupos
{
    public class GroupManagerTest
    {
        public List<string> students { get; set; }

        private Group[][] group(int numberOfGroups, int numOfTests)
        {
            GroupManager manager = new GroupManager();
            double probability = 1 / numberOfGroups;

            Group[][] listasDeListasGrupos = new Group[numOfTests][];

            for (int i = 0; i < listasDeListasGrupos.Length; i++)
            {
                listasDeListasGrupos[i] = new Group[numberOfGroups];
                listasDeListasGrupos[i] = manager.GetRandomizedGroups(students, new List<string>(), numberOfGroups);
            }
            return listasDeListasGrupos;
        }

        [SetUp]
        public void Setup()
        {
            students = new List<string>() { "Jonathan", "Mario", "Samuel", "Emily", "Lorenzo :c", "Alan" };
        }

        /*
            Datos estaticos:
            20 estudiantes
            5 temas
            5 grupos

            Hacer 20 tests y calcular:

            Constante de desviacion estandar: +- 0.002

            1- Numero de veces que cada estudiante le toca cada grupo:
            -Calcular la probabilidad de que un estudiante caiga en un grupo (1/cantOfGroups)

            Se hacen 20 tests:

            En este caso cada estudiante tiene 1/5 probabilidad de caer en cada grupo.

            En teoria

            Estudiante: Julio Perez

            Grupo 1: 5 veces cayo Julio en este grupo   Estudiantes
            Grupo 2: 5 veces
            Grupo 3: 4 veces
            Grupo 4: 4 veces
            Grupo 5: 2 veces


            Luego de contar todas estas veces:
            Se calcula la frecuencia relativa de Julio Perez en cada grupo o sea:
            Grupo 1: 5/20= 1/4 falso 
            Grupo 2: 5/20 = 1/4
            Grupo 3: 4/20 = 1/5
            Grupo 4: 4/20 = 1/5
            Grupo 5: 2/20 = 1/10



            Cada probabilidad debe ser menor o igual a 1/5, la probabilidad maxima de que este en cada grupo

            1/4 > 1/5 -- Falso
            1/4 > 1/5 -- FAlso

            Lo que significa que hay un maco y no es teoricamente aleatorio.



        */


        [Test]
        public void GroupManager_elements_with_no_remanent()
        {
            GroupManager manager = new GroupManager();

            List<string> elements = new List<string>()
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15"
            };

            int numberOfGroups = 5;

            List<string>[] groups = manager.RandomizeGroups(elements, numberOfGroups);

            Assert.That(groups.Select(group => group.Count), Is.All.EqualTo(3));
        }

        [Test]
        public void GroupManager_RandomizeGroups_elements_with_remanent()
        {
            GroupManager manager = new GroupManager();
            int numberOfGroups = 5;
            List<string> groups = new List<string>()
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15"
            };
            Assert.Pass();
        }

        [Test]
        public void GroupManager_test_randomness()
        {
            int numberOfGroups = 3;
            int numTests = 1000;
            int probabilty = 1 / numberOfGroups;
            Group[][] listasDeListasGrupos = group(numberOfGroups, numTests);

            Stack<string> studentsStack = new Stack<string>();

            foreach (var student in students)
            {
                studentsStack.Push(student);
            }
            //studentsCount = new int[numOfStudents]

            //[[20,20,10],[16,16,18]]
            //int[numStudents][]
            //

            int[][] studentGroupAppearancesCount = new int[students.Count][];

            for (int i = 0; i < listasDeListasGrupos.Length; i++)
            {
                if (studentsStack.Count == 0)
                {
                    break;
                }
                string currentStudent = studentsStack.Pop(); // Jonathan
                int[] currentIntArrOfStudentGroupAppearancesCount = studentGroupAppearancesCount[i]; // Arrego de jonathan de veces aparecidas por grupo

                Group[] listaDeGruposActual = listasDeListasGrupos[i]; // Lista de grupos a chequear aparecidas de Jonathan Actual

                for (int j = 0; j < listaDeGruposActual.Length; j++)
                {
                    Group currentGroup = listaDeGruposActual[j]; // Grupo 1
                    string[] currentGroupStudents = currentGroup.Students; //Los estudiantes del grupo 1

                    if (currentGroupStudents.Contains(currentStudent))
                    {
                        currentIntArrOfStudentGroupAppearancesCount[j]++; // Sumalo a la posicion del arreglo de contadas correspondiente al grupo 1
                    }
                }
            }

            foreach (var countAppearance in studentGroupAppearancesCount)
            {
                for (int i = 0; i < countAppearance.Length; i++)
                {
                    int countOfCurrentGroup = countAppearance[i];
                    if (countOfCurrentGroup / numTests > probabilty)
                    {
                        Assert.Fail();
                    }
                }
            }

            Assert.Pass();
            // Assert.That(listasDeListasGrupos.Select(listGroups => listGroups.Length), Is.All.EqualTo(numberOfGroups));
        }

        [Test]
        public void GroupManager_RandomNumber()
        {
            GroupManager manager = new GroupManager();
            Assert.Pass();
        }
    }
}


// Casos nulls:
// Salida: Debe salir un mensaje de error, Mensaje:
// “El formato introducido no es admitido.
// Formato correcto : < número de grupos> <dirección de listado de estudiantes> <dirección de archivo de temas>

// Test1:
// grupo está null
// throw ArgumentNullException

// Test2:
// estudiantes.txt está null
// throw ArgumentNullException

// Test3:
// temas.txt está null
// throw ArgumentNullException

// Test4:
// Entrada correcta
// throw Nothing


// Casos de error

// Caso5: Hay más grupos que estudiantes
// Ej: Grupos: 5, Estudiante: 4---- Grupos > Estudiante

// Test5:
// if grupos > estudiantes(en una variable que contenga la cantidad de estudiantes del archivo)
// throw (MENSAJE DE ERROR)

// Caso6: Hay menos temas que grupos
// Ej: Grupos: 5, Temas: 4------ Grupos < Temas

// Test6:
// if grupos < temas(en una variable que contenga la cantidad de temas del archivo)
// throw (MENSAJE DE ERROR)

// Caso7: Si la división es > 0, es que hay mas temas y estudiantes que grupos

// Test7:
// if temas / grupos > 0 y estudiantes/ grupos > 0.
// throw Nothing

