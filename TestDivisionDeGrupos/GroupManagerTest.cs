using NUnit.Framework;
using divisionDeGrupos;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System;


namespace TestDivisionDeGrupos
{
    public class GroupManagerTest
    {
        public List<string> students { get; set; }
        public List<string> subjects { get; set; }

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
            students = new List<string>() { "Jonathan", "Mario", "Samuel", "Emily", "Lorenzo", "Alan" };
            subjects = new List<string>() { "c#", "java", "python", "c++", "ruby" };
        }

        [Test]
        public void GroupManager_NumbersOfGroups_HigherThan_Students()
        {
            GroupManager manager = new GroupManager();


            Assert.That(() => manager.GetRandomizedGroups(students, subjects, 300), Throws.ArgumentException.And.Message.EqualTo("La cantidad de grupos no puede ser mayor que la cantidad de estudiantes o de temas"));
        }

        [Test]
        public void GroupManager_NumbersOfGroups_HigherThan_Subjects()
        {
            GroupManager manager = new GroupManager();

            Assert.That(() => manager.GetRandomizedGroups(students, subjects, 300), Throws.ArgumentException.And.Message.EqualTo("La cantidad de grupos no puede ser mayor que la cantidad de estudiantes o de temas"));
        }

        [Test]
        public void GroupManager_elements_with_no_remanent()
        {
            List<string> subjects = new List<string>() { "c#", "java", "python", "c++", "julia", "ruby" };
            GroupManager manager = new GroupManager();
            int numberOfGroups = 3;

            Group[] groups = manager.GetRandomizedGroups(students, subjects, numberOfGroups);


            Assert.That(groups.Select(group => group.Students.Length), Is.All.EqualTo(2));
            Assert.That(groups.Select(group => group.Subjects.Length), Is.All.EqualTo(2));
        }

        [Test]
        public void GroupManager_RandomizeGroups_elements_with_remanent()
        {

            GroupManager manager = new GroupManager();
            int numberOfGroups = 4;
            // 2 grupos de 1 y 2 de 2
            //1 de 2 y 3 de 1
            int groupsOfOne = 0, groupsOfTwo = 0, groupsWithTwoSubjects = 0, groupsWithOneSubject = 0;


            Group[] groups = manager.GetRandomizedGroups(students, subjects, numberOfGroups);

            foreach (var group in groups)
            {
                if (group.Students.Length == 1)
                {
                    groupsOfOne++;
                }
                else if (group.Students.Length == 2)
                {
                    groupsOfTwo++;
                }

                if (group.Subjects.Length == 1)
                {
                    groupsWithOneSubject++;
                }
                else if (group.Subjects.Length == 2)
                {
                    groupsWithTwoSubjects++;
                }
            }
            Assert.AreEqual(2, groupsOfOne);
            Assert.AreEqual(2, groupsOfTwo);
            Assert.AreEqual(3, groupsWithOneSubject);
            Assert.AreEqual(1, groupsWithTwoSubjects);
        }


        // [Test]
        // public void GroupManager_test_randomness()
        // {
        //     int numberOfGroups = 3;
        //     int numTests = 1000;
        //     int probabilty = 1 / numberOfGroups;
        //     Group[][] listasDeListasGrupos = group(numberOfGroups, numTests);

        //     Stack<string> studentsStack = new Stack<string>();

        //     foreach (var student in students)
        //     {
        //         studentsStack.Push(student);
        //     }
        //     //studentsCount = new int[numOfStudents]

        //     //[[20,20,10],[16,16,18]]
        //     //int[numStudents][]
        //     //

        //     int[][] studentGroupAppearancesCount = new int[students.Count][];

        //     for (int i = 0; i < studentGroupAppearancesCount.Length; i++)
        //     {
        //         studentGroupAppearancesCount[i] = new int[numberOfGroups];
        //     }

        //     for (int i = 0; i < listasDeListasGrupos.Length; i++)
        //     {
        //         if (studentsStack.Count == 0)
        //         {
        //             break;
        //         }
        //         string currentStudent = studentsStack.Pop(); // Jonathan
        //         int[] currentIntArrOfStudentGroupAppearancesCount = studentGroupAppearancesCount[i]; // Arrego de jonathan de veces aparecidas por grupo

        //         Group[] listaDeGruposActual = listasDeListasGrupos[i]; // Lista de grupos a chequear aparecidas de Jonathan Actual

        //         for (int j = 0; j < listaDeGruposActual.Length; j++)
        //         {
        //             Group currentGroup = listaDeGruposActual[j]; // Grupo 1
        //             string[] currentGroupStudents = currentGroup.Students; //Los estudiantes del grupo 1

        //             if (currentGroupStudents.Contains(currentStudent))
        //             {
        //                 currentIntArrOfStudentGroupAppearancesCount[j]++; // Sumalo a la posicion del arreglo de contadas correspondiente al grupo 1
        //             }
        //         }
        //     }

        //     foreach (var countAppearance in studentGroupAppearancesCount)
        //     {
        //         Assert.Fail();
        //         for (int i = 0; i < countAppearance.Length; i++)
        //         {
        //             int countOfCurrentGroup = countAppearance[i];

        //             if (countOfCurrentGroup / numTests > probabilty)
        //             {
        //                 Assert.Fail();
        //             }
        //         }
        //     }
        //     // Assert.Pass();
        //     // Assert.That(listasDeListasGrupos.Select(listGroups => listGroups.Length), Is.All.EqualTo(numberOfGroups));
        // }
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

