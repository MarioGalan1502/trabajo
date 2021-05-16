using NUnit.Framework;
using divisionDeGrupos;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System;

namespace TestDivisionDeGrupos
{
    public class InputTest
    {
        [Test]
        public void ArgumentsInput_numberOfGroups_IsNull()
        {
            InputClass inputClass = new InputClass();
            string[] args = { null, "Students.txt", "Subjects.txt" };
            Assert.That(() => inputClass.ArgumentsInput(args), Throws.ArgumentNullException);
        }

        [Test]
        public void ArgumentsInput_FileDirectionStudents_IsNull()
        {
            InputClass inputClass = new InputClass();
            string[] args = { "5", null, ".txt" };
            Assert.That(() => inputClass.ArgumentsInput(args), Throws.ArgumentNullException);
        }

        [Test]
        public void ArgumentsInput_FileDirectionSubjects_IsNull()
        {
            InputClass inputClass = new InputClass();
            string[] args = { "5", "Students.txt", null };
            Assert.That(() => inputClass.ArgumentsInput(args), Throws.ArgumentNullException);
        }

        [Test]
        public void ArgumentsInput_All_AreNull()
        {
            InputClass inputClass = new InputClass();
            string[] args = { null, null, null };
            Assert.That(() => inputClass.ArgumentsInput(args), Throws.ArgumentNullException);
        }

        [Test]
        public void ArgumentsInput_File_Not_Found()
        {
            InputClass inputClass = new InputClass();
            string[] args = { "5", "Students.txt", "Subjects.txt" };

            Assert.That(() => inputClass.ArgumentsInput(args), Throws.Exception.TypeOf<FileNotFoundException>());
        }
        [Test]
        public void ArgumentsInput_Argument_NumberOfGroups_IsZero()
        {
            InputClass inputClass = new InputClass();
            string[] args = { "0", "Students.txt", "Subjects.txt" };
            Assert.That(() => inputClass.ArgumentsInput(args), Throws.Exception.TypeOf<DivideByZeroException>().And.Message.EqualTo("No puede haber 0 grupos."));
        }

        [Test]
        public void ArgumentsInput_Argument_NumberOfGroups_IsNegative()
        {
            InputClass inputClass = new InputClass();
            string[] args = { "-5", "Students.txt", "Subjects.txt" };
            Assert.That(() => inputClass.ArgumentsInput(args), Throws.Exception);
        }
    }
}

