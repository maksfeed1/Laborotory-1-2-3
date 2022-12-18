using System;
using System.Diagnostics;
using System.Numerics;
using lab_2;
using Microsoft.VisualBasic;
using Peron;
using _Person;



namespace lab_1
{
    class Program
    {

        static void Main(string[] args)
        {
            //вывод студента
            var st = new Peron.Student("Nikita", "Rogov", new DateTime(2000, 12, 12), 2, "Bachelor");
            Console.WriteLine(st.ToShortString());

            st.Datastudent = new Peron.Person("Oleg", "Tokarev", new DateTime(2003, 02, 11));
            st.education = Peron.Education.Bachelor;

            st.AddExams(new Exam("math", 5, new DateTime(2022, 01, 01)), new Exam("C#", 5, new DateTime(2022, 01, 02)));

            Console.WriteLine(st.ToString());
            var linearArray = new Exam[100];
            var rectArray = new Exam[10, 10];
            var jaggedArray = new Exam[10][];

            for (int i = 0; i < jaggedArray.Length; i++)
                jaggedArray[i] = new Exam[10];
            // проврека какой массив быстрее
            //test1
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < 100; i++)
                linearArray[i] = null;

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            //test2
            sw = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    rectArray[i, j] = null;

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            //test3
            sw = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    jaggedArray[i][j] = null;

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
          
            Console.WriteLine("\n ************************************************** \n Вторая лаба \n ****************************************************** \n ");
            var person1 = new person("Bobson", "Bob", new DateTime(1950, 01, 01));
            var person2 = new person("Bobson", "Bob", new DateTime(1950, 01, 01));
            Console.WriteLine("Равны ли ссылки на объекты?:");
            Console.WriteLine(Object.ReferenceEquals(person2, person1)); //проверка равны ли сслыки на объекты
            Console.WriteLine("Равны ли значени в объекты?:");
            Console.WriteLine(person1 == person2); // проверка равны ли объекты
            Console.WriteLine("hash: \nperson1: {0},  \nperson2: {1}", person1.GetHashCode(), person2.GetHashCode());
            Console.WriteLine();
            Console.WriteLine("\n");

            var student = new Student2(new person("Ivanov", "Ivan", new DateTime(2000, 01, 01)), lab_2.Education.Specialist, 151);
            student.AddExam(new Exam2("\n Englek", 5, new DateTime(2008, 9, 21)));
            student.AddTest(new Test("PPP", true));
            //вывод информации
            Console.WriteLine(student.ToString());
            Console.WriteLine(student.Personal);
            Console.WriteLine("\n");
            var studentClone = student.DeepCopy();
            student.Name = "Tom";
            student.Surname = "Tomson";
            Console.WriteLine("Student: ");
            Console.WriteLine(student.ToString());
            Console.WriteLine("StudentClone: ");
            Console.WriteLine(studentClone.ToString());
            Console.WriteLine("\n");
            try
            {
                student.GroupNumber = 600;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");
            //вывод результатов
            foreach (var task in student.GetResults())
                Console.WriteLine(task.ToString());

            Console.WriteLine("----------------------------------------------------------");

            foreach (var task in student.ExamsOver(3))
                Console.WriteLine(task.ToString());



            
            Console.WriteLine("\n ************************************************** \n Третья лаба \n ****************************************************** \n ");
            StudentCollection studentCollection = new StudentCollection();
            var student1 = new _Person.Student(new _Person.Person("Maksim", "Baranov", new DateTime(2003, 12, 15)), lab_2.Education.Specialist, 131);
            student1.AddExams(new Exam2("Scratch", 5, new DateTime(2022, 12, 21)));
            studentCollection.AddStudents(student1);
            var student2 = new _Person.Student(new _Person.Person("Artem", "Jigalov", new DateTime(2004, 01, 14)), lab_2.Education.Specialist, 131);
            student2.AddExams(new Exam2("Mathematic", 4, new DateTime(2022, 12, 20)));
            studentCollection.AddStudents(student2);
            var student3 = new _Person.Student(new _Person.Person("Antuan", "DeGolubtsov", new DateTime(2007, 03, 13)), lab_2.Education.Specialist, 131);
            student3.AddExams(new Exam2("Engish", 4, new DateTime(2022, 12, 19)));
            studentCollection.AddStudents(student3);
            var student4 = new _Person.Student(new _Person.Person("Pasha", "Moskva", new DateTime(1997, 09, 19)), lab_2.Education.Bachelor, 131);
            student4.AddExams(new Exam2("PhysicalEducation", 5, new DateTime(2022, 12, 01)));
            student4.AddExams(new Exam2("MatAnaliz", 2, new DateTime(2022, 12, 31)));
            studentCollection.AddStudents(student4);
            Console.WriteLine(studentCollection.ToShortString());
            Console.WriteLine();
            // сортировк по фамилии
            studentCollection.SortBySurname();
            Console.WriteLine("sortirovka po familii");
            Console.WriteLine(studentCollection.ToShortString());
            //сортировка по дате рождения
            studentCollection.SortByBirthDate();
            Console.WriteLine();
            Console.WriteLine("Sortirovka po date rozhdeniya");
            Console.WriteLine(studentCollection.ToShortString());
            // сортировка по среднему баллу
            studentCollection.SortByAverageScore();
            Console.WriteLine();
            Console.WriteLine("sortirovka po sredneyocenke");
            Console.WriteLine(studentCollection.ToShortString());
            // максимальный балл для элементов из списка
            Console.WriteLine(studentCollection.MaxAverageMark.ToString());
            //запустим фильтрацию списка для отбора студентов с формой обучения Specialist
            Console.WriteLine("Specialist: ");
            foreach (var specialists in studentCollection.Specialist.ToList())
                Console.WriteLine(specialists.ToShortString());
            Console.WriteLine();
            //Вывод студентов по среднему баллу (5,4,3)
            Console.WriteLine("srednaya ocenka 5: ");
            //studentCollection.AverageMarkGroup(5);
            foreach (var specialists in studentCollection.AverageMarkGroup(5).ToList())
                Console.WriteLine(specialists.ToShortString());
            Console.WriteLine();
            Console.WriteLine("srednaya ocenka 4: ");
            foreach (var specialists in studentCollection.AverageMarkGroup(4).ToList())
                Console.WriteLine(specialists.ToShortString());
            Console.WriteLine();
            Console.WriteLine("srednaya Ocenka 3.5: ");
            foreach (var specialists in studentCollection.AverageMarkGroup(3.5).ToList())
                Console.WriteLine(specialists.ToShortString());
            TestCollections test = new TestCollections(1);
            test.TimeOfSearching();
            Console.ReadKey();
        }




    }

}