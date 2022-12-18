﻿
using System;
using System.Collections;
using System.Text;
namespace lab_2
    {


        interface IDateAndCopy
        {
        
            object DeepCopy();
            DateTime Date { get; set; }
        }

        

    //наследуется от интерфейса
        public class person : IDateAndCopy
        {
            protected string name;
            protected string surname;
            protected DateTime date;
        
            public person() { name = "NetName_2"; surname = "NetSurname_2"; new DateTime(1900, 05, 05); }

            public person(string n, string s, DateTime d) { name = n; surname = s; date = d; }

            public string Name //метод get/set для поля с именем 
            {
                get { return name; }
                set { name = value; }
            }

            public DateTime Birthday //метод get/set для поля с датой рождеония
            {
                get { return date; }
                set { date = value; }

            }

            public string Surname //метод get/set для поля с фамилией
            {
                get { return surname; }
                set { surname = value; }
            }

            public int Years
            {
                get { return date.Year; }
                set { date = new DateTime(value, date.Month, date.Day); }
            }


            public override string ToString()
        {
                return name + " " + surname + " " + date.ToShortDateString() + "\n";

            }

            public virtual string ToShortString()
        {
                return Name + surname + "\n";
            }
            //*********************************************************
            public override bool Equals(object obj) //сравнивает ссылки на объекты ,это помогает понять находятся ли они в одной ячейке памяти
            {
                if (obj == null)
                {
                    return false;
                }
                var p = obj as person;
                if ((System.Object)p == null)
                {
                    return false;
                }
                return (name == p.name) && (surname == p.surname) &&
                 (date == p.date);

            }

            public override int GetHashCode() //вирутуальный метод для получения хэш кода
            {
                return name.GetHashCode() + surname.GetHashCode() + date.GetHashCode();
            }


            public static bool operator ==(person a, person b)
            {
                if (System.Object.ReferenceEquals(a, b))
                {
                    return true;
                }

                if (((object)a == null) || ((object)b == null))
                {
                    return false;
                }

                return a.Equals(b);
            }

            public static bool operator !=(person a, person b)
            {
                return !(a == b);
            }

            public virtual object DeepCopy() //реализация интерфейса
            {
                person person = new person(this.name, this.surname, this.date);
                return person;
            }

            DateTime IDateAndCopy.Date { get { return date; } set { date = value; } } //реализация интерфейса
        }
        public enum Education { Specialist, Bachelor, SecondEducation }//реализация форм обучения из первой лабораторной работы

        public class Exam2 : IDateAndCopy
        {
            public string Subject { get; set; }// автореализуемые свойства
            public int Mark { get; set; }
            public DateTime ExamDate { get; set; }

            public Exam2()//конструктор экзаменов с неизвестными параметрами
            {
                Subject = "Default";
                Mark = 5;
                ExamDate = DateTime.Now;
            }

            public Exam2(string subject, int mark, DateTime examDate)//конструктор экзаменов
        {
                Subject = subject;
                Mark = mark;
                ExamDate = examDate;
            }

            public object DeepCopy()
            {
                return new Exam2(Subject, Mark, ExamDate);
            }

            DateTime IDateAndCopy.Date//реализация интерфейса в классе
            {
                get { return ExamDate; }
                set { ExamDate = value; }

            }


            public override string ToString()
            {
                return Subject + ", mark: " + Mark + ", date: " + ExamDate.ToShortDateString() + "\n";
            }

        }
      

        public class Student2 : person, IDateAndCopy

        {

            private System.Collections.ArrayList tests; // список зачётов
            private System.Collections.ArrayList exams; // список экзаменов
            private Education educationInfo; // информация о форме обучения
            private int groupNumber; // информация о номере группы
            private person personalInfo; //информация о обучающемся

            public person Personal //метод get/set для Person 
            {
                get { return personalInfo; }
                set { personalInfo = value; }
            }

            public Education Educational //метод get/set для формы обучения 
            {
                get { return educationInfo; }
                set { educationInfo = value; }
            }

            public int GroupNumber //метод get/set для номера группы 
            {
                get { return groupNumber; }
                set
                {
                    if (value <= 100 || value > 599) //проверка попадания заданного значения диапазон
                    {
                        throw new ArgumentOutOfRangeException("Error! GroupNumber out of range(100, 599)."); //вывод предупреждающего сообщения
                    }
                    groupNumber = value;
                }
            }

            public System.Collections.ArrayList Exams //метод get/set для доступа к полю с экзаменами 
            {
                get { return exams; }
                set { exams = value; }
            }


            public Student2(person person, Education info, int _groupNumber) //конструктор с параментрами реализующий поля класса
            {
                educationInfo = info;
                personalInfo = person;
                groupNumber = _groupNumber;
                exams = new System.Collections.ArrayList();
                tests = new System.Collections.ArrayList();
            }

            public Student2() //конструктор без параметров реальзующий значения по умолчанию
            {
                groupNumber = 481063;
                personalInfo = new person();
                educationInfo = Education.Specialist;
                exams = new System.Collections.ArrayList();
                tests = new System.Collections.ArrayList();
            }
            public double AverageMark //вычисление средней оценки из списка сданных экзаменов
            {
                get
                {
                    int sum = 0;
                    foreach (Exam2 exam in exams)
                    {
                        sum = sum + exam.Mark;
                    }
                    return (double)sum / exams.Count;
                }
            }


            public bool this[Education _education] //проверка есть ли степень
            {
                get { return educationInfo == _education; }
            }

            public void AddExam(Exam2 exam) //метод для добавления элементов в спосок экзаменов
            {
                exams.Add(exam);
            }

            public void AddTest(Test _test) // метод для добавления элементов в список тестов
            {
                tests.Add(_test);
            }

            public override string ToString() //виртуальный метод для формирования строки со всеми значениями полей класса
            {
                StringBuilder strineg = new StringBuilder();
                strineg.AppendFormat("{0} {1} {2}", base.ToString(), groupNumber, educationInfo);
                foreach (Exam2 exam in exams) //перебор всех элементов списка экзаменов
                    strineg.AppendLine(exam.ToString());
                foreach (Test test in tests) // перебор всех элементов списка тестов
                    strineg.AppendLine(test.ToString());
                return strineg.ToString();

            }

            public override string ToShortString() // виртуальный метод  без списка тестов и экзаменов
            {
                return
                    ToShortString() +
                    string.Format(
                    "{0}, {1}, {2}, AVG Mark = {3}",
                    Personal,
                    Educational,
                    GroupNumber,
                    AverageMark
                );
            }

            public object DeepCopy() //реализация перегруженного виртуального метода DeepCopy
            {
                Student2 stud = new Student2(this.personalInfo, this.educationInfo, this.groupNumber);

                foreach (Exam2 exam in this.exams)
                {
                    stud.AddExam(exam);
                }
                foreach (Test test in this.tests)
                {
                    stud.AddTest(test);
                }
                return stud;
            }



            public IEnumerable GetResults() //получение результата экзамена
            {
                foreach (var exam in exams)
                    yield return exam;
                foreach (var test in tests)
                    yield return test;
            }

            public IEnumerable ExamsOver(int minRate) // выведение данных о экжзамене с оценкой выше узказанной
            {
                foreach (var exam in exams)
                {
                    Exam2 ex = (Exam2)exam;
                    if (ex.Mark > minRate)
                        yield return exam;
                }
            }

        }

        public class Test
        {
            public string subject { get; set; } //автореализуемое свойство типа string
            public bool isPassed { get; set; } //автореализуемое свойство типа bool

            public Test(string _subject, bool _isPassed) //конструктор реаализующий поля класса с параметрами
            {
                subject = _subject;
                isPassed = _isPassed;
            }

            public Test() //конструктор без параметров, создающий значения по умолчанию
            {
                subject = "Math";
                isPassed = true;
            }

            public override string ToString() //виртуальный метод для формирования строки со всеми значениями полей класса
            {
                return string.Format("Test subj = {0}, ispassed = {1}", subject, isPassed);
            }
        }
    }