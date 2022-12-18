using lab_2;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Person
{
    public class TestCollections
    {
        
        List<Test> ListOfTest = new List<Test>();
        List<string> ListOfString = new List<string>();
        Dictionary<Test, Student2> DictionaryOfTestAndStudent = new Dictionary<Test, Student2>();
        Dictionary<string, Student2> DictionaryOfStringAndStudent = new Dictionary<string, Student2>();
        public static Student2 GenerateElement(int value)
        {
            Student2 a = new Student2();
            a.GroupNumber = value;
            return a;
        }
        //создадим конструктор  для создания коллекции с заданным числом элементов
        public TestCollections(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                ListOfTest.Add(new Test());
                DictionaryOfTestAndStudent.Add(new Test(), new Student2());
                ListOfString.Add(" ");
                DictionaryOfStringAndStudent.Add(" ", new Student2());
            }
        }
        //время поиска элемента
        public void TimeOfSearching()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var temp = ListOfTest.Contains(ListOfTest[0]);
            temp = ListOfTest.Contains(ListOfTest[ListOfTest.Count / 2]);
            temp = ListOfTest.Contains(ListOfTest[ListOfTest.Count - 1]);
            stopwatch.Stop();
            Console.WriteLine($"Time to find element in List<Person>: {stopwatch.Elapsed}");
            var first = DictionaryOfTestAndStudent.First();
            Test key = first.Key;
            var middle = DictionaryOfTestAndStudent.ElementAt(DictionaryOfTestAndStudent.Count / 2);
            Test keymiddle = middle.Key;
            var last = DictionaryOfTestAndStudent.Last();
            Test keylast = last.Key;
            var first1 = DictionaryOfStringAndStudent.First();
            Student2 key1 = first1.Value;
            var middle1 = DictionaryOfStringAndStudent.ElementAt(DictionaryOfStringAndStudent.Count / 2);
            Student2 keymiddle1 = middle1.Value;
            var last1 = DictionaryOfStringAndStudent.Last();
            Student2 keylast1 = last1.Value;
           
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            var temp1 = DictionaryOfTestAndStudent.ContainsKey(key);
            temp1 = DictionaryOfTestAndStudent.ContainsKey(keymiddle);
            temp1 = DictionaryOfTestAndStudent.ContainsKey(keylast);
            stopwatch1.Stop();
            Console.WriteLine($"Time to find element in Dictionary<Team, Person>: {stopwatch1.Elapsed}");
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var temp2 = DictionaryOfStringAndStudent.ContainsValue(key1);
            temp2 = DictionaryOfStringAndStudent.ContainsValue(keymiddle1);
            temp2 = DictionaryOfStringAndStudent.ContainsValue(keylast1);
            stopwatch2.Stop();
            Console.WriteLine($"Time to find element in Dictionary<string,Person>: {stopwatch2.Elapsed}");

        }
    }


    public class Person : IDateAndCopy, IComparable<Person>, IComparer<Person>
    {
        
        protected string _Name;
        protected string _Surname;
        protected DateTime _BDate;
        //Определение конструктора
        public Person(string StudentName, string StudentSurname, DateTime StudentBDate)
        {
            _Name = StudentName;
            _Surname = StudentSurname;
            _BDate = StudentBDate;
        }
        //Определение конструктора без параметров со значениями по умолчанию
        public Person() : this("DefName", "DefSurname", new DateTime(2003, 05, 21))
        { }
        //Определение свойств с методами get  и set 
        
        public string StudName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string StudSurname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }
        public DateTime StudBdate
        {
            get { return _BDate; }
            set { _BDate = value; }
        }
        public int intStudBDate
        {
            get { return Convert.ToInt32(_BDate); }
            set { _BDate = Convert.ToDateTime(value); }
        }
        

        //Определение перегруженной версии строки
        
        public override string ToString()
        {
            return string.Format("{0} {1}\nDate of birth: {2}", _Name, _Surname, _BDate);
        }
        //Определение виртуального метода короткой строки
        
        public string ToShortString()
        {
            return string.Format("{0} {1}", _Name, _Surname);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Person objPerson = obj as Person;
            if (obj as Person == null)
            { return false; }
            return objPerson.StudName == _Name && objPerson.StudSurname == _Surname && objPerson.StudBdate == _BDate;
        }
        
        public static bool operator ==(Person leftperson, Person rightperson)
        {
            
            if (Equals(leftperson, rightperson))
            { return true; }
            if ((object)leftperson == null || (object)rightperson == null)
            { return false; }
            return leftperson.StudName == rightperson.StudName && leftperson.StudSurname == rightperson.StudSurname && leftperson.StudBdate == rightperson.StudBdate;
        }
        public static bool operator !=(Person leftperson, Person rightperson)
        {
            return !(leftperson == rightperson);
        }
        public override int GetHashCode()
        {
            return StudName.GetHashCode() + StudSurname.GetHashCode() + StudBdate.GetHashCode();
        }
       
        public object DeepCopy()
        {
            Person personcopy = new Person(this.StudName, this.StudSurname, this.StudBdate);
            return personcopy;
        }
        //Добавляем реализацию IComparable для сравнения объектов по полю с фамилией
        public int CompareTo(Person? other)
        {
            return this.StudSurname.CompareTo(other.StudSurname);
        }
        //Добавляем реализацию IComparer для сравнения объектов по дате рождения
        public int Compare(Person? x, Person? y)
        {
            return x.StudBdate.CompareTo(y.StudBdate);
        }

        DateTime IDateAndCopy.Date { get; set; }
    }

    //класс Student производный от  Person
    public class Student : Person, IDateAndCopy
    {
        
        Person _Info;
        Education _Formofstudy;
        int _numberOfGroup;
        Exam2[] Exams;
        Test _test;
        
       
        List<Test> tests = new List<Test>();
        List<Exam2> exams = new List<Exam2>();
        
        //Создание конструктора
        public Student(Person info, Education formofstudy, int numberofgroup)
        {
            _Info = info;
            _Formofstudy = formofstudy;
            _numberOfGroup = numberofgroup;
            //Создаем пустой массив, который будем заполнять экзаменами
            
            tests = new List<Test>();
            exams = new List<Exam2>();
        }
        //Создание конструктора со значениями по умолчанию
        public Student() : this(new Person(), Education.SecondEducation, 1)
        { }
        //Определение  get и set
        public Person Information
        {
            get { return _Info; }
            set { _Info = value; }
        }

        public Education Formofstudy
        {
            get { return _Formofstudy; }
            set { _Formofstudy = value; }
        }
        
        public int NumberOfGroup
        {
            get { return _numberOfGroup; }
            set
            {
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Error! Number of group is out of range (100;599");
                }
            }
        }
        public Exam2[] getExams
        {
            get { return Exams; }
            set { Exams = value; }
        }
        public Test Test
        {
            get { return _test; }
            set { _test = value; }
        }
        //Определение свойства вычисления среднего значения оценок
        public double AverageMark
        {
            get
            {
                int sum = 0;
                foreach (Exam2 Exams in exams)
                {
                    sum = sum + Exams.Mark;
                }
                //Делим сумму оценок на количество экзаменов
                return (double)sum / exams.Count();
            }
        }
        //Совпадает ли поле обучения с индексом
        public bool this[Education Education]
        {
            get { return Education == _Formofstudy; }
        }
        
        public void AddExams(Exam2 Examss)
        {
            exams.Add(Examss);
            
        }
        public void AddTests(Test _test)
        {
            tests.Add(_test);
            
        }
        
        
        public override string ToString()
        {
            foreach (Exam2 getexams in exams)
            {
                Console.WriteLine(getexams.ToString());
            }
            foreach (Test test in tests)
            {
                Console.WriteLine(test.ToString());
            }
            return "\nStudent : " + _Info + "  Education : " + _Formofstudy + "  NumberOfGroup : " + NumberOfGroup;
        }
        
        public string ToShortString()
        {
            return "\nStudent : " + _Info + "  Education :" + _Formofstudy + "  NumberOfGroup :" + NumberOfGroup.ToString()
                + "  Avg. Mark : " + AverageMark.ToString();
        }
       
        public bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Student objStudent = obj as Student;
            if (obj as Person == null)
            { return false; }
            return objStudent.Information == _Info && objStudent.Formofstudy == _Formofstudy && objStudent.NumberOfGroup == _numberOfGroup && objStudent.Exams == Exams && objStudent.Test == _test;
        }
       
        public static bool operator ==(Student leftperson, Student rightperson)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(leftperson, rightperson))
            { return true; }
            if ((object)leftperson == null || (object)rightperson == null)
            { return false; }
            return leftperson._Info == rightperson._Info && leftperson.NumberOfGroup == rightperson.NumberOfGroup && leftperson.Formofstudy == rightperson.Formofstudy && leftperson.Exams == rightperson.Exams && leftperson.tests == rightperson.tests;
        }
        public static bool operator !=(Student leftperson, Student rightperson)
        {
            return !(leftperson == rightperson);
        }
        public override int GetHashCode()
        {
            return _Info.GetHashCode() + NumberOfGroup.GetHashCode() + Formofstudy.GetHashCode() + Exams.GetHashCode() + tests.GetHashCode();
        }
        //перебор экзаменов и зачетов
        public IEnumerable GetResults()
        {
            foreach (var exam in exams)
                yield return exam;
            foreach (var test in tests)
                yield return test;
        }
        //перебор  экзаменов с оценкой, выше заданной
        public IEnumerable ExamsOver(int minRate)
        {
            foreach (var exam in exams)
            {
                Exam2 ex = (Exam2)exam;
                if (ex.Mark > minRate)
                    yield return exam;
            }
        }
    }
    
    //сравнение объектов  по среднему баллу
    class CompareAverage : IComparer<Student>
    {
        //через CompareTo будем сравнивать среднюю оценку
        public int Compare(Student? x, Student? y)
        {
            return x.AverageMark.CompareTo(y.AverageMark);
        }
    }

    public class StudentCollection
    {
        
        List<Student> students = new List<Student>();
        
        public void AddDefaults()
        {
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student());
            }
        }
        //добавление студентов в список
          public void AddStudents(params Student[] studentss)
        {
            students.AddRange(studentss);
        }
        
        public override string ToString()
        {
            string StudentString = "";
            foreach (Student student in students)
            {
                StudentString += student.ToString();
            }
            return StudentString;
        }
        
        public string ToShortString()
        {
            string StudentString = "";
            foreach (Student student in students)
            {
                StudentString += student.ToShortString();
            }
            return StudentString;
        }
        //сортируовка по фамилиям
        public void SortBySurname()
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - 1; j++)
                    if (students[j].Information.CompareTo(students[j + 1].Information) > 0)
                    {
                        (students[j + 1], students[j]) = (students[j], students[j + 1]);
                    }
            }
        }
        //сортируовка по датам рождения
        public void SortByBirthDate()
        {
            for (int i = 0; i < students.Count - 1; i++)
                for (int j = 0; j < students.Count - 1; j++)
                    if (students[j].Compare(students[j].Information, students[j + 1].Information) > 0)
                    {
                        (students[j + 1], students[j]) = (students[j], students[j + 1]);
                    }
        }
        //сортируовка по среднему баллу
        public void SortByAverageScore()
        {
            CompareAverage comparer = new();
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - 1; j++)
                    if (comparer.Compare(students[i], students[i + 1]) > 0)
                    {
                        (students[i + 1], students[i]) = (students[i], students[i + 1]);
                    }
            }
        }
        // средний балл
        public double MaxAverageMark
        {
            get
            {
                if (students.Count == 0)
                {
                    return 0;
                }
                return students.Max(students => students.AverageMark);
            }
        }
        //проверк на specialist
         public IEnumerable<Student> Specialist
        {
            get
            {
                IEnumerable<Student> AllSpecialists = students.Where(education => education.Formofstudy == Education.Specialist);
                return AllSpecialists;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < students.Count; i++)
            {
                yield return students[i];
            }
        }
        //значение среднего балла
         public List<Student> AverageMarkGroup(double value)
        {
            IEnumerable<IGrouping<double, Student>> someGroup = students.GroupBy(team => team.AverageMark);

            foreach (IGrouping<double, Student> teams in someGroup)
            {
                if (teams.Key == value)
                {
                    return teams.ToList();
                }
            }
            return null;
        }
    }

}
