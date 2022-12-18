namespace Peron
{
    public enum Education { Specialist, Bachelor, SecondEducation }
    public class Person
    {

        private string name;
        private string surname;
        private System.DateTime date;

        public Person()
        {
            name = "НЕИЗВЕСТНО";
            surname = "НЕИЗВЕСТНО";
            date = DateTime.MinValue;
        }
        public Person(string n, string s, DateTime d)
        {
            name = n;
            surname = s;
            date = d;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public override string ToString()
        {
            return $"Name:{name}, {surname}, Date:{date}";
        }
        public virtual string ToShortString()
        {
            return $"Name:{name}, {surname}";
        }
    }
    public class Exam
    {

        public string subject { get; set; }
        public int mark { get; set; }
        public System.DateTime dateEx { get; set; }

        public Exam()
        {

            subject = "НЕИЗВЕСТНО";
            mark = 0;
            dateEx = DateTime.MinValue;
        }
        public Exam(string s, int m, DateTime d)
        {

            subject = s;
            mark = m;
            dateEx = d;
        }
        public override string ToString()
        {
            return $"Name:{subject}, {mark}, Date:{dateEx}";
        }
    }

    public class Student
    {

        private Person datastudent;
        private Education Education;
        private int groupnumber;
        private List<Exam> informationExams = new List<Exam>();

        public Student()
        {
            datastudent = new Person();
            Education = Education.Bachelor;
            groupnumber = 1321;
        }
        public Student(string n, string s, DateTime d, int g, string a)
        {
            datastudent = new Person(n, s, d);
            if (a.ToLower() == "bachelor") { Education = Education.Bachelor; }
            if (a.ToLower() == "specialist") { Education = Education.Specialist; }
            if (a.ToLower() == "second education") { Education = Education.SecondEducation; };//надо дописать чтобы брал разные специальности
            Education = Enum.Parse<Education>(a);
            groupnumber = g;
        }
        public double averagemark
        {
            get
            {
                double sum = 0;
                int count = 0;
                if (informationExams != null)
                {
                    foreach (Peron.Exam item in informationExams)
                    {
                        sum += item.mark;
                        count++;
                    }
                }
                if (count > 0) return sum / count;
                else return 0;
            }
        }
        public Person Datastudent
        {
            get { return datastudent; }
            set { datastudent = value; }
        }
        public Education education
        {
            get { return Education; }
            set { Education = value; }
        }
        public int Groupnumber
        {
            get { return groupnumber; }
            set { groupnumber = value; }
        }
        public List<Exam> InformationExams
        {
            get { return informationExams; }
        }
        public Exam[] Exams
        {
            get { return Exams.ToArray(); }
        }
        private bool get_bool(Education b)
        {
            if (Education == b) return true;
            else return false;
        }
        public void AddExams(params Exam[] InfExamsStud)
        {
            informationExams.AddRange(InfExamsStud);
        }
        public override string ToString()
        {
            return $" {groupnumber}, {datastudent}, {Education}" + string.Join(", ", informationExams);
        }
        public virtual string ToShortString()
        {
            return $" {groupnumber}, {datastudent}, {averagemark}" + string.Join(", ", informationExams);
        }


    }
}

  



