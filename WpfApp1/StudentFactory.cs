using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class StudentFactory
    {
        private IList<Student> students;
        public IEnumerable<Student> GetAllStudent()
        {
            return students;
        }

        public StudentFactory()
        {
            students = new List<Student>();

            students.Add(new Student() { Grade = "1", Cclass = "3", Name = "gildong", No = "1010", Score = "A" });
            students.Add(new Student() { Grade = "1", Cclass = "1", Name = "gildong", No = "1020", Score = "A" });
            students.Add(new Student() { Grade = "1", Cclass = "2", Name = "gildong", No = "1030", Score = "A" });
            students.Add(new Student() { Grade = "1", Cclass = "4", Name = "gildong", No = "1040", Score = "B" });
            students.Add(new Student() { Grade = "1", Cclass = "2", Name = "gildong", No = "1050", Score = "A" });
            students.Add(new Student() { Grade = "1", Cclass = "5", Name = "gildong", No = "1060", Score = "C" });
        }
    }

    public class Student : Notifier
    {
        private string grade;
        public string Grade
        {
            get { return grade; }
            set
            {
                grade = value; OnPropertyChanged("Grade");
            }
        }
        private string cclass;
        public string Cclass
        {
            get { return cclass; }
            set
            {
                cclass = value; OnPropertyChanged("Cclass");
            }
        }
        private string no;
        public string No
        {
            get { return no; }
            set
            {
                no = value; OnPropertyChanged("No");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value; OnPropertyChanged("Name");
            }
        }
        private string score;
        public string Score
        {
            get { return score; }
            set
            {
                score = value; OnPropertyChanged("Score");
            }
        }
    }
}
