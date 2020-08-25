using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    public class StudentViewModel : Notifier
    {
        //데이터 불러올 생성자 생성
        StudentFactory factory = new StudentFactory();

        // view 단에서 쓸 모델명
        private IEnumerable<Student> foundStudents;
        public IEnumerable<Student> FoundStudents
        {
            get { return foundStudents; }
            set
            {
                foundStudents = value; OnPropertyChanged("FoundStudents");
            }
        }
        // view 단에서 쓸 모델명
        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value; OnPropertyChanged("SelectedStudent");
            }
        }
        public StudentViewModel()
        {
        }
        //Read에서 사용할 이벤트 커맨드 생성
        private ICommand readCommand;
        public ICommand ReadCommand
        {
            get { return (this.readCommand) ?? (this.readCommand = new DelegateCommand(Read)); }
        }
        private void Read()
        {
            FoundStudents = factory.GetAllStudent();
        }
    }
    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action execute;

        public DelegateCommand(Action excute) : this(excute, null)
        {

        }
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute();
        }

        public void Execute(object o)
        {
            this.execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if(this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
