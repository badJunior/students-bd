
namespace students_bd
{
    public class InMemoryStudentsRepository:IStudentsRepository
    {
        private readonly List<Student> _students = new List<Student>();


        public InMemoryStudentsRepository ()
        {
            var names = new List<string>() {
          "Петр Петров"
        , "Дмитрий Александров"
        , "Тарас Владов"
    };
            var students = names.Select((name, index) => new Student(name, index + 1));
            _students.AddRange(students);
        }

        public void AddStudent(string newStudentName)
        {
            var id = 1;
            if (_students.Any())
            {

                var maxNumber = _students.Max(student => student.Id);
                id += maxNumber;
            }
            var newStudent = new Student (newStudentName, id);
            _students.Add(newStudent);
        }

        public void DeleteStudent(int studentToBeDeleted)
        {
            if (!_students.Any(student => student.Id == studentToBeDeleted))
            {
                throw new InvalidOperationException("Такого студента нет");

            }

            _students.Remove(_students.First(student => student.Id == studentToBeDeleted));
        }

        public IEnumerable<Student> GetStudents()
        {
           return _students;
        }
    }
}
