
namespace students_bd
{
    public class StudentsService:IStudentsService
    {
        private readonly IStudentsRepository _repository;

        public StudentsService(IStudentsRepository repository)
        {
            _repository = repository;
        }

       

        public void AddStudent(string newStudent)
        {
           _repository.AddStudent(newStudent);
        }

       

        public void DeleteStudent(int studentToBeDeleted)
        {
            _repository.DeleteStudent(studentToBeDeleted);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _repository.GetStudents();
        }
    }
}
