namespace students_bd
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetStudents();
        void AddStudent(string newStudent);
        void DeleteStudent(int studentToBeDeleted);
    }
}
