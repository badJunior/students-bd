namespace students_bd
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudents();
        void AddStudent(string newStudent);
        void DeleteStudent(int studentToBeDeleted);
        
    }
}
