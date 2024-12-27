namespace students_bd.Routes
{
    public static class StudentsRoutesExtensions
    {
        public static void RegisterStudentRoutes(this WebApplication app)
        {
            var students = app.MapGroup("/students");
            students.MapGet("/",GetStudents);
            students.MapPost("/", CreateStudent);
            students.MapDelete("/{idStudentToDelete}", DeleteStudent);

        }
        private static IResult GetStudents(IStudentsService service)
        {
            return Results.Ok(service.GetStudents());
        }

        private static IResult DeleteStudent( int idStudentToDelete, IStudentsService service)
        {
            if (idStudentToDelete <= 0)
            {
                return Results.BadRequest("Неправильный идентификатор студента");
            }

            try
            {
                service.DeleteStudent(idStudentToDelete);
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(ex.Message);
            }
            return Results.Ok();
        }

        private static IResult CreateStudent(CreateStudentRequestDto request , IStudentsService service)
        {
            if (string.IsNullOrWhiteSpace(request.NewStudentName))
            {
                return Results.BadRequest("Неправильное имя студента");
            }

            service.AddStudent(request.NewStudentName);

            return Results.Ok();
        }
    }
}
