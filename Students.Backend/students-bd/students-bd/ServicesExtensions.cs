namespace students_bd
{
    public static class ServicesExtensions
    {
        public static void RegisterServicesLayerDependencies(this IServiceCollection collection)
        {
            collection.AddSingleton<IStudentsRepository, InMemoryStudentsRepository>();
            collection.AddTransient<IStudentsService, StudentsService>();

        }
    }
}
