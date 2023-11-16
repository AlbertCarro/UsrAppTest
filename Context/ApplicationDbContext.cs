using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Define tus DbSet para cada entidad que deseas mapear a una tabla en la base de datos
    public DbSet<Person> People { get; set; }
    // Otros DbSets si los necesitas
}

public class Person
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public TimeSpan EstimatedWaitTime { get; internal set; }
    // Otros campos

    // Resto del código de la entidad
}
