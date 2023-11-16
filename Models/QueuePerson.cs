using System;

public class QueuePerson
{
    public int Id { get; set; } // Clave primaria
    public required string Name { get; set; }
    public DateTime EntryTime { get; set; } // Hora de entrada
    public TimeSpan EstimatedWaitTime { get; internal set; }

    // Otros campos si son necesarios

    // Constructor si es necesario inicializar propiedades al crear una nueva instancia
    public QueuePerson()
    {
        EntryTime = DateTime.Now; // Por ejemplo, establecer la hora de entrada por defecto al momento de crear la persona en cola
    }
}
