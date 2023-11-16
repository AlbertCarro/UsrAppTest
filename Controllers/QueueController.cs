using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class QueueController : ControllerBase
{
    private List<QueuePerson> queue1 = new List<QueuePerson>(); // Cola 1
    private List<QueuePerson> queue2 = new List<QueuePerson>(); // Cola 2

    [HttpPost("add")]
    public IActionResult AddToQueue([FromBody] QueuePerson newPerson)
    {
        // Lógica para determinar la cola más corta
        if (queue1.Count < queue2.Count)
        {
            // Asignar a la cola 1
            queue1.Add(newPerson);
        }
        else
        {
            // Asignar a la cola 2
            queue2.Add(newPerson);
        }

        return Ok("Persona agregada a la cola");
    }

    public void RemoveFromQueue(int queueNumber)
{
    if (queueNumber == 1 && queue1.Count > 0)
    {
        queue1.RemoveAt(0); // Eliminar la primera persona de la cola 1 (se supone que ha sido atendida)
    }
    else if (queueNumber == 2 && queue2.Count > 0)
    {
        queue2.RemoveAt(0); // Eliminar la primera persona de la cola 2 (se supone que ha sido atendida)
    }
    // Puedes manejar otros números de cola si es necesario
}

public TimeSpan CalculateAverageWaitTime(int queueNumber)
{
    List<QueuePerson> queue = queueNumber == 1 ? queue1 : queue2;

    if (queue.Count == 0)
    {
        return TimeSpan.Zero; // Si la cola está vacía, el tiempo de espera promedio es cero
    }

    TimeSpan totalWaitTime = TimeSpan.Zero;

    foreach (var person in queue)
    {
        // Sumar los tiempos de espera de cada persona en la cola
        totalWaitTime += person.EstimatedWaitTime;
    }

    // Calcular el tiempo promedio dividiendo la suma total por la cantidad de personas en la cola
    return TimeSpan.FromTicks(totalWaitTime.Ticks / queue.Count);
}



}
