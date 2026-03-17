// See https://aka.ms/new-console-template for more information
using Scheduling_app___deberati;
using System.Threading.Tasks.Dataflow;

Console.WriteLine("Hello, World!");

new List<Job>
{
    new Job("A", 0, 3, 1),
    new Job("B", 2, 6, 2),
    new Job("C", 4, 4, 1),
    new Job("D", 6, 5, 3),
    new Job("E", 8, 2, 2)
}.ForEach(job => Console.WriteLine($"Job {job.ID}: Arrival Time = {job.arrivalTime}, Execution Time = {job.executionTime}, Priority = {job.priority}"));

