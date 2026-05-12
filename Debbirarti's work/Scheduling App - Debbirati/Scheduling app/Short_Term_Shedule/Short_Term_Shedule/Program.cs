using System;
using System.Collections.Generic;

/// <summary>
/// This code is a First-Come First-Serve (FCFS) scheduling algorithm its main function is to compare the arrival times
/// of process a and b, produce a list of all the processes with their arrival and execution times, sort the processes
/// by comparing said times, using the times to calculate the normal turn around time and then print the results.
/// the sort method puts all the processes in the correct order.
/// </summary>

// the Process class declares all the properties that are needed for the FCFS scheduling algorithm to work.
public class Process
{
    public string Name { get; set; }
    public int ArrivalTime { get; set; }
    public int ExecutionTime { get; set; }

    public int FinishTime { get; set; }
    public int TurnaroundTime { get; set; }
    public double NormalisedTurnaround { get; set; }
}

class Program
{
    // Comparison method for sorting by arrival time.
    private static int CompareByArrival(Process a, Process b)
    {
        if (a.ArrivalTime < b.ArrivalTime) return -1;
        if (a.ArrivalTime > b.ArrivalTime) return 1;
        return 0;
    }

    static void Main()
    {
        // This list is what shows all the processes with their arrival and execution times.
        List<Process> processes = new List<Process>
        {
            new Process { Name = "A", ArrivalTime = 0, ExecutionTime = 3 },
            new Process { Name = "B", ArrivalTime = 2, ExecutionTime = 6 },
            new Process { Name = "C", ArrivalTime = 5, ExecutionTime = 5 },
            new Process { Name = "D", ArrivalTime = 6, ExecutionTime = 3 },
            new Process { Name = "E", ArrivalTime = 8, ExecutionTime = 6 },
            new Process { Name = "F", ArrivalTime = 9, ExecutionTime = 2 },
            new Process { Name = "G", ArrivalTime = 10, ExecutionTime = 6 }
        };

        ///<summary>
        /// This method sorts the processes based on their arrival time, ensuring that the First-Come First-Serve
        /// (FCFS) algorithm processes them in the correct order.
        /// </summary>

        processes.Sort(CompareByArrival);

        ///<summary>
        ///The next foreach loop simulates the FCFS algorithm by iterating through the sorted list of processes,
        ///calculating their finish time, turnaround time, and normalised turnaround time based on their arrival and
        ///execution times.
        /// </summary>

        int currentTime = 0;

        foreach (var p in processes)
        {
            // If the CPU is idle, the code jumps to the process arrival time
            if (currentTime < p.ArrivalTime)
            {
                currentTime = p.ArrivalTime;
            }

            // This part of the code adds the execution time of the current process to the current time to calculate the finish time.
            currentTime += p.ExecutionTime;
            p.FinishTime = currentTime;

            ///<summary>
            ///  This part of the code calculates the total turnaround time for each process by subtracting the
            ///  arrival time from the finish time, and then calculates the normalised turnaround time by dividing
            ///  the turnaround time by the execution time.
            ///</summary>
            p.TurnaroundTime = p.FinishTime - p.ArrivalTime;
            p.NormalisedTurnaround = (double)p.TurnaroundTime / p.ExecutionTime;
        }

        ///<summary>
        /// The last chunk of code prints the results of the FCFS algorithm, showing each process's finish time,
        /// turnaround time, and normalised turnaround time in a readable format and this is repeated for each process
        /// in the list.
        ///</summary>

        Console.WriteLine("FCFS Scheduling Results:");

        foreach (var p in processes)
        {
            Console.WriteLine($"{p.Name}: Finish={p.FinishTime}, " + $"Turnaround={p.TurnaroundTime}, " + $"Normalised={p.NormalisedTurnaround:F2}");
        }
    }
}


