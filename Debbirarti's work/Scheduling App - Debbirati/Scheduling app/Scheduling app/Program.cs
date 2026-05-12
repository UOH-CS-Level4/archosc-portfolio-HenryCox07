using System;
using System.Collections.Generic;
using System.Linq;

///<summary>
/// The code here is a long term scheduling algorithm which takes a set of jobs and orders them by priority,arrival
/// time and execution time. The way it does this is by looking at the arrival time of each job (job a and b) and
/// putting them in an appropriate order going from quickest arrival time to slowest arrival time. Then the method 
/// AdmitJobs checks to see if the priority for each job passes the minimum priority requirement (they need
/// to have a priority of 5); if they do not they are excluded from the final list of jobs.
///</summary>

public class Job
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public int ArrivalTime { get; set; }
    public int ExecutionTime { get; set; }

    // Returns the job details in a readable format.
    public override string ToString()
    {
        return $"Job {Name}, Priority: {Priority}, Arrival Time: {ArrivalTime}, Execution Time: {ExecutionTime}";
    }
}

class Program
{
    // This method compares the arrival time for each of the jobs and sorts them accordingly.
    private static int CompareByArrivalTime(Job a, Job b)
    {
        if (a.ArrivalTime < b.ArrivalTime) return -1;
        if (a.ArrivalTime > b.ArrivalTime) return 1;
        return 0;
    }

    // This method filters the jobs based on a minimum priority value and then sorts the admitted jobs by arrival time.
    public static List<Job> AdmitJobs(List<Job> jobs, int minPriority)
    {
        // This list stores all jobs that meet the minimum priority requirement.
        List<Job> admittedJobs = new List<Job>();

        // The foreach loop checks each job in the list.
        foreach (Job job in jobs)
        {
            // If the job priority is greater than or equal to the minimum priority,it is added to the admitted jobs list.
            if (job.Priority >= minPriority)
            {
                admittedJobs.Add(job);
            }
        }

        /// This line sorts the admitted jobs by arrival time so that they are processed in the correct order.
        admittedJobs.Sort(CompareByArrivalTime);

        return admittedJobs;
    }

    static void Main()
    {
        Console.WriteLine("Hello, World!");

        // This list contains all jobs with their priority, arrival time, and execution time values.
        var jobs = new List<Job>
        {
            new Job { Name = "A", Priority = 7, ArrivalTime = 0, ExecutionTime = 5 },
            new Job { Name = "B", Priority = 4, ArrivalTime = 2, ExecutionTime = 3 },
            new Job { Name = "C", Priority = 6, ArrivalTime = 4, ExecutionTime = 4 },
            new Job { Name = "D", Priority = 6, ArrivalTime = 3, ExecutionTime = 6 },
            new Job { Name = "E", Priority = 8, ArrivalTime = 6, ExecutionTime = 10 },
            new Job { Name = "F", Priority = 9, ArrivalTime = 2, ExecutionTime = 3 },
            new Job { Name = "G", Priority = 10, ArrivalTime = 6, ExecutionTime = 7 }
        };

        // This part of the code calls the AdmitJobs method and filters out any jobs with a priority lower than 5.
        var admitted = AdmitJobs(jobs, minPriority: 5);


        // The foreach loop below prints all admitted jobs in a readable format. 
        foreach (var job in admitted)
        {
            Console.WriteLine(job);
        }
    }
}
