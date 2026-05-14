using System;

class Program
{
    static void Main()
    {
        /// <summary>
        /// The first section of code asks the user to enter the number of processes, resource types,
        /// the allocation matrix, the maximum demand matrix and the available resources that will be used
        /// in the algorithm. Once this information has been entered, arrays are created
        /// to store the matrices, need and resource values so they can later be used later on in the
        /// algorithm. It also uses the processes entered by the user to produce the finished bool array and
        /// the safeSequence array. Finally the completed process array is produced and set to 0.
        /// </summary>

        Console.Write("Number of processes: ");
        int processes = int.Parse(Console.ReadLine());

        Console.Write("Number of resource types: ");
        int resources = int.Parse(Console.ReadLine());

        int[,] allocation = new int[processes, resources];
        int[,] maximum = new int[processes, resources];
        int[,] need = new int[processes, resources];
        int[] available = new int[resources];

        Console.WriteLine("Enter allocation matrix:");

        for (int i = 0; i < processes; i++)
        {
            Console.Write($"P{i + 1}: ");
            string[] values = Console.ReadLine().Split(' ');

            for (int j = 0; j < resources; j++)
            {
                allocation[i, j] = int.Parse(values[j]);
            }
        }

        Console.WriteLine("Enter maximum demand matrix:");

        for (int i = 0; i < processes; i++)
        {
            Console.Write($"P{i + 1}: ");
            string[] values = Console.ReadLine().Split(' ');

            for (int j = 0; j < resources; j++)
            {
                maximum[i, j] = int.Parse(values[j]);
            }
        }

        Console.WriteLine("Enter available resources:");

        string[] availableValues = Console.ReadLine().Split(' ');

        for (int i = 0; i < resources; i++)
        {
            available[i] = int.Parse(availableValues[i]);
        }

        for (int i = 0; i < processes; i++)
        {
            for (int j = 0; j < resources; j++)
            {
                need[i, j] = maximum[i, j] - allocation[i, j];
            }
        }

        bool[] finished = new bool[processes];
        int[] safeSequence = new int[processes];
        int completedProcesses = 0;

        /// <summary>
        /// This section of code performs the main Banker’s Algorithm safety check by performing a while loop
        /// that runs as long as the number of completed processes is less than the number of processes. It
        /// checks if the process has not already finished and if not, the canRun bool is set to true and the
        /// code checks whether the remaining need is greater than the currently available resources. If the
        /// need is greater than the available resources, canRun becomes false and the code breaks. However,
        /// if there are enough available resources, the process is allowed to execute safely, its allocated
        /// resources are returned back into the system after completion and 1 is added to the completed
        /// processes counter. This continues until all processes have either completed successfully or no
        /// safe process can be found.
        /// </summary>

        while (completedProcesses < processes)
        {
            bool foundProcess = false;

            for (int i = 0; i < processes; i++)
            {
                if (!finished[i])
                {
                    bool canRun = true;

                    for (int j = 0; j < resources; j++)
                    {
                        if (need[i, j] > available[j])
                        {
                            canRun = false;
                            break;
                        }
                    }

                    if (canRun)
                    {
                        for (int j = 0; j < resources; j++)
                        {
                            available[j] += allocation[i, j];
                        }

                        safeSequence[completedProcesses] = i;
                        completedProcesses++;

                        finished[i] = true;
                        foundProcess = true;
                    }
                }
            }

            if (!foundProcess)
            {
                break;
            }
        }

        /// <summary>
        /// The final section of code outputs the result of the algorithm. If every process was able to
        /// complete successfully, the code outputs the safe sequence and confirms that the system is in a
        /// safe state but if all processes could not safely execute, the program instead outputs that the
        /// system is unsafe. This process is repeated whilst i is less than the neumber of processes in 
        /// the algorithm which is shown in the code with for (int i = 0; i < processes; i++).
        /// </summary>

        if (completedProcesses == processes)
        {
            Console.Write("Safe Sequence: ");

            for (int i = 0; i < processes; i++)
            {
                Console.Write($"P{safeSequence[i] + 1}");

                if (i < processes - 1)
                {
                    Console.Write(" -> ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("System is in a safe state.");
        }
        else
        {
            Console.WriteLine("System is not in a safe state.");
        }
    }
}