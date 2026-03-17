using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_app___deberati
{
    internal class Job
    {
        public string ID { get; set; }
        public int arrivalTime { get; set; }
        public int executionTime { get; set; }
        public int priority { get; set; }
        public Job(string id, int arrivalTime, int executionTime, int priority)
        {
            this.ID = id;
            this.arrivalTime = arrivalTime;
            this.executionTime = executionTime;
            this.priority = priority;
        }
    }
}
