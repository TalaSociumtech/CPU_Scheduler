using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPU_Scheduler.Interfaces
{
    public interface IScheduler
    {
       public List<CPU_Scheduler.Classes.Task> execution(List<CPU_Scheduler.Classes.Processor> processorList, List<CPU_Scheduler.Classes.Task> taskList);
       
    }
}