using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPU_Scheduler.Classes
{
    public class Processor {
       public string? pId{get; set;}
        public string? state{get; set;}
        public Task? task;
        public Processor(){}
      
    }
}