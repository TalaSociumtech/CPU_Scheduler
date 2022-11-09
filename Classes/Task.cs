using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPU_Scheduler.Classes 
{
    public class Task: IComparable<Task>{
        public String? tId {get; set;}
        public int creationalTime {get; set;}
        public int requestedTime {get; set;}
        public int completionTime {get; set;}
        public string? priority {get; set;}
        public string? tState {get; set;}

        public int waitingTime{get;set;}
        public int taskProcessingTime{get; set;}
        
       
        public Task(){
            waitingTime =0;
            completionTime = 0;
            taskProcessingTime = requestedTime;
        }

        public int CompareTo(Task? other)
        {
           
          return creationalTime.CompareTo(other.creationalTime);
        }


    }
}