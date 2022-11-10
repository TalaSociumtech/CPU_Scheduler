using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;
using CPU_Scheduler.Enums;
namespace CPU_Scheduler.Classes 
{
    public class Task: IComparable<Task>{
        public String tId {get; set;}
        public int creationalTime {get; set;}
        public int requestedTime {get; set;}
        public int completionTime {get; set;}
        [JsonConverter(typeof(JsonStringEnumConverter))] public TaskPriority priority {get; set;}
        [JsonConverter(typeof(JsonStringEnumConverter))] public TaskState tState {get; set;}

        public int waitingTime{get;set;}
        public int taskProcessingTime{get; set;}
        
       
        public Task(){
            waitingTime =0;
            completionTime = 0;
            taskProcessingTime = 0;
        }

        public int CompareTo(Task? other)
        {
           
          return creationalTime.CompareTo(other.creationalTime);
        }


    }
}