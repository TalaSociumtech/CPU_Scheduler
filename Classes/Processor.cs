using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using CPU_Scheduler.Enums;
namespace CPU_Scheduler.Classes
{
    public class Processor   {
       public string pId{get; set;}
       [JsonConverter(typeof(JsonStringEnumConverter))] public ProcessorState state{get; set;}
        public Task? task;
      
    }
}