using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace CPU_Scheduler.Classes
{
    public class ReadWrite
    {
          
        public List<Processor> readProcessorFile(string path, List<Processor> processorList){
           StreamReader sr = new StreamReader(path);
          string strResult = sr.ReadToEnd();
            sr.Close();

            processorList.AddRange((List<Processor>)JsonSerializer.Deserialize(strResult, typeof(List<Processor>)));
            


            return processorList;
           
        }

        public List<Task> readTaskFile(string path, List<Task> taskList){

            StreamReader sr = new StreamReader(path);
            string? strResult = sr.ReadToEnd();
            sr.Close();
            taskList.AddRange((List<Task>)JsonSerializer.Deserialize(strResult, typeof(List<Task>)));
            taskList.Sort();

            return taskList;
        }

        public void writeResultFile( List<Task> completedTask )
        {

             string json = "JsonFiles/results.json";
             var Tresults = JsonSerializer.Serialize<List<Task>>(completedTask);
            StreamWriter wr = new StreamWriter(json);
            wr.Write(Tresults);
            wr.Close();
            
        
        }
    }
}