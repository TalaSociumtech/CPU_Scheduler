using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading;
using System.Timers;
//using Newtonsoft.Json;

namespace CPU_Scheduler.Classes
{

    public class ShcedulerSJF : Interfaces.IScheduler
    {
        List<Processor>? processorList = new List<Processor>();
        List<Task>? taskList = new List<Task>();
        PriorityQueue<Task?, string> taskQueue = new PriorityQueue<Task?, string>();
       

        int clockcycle = 0;
        public ShcedulerSJF(){}

        string? strtesult=null;

        Processor processor = new Processor();
        public void readProcessorFile(string path){
           StreamReader sr = new StreamReader(path);
            strtesult = sr.ReadToEnd();
            sr.Close();

            processorList.AddRange((List<Processor>)JsonSerializer.Deserialize(strtesult, typeof(List<Processor>))); 
           
        }

        public void readTaskFile(string path){

            StreamReader sr = new StreamReader(path);
            strtesult = sr.ReadToEnd();
            sr.Close();
            taskList.AddRange((List<Task>)JsonSerializer.Deserialize(strtesult, typeof(List<Task>)));
            taskList.Sort();
        }

        public void writeResultFile(Processor processor, Task task)
        {
        
            string json = ".vscode/results.json";
            string Presults = JsonSerializer.Serialize<Processor>(processor);
            var Tresults = JsonSerializer.Serialize<Task>(task);
            Console.WriteLine(Presults + Tresults);
            StreamWriter wr = new StreamWriter(json);
           // wr.Write("In clockcycle" + clockcycle+ ":");
            if(task==null){
                wr.Write("[" + Presults+ "]");
            }else{
                wr.Write("["+ Presults + "," + Tresults +"]");
            }
            
            wr.Close();
            
        
        }
    
        public void sortTask()
        { 
            taskList.Sort();
            
        }
        public void taskEnqueue(){
            foreach(var item in taskList.ToList())
        {
            if(item.creationalTime == clockcycle){
                taskQueue.Enqueue(item, item.priority);
               
            }
        }
        }
        public void execution()
        {
       sortTask();
        int count =0;
       while(true)
       {
        Console.WriteLine("In ClockCycle " + clockcycle + " : {");
        taskEnqueue();
      
        foreach(var item in processorList)
        { 
                //Put waiting task in available processor, update Processor -> Busy, update task state -> Executing 
           if(item.state.Equals(CPU_Scheduler.Enums.ProcessorState.Idle.ToString()) && taskQueue.Count!=0){
                    item.task = taskQueue.Dequeue();
                        item.state = CPU_Scheduler.Enums.ProcessorState.Busy.ToString();
                         item.task.tState = CPU_Scheduler.Enums.TaskState.Executing.ToString();

                //Replace 'Low' task with 'High' task, update 'low' task state -> waiting, updating 'High' task state -> Executing   
            } else if(item.state.Equals(CPU_Scheduler.Enums.ProcessorState.Busy.ToString())&&
                item.task.priority.Equals(CPU_Scheduler.Enums.TaskPriority.Low.ToString()) && taskQueue.Count!=0 ){
                if(taskQueue.Peek().priority == "High" ){
                    taskQueue.Enqueue(item.task, item.task.priority);
                    item.task.tState = CPU_Scheduler.Enums.TaskState.Waiting.ToString();
                    item.task = taskQueue.Dequeue();
                    item.task.tState = CPU_Scheduler.Enums.TaskState.Executing.ToString();
                } 
            }
            
                //In case of Task complete : Update task state -> completed, processor -> Idle, get Completiong time and Waiting time
            if( item.state.Equals(CPU_Scheduler.Enums.ProcessorState.Busy.ToString()) && item.task.taskProcessingTime ==item.task.requestedTime)
            {
                item.state = (CPU_Scheduler.Enums.ProcessorState.Idle).ToString();
                item.task.tState = (CPU_Scheduler.Enums.TaskState.Completed).ToString();
                item.task.completionTime = clockcycle;
                item.task.waitingTime = item.task.completionTime - item.task.creationalTime;
                item.task=null;
                count++;
                

                //In case of Task !complete : increase Processing time, Update waiting time
            } else if(item.state.Equals(CPU_Scheduler.Enums.ProcessorState.Busy.ToString()) && item.task.taskProcessingTime !=item.task.requestedTime){
                item.task.taskProcessingTime+=1;
                item.task.waitingTime = clockcycle - item.task.creationalTime;
            }

               //Write the results of this clockcycle
            writeResultFile(item, item.task);
            Console.Write("}");
            Console.WriteLine();

             if(taskQueue.Count == 0 && processorList.Where(x=>x.state.Equals(CPU_Scheduler.Enums.ProcessorState.Idle)).Equals(0) ){
            
                break;
            }

        }
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine();

       clockcycle++;
       if(taskList.Count == count){
        break;
       } 
       
        }


    }

       
    
    }
}
