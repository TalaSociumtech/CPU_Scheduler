using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading;
using System.Timers;
using CPU_Scheduler.Enums;

namespace CPU_Scheduler.Classes
{

    public class ShcedulerSJF : Interfaces.IScheduler
    {
        List<Task>? completedTask = new List<Task>();
        PriorityQueue<Task, int> taskQueue = new PriorityQueue<Task, int>();
        int clockcycle = 0;
        public ShcedulerSJF(){}

        string? strtesult=null;
        public void taskEnqueue(List<Task> taskList){
            foreach(var item in taskList.ToList())
        {
            if(item.creationalTime == clockcycle){
                taskQueue.Enqueue(item, (int)item.priority);
               taskList.Remove(item);
            }
        }
        }
        public List<Task> execution (List<Processor> processorList, List<Task> taskList)
        {
            int count =taskList.Count();
       while(true)
       {
        taskEnqueue(taskList);
         
        
       
        foreach(var item in processorList)
        {       
                //Put waiting task in available processor, update Processor -> Busy, update task state -> Executing 
           if(item.state.Equals(ProcessorState.Idle) && taskQueue.Count!=0){
                    item.task = taskQueue.Dequeue();
                        item.state =  ProcessorState.Busy;
                        item.task.tState = TaskState.Executing;

                //Replace 'Low' task with 'High' task, update 'low' task state -> waiting, updating 'High' task state -> Executing   
            } else if(item.state.Equals(ProcessorState.Busy)&&
                item.task.priority.Equals(TaskPriority.Low) && taskQueue.Count!=0 ){
                if(taskQueue.Peek().priority.Equals(TaskPriority.High) ){
                    taskQueue.Enqueue(item.task, (int)item.task.priority);
                    item.task.tState = TaskState.Waiting;
                    item.task = taskQueue.Dequeue();
                    item.task.tState = TaskState.Executing;
                } 
            }
            
                //In case of Task complete : Update task state -> completed, processor -> Idle, get Completion time and Waiting time
            if( item.state.Equals(ProcessorState.Busy) && item.task.taskProcessingTime ==item.task.requestedTime)
            {
                item.state = ProcessorState.Idle;
                item.task.tState = TaskState.Completed;
                item.task.completionTime = clockcycle;
                item.task.waitingTime = item.task.completionTime - item.task.creationalTime;
                completedTask.Add(item.task);
                item.task=null;

                
                

                //In case of Task !complete : increase Processing time, Update waiting time
            } else if(item.state.Equals(ProcessorState.Busy) && item.task.taskProcessingTime !=item.task.requestedTime){
                item.task.taskProcessingTime+=1;
                item.task.waitingTime = clockcycle - item.task.creationalTime;
            }
             if(taskQueue.Count == 0 && processorList.Where(x=>x.state.Equals(ProcessorState.Idle)).Equals(0) ){
            
                break;
            }

               
        }
        
       clockcycle++;
       if(taskList.Count == 0 && completedTask.Count==count){
        break;
       } 
      
        }
      
      return completedTask;

    }

        
    }
}
