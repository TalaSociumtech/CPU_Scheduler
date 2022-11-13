using Xunit;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using CPU_Scheduler.Classes;
using CPU_Scheduler.Enums;
public class TestSchedulerClass 
{
        List<Processor> mockProcessorList = new List<Processor>();
        List<CPU_Scheduler.Classes.Task> mockTaskList = new List<CPU_Scheduler.Classes.Task>();
        List<CPU_Scheduler.Classes.Task> mockCompletedTask = new List<CPU_Scheduler.Classes.Task>();
    
    

   
   [Fact]
   public void TestExecution(){

Processor processor = new Processor();
    processor.pId = "p2";
    processor.state = ProcessorState.Idle;
    
    CPU_Scheduler.Classes.Task task = new CPU_Scheduler.Classes.Task();
    task.tId = "t1";
    task.requestedTime = 5;
    task.creationalTime = 3;
    task.tState = TaskState.Waiting;
    task.priority = TaskPriority.High;

    mockProcessorList.Add(processor);
    mockTaskList.Add(task);


    ShcedulerSJF shceduler1 = new ShcedulerSJF();
    mockCompletedTask = shceduler1.execution(mockProcessorList, mockTaskList);

    int waitingTime = mockCompletedTask[0].waitingTime;
    int expectedTime = mockCompletedTask[0].completionTime - mockCompletedTask[0].creationalTime;
    Assert.Equal(expectedTime, waitingTime);

    int completionTime = mockCompletedTask[0].completionTime;
    Assert.Equal(8, completionTime);


   }
}