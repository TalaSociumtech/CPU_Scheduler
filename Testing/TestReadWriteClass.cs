using Xunit;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using CPU_Scheduler.Classes;
using CPU_Scheduler.Enums;
public class TestReadWriteClass 
{
        List<Processor> mockProcessorList = new List<Processor>();
        List<CPU_Scheduler.Classes.Task> mockTaskList = new List<CPU_Scheduler.Classes.Task>();
        List<CPU_Scheduler.Classes.Task> mockCompletedTask = new List<CPU_Scheduler.Classes.Task>();
    
    

    [Fact]
    public void TestReadProcessorFile(){
    
    ReadWrite pathReader = new ReadWrite();
    string path = "ProcessorsFile.json";
    
    pathReader.readProcessorFile(path, mockProcessorList);   
    Assert.NotEmpty(mockProcessorList);
    }
  
[Fact]
  public void TestReadTaskFile(){

    ReadWrite pathReader = new ReadWrite();
    string path = "tasksFile.json";

    mockTaskList=pathReader.readTaskFile(path, mockTaskList);
    Assert.NotEmpty(mockTaskList);
   } 

   [Fact]
   public void TestWriteResultFile(){

      CPU_Scheduler.Classes.Task task = new CPU_Scheduler.Classes.Task();
    task.tId = "t1";
    task.requestedTime = 5;
    task.creationalTime = 3;
    task.completionTime = 8;
    task.waitingTime = 5;
    task.tState = TaskState.Completed;
    task.priority = TaskPriority.High;
     mockCompletedTask.Add(task);
     ReadWrite resultReader = new ReadWrite();
     string path = "results.json";
    resultReader.writeResultFile(path, mockCompletedTask);
    mockTaskList=resultReader.readTaskFile(path, mockTaskList);
    Assert.NotEmpty(mockTaskList);
   } 
   
  
   

}
