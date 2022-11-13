using Xunit;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using CPU_Scheduler.Classes;
using CPU_Scheduler.Enums;
public class TestClass 
{
        List<Processor> mockProcessorList = new List<Processor>();
        List<CPU_Scheduler.Classes.Task> mockTaskList = new List<CPU_Scheduler.Classes.Task>();
        List<CPU_Scheduler.Classes.Task> mockCompletedTask = new List<CPU_Scheduler.Classes.Task>();
    
    

    [Fact]
    public void TestProcessorsReadFile(){
    
    ReadWrite pathReader = new ReadWrite();
    string path = "ProcessorsFile.json";
    
    pathReader.readProcessorFile(path, mockProcessorList);   
    Assert.NotEmpty(mockProcessorList);
    }
  
[Fact]
  public void TestTaskReadFile(){

    ReadWrite pathReader = new ReadWrite();
    string path = "tasksFile.json";

    mockTaskList=pathReader.readTaskFile(path, mockTaskList);
    Assert.NotEmpty(mockTaskList);
   } 

   [Fact]
   public void TestCompletedTaskNotEmpty(){

       ReadWrite pathReader1 = new ReadWrite();
    string path1 = "ProcessorsFile.json";
    mockProcessorList= pathReader1.readProcessorFile(path1, mockProcessorList);

    ReadWrite pathReader2 = new ReadWrite();
    string path2 = "tasksFile.json";
    mockTaskList=pathReader2.readTaskFile(path2, mockTaskList);

    ShcedulerSJF shceduler1 = new ShcedulerSJF();
    mockCompletedTask = shceduler1.execution(mockProcessorList, mockTaskList);
    Assert.NotEmpty(mockCompletedTask);
   } 

   [Fact]
    public void TestCompletionTime(){
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

    int completionTime = mockCompletedTask[0].completionTime;
    Assert.Equal(8, completionTime);
    
   }

   [Fact]
    public void TestWaitingTime(){

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

   }
}