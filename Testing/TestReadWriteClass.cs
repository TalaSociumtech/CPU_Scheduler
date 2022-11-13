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
   
  
   

}
