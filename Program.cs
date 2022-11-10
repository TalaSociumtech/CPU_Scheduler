using CPU_Scheduler.Classes;
        List<Processor>? processorList = new List<Processor>();
        List<CPU_Scheduler.Classes.Task>? taskList = new List<CPU_Scheduler.Classes.Task>();
        List<CPU_Scheduler.Classes.Task>? completedTask = new List<CPU_Scheduler.Classes.Task>();



string processorfilepath = "JsonFiles/ProcessorsFile.json";
string taskfilepath = "JsonFiles/tasksFile.json";
ShcedulerSJF scheduler1 = new  ShcedulerSJF();
ReadWrite rw = new ReadWrite();

processorList = rw.readProcessorFile(processorfilepath, processorList);
taskList = rw.readTaskFile(taskfilepath, taskList);
completedTask = scheduler1.execution (processorList, taskList);
rw.writeResultFile(completedTask);