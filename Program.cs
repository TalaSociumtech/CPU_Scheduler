string processorfilepath = "JsonFiles/ProcessorsFile.json";
string taskfilepath = "JsonFiles/tasksFile.json";
CPU_Scheduler.Classes.ShcedulerSJF scheduler1 = new CPU_Scheduler.Classes.ShcedulerSJF();
scheduler1.readProcessorFile(processorfilepath);
scheduler1.readTaskFile(taskfilepath);
scheduler1.execution();