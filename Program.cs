string processorfilepath = "/home/tala/Documents/Tala_C#/CPU_Scheduler/.vscode/ProcessorsFile.json";
string taskfilepath = "/home/tala/Documents/Tala_C#/CPU_Scheduler/.vscode/tasksFile.json";
CPU_Scheduler.Classes.ShcedulerSJF scheduler1 = new CPU_Scheduler.Classes.ShcedulerSJF();
scheduler1.readProcessorFile(processorfilepath);
scheduler1.readTaskFile(taskfilepath);
scheduler1.execution();