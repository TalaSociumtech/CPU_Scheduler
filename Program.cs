string processorfilepath = ".vscode/ProcessorsFile.json";
string taskfilepath = ".vscode/tasksFile.json";
CPU_Scheduler.Classes.ShcedulerSJF scheduler1 = new CPU_Scheduler.Classes.ShcedulerSJF();
scheduler1.readProcessorFile(processorfilepath);
scheduler1.readTaskFile(taskfilepath);
scheduler1.execution();