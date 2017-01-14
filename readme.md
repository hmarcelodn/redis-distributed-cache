# SouthWorks Solution #

----------

Solution for the escalation engineer John Foo.

## SolutionApproach Folder ##

This solution folder contains the code with Distributed Cache with Redis using a Custom Output Cache Provider.

**Installation**

1. Download and Install Redis for Windows.
2. Run Redis in default port 6379.
3. Download Redis Desktop Manager for Windows.
4. Build the Solution and Restore Nuget Packages.
5. Press F5 to run the application.


## Troubleshooter Folder ##

This solution folder contains the code to reproduce the issue with output cache.

**Installation**

1. Build the Solution.
2. Deploy to local IIS or just run the project SouthWorks.Events.Web
3. On the application is running go to SouthWorks.Events.Console which is a .NET Core simple console to stress the web site.
4. Change the port to the one the application is running.
5. Launch a new instance of the console project and let it run.
6. Control from Task manager the wpw3.exe process or just Open IIS Worker Processes window to monitor memory.
