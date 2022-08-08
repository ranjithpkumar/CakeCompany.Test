
This is a simple console application and the code is developed using C#.Net core 6.0.

This application can be built and verified using either visual studio with latest .net core 6.0 framework/CLI command either powershell.

How to build the code?

To build the application, please use any of the steps mentioned below:

Run the following commands as Administrator:

First Approach:

Run the application via PowerShell.

Go to the Project folder. Sample commands are as follows

PS C:\Users\Ranjith\source\repos\CakeCompany> dotnet build
Once the build is complete and “Build Success message will be displayed”, if there is no error.

Second Approach

Follow the same steps are mentioned in the above using command prompt rather than powershell.

Third Approach

Use Visual Studio 2019/VS Code.
.Net Core 5.0 should be installed to build this project.
Open the CakeCompany.sin file from your local machine and wait until Nuget packages get downloaded. Once it’s complete, build the project, 
once build is completed, it’s ready to verify the results.

How to run the output?

Run the following commands as Administrator:

Open Powershell

Go to the Project folder. Sample command is provided as follows

C:\Users\Ranjith\source\repos\CakeCompany\bin\Debug\net6.0

Run the following command PS C:\Users\Ranjith\source\repos\CakeCompany\bin\Debug\net6.0> .\CakeCompany.exe
output  will be displayed

PS C:\Users\Ranjith\source\repos\CakeCompany\bin\Debug\net6.0> .\CakeCompany.exe

If there are any issues, Error will be logged and generated where the log file path is defined in the appsettings.

verification can be done via CMD as well

The same steps have to be followed like powershell.

This application was developed based on the below assumptions

  
   This application is built on console application , since it's a Simple application , it does not require a user input.

There are prerequisites to execute this application
.Net 6.0 should be installed on the machine 

Serial logger has been used to log the errors/information.

Factory pattern is used for object creation.

Solid prinicple is followed for clean code

DI container is used for loosely coupled .

Unittest project is also added.
