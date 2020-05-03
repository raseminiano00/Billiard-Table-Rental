# Billiard-Table-Rental
Program that monitors the Billiard Table Rental created 

C# Windows Form Application


For configuration of Pomelo : 

1. Add Windows Power Shell in Visual Studio
2. dotnet add package Microsoft.EntityFrameworkCore.Design --v [Accoding to your netstandard version]
3. dotnet add package Pomelo.EntityFrameworkCore.MySql --version [According to your netstandard version]
4. Add this to <itemGroup> xml of your Persistence Layer <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.1.0" />
5. dotnet ef to windows power shell theh unicorn must be appeared after the execution
6. dotnet ef dbcontext scaffold 'Server=xxx;Database=xx;Uid=xxxx;Pwd=xxxx;' 'Pomelo.EntityFr
ameworkCore.Mysql' -o .\[Desired location of generated models] -f
