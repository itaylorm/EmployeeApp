CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Salary] MONEY NOT NULL, 
    [HireDate] DATETIME2 NOT NULL, 
    [ExitDate] DATETIME2 NULL, 
    [IsCurrent] BIT NOT NULL, 
    [ManagerId] INT NULL, 
    [DepartmentId] INT NOT NULL 
)
