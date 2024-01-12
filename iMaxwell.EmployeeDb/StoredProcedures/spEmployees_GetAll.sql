CREATE PROCEDURE [dbo].[spEmployees_GetAll]
AS
begin
	SELECT 
		[Id],
		[FirstName],
		[LastName],
		[Title],
		[Salary],
		[HireDate],
		[ExitDate],
		[ManagerId],
		[DepartmentId],
		[IsCurrent]
	FROM [dbo].[Employees]
end
