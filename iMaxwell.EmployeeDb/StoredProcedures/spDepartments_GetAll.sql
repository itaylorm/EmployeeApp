CREATE PROCEDURE [dbo].[spDepartments_GetAll]
AS
begin
	SELECT 
		[Id],
		[Name]
	FROM [dbo].[Departments]
end
