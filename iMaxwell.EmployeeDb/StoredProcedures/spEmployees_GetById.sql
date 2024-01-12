CREATE PROCEDURE [dbo].[spEmployees_GetById]
@Id int
AS
begin
	select * from Employees where Id = @Id
end
