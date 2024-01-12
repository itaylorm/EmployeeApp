CREATE PROCEDURE [dbo].[spEmployees_Update]
@Id int,
@Salary money
AS
Begin
	UPDATE Employees
	SET Salary = @Salary
	WHERE Id = @Id
end
