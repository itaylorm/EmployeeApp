CREATE PROCEDURE [dbo].[spEmployees_Exit]
@Id int,
@ExitDate datetime
AS
begin
	UPDATE Employees
	SET ExitDate = @ExitDate,
	IsCurrent = 0
	WHERE Id = @Id
end
