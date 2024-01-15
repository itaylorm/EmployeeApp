CREATE PROCEDURE [dbo].[spEmployees_Delete]
@Id int
AS
Begin
	DELETE FROM Employees WHERE Id = @Id
end