CREATE PROCEDURE [dbo].[spDepartments_Create]
@Name nvarchar(50),
@Id int OUTPUT
AS
begin
	INSERT INTO [dbo].[Departments]
	(
		[Name]
	)
	VALUES
	(
		@Name
	)
	SET @Id = SCOPE_IDENTITY()
end
