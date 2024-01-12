CREATE PROCEDURE [dbo].[spEmployees_Create]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Title nvarchar(50),
	@Salary money,
	@HireDate datetime2,
	@ExitDate datetime2,
	@ManagerId int,
	@DepartmentId int,
	@Id int OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[Employees]
	(
		[FirstName],
		[LastName],
		[Title],
		[Salary],
		[HireDate],
		[ExitDate],
		[ManagerId],
		[DepartmentId],
		[IsCurrent]
	)
	VALUES
	(
		@FirstName,
		@LastName,
		@Title,
		@Salary,
		@HireDate,
		@ExitDate,
		@ManagerId,
		@DepartmentId,
		1
	)
	SET @Id = SCOPE_IDENTITY()
END
