CREATE PROCEDURE [dbo].[spEmployees_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Title nvarchar(50),
	@Salary money,
	@HireDate datetime2,
	@ManagerId int,
	@DepartmentId int
AS
Begin
	Update Employees
Set FirstName = @FirstName,
		LastName = @LastName,
		Title = @Title,
		Salary = @Salary,
		HireDate = @HireDate,
		ManagerId = @ManagerId,
		DepartmentId = @DepartmentId
	Where Id = @Id
end