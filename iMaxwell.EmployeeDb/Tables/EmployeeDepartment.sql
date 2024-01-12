ALTER TABLE [dbo].Employees
	ADD CONSTRAINT FK_EmployeeDepartment
	FOREIGN KEY (DepartmentId)
	REFERENCES Departments (Id)
