ALTER TABLE [dbo].Employees
	ADD CONSTRAINT FK_EmployeeManager
	FOREIGN KEY (ManagerId)
	REFERENCES Employees (Id)
