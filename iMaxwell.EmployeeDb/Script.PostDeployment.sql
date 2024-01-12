if not exists (select * from dbo.departments)
begin
    insert into dbo.Departments (Name)
    values 
        ('Accounting'),
        ('Human Resources'),
        ('Information Technology'),
        ('Marketing'),
        ('Sales')
end
go
if not exists (select * from dbo.employees)
begin
    insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
    values ('Taylor', 'Maxwell', 'CEO', 1000000, '2010-01-01', 1, null, null, 1)

	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Allen', 'Foster', 'CFO', 500000, '2010-01-01', 1, 1, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('John', 'Cooper', 'VP of Sales', 300000, '2010-01-01', 5, 1, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Janet', 'Alderson', 'VP of Marketing', 300000, '2010-01-01', 4, 1, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Barry', 'Wright', 'VP of IT', 300000, '2010-01-01', 3, 1, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Jane', 'Jones', 'VP of HR', 300000, '2010-01-01', 2, 1, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('John', 'Doe', 'Accountant', 100000, '2010-01-01', 1, 2, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Ellen', 'Chalmers', 'Accountant', 100000, '2010-01-01', 1, 2, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Marcia', 'Maxwell', 'Sales Manager', 100000, '2010-01-01', 5, 3, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Kim', 'Hull', 'Sales Manager', 100000, '2010-01-01', 5, 3, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Ethan', 'Hull', 'Marketing Manager', 100000, '2010-01-01', 4, 4, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Zeus', 'Jones', 'Marketing Manager', 100000, '2010-01-01', 4, 4, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Gary', 'Cooper', 'IT Manager', 100000, '2010-01-01', 3, 5, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Dolores', 'Doe', 'IT Manager', 100000, '2010-01-01', 3, 5, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Larry', 'Elger', 'HR Manager', 100000, '2010-01-01', 2, 6, null, 1)
	
	insert into dbo.employees(FirstName, LastName, Title, Salary, HireDate, DepartmentId, ManagerId, ExitDate, IsCurrent)
	values ('Gordon', 'Cooper', 'HR Manager', 100000, '2010-01-01', 2, 6, null, 1)
	
end