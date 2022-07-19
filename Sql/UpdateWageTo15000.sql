USE [EmployeesManager]
GO

UPDATE [dbo].[Employees]
	SET [Wage] = 15000.00
	WHERE [Wage] < 1500.00
GO


