USE [EmployeesManager]
GO

DELETE FROM [dbo].[Employees]
      WHERE FLOOR(DATEDIFF(DAY, Birthday, GETDATE()) / 365.25) > 70
GO


