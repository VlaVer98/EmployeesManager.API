USE [EmployeesManager]
GO

SELECT [Id]
      ,[Department]
      ,[FirstName]
      ,[LastName]
      ,[Patronymic]
      ,[Birthday]
      ,[EmploymentDate]
      ,[Wage]
  FROM [dbo].[Employees] WHERE [Wage] > 10000.00

GO


