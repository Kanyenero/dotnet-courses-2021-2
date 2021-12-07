/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [ID]
      ,[Name]
      ,[LastName]
      ,[Birthdate]
  FROM [PersonsAndAwards].[dbo].[Persons]

  SELECT TOP (1000) [ID]
      ,[Title]
	  ,[Descr]
  FROM [PersonsAndAwards].[dbo].[Awards]

    SELECT TOP (1000) [ID]
      ,[Person_ID]
	  ,[Award_ID]
  FROM [PersonsAndAwards].[dbo].[Relations]