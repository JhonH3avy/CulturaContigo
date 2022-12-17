CREATE TABLE [dbo].[Activities]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Place] VARCHAR(50) NULL, 
    [ScheduledDateTime] DATETIME2 NULL, 
    [TicketPrice] DECIMAL(20, 2) NULL, 
    [Details] VARCHAR(1000) NOT NULL, 
    [Capacity] INT NULL, 
    [Available] INT NULL, 
    [ImageUrl] VARCHAR(MAX) NULL 
)
