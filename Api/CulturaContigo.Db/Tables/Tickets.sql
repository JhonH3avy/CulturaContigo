CREATE TABLE [dbo].[Tickets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ActivityId] INT NOT NULL, 
    [TypeOfId] VARCHAR(50) NOT NULL, 
    [PersonalId] VARCHAR(100) NOT NULL, 
    [NumberOfTickets] INT NOT NULL, 
    CONSTRAINT [FK_Tickets_Activities_ActivityId] FOREIGN KEY ([ActivityId]) REFERENCES [Activities]([Id])
)
