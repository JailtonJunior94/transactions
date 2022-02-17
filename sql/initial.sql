CREATE DATABASE Transactions;
GO

USE Transactions; 
EXEC sys.sp_cdc_enable_db;

CREATE TABLE [Transaction]
(
    [Id] INTEGER IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(255) NOT NULL,
);

INSERT INTO [Transaction] ([Name]) VALUES ('Passagem');
INSERT INTO [Transaction] ([Name]) VALUES ('Estacionamento');

EXEC sys.sp_cdc_enable_table 
  @source_schema = 'dbo',
  @source_name = 'Transaction',
  @role_name = NULL,
  @supports_net_changes = 0;
GO
