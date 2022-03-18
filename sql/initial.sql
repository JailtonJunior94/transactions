CREATE DATABASE Transactions;
GO

USE Transactions; 
EXEC sys.sp_cdc_enable_db;

CREATE TABLE [Customers] 
(
   [Id] INTEGER IDENTITY(1, 1) NOT NULL PRIMARY KEY,
   [Document] VARCHAR(14) NOT NULL,
   [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE [Transaction]
(
    [Id] INTEGER IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    [CustomerId] INTEGER NOT NULL,
    [TransactionValue] [decimal](18, 2) NOT NULL,
    [TransactionDate] [datetime2](7) NOT NULL,
    [TransactionDescription] VARCHAR(255) NOT NULL,

    FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);

EXEC sys.sp_cdc_enable_table 
  @source_schema = 'dbo',
  @source_name = 'Transaction',
  @role_name = NULL,
  @supports_net_changes = 0;
GO

INSERT INTO [Customers] ([Document], [Name]) VALUES ('74593599806', 'Jailton');
INSERT INTO [Customers] ([Document], [Name]) VALUES ('76076763841', 'Stefany');
INSERT INTO [Customers] ([Document], [Name]) VALUES ('08377371847', 'Antony');

INSERT INTO [Transaction] ([CustomerId], [TransactionValue], [TransactionDate], [TransactionDescription]) VALUES (1, 2.50, GETDATE(), 'Rodoanel Oeste Castelo');
INSERT INTO [Transaction] ([CustomerId], [TransactionValue], [TransactionDate], [TransactionDescription]) VALUES (1, 19.50, GETDATE(), 'Estacionamento');
INSERT INTO [Transaction] ([CustomerId], [TransactionValue], [TransactionDate], [TransactionDescription]) VALUES (1, 0, GETDATE(), 'Mensalidade');

INSERT INTO [Transaction] ([CustomerId], [TransactionValue], [TransactionDate], [TransactionDescription]) VALUES (2, 2.50, GETDATE(), 'Rodoanel Oeste Castelo');
INSERT INTO [Transaction] ([CustomerId], [TransactionValue], [TransactionDate], [TransactionDescription]) VALUES (2, 2.50, GETDATE(), 'Rodoanel Oeste Castelo');

INSERT INTO [Transaction] ([CustomerId], [TransactionValue], [TransactionDate], [TransactionDescription]) VALUES (3, 19.50, GETDATE(), 'Estacionamento');
INSERT INTO [Transaction] ([CustomerId], [TransactionValue], [TransactionDate], [TransactionDescription]) VALUES (3, 0, GETDATE(), 'Mensalidade');