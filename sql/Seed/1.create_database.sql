USE master;
GO  

if not exists (select 1 from sys.databases where name = 'NbaOracle')
begin
  CREATE DATABASE NbaOracle
  ON   
  ( NAME = Metrics_Dat,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NbaOracle.mdf',  
    SIZE = 50,  
    MAXSIZE = 100,  
    FILEGROWTH = 5 )  
  LOG ON  
  ( NAME = NbaOracle_Log,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NbaOracle.ldf',
    SIZE = 50MB,  
    MAXSIZE = 100MB,  
    FILEGROWTH = 5MB ) ;  
end
go