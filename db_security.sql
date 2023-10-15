USE [master]
GO
CREATE DATABASE [db_security];
GO
USE [db_security]
GO
CREATE TABLE [user](
	 id_user INT IDENTITY(1,1) PRIMARY KEY,
	 username VARCHAR(100) NOT NULL,
	 [password] VARCHAR(100) NOT NULL
);