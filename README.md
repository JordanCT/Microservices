# Microservicios BCP.Muchik.Market
## Configuración de BD
1. **Configuración db_security `SqlServer`.**
    ```SQL
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
2. **Configuración db_invoice `PostgreSQL`.**
    ```SQL
      create database db_invoice;
      create table invoice(
        id_invoice integer primary key generated always as identity,
        amount decimal(10,2),
        state integer
      );
3. **Configuración db_operation `MySQL`.**
    ```SQL
      CREATE DATABASE db_operation;
      USE db_operation
      CREATE TABLE operation(
        id_operation INT AUTO_INCREMENT PRIMARY KEY,
        id_invoice INT,
        amount DECIMAL(10,2),
        date_modified DATETIME
      );
4. **Configuración db_transactions `MongoDB`.**
    ```javascript
      use db_transactions;
      db.transactions.insertOne(
          {
              "id_invoice": 2,
              "amount": {
                  "$numberDecimal": "100.0"
              },
              "date": {
                  "$date": "2023-10-18T01:10:56.355Z"
              }
          });