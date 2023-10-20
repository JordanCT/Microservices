CREATE DATABASE db_operation;
USE db_operation
CREATE TABLE operation(
	id_operation INT AUTO_INCREMENT PRIMARY KEY,
	id_invoice INT,
	amount DECIMAL(10,2),
	date_modified DATETIME
);
