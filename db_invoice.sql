create database db_invoice;
create table invoice(
	id_invoice integer primary key generated always as identity,
	amount decimal(10,2),
	state integer
);