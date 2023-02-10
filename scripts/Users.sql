CREATE TABLE Users
(
	Id bigint identity not null,
	Name varchar(50) not null,
	LastName varchar(50) not null,
	Email varchar(50) not null,
	Password varchar(50) not null
)