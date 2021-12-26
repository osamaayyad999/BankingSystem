create database "Banking-System"
use "Banking-System"

create table Department (
	DepartmentID int Primary Key,
	DepartmentName varchar(255) Not Null,
	DepartmentStatus bit Not Null,
)

create table Employee (
	EmployeeID int IDENTITY(1,1) PRIMARY KEY,
	DepartmentID int Not Null,
	RoleID int Not Null,
	EmployeeUsername varchar(255) Not Null,
	EmployeePassword varchar(255) Not Null,
	EmployeeEmail varchar(255) Not Null,
	EmployeeStatus bit Not Null,
)

create table EmployeeRole (
	RoleID int IDENTITY(1,1) PRIMARY KEY,
	RoleName varchar(255) Not Null,
	RoleStatus bit Not Null,
)

create table Customer (
	CustomerID int IDENTITY(1,1) PRIMARY KEY,
	CustomerFirstName varchar(255) Not Null,
	CustomerLastName varchar(255) Not Null,
	CustomerAge int Not Null,
	CustomerGender varchar(255) Not Null,
	CustomerPhone int Not Null,
	CustomerEmail varchar(255) Not Null,
	CustomerIdentity int Not Null,
	CustomerStatus bit Not Null,
)
create table Account (
	AccountID int IDENTITY(1,1) PRIMARY KEY,
	CustomerID int Not Null,
	AccountType varchar(255) Not Null,
	AccountStatus bit Not Null,
	AccountCreateTime datetime Not Null,
	AccountlastSeenTime datetime Not Null, 
)

create table AccountBalance (
	AccountID int IDENTITY(1,1) PRIMARY KEY,
	AccountAmount varchar(255),
	AccountAmountStatus bit Not Null,
)