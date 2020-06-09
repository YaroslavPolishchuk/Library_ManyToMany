use master
go
if DB_ID('AngularSample') is not null
	drop database AngularSample
create database AngularSample
go

use AngularSample
go

if OBJECT_ID('dbo.Manufacturers','U') is not null
	drop table dbo.Manufacturers
create table dbo.Manufacturers
(
	ManufacturerId int not null identity,
	ManufacturerName nvarchar(64) not null,
	constraint PK_Manufacturers primary key (ManufacturerId)
	)

if OBJECT_ID('dbo.Products''U') is not null
	drop table dbo.Products
create table dbo.Products
(
	ProductId int not null identity,
	ProductName nvarchar(128) not null,
	IdCode nvarchar(64) not null,
	ManufacturerId int not null,
	constraint PK_Products primary key(ProductId),
	constraint UNQ_Products_IdCode unique(IdCode),
)

if Object_ID('dbo.ProductPhoto''U') is not null
	drop table dbo.ProductPhoto
create table dbo.ProductPhoto
(
	ProductPhotoId int not null identity,
	ProductId int not null,
	PhotoPath nvarchar(256) not null,
	constraint PK_ProductPhoto primary key(ProductPhotoId),
	constraint FK_ProductId foreign key (ProductId) references dbo.Products(ProductId),
	constraint UNQ_PhotoPath unique(PhotoPath)
)