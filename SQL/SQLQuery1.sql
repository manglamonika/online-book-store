create database BookDemo;

use BookDemo;


CREATE TABLE tblRole (
 RoleId int primary key IDENTITY (1, 1),
   RoleName varchar(50)       
);
Insert into tblRole values('ADMIN');
Insert into tblRole values('USER');

select * from tblRole;
----------------------------------------------

CREATE TABLE tblUsers (
	UserId int primary key IDENTITY (1000, 1),
    [Email] varchar(50),
	[Password] varchar(50),
    [Name] VARCHAR (50) NOT NULL,
    Mobile VARCHAR (50) NOT NULL,
	[Address] varchar(100),
	RoleId int,
	IsAdmin bit,
	FOREIGN KEY (RoleId) REFERENCES tblRole (RoleId)
    );

Insert into tblUsers([Email],[Password],[Name],Mobile,[Address],RoleId,IsAdmin) values('admin@gmail.com','admin@123','ADMIN','123456789','test',1,1);
select * from tblUsers;
---------------------------------------------------------------
CREATE TABLE [tblBooks](
	[BookId] [int] primary key IDENTITY(1,1) NOT NULL,
	[IsBn] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
	[Auther] [varchar](50) NULL,
	[Publisher] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Publisheddate] [varchar](500) NULL,
	[Language] [varchar](50) NULL,
	[UserId] [int] NULL,
	[OrderStatusId] [int] NULL);
	select * from [tblBooks];
	
	

CREATE TABLE [dbo].[tblOrderStatus](
	[OrderStatusId] [int] primary key IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NULL);



	CREATE TABLE [tblOrders](
	[OrderId] [int] Primary Key IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[BookId] [int] NULL,
	[OrderStatusId] [int] NULL,
	[BuyUserId] [int] NULL,
	FOREIGN KEY (BookId) REFERENCES tblBooks (BookId),
	FOREIGN KEY (OrderStatusId) REFERENCES tblOrderStatus (OrderStatusId));
	select * from [tblOrders];

----------------------------------------------------------------------------

	
	insert into tblOrderStatus values('Sell');
insert into tblOrderStatus values('Buy');
insert into tblOrderStatus values('InProgress');
select * from tblOrderStatus;
------------------------------------------------------------------------------
CREATE PROCEDURE SP_SellBooks @BookId int, @UserId int
AS
begin
insert into tblOrders(BookId,UserId,OrderStatusId) values(@BookId,@UserId,2);
update tblBooks set OrderStatusId=3 where  BookId=@BookId and UserId=@UserId;
end

-----------------------------------------------------------------------
CREATE PROCEDURE SP_DellBooks @BookId int, @UserId int
AS
begin
delete from tblOrders where BookId=@BookId and  UserId=@UserId;
delete from  tblBooks where BookId=@BookId and UserId=@UserId;
end

----------------------------------------------------------------------------------

Web.config
 <connectionStrings>
    <add name="Connect" connectionString="Data Source=DESKTOP-R5C27DF;Initial Catalog=BookDemo;Integrated Security=SSPI;" providerName="System.Data.SqlClient" /> 
  </connectionStrings>