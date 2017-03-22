create proc ListProduct
as
SELECT * FROM Products
go 
create proc AddProduct
@pn varchar(20),
@pp money,
@ps smallint,
@po smallint
as
INSERT INTO	Products(ProductName,UnitPrice,UnitsInStock,UnitsOnOrder) VALUES(@pn,@pp,@ps,@po)
go 
