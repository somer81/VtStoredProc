RESTORE FILELISTONLY  
FROM DISK = 'C:\Users\pro1\Documents\Visual Studio 2013\Projects\northwind.bak'  
GO  

RESTORE DATABASE Northwind  
FROM DISK = 'C:\Users\pro1\Documents\Visual Studio 2013\Projects\northwind.bak'  
WITH MOVE 'Northwind' TO 'C:\Users\pro1\Documents\Visual Studio 2013\Projects\northwind.mdf',  
MOVE 'Northwind_log' TO 'C:\Users\pro1\Documents\Visual Studio 2013\Projects\northwind.ldf' 