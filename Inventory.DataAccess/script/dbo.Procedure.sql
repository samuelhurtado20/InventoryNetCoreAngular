USE [InventoryAngular]
GO

/****** Object: SqlProcedure [dbo].[SupplierPagedList] Script Date: 6/26/2022 5:57:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[SupplierPagedList]  
@page int,  
@rows int 
AS 
BEGIN  

 
 SELECT [Id]  ,[CompanyName] ,[ContactName] ,[ContactTitle], City, Country, Phone, Fax,
 COUNT(*) OVER() TotalRecords
 FROM [Supplier]
 order by [Id]
 OFFSET @page - 1 ROWS                  
 FETCH NEXT @rows ROWS ONLY
 
END
