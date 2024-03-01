CREATE PROCEDURE [dbo].[sp_Customer_GetAll]
AS
BEGIN
	select * 
	from dbo.Customer c
	join dbo.[Address] a on a.CustomerId = c.Id
	join dbo.ContactPerson cp on cp.CustomerId = c.Id;
END
