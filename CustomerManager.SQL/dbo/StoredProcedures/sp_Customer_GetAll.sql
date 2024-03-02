CREATE PROCEDURE [dbo].[spCustomer_GetAll]
@CustomerOwnerId int
AS
BEGIN
	select c.*, a.* 
	from dbo.Customer c
	left join dbo.[Address] a on a.CustomerId = c.Id
	where c.ClientOwnerId = @ClientOwnerId
	order by c.Name asc;
END
