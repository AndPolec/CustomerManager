CREATE PROCEDURE [dbo].[spContactPerson_GetAll]
	@CustomerOwnerId int
AS
BEGIN
	select cp.* 
	from dbo.ContactPerson cp
	join dbo.Customer c on c.Id = cp.CustomerId 
	where c.CustomerOwnerId = @CustomerOwnerId;
END
