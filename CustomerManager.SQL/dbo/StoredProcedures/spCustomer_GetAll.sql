CREATE PROCEDURE [dbo].[spCustomer_GetAll]
@CustomerOwnerId int,
@SearchString nvarchar(200),
@PageSize int,
@PageNumber int
AS
BEGIN
	select c.*, a.* 
	from dbo.Customer c
	left join dbo.[Address] a on a.CustomerId = c.Id
	where c.CustomerOwnerId = @CustomerOwnerId 
		and (@SearchString is null or c.Name like '%' + @SearchString + '%')
	order by c.Name asc
	offset (@PageNumber-1)*@PageSize rows
	fetch next @PageSize rows only;
END
