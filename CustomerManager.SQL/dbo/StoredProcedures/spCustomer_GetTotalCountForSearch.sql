CREATE PROCEDURE [dbo].[spCustomer_GetTotalCountForSearch]
    @CustomerOwnerId int,
    @SearchString nvarchar(200)
AS
BEGIN
    select COUNT(*) as TotalCount
    from dbo.Customer c
    left join dbo.[Address] a on a.CustomerId = c.Id
    where c.CustomerOwnerId = @CustomerOwnerId 
        and (@SearchString is null or c.Name like '%' + @SearchString + '%');
END
