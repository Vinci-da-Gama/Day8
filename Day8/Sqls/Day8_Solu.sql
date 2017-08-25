-- Create a new stored procedure called 'DeleteExtraRowsInProducts' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'DeleteExtraRowsInProducts'
)
DROP PROCEDURE DeleteExtraRowsInProducts
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE DeleteExtraRowsInProducts
AS
Begin
    -- Delete rows from table 'Products'
    DELETE FROM Products
    WHERE ProductId > 120 /* add search conditions here */
End
GO

-- Create a new stored procedure called 'ThreeInnerJoin' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ThreeInnerJoin'
)
DROP PROCEDURE ThreeInnerJoin
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE ThreeInnerJoin
AS
Begin
    -- Select rows from a Table or View 'Orders' in schema 'dbo'
    SELECT c.CustomerId, o.OrderId, p.ProductId FROM Orders o Inner Join Products p On o.OrderId = p.OrderId Inner Join Customers c On o.CustomerId = c.CustomerId
    WHERE c.CustomerId Between 100 And 110 /* add search conditions here */
End
GO

-- Create a new stored procedure called 'InsertNewProduct' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'InsertNewProduct'
)
DROP PROCEDURE InsertNewProduct
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE InsertNewProduct
	@MaxOid Int = 0,
    @StartOid Int = 0,
    @RandomOid INT = 0,
    @PdName NVARCHAR(50)
AS
Begin
    WITH Orders_Cte as (
        Select ROW_NUMBER() Over(Order By OrderId) As Row_No From Orders
    )
	Select @MaxOid = MAX(Row_No) From Orders_Cte;
    SET @StartOid = 1;
    SET @RandomOid = ROUND(((@MaxOid - @StartOid -1) * RAND() + @StartOid), 0)
    -- SET @PdName = 'PdName'+CAST(@RandomOid As Nvarchar);
    Print @MaxOid;
    Print @StartOid;
    Print @RandomOid;
	-- Insert rows into table 'Products'
    INSERT INTO Products
    (
        -- columns to insert data into
        [ProductName], [Produce_Date], [ProductOrderNum], [OrderId]
    )
    VALUES
    (
        -- first row: values for the columns in the list above
        @PdName, GetDate(), Abs(CheckSum(NewId())) % 9999, @RandomOid
    )
    Select * From Products Where ProductId > 136
End
GO

-- Create a new stored procedure called 'TestInnerVariable' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'TestInnerVariable'
)
DROP PROCEDURE TestInnerVariable
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE TestInnerVariable
    @No1 Int = 1
AS
Begin
    Print @No1;
End
GO