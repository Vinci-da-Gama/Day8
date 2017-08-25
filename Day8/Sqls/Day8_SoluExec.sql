-- Delete Useless Rows In Products Table
Exec DeleteExtraRowsInProducts

-- Three Inner Join
Exec ThreeInnerJoin

-- Insert New Product
-- Declare @MaxOid Int;
-- Declare @RandomOid Int;
-- Declare @StartOid Int;
Declare @PdName Nvarchar(50);
Exec InsertNewProduct @PdName

Select * From Products Where ProductId > 120

-- Test Inner Variable
Exec TestInnerVariable