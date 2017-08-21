-- Create a new stored procedure called 'DropCreditLimi' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'Customers'
)
DROP PROCEDURE DropCreditLimi
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE DropCreditLimi
AS
Begin
	-- Drop 'CreditLimit' from table 'Customers' in schema 'dbo'
    ALTER TABLE dbo.Customers
        DROP COLUMN CreditLimit
End
GO

-- Create a new stored procedure called 'AddNewCreditLimit' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'AddNewCreditLimit'
)
DROP PROCEDURE AddNewCreditLimit
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE AddNewCreditLimit
AS
Begin
    -- Add a new column 'CreditLimit' to table 'Customers' in schema 'dbo'
    ALTER TABLE dbo.Customers
        ADD CreditLimit /*new_column_name*/ int /*new_column_datatype*/ Not NULL /*new_column_nullability*/ Default ROUND(((999 - 1 -1) * RAND() + 1), 0) /* This will create a random number between 1 and 999 */
	Select * From Customers
End
GO

-- Create a new stored procedure called 'UpdateRandomValForCreditLimit' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'UpdateRandomValForCreditLimit'
)
DROP PROCEDURE UpdateRandomValForCreditLimit
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE UpdateRandomValForCreditLimit
AS
Declare @cnt Int;
Declare @MaxLine Int;
DECLARE @UpperNum INT;
DECLARE @LowerNum INT;

SET @cnt = 0;
SET @MaxLine = 120;
SET @UpperNum = 999;
SET @LowerNum = 1;
Print @cnt;

While (@cnt < @MaxLine)
Begin
    -- Update rows in table 'Customers'
    UPDATE Customers
    SET
        [CreditLimit] = ROUND(((@UpperNum - @LowerNum -1) * RAND() + @LowerNum), 0)
    WHERE CustomerId = @cnt + 1
    SET @cnt = @cnt + 1;
End
GO

-- Create a new stored procedure called 'RemoveOrderPriceAndAddNew' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'RemoveOrderPriceAndAddNew'
)
DROP PROCEDURE RemoveOrderPriceAndAddNew
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE RemoveOrderPriceAndAddNew
AS
Begin
    -- Drop 'OrderPrice' from table 'Orders' in schema 'dbo'
    ALTER TABLE dbo.Orders
        DROP COLUMN OrderPrice
    -- Add a new column 'OrderPrice' to table 'Orders' in schema 'dbo'
    ALTER TABLE dbo.Orders
        ADD OrderPrice /*new_column_name*/ smallmoney /*new_column_datatype*/ Not NULL /*new_column_nullability*/ Default 1.00
End
GO

-- Create a new stored procedure called 'GenerateRandomSmallMoney' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GenerateRandomSmallMoney'
)
DROP PROCEDURE GenerateRandomSmallMoney
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE GenerateRandomSmallMoney
AS
Declare @opCnt Int = 1;
Declare @OdsMaxLine Int = 120;
While (@opCnt <= @OdsMaxLine)
Begin
	-- Update rows in table 'Customers'
    UPDATE Orders
    SET
        [OrderPrice] = ABS(CHECKSUM(NEWID())) % 99
        -- add more columns and values here
    WHERE OrderId = @opCnt /* add search conditions here */
    Print @opCnt;
    SET @opCnt += 1;
End
GO

-- Create a new stored procedure called 'FindPeopleFromTexas' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'FindPeopleFromTexas'
)
DROP PROCEDURE FindPeopleFromTexas
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE FindPeopleFromTexas
    @state /*parameter name*/ varchar(30) /*datatype_for_param1*/ = 'Texas'
AS
Begin
    -- body of the stored procedure
    SELECT * From Customers
    Where [State] = @state
End
GO




-- Create a new stored procedure called 'ReturnLastRowForCustomerTable' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ReturnLastRowForCustomerTable'
)
DROP PROCEDURE ReturnLastRowForCustomerTable
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE ReturnLastRowForCustomerTable
	@ML INT Output
AS
Begin
	With Cust_Cte as (
		Select ROW_NUMBER() Over(Order By CustomerId) as Row_No From Customers
	)
	Select @ML = MAX(Row_No) From Cust_Cte
End
GO

-- Create a new stored procedure called 'InsertOneRowToOrders' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'InsertOneRowToOrders'
)
DROP PROCEDURE InsertOneRowToOrders
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE InsertOneRowToOrders
    @OdMLine Int
AS
Begin
	Set @OdMLine += 3;
    
    -- Insert rows into table 'Customers'
    INSERT INTO Customers
    (
        -- columns to insert data into
        [First_Name], [Last_Name], [Email], Gender, Zip, [State], [Join_Date], CreditLimit
    )
    VALUES
    (
        -- first row: values for the columns in the list above
        'FN0', 'LN0', 'fln@sth.com', 'Female', ABS(CHECKSUM(NEWID())) % 999, 'Texas', GETDATE(), ABS(CHECKSUM(NewId())) % 999)
	/*Display Last line Number*/
    Print @OdMLine;
	-- Insert rows into table 'Orders'
    INSERT INTO Orders
    (
        -- columns to insert data into
        [OrderProduct], [OrderPrice], [OrderDate], CustomerId
    )
    VALUES
    (
        -- first row: values for the columns in the list above
        'Product0', 33.33, GETDATE(), @OdMLine
    )
End
GO


-- Create a new stored procedure called 'InsertRowByOutputVariable' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'InsertRowByOutputVariable'
)
DROP PROCEDURE InsertRowByOutputVariable
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE InsertRowByOutputVariable
    @LastRowNum INT Output
AS
Begin
    -- Insert rows into table 'Customers'
    INSERT INTO Customers
    (
        -- columns to insert data into
        [First_Name], [Last_Name], [Email], Gender, Zip, [State], [Join_Date], CreditLimit
    )
    VALUES
    (
        -- first row: values for the columns in the list above
        'FN1', 'LN1', 'fln1@sth.com', 'Female', ABS(CHECKSUM(NEWID())) % 999, 'Texas', GETDATE(), ABS(CHECKSUM(NewId())) % 999
	)
    SELECT @LastRowNum = MAX(CustomerId) From Customers
    -- Insert rows into table 'Orders'
    INSERT INTO Orders
    (
        -- columns to insert data into
        [OrderProduct], [OrderPrice], [OrderDate], CustomerId
    )
    VALUES
    (
        -- first row: values for the columns in the list above
        'Product1', 66.66, GETDATE(), @LastRowNum
    )
End
GO



-- Create a new stored procedure called 'PrintReturnValAfterInsertRow' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'PrintReturnValAfterInsertRow'
)
DROP PROCEDURE PrintReturnValAfterInsertRow
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE PrintReturnValAfterInsertRow
AS
Begin
    -- Insert rows into table 'Customers'
    INSERT INTO Customers
    (
        -- columns to insert data into
        [First_Name], [Last_Name], [Email], Gender, Zip, [State], [Join_Date], CreditLimit
    )
    VALUES
    (
        -- first row: values for the columns in the list above
        'FN2', 'LN2', 'fln2@sth.com', 'Female', ABS(CHECKSUM(NEWID())) % 999, 'New York', GETDATE(), ABS(CHECKSUM(NewId())) % 999
	)
    Return @@Identity
End
GO