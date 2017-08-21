-- Drop CreditLimit
Exec DropCreditLimi

-- Add new CreditLimit Column
EXECUTE AddNewCreditLimit

-- Update Random Values for CreditLimit
Exec UpdateRandomValForCreditLimit
Select * From Customers

-- Remove OrderPrice and Add new one
Exec RemoveOrderPriceAndAddNew

-- Generate Random smallmoney For OrderPrice
Exec GenerateRandomSmallMoney
Select * From Orders

-- Find People Who Comes From Texas
Exec FindPeopleFromTexas @state = 'Texas'

-- Return Last Row Num
Declare @Rn AS Int;
Exec ReturnLastRowForCustomerTable @Rn Output
-- Print @Rn

-- Insert on row to Orders Table
Declare @OdMLine Int;
Exec InsertOneRowToOrders @OdMLine = @Rn

-- Insert New Row By Output Variable
Declare @LastRowNum Int
Exec InsertRowByOutputVariable @LastRowNum Output

-- Return Value After Insert New Row.
Declare @Rn Int;
Exec @Rn = PrintReturnValAfterInsertRow
Print @Rn

-- Select all Customers
Exec SelectAllCustomers

-- Select All Orders
Exec SelectAllOrders