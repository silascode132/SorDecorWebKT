/* TRIGGER */

USE SorDecor
GO

--Trigger tự sinh ID khi register admin
CREATE TRIGGER trg_registerAdmin ON dbo.Admins
AFTER INSERT
AS
BEGIN
	DECLARE @ID VARCHAR(128)
	IF(SELECT COUNT(ID) FROM dbo.Admins) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 5)) FROM dbo.Admins
		SELECT @ID = CASE
			WHEN @ID >= 0 AND @ID < 9 THEN 'AD0000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00004
			WHEN @ID >= 9 AND @ID < 99 THEN 'AD000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00032
			WHEN @ID >=99 AND @ID < 999 THEN 'AD00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00742
			WHEN @ID >=999 AND @ID <9999 THEN 'AD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP01525
			WHEN @ID >=9999 THEN 'AD' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END

	SET @ID = MAX(LEFT(@ID, 7))
	UPDATE dbo.Admins
	SET ID = @ID
	WHERE ID = '0'
END


-- Trigger tự sinh ID khi register user account
CREATE TRIGGER trg_Register ON dbo.UserAccounts
AFTER INSERT
AS
BEGIN
	DECLARE @ID VARCHAR(128)
	IF(SELECT COUNT(ID) FROM dbo.UserAccounts) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 5)) FROM dbo.UserAccounts
		SELECT @ID = CASE
			WHEN @ID >= 0 AND @ID < 9 THEN 'US0000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00004
			WHEN @ID >= 9 AND @ID < 99 THEN 'US000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00032
			WHEN @ID >=99 AND @ID < 999 THEN 'US00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00742
			WHEN @ID >=999 AND @ID <9999 THEN 'US0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP01525
			WHEN @ID >=9999 THEN 'US' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END

	DECLARE @IDCart VARCHAR(128)
	IF(SELECT COUNT(ID) FROM dbo.Carts) = 0
		SET @IDCart = '0'
	ELSE
		SELECT @IDCart = MAX(RIGHT(ID, 5)) FROM dbo.Carts
		SELECT @IDCart = CASE
			WHEN @IDCart >= 0 AND @IDCart < 9 THEN 'CI0000' + CONVERT(CHAR, CONVERT(INT, @IDCart) + 1)
			WHEN @IDCart >= 9 AND @IDCart < 99 THEN 'CI000' + CONVERT(CHAR, CONVERT(INT, @IDCart) + 1)
			WHEN @IDCart >= 99 AND @IDCart <999 THEN 'CI00' + CONVERT(CHAR, CONVERT(INT, @IDCart) + 1)
			WHEN @IDCart >= 999 AND @IDCart <9999 THEN 'CI0' + CONVERT(CHAR, CONVERT(INT, @IDCart) + 1)
			WHEN @IDCart >= 9999 THEN 'CI' + CONVERT(CHAR, CONVERT(INT, @IDCart) + 1)
		END

	SET @ID = MAX(LEFT(@ID, 7))
	UPDATE dbo.UserAccounts
	SET ID = @ID
	WHERE ID = '0'

	SET @IDCart = MAX(LEFT(@IDCart, 7))
	INSERT INTO dbo.Carts VALUES (@IDCart, @ID)
END



-- Trigger tự sinh ID cho dbo.ItemInCart
CREATE TRIGGER trg_ItemInCart ON dbo.ItemInCarts
AFTER INSERT
AS
BEGIN
	DECLARE @ID VARCHAR(128)
	DECLARE @ProductID VARCHAR(128)
	DECLARE @CartID VARCHAR(128)
	DECLARE @SLA INT
	DECLARE @SLB INT
	DECLARE @IDPr VARCHAR(128)
	-- Khởi tạo
	SET @ProductID = (SELECT ProductID FROM dbo.ItemInCarts WHERE ID = '0') -- gán @ProductID = ID của product mới đc thêm vào
	SET @CartID = (SELECT CartItemID FROM dbo.ItemInCarts WHERE ID = '0')	-- gán @CartID = ID của cart mới được thêm vào
	IF((SELECT COUNT(*) FROM dbo.ItemInCarts WHERE CartItemID=@CartID AND ProductID=@ProductID) > 1)	--Kiếm tra SP đó đã có trong giỏ chưa
		begin
		SELECT @SLA =  SL FROM dbo.ItemInCarts WHERE ProductID = @ProductID AND CartItemID = @CartID	 -- Gán @SLA = số lượng ban đầu của SP đó
		SELECT @SLB =  SL FROM dbo.ItemInCarts WHERE ID = '0' -- Gán @SLB = Số lượng thêm mới
		SELECT @IDPr = ID FROM dbo.ItemInCarts WHERE (ProductID = @ProductID AND CartItemID = @CartID) AND ID != '0' -- Gán @IDPr = ID của sản phẩm đã có sẵn trong giỏ
		
		UPDATE dbo.ItemInCarts	-- Tiến hành update lại SL của SP đó trong giỏ
		SET SL = @SLA + @SLB
		WHERE ID = @IDPr

		UPDATE dbo.ItemInCarts	-- Update lại giá của SP đó trong giỏ
		SET Total = SL * Price
		WHERE ID = @IDPr

		DELETE FROM dbo.ItemInCarts	-- Xóa SP mới thêm vào
		WHERE ID = '0'
		end
	ELSE	-- Nếu chưa có trong giỏ tiến hành tạo mới
		begin
			SELECT @ID = MAX(RIGHT(ID, 5)) FROM dbo.ItemInCarts	-- Lấy ra số
			SELECT @ID = CASE
				WHEN @ID >= 0 AND @ID < 9 THEN 'IC0000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00004
				WHEN @ID >= 9 AND @ID < 99 THEN 'IC000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00032
				WHEN @ID >=99 AND @ID < 999 THEN 'IC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00742
				WHEN @ID >=999 AND @ID <9999 THEN 'IC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP01525
				WHEN @ID >=9999 THEN 'IC' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			end
			SET @ID = MAX(LEFT(@ID, 7)) -- Bỏ khoảng trống đăng sau @ID
			
		UPDATE dbo.ItemInCarts
		SET ID = @ID, Total = SL*Price
		WHERE ID = '0'


		end
END


-- TRIGGER sinh ID cho dbo.OrderBills	mã hóa đơn bán
CREATE TRIGGER trg_AddOrderBills ON dbo.OrderBills
AFTER INSERT
AS
BEGIN
	
	DECLARE @ID VARCHAR(128)
	IF (SELECT COUNT(ID) FROM dbo.OrderBills) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 5)) FROM dbo.OrderBills
		SELECT @ID = CASE
			WHEN @ID = 99999 THEN CONVERT(VARCHAR,GETDATE(),112) + 'HD00001'
			WHEN @ID >= 0 and @ID < 9 THEN CONVERT(VARCHAR,GETDATE(),112) + 'HD0000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN CONVERT(VARCHAR,GETDATE(),112) + 'HD000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 99 THEN CONVERT(VARCHAR,GETDATE(),112) + 'HD00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 999 THEN CONVERT(VARCHAR,GETDATE(),112) + 'HD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9999 THEN CONVERT(VARCHAR,GETDATE(),112) + 'HD' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END

	

	SET @ID = MAX(LEFT(@ID, 15))
	UPDATE dbo.OrderBills
	SET ID = @ID
	WHERE ID = '0'

	
END


-- Trigger tự sinh ID khi thêm 1 SP
CREATE TRIGGER trg_AddProduct ON dbo.Products
AFTER INSERT
AS
BEGIN
	DECLARE @ID VARCHAR(128)
	IF(SELECT COUNT(ID) FROM dbo.Products) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 5)) FROM dbo.Products
		SELECT @ID = CASE
			WHEN @ID >= 0 AND @ID < 9 THEN 'SP0000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00004
			WHEN @ID >= 9 AND @ID < 99 THEN 'SP000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00032
			WHEN @ID >=99 AND @ID < 999 THEN 'SP00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP00742
			WHEN @ID >=999 AND @ID <9999 THEN 'SP0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)	-- Ex: SP01525
			WHEN @ID >=9999 THEN 'SP' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END

		SET @ID = MAX(LEFT(@ID, 7))
		UPDATE dbo.Products
		SET ID = @ID
		WHERE ID = '0'
END

================================================================================







SET DATEFORMAT dmy;
INSERT INTO dbo.ItemOrder VALUES ('0', 'US00001', 'lam', 'address', '0000', 'note', 1, 1, '2000/5/2', '2000/6/2')
GO
sp_AddItemOrder @ID = '0', @UserID = 'US00001', @UserName = 'lam', @UserAddress = 'address', @Phone = '0000', @Note = 'note', @Paid = 0, @DateOrder = '2000/6/2'
INSERT INTO dbo.OrderInfo(ItemOrder, ProductID, SL, Total) VALUES ('')
