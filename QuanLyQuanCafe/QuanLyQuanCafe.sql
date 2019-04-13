CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe

--Food
--TableFood
--FoodCategory
--Account 
--Bill
--BillInfo
CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống', -- trống|| có người
)
GO 

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Chưa xác định',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0 -- 1: admin   0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0, -- chưa thanh toán và đã thanh toán

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

------------------------------------------------------------------------------------
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'admin' , -- UserName - nvarchar(100)
          N'Nguyễn Đăng Tỉnh' , -- DisplayName - nvarchar(100)
          N'admin' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'staff' , -- UserName - nvarchar(100)
          N'staff' , -- DisplayName - nvarchar(100)
          N'staff' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
--SELECT * FROM dbo.Account

------------------------------------------------------------------------------------
CREATE PROC USP_GetAccountByUserName --4
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END


--EXEC USP_GetAccountByUserName @userName = N'admin'



SELECT * FROM dbo.Account WHERE UserName = N'admin' AND PassWord = N'admin'

SELECT COUNT(*) FROM dbo.Account WHERE UserName = N'admin' AND PassWord = N'' OR 1=1--


-- tạo store procedure tránh hack mật khẩu (' OR 1=1--)

CREATE PROC USP_Login -- 7
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO
------------------------------------------------------------------------------------

-- INSERT

-- thêm bàn
DECLARE @i INT = 1;  -- 8
WHILE @i <= 20
BEGIN	
	INSERT dbo.TableFood( name) VALUES ( N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END

--DELETE FROM dbo.TableFood
--INSERT dbo.TableFood( name, status ) VALUES  ( N'Bàn 1')
--INSERT dbo.TableFood( name, status ) VALUES  ( N'Bàn 1')
--INSERT dbo.TableFood( name, status ) VALUES  ( N'Bàn 1')
--SELECT * FROM dbo.TableFood


CREATE PROC USP_GetTableList -- 8
AS 
	SELECT * FROM dbo.TableFood
GO

UPDATE dbo.TableFood SET status = N'Có người' WHERE id = 5;
--EXEC dbo.USP_GetTableList

------------------------------------------------------------------------------------
SELECT * FROM dbo.TableFood
SELECT * FROM dbo.Bill       -- 9
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Food
SELECT * FROM dbo.FoodCategory

-- thêm category
INSERT dbo.FoodCategory( name ) VALUES  ( N'Hải sản')
INSERT dbo.FoodCategory( name ) VALUES  ( N'Nông sản')
INSERT dbo.FoodCategory( name ) VALUES  ( N'Lâm sản')
INSERT dbo.FoodCategory( name ) VALUES  ( N'Nước')
INSERT dbo.FoodCategory( name ) VALUES  ( N'Bia')
INSERT dbo.FoodCategory( name ) VALUES  ( N'Rượu')

-- thêm món ăn
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Mực một nắng nước sa tế',1, 120000 )
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Nghêu hấp xả',1, 50000)
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Dú dê nướng sữa',2, 100000)
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Heo rừng nướng muối ớt',3, 80000 )
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Nước giải khác',4, 12000)
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Cafe',4, 15000)
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Bia tươi',5, 20000)
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Bia hơi',5, 30000)
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Rượu vodka',6, 50000)
INSERT dbo.Food( name, idCategory, price) VALUES  ( N'Lẩu hải sản',1,20000 )

INSERT dbo.Bill( DateCheckIn ,DateCheckOut ,idTable ,status)
VALUES  ( GETDATE() , NULL ,1 , 0)
INSERT dbo.Bill( DateCheckIn ,DateCheckOut ,idTable ,status)
VALUES  ( GETDATE() , NULL ,2 , 0)
INSERT dbo.Bill( DateCheckIn ,DateCheckOut ,idTable ,status)
VALUES  ( GETDATE() , GETDATE() ,3, 1)
INSERT dbo.Bill( DateCheckIn ,DateCheckOut ,idTable ,status)
VALUES  ( GETDATE() , GETDATE() ,4 , 1)


-- thêm bill info
INSERT dbo.BillInfo ( idBill, idFood, count )
VALUES  ( 1, 1, 3 )
INSERT dbo.BillInfo ( idBill, idFood, count )
VALUES  ( 2, 5, 4 )
INSERT dbo.BillInfo ( idBill, idFood, count )
VALUES  ( 3, 4, 2 )
INSERT dbo.BillInfo ( idBill, idFood, count )
VALUES  ( 4, 2, 2 )
INSERT dbo.BillInfo ( idBill, idFood, count )
VALUES  ( 2, 3, 1 )

--SELECT * FROM dbo.BillInfo

--SELECT * FROM dbo.Bill WHERE idTable = 1 AND status = 0
--SELECT * FROM dbo.BillInfo WHERE idBill = 2
SELECT f.name, bi.count,f.price,f.price*bi.count AS TotalPrice  
FROM dbo.BillInfo AS bi, dbo.Bill AS b ,dbo.Food AS f 
WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable = 2

------------------------------------------------------------------------------
ALTER PROC USP_InsertBill     -- 11
@idTable INT
AS
BEGIN
	INSERT dbo.Bill
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
			  discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
			  0
	        )
END


CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @idExitBillInfo INT
	DECLARE @foodCount INT = 1
	SELECT @idExitBillInfo = id,@foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood
	
	IF(@idExitBillInfo > 0) -- thức ăn có tồn tại
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF(@newCount > 0)
			UPDATE dbo.BillInfo SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END

	ELSE	
	BEGIN
		INSERT dbo.BillInfo
	        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
	          @idFood, -- idFood - int
	          @count  -- count - int
	          )
	END
END
GO
--SELECT MAX(id) FROM dbo.Bill
-------------------------------------------------------------------------------------
UPDATE dbo.Bill SET status = 1 WHERE id = 1  -- 12

-- trigger
GO
ALTER TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = idBill FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill
	IF(@count > 0)
	BEGIN
		PRINT @idTable
		PRINT @idBill
		PRINT @count

		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
	END
	
	ELSE

	BEGIN
		PRINT @idTable
		PRINT @idBill
		PRINT @count

		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable	
	END
		
END
GO


--DROP TRIGGER UTG_UpdateTable -- 13
--ON dbo.TableFood FOR UPDATE
--AS
--BEGIN
--	DECLARE @idTable INT
--	DECLARE @status NVARCHAR(100)
--	SELECT @idTable = id FROM Inserted

--	DECLARE @idBill INT
--	SELECT @idBill = id FROM dbo.Bill WHERE idTable = @idTable AND status = 0

--	DECLARE @countBillInfo INT
--	SELECT @countBillInfo = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill
	
--	IF (@countBillInfo > 0 )-- AND @status <> N'Có người')
--		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
--	ELSE -- IF(@countBillInfo <= 0 AND @status <> N'Trống')
--		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
--END


CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = id FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0

	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0

	IF (@count = 0)  -- không có bill nào hết
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

DELETE dbo.BillInfo
DELETE dbo.Bill
----------------------------------------------------------
ALTER TABLE dbo.Bill   --13
ADD discount INT

UPDATE dbo.Bill SET discount = 0
SELECT * FROM dbo.Bill

DECLARE @idBillNew INT = 15

SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idBillNew -- tạo bảng mới với idBill được truyền vào

DECLARE @idBillOld INT = 14
UPDATE dbo.BillInfo SET idBill = @idBillOld WHERE id IN (SELECT * FROM IDBillInfoTable)

ALTER PROC USP_SwitchTable -- chuyển bàn
@idTable1 INT , @idTable2 INT
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE  @idSecondBill INT

	DECLARE @isFirstTableEmty INT = 1
	DECLARE @isSecondTableEmty INT = 1 

	SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '-------------'

	IF (@idFirstBill IS NULL)  -- nếu null thì tạo ra thằng mới
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status ,
		          discount
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0 , -- status - int
		          0  -- discount - int
		        )
		SELECT @idFirstBill =  MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

	END

	SELECT @isFirstTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill

	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '-------------'

	IF (@idSecondBill IS NULL)  -- nếu null thì tạo ra thằng mới
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status ,
		          discount
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0 , -- status - int
		          0  -- discount - int
		        )
		SELECT @idSecondBill =  MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
		
	END

	SELECT @isSecondTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSecondBill
	
	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '-------------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill

	UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill -- chuyển tất cả billInfo của thằng đầu tiên qua thằng thứ 2

	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable) -- chuyển tất cả billInfo của thằng thứ 2  
																								-- qua thằng đầu tiền với điều kiện mặc định từ đầu
	DROP TABLE IDBillInfoTable

	IF (@isFirstTableEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2

	IF (@isSecondTableEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO

EXEC USP_SwitchTable @idTable1 = 3 , @idTable2 = 5

UPDATE dbo.TableFood SET status = N'Trống'
-----------------------------------------------------------------
SELECT * FROM dbo.Bill -- 14
DELETE dbo.BillInfo
DELETE dbo.Bill

CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT  t.name AS [Tên bàn] ,(b.totalPrice * 1000) AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END

CREATE PROC USP_Food
AS
BEGIN
	SELECT f.id AS N'Mã thức ăn', f.name AS N'Tên thức ăn', fc.name AS N'Danh mục' , f.price AS N'Giá'
	FROM dbo.Food AS f INNER JOIN dbo.FoodCategory AS fc
	ON f.idCategory = fc.id
END

ALTER TABLE dbo.Bill ADD totalPrice FLOAT -- thêm cột totalPrice vào bảng Bill
---------------------------------------------------------------------  
SELECT * FROM dbo.Account   -- 15

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100),
@passWord NVARCHAR(100), @newPassWord NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord

	IF (@isRightPass = 1) -- nhập đúng mật khẩu
	BEGIN
		IF (@newPassWord = NULL OR @newPassWord = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END
			
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassWord WHERE UserName = @userName
	END
END
-----------------------------------------------
SELECT id, name AS N'Tên thức ăn', idCategory AS N'Danh mục', price AS N'Giá'  FROM dbo.Food
SELECT * FROM dbo.Food
SELECT f.name AS [Tên thức ăn],f.price AS [Giá], fc.name AS [Tên loại thức ăn]  -- 16
FROM dbo.Food AS f , dbo.FoodCategory AS fc
WHERE f.id = fc.id
---------------------------------------------------     18
INSERT dbo.Food( name, idCategory, price ) VALUES ( N'', 0, 0.0)

UPDATE dbo.Food SET name = N'',idCategory = 5,price = 0 WHERE id =5
SELECT * FROM  dbo.Food

CREATE TRIGGER UTP_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0;
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi , dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0

	IF(@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
---------------------------------------------------------  tự làm
DELETE FROM BillInfo FROM BillInfo  -- delete idCategory theo idCategory bên Food và idFood theo idFood bên Billinfo
INNER JOIN Food ON BillInfo.idFood = Food.id 
INNER JOIN FoodCategory ON Food.idCategory = FoodCategory.id 
WHERE FoodCategory.id = 7

SELECT * FROM dbo.TableFood
EXEC USP_GetTableList

INSERT dbo.TableFood( name, status )VALUES  ( N'',N'')

UPDATE dbo.TableFood SET name = N'', status = N'' WHERE id =  3

SELECT UserName,DisplayName,Type FROM dbo.Account

SELECT * FROM dbo.Food
---------------------------------------------------------------------------------   19 
CREATE FUNCTION [dbo].[fChuyenCoDauThanhKhongDau](@inputVar NVARCHAR(MAX) ) -- chuyển chuỗi thành không dấu
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END


SELECT * FROM dbo.Food WHERE dbo.fChuyenCoDauThanhKhongDau(name) LIKE N'%' + dbo.fChuyenCoDauThanhKhongDau(N'muc') + '%' 

SELECT * FROM dbo.Account
--------------------------------------------------------- 24
SELECT TOP 4 * FROM dbo.Bill
EXCEPT
SELECT TOP 2 * FROM dbo.Bill


ALTER PROC USP_GetListBillByDateAndPage
@checkIn date, @checkOut date, @page int
AS
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows * @page
	DECLARE @exceptRows INT = (@page - 1) * @pageRows

	;WITH BillShow AS ( SELECT t.name AS [Tên bàn] ,(b.totalPrice * 1000) AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable)

	SELECT TOP (@selectRows) * FROM BillShow
	EXCEPT
	SELECT TOP (@exceptRows) * FROM BillShow

END

EXEC dbo.USP_GetListBillByDateAndPage @checkIn = '2017-09-20', @checkOut = '2017-10-20' , @page = 1

EXEC dbo.USP_GetListBillByDate @checkIn = '2017-09-20', @checkOut = '2017-10-20' , @page = 1


CREATE PROC USP_GetNumBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT  COUNT(*) 
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END