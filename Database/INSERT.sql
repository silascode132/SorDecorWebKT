USE SorDecor
GO


/*	------- INSERT ------- 
	----------------------
	---------------------- */


/* ============ INSERT ============ 
   ==================================	 */

/* -- Categories --*/
INSERT INTO dbo.Categories VALUES (N'Trang trí', 1)
GO
INSERT INTO dbo.Categories VALUES (N'PostCard', 1)
GO
INSERT INTO dbo.Categories VALUES (N'Quần áo', 1)
GO
INSERT INTO dbo.Categories VALUES (N'Gia dụng', 1)
GO

/* -- Categories --*/
INSERT INTO dbo.Mades(MadeName) VALUES (N'Trung Quốc')

/* -- Sản phẩm -- */
sp_AutoID_Product 
@ProductName = N'Hoa Khô', 
@Made = 1, 
@Info = N'Những bông hoa chọn lọc được sấy khô qua những công đoạn khắt khe', 
@Descript = N'Khi bạn không có thời gian nhưng vẫn muốn “make color” cho căn phòng thêm sức sống, hoa khô sẽ là lựa chọn hợp lý cho bạn',
@Price = 200000,
@Size = NULL,
@Sale = 0,
@Category = 1,
@Freeship = 0,
@Image = NULL,
@ImageUrl = 'product-hoakho.jpg',
@SL = 20,
@DateUpdate = '8/1/2021',
@STT = 1
GO

select sum(SL)
from dbo.ItemInCarts


sp_AutoID_Product 
@Name = N'Khăn chải bàn', 
@Made = N'Vietnam', 
@Info = N'Kích thước: 100 x 150cm, hoa văn phong cách Vintage phù hợp cho trang trí nhà cửa', 
@Descript = N'Kích thước: 100 x 150cm, hoa văn phong cách Vintage phù hợp cho trang trí nhà cửa. 1 chiếc khăn trải bàn hoa vintage có thể thay đổi không gian của phòng bạn trở nên thật “ther”',
@Price = 200000,
@Size = NULL,
@Sale = 10,
@Category = 'Giadung',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-GVEKKdveCyI/YNwyKofppTI/AAAAAAAABoU/9qSmMVIR2KQpxeFbhu_YNBhrC7hqE6B-wCLcBGAsYHQ/s1080/Product-Khantraiban.jpg',
@SL = 14
GO

sp_AutoID_Product 
@Name = N'Lọ cắm hoa trong suốt', 
@Made = N'China', 
@Info = N'Info của "Lọ cắm hoa trong suốt", chất liệu thủy tinh trong suốt', 
@Descript = N'Descript của "Lọ cắm hoa trong suốt"Descript của "Lọ cắm hoa trong suốt"Descript của "Lọ cắm hoa trong suốt"Descript của "Lọ cắm hoa trong suốt"Descript của "Lọ cắm hoa trong suốt"Descript của "Lọ cắm hoa trong suốt" ',
@Price = 50000,
@Size = NULL,
@Sale = NULL,
@Category = 'Trangtri',
@Promotions = 'Freeship',
@Images = 'https://1.bp.blogspot.com/-UxmpxYUa2v4/YNw1fJDg7sI/AAAAAAAABoc/BQgPtUXjBRciZWD8UPAO3QaCswZWmH2xgCLcBGAsYHQ/s1080/Product-Lothuytinh.jpg',
@SL = 25
GO

sp_AutoID_Product 
@Name = N'Lục bình', 
@Made = N'China', 
@Info = N'Info của "Lục bình", chất liệu thân thiện môi trường |Info của "Lục bình", chất liệu thân thiện môi trường', 
@Descript = N'Descript của "Lục bình", chất liệu thân thiện môi trường "Lục bình", chất liệu thân thiện môi trường "Lục bình", chất liệu thân thiện môi trường "Lục bình", chất liệu thân thiện môi trường ',
@Price = 70000,
@Size = NULL,
@Sale = NULL,
@Category = 'Trangtri',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-qeRDOJJvAqY/YNw2GeHTcAI/AAAAAAAABok/pjalSe0Val8hP4bQ9Y6xUCozI4FZ9By2QCLcBGAsYHQ/s1080/Product-Giohoa.jpg',
@SL = 5
GO

sp_AutoID_Product 
@Name = N'Tượng giả thạch', 
@Made = N'China', 
@Info = N'Info của "Tượng giả thạch", cao 17cm |Info của "Tượng giả thạch", cao 17cm Info của "Tượng giả thạch", cao 17cm', 
@Descript = N'Descript của "Tượng giả thạch", cao 17cm | Descript của "Tượng giả thạch", cao 17cm |Descript của "Tượng giả thạch", cao 17cm |Descript của "Tượng giả thạch", cao 17cm |Descript của "Tượng giả thạch", cao 17cm |',
@Price = 150000,
@Size = NULL,
@Sale = 5,
@Category = 'Trangtri',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-2Zy2RKtB5Uo/YNxt4oNfXlI/AAAAAAAABos/CgCivElOqXIdDF6_KBTeFG4GFNK7WY-NgCLcBGAsYHQ/s1080/Product-Tuong.jpg',
@SL = 10
GO

sp_AutoID_Product 
@Name = N'Khăn trải bàn 100x150', 
@Made = N'Vietnam', 
@Info = N'Info của "Khăn trải bàn", Khăn đa năng - 100x150cm: có thể dùng làm khăn trải bàn, khăn trải cắm trại, khăn lót chụp hình sản phẩm...', 
@Descript = N'Descript của "Khăn trải bàn", Khăn đa năng - 100x150cm: có thể dùng làm khăn trải bàn, khăn trải cắm trại, khăn lót chụp hình sản phẩm | Khăn đa năng - 100x150cm: có thể dùng làm khăn trải bàn, khăn trải cắm trại, khăn lót chụp hình sản phẩm',
@Price = 200000,
@Size = NULL,
@Sale = NULL,
@Category = 'Giadung',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-PgLJqzE8g6Y/YNxu3e4Xt4I/AAAAAAAABo0/GEem2SSTEJsovNT9iGlL1q0AvJXJp8pPACLcBGAsYHQ/s1080/Product-Khantraiban-2.jpg',
@SL = 7
GO

sp_AutoID_Product 
@Name = N'Gương để bàn', 
@Made = N'China', 
@Info = N'Info của "Gương để bàn", Gương để bàn phong cách tối giản. Soi đẹp mà chưng cũng đẹp nè các bạn...', 
@Descript = N'Descript của "Gương để bàn", Gương để bàn phong cách tối giản. Soi đẹp mà chưng cũng đẹp nè các bạn | Gương để bàn phong cách tối giản. Soi đẹp mà chưng cũng đẹp nè các bạn | Gương để bàn phong cách tối giản. Soi đẹp mà chưng cũng đẹp nè các bạn',
@Price = 170000,
@Size = NULL,
@Sale = 20,
@Category = 'Trangtri',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-M-F1cY8Cumw/YNxvqxPMhgI/AAAAAAAABo8/chFf2gpzqMEk2EtQ0JBYBLYu94wtfdQ3gCLcBGAsYHQ/s1080/Product-Guong.jpg',
@SL = 18
GO

sp_AutoID_Product 
@Name = N'Đồng hồ LED 3D', 
@Made = N'China', 
@Info = N'Info của "Đồng hồ LED 3D", Đồng hồ led 3D - không chỉ là item không thể thiếu trong mọi bức ảnh chụp phòng siêu ảo, mà còn có rất nhiều công dụng thiết thực', 
@Descript = N'Descript của "Đồng hồ LED 3D", Đồng hồ led 3D - không chỉ là item không thể thiếu trong mọi bức ảnh chụp phòng siêu ảo, mà còn có rất nhiều công dụng thiết thực | Đồng hồ led 3D - không chỉ là item không thể thiếu trong mọi bức ảnh chụp phòng siêu ảo, mà còn có rất nhiều công dụng thiết thực',
@Price = 150000,
@Size = NULL,
@Sale = NULL,
@Category = 'Trangtri',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-1uWg0BK8H0o/YNxwlhhZ4dI/AAAAAAAABpE/S4iD3KNLk6Exo6xjYEnLGonkpwZsj82RACLcBGAsYHQ/s1080/Product-Dongho.jpg',
@SL = 5
GO

sp_AutoID_Product 
@Name = N'Máy phun sương', 
@Made = N'Japan', 
@Info = N'Info của "Máy phun sương", Phun sương cân bằng ẩm, Xông hương tinh dầu, Đèn ngủ ánh sáng vàng 2 chế độ (mạnh - yếu), Có chế độ hẹn giờ tắt', 
@Descript = N'Descript của "Máy phun sương", Phun sương cân bằng ẩm, Xông hương tinh dầu, Đèn ngủ ánh sáng vàng 2 chế độ (mạnh - yếu), Có chế độ hẹn giờ tắt | Phun sương cân bằng ẩm, Xông hương tinh dầu, Đèn ngủ ánh sáng vàng 2 chế độ (mạnh - yếu), Có chế độ hẹn giờ tắt',
@Price = 470000,
@Size = NULL,
@Sale = 10,
@Category = 'Giadung',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-WAU9btgDKrc/YNxx-VJtfXI/AAAAAAAABpM/8WGAcevc7DAPFK7QxQbPPrVW0z71qH-_wCLcBGAsYHQ/s1080/Product-Mayphunsuong.jpg',
@SL = 9
GO

sp_AutoID_Product 
@Name = N'Gương không viền', 
@Made = N'China', 
@Info = N'Info của "Gương không viền", gương không viền, mặt gương to, kiểu dáng đơn giản, dễ lau chùi. Tặng kèm bút vẽ', 
@Descript = N'Descript của "Gương không viền", gương không viền, mặt gương to, kiểu dáng đơn giản, dễ lau chùi. Tặng kèm bút vẽ "Gương không viền", gương không viền, mặt gương to, kiểu dáng đơn giản, dễ lau chùi. Tặng kèm bút vẽ "Gương không viền", gương không viền, mặt gương to, kiểu dáng đơn giản, dễ lau chùi. Tặng kèm bút vẽ',
@Price = 230000,
@Size = NULL,
@Sale = NULL,
@Category = 'Trangtri',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-vwZ5nGEhC9A/YOBifArrUxI/AAAAAAAABps/CaP1roNbFx8rqf3ON6LZvhfe4YGV3tuWgCLcBGAsYHQ/s1080/Product-Guongkhongvien.jpg',
@SL = 24
GO

sp_AutoID_Product 
@Name = N'Đèn ngủ để bàn', 
@Made = N'Korea', 
@Info = N'Info của "Đèn ngủ để bàn", biến hoá căn phòng của bạn vừa “cozy kiểu hàn quốc” vừa “vintage như phương tây”. Đèn sáng đủ để bạn sử dụng các thiết bị điện tử mà không làm hại và mỏi mắt như ánh sáng trắng.', 
@Descript = N'Descript của "Đèn ngủ để bàn", biến hoá căn phòng của bạn vừa “cozy kiểu hàn quốc” vừa “vintage như phương tây”. Đèn sáng đủ để bạn sử dụng các thiết bị điện tử mà không làm hại và mỏi mắt như ánh sáng trắng.biến hoá căn phòng của bạn vừa “cozy kiểu hàn quốc” vừa “vintage như phương tây”. Đèn sáng đủ để bạn sử dụng các thiết bị điện tử mà không làm hại và mỏi mắt như ánh sáng trắng.',
@Price = 360000,
@Size = NULL,
@Sale = NULL,
@Category = 'Trangtri',
@Promotions = NULL,
@Images = 'https://1.bp.blogspot.com/-RCEMfh3MUQs/YOBkmQ2FijI/AAAAAAAABp0/6EZfqpLX42wMrWN5odZBDgwTjtP0F-kcgCLcBGAsYHQ/s899/Product-Denngudeban.jpg',
@SL = 7
GO


SELECT COUNT(*)
FROM dbo.Product
WHERE Category = 'Trangtri'

