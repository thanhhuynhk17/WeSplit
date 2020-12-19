create table province
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(255) not null,
	code int
)

create table member
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(255) not null,
	phone nvarchar(30) null
)

create table place
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(255),
	image nvarchar(100),
	description text,
	address nvarchar(255),
	province_id int
)

create table journey
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(255) not null,
	end_place int,
	status int,
	date_start date not null,
	date_end date,
	hire_vehicle_cost float default 0,
	hire_room_cost float default 0,
	plane_ticket_cost float default 0,
	total_cost float default 0 
)

create table route
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	place_start varchar(255) not null,
	description text,
	province_id int,
	costs float default 0,
	journey_id int
)

create table journey_member
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	journey_id int,
	member_id int,
	journey_member_money float default 0
)

alter table place ADD CONSTRAINT FK_PlaceProvince
FOREIGN KEY (province_id) REFERENCES Province(id);

alter table journey ADD CONSTRAINT FK_JourneyPlace
FOREIGN KEY (end_place) REFERENCES Place(id);

alter table route ADD CONSTRAINT FK_RouteJourney
FOREIGN KEY (journey_id) REFERENCES Journey(id);
alter table route ADD CONSTRAINT FK_RouteProvince
FOREIGN KEY (province_id) REFERENCES Province(id);

alter table journey_member ADD CONSTRAINT FK_Journey_MemberMember
FOREIGN KEY (member_id) REFERENCES Member(id);
alter table journey_member ADD CONSTRAINT FK_Journey_MemberJourney
FOREIGN KEY (journey_id) REFERENCES Journey(id);


--Insert Province
insert into province values (N'Hà Nội', 29)
insert into province values (N'An Giang', 67)
insert into province values (N'Cao bằng', 11)
insert into province values (N'Lạng Sơn', 12)
insert into province values (N'Hải Phòng', 15)
insert into province values (N'Thái Bình', 17)
insert into province values (N'Nam Định', 18)
insert into province values (N'Phú Thọ', 19)
insert into province values (N'Thái Nguyên', 20)
insert into province values (N'Yên Bái', 21)
insert into province values (N'Tuyên Quang', 22)
insert into province values (N'Hà Giang', 23)
insert into province values (N'Lào Cai', 24)
insert into province values (N'Lai Châu', 25)
insert into province values (N'Sơn La', 26)
insert into province values (N'Điện Biên', 27)
insert into province values (N'Hòa Bình', 28)
insert into province values (N'Hải Dương', 34)
insert into province values (N'Ninh Bình', 35)
insert into province values (N'Thanh Hóa', 36)
insert into province values (N'Nghệ An', 37)
insert into province values (N'Hà Tĩnh', 38)
insert into province values (N'TP Đà Nẵng', 43)
insert into province values (N'Đắk Lắk', 47)
insert into province values (N'Đắk Nông', 48)
insert into province values (N'Lâm Đồng', 49)
insert into province values (N'TP Hồ Chí Minh', 59)
insert into province values (N'Đồng Nai', 60)
insert into province values (N'Bình Dương', 61)
insert into province values (N'Long An', 62)
insert into province values (N'Tiền Giang', 63)
insert into province values (N'Vĩnh Long', 64)
insert into province values (N'Cần Thơ', 65)
insert into province values (N'Đồng Tháp', 66)
insert into province values (N'An Giang', 67)
insert into province values (N'Kiên Giang', 68)
insert into province values (N'Cà Mau', 69)
insert into province values (N'Tây Ninh', 70)
insert into province values (N'Bến Tre', 71)
insert into province values (N'Bà Rịa - Vũng Tàu', 72)
insert into province values (N'Quảng Bình', 73)
insert into province values (N'Quảng Trị', 74)
insert into province values (N'Thừa Thiên Huế', 75)
insert into province values (N'Quảng Ngãi', 76)
insert into province values (N'Bình Định', 77)
insert into province values (N'Phú Yên', 78)
insert into province values (N'Khánh Hòa', 79)
insert into province values (N'Gia Lai', 81)
insert into province values (N'Kon Tum', 82)
insert into province values (N'Sóc Trăng', 83)
insert into province values (N'Trà Vinh', 84)
insert into province values (N'Ninh Thuận', 85)
insert into province values (N'Bình Thuận', 86)
insert into province values (N'Vĩnh Phúc', 88)
insert into province values (N'Hưng Yên', 89)
insert into province values (N'Hà Nam', 90)
insert into province values (N'Quảng Nam', 92)
insert into province values (N'Bình Phước', 93)
insert into province values (N'Bạc Liêu', 94)
insert into province values (N'Hậu Giang', 95)
insert into province values (N'Bắc Cạn', 97)
insert into province values (N'Bắc Giang', 98)
insert into province values (N'Bắc Ninh', 99)

--Insert into place table
insert into place(name,image,description,address,province_id) values (N'Phố cổ Hội An','Thành Phố Hoa Mĩ',N'Thành phố tuyệt vời','Điện bàn, Quảng Nam', 1);

INSERT INTO place (name, image, description, address, province_id)
VALUES (N'Phố cổ Hội An', 'Assets\JourneyResources\dao_co_to\',N'Cô Tô có tên cổ là Chàng Sơn (Núi Chàng), từ lâu đời đã là nơi cư trú ngụ của thuyền bè ngư dân Vùng Đông Bắc, song chưa thành nơi định cư vì luôn bị những toán cướp biển Trung Quốc quấy phá. Đầu thời Nguyễn, một số ngư dân Trung Quốc bắt được những toán cướp biển và xin được nhập cư sinh sống.',N'Thị trấn Cô Tô - Tỉnh Quảng Ninh',NULL);

INSERT INTO place (name, image, description, address, province_id)
VALUES (N'Thành Phố Đà Lạt', 'Assets\JourneyResources\da_lat\',N'Địa danh Đà Lạt được bắt nguồn từ chữ Đạ Lạch, tên gọi của con suối Cam Ly. Khởi nguồn từ huyện Lạc Dương, dòng suối Cam Ly chảy qua khu vực Đà Lạt theo hướng Bắc – Nam, trong đó đoạn từ khoảng Hồ Than Thở tới thác Cam Ly ngày nay được gọi là Đạ Lạch.[4] Theo ngôn ngữ của người Thượng, Da hay Dak có nghĩa là nước, tên gọi Đà Lạt có nghĩa nước của người Lát, hay suối của người Lát (người Cơ Ho).',N'Thành phố Đà Lạt - Tỉnh Lâm Đồng',NULL);

INSERT INTO place (name, image, description, address, province_id)
VALUES (N'Bảo tàng cà phê', 'Assets\JourneyResources\bao_tang_ca_phe\',N'Dân chúng thường quen gọi tên tỉnh này là Buôn Mê Thuột hơn là Daklak. Theo truyền tụng, Buôn Mê Thuột trước có tên là "Buôn Ma Thuốt", thổ ngữ của sắc tộc Rhadé. "Buôn" là làng, ấp. "Ma" là cha. "Thuốt" là tên con của vị tù trưởng Êdê, ngày xưa đã lãnh đạo dân chúng chống lại những người Cam Bốt và Ai Lao thường tràn qua biên giới cướp phá. Vì vậy, "Buôn Ma Thuốt" được đặt tên để tưởng nhớ vị tù trưởng anh hùng tên Thuốt.',N'Thành phố Buôn Ma Thuột - Tỉnh ĐăkLăk',NULL);

INSERT INTO place (name, image, description, address, province_id)
VALUES (N'Đảo Phú Quốc', 'Assets\JourneyResources\dao_phu_quoc\',N'',N'Thị trấn Dương Đông - Tỉnh Kiên Giang',NULL);

INSERT INTO place (name, image, description, address, province_id)
VALUES (N'Cố Đô Huế', 'Assets\JourneyResources\co_do_hue\',N'',N'Tỉnh Thừa Thiên Huế',NULL);

INSERT INTO place (name, image, description, address, province_id)
VALUES (N'Vũng Tàu', 'Assets\JourneyResources\ba_ria_vung_tau\',N'',N'Thành phố Bà Rịa - Vũng Tàu',NULL);