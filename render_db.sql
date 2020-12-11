use WeSplit
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
	image nvarchar(100),
	description text,
	address nvarchar(255),
	province_id int
)

create table journey
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(255) not null,
	end_place int not null,
	status int,
	date_start date not null,
	date_end date,
	total_cost float not null default 0 
)

create table route
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	place_start varchar(255) not null,
	description text,
	province_id int not null,
	costs float default 0,
	journey_id int not null
)

create table journey_member
(
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	journey_id int not null,
	member_id int not null,
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