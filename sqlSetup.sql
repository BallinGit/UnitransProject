Create Database UnitransTestSystemsDB
GO
use UnitransTestSystemsDB
Go
IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'tblUserDetails'))  
BEGIN
    CREATE TABLE [dbo].[tblUserDetails](
	[PK_UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[Fk_CityID] [int] NOT NULL,
	[Fk_SuburbID] [int] NOT NULL,
	[PoCode] [int] NOT NULL,
	[ContactNumber] [int] NOT NULL,
	[IDNumber] [varchar](13) NOT NULL,
	[DOB] [datetime] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[PK_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
 
CREATE INDEX IDX_tblUserDetails_UserDetail
ON tblUserDetails (Name,Surname,StreetAddress,PoCode,ContactNumber,IDNumber,DOB);

END


IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'tblCity'))  
BEGIN
    CREATE TABLE [dbo].[tblCity](
	[PK_CityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[PK_CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
 SET IDENTITY_INSERT [dbo].[tblCity] ON 
 
Insert into tblCity(PK_CityID,Name) values (1,'Cape Town')
Insert into tblCity(PK_CityID,Name) values (2,'Durban')
Insert into tblCity(PK_CityID,Name) values (3,'Johannesburg')
Insert into tblCity(PK_CityID,Name) values (4,'Port Elizabeth')
Insert into tblCity(PK_CityID,Name) values (5,'Pretoria')

  SET IDENTITY_INSERT [dbo].[tblCity] OFF

  
CREATE INDEX IDX_tblCity_NAME
ON tblCity (Name);


END


IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'tblSuburb'))  
BEGIN
    CREATE TABLE [dbo].[tblSuburb](
	[PK_SuburbID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[PK_SuburbID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
  
   SET IDENTITY_INSERT [dbo].[tblSuburb] ON

Insert into tblSuburb(PK_SuburbID,Name) values (1,'Bishopscourt')
Insert into tblSuburb(PK_SuburbID,Name) values (2,'Bloubergstrand')
Insert into tblSuburb(PK_SuburbID,Name) values (3,'Constantia')
Insert into tblSuburb(PK_SuburbID,Name) values (4,'Higgovale')
Insert into tblSuburb(PK_SuburbID,Name) values (5,'Hout Bay')
Insert into tblSuburb(PK_SuburbID,Name) values (6,'Hillcrest')
Insert into tblSuburb(PK_SuburbID,Name) values (7,'Pinetown')
Insert into tblSuburb(PK_SuburbID,Name) values (8,'Queensburgh')
Insert into tblSuburb(PK_SuburbID,Name) values (9,'Umhlanga')
Insert into tblSuburb(PK_SuburbID,Name) values (10,'Westville')
Insert into tblSuburb(PK_SuburbID,Name) values (11,'Ferndale')
Insert into tblSuburb(PK_SuburbID,Name) values (12,'Greenside')
Insert into tblSuburb(PK_SuburbID,Name) values (13,'Northcliff')
Insert into tblSuburb(PK_SuburbID,Name) values (14,'Rosebank')
Insert into tblSuburb(PK_SuburbID,Name) values (15,'Sandton')
Insert into tblSuburb(PK_SuburbID,Name) values (16,'Adcockvale')
Insert into tblSuburb(PK_SuburbID,Name) values (17,'Algoa Bay')
Insert into tblSuburb(PK_SuburbID,Name) values (18,'Arcadia')
Insert into tblSuburb(PK_SuburbID,Name) values (19,'Malabar')
Insert into tblSuburb(PK_SuburbID,Name) values (20,'Newton Park')
Insert into tblSuburb(PK_SuburbID,Name) values (21,'Alphen Park')
Insert into tblSuburb(PK_SuburbID,Name) values (22,'Brooklyn')
Insert into tblSuburb(PK_SuburbID,Name) values (23,'Colbyn')
Insert into tblSuburb(PK_SuburbID,Name) values (24,'Eastcliff')
Insert into tblSuburb(PK_SuburbID,Name) values (25,'Hillcrest')

SET IDENTITY_INSERT [dbo].[tblSuburb] OFF

CREATE INDEX IDX_tblSuburb_NAME
ON tblSuburb (Name);
 
END


IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'tblCitySuburb'))  
BEGIN
    CREATE TABLE [dbo].[tblCitySuburb](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[FK_CityID] [int] NOT NULL,
	[FK_SuburbID] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (1,1)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (1,2)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (1,3)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (1,4)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (1,5)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (2,6)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (2,7)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (2,8)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (2,9)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (2,10)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (3,11)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (3,12)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (3,13)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (3,14)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (3,15)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (4,16)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (4,17)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (4,18)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (4,19)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (4,20)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (5,21)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (5,22)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (5,23)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (5,24)
Insert into tblCitySuburb(FK_CityID,FK_SuburbID) values (5,25)

END



IF NOT EXISTS (SELECT * FROM information_schema.ROUTINES WHERE ROUTINE_NAME = 'prc_GetCity' AND ROUTINE_SCHEMA = 'dbo')
    BEGIN
        EXEC('CREATE PROCEDURE [dbo].[prc_GetCity] AS SET NOCOUNT ON;')
 
    END
GO
 
Alter  procedure [dbo].[prc_GetCity] --[dbo].[prc_GetCity]  

as 
select [PK_CityID],Name from tblCity
go

IF NOT EXISTS (SELECT * FROM information_schema.ROUTINES WHERE ROUTINE_NAME = 'prc_GetSuburb' AND ROUTINE_SCHEMA = 'dbo')
    BEGIN
        EXEC('CREATE PROCEDURE [dbo].[prc_GetSuburb] AS SET NOCOUNT ON;')
 
    END
GO
 
Alter  procedure [dbo].[prc_GetSuburb] --[dbo].[prc_GetSuburb] 1
(
	@pCityID int
)
as 

select PK_SuburbID,Name from tblSuburb
left join tblCitySuburb on tblCitySuburb.FK_SuburbID = tblSuburb.PK_SuburbID
where tblCitySuburb.FK_CityID = @pCityID
go
 

IF NOT EXISTS (SELECT * FROM information_schema.ROUTINES WHERE ROUTINE_NAME = 'prc_GetUserDetailsBySearchText' AND ROUTINE_SCHEMA = 'dbo')
    BEGIN
        EXEC('CREATE PROCEDURE [dbo].[prc_GetUserDetailsBySearchText] AS SET NOCOUNT ON;')
 
    END
GO
 
Alter  procedure [dbo].[prc_GetUserDetailsBySearchText] --[dbo].[prc_GetUserDetailsBySearchText] 'hill'
(
	@pSearchText varchar(50)
)
as 

select tblUserDetails.PK_UserID, tblUserDetails.Name, tblUserDetails.Surname, tblUserDetails.StreetAddress,tblSuburb.PK_SuburbID,tblCity.PK_CityID, tblSuburb.Name + ' ' + tblCity.Name as [Suburb City], tblUserDetails.PoCode,tblUserDetails.DOB,tblUserDetails.IDNumber from tblUserDetails
left join tblCity on tblUserDetails.Fk_CityID = tblCity.PK_CityID
left join tblSuburb on tblUserDetails.Fk_SuburbID = tblSuburb.PK_SuburbID
where (tblUserDetails.Name like '%' + @pSearchText  +'%')
or (tblUserDetails.Surname like '%' + @pSearchText  +'%')
or (tblUserDetails.StreetAddress like '%' + @pSearchText  +'%')
or (tblCity.Name like '%' + @pSearchText  +'%')
or (tblSuburb.Name like '%' + @pSearchText  +'%')
or (tblUserDetails.PoCode like '%' + @pSearchText  +'%')
or (tblUserDetails.ContactNumber like '%' + @pSearchText  +'%')
or (tblUserDetails.DOB like '%' + @pSearchText  +'%')
or (tblUserDetails.IDNumber like '%' + @pSearchText  +'%')
go




IF NOT EXISTS (SELECT * FROM information_schema.ROUTINES WHERE ROUTINE_NAME = 'prc_GetUserDetailsByLookupText' AND ROUTINE_SCHEMA = 'dbo')
    BEGIN
        EXEC('CREATE PROCEDURE [dbo].[prc_GetUserDetailsByLookupText] AS SET NOCOUNT ON;')
 
    END
GO
 
Alter  procedure [dbo].[prc_GetUserDetailsByLookupText] --[dbo].[prc_GetUserDetailsByLookupText] 'hill'
(
	@pLookupText varchar(50)
)
as 

select tblUserDetails.PK_UserID, 
case 
when tblUserDetails.Name like '%'+ @pLookupText + '%' then tblUserDetails.Name
when tblUserDetails.Surname like '%'+ @pLookupText + '%' then tblUserDetails.Surname
when tblUserDetails.StreetAddress like '%'+ @pLookupText + '%' then tblUserDetails.StreetAddress
when convert(varchar,tblUserDetails.PoCode) like '%'+ @pLookupText + '%' then  convert(varchar,tblUserDetails.PoCode)
when tblSuburb.Name  like '%'+ @pLookupText + '%' then tblSuburb.Name 
when tblCity.Name like '%'+ @pLookupText + '%' then tblCity.Name
when  convert(varchar,tblUserDetails.DOB) like '%'+ @pLookupText + '%' then  convert(varchar,tblUserDetails.DOB)
when tblUserDetails.IDNumber like '%'+ @pLookupText + '%' then tblUserDetails.IDNumber

end as SearchText

from tblUserDetails
left join tblCity on tblUserDetails.Fk_CityID = tblCity.PK_CityID
left join tblSuburb on tblUserDetails.Fk_SuburbID = tblSuburb.PK_SuburbID
where (tblUserDetails.Name like '%' + @pLookupText  +'%')
or (tblUserDetails.Surname like '%' + @pLookupText  +'%')
or (tblUserDetails.StreetAddress like '%' + @pLookupText  +'%')
or (tblCity.Name like '%' + @pLookupText  +'%')
or (tblSuburb.Name like '%' + @pLookupText  +'%')
or (convert(varchar,tblUserDetails.PoCode) like '%' + @pLookupText  +'%')
or (convert(varchar,tblUserDetails.ContactNumber) like '%' + @pLookupText  +'%')
or (tblUserDetails.DOB like '%' + @pLookupText  +'%')
or (tblUserDetails.IDNumber like '%' + @pLookupText  +'%')

go
