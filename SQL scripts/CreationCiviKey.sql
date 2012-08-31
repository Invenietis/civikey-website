
drop table tVideo;
drop table tTestimony;
drop table tSectionPlugin;
drop table tSection;
drop table tPlugin;
drop table tParticipationFeature;
drop table tParticipationRoadmap;
drop table tParticipation;
drop table tNews;
drop table tContactRelation;
drop table tContact;
drop table tCategoryFeature;
drop table tCategory;
drop table tFeature;
drop table tRoadMap;
--Stored procedures
if exists (select * from dbo.sysobjects where id = object_id(N'dbo.GetContactIdFromSafeName') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure dbo.GetContactIdFromSafeName
GO
CREATE PROCEDURE [dbo].[GetContactIdFromSafeName]
      @safeName nvarchar(128)
      AS
      SELECT Id FROM tContact
      WHERE LOWER(REPLACE(REPLACE(Name, '''',''),' ','-')) = @safeName;
GO
create table tNews
(
	Id int not null primary key identity(1,1),
	Title varchar(128) not null,
	Content nvarchar(max) not null,
	CreationDate smalldatetime not null
);

create table tTestimony
(
	Id int not null primary key identity(1,1),
	Author varchar (max) not null,
	Title varchar(128) not null,
	Content nvarchar(max) not null,
	CreationDate smalldatetime not null
);

create table tRoadMap
(
	Id int not null primary key identity(1,1),
	Name varchar(32) not null,
	HasRelease bit not null
)

create table tPlugin
(
	Id int not null primary key identity(1,1),
	Title varchar(128) not null,
	Version varchar(12) not null,
	Description nvarchar(max) not null,
	CreationDate smalldatetime not null
);

create table tContact
(
	Id int not null primary key identity(1,1),
	Name varchar(128) not null,
	Description nvarchar(max) not null,
	LogoPath nvarchar(max) not null,
	WebsiteUrl nvarchar(256) not null
);

create table tContactRelation
(
	Id int not null primary key identity(1,1),
	ContactId int not null,
	EntityId int not null,
	StartDate smalldatetime not null,
	EndDate smalldatetime,
	constraint FK_ContactId foreign key (ContactId)
	references tContact(Id),
	constraint FK_EntityId foreign key (EntityId)
	references tContact(Id)
);

create table tFeature
(
	Id int not null primary key identity(1,1),
	Title varchar(128) not null,
	Description varchar(max) not null,
	Version varchar(12) not null,
	Progress int not null,
	CreationDate smalldatetime not null,
	IdRoadMap int not null,
	Type int not null,
	LogoPath varchar(256) not null,
	constraint FK_IdRoadMap foreign key (IdRoadMap)
	references tRoadMap(Id)
);

create table tSection
(
	Id int not null primary key identity(1,1),
	Name varchar(128) not null,
	FeatureId int not null,
	constraint FK_FeatureId foreign key (FeatureId)
	references tFeature(Id)
);

create table tSectionPlugin
(
	SectionId int not null,
	PluginId int not null,
	constraint FK_SectionId foreign key (SectionId) references tSection(Id),
	constraint FK_PluginId foreign key (PluginId) references tPlugin(Id),
	constraint PK_tPluginSection primary key clustered ( SectionId, PluginId ) on [PRIMARY]
);

create table tCategory
(
	Id int not null primary key identity(1,1),
	Name varchar(128) not null,
	IconName varchar(128)
);

create table tParticipation
(
	Id int not null primary key identity(1,1),
	ContactRelationId int not null,
	PartType varchar(max) not null,
	Percentage int not null,
	ParticipationDate smalldatetime not null,
	constraint FK_ContactIdParticipation foreign key (ContactRelationId) references tContactRelation(Id)
)

create table tCategoryFeature
(
	IdCategory int not null,
	IdFeature int not null,
	constraint FK_IdCategory foreign key (IdCategory) references tCategory(Id),
	constraint FK_IdFeature foreign key (IdFeature)references tFeature(Id),
	constraint PK_tCategoryFeature primary key clustered (IdCategory, IdFeature) on [PRIMARY]
)

create table tVideo
(
	Id int not null primary key identity(1,1),
	Name varchar(128) not null,
	VideoSource nvarchar(max) not null,
	FeatureId int not null,
	CreationDate smalldatetime not null,
	constraint FK_FeatureIdVideo foreign key (FeatureId) references tFeature(Id)
)

create table tParticipationFeature
(
	ParticipationId int not null primary key,
	FeatureId int not null,
	constraint FK_ParticipationId foreign key (ParticipationId) references tParticipation(Id),
	constraint FK_FeatureIdPart foreign key (FeatureId) references tFeature (Id)
)

create table tParticipationRoadmap
(
	ParticipationId int not null primary key,
	RoadmapId int not null,
	constraint FK_ParticipationRoadmapId foreign key (ParticipationId) references tParticipation(Id),
	constraint FK_RoadmapIdPart foreign key (RoadmapId) references tRoadMap (Id)
)

--- V2
create table dbo.tReleaseNote
(
	Id int not null primary key identity(1,1),
	RoadmapId int not null ,
	RevisionNumber int not null,
	HtmlContent nvarchar(max) not null,
	ReleaseDate smalldatetime not null,
	constraint FK_ReleaseNoteRoadmapID foreign key (RoadmapId) references tRoadMap(Id),
	constraint UC_ReleaseNote UNIQUE (RoadmapId,RevisionNumber)
)






