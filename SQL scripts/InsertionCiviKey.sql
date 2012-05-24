--DBCC CHECKIDENT (tContact, reseed, 0)
--DBCC CHECKIDENT (tContactRelation, reseed, 0)
--DBCC CHECKIDENT (tParticipation, reseed, 0)

--delete from dbo.tContact
--delete from dbo.tContactRelation
--delete from dbo.tParticipation
--delete from dbo.tParticipationFeature

--Creating contacts

insert into dbo.tContact(Name,Description,LogoPath)values('Vlad','','');--1
insert into dbo.tContact(Name,Description,LogoPath)values('Jean-Loup','','');
insert into dbo.tContact(Name,Description,LogoPath)values('Philippe Lepadellec','','');
insert into dbo.tContact(Name,Description,LogoPath)values('François Bessaguet','',''); --4

insert into dbo.tContact(Name,Description,LogoPath)values('Invenietis','SSII',''); --5
insert into dbo.tContact(Name,Description,LogoPath)values('Steria','Financeur de folie',''); --6
insert into dbo.tContact(Name,Description,LogoPath)values('Alcatel','Aloé vera',''); --7

--Linking contacts to their organization

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(1,5,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(2,5,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(4,6,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(3,7,GetDate(), DATEADD(year,1,GetDate()));

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(5,5,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(6,6,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(7,7,GetDate(), DATEADD(year,1,GetDate()));
select * from dbo.tContactRelation


--- Creating RoadMap
insert into dbo.tRoadMap(Name)values('3.4.5');


--Creating features

insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap) values('AutoClick','1.0.0',100,DATEADD(year,-1,GetDate()),1)
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap) values('Prediction','1.0.0',50,DATEADD(year,-1,GetDate()),1)

--Creating sections in the features

insert into dbo.tSection(Name,FeatureId) values('Affichage & selection de clic',1);
insert into dbo.tSection(Name,FeatureId) values('Logique de clic',1);
insert into dbo.tSection(Name,FeatureId) values('Autres',1);

insert into dbo.tSection(Name,FeatureId) values('Affichage',2);
insert into dbo.tSection(Name,FeatureId) values('Moteur de prédiction',2);
insert into dbo.tSection(Name,FeatureId) values('Autres',2);

--Creating plugins

insert into dbo.tPlugin(Title,Description,CreationDate) values('AutoClick','Plugin permettant de simuler des clics souris', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Description,CreationDate) values('MouseWatcher','Plugin permettant de compter le temps d''inaction de la souris', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Description,CreationDate) values('PointerDeviceDriver','Plugin permettant d''écouter les evenements souris', DateAdd(year,-1,GetDate()))

insert into dbo.tPlugin(Title,Description,CreationDate) values('PredictionDisplayer','Affiche les prédictions', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Description,CreationDate) values('SimplePredictionEngine','Prédiction de mots via dictionnaire statique', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Description,CreationDate) values('ComplexPredictionEngine','Prédiction avec Sybille', DateAdd(year,-1,GetDate()))

--Linking plugins and features

insert into dbo.tSectionPlugin(SectionId,PluginId) values(1,1)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(2,2)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(2,3) --PointerDeviceDriver used by the autoclick plugin

insert into dbo.tSectionPlugin(SectionId,PluginId) values(4,4)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(5,5)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(5,6)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(6,3) --PointerDeviceDriver used by the prediction engine

--Creating Participations

insert into dbo.tParticipation(ContactId,PartType,Percentage,ParticipationDate) values(1,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(1,1) --Vlad has developped 50% of the AutoClick feature 

insert into dbo.tParticipation(ContactId,PartType,Percentage,ParticipationDate) values(6,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(2,2) --Vlad has sponsored 100% of the Prediction Feature 

select * from dbo.tParticipation
select * from dbo.tParticipationFeature







