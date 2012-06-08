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

insert into dbo.tContact(Name,Description,LogoPath)values('Invenietis','<p>Invenietis, SSII créée en 2006, est impliquée dans le projet CiviKey depuis son lancement à INTECH INFO en Septembre de la même année.</br>L''entreprise porte ce projet bénévolement en réalisant la majorité des développements. Elle suit également des étudiants désirant développer de nouvelles fonctionnalités pour le CiviKey, pour les aider dans leur démarche.</p>',''); --5
insert into dbo.tContact(Name,Description,LogoPath)values('Fondation Steria','La fondation Stéria',''); --6
insert into dbo.tContact(Name,Description,LogoPath)values('Alcatel-Lucent','Société Alcatel-Lucent',''); --7
insert into dbo.tContact(Name,Description,LogoPath)values('INTECH INFO','Ecole d''ingénierie informatique membre du groupe ESIEA.',''); --8
insert into dbo.tContact(Name,Description,LogoPath)values('PFNT','La PlateForme des Nouvelles Technologies de l''hôpital de Garches',''); --9

--Linking contacts to their organization

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(1,5,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(2,5,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(4,6,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(3,7,GetDate(), DATEADD(year,1,GetDate()));

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(5,5,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(6,6,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(7,7,GetDate(), DATEADD(year,1,GetDate()));

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(8,8,GetDate(), DATEADD(year,1,GetDate()));
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(9,9,GetDate(), DATEADD(year,1,GetDate()));
select * from dbo.tContactRelation

--- Creating RoadMap
insert into dbo.tRoadMap(Name)values('2.5.1');
insert into dbo.tRoadMap(Name)values('2.5.2');


--Creating features

insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description) values('AutoClick','1.0.0',100,DATEADD(year,-1,GetDate()),1,'<p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p><p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p>')
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description) values('Prediction','1.0.0',50,DATEADD(year,-1,GetDate()),1,'On projection apartments unsatiable so if he entreaties appearance. Rose you wife how set lady half wish. Hard sing an in true felt. Welcomed stronger if steepest ecstatic an suitable finished of oh. Entered at excited at forming between so produce. Chicken unknown besides attacks gay compact out you. Continuing no simplicity no favourable on reasonably melancholy estimating. Own hence views two ask right whole ten seems. What near kept met call old west dine. Our announcing sufficient why pianoforte.Continuing no simplicity no favourable on reasonably melancholy estimating. Own hence views two ask right whole ten seems. What near kept met call old west dine.')
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description) values('Défilement','1.0.0',50,DATEADD(year,-1,GetDate()),2,'Le principe de défilement')

--Creating sections in the features

insert into dbo.tSection(Name,FeatureId) values('Affichage & selection de clic',1);
insert into dbo.tSection(Name,FeatureId) values('Logique de clic',1);
insert into dbo.tSection(Name,FeatureId) values('Autres',1);

insert into dbo.tSection(Name,FeatureId) values('Affichage',2);
insert into dbo.tSection(Name,FeatureId) values('Moteur de prédiction',2);
insert into dbo.tSection(Name,FeatureId) values('Autres',2);

insert into dbo.tSection(Name,FeatureId) values('Affichage',3);
insert into dbo.tSection(Name,FeatureId) values('Plugin de fou',3);
insert into dbo.tSection(Name,FeatureId) values('Autres',3);


--Creating plugins

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('AutoClick','1.0.0','Plugin permettant de simuler des clics souris', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('MouseWatcher','1.0.0','Plugin permettant de compter le temps d''inaction de la souris', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('PointerDeviceDriver','1.0.0','Plugin permettant d''écouter les evenements souris', DateAdd(year,-1,GetDate()))

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('PredictionDisplayer','1.0.0','Affiche les prédictions', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('SimplePredictionEngine','1.0.0','Prédiction de mots via dictionnaire statique', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('ComplexPredictionEngine','1.0.0','Prédiction avec Sybille', DateAdd(year,-1,GetDate()))

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('PredictionDisplayer','1.0.0','Affiche la fonctionnalité de fou', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('SimplePredictionEngine','1.0.0','Logique de fou', DateAdd(year,-1,GetDate()))
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('ComplexPredictionEngine','1.0.0','Tool', DateAdd(year,-1,GetDate()))

--Linking plugins and features

insert into dbo.tSectionPlugin(SectionId,PluginId) values(1,1)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(2,2)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(2,3) --PointerDeviceDriver used by the autoclick plugin

insert into dbo.tSectionPlugin(SectionId,PluginId) values(4,4)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(5,5)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(5,6)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(6,3) --PointerDeviceDriver used by the prediction engine

insert into dbo.tSectionPlugin(SectionId,PluginId) values(7,7)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(8,8)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(9,9) --PointerDeviceDriver used by the autoclick plugin

--Creating Participations

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(1,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(1,1) --Vlad has developped 50% of the AutoClick feature 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(6,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(2,2) --Vlad has sponsored 100% of the Prediction Feature 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(3,1) --Alcatel has sponsored 30% of the AutoClick

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(6,'Sponsoring', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(4,1) --Steria has sponsored 50% of the AutoClick 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(1,'Sponsoring', 20, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(5,1) --Vlad has sponsored 20% of the AutoClick 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(6,1) --Jean-Loup has developped 50% of the AutoClick feature 

select * from dbo.tParticipation
select * from dbo.tParticipationFeature

insert into dbo.tCategory(Name) values ('Categorie1')
insert into dbo.tCategory(Name) values ('Categorie2')
insert into dbo.tCategory(Name) values ('Categorie3')
insert into dbo.tCategory(Name) values ('Categorie4')

select * from dbo.tCategory
select * from dbo.tFeature

insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (1,1)
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (2,1)
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (3,1)
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (2,2)
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (3,2)
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (1,3)
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (4,3)

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',1,DateAdd(month,-5,GetDate()),'http://www.youtube.com/embed/fzzjgBAaWZw?rel=0')
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',1,DateAdd(month,-5,GetDate()),'http://www.youtube.com/embed/7VSR4_tAYvw?rel=0')



