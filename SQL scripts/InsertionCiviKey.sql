--Creating contacts

insert into dbo.tTestimony (Author,Title,Content,CreationDate ) values('Lorem ipsum', 'un avenir radieux', 'Depuis quelques mois, le projet CiviKey prend de l''ampleur, je lui prédis un avenir radieux !', GetDate());
insert into dbo.tTestimony (Author,Title,Content,CreationDate ) values('Lourem Ipsim', 'un projet suivi', 'CiviKey fait l''objet de projets étudiant chaque année. C''est un projet suivi de très près par notre école', GetDate());
insert into dbo.tTestimony (Author,Title,Content,CreationDate ) values('louroum ipsem', 'un autre témoignage', 'Ceci est un autre témoignage', GetDate());

insert into dbo.tNews (Title,Content,CreationDate ) values('Le site CiviKey est en ligne !', 'Le site CiviKey est maintenant en ligne ! N''hésitez pas a parcourir ses différentes pages pour vous informer sur ce projet gratuit et open-source.', GetDate());
insert into dbo.tNews (Title,Content,CreationDate ) values('La Roadmap 2012 est lancée', 'Notre partenariat avec Alcatel-Lucent nous a permis de nous lancer sur le développement de la roadmap 2012, qui se terminera avec la mise à disposition de la version 2.5.2 de CiviKey <br/> détails sur la page Roadmaps.', GetDate());


insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Vlad Sargu','','','');--1
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Jean-Loup Kahloun','','','');
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Philippe Lepadellec','','','');
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('François Bessaguet','','',''); --4

insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Invenietis','<p>Invenietis, SSII créée en 2006, est impliquée dans le projet CiviKey depuis son lancement à IN''TECH INFO en Septembre de la même année.</br>L''entreprise porte ce projet bénévolement en réalisant la majorité des développements. Elle suit également des étudiants désirant développer de nouvelles fonctionnalités pour le CiviKey, pour les aider dans leur démarche.</p>','invenietis.png', 'http://www.invenietis.com'); --5
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Fondation Steria','<p>La Fondation Steria – Institut de France s’inscrit dans la politique de solidarité du Groupe Steria, qui a pour objectif de favoriser l’autonomie de publics en difficulté en leur donnant accès à l’éducation, à l’informatique et à un métier. La Fondation est née d’une démarche participative de collaborateurs de Steria en France. Elle a pour objectif de contribuer à la réduction de la fracture numérique.</p>','fondation-steria.png','http://www.fondationsteria.org'); --6
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Alcatel-Lucent','Société Alcatel-Lucent','alcatel-lucent.png', 'http://www.alcatel-lucent.com'); --7
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('IN''TECH INFO','<p>Différents groupes d''élèves se sont succédés à IN''TECH INFO pour travailler sur le Civikey depuis sa création. L''école a toujours voulu accompagner et faire vivre ce projet à vocation humaine. Il est une magnifique vitrine de leur savoir faire et des compétences mises en oeuvre. Ce travail d''équipe entre différentes entités correspond parfaitement à la pédagogie de projets développée à IN''TECH INFO qui souhaite continuer à collaborer à la réussite de ce projet encore de nombreuses années.</p>','intech-info.png', 'http://www.intechinfo.fr'); --8
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('PFNT','<p>La Plate-Forme Nouvelles Technologies (PFNT) de l’hôpital Raymond Poincaré est une unité de conseil, de démonstration, de formation et de recherche dans le domaine des Nouvelles Technologies appliquées aux personnes en situation de handicap. Initialement uniquement tournée vers la robotique d’assistance (en 1995), elle s’est peu à peu ouverte à d’autres technologies de l’information et de la communication, comme l’informatique, la Communication Améliorée et Alternative (CAA) et la domotique.</p>','pfnt.png', 'http://www.handicap.org'); --9
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Antoine Blanchet','','',''); --10
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Isaac Duplan','','',''); --11
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Objectif Aide','<p>[10:42:14] Julien MATHON: Objectif Aide est une association de loi 1901 à but non lucratif. Sa mission est de sensibiliser les personnes à la solidarité en menant des actions à caractère social, culturel ou humanitaire.<br/>Fort de sa motivation, le collectif organise chaque année un concours photographique sur un thème original et utile. Ce concours laisse ensuite place à une exposition en Île-de-France pour sensibiliser, grâce à la force des images, les Franciliens aux problèmes que rencontre notre société.</p>','objectif-aide.png','http://www.objectif-aide.org/'); --12
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Antoine Raquillet','','',''); --13
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Fondation Garches','<p>La Fondation Garches a pris la succession de l’Institut Garches, qui avait vu le jour en 1988 à l’initiative des médecins de l’Hôpital Raymond Poincaré, avec le soutien de quelques entreprises. Créée par l’Institut Garches en 2005, avec le soutien du Ministère en charge de la recherche, et d’emblée reconnue d’utilité publique, la Fondation Garches a été la première fondation de recherche à caractère scientifique dans le domaine du Handicap.</p>','fondation-garches.png', 'http://www.handicap.org'); --14
insert into dbo.tContact(Name,Description,LogoPath,WebsiteUrl)values('Olivier Spinelli','','', ''); --15

--Linking contacts to their organization

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(1,5,GetDate(), DATEADD(year,1,GetDate()));--1 Vlad --> Inv
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(2,5,GetDate(), DATEADD(year,1,GetDate()));--2 JL --> Inv
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(4,6,GetDate(), DATEADD(year,1,GetDate()));--3 F.Bessaguet --> Steria
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(3,7,GetDate(), DATEADD(year,1,GetDate()));--4 P.Lepadellec --> Alcatel

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(5,5,GetDate(), DATEADD(year,1,GetDate()));--5 Inv
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(6,6,GetDate(), DATEADD(year,1,GetDate()));--6 Steria
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(7,7,GetDate(), DATEADD(year,1,GetDate()));--7 Alcatel

insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(8,8,GetDate(), DATEADD(year,1,GetDate()));--8 Intech
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(9,9,GetDate(), DATEADD(year,1,GetDate()));--9 PFNT
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(10,5,GetDate(), DATEADD(year,1,GetDate()));--10 Antoine --> Inv
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(11,8,GetDate(), DATEADD(year,1,GetDate()));--11 Isaac --> Intech
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(12,12,GetDate(), DATEADD(year,1,GetDate()));--12 Objectif Aide
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(13,5,GetDate(), DATEADD(year,1,GetDate()));--13 Antoine Raquillet --> Inv
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(14,14,GetDate(), DATEADD(year,1,GetDate()));--14 Fondation Garches
insert into dbo.tContactRelation(ContactId,EntityId,StartDate,EndDate)values(15,5,GetDate(), DATEADD(year,1,GetDate()));--14 Olivier Spinelli --> inv

--OK
																									--TODO : handle dates
--- Creating RoadMap
insert into dbo.tRoadMap(Name, HasRelease)values('2.5.1', 1);
insert into dbo.tRoadMap(Name, HasRelease)values('2.5.2', 1);
insert into dbo.tRoadMap(Name, HasRelease)values('2.6.0', 0); --futur

--Creating features
--2.5.1
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('AutoClick','1.0.0',100,DATEADD(year,-1,GetDate()),1,'<p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p><p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p>', 2)
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Clavier','1.0.0',100,DATEADD(year,-1,GetDate()),1,'<p>Le clavier de CiviKey, celui-ci affiche un clavier configuré via un fichier xml. En editant ce fichier, on peut ajouter ou modifier des touches, pour leur faire envoyer le texte souhaité. <br/>La couleur des touches est modifiable. <br/> Autre fonctionnalités : <br/> le clavier peut être configuré pour se minimiser au bout d''un temps défini d''inaction, minimisant l''espace pris par le clavier sur l''écran.</p>', 2)
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Object Explorer','1.0.0',100,DATEADD(year,-1,GetDate()),1,'<p>Outil de configuration de CiviKey, reservé aux utilisateurs confirmés, il permet de décider du lancement automatique d''une fonctionnalité, et de visualiser l''état du système.</p>', 2)
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Automatic update','1.0.0',100,DATEADD(year,-1,GetDate()),1,'<p>Mise à jour automatique de CiviKey.</p>', 2)
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Noyau','1.0.0',100,DATEADD(year,-1,GetDate()),1,'<p>Le noyau de CiviKey. C''est lui qui assure la modularité de CiviKey en gérant le lancement et l''arret des différentes fonctionnalités. <br/> Utilise le .NET Framework 3.5.</p>', 2)
--OK
--2.5.2
--6
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('AutoClick','1.0.0',100,DATEADD(year,-1,GetDate()),2,'<p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p><p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p>', 1)
--7
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Clavier','1.0.0',100,DATEADD(year,-1,GetDate()),2,'<p>Le clavier de CiviKey, celui-ci affiche un clavier configuré via un fichier xml. En editant ce fichier, on peut ajouter ou modifier des touches, pour leur faire envoyer le texte souhaité. <br/>La couleur des touches est modifiable. <br/> Autre fonctionnalités : <br/> le clavier peut être configuré pour se minimiser au bout d''un temps défini d''inaction, minimisant l''espace pris par le clavier sur l''écran.</p>', 1)
--8
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Object Explorer','1.0.0',100,DATEADD(year,-1,GetDate()),2,'<p>Outil de configuration de CiviKey, reservé aux utilisateurs confirmés, il permet de décider du lancement automatique d''une fonctionnalité, et de visualiser l''état du système.</p>', 1)
--9
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Automatic update','1.0.0',100,DATEADD(year,-1,GetDate()),2,'<p>Mise à jour automatique de CiviKey.</p>', 1)
--10
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Noyau','1.0.0',100,DATEADD(year,-1,GetDate()),2,'<p>Le noyau de CiviKey. C''est lui qui assure la modularité de CiviKey en gérant le lancement et l''arret des différentes fonctionnalités. <br/> Cette nouvelle version utilise le framework .NET 4.0</p>', 3)

--2.6
--11
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('AutoClick','1.0.0',100,DATEADD(year,-1,GetDate()),3,'<p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p><p>Cette fonctionnalité permet de simuler des clics souris, sans avoir a utiliser de contacteur, l''immobilité de la souris pendant un temps configurable lance le clic automatiquement. <br/> Un cartouche permet de selectionner le type de clic que l''on veut effectuer : clic gauche, clic droit, double clic ou encore glisser-déposer.<br/> Pour plus d''informations, regardez le screencast ci-dessous.</p>', 1)
--12
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Clavier','1.0.0',100,DATEADD(year,-1,GetDate()),3,'<p>Le clavier de CiviKey, celui-ci affiche un clavier configuré via un fichier xml. En editant ce fichier, on peut ajouter ou modifier des touches, pour leur faire envoyer le texte souhaité. <br/>La couleur des touches est modifiable. <br/> Autre fonctionnalités : <br/> le clavier peut être configuré pour se minimiser au bout d''un temps défini d''inaction, minimisant l''espace pris par le clavier sur l''écran.</p>', 1)
--13
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Object Explorer','1.0.0',100,DATEADD(year,-1,GetDate()),3,'<p>Outil de configuration de CiviKey, reservé aux utilisateurs confirmés, il permet de décider du lancement automatique d''une fonctionnalité, et de visualiser l''état du système.</p>', 1)
--14
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Automatic update','1.0.0',100,DATEADD(year,-1,GetDate()),3,'<p>Mise à jour automatique de CiviKey.</p>', 1)
--15
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Noyau','1.0.0',100,DATEADD(year,-1,GetDate()),3,'<p>Le noyau de CiviKey. C''est lui qui assure la modularité de CiviKey en gérant le lancement et l''arret des différentes fonctionnalités. <br/> Cette nouvelle version utilise le framework .NET 4.0</p>', 1)
--16
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Prédiction','1.0.0',0,DATEADD(year,-1,GetDate()),3,'<p>Cette fonctionnalité affiche les mots les plus probables considérant les touches selectionnées précédemment via le clavier CiviKey. Cette prédiction s''adapte à l''utilisateur, en permettant d''enregistrer d''autres mots. Elle augmente automatiquement la pondération des mots les plus utilisés.</p>', 2)
--17
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Défilement clavier','1.0.0',0,DATEADD(year,-1,GetDate()),3,'<p>Les touches du clavier sont ''allumés'' l''une après l''autre, pour permettre à un utilsiateur équipé d''un simple contacteur d''activer des touches du clavier CiviKey. Permet de défiler sur la panel contenant la prédiction de mots.</p>', 2)
--18
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Défilement souris','1.0.0',0,DATEADD(year,-1,GetDate()),3,'<p>Permet à un utilisateur équipé d''un simple contacteur de déplacer la souris, via un système de défilement sur les différentes zones de l''écran. Peut-être associé à l''auto clic pour lancer différents types de clics.</p>', 2)
--19
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Assistant création','1.0.0',0,DATEADD(year,-1,GetDate()),3,'<p>Permet de créer de nouveaux claviers, en choisissant les touches, leur taille et leur disposition.</p>', 2)
--20
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Assistant 1er démarrage','1.0.0',0,DATEADD(year,-1,GetDate()),3,'<p>Assistant de configuration de CiviKey au premier lancement d''un nouvel utilisateur.<br/>Permet de choisir les fonctionnalités à lancer au démarrage de l''application</p>', 2)
--21
insert into dbo.tFeature(Title,Version,Progress,CreationDate,IdRoadMap,Description, Type) values('Aide en ligne','1.0.0',0,DATEADD(year,-1,GetDate()),3,'<p>Intégration de point d''information sur les différentes fonctionnalités, pour expliquer le fonctionnement de chacune.</p>', 2)
-------------------------STOPPED HERE

--Creating sections in the features

insert into dbo.tSection(Name,FeatureId) values('Affichage & selection de clic',1); --1
insert into dbo.tSection(Name,FeatureId) values('Logique de clic',1); --2
insert into dbo.tSection(Name,FeatureId) values('Autres',1); --3

insert into dbo.tSection(Name,FeatureId) values('Affichage',2); --4
insert into dbo.tSection(Name,FeatureId) values('Gestionnaire de claviers',2); --5
insert into dbo.tSection(Name,FeatureId) values('Autres',2); --6

insert into dbo.tSection(Name,FeatureId) values('Plugin principal',3); --7

insert into dbo.tSection(Name,FeatureId) values('Noyau',5); --8

--roadmap 2.5.2
insert into dbo.tSection(Name,FeatureId) values('Affichage & selection de clic',1); --9
insert into dbo.tSection(Name,FeatureId) values('Logique de clic',1); --10
insert into dbo.tSection(Name,FeatureId) values('Autres',1); --11

insert into dbo.tSection(Name,FeatureId) values('Affichage',2); --12
insert into dbo.tSection(Name,FeatureId) values('Gestionnaire de claviers',2); --13
insert into dbo.tSection(Name,FeatureId) values('Autres',2); --14

insert into dbo.tSection(Name,FeatureId) values('Plugin principal',3); --15
insert into dbo.tSection(Name,FeatureId) values('Plugin principal',4); --16

insert into dbo.tSection(Name,FeatureId) values('Noyau',5); --17

--roadmap 2.6
insert into dbo.tSection(Name,FeatureId) values('Affichage & selection de clic',1); --18
insert into dbo.tSection(Name,FeatureId) values('Logique de clic',1); --19
insert into dbo.tSection(Name,FeatureId) values('Autres',1); --20

insert into dbo.tSection(Name,FeatureId) values('Affichage',2); --21
insert into dbo.tSection(Name,FeatureId) values('Gestionnaire de claviers',2); --22
insert into dbo.tSection(Name,FeatureId) values('Autres',2); --23

insert into dbo.tSection(Name,FeatureId) values('Plugin principal',3); --24
insert into dbo.tSection(Name,FeatureId) values('Plugin principal',4); --25

insert into dbo.tSection(Name,FeatureId) values('Noyau',5); --26

--Creating plugins

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('AutoClick','1.0.0','Plugin permettant de simuler des clics souris', DateAdd(year,-1,GetDate())) --1
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('MouseWatcher','1.0.0','Plugin permettant de compter le temps d''inaction de la souris', DateAdd(year,-1,GetDate())) --2
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('PointerDeviceDriver','1.0.0','Plugin permettant d''écouter les evenements souris', DateAdd(year,-1,GetDate())) --3

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('CK.KeyboardContext','1.0.0','Le modèle de claviers', DateAdd(year,-1,GetDate())) --4
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Simple skin','1.0.0','Le plugin d''affichage basique de CiviKey', DateAdd(year,-1,GetDate())) --5
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Simple skin editor','1.0.0','Edition des styles de touches du clavier', DateAdd(year,-1,GetDate())) --6

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Object Explorer','1.0.0','Plugin principal de la fonctionnalité Object Explorer', DateAdd(year,-1,GetDate())) --7
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Update Checker','1.0.0','Plugin principal de la fonctionnalité Automatic update', DateAdd(year,-1,GetDate())) --8

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('CK-Core','1.0.0','Noyau, framework .NET 3.5', DateAdd(year,-1,GetDate())) --9
--OK
-- roadmap 2.5.2
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('AutoClick','1.0.0','Plugin permettant de simuler des clics souris', DateAdd(year,-1,GetDate())) --10
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('MouseWatcher','1.0.0','Plugin permettant de compter le temps d''inaction de la souris', DateAdd(year,-1,GetDate())) --11
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('PointerDeviceDriver','1.0.0','Plugin permettant d''écouter les evenements souris', DateAdd(year,-1,GetDate())) --12

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('CK.KeyboardContext','1.0.0','Le modèle de claviers', DateAdd(year,-1,GetDate())) --13
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Simple skin','1.0.0','Le plugin d''affichage basique de CiviKey', DateAdd(year,-1,GetDate())) --14
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Simple skin editor','1.0.0','Edition des styles de touches du clavier', DateAdd(year,-1,GetDate())) --15

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Object Explorer','1.0.0','Plugin principal de la fonctionnalité Object Explorer', DateAdd(year,-1,GetDate())) --16
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Update Checker','1.0.0','Plugin principal de la fonctionnalité Automatic update', DateAdd(year,-1,GetDate())) --17

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('CK-Core','1.0.0','Noyau, framework .NET 4.0', DateAdd(year,-1,GetDate())) --18

-- roadmap 2.6
-- Not done, so we don't know what plugins should be in it except for those which already exist
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('AutoClick','1.0.0','Plugin permettant de simuler des clics souris', DateAdd(year,-1,GetDate())) --19
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('MouseWatcher','1.0.0','Plugin permettant de compter le temps d''inaction de la souris', DateAdd(year,-1,GetDate())) --20
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('PointerDeviceDriver','1.0.0','Plugin permettant d''écouter les evenements souris', DateAdd(year,-1,GetDate())) --21

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('CK.KeyboardContext','1.0.0','Le modèle de claviers', DateAdd(year,-1,GetDate())) --22
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Simple skin','1.0.0','Le plugin d''affichage basique de CiviKey', DateAdd(year,-1,GetDate())) --23
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Simple skin editor','1.0.0','Edition des styles de touches du clavier', DateAdd(year,-1,GetDate())) --24

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Object Explorer','1.0.0','Plugin principal de la fonctionnalité Object Explorer', DateAdd(year,-1,GetDate())) --25
insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('Update Checker','1.0.0','Plugin principal de la fonctionnalité Automatic update', DateAdd(year,-1,GetDate())) --26

insert into dbo.tPlugin(Title,Version,Description,CreationDate) values('CK-Core','1.0.0','Noyau, framework .NET 4.0', DateAdd(year,-1,GetDate())) --27



--Linking plugins and features
insert into dbo.tSectionPlugin(SectionId,PluginId) values(1,1) --AutoClick
insert into dbo.tSectionPlugin(SectionId,PluginId) values(2,2) --MouseWatcher
insert into dbo.tSectionPlugin(SectionId,PluginId) values(2,3) --PointerDeviceDriver used by the autoclick plugin

insert into dbo.tSectionPlugin(SectionId,PluginId) values(4,5) --CK.KeyboardContext --> Gestionnaire de clavier
insert into dbo.tSectionPlugin(SectionId,PluginId) values(5,4) --Simple skin --> Affichage
insert into dbo.tSectionPlugin(SectionId,PluginId) values(5,5) --Simple skin editor --> Affichage

insert into dbo.tSectionPlugin(SectionId,PluginId) values(6,7) --Object Explorer --> Plugin principal

insert into dbo.tSectionPlugin(SectionId,PluginId) values(7,8) --Update checker --> plugin principal
insert into dbo.tSectionPlugin(SectionId,PluginId) values(8,9) --Noyau --> Noyau

--2.5.2
insert into dbo.tSectionPlugin(SectionId,PluginId) values(10,10) --AutoClick
insert into dbo.tSectionPlugin(SectionId,PluginId) values(11,11) --MouseWatcher
insert into dbo.tSectionPlugin(SectionId,PluginId) values(11,12) --PointerDeviceDriver used by the autoclick plugin

insert into dbo.tSectionPlugin(SectionId,PluginId) values(13,13) --CK.KeyboardContext --> Gestionnaire de clavier
insert into dbo.tSectionPlugin(SectionId,PluginId) values(12,14) --Simple skin --> Affichage
insert into dbo.tSectionPlugin(SectionId,PluginId) values(12,15) --Simple skin editor --> Affichage

insert into dbo.tSectionPlugin(SectionId,PluginId) values(15,16) --Object Explorer --> Plugin principal

insert into dbo.tSectionPlugin(SectionId,PluginId) values(16,17) --Update checker --> plugin principal
insert into dbo.tSectionPlugin(SectionId,PluginId) values(17,18) --Noyau --> Noyau

--roadmap 2.6
--Not done, so there's no new plugins (yet)
insert into dbo.tSectionPlugin(SectionId,PluginId) values(18,19) --AutoClick
insert into dbo.tSectionPlugin(SectionId,PluginId) values(19,20) --MouseWatcher
insert into dbo.tSectionPlugin(SectionId,PluginId) values(19,21) --PointerDeviceDriver used by the autoclick plugin

insert into dbo.tSectionPlugin(SectionId,PluginId) values(21,22) --CK.KeyboardContext --> Gestionnaire de clavier
insert into dbo.tSectionPlugin(SectionId,PluginId) values(22,23) --Simple skin --> Affichage
insert into dbo.tSectionPlugin(SectionId,PluginId) values(22,24) --Simple skin editor --> Affichage

insert into dbo.tSectionPlugin(SectionId,PluginId) values(23,25) --Object Explorer --> Plugin principal

insert into dbo.tSectionPlugin(SectionId,PluginId) values(24,26) --Update checker --> plugin principal
insert into dbo.tSectionPlugin(SectionId,PluginId) values(25,27) --Noyau --> Noyau
--Creating Participations

--AC
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(1,1) --Jean-Loup has developped 100% of the AutoClick feature 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(2,1) --Invenietis has sponsored 100% of the AutoClick Feature 

--Skin
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(3,2) --Antoine has developped 100% of the Clavier

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(4,2) --Alcatel has sponsored 100% of the Clavier

--OE
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 60, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(5,3) --Antoine has developed 60% of the OE 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 40, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(6,3) --Jean-Loup has developed 40% of the OE

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(7,3) --Alcatel has sponsored 100% of the OE

--AutoUpdate
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(8,4) --Jean-Loup has developed 50% of the Automatic update

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(13,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(9,4) --Antoine Raquillet has developed 50% of the Automatic Update

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(10,4) --Alcatel has sponsored 100% of the AutomaticUpdate

--Kernel
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(15,'Development', 60, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(11,5) --Olivier Spinelli has developed 60% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 20, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(12,5) --Antoine Blanchet has developed 20% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 20, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(13,5) --Jean-loup Kahloun has developed 20% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(14,5) --Alcatel has sponsored 30% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(6,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(15,5) --Steria has sponsored 30% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(16,5) --Invenietis has sponsored 30% of the Kernel

--OK
--2.5.2
--AC
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(17,6) --Jean-Loup has developped 100% of the AutoClick feature 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(18,6) --Invenietis has sponsored 100% of the AutoClick Feature 

--Skin
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(19,7) --Antoine has developped 100% of the Clavier

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(20,7) --Alcatel has sponsored 100% of the Clavier

--OE
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 60, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(21,8) --Antoine has developed 60% of the OE 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 40, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(22,8) --Jean-Loup has developed 40% of the OE

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(23,8) --Alcatel has sponsored 100% of the OE

--AutoUpdate
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(24,9) --Jean-Loup has developed 50% of the Automatic update

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(13,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(25,9) --Antoine Raquillet has developed 50% of the Automatic Update

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(26,9) --Alcatel has sponsored 100% of the AutomaticUpdate

--Kernel
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(15,'Development', 60, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(27,10) --Olivier Spinelli has developed 60% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 20, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(28,10) --Antoine Blanchet has developed 20% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 20, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(29,10) --Jean-loup Kahloun has developed 20% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(30,10) --Alcatel has sponsored 30% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(6,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(31,10) --Steria has sponsored 30% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(32,10) --Invenietis has sponsored 30% of the Kernel

-- 2.6
--AC
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(33,11) --Jean-Loup has developped 100% of the AutoClick feature 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(34,11) --Invenietis has sponsored 100% of the AutoClick Feature 

--Skin
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(35,12) --Antoine has developped 100% of the Clavier

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(36,12) --Alcatel has sponsored 100% of the Clavier

--OE
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 60, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(37,13) --Antoine has developed 60% of the OE 

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 40, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(38,13) --Jean-Loup has developed 40% of the OE

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(39,13) --Alcatel has sponsored 100% of the OE

--AutoUpdate
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(40,14) --Jean-Loup has developed 50% of the Automatic update

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(13,'Development', 50, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(41,14) --Antoine Raquillet has developed 50% of the Automatic Update

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(42,14) --Alcatel has sponsored 100% of the AutomaticUpdate

--Kernel
insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(15,'Development', 60, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(43,15) --Olivier Spinelli has developed 60% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(10,'Development', 20, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(44,15) --Antoine Blanchet has developed 20% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(2,'Development', 20, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(45,15) --Jean-loup Kahloun has developed 20% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(46,15) --Alcatel has sponsored 30% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(6,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(47,15) --Steria has sponsored 30% of the Kernel

insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(48,15) --Invenietis has sponsored 30% of the Kernel


-- 2.6.0 : Après signature de la convention :
--Prediction
--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(49,16) --Alcatel has sponsored 50% of the Prediction

--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 30, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(50,16) --Invenietis has sponsored 50% of the Prediction


--Defilement clavier
--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(51,17) --Alcatel has sponsored 50% of the defilement clavier


--Défilement souris
--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(52,18) --Alcatel has sponsored 50% of the defilement souris

--assistant creation
--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 100, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(53,19) --Alcatel has sponsored 50% of the assistant creation

--Assistant 1er demarrage
--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 50, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(54,20) --Alcatel has sponsored 50% of the Assistant 1er demarrage

--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 50, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(55,20) --Invenietis has sponsored 50% of the Assistant 1er demarrage

--Aide en ligne
--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(7,'Sponsoring', 50, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(56,21) --Alcatel has sponsored 50% of the online help

--insert into dbo.tParticipation(ContactRelationId,PartType,Percentage,ParticipationDate) values(5,'Sponsoring', 50, DateAdd(month,-5,GetDate()))
--insert into dbo.tParticipationFeature(ParticipationId,FeatureId) values(57,21) --Invenietis has sponsored 50% of the online help

--Creating categories
insert into dbo.tCategory(Name,IconName) values ('Aide au clic','mouse_pointer_24x24.png') --1
insert into dbo.tCategory(Name,IconName) values ('Aide à la saisie','keyboard_24x24.png') --2
insert into dbo.tCategory(Name,IconName) values ('Aide au déplacement du pointeur','move_24x24.png') --3
insert into dbo.tCategory(Name,IconName) values ('Aide visuelle','zoom_in_24x24.png') --4
insert into dbo.tCategory(Name,IconName) values ('Noyau','gear_wheel_24x24.png') --5
--OK
--Linking feature to categories
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (1,1) --Autoclick - clic
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (2,2) --Clavier - saisie
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (4,2) --Clavier - aide visuelle
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,3) --OE - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,4) --Update checker - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,5) --Noyau - noyau
--OK
--2.5.2
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (1,6) --Autoclick - clic
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (2,7) --Clavier - saisie
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (4,7) --Clavier - aide visuelle
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,8) --OE - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,9) --Update checker - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,10) --Noyau - noyau

--2.6
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (1,11) --Autoclick - clic
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (2,12) --Clavier - saisie
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (4,12) --Clavier - aide visuelle
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,13) --OE - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,14) --Update checker - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,15) --Noyau - noyau
--new
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (2,16) --Prediction - saisie
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (2,17) --Défilement clavier - saisie
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (3,18) --Défilement souris - aide au déplacement du pointeur
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,19) --Assistant création - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,20) --Assistant 1er démarrage - noyau
insert into dbo.tCategoryFeature (IdCategory, IdFeature) values (5,21) --Aide en ligne - noyau

--Video
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',1,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw') --AutoClick 2.5.1
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',1,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',2,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--Clavier 2.5.1
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',2,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',3,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--ObjExplorer 2.5.1
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',3,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',4,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--Auto Update 2.5.1
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',4,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')
--OK
--2.5.2
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',6,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw') --AutoClick 2.5.2
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',6,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',7,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--Clavier 2.5.2
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',7,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',8,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--ObjExplorer 2.5.2
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',8,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',9,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--Auto Update 2.5.2
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',9,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

--2.6
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',11,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw') --AutoClick 2.6
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',11,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',12,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--Clavier 2.6
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',12,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',13,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--ObjExplorer 2.6
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',13,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')

insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial',14,DateAdd(month,-5,GetDate()),'fzzjgBAaWZw')--Auto Update 2.6
insert into dbo.tVideo (Name,FeatureId, CreationDate, VideoSource) values ('Tutorial2',14,DateAdd(month,-5,GetDate()),'7VSR4_tAYvw')















