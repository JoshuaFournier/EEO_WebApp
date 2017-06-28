CREATE TABLE PAYS (
	paysID int not null identity PRIMARY KEY,
	libelle varchar(25),
);
GO

CREATE TABLE VILLE (
	villeID int not null identity PRIMARY KEY,
	libelle varchar(25),
	paysID int FOREIGN KEY REFERENCES PAYS(paysID)
);
GO

CREATE TABLE TYPESITE (
	typesiteID int not null identity PRIMARY KEY,
	libelle varchar(25),
	villeID int FOREIGN KEY REFERENCES VILLE(villeID)
);
GO

CREATE TABLE LIGNEPROD (
	ligneprodID int not null identity PRIMARY KEY,
	libelle varchar(25),
	typesiteID int FOREIGN KEY REFERENCES TYPESITE(typesiteID)
);
GO

CREATE TABLE TYPEEQUIPEMENT (
	typeequipementID int not null identity PRIMARY KEY,
	libelle varchar(25),
	ligneprodID int FOREIGN KEY REFERENCES LIGNEPROD(ligneprodID),
);
GO

CREATE TABLE RAISON (
	raisonID int not null identity PRIMARY KEY,
	description varchar(25),
	typeequipementID int FOREIGN KEY REFERENCES TYPEEQUIPEMENT(typeequipementID)
);
GO

CREATE TABLE EQUIPEMENT (
	equipementID int not null identity PRIMARY KEY,
	libelle varchar(25),
	typeequipementID int FOREIGN KEY REFERENCES TYPEEQUIPEMENT(typeequipementID)
);
GO

CREATE TABLE OEEDOWNTIME (
	oeedowntimeID int not null identity PRIMARY KEY,
	dateDebut DateTime,
	dateFin DateTime,
	duree int,
	commentaire varchar(200),
	equipementID int FOREIGN KEY REFERENCES EQUIPEMENT(equipementID)
);
GO
