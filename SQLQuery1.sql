--Kreirajte funkcionalnu aplikaciju za upravljanje flotom vozila. Aplikacija omogu�ava korisniku:
--� registraciju voza�a (ime, prezime, broj mobitela, broj voza�ke dozvole), unos vozila (tip, marka, godina
--proizvodnje, inicijalno stanje kilometara)
--� kreiranje putnog naloga i dodjelu vozila voza�u, pregled putnih naloga
--o Pregled PN po voza�u, detalji PN za voza�a, pregled svih PNa � otvorenih, zatvorenih, budu�ih, filtriranih
--o Evidenciju tro�kova goriva (tko, kada, gdje, koliko i po kojoj cijeni je kupio gorivo)
--� Pra�enje prije�ene rute za svaki putni nalog putem GPS-a
--o Osigurati API za automatski unos informacije u aplikaciju: vrijeme, koordinata A i B, prije�eni kilometri
--izme�u A i B, prosje�na brzina izme�u A i B, potro�eno gorivo izme�u A I B
--� Pra�enje servisnih intervala i tro�kova servisa vozila
--o unos informacija direktnim na�inom u aplikaciju, pregled
--� Izradu izvje�taja:
--o Za putne naloge
--o Za servisne intervale


--o Procedura za ubacivanje nekoliko testnih zapisa
--o Procedura za �i��enje baze � koja bazu dovodi u stanje bez zapisa

--VOZAC
--VOZILO
--PUTNI NALOG


--� Voza�i:
--o Forma za jednostavni pregled voza�a
--o Forma za CRUD pojedinog voza�a
--o direktni sql za voza�e
--o SP za vozila
--� Putni nalozi:
--o Forma za pregled putnih naloga + filtriranje po tipu (budu�i, zatvoreni,
--aktivni)
--o Forma za CRUD za putni nalog: odabir voza�a, odabir slobodnog vozila,
--popunjavanje osnovnih informacija o PNu (start/stop grad, o�ekivani broj
--dana, �)
--o transakcije
--� Hvatanje iznimaka kori�tenjem InfoMessage 
--me, prezime, broj mobitela, broj voza�ke dozvole)

--INSERT into tblVozac (IME,Prezime,BrojMobitela,SerijskiBrojVozacke)
--VALUES
--('Andre','Matic','123-4566-123','A1234567'),
--('Iva','Staric','123-4566-124','A2234567'),
--('Starija','Katic','123-4566-125','A3234567')
--GO;
--CREATE PROCEDURE InsertTestDrivers
--as
--INSERT into tblVozac (IME,Prezime,BrojMobitela,SerijskiBrojVozacke)
--VALUES
--('Andre','Matic','123-4566-123','A1234567'),
--('Iva','Staric','123-4566-124','A2234567'),
--('Starija','Katic','123-4566-125','A3234567')
Create Database VehicleControl
use VehicleControl

create Table tblVozac(
IDVozac int primary key identity,
Ime nvarchar(50),
Prezime nvarchar(50),
BrojMobitela nvarchar(50),
SerijskiBrojVozacke nvarchar(8),

);
--unos vozila (tip, marka, godina
--proizvodnje, inicijalno stanje kilometara)
create Table tblVozilo(
IDVozilo int primary key identity,
Tip nvarchar(50),
Marka nvarchar(50),
GodinaProizvodnje DateTime,
InicijalniKM int,
);



GO;
CREATE PROCEDURE SelectAllVehicles
AS
Select * FROM tblVozilo
GO;

CREATE PROCEDURE FindWarrantBetweenDates @pBegin Date, @pEnd Date
as
Select * from tblPutniNalog as f
Where (f.StartDate <= @pEnd) and (f.StopDate >= @pBegin)

GO;


CREATE PROCEDURE InsertTestVehicles
as
INSERT into tblVozilo(Tip,Marka,GodinaProizvodnje,InicijalniKM)
VALUES
('Sedan','Toyota',1996,10000),
('Truck','BMW',1992,1000),
('Minivan','Fiat',2000,19500)

GO;



Create Procedure SelectAllDrivers
as
Select * From tblVozac
GO;

CREATE PROCEDURE WipeTheTable
as
DELETE FROM tblVozac;
DELETE FROM tblVozilo;
GO;

Create PROCEDURE AddDriver @pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
as
INSERT into tblVozac (IME,Prezime,BrojMobitela,SerijskiBrojVozacke)
VALUES
(@pIme,@pPrezime,@pBrojMobitela,@pSerijskiBrojVozacke)

GO;

Create PROCEDURE DeleteDriver @pID int
as
DELETE FROM tblVozac
Where IDVozac=@pID
GO;

Create PROCEDURE UpdateDriver @pID int, @pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
as
UPDATE tblVozac
SET Ime=@pIme, Prezime=@pPrezime,BrojMobitela=@pBrojMobitela,SerijskiBrojVozacke=@pSerijskiBrojVozacke
Where IDVozac=@pID

EXEC SelectallVehicles

Exec InsertTestDrivers
Exec WipeTheTable
GO;

Create PROCEDURE AddVehicles @pTip nvarchar(50), @pMarka nvarchar(50), @pGodinaProizvodnje DateTime,@pInicijalniKM int
as
INSERT into tblVozilo(Tip,Marka,GodinaProizvodnje,InicijalniKM)
VALUES
(@pTip,@pMarka,@pGodinaProizvodnje,@pInicijalniKM)

GO;

Create PROCEDURE DeleteVehicle @pID int
as
DELETE FROM tblVozilo
Where IDVozilo=@pID
GO;

Create PROCEDURE UpdateVehicle @pID int,  @pTip nvarchar(50), @pMarka nvarchar(50), @pGodinaProizvodnje DateTime,@pInicijalniKM int
as
UPDATE tblVozilo
SET Tip=@pTip, Marka=@pMarka,GodinaProizvodnje=@pGodinaProizvodnje,InicijalniKM=@pInicijalniKM
Where IDVozilo=@pID

GO;
Create Table tblPutniNalog(
IDPutniNalog int primary key identity,
VozacID int foreign key References tblVozac(IDVozac),
VoziloID int foreign key References tblVozilo(IDVozilo),
StartGrad nvarchar(50),
StopGrad nvarchar(50),
StartDate Date,
StopDate Date,
);
GO;
Create Proc SelectAllWarrants
as
Select * FROM tblPutniNalog;

GO;


Create Proc FindVozacById @pID int
as
Select * from tblVozac where IDVozac=@pID

GO
Create Proc FindVoziloById @pID int
as
Select * from tblVozilo where IDVozilo=@pID
GO;
EXEC SelectAllWarrants

GO;

Create Proc WarrantCreate @pVozacID int, @pVoziloID int,@pStartGrad nvarchar(50),@pStopGrad nvarchar(50),@pStartDate Date,@pStopDate Date
as
Insert into tblPutniNalog(VozacID,VoziloID,StartGrad,StopGrad,StartDate,StopDate)
Values(@pVozacID,@pVoziloID,@pStartGrad,@pStopGrad,@pStartDate,@pStopDate)
GO;

Create PROCEDURE DeleteWarrant @pID int
as
DELETE FROM tblPutniNalog
Where IDPutniNalog=@pID
GO;
Drop Proc UpdateWarrant
GO;

Create PROCEDURE UpdateWarrant @pID int,@pVozacID int, @pVoziloID int,@pStartGrad nvarchar(50),@pStopGrad nvarchar(50),@pStartDate Date,@pStopDate Date
as
UPDATE tblPutniNalog
SET VoziloID=@pVoziloID,VozacID=@pVozacID,StartGrad=@pStartGrad,StopGrad=@pStopGrad,StartDate=@pStartDate,StopDate=@pStopDate
Where IDPutniNalog=@pID

GO;

Create PROCEDURE FindWarrantByID @pID int
as
Select * from tblPutniNalog Where IDPutniNalog=@pID

GO;
