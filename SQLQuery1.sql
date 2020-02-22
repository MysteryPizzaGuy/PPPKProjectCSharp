
Create Database VehicleControl
GO
use VehicleControl

create Table tblVozac(
IDVozac int primary key identity,
Ime nvarchar(50),
Prezime nvarchar(50),
BrojMobitela nvarchar(50),
SerijskiBrojVozacke nvarchar(8),

);
GO
--unos vozila (tip, marka, godina
--proizvodnje, inicijalno stanje kilometara)
create Table tblVozilo(
IDVozilo int primary key identity,
Tip nvarchar(50),
Marka nvarchar(50),
GodinaProizvodnje DateTime,
InicijalniKM int,
);



GO
CREATE PROCEDURE SelectAllVehicles
AS
Select * FROM tblVozilo
GO

CREATE PROCEDURE FindWarrantBetweenDates @pBegin Date, @pEnd Date
as
Select * from tblPutniNalog as f
Where (f.StartDate <= @pEnd) and (f.StopDate >= @pBegin)

GO


CREATE PROCEDURE InsertTestVehicles
as
INSERT into tblVozilo(Tip,Marka,GodinaProizvodnje,InicijalniKM)
VALUES
('Sedan','Toyota',1996,10000),
('Truck','BMW',1992,1000),
('Minivan','Fiat',2000,19500)

GO



Create Procedure SelectAllDrivers
as
Select * From tblVozac
GO

CREATE PROCEDURE WipeTheTable
as
DELETE FROM tblVozac;
DELETE FROM tblVozilo;
GO

Create PROCEDURE AddDriver @pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
as
INSERT into tblVozac (IME,Prezime,BrojMobitela,SerijskiBrojVozacke)
VALUES
(@pIme,@pPrezime,@pBrojMobitela,@pSerijskiBrojVozacke)

GO

Create PROCEDURE DeleteDriver @pID int
as
DELETE FROM tblVozac
Where IDVozac=@pID
GO

Create PROCEDURE UpdateDriver @pID int, @pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
as
UPDATE tblVozac
SET Ime=@pIme, Prezime=@pPrezime,BrojMobitela=@pBrojMobitela,SerijskiBrojVozacke=@pSerijskiBrojVozacke
Where IDVozac=@pID


GO

Create PROCEDURE AddVehicles @pTip nvarchar(50), @pMarka nvarchar(50), @pGodinaProizvodnje DateTime,@pInicijalniKM int
as
INSERT into tblVozilo(Tip,Marka,GodinaProizvodnje,InicijalniKM)
VALUES
(@pTip,@pMarka,@pGodinaProizvodnje,@pInicijalniKM)

GO

Create PROCEDURE DeleteVehicle @pID int
as
DELETE FROM tblVozilo
Where IDVozilo=@pID
GO

Create PROCEDURE UpdateVehicle @pID int,  @pTip nvarchar(50), @pMarka nvarchar(50), @pGodinaProizvodnje DateTime,@pInicijalniKM int
as
UPDATE tblVozilo
SET Tip=@pTip, Marka=@pMarka,GodinaProizvodnje=@pGodinaProizvodnje,InicijalniKM=@pInicijalniKM
Where IDVozilo=@pID

GO
Create Table tblPutniNalog(
IDPutniNalog int primary key identity,
VozacID int foreign key References tblVozac(IDVozac),
VoziloID int foreign key References tblVozilo(IDVozilo),
StartGrad nvarchar(50),
StopGrad nvarchar(50),
StartDate Date,
StopDate Date,
);
GO
Create Proc SelectAllWarrants
as
Select * FROM tblPutniNalog;

GO


Create Proc FindVozacById @pID int
as
Select * from tblVozac where IDVozac=@pID

GO
Create Proc FindVoziloById @pID int
as
Select * from tblVozilo where IDVozilo=@pID
GO

GO

Create Proc WarrantCreate @pVozacID int, @pVoziloID int,@pStartGrad nvarchar(50),@pStopGrad nvarchar(50),@pStartDate Date,@pStopDate Date
as
Insert into tblPutniNalog(VozacID,VoziloID,StartGrad,StopGrad,StartDate,StopDate)
Values(@pVozacID,@pVoziloID,@pStartGrad,@pStopGrad,@pStartDate,@pStopDate)
GO

Create PROCEDURE DeleteWarrant @pID int
as
DELETE FROM tblPutniNalog
Where IDPutniNalog=@pID
GO


Create PROCEDURE UpdateWarrant @pID int,@pVozacID int, @pVoziloID int,@pStartGrad nvarchar(50),@pStopGrad nvarchar(50),@pStartDate Date,@pStopDate Date
as
UPDATE tblPutniNalog
SET VoziloID=@pVoziloID,VozacID=@pVozacID,StartGrad=@pStartGrad,StopGrad=@pStopGrad,StartDate=@pStartDate,StopDate=@pStopDate
Where IDPutniNalog=@pID

GO

Create PROCEDURE FindWarrantByID @pID int
as
Select * from tblPutniNalog Where IDPutniNalog=@pID

GO


Create TABLE tblKupnjaGoriva(
IDKupnjaGoriva int primary key identity,
PutniNalogID int foreign key references tblPutniNalog(IDPutniNalog),
Lokacija nvarchar(100),
GorivoPoLitri float,
CijenaPoLitri float
)
GO




GO

CREATE TABLE tblRuta(
IDRuta int primary key identity,
PutniNalogID int foreign key references tblPutniNalog(IDPutniNalog),
Vrijeme datetime,
ACoordX int,
ACoordY int,
BCoordX int,
BCoordY int,
PrijedeniKM float,
ProsjecniKMH float,
PotrosenoGorivoLitre float,

)



GO

CREATE PROC SelectAllFuelBuying
As
Begin
Select * from tblKupnjaGoriva
End

Go

Create Proc CreateFuelBuying @pPutniNalogID int, @pLokacija nvarchar(100),@pGorivoPoLitri float,@pCijenaPoLitri float
as
Insert into tblKupnjaGoriva(PutniNalogID, Lokacija, GorivoPoLitri, CijenaPoLitri)
Values(@pPutniNalogID,@pLokacija,@pGorivoPoLitri,@pCijenaPoLitri)
GO

Create PROCEDURE DeleteFuelBuying @pID int
as
DELETE FROM tblKupnjaGoriva
Where IDKupnjaGoriva=@pID
GO


Create PROCEDURE UpdateFuelBuying @pID int,@pPutniNalogID int, @pLokacija nvarchar(100),@pGorivoPoLitri float,@pCijenaPoLitri float
as
UPDATE tblKupnjaGoriva
SET PutniNalogID=@pPutniNalogID, Lokacija=@pLokacija,GorivoPoLitri = @pGorivoPoLitri, CijenaPoLitri = @pCijenaPoLitri
Where IDKupnjaGoriva=@pID

GO

Create PROCEDURE FindFuelBuyingByID @pID int
as
Select * from tblKupnjaGoriva Where IDKupnjaGoriva=@pID

GO




CREATE PROC SelectAllRoutes
As
Begin
Select * from tblRuta
End

Go

Create Proc CreateRoute @pPutniNalogID int,@pVrijeme datetime, @pACoordX int, @pACoordY int, @pBCoordX int, @pBCoordY int, @pPrijedeniKM float, @pProsjecniKMH float, @pPotrosenoGorivoLitre float
as
Insert into tblRuta(PutniNalogID, Vrijeme, ACoordX, ACoordY, BCoordX, BCoordY, PrijedeniKM, ProsjecniKMH, PotrosenoGorivoLitre)
Values(@pPutniNalogID,@pVrijeme,@pACoordX,@pACoordY,@pBCoordX,@pBCoordY,@pPrijedeniKM,@pProsjecniKMH,@pPotrosenoGorivoLitre)
GO

Create PROCEDURE DeleteRoute @pID int
as
DELETE FROM tblRuta
Where IDRuta=@pID
GO


Create PROCEDURE UpdateRoute @pID int,@pPutniNalogID int,@pVrijeme datetime, @pACoordX int, @pACoordY int, @pBCoordX int, @pBCoordY int, @pPrijedeniKM float, @pProsjecniKMH float, @pPotrosenoGorivoLitre float
as
UPDATE tblRuta
SET PutniNalogID=@pPutniNalogID, Vrijeme=@pVrijeme,ACoordX = @pACoordX, ACoordY = @pACoordY, BCoordX= @pBCoordX,BCoordY =@pBCoordY,PrijedeniKM =@pPrijedeniKM,ProsjecniKMH = @pProsjecniKMH, PotrosenoGorivoLitre=@pPotrosenoGorivoLitre
Where IDRuta=@pID

GO

Create PROCEDURE FindRoute @pID int
as
Select * from tblRuta Where IDRuta=@pID

GO



CREATE PROCEDURE emptyDB
as
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' 
EXEC sp_MSForEachTable 'DELETE FROM ?' 

-- enable referential integrity again 
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL' 
EXEC sp_MSForEachTable 'DBCC CHECKIDENT(''?'', RESEED, 0)'

GO

CREATE PROCEDURE EnableIDInsert
as
EXEC sp_MSForEachTable 'SET IDENTITY_INSERT ? ON'
GO

CREATE PROCEDURE DisableIDInsert
as
EXEC sp_MSForEachTable 'SET IDENTITY_INSERT ? OFF'
GO


Create table tblServisStavka(
IDServisStavka int primary key identity,
Naziv nvarchar(50)
)
-------------------
GO

CREATE PROC SelectServisStavka
As
Begin
Select * from tblServisStavka
End

Go

Create Proc CreateServisStavka @pNaziv nvarchar(50)
as
Insert into tblServisStavka(Naziv)
Values(@pNaziv)
GO


Create PROCEDURE DeleteServisStavka @pID int
as
DELETE FROM tblServisStavka
Where IDServisStavka=@pID
GO


Create PROCEDURE UpdateServisStavka @pID int,@pNaziv nvarchar(50)
as
UPDATE tblServisStavka
SET Naziv=@pNaziv
Where IDServisStavka=@pID

GO

Create PROCEDURE FindServisStavka @pID int
as
Select * from tblServisStavka Where IDServisStavka=@pID

GO
--------------


Create table tblServis(
IDServis int primary key identity,
VoziloID int foreign key references tblVozilo(IDVozilo),
ServisStavkaID int foreign key references tblServisStavka(IDServisStavka),

Datum date,
Naziv nvarchar(50),
Opis nvarchar(250),
Cijena float
)
GO



CREATE PROC SelectServis
As
Begin
Select * from tblServis
End

Go

Create Proc CreateServis @pVoziloID int,@pServisStavkaID int, @pDatum date, @pNaziv nvarchar(50),@pOpis nvarchar(250),@pCijena float
as
Insert into tblServis(VoziloID, ServisStavkaID, Datum, Naziv, Opis, Cijena)
Values(@pVoziloID,@pServisStavkaID,@pDatum , @pNaziv ,@pOpis ,@pCijena )
GO


Create PROCEDURE DeleteServis @pID int
as
DELETE FROM tblServis
Where IDServis=@pID
GO


Create PROCEDURE UpdateServis @pID int, @pVoziloID int,@pServisStavkaID int, @pDatum date, @pNaziv nvarchar(50),@pOpis nvarchar(250),@pCijena float
as
UPDATE tblServis
SET VoziloID=@pVoziloID,ServisStavkaID=@pServisStavkaID, Datum=@pDatum,Naziv=@pNaziv, Opis= @pOpis, Cijena=@pCijena
Where IDServis=@pID

GO

Create PROCEDURE FindServis @pID int
as
Select * from tblServis Where IDServis=@pID


