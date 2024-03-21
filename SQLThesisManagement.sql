-- CREATE DATABASE
create database ThesisManagement
go
-- Data Source=DESKTOP-4FIVTNT\SQLEXPRESS;Initial Catalog=ThesisManagement;Integrated Security=True;Encrypt=False
use ThesisManagement
go

-- CREATE TABLE
create table Account (
    idaccount nvarchar(50) primary key not null,
    fullname nvarchar(100) not null,
    citizencode nvarchar(20) not null,
    birthday datetime not null,
    gender nvarchar(10) not null,
    email nvarchar(100) not null,
    phonenumber nvarchar(20) not null,
    handle nvarchar(50) not null,
    role nvarchar(20) not null,
    university nvarchar(100) not null,
    faculty nvarchar(100) not null,
    workcode nvarchar(20) not null,
    password nvarchar(100) not null
);
-- drop table Account

create table Thesis (
    idthesis nvarchar(50) primary key not null,
    topic text not null,
    field nvarchar(100) not null,
    tslevel nvarchar(20) not null,
    maxmembers int not null,
    description text not null,
    reference nvarchar(255) not null,
    publishdate datetime not null,
    technology text not null,
    functions text not null,
    requirements text not null,
	idcreator nvarchar(50) not null default '221100001',
	isfavorite bit not null default 0,
	pending int not null default 0,
	accepted int not null default 0,
	completed int not null default 0
);
alter table Thesis
add idcreator nvarchar(50) not null default '221100001';
alter table Thesis
add isfavorite bit not null default 0,
	pending int not null default 0,
	accepted int not null default 0,
	completed int not null default 0;

create table ThesisStatus
(
	idaccount nvarchar(50) not null,
	idthesis nvarchar(50) not null,
	sta nvarchar(20) not null
)

--- WORK SPACE
 select *
 from Thesis 
 where idthesis = '244400001'

UPDATE Thesis
SET isfavorite = 1
WHERE idthesis IN ('244400003', '244400005', '244400007', '244400009', '244400011', '244400013', '244400015', '244400017', 
				   '244400019', '244400021', '244400023', '244400025', '244400027', '244400029');

ALTER TABLE Thesis
ALTER COLUMN reference nvarchar(255);

---

-- RENAME COLUM
-- EXEC sp_rename 'Thesis.level', 'tslevel', 'COLUMN';

-- DELETE ALL RECORD
-- delete from Account

-- CREATE DATABASE FOR TABLE

-- INSERT Lecture
-- delete from Account where role = 'Lecture'
-- update Account set password = 'abc123' where role = 'Lecture'

-- Lecture 1 - 10
INSERT INTO Account
VALUES 
    ('242200001', 'David Lee', '072352117212', '1995-03-15', 'Male', 'david@gmail.com', '0375676599', 'DavidL', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5373538693', 'abc123'),
    ('242200002', 'Alice Johnson', '095216398243', '1994-08-22', 'Female', 'alice@gmail.com', '0652145893', 'AliceJ', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236492347', 'xyz456'),
    ('242200003', 'John Smith', '093578641325', '1996-12-10', 'Male', 'john@gmail.com', '0845763214', 'JohnS', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325678942', 'qwerty'),
    ('242200004', 'Emily Brown', '086547932156', '1993-05-29', 'Female', 'emily@gmail.com', '0213546879', 'EmilyB', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287651293', 'pass123'),
    ('242200005', 'Michael Davis', '073859216843', '1997-09-17', 'Male', 'michael@gmail.com', '0397546821', 'MichaelD', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'secure789'),
    ('242200006', 'Sophia Taylor', '094621837595', '1992-11-05', 'Female', 'sophia@gmail.com', '0874651239', 'SophiaT', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'passpass'),
    ('242200007', 'William Clark', '085239614780', '1998-02-25', 'Male', 'william@gmail.com', '0987543210', 'WilliamC', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('242200008', 'Olivia Martinez', '092763514789', '1991-07-08', 'Female', 'olivia@gmail.com', '0239654781', 'OliviaM', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('242200009', 'Daniel Anderson', '083715932641', '1999-04-12', 'Male', 'daniel@gmail.com', '0946582713', 'DanielA', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('242200010', 'Isabella Wilson', '096347812530', '1990-10-03', 'Female', 'isabella@gmail.com', '0357894216', 'IsabellaW', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- Lecture 11 - 20
INSERT INTO Account
VALUES 
    ('242200011', 'Sophie Turner', '095216398243', '1995-03-15', 'Female', 'sophie@gmail.com', '0976543210', 'SophieT', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5373538693', 'abc123'),
    ('242200012', 'James Smith', '093578641325', '1994-08-22', 'Male', 'james@gmail.com', '0987654321', 'JamesS', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236492347', 'xyz456'),
    ('242200013', 'Emma Watson', '086547932156', '1996-12-10', 'Female', 'emma@gmail.com', '0123456789', 'EmmaW', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325678942', 'qwerty'),
    ('242200014', 'Ryan Reynolds', '073859216843', '1993-05-29', 'Male', 'ryan@gmail.com', '0987654321', 'RyanR', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287651293', 'pass123'),
    ('242200015', 'Natalie Portman', '094621837595', '1997-09-17', 'Female', 'natalie@gmail.com', '0123456789', 'NatalieP', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'secure789'),
    ('242200016', 'Chris Hemsworth', '085239614780', '1992-11-05', 'Male', 'chris@gmail.com', '0987654321', 'ChrisH', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'passpass'),
    ('242200017', 'Jennifer Lawrence', '092763514789', '1998-02-25', 'Female', 'jennifer@gmail.com', '0123456789', 'JenniferL', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('242200018', 'Brad Pitt', '083715932641', '1991-07-08', 'Male', 'brad@gmail.com', '0987654321', 'BradP', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('242200019', 'Angelina Jolie', '096347812530', '1999-04-12', 'Female', 'angelina@gmail.com', '0123456789', 'AngelinaJ', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('242200020', 'Leonardo DiCaprio', '096347812530', '1990-10-03', 'Male', 'leonardo@gmail.com', '0987654321', 'LeonardoD', 'Lecture', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- INSERT Student
-- delete from Account where role = 'Student'
-- update Account set password = '123abc' where role = 'Student'

-- Student 1 - 10
INSERT INTO Account
VALUES 
    ('243300001', 'Emma Watson', '093482139832', '2003-03-15', 'Female', 'emma@gmail.com', '0976523421', 'EmmaW', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'pass123'),
    ('243300002', 'Chris Evans', '096321587439', '2002-08-22', 'Male', 'chris@gmail.com', '0654321987', 'ChrisE', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'xyz456'),
    ('243300003', 'Scarlett Johansson', '093654827615', '2004-12-10', 'Female', 'scarlett@gmail.com', '0845672310', 'ScarlettJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'qwerty'),
    ('243300004', 'Tom Holland', '096527384519', '2003-05-29', 'Male', 'tom@gmail.com', '0213546789', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'secure789'),
    ('243300005', 'Zendaya', '093741258639', '2003-09-17', 'Female', 'zendaya@gmail.com', '0397546821', 'Zendaya', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'passpass'),
    ('243300006', 'Robert Downey Jr.', '096374815236', '2002-11-05', 'Male', 'robert@gmail.com', '0874651239', 'RobertDJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'pass123'),
    ('243300007', 'Gal Gadot', '095261398712', '2004-02-25', 'Female', 'gal@gmail.com', '0987543210', 'GalG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('243300008', 'Chris Pratt', '093658274916', '2001-07-08', 'Male', 'chrisp@gmail.com', '0239654781', 'ChrisP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('243300009', 'Brie Larson', '096347819520', '2003-04-12', 'Female', 'brie@gmail.com', '0946582713', 'BrieL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('243300010', 'Tom Hiddleston', '096347812530', '2002-10-03', 'Male', 'tomh@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- Student 11 - 20
INSERT INTO Account
VALUES 
    ('243300011', 'Natalie Portman', '093482139832', '2000-03-15', 'Female', 'natalie.portman@gmail.com', '0976523421', 'NatalieP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'pass123'),
    ('243300012', 'Brad Pitt', '096321587439', '2001-08-22', 'Male', 'brad.pitt@gmail.com', '0654321987', 'BradP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'xyz456'),
    ('243300013', 'Angelina Jolie', '093654827615', '2003-12-10', 'Female', 'angelina.jolie@gmail.com', '0845672310', 'AngelinaJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'qwerty'),
    ('243300014', 'Leonardo DiCaprio', '096527384519', '2000-05-29', 'Male', 'leonardo.dicaprio@gmail.com', '0213546789', 'LeonardoD', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'secure789'),
    ('243300015', 'Emma Watson', '093741258639', '2000-09-17', 'Female', 'emma.watson@gmail.com', '0397546821', 'EmmaW', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'passpass'),
    ('243300016', 'Chris Hemsworth', '096374815236', '2001-11-05', 'Male', 'chris.hemsworth@gmail.com', '0874651239', 'ChrisH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'pass123'),
    ('243300017', 'Jennifer Lawrence', '095261398712', '2003-02-25', 'Female', 'jennifer.lawrence@gmail.com', '0987543210', 'JenniferL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('243300018', 'Matthew McConaughey', '093658274916', '2002-07-08', 'Male', 'matthew.mcconaughey@gmail.com', '0239654781', 'MatthewMc', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('243300019', 'Brie Larson', '096347819520', '2001-04-12', 'Female', 'brie.larson@gmail.com', '0946582713', 'BrieL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('243300020', 'Tom Hiddleston', '096347812530', '2000-10-03', 'Male', 'tom.hiddleston@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- Student 20 - 30
INSERT INTO Account
VALUES 
    ('243300021', 'Emma Stone', '093482139832', '2000-03-15', 'Female', 'emma.stone@gmail.com', '0976523421', 'EmmaS', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'pass123'),
    ('243300022', 'Tom Cruise', '096321587439', '2001-08-22', 'Male', 'tom.cruise@gmail.com', '0654321987', 'TomC', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'xyz456'),
    ('243300023', 'Jennifer Aniston', '093654827615', '2003-12-10', 'Female', 'jennifer.aniston@gmail.com', '0845672310', 'JenniferA', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'qwerty'),
    ('243300024', 'Chris Pine', '096527384519', '2000-05-29', 'Male', 'chris.pine@gmail.com', '0213546789', 'ChrisP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'secure789'),
    ('243300025', 'Emma Roberts', '093741258639', '2000-09-17', 'Female', 'emma.roberts@gmail.com', '0397546821', 'EmmaR', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'passpass'),
    ('243300026', 'Jake Gyllenhaal', '096374815236', '2001-11-05', 'Male', 'jake.gyllenhaal@gmail.com', '0874651239', 'JakeG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'pass123'),
    ('243300027', 'Jennifer Garner', '095261398712', '2003-02-25', 'Female', 'jennifer.garner@gmail.com', '0987543210', 'JenniferG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('243300028', 'Matthew McConaughey', '093658274916', '2002-07-08', 'Male', 'matthew.mcconaughey@gmail.com', '0239654781', 'MatthewMc', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('243300029', 'Brie Larson', '096347819520', '2001-04-12', 'Female', 'brie.larson@gmail.com', '0946582713', 'BrieL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('243300030', 'Tom Hiddleston', '096347812530', '2000-10-03', 'Male', 'tom.hiddleston@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- Student 30 - 40
INSERT INTO Account
VALUES 
    ('243300031', 'Scarlett Johansson', '093482139832', '2000-03-15', 'Female', 'scarlett.johansson@gmail.com', '0976523421', 'ScarlettJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'pass123'),
    ('243300032', 'Chris Evans', '096321587439', '2001-08-22', 'Male', 'chris.evans@gmail.com', '0654321987', 'ChrisE', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'xyz456'),
    ('243300033', 'Margot Robbie', '093654827615', '2003-12-10', 'Female', 'margot.robbie@gmail.com', '0845672310', 'MargotR', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'qwerty'),
    ('243300034', 'Robert Downey Jr.', '096527384519', '2000-05-29', 'Male', 'robert.downey@gmail.com', '0213546789', 'RobertDJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'secure789'),
    ('243300035', 'Gal Gadot', '093741258639', '2000-09-17', 'Female', 'gal.gadot@gmail.com', '0397546821', 'GalG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'passpass'),
    ('243300036', 'Chris Pratt', '096374815236', '2001-11-05', 'Male', 'chris.pratt@gmail.com', '0874651239', 'ChrisP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'pass123'),
    ('243300037', 'Emma Stone', '095261398712', '2003-02-25', 'Female', 'emma.stone2@gmail.com', '0987543210', 'EmmaS2', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('243300038', 'Tom Hardy', '093658274916', '2002-07-08', 'Male', 'tom.hardy@gmail.com', '0239654781', 'TomH2', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('243300039', 'Zendaya', '096347819520', '2001-04-12', 'Female', 'zendaya@gmail.com', '0946582713', 'Zendaya', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('243300040', 'Tom Holland', '096347812530', '2000-10-03', 'Male', 'tom.holland@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- Student 40 - 50
INSERT INTO Account
VALUES 
    ('243300041', 'Emma Watson', '093482139832', '2000-03-15', 'Female', 'emma.watson@gmail.com', '0976523421', 'EmmaW', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'pass123'),
    ('243300042', 'Tom Cruise', '096321587439', '2001-08-22', 'Male', 'tom.cruise@gmail.com', '0654321987', 'TomC', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'xyz456'),
    ('243300043', 'Jennifer Aniston', '093654827615', '2003-12-10', 'Female', 'jennifer.aniston@gmail.com', '0845672310', 'JenniferA', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'qwerty'),
    ('243300044', 'Chris Pine', '096527384519', '2000-05-29', 'Male', 'chris.pine@gmail.com', '0213546789', 'ChrisP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'secure789'),
    ('243300045', 'Emma Roberts', '093741258639', '2000-09-17', 'Female', 'emma.roberts@gmail.com', '0397546821', 'EmmaR', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'passpass'),
    ('243300046', 'Jake Gyllenhaal', '096374815236', '2001-11-05', 'Male', 'jake.gyllenhaal@gmail.com', '0874651239', 'JakeG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'pass123'),
    ('243300047', 'Jennifer Garner', '095261398712', '2003-02-25', 'Female', 'jennifer.garner@gmail.com', '0987543210', 'JenniferG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('243300048', 'Matthew McConaughey', '093658274916', '2002-07-08', 'Male', 'matthew.mcconaughey@gmail.com', '0239654781', 'MatthewMc', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('243300049', 'Brie Larson', '096347819520', '2001-04-12', 'Female', 'brie.larson@gmail.com', '0946582713', 'BrieL', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('243300050', 'Tom Hiddleston', '096347812530', '2000-10-03', 'Male', 'tom.hiddleston@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- Student 50 - 60
INSERT INTO Account
VALUES 
    ('243300051', 'Scarlett Johansson', '093482139832', '2000-03-15', 'Female', 'scarlett.johansson@gmail.com', '0976523421', 'ScarlettJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5372535694', 'pass123'),
    ('243300052', 'Chris Evans', '096321587439', '2001-08-22', 'Male', 'chris.evans@gmail.com', '0654321987', 'ChrisE', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9236754210', 'xyz456'),
    ('243300053', 'Margot Robbie', '093654827615', '2003-12-10', 'Female', 'margot.robbie@gmail.com', '0845672310', 'MargotR', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '1325647892', 'qwerty'),
    ('243300054', 'Robert Downey Jr.', '096527384519', '2000-05-29', 'Male', 'robert.downey@gmail.com', '0213546789', 'RobertDJ', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '4287396152', 'secure789'),
    ('243300055', 'Gal Gadot', '093741258639', '2000-09-17', 'Female', 'gal.gadot@gmail.com', '0397546821', 'GalG', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9284756123', 'passpass'),
    ('243300056', 'Chris Pratt', '096374815236', '2001-11-05', 'Male', 'chris.pratt@gmail.com', '0874651239', 'ChrisP', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3547829101', 'pass123'),
    ('243300057', 'Emma Stone', '095261398712', '2003-02-25', 'Female', 'emma.stone2@gmail.com', '0987543210', 'EmmaS2', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '9134678251', 'abcxyz'),
    ('243300058', 'Tom Hardy', '093658274916', '2002-07-08', 'Male', 'tom.hardy@gmail.com', '0239654781', 'TomH2', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '7391856420', 'password'),
    ('243300059', 'Zendaya', '096347819520', '2001-04-12', 'Female', 'zendaya@gmail.com', '0946582713', 'Zendaya', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '5281479632', 'abc123xyz'),
    ('243300060', 'Tom Holland', '096347812530', '2000-10-03', 'Male', 'tom.holland@gmail.com', '0357894216', 'TomH', 'Student', 
     'HCM City University of Technology and Education', 'Faculty of Information Technology', '3948572160', 'passpass123');

-- INSERT Thesis
-- delete from Thesis where idthesis
-- update Thesis set maxmembers = 5 where ...

-- Thesis 1
INSERT INTO Thesis 
VALUES ('244400001', 
        'Building a model for applying information technology to serve the development of agriculture and rural industry', 
        'SoftwareDevelopment', 
        'Medium', 
        5, 
        'Building an information technology model to optimize agricultural management and development, enhancing production efficiency, service provision, and sustainable development in rural areas.', 
        'reference.txt', 
        '2024-03-15 19:30:45', 
        'Technologies include Artificial Intelligence, IoT, Blockchain, Big Data, and Machine Learning for production processes and resource management.', 
        'Functions include weather monitoring, crop management, sensor data recording, yield prediction, schedule and resource management, and farmer-market connectivity.', 
        'Requirements: Agricultural knowledge, programming skills, understanding of AI and data analysis, logical thinking, and creativity in technology application in agriculture.',
		'241100001', 1, 0, 0, 0);

-- Thesis 2
INSERT INTO Thesis 
VALUES ('244400002', 
        'Developing an AI-powered system for cybersecurity threat detection and prevention', 
        'Cybersecurity', 
        'Difficult', 
        7, 
        'Creating an advanced AI system to detect and prevent cybersecurity threats in real-time, providing robust protection for sensitive data and networks.', 
        'reference.txt', 
        '2024-03-14 14:45:30', 
        'Technologies include Machine Learning, Deep Learning, Natural Language Processing, and Pattern Recognition for analyzing network traffic and identifying potential threats.', 
        'Functions include anomaly detection, intrusion detection, malware analysis, threat intelligence integration, and automated response mechanisms.', 
        'Requirements: Strong understanding of cybersecurity principles, programming expertise in Python or Java, familiarity with network protocols and security tools, and analytical skills.',
		'241100001', 0, 0, 0, 0);

-- Thesis 3
INSERT INTO Thesis 
VALUES ('244400003', 
        'Utilizing data science techniques for predictive maintenance in manufacturing industries', 
        'DataScienceAndAnalytics', 
        'Medium', 
        4, 
        'Implementing data science methods to predict machinery failures and optimize maintenance schedules in manufacturing plants, reducing downtime and improving productivity.', 
        'reference.txt', 
        '2024-03-13 10:20:15', 
        'Technologies include Predictive Analytics, Machine Learning, Data Visualization, and Time Series Analysis for analyzing equipment sensor data and predicting maintenance needs.', 
        'Functions include data preprocessing, model training, feature selection, anomaly detection, and maintenance schedule optimization.', 
        'Requirements: Understanding of manufacturing processes, proficiency in data analysis tools like Python or R, knowledge of statistical techniques, and familiarity with industrial sensors and IoT.',
		'241100001', 1, 0, 0, 0);

-- Thesis 4
INSERT INTO Thesis 
VALUES ('244400004', 
        'Developing a chatbot using artificial intelligence for customer service', 
        'ArtificialIntelligenceAndMachineLearning', 
        'Easy', 
        3, 
        'Creating an AI-powered chatbot to handle customer inquiries, provide assistance, and streamline customer service operations for businesses.', 
        'reference.txt', 
        '2024-03-12 08:55:10', 
        'Technologies include Natural Language Processing, Machine Learning algorithms, and Chatbot frameworks for understanding user queries and generating appropriate responses.', 
        'Functions include intent recognition, context handling, response generation, and integration with backend systems.', 
        'Requirements: Proficiency in NLP libraries like NLTK or spaCy, experience in building chatbots using frameworks like Dialogflow or Rasa, and knowledge of RESTful APIs for backend integration.',
		'241100001', 0, 0, 0, 0);

-- Thesis 5
INSERT INTO Thesis 
VALUES ('244400005', 
        'Implementing cloud computing solutions for efficient data storage and processing', 
        'CloudComputing', 
        'Medium', 
        6, 
        'Deploying cloud-based infrastructure for storing and processing large volumes of data, ensuring scalability, reliability, and cost-effectiveness for businesses.', 
        'reference.txt', 
        '2024-03-11 12:30:25', 
        'Technologies include AWS, Azure, Google Cloud Platform, and Kubernetes for building scalable and resilient cloud architectures.', 
        'Functions include data migration, cluster management, performance optimization, security configuration, and cost monitoring.', 
        'Requirements: Familiarity with cloud platforms, experience in deploying and managing cloud services, understanding of networking and security principles, and knowledge of DevOps practices.',
		'241100001', 1, 0, 0, 0);

-- Thesis 6
INSERT INTO Thesis 
VALUES ('244400006', 
        'Creating IoT applications for smart energy management in buildings', 
        'InternetOfThings', 
        'Medium', 
        5, 
        'Developing IoT-based solutions to optimize energy consumption, monitor equipment performance, and automate energy-saving processes in residential and commercial buildings.', 
        'reference.txt', 
        '2024-03-10 15:20:40', 
        'Technologies include Arduino, Raspberry Pi, MQTT, and Zigbee for building IoT devices and communication protocols.', 
        'Functions include sensor integration, real-time data processing, energy usage analysis, automated control systems, and user interface design for energy monitoring.', 
        'Requirements: Knowledge of IoT protocols and platforms, proficiency in hardware programming, experience in energy management systems, and understanding of building automation principles.',
		'241100001', 0, 0, 0, 0);

-- Thesis 7
INSERT INTO Thesis 
VALUES ('244400007', 
        'Developing mobile applications for remote healthcare monitoring', 
        'MobileDevelopment', 
        'Medium', 
        4, 
        'Designing mobile apps to remotely monitor patients health status, track medication adherence, and facilitate communication between healthcare providers and patients.', 
        'reference.txt', 
        '2024-03-09 18:10:55', 
        'Technologies include Android Studio, Swift, Firebase, and HealthKit for building cross-platform mobile applications with health monitoring features.', 
        'Functions include user authentication, data encryption, real-time health data synchronization, medication reminders, and emergency alert systems.', 
        'Requirements: Proficiency in mobile app development frameworks, knowledge of healthcare regulations, experience in HIPAA compliance, and understanding of medical data privacy.',
		'241100001', 1, 0, 0, 0);

-- Thesis 8
INSERT INTO Thesis 
VALUES ('244400008', 
        'Developing responsive web interfaces for online education platforms', 
        'WebDevelopment', 
        'Medium', 
        6, 
        'Creating user-friendly web interfaces for online learning platforms, ensuring accessibility, interactivity, and engagement for learners of all ages.', 
        'reference.txt', 
        '2024-03-08 09:40:20', 
        'Technologies include HTML5, CSS3, JavaScript, React, and Node.js for building modern, responsive web interfaces and interactive learning modules.', 
        'Functions include frontend development, UI/UX design, content management, gamification features, and integration with learning management systems.', 
        'Requirements: Proficiency in web development technologies, understanding of educational principles, experience in UX/UI design, and familiarity with e-learning standards.',
		'241100001', 0, 0, 0, 0);

-- Thesis 9
INSERT INTO Thesis 
VALUES ('244400009', 
        'Exploring the potential of blockchain technology for supply chain transparency', 
        'BlockchainTechnology', 
        'Difficult', 
        8, 
        'Investigating how blockchain can enhance supply chain transparency, traceability, and accountability, improving trust and efficiency in global supply networks.', 
        'reference.txt', 
        '2024-03-07 11:50:35', 
        'Technologies include Ethereum, Hyperledger Fabric, and Solidity for building decentralized applications and smart contracts to track and verify supply chain transactions.', 
        'Functions include blockchain architecture design, smart contract development, consensus mechanism implementation, and integration with existing supply chain systems.', 
        'Requirements: Understanding of blockchain principles, proficiency in smart contract programming, knowledge of supply chain management, and familiarity with cryptographic techniques.',
		'241100001', 1, 0, 0, 0);

-- Thesis 10
INSERT INTO Thesis 
VALUES ('244400010', 
        'Advancing human-computer interaction through augmented reality interfaces', 
        'HumanComputerInteraction', 
        'Medium', 
        5, 
        'Exploring novel ways to interact with computers using augmented reality interfaces, enhancing user experience and productivity in various domains such as gaming, education, and healthcare.', 
        'reference.txt', 
        '2024-03-06 14:25:50', 
        'Technologies include Unity3D, ARKit, ARCore, and Vuforia for developing immersive AR experiences and intuitive user interfaces for AR applications.', 
        'Functions include gesture recognition, object tracking, spatial mapping, user feedback analysis, and usability testing for AR interfaces.', 
        'Requirements: Proficiency in AR development frameworks, understanding of human-centered design principles, experience in UI/UX design, and creativity in AR content creation.',
		'241100001', 0, 0, 0, 0);

-- Thesis 11
INSERT INTO Thesis 
VALUES ('244400011', 
        'Analyzing big data for personalized healthcare recommendations', 
        'Big Data', 
        'Difficult', 
        7, 
        'Utilizing big data analytics to analyze patient health data, identify patterns, and provide personalized healthcare recommendations for disease prevention and management.', 
        'reference.txt', 
        '2024-03-05 16:55:30', 
        'Technologies include Hadoop, Spark, Python, and Apache Kafka for processing and analyzing large volumes of healthcare data from various sources.', 
        'Functions include data preprocessing, feature extraction, predictive modeling, patient segmentation, and recommendation system development.', 
        'Requirements: Proficiency in big data technologies, understanding of healthcare data standards, experience in machine learning algorithms, and knowledge of medical terminology.');

-- Thesis 12
INSERT INTO Thesis 
VALUES ('244400012', 
        'Exploring the potential of quantum computing in cryptography', 
        'Quantum Computing', 
        'Difficult', 
        6, 
        'Investigating the applications of quantum computing in cryptographic algorithms and protocols, exploring quantum-resistant cryptography for secure communication and data protection.', 
        'reference.txt', 
        '2024-03-04 09:15:25', 
        'Technologies include Qiskit, Microsoft Q#, and IBM Quantum Experience for developing quantum algorithms and simulating quantum computations.', 
        'Functions include quantum algorithm design, quantum error correction, post-quantum cryptography analysis, and quantum key distribution protocols.', 
        'Requirements: Understanding of quantum computing principles, proficiency in quantum programming languages, knowledge of cryptography fundamentals, and familiarity with quantum hardware.');

-- Thesis 13
INSERT INTO Thesis 
VALUES ('244400013', 
        'Developing immersive virtual reality simulations for training medical professionals', 
        'Virtual Reality (VR) and Augmented Reality (AR)', 
        'Medium', 
        5, 
        'Creating VR simulations to provide realistic medical training scenarios for healthcare professionals, enhancing their skills, decision-making, and patient care abilities.', 
        'reference.txt', 
        '2024-03-03 11:40:20', 
        'Technologies include Unity3D, Oculus Rift, HTC Vive, and Unreal Engine for building immersive VR environments and interactive medical simulations.', 
        'Functions include scenario design, 3D modeling, user interaction design, physiological feedback integration, and performance assessment in medical VR applications.', 
        'Requirements: Proficiency in VR development tools, understanding of medical procedures, experience in 3D modeling, and knowledge of human anatomy.');

-- Thesis 14
INSERT INTO Thesis 
VALUES ('244400014', 
        'Enhancing user experience in e-commerce through AI-powered recommendation systems', 
        'Artificial Intelligence and Machine Learning', 
        'Medium', 
        6, 
        'Improving user engagement and sales conversion rates in e-commerce platforms by implementing AI-driven recommendation engines to suggest personalized products and content.', 
        'reference.txt', 
        '2024-03-02 14:30:15', 
        'Technologies include Collaborative Filtering, Content-Based Filtering, and Hybrid Recommender Systems for analyzing user preferences and generating personalized recommendations.', 
        'Functions include data preprocessing, model training, recommendation algorithm optimization, A/B testing, and performance evaluation of recommendation systems.', 
        'Requirements: Proficiency in machine learning algorithms, understanding of e-commerce dynamics, experience in recommendation system development, and knowledge of user behavior analysis.');

-- Thesis 15
INSERT INTO Thesis 
VALUES ('244400015', 
        'Applying bioinformatics methods for genomic analysis in cancer research', 
        'Bioinformatics', 
        'Difficult', 
        7, 
        'Utilizing bioinformatics tools and techniques to analyze genomic data, identify cancer biomarkers, and understand the molecular mechanisms underlying cancer development and progression.', 
        'reference.txt', 
        '2024-03-01 16:20:10', 
        'Technologies include Bioconductor, BLAST, Python, and R for processing and analyzing biological data, performing sequence alignment, and predicting gene mutations.', 
        'Functions include data mining, sequence analysis, pathway mapping, variant calling, and statistical analysis of genomic datasets in cancer bioinformatics research.', 
        'Requirements: Proficiency in bioinformatics software, understanding of cancer biology, experience in genomic data analysis, and knowledge of statistical methods for biological research.');

-- Thesis 16
INSERT INTO Thesis 
VALUES ('244400016', 
        'Developing a machine learning model for predicting stock prices', 
        'Data Science and Analytics', 
        'Medium', 
        5, 
        'Building a predictive model using machine learning algorithms to forecast stock prices and identify profitable investment opportunities in financial markets.', 
        'reference.txt', 
        '2024-02-29 09:45:55', 
        'Technologies include Python, TensorFlow, Keras, and Pandas for data preprocessing, feature engineering, and training predictive models based on historical stock data.', 
        'Functions include data collection, model training, backtesting, performance evaluation, and deployment of stock prediction algorithms.', 
        'Requirements: Proficiency in machine learning techniques, understanding of financial markets, experience in quantitative analysis, and knowledge of time series forecasting.');

-- Thesis 17
INSERT INTO Thesis 
VALUES ('244400017', 
        'Exploring the applications of AI in autonomous vehicle navigation', 
        'Artificial Intelligence and Machine Learning', 
        'Difficult', 
        7, 
        'Investigating AI-driven technologies for autonomous vehicle navigation, including perception systems, decision-making algorithms, and sensor fusion techniques.', 
        'reference.txt', 
        '2024-02-28 11:30:40', 
        'Technologies include Convolutional Neural Networks (CNNs), Reinforcement Learning, and LIDAR for enabling real-time object detection, path planning, and environment mapping in autonomous vehicles.', 
        'Functions include algorithm design, simulation testing, data labeling, sensor calibration, and performance optimization of AI-based navigation systems.', 
        'Requirements: Proficiency in AI/ML algorithms, understanding of robotics principles, experience in sensor fusion, and knowledge of autonomous vehicle technologies.');

-- Thesis 18
INSERT INTO Thesis 
VALUES ('244400018', 
        'Developing scalable IoT solutions for smart city infrastructure', 
        'Internet of Things (IoT)', 
        'Medium', 
        6, 
        'Designing IoT-based solutions to enhance urban infrastructure management, including smart traffic systems, environmental monitoring, and energy-efficient utilities.', 
        'reference.txt', 
        '2024-02-27 14:20:25', 
        'Technologies include LoRaWAN, MQTT, and Edge Computing for building scalable IoT networks, collecting sensor data, and implementing real-time control mechanisms in smart city applications.', 
        'Functions include system architecture design, sensor deployment, data aggregation, analytics integration, and optimization of IoT deployments for urban environments.', 
        'Requirements: Proficiency in IoT protocols, understanding of urban planning concepts, experience in sensor networks, and knowledge of cloud computing.');

-- Thesis 19
INSERT INTO Thesis 
VALUES ('244400019', 
        'Applying machine learning in medical image analysis for disease diagnosis', 
        'Artificial Intelligence and Machine Learning', 
        'Difficult', 
        7, 
        'Utilizing machine learning algorithms to analyze medical images such as X-rays, MRIs, and CT scans for diagnosing diseases, detecting abnormalities, and assisting radiologists in clinical decision-making.', 
        'reference.txt', 
        '2024-02-26 16:15:20', 
        'Technologies include Convolutional Neural Networks (CNNs), Transfer Learning, and DICOM for image preprocessing, feature extraction, and classification tasks in medical image analysis.', 
        'Functions include dataset curation, model training, validation testing, radiomics feature extraction, and integration with Picture Archiving and Communication Systems (PACS).', 
        'Requirements: Proficiency in medical image analysis, understanding of diagnostic imaging techniques, experience in deep learning frameworks, and knowledge of medical imaging standards.');

-- Thesis 20
INSERT INTO Thesis 
VALUES ('244400020', 
        'Enhancing cybersecurity through threat intelligence and risk assessment', 
        'Cybersecurity', 
        'Medium', 
        6, 
        'Strengthening cybersecurity posture by implementing threat intelligence platforms and conducting risk assessments to proactively identify, prioritize, and mitigate cyber threats targeting organizations.', 
        'reference.txt', 
        '2024-02-25 10:10:15', 
        'Technologies include SIEM (Security Information and Event Management) systems, Threat Intelligence Feeds, and Risk Assessment frameworks for threat detection, analysis, and risk quantification in cybersecurity operations.', 
        'Functions include threat hunting, incident response planning, vulnerability scanning, risk scoring, and security awareness training for employees.', 
        'Requirements: Proficiency in cybersecurity tools, understanding of threat landscape analysis, experience in risk management methodologies, and knowledge of compliance regulations.');

-- Thesis 21
INSERT INTO Thesis 
VALUES ('244400021', 
        'Implementing machine learning algorithms for predictive maintenance in manufacturing', 
        'Data Science and Analytics', 
        'Medium', 
        5, 
        'Implementing machine learning models to predict equipment failures and optimize maintenance schedules in manufacturing plants, reducing downtime and improving operational efficiency.', 
        'reference.txt', 
        '2024-02-24 14:05:10', 
        'Technologies include Python, scikit-learn, TensorFlow, and Apache Spark for data preprocessing, feature engineering, and predictive modeling based on historical maintenance data.', 
        'Functions include data exploration, model training, performance evaluation, maintenance scheduling, and integration with enterprise asset management systems.', 
        'Requirements: Proficiency in machine learning techniques, understanding of manufacturing processes, experience in predictive maintenance, and knowledge of reliability engineering.');

-- Thesis 22
INSERT INTO Thesis 
VALUES ('244400022', 
        'Enhancing user privacy in IoT devices through federated learning', 
        'Internet of Things (IoT)', 
        'Medium', 
        6, 
        'Implementing federated learning techniques to enhance user privacy and data security in IoT devices by training machine learning models locally on edge devices without sharing sensitive data with central servers.', 
        'reference.txt', 
        '2024-02-23 09:50:05', 
        'Technologies include PySyft, TensorFlow Federated, and Differential Privacy for building federated learning systems and ensuring privacy-preserving model training in distributed IoT environments.', 
        'Functions include model aggregation, differential privacy implementation, communication optimization, and performance evaluation of federated learning algorithms in IoT applications.', 
        'Requirements: Proficiency in federated learning frameworks, understanding of IoT security principles, experience in privacy-preserving machine learning, and knowledge of cryptography.');

-- Thesis 23
INSERT INTO Thesis 
VALUES ('244400023', 
        'Developing scalable and efficient blockchain solutions for supply chain management', 
        'Blockchain Technology', 
        'Medium', 
        6, 
        'Designing blockchain-based solutions to streamline supply chain processes, enhance transparency, and reduce fraud through immutable ledger records and smart contract automation.', 
        'reference.txt', 
        '2024-02-22 14:30:45', 
        'Technologies include Ethereum, Hyperledger Fabric, and Smart Contracts for building distributed ledger systems, implementing supply chain traceability, and enforcing business rules through blockchain automation.', 
        'Functions include consensus mechanism design, smart contract development, blockchain network deployment, and integration with existing supply chain management systems.', 
        'Requirements: Proficiency in blockchain platforms, understanding of supply chain dynamics, experience in smart contract programming, and knowledge of cryptography.');

-- Thesis 24
INSERT INTO Thesis 
VALUES ('244400024', 
        'Developing AI-powered chatbots for enhancing customer support in e-commerce', 
        'Artificial Intelligence and Machine Learning', 
        'Medium', 
        5, 
        'Creating AI-driven chatbots to provide personalized customer support, answer queries, and assist in product selection, improving customer satisfaction and retention in e-commerce platforms.', 
        'reference.txt', 
        '2024-02-21 11:15:30', 
        'Technologies include Natural Language Processing (NLP), Dialogflow, and Recurrent Neural Networks (RNNs) for understanding user intent, generating conversational responses, and improving chatbot interactions.', 
        'Functions include intent recognition, dialog management, sentiment analysis, integration with CRM systems, and continuous learning through user feedback.', 
        'Requirements: Proficiency in NLP techniques, understanding of e-commerce workflows, experience in chatbot development, and knowledge of customer service principles.');

-- Thesis 25
INSERT INTO Thesis 
VALUES ('244400025', 
        'Utilizing AI and IoT for precision agriculture in smart farming', 
        'Artificial Intelligence and Machine Learning', 
        'Medium', 
        6, 
        'Implementing AI and IoT technologies to optimize farming practices, monitor crop health, and automate agricultural processes for precision farming, improving yield, and resource efficiency.', 
        'reference.txt', 
        '2024-02-20 09:40:25', 
        'Technologies include Machine Learning, IoT sensors, Edge Computing, and Drone Technology for collecting agricultural data, analyzing environmental conditions, and making data-driven decisions in farming operations.', 
        'Functions include sensor deployment, data fusion, predictive modeling, automated irrigation, and crop monitoring using AI algorithms and IoT devices.', 
        'Requirements: Proficiency in AI and IoT integration, understanding of agricultural systems, experience in sensor networks, and knowledge of crop science.');

-- Thesis 26
INSERT INTO Thesis 
VALUES ('244400026', 
        'Building a scalable cloud infrastructure for healthcare data management', 
        'Cloud Computing', 
        'Medium', 
        6, 
        'Designing a cloud-based infrastructure to securely store, process, and analyze healthcare data, facilitating interoperability, accessibility, and scalability for healthcare organizations.', 
        'reference.txt', 
        '2024-02-19 14:20:20', 
        'Technologies include Amazon Web Services (AWS), Microsoft Azure, and Google Cloud Platform (GCP) for building secure and compliant cloud environments, implementing data encryption, and ensuring regulatory compliance in healthcare data management.', 
        'Functions include data migration, cloud architecture design, access control management, disaster recovery planning, and performance optimization of cloud services for healthcare applications.', 
        'Requirements: Proficiency in cloud computing platforms, understanding of healthcare data regulations, experience in HIPAA compliance, and knowledge of data encryption techniques.');

-- Thesis 27
INSERT INTO Thesis 
VALUES ('244400027', 
        'Enhancing cybersecurity through AI-driven threat detection and response', 
        'Cybersecurity', 
        'Difficult', 
        7, 
        'Implementing AI-based cybersecurity solutions to detect and respond to advanced cyber threats, leveraging machine learning algorithms for anomaly detection, threat hunting, and automated incident response.', 
        'reference.txt', 
        '2024-02-18 11:10:15', 
        'Technologies include Security Information and Event Management (SIEM), User and Entity Behavior Analytics (UEBA), and Deep Learning for analyzing network traffic, identifying suspicious behavior, and mitigating security risks in real-time.', 
        'Functions include security operations center (SOC) monitoring, threat intelligence integration, malware analysis, incident triage, and incident response playbook development.', 
        'Requirements: Proficiency in cybersecurity operations, understanding of threat intelligence concepts, experience in SOC environments, and knowledge of machine learning techniques for cybersecurity.');

-- Thesis 28
INSERT INTO Thesis 
VALUES ('244400028', 
        'Developing AI-driven recommendation systems for personalized learning platforms', 
        'Artificial Intelligence and Machine Learning', 
        'Medium', 
        6, 
        'Creating personalized learning experiences through AI-powered recommendation systems that analyze learner behavior, preferences, and performance data to suggest relevant content and learning pathways.', 
        'reference.txt', 
        '2024-02-17 09:50:10', 
        'Technologies include Collaborative Filtering, Content-Based Filtering, and Reinforcement Learning for building recommendation algorithms, improving learner engagement, and enhancing learning outcomes in online education platforms.', 
        'Functions include data preprocessing, model training, recommendation engine optimization, A/B testing, and performance evaluation of recommendation systems in educational contexts.', 
        'Requirements: Proficiency in machine learning algorithms, understanding of educational technology, experience in recommendation system development, and knowledge of learning analytics.');

-- Thesis 29
INSERT INTO Thesis 
VALUES ('244400029', 
        'Exploring the role of IoT in smart energy management for sustainable cities', 
        'Internet of Things (IoT)', 
        'Medium', 
        5, 
        'Investigating the applications of IoT technologies in optimizing energy consumption, reducing carbon emissions, and promoting sustainability in urban environments through smart energy management systems.', 
        'reference.txt', 
        '2024-02-16 14:30:05', 
        'Technologies include IoT sensors, Smart Grid technologies, and Energy Management Systems for collecting real-time energy data, analyzing consumption patterns, and implementing demand-side management strategies in smart cities.', 
        'Functions include sensor deployment, data analytics, energy optimization algorithms, infrastructure monitoring, and stakeholder engagement for implementing IoT-based energy solutions in urban areas.', 
        'Requirements: Proficiency in IoT deployment, understanding of energy systems, experience in sustainability initiatives, and knowledge of urban planning principles.');

-- Thesis 30
INSERT INTO Thesis 
VALUES ('244400030', 
        'Applying machine learning in financial fraud detection for banking security', 
        'Data Science and Analytics', 
        'Difficult', 
        7, 
        'Utilizing machine learning algorithms to detect and prevent financial fraud in banking systems, analyzing transaction data, and identifying fraudulent patterns to enhance security and protect customer assets.', 
        'reference.txt', 
        '2024-02-15 11:20:25', 
        'Technologies include Fraud Detection algorithms, Supervised Learning, and Ensemble methods for building predictive models to classify fraudulent transactions, reduce false positives, and improve fraud detection accuracy.', 
        'Functions include feature engineering, model training, anomaly detection, risk scoring, and integration with banking systems for real-time fraud monitoring and prevention.', 
        'Requirements: Proficiency in machine learning techniques, understanding of financial systems, experience in fraud detection, and knowledge of regulatory compliance in banking.');

-- INSERT ThesisStatus
-- delete from ThesisStatus

INSERT INTO ThesisStatus
VALUES 
('243300001', '244400001', 'Pending'),
('243300002', '244400002', 'Accepted'),
('243300003', '244400003', 'Completed'),
('243300004', '244400004', 'Pending'),
('243300005', '244400005', 'Accepted'),
('243300006', '244400006', 'Completed'),
('243300007', '244400007', 'Pending'),
('243300008', '244400008', 'Accepted'),
('243300009', '244400009', 'Completed'),
('243300010', '244400010', 'Pending');

INSERT INTO ThesisStatus
VALUES 
('243300001', '244400004', 'Pending'),
('243300002', '244400003', 'Accepted'),
('243300003', '244400005', 'Completed'),
('243300004', '244400009', 'Pending'),
('243300005', '244400010', 'Accepted'),
('243300006', '244400007', 'Completed'),
('243300007', '244400006', 'Pending'),
('243300008', '244400001', 'Accepted'),
('243300009', '244400002', 'Completed'),
('243300010', '244400008', 'Pending');

INSERT INTO ThesisStatus
VALUES 
('243300001', '244400007', 'Pending'),
('243300002', '244400001', 'Accepted'),
('243300003', '244400009', 'Completed'),
('243300004', '244400003', 'Pending'),
('243300005', '244400004', 'Accepted'),
('243300006', '244400008', 'Completed'),
('243300007', '244400002', 'Pending'),
('243300008', '244400006', 'Accepted'),
('243300009', '244400010', 'Completed'),
('243300010', '244400005', 'Pending');

---
select *
from (select idaccount as idstudent from ThesisStatus where sta = 'Pending' and idthesis = '244400001') as Q
inner join (select * from Account where role = 'Student') as R
on q.idstudent = r.idaccount
---










