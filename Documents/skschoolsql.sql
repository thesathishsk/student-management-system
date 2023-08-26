create table staffLogin(userid int primary key,password varchar(30) not null);
insert into staffLogin values(131001,'Dhivya121'),(131002,'suja111'),(131003,'Vimala2323'),(131004,'Anto12'),(131005,'Deepika12'),(131006,'PremKumarsrk'),(131007,'Jhon1212'),(131008,'Kelvin11'),(131009,'saranyarv')
select * from stafflogin

create table staffDetails(userid int primary key,name varchar(30) not null,dob date not null,Dateofjoining date not null,gender varchar(30) not null, qualification varchar(30) not null, Totalexperience float not null,email varchar(40) not null, phoneNo varchar(40) not null, address varchar(50) not null)
insert into staffDetails values(131002,'suja','1892-09-12','2004-11-02','Female','Msc.Computer Science',3,'sujamsc@gmail.com','897788221','78,west cross street, chennai')

select * from staffDetails

create table class(classid int primary key,class_name varchar(30) not null,teacher_id int not null)
insert into class values(102,'XII-CS',131009);
select * from class

create table staffAcademics(userid int primary key,name varchar(30) not null,subject_id int not null,classid int not null)

insert into staffAcademics values ( 131007,'Jhon venkat',677,102)
select * from staffAcademics

create table subject(subject_id int primary key, subject_name varchar(30) not null);
insert into subject values(677,'Maths'),(678,'Chemistry'),(680,'Physics'),(679,'English'),(681,'History'),(682,'Tamil'),(683,'Science'),(684,'social'),(685,'Computer Science'),(686,'Biology')
select * from subject