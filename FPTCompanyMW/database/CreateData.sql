﻿-- DROP DATABASE PRN221_FPTCompanyMW;
-- CREATE DATABASE PRN221_FPTCompanyMW;
USE PRN221_FPTCompanyMW; 

CREATE TABLE Account (
    username VARCHAR(150) NOT NULL PRIMARY KEY,
    [password] VARCHAR(150) NOT NULL,
);
CREATE TABLE [Role](
	roleId int NOT NULL,
	roleName varchar(150),
	CONSTRAINT PK_Role PRIMARY KEY (roleId)
)
CREATE TABLE AccountRole(
	username varchar(150) NOT NULL,
	roleId int NOT NULL,
	CONSTRAINT PK_AccountRole PRIMARY KEY (username, roleId)
)

ALTER TABLE AccountRole ADD CONSTRAINT FK_AccountRole_Account FOREIGN KEY(username)
REFERENCES Account (username)
ALTER TABLE AccountRole ADD CONSTRAINT FK_AccountRole_Role FOREIGN KEY(roleId)
REFERENCES [Role] (roleId)

CREATE TABLE Employee
(
	employeeId varchar(50) NOT NULL,
	employeeName nvarchar(100),
	gender bit,
	employeeImage varchar(max),
	CONSTRAINT PK_Employee PRIMARY KEY (employeeId),

	accountId varchar(150) NOT NULL UNIQUE,
    CONSTRAINT FK_Employee_Account FOREIGN KEY (accountId) REFERENCES Account(username)
 )

 CREATE TABLE [Group]
(
	groupCode varchar(10) NOT NULL,
	groupName varchar(20) NULL,
	buId varchar(50) NULL,
	CONSTRAINT PK_Group PRIMARY KEY (groupCode)
)
ALTER TABLE [Group] ADD CONSTRAINT FK_Group_Employee FOREIGN KEY(buId)
REFERENCES Employee (employeeId)
ALTER TABLE [Group] DROP CONSTRAINT FK_Group_Employee 

CREATE TABLE Job (
    jobCode VARCHAR(10) PRIMARY KEY,
    jobName VARCHAR(255) NOT NULL
);
CREATE TABLE Package (
    packageCode VARCHAR(10) PRIMARY KEY,
    packageSalary DECIMAL(18, 0) NOT NULL
);

CREATE TABLE JobRank (
    jobRankId INT PRIMARY KEY,
    jobCode VARCHAR(10) REFERENCES Job(jobCode),
    jobRank VARCHAR(10) NOT NULL,
    packageCode VARCHAR(10) REFERENCES Package(packageCode)
);

CREATE TABLE Salary 
(
    employeeId VARCHAR(50) REFERENCES Employee(employeeId),
    jobRankId INT REFERENCES JobRank(jobRankId),
	PRIMARY KEY (employeeId, jobRankId)
);

CREATE TABLE StandardTime
(
    standardTimeId INT PRIMARY KEY,
    morningStartTime time,
    morningEndTime time,
    afternoonStartTime time,
    afternoonEndTime time,
);

CREATE TABLE Participate
(
	groupCode varchar(10) NOT NULL REFERENCES [Group] (groupCode),
	employeeId varchar(50) NOT NULL REFERENCES Employee (employeeId),
	standardTimeId int NOT NULL REFERENCES StandardTime (standardTimeId),
	CONSTRAINT PK_Participate PRIMARY KEY (groupCode, employeeId)
)

CREATE TABLE Working
(
    workingId INT PRIMARY KEY IDENTITY(1,1),
	employeeId varchar(50) NOT NULL REFERENCES Employee (employeeId),
	dateWorking date,
	firstEntryTime time,
	lastExistTime time,
);

SELECT * FROM Employee;
SELECT * FROM AccountRole;
SELECT * FROM Account;
SELECT * FROM [Role]

SELECT * FROM [Group]
SELECT * FROM Participate
SELECT * FROM Job
SELECT * FROM Package
SELECT * FROM JobRank
SELECT * FROM Salary
SELECT * FROM StandardTime
SELECT * FROM Working 

DELETE FROM Participate
DELETE FROM Job
DELETE FROM Package
DELETE FROM JobRank
DELETE FROM Salary
DELETE FROM StandardTime
/*
DROP TABLE Working
DROP TABLE Participate
DROP TABLE Salary
DROP TABLE [Group]
DROP TABLE Job
DROP TABLE Package
DROP TABLE JobRank
DROP TABLE StandardTime
*/

SELECT employeeId FROM Participate
GROUP BY employeeId
HAVING COUNT(DISTINCT groupCode) > 1;


SELECT * FROM [Group] g JOIN Participate p ON g.groupCode = p.groupCode WHERE g.groupCode = 'IVS';

SELECT e.employeeId, e.employeeName, g.groupCode, 
j.jobCode, j.jobName, 
jr.jobRank, jr.packageCode, 
pk.packageSalary, 
st.standardTimeId, st.morningStartTime, st.afternoonEndTime
FROM [Group] g 
JOIN Participate p ON g.groupCode = p.groupCode 
JOIN Employee e ON e.employeeId = p.employeeId 
JOIN Salary s ON s.employeeId = e.employeeId
JOIN JobRank jr ON jr.jobRankId = s.jobRankId
JOIN Job j ON j.jobCode = jr.jobCode
JOIN Package pk ON pk.packageCode = jr.packageCode
JOIN StandardTime st ON st.standardTimeId = p.standardTimeId 
WHERE g.groupCode IN ('GHC')
-- WHERE j.jobCode IN ('SPMA', 'BEDEVE')


SELECT *, CONVERT(TIME, CONCAT(
FORMAT(DATEDIFF(HOUR, w.firstEntryTime, w.lastExistTime), '00'),':', 
FORMAT(DATEDIFF(MINUTE, w.firstEntryTime, w.lastExistTime)%60, '00'),':', 
FORMAT(DATEDIFF(SECOND, w.firstEntryTime, w.lastExistTime)%60, '00')
)) AS workedTime  FROM Working w
WHERE  DATENAME(WEEKDAY, w.dateWorking) NOT IN ('Saturday', 'Sunday')
AND w.employeeId = 'thangnv75' AND MONTH(w.dateWorking) = 1

SELECT
st.*,
w.*
from Participate p
JOIN Employee e ON e.employeeId = p.employeeId 
JOIN StandardTime st ON st.standardTimeId = p.standardTimeId 
JOIN Working w ON w.employeeId = e.employeeId
WHERE w.firstEntryTime <  st.afternoonEndTime
