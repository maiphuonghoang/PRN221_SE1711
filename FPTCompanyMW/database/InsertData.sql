USE PRN221_FPTCompanyMW; 

INSERT INTO [Group] (groupCode, buId) VALUES ('GHC', 'thangnv75');
INSERT INTO [Group] (groupCode, buId) VALUES ('EBS', 'anhnh88');
INSERT INTO [Group] (groupCode, buId) VALUES ('GST', 'sonnt5');
INSERT INTO [Group] (groupCode, buId) VALUES ('IVS', 'tientd17');
INSERT INTO [Group] (groupCode, buId) VALUES ('FCJ', 'trungnt');

INSERT INTO Job (jobCode, jobName)
VALUES
('SPMA', 'Project Manager'),
('BRSE', 'Bridge Software Engineering'),
('SDSM', 'Scrum Master'),
('SPOW', 'Product Owner'),
('BANE', 'Business Analyst'),
('DESI', 'Designer'),
('SARE', 'Solution Architect'),
('BEDEVE', 'Back-end Developer'),
('MBDEVE', 'Mobile Developer'),
('FEDEVE', 'Front-end Developer'),
('ODEV', 'OS and Middleware Developer'),
('TEST', 'Tester'),
('AWSC', 'AWS Consultant'),
('DSEN', 'Data Engineer'),
('DSAN', 'Data Analyst'),
('DEVO', 'DevOps Engineer');

INSERT INTO Package (packageCode, packageSalary)
VALUES
('P2', 8000000),
('P3', 10000000),
('P4', 15000000),
('P5', 18000000),
('P6', 20000000),
('P7', 25000000),
('P8', 28000000),
('P9', 30000000);

-- Insert data into JobRank table
INSERT INTO JobRank (jobRankId, jobCode, jobRank, packageCode)
VALUES
(1, 'SPMA', 'SPMA01', 'P4'),
(2, 'SPMA', 'SPMA02', 'P5'),
(3, 'SPMA', 'SPMA03', 'P6'),
(4, 'SPMA', 'SPMA04', 'P7'),
(5, 'SPMA', 'SPMA05', 'P8'),
(6, 'SPMA', 'SPMA06', 'P9'),
(7, 'BRSE', 'BRSE01', 'P4'),
(8, 'BRSE', 'BRSE02', 'P5'),
(9, 'BRSE', 'BRSE03', 'P6'),
(10, 'BRSE', 'BRSE04', 'P7'),
(11, 'BRSE', 'BRSE05', 'P8'),
(12, 'SDSM', 'SDSM01', 'P3'),
(13, 'SDSM', 'SDSM02', 'P4'),
(14, 'SDSM', 'SDSM03', 'P5'),
(15, 'SDSM', 'SDSM04', 'P6'),
(16, 'SPOW', 'SPOW01', 'P4'),
(17, 'SPOW', 'SPOW02', 'P5'),
(18, 'SPOW', 'SPOW03', 'P6'),
(19, 'SPOW', 'SPOW04', 'P7'),
(20, 'SPOW', 'SPOW05', 'P8'),
(21, 'SPOW', 'SPOW06', 'P9'),
(22, 'BANE', 'BANE01', 'P3'),
(23, 'BANE', 'BANE02', 'P4'),
(24, 'BANE', 'BANE03', 'P5'),
(25, 'BANE', 'BANE04', 'P6'),
(26, 'BANE', 'BANE05', 'P7'),
(27, 'BANE', 'BANE06', 'P8'),
(28, 'DESI', 'DESI01', 'P4'),
(29, 'DESI', 'DESI02', 'P5'),
(30, 'DESI', 'DESI03', 'P6'),
(31, 'DESI', 'DESI04', 'P7'),
(32, 'DESI', 'DESI05', 'P8'),
(33, 'DESI', 'DESI06', 'P9'),
(34, 'SARE', 'SARE01', 'P5'),
(35, 'SARE', 'SARE02', 'P6'),
(36, 'SARE', 'SARE03', 'P7'),
(37, 'SARE', 'SARE04', 'P8'),
(38, 'SARE', 'SARE05', 'P9'),
(39, 'BEDEVE', 'DEVE01', 'P2'),
(40, 'BEDEVE', 'DEVE02', 'P3'),
(41, 'BEDEVE', 'DEVE03', 'P4'),
(42, 'BEDEVE', 'DEVE04', 'P5'),
(43, 'BEDEVE', 'DEVE05', 'P6'),
(44, 'BEDEVE', 'DEVE06', 'P7'),
(45, 'MBDEVE', 'DEVE01', 'P2'),
(46, 'MBDEVE', 'DEVE02', 'P3'),
(47, 'MBDEVE', 'DEVE03', 'P4'),
(48, 'MBDEVE', 'DEVE04', 'P5'),
(49, 'MBDEVE', 'DEVE05', 'P6'),
(50, 'MBDEVE', 'DEVE06', 'P7'),
(51, 'FEDEVE', 'DEVE01', 'P2'),
(52, 'FEDEVE', 'DEVE02', 'P3'),
(53, 'FEDEVE', 'DEVE03', 'P4'),
(54, 'FEDEVE', 'DEVE04', 'P5'),
(55, 'FEDEVE', 'DEVE05', 'P6'),
(56, 'FEDEVE', 'DEVE06', 'P7'),
(57, 'TEST', 'TEST01', 'P2'),
(58, 'TEST', 'TEST02', 'P3'),
(59, 'TEST', 'TEST03', 'P4'),
(60, 'TEST', 'TEST04', 'P5'),
(61, 'TEST', 'TEST05', 'P6'),
(62, 'TEST', 'TEST06', 'P7'),
(63, 'AWSC', 'AWSC01', 'P5'),
(64, 'AWSC', 'AWSC02', 'P6'),
(65, 'AWSC', 'AWSC03', 'P7'),
(66, 'AWSC', 'AWSC04', 'P8'),
(67, 'DSEN', 'DSEN01', 'P4'),
(68, 'DSEN', 'DSEN02', 'P5'),
(69, 'DSEN', 'DSEN03', 'P6'),
(70, 'DSEN', 'DSEN04', 'P7'),
(71, 'DSEN', 'DSEN05', 'P8'),
(72, 'DSAN', 'DSAN01', 'P4'),
(73, 'DSAN', 'DSAN02', 'P5'),
(74, 'DSAN', 'DSAN03', 'P6'),
(75, 'DSAN', 'DSAN04', 'P7'),
(76, 'DSAN', 'DSAN05', 'P8'),
(77, 'DEVO', 'DEVO01', 'P3'),
(78, 'DEVO', 'DEVO02', 'P4'),
(79, 'DEVO', 'DEVO03', 'P5'),
(80, 'DEVO', 'DEVO04', 'P6'),
(81, 'DEVO', 'DEVO05', 'P7'),
(82, 'DEVO', 'DEVO06', 'P8');


INSERT INTO Salary (employeeId, jobRankId) VALUES
	('anhnh88', '2'),
	('DE170703', '7'),
	('HE153678', '15'),
	('HE161700', '20'),
	('HE161706', '23'),
	('HE161755', '28'),
	('HE163415', '35'),
	('HE163635', '40'),
	('HE164044', '39'),
	('HE170072', '41'),
	('HE170180', '42'),
	('HE170201', '43'),
	('HE170203', '45'),
	('HE170420', '49'),
	('HE170595', '51'),
	('HE171098', '56'),
	('HE171319', '57'),
	('HE171320', '61'),
	('HE171416', '63'),
	('HE171702', '66'),
	('HE171937', '67'),
	('HE172032', '75'),
	('HE173037', '73'),
	('HE173046', '78'),
	('HE176640', '82'),
	('HE181829', '51'),
	('HE181879', '56'),
	('HS170024', '45'),
	('HS170726', '50'),
	('HS173175', '43'),
	('HS176033', '44');

INSERT INTO Salary (employeeId, jobRankId) VALUES
	('trungnt', '3'),
	('HE161232', '8'),
	('HE161643', '14'),
	('HE163665', '17'),
	('HE170123', '22'),
	('HE170268', '29'),
	('HE170302', '38'),
	('HE170314', '39'),
	('HE170317', '40'),
	('HE170617', '41'),
	('HE171209', '42'),
	('HE171310', '43'),
	('HE171883', '46'),
	('HE172207', '48'),
	('HE172366', '52'),
	('HE172533', '55'),
	('HE172693', '58'),
	('HE172802', '60'),
	('HE173328', '64'),
	('HE173373', '65'),
	('HE173476', '70'),
	('HE173489', '72'),
	('HE176275', '75'),
	('HE176282', '78'),
	('HE176285', '82'),
	('HE176346', '52'),
	('HE176360', '54'),
	('HE176603', '46'),
	('HE176686', '49'),
	('HE176834', '41');

INSERT INTO Salary (employeeId, jobRankId) VALUES
	('thangnv75', '4'),
	('HE150057', '9'),
	('HE151095', '13'),
	('HE153206', '16'),
	('HE160694', '24'),
	('HE161357', '33'),
	('HE161795', '34'),
	('HE163146', '42'),
	('HE164035', '39'),
	('HE170051', '40'),
	('HE170245', '41'),
	('HE170422', '43'),
	('HE170428', '47'),
	('HE170444', '50'),
	('HE170533', '53'),
	('HE170842', '54'),
	('HE170863', '59'),
	('HE170907', '62'),
	('HE170996', '65'),
	('HE171071', '63'),
	('HE171073', '71'),
	('HE171162', '73'),
	('HE171442', '76'),
	('HE171482', '79'),
	('HE171578', '81'),
	('HE171687', '54'),
	('HE171851', '52'),
	('HE171865', '48'),
	('HE176182', '46'),
	('HE176697', '42'),
	('HE176751', '32'),
	('SE03520', '26'),
	('SE04495', '21');

INSERT INTO Salary (employeeId, jobRankId) VALUES
	('sonnt5', '5'),
	('HE161285', '10'),
	('HE161816', '12'),
	('HE163067', '18'),
	('HE170011', '27'),
	('HE170167', '30'),
	('HE170273', '36'),
	('HE170301', '44'),
	('HE170415', '39'),
	('HE170607', '40'),
	('HE170622', '41'),
	('HE170631', '42'),
	('HE170724', '48'),
	('HE170960', '46'),
	('HE170999', '54'),
	('HE171312', '53'),
	('HE171411', '60'),
	('HE171540', '57'),
	('HE171628', '66'),
	('HE172037', '64'),
	('HE172748', '69'),
	('HE172838', '76'),
	('HE172848', '74'),
	('HE173248', '79'),
	('HE173588', '81'),
	('HE176077', '55'),
	('HE176087', '51'),
	('HE176169', '47'),
	('HE176420', '50'),
	('HE176882', '44');

INSERT INTO Salary (employeeId, jobRankId) VALUES
	('tientd17', '6'),
	('HE150732', '11'),
	('HE150998', '13'),
	('HE161224', '19'),
	('HE161597', '25'),
	('HE163629', '31'),
	('HE170089', '37'),
	('HE170685', '41'),
	('HE170793', '39'),
	('HE171358', '40'),
	('HE171394', '42'),
	('HE171421', '44'),
	('HE171552', '49'),
	('HE171908', '45'),
	('HE171915', '55'),
	('HE171916', '52'),
	('HE171990', '61'),
	('HE172180', '58'),
	('HE172280', '64'),
	('HE172313', '65'),
	('HE172435', '68'),
	('HE172527', '74'),
	('HE172538', '72'),
	('HE172702', '80'),
	('HE172737', '80'),
	('HE173401', '56'),
	('HE173457', '53'),
	('HE176211', '49'),
	('HE176279', '48'),
	('HE176633', '40'),
	('HE176747', '43');

INSERT INTO StandardTime (standardTimeId, morningStartTime, morningEndTime, afternoonStartTime, afternoonEndTime)
VALUES
(1, '08:00:00 AM', '12:00:00 PM', '13:30:00 PM', '17:00:00 PM'),
(2, '08:30:00 AM', '12:00:00 PM', '13:30:00 PM', '17:30:00 PM'),
(3, '09:00:00 AM', '12:00:00 PM', '13:30:00 PM', '18:00:00 PM')

INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE150057', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE151095', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE153206', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE160694', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE161357', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE161795', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE163146', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE164035', 'GHC', 2);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170051', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170245', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170422', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170428', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170444', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170533', 'GHC', 2);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170842', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170863', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170907', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE170996', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171071', 'GHC', 2);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171073', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171162', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171442', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171482', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171578', 'GHC', 2);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171687', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171851', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE171865', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE176182', 'GHC', 3);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE176697', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('HE176751', 'GHC', 3);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('SE03520', 'GHC', 3);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('SE04495', 'GHC', 1);
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('thangnv75', 'GHC', 1);



INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'DE170703', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE153678', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE161700', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE161706', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE161755', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE163415', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE163635', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE164044', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE170072', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE170180', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE170201', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE170203', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE170420', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE170595', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE171098', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE171319', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE171320', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE171416', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE171702', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE171937', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE172032', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE173037', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE173046', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE176640', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE181829', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HE181879', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HS170024', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HS170726', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HS173175', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('EBS', 'HS176033', 1)
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('anhnh88', 'EBS', 1);

INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE161232', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE161643', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE163665', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE170123', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE170268', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE170302', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE170314', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE170317', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE170617', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE171209', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE171310', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE171883', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE172207', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE172366', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE172533', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE172693', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE172802', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE173328', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE173373', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE173476', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE173489', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176275', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176282', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176285', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176346', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176360', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176603', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176686', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('FCJ', 'HE176834', 1)
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('trungnt', 'FCJ', 1);

INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE161285', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE161816', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE163067', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170011', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170167', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170273', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170301', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170415', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170607', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170622', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170631', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170724', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170960', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE170999', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE171312', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE171411', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE171540', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE171628', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE172037', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE172748', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE172838', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE172848', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE173248', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE173588', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE176077', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE176087', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE176169', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE176420', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('GST', 'HE176882', 1)
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('sonnt5', 'GST', 1);

INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE150732', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE150998', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE161224', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE161597', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE163629', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE170089', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE170685', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE170793', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171358', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171394', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171421', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171552', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171908', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171915', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171916', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE171990', 2)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172180', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172280', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172313', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172435', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172527', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172538', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172702', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE172737', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE173457', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE176211', 1)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE176279', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE176633', 3)
INSERT INTO Participate (groupCode, employeeId, standardTimeId) VALUES ('IVS', 'HE176747', 1)
INSERT INTO Participate (employeeId, groupCode, standardTimeId) VALUES ('tientd17', 'IVS', 1);


SET DATEFORMAT DMY

INSERT INTO Working (employeeId, dateWorking , firstEntryTime, lastExistTime) VALUES
	('HE150057', '01/01/2024', '07:45:00', '17:00:00'),
	('HE150057', '02/01/2024', '07:50:00', '17:01:01'),
	('HE150057', '03/01/2024', '07:55:00', '17:02:02'),
	('HE150057', '04/01/2024', '08:00:00', '17:03:03'),
	('HE150057', '05/01/2024', '08:00:00', '17:04:04'),
	('HE150057', '08/01/2024', '08:00:00', '17:07:07'),
	('HE150057', '09/01/2024', '08:00:00', '17:08:08'),
	('HE150057', '10/01/2024', '08:00:00', '17:09:09'),
	('HE150057', '11/01/2024', '08:00:00', '17:10:10'),
	('HE150057', '12/01/2024', '08:00:00', '17:11:11'),
	('HE150057', '15/01/2024', '08:00:00', '17:14:14'),
	('HE150057', '16/01/2024', '07:45:00', '17:15:15'),
	('HE150057', '17/01/2024', '07:50:00', '17:16:16'),
	('HE150057', '18/01/2024', '07:55:00', '17:17:17'),
	('HE150057', '19/01/2024', '08:00:00', '17:18:18'),
	('HE150057', '22/01/2024', '08:00:00', '17:21:21'),
	('HE150057', '23/01/2024', '08:00:00', '17:22:22'),
	('HE150057', '24/01/2024', '08:00:00', '17:23:23'),
	('HE150057', '25/01/2024', '08:00:00', '17:24:24'),
	('HE150057', '26/01/2024', '08:00:00', '17:25:25'),
	('HE150057', '29/01/2024', '08:00:00', '17:28:28'),
	('HE150057', '30/01/2024', '08:00:00', '17:29:29'),
	('HE150057', '31/01/2024', '08:00:00', '17:30:30'),
	('HE150057', '01/02/2024', '08:00:00', '17:00:00'),
	('HE150057', '02/02/2024', '08:00:00', '17:01:01'),
	('HE150057', '05/02/2024', '08:00:00', '17:04:04'),
	('HE150057', '06/02/2024', '08:00:00', '17:05:05'),
	('HE150057', '07/02/2024', '07:45:00', '17:06:06'),
	('HE150057', '08/02/2024', '07:50:00', '17:07:07'),
	('HE150057', '09/02/2024', '07:55:00', '17:08:08'),
	('HE150057', '12/02/2024', '08:00:00', '17:11:11'),
	('HE150057', '13/02/2024', '08:00:00', '17:12:12'),
	('HE150057', '14/02/2024', '08:00:00', '17:13:13'),
	('HE150057', '15/02/2024', '08:00:00', '17:14:14'),
	('HE150057', '16/02/2024', '08:00:00', '17:15:15'),
	('HE150057', '19/02/2024', '08:00:00', '17:18:18'),
	('HE150057', '20/02/2024', '08:00:00', '17:19:19'),
	('HE150057', '21/02/2024', '07:48:00', '17:20:20'),
	('HE150057', '22/02/2024', '07:52:00', '17:21:21'),
	('HE150057', '23/02/2024', '07:59:00', '17:22:22'),
	('HE150057', '26/02/2024', '07:59:05', '17:25:25'),
	('HE150057', '27/02/2024', '07:48:03', '17:26:26'),
	('HE150057', '28/02/2024', '07:52:00', '17:27:27'),
	('HE150057', '29/02/2024', '07:59:00', '17:28:28');
INSERT INTO Working (employeeId, dateWorking , firstEntryTime, lastExistTime) VALUES
	('HE151095', '01/01/2024', '07:45:00', '17:00:00'),
	('HE151095', '02/01/2024', '07:50:00', '17:01:01'),
	('HE151095', '03/01/2024', '07:55:00', '17:02:02'),
	('HE151095', '04/01/2024', '08:00:00', '17:03:03'),
	('HE151095', '05/01/2024', '08:00:00', '17:04:04'),
	('HE151095', '08/01/2024', '08:00:00', '17:07:07'),
	('HE151095', '09/01/2024', '08:00:00', '17:08:08'),
	('HE151095', '10/01/2024', '08:00:00', '17:09:09'),
	('HE151095', '11/01/2024', '08:00:00', '17:10:10'),
	('HE151095', '12/01/2024', '08:00:00', '17:11:11'),
	('HE151095', '15/01/2024', '08:00:00', '17:14:14'),
	('HE151095', '16/01/2024', '07:45:00', '17:15:15'),
	('HE151095', '17/01/2024', '07:50:00', '17:16:16'),
	('HE151095', '18/01/2024', '07:55:00', '17:17:17'),
	('HE151095', '19/01/2024', '08:00:00', '17:18:18'),
	('HE151095', '22/01/2024', '08:00:00', '17:21:21'),
	('HE151095', '23/01/2024', '08:00:00', '17:22:22'),
	('HE151095', '24/01/2024', '08:00:00', '17:23:23'),
	('HE151095', '25/01/2024', '08:00:10', '17:24:24'),
	('HE151095', '26/01/2024', '08:01:10', '17:25:25'),
	('HE151095', '29/01/2024', '09:00:10', '17:28:28'),
	('HE151095', '30/01/2024', '10:00:00', '17:29:29'),
	('HE151095', '31/01/2024', '08:00:10', '16:30:00'),
	('HE151095', '01/02/2024', '08:00:10', '16:30:00'),
	('HE151095', '02/02/2024', '08:00:00', '16:30:00'),
	('HE151095', '05/02/2024', '08:00:00', '16:30:00'),
	('HE151095', '06/02/2024', '08:00:00', '17:05:05'),
	('HE151095', '07/02/2024', '07:45:00', '17:06:06'),
	('HE151095', '08/02/2024', '07:50:00', '17:07:07'),
	('HE151095', '09/02/2024', '07:55:00', '17:08:08'),
	('HE151095', '12/02/2024', '08:00:00', '12:00:00'),
	('HE151095', '13/02/2024', '08:00:00', '11:00:00'),
	('HE151095', '14/02/2024', '08:00:00', '12:30:00'),
	('HE151095', '15/02/2024', '08:10:00', '12:00:00'),
	('HE151095', '16/02/2024', '08:00:00', '10:00:00'),
	('HE151095', '19/02/2024', '08:00:00', '17:18:18'),
	('HE151095', '20/02/2024', '08:00:00', '17:19:19'),
	('HE151095', '21/02/2024', '07:48:00', '17:20:20'),
	('HE151095', '22/02/2024', '15:00:00', '17:00:00'),
	('HE151095', '23/02/2024', '13:30:00', '16:40:00'),
	('HE151095', '26/02/2024', '12:30:00', '17:00:00'),
	('HE151095', '27/02/2024', '13:30:00', '17:00:00'),
	('HE151095', '28/02/2024', '13:40:00', '17:00:00'),
	('HE151095', '29/02/2024', '13:40:00', '16:40:00');
INSERT INTO Working (employeeId, dateWorking , firstEntryTime, lastExistTime) VALUES
	('thangnv75', '01/01/2024', '07:45:00', '17:00:00'),
	('thangnv75', '02/01/2024', '07:50:00', '17:01:01'),
	('thangnv75', '03/01/2024', '07:55:00', '17:02:02'),
	('thangnv75', '04/01/2024', '08:00:00', '17:03:03'),
	('thangnv75', '05/01/2024', '08:00:00', '17:04:04'),
	('thangnv75', '06/01/2024', '08:00:00', '17:05:05'),
	('thangnv75', '07/01/2024', '08:00:00', '17:06:06'),
	('thangnv75', '08/01/2024', '08:00:00', '17:07:07'),
	('thangnv75', '09/01/2024', '08:00:00', '17:08:08'),
	('thangnv75', '10/01/2024', '08:00:00', '17:09:09'),
	('thangnv75', '11/01/2024', '08:00:00', '17:10:10'),
	('thangnv75', '12/01/2024', '08:00:00', '17:11:11'),
	('thangnv75', '13/01/2024', '08:05:00', '17:12:12'),
	('thangnv75', '14/01/2024', '08:00:00', '17:13:13'),
	('thangnv75', '15/01/2024', '08:00:00', '17:14:14'),
	('thangnv75', '16/01/2024', '07:45:00', '17:15:15'),
	('thangnv75', '17/01/2024', '07:50:00', '17:16:16'),
	('thangnv75', '18/01/2024', '07:55:00', '17:17:17'),
	('thangnv75', '19/01/2024', '08:00:00', '17:18:18'),
	('thangnv75', '20/01/2024', '08:00:00', '17:19:19'),
	('thangnv75', '21/01/2024', '08:00:00', '17:20:20'),
	('thangnv75', '22/01/2024', '08:00:00', '17:21:21'),
	('thangnv75', '23/01/2024', '08:00:00', '17:22:22'),
	('thangnv75', '24/01/2024', '08:00:00', '17:23:23'),
	('thangnv75', '25/01/2024', '08:00:00', '17:24:24'),
	('thangnv75', '26/01/2024', '08:00:00', '17:25:25'),
	('thangnv75', '27/01/2024', '08:00:00', '17:26:26'),
	('thangnv75', '28/01/2024', '08:00:00', '17:27:27'),
	('thangnv75', '29/01/2024', '08:00:00', '17:28:28'),
	('thangnv75', '30/01/2024', '08:00:00', '17:29:29'),
	('thangnv75', '31/01/2024', '08:00:00', '17:30:30'),
	('thangnv75', '01/02/2024', '08:00:00', '17:00:00'),
	('thangnv75', '02/02/2024', '08:00:00', '17:01:01'),
	('thangnv75', '03/02/2024', '07:59:05', '17:02:02'),
	('thangnv75', '04/02/2024', '08:00:00', '17:03:03'),
	('thangnv75', '05/02/2024', '08:00:00', '17:04:04'),
	('thangnv75', '06/02/2024', '08:00:00', '17:05:05'),
	('thangnv75', '07/02/2024', '07:45:00', '17:06:06'),
	('thangnv75', '08/02/2024', '07:50:00', '17:07:07'),
	('thangnv75', '09/02/2024', '07:55:00', '17:08:08'),
	('thangnv75', '10/02/2024', '08:00:00', '17:09:09'),
	('thangnv75', '11/02/2024', '08:00:00', '17:10:10'),
	('thangnv75', '12/02/2024', '08:00:00', '17:11:11'),
	('thangnv75', '13/02/2024', '08:00:00', '17:12:12'),
	('thangnv75', '14/02/2024', '08:00:00', '17:13:13'),
	('thangnv75', '15/02/2024', '08:00:00', '17:14:14'),
	('thangnv75', '16/02/2024', '08:00:00', '17:15:15'),
	('thangnv75', '17/02/2024', '08:00:00', '17:16:16'),
	('thangnv75', '18/02/2024', '08:00:00', '17:17:17'),
	('thangnv75', '19/02/2024', '08:00:00', '17:18:18'),
	('thangnv75', '20/02/2024', '08:00:00', '17:19:19'),
	('thangnv75', '21/02/2024', '07:48:00', '17:20:20'),
	('thangnv75', '22/02/2024', '07:52:00', '17:21:21'),
	('thangnv75', '23/02/2024', '07:59:00', '17:22:22'),
	('thangnv75', '24/02/2024', '07:48:00', '17:23:23'),
	('thangnv75', '25/02/2024', '07:52:00', '17:24:24'),
	('thangnv75', '26/02/2024', '07:59:05', '17:25:25'),
	('thangnv75', '27/02/2024', '07:48:03', '17:26:26'),
	('thangnv75', '28/02/2024', '07:52:00', '17:27:27'),
	('thangnv75', '29/02/2024', '07:59:00', '17:28:28');

INSERT INTO Working (employeeId, dateWorking , firstEntryTime, lastExistTime) VALUES
	('HE153206', '01/01/2024', '07:45:00', '17:00:00'),
	('HE153206', '02/01/2024', '07:50:00', '17:01:01'),
	('HE153206', '03/01/2024', '07:55:00', '17:02:02'),
	('HE153206', '04/01/2024', '08:00:00', '17:03:03'),
	('HE153206', '05/01/2024', '08:00:00', '17:04:04'),
	('HE153206', '08/01/2024', '08:00:00', '17:07:07'),
	('HE153206', '10/01/2024', '08:00:00', '17:09:09'),
	('HE153206', '11/01/2024', '08:00:00', '17:10:10'),
	('HE153206', '12/01/2024', '08:00:00', '17:11:11'),
	('HE153206', '16/01/2024', '07:45:00', '17:15:15'),
	('HE153206', '17/01/2024', '07:50:00', '17:16:16'),
	('HE153206', '18/01/2024', '07:55:00', '17:17:17'),
	('HE153206', '22/01/2024', '08:00:00', '17:21:21'),
	('HE153206', '23/01/2024', '08:00:00', '17:22:22'),
	('HE153206', '24/01/2024', '08:00:00', '17:23:23'),
	('HE153206', '26/01/2024', '08:00:00', '17:25:25'),
	('HE153206', '29/01/2024', '08:00:00', '17:28:28'),
	('HE153206', '30/01/2024', '08:00:00', '17:29:29'),
	('HE153206', '31/01/2024', '08:00:00', '17:30:30'),
	('HE153206', '01/02/2024', '08:00:00', '17:00:00'),
	('HE153206', '02/02/2024', '08:00:00', '17:01:01'),
	('HE153206', '06/02/2024', '08:00:00', '17:05:05'),
	('HE153206', '07/02/2024', '07:45:00', '17:06:06'),
	('HE153206', '08/02/2024', '07:50:00', '17:07:07'),
	('HE153206', '09/02/2024', '07:55:00', '17:08:08'),
	('HE153206', '12/02/2024', '08:00:00', '17:11:11'),
	('HE153206', '13/02/2024', '08:00:00', '17:12:12'),
	('HE153206', '14/02/2024', '08:00:00', '17:13:13'),
	('HE153206', '15/02/2024', '08:00:00', '17:14:14'),
	('HE153206', '16/02/2024', '08:00:00', '17:15:15'),
	('HE153206', '20/02/2024', '08:00:00', '17:19:19'),
	('HE153206', '21/02/2024', '07:48:00', '17:20:20'),
	('HE153206', '22/02/2024', '07:52:00', '17:00:00'),
	('HE153206', '23/02/2024', '07:59:00', '17:00:00'),
	('HE153206', '27/02/2024', '07:48:03', '17:00:00'),
	('HE153206', '28/02/2024', '07:52:00', '17:00:00'),
	('HE153206', '29/02/2024', '07:59:00', '17:00:00');