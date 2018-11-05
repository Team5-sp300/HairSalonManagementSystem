-- MySqlBackup.NET 2.0.12
-- Dump Time: 2018-11-05 21:49:01
-- --------------------------------------
-- Server version 10.1.36-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of booking
-- 

DROP TABLE IF EXISTS `booking`;
CREATE TABLE IF NOT EXISTS `booking` (
  `BookingID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) NOT NULL,
  `EmployeeUsername` varchar(100) NOT NULL,
  `AppointmentDate` date DEFAULT NULL,
  `AppointmentTime` varchar(45) DEFAULT NULL,
  `ServiceID` int(11) NOT NULL,
  PRIMARY KEY (`BookingID`,`CustomerID`,`EmployeeUsername`,`ServiceID`),
  KEY `fk_Booking_Customer_idx` (`CustomerID`),
  KEY `fk_Booking_Employee_idx` (`EmployeeUsername`),
  KEY `fk_Booking_Service1_idx` (`ServiceID`),
  CONSTRAINT `fk_Booking_Customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Booking_Employee` FOREIGN KEY (`EmployeeUsername`) REFERENCES `employee` (`Username`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Booking_Service1` FOREIGN KEY (`ServiceID`) REFERENCES `service` (`ServiceID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table booking
-- 

/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
INSERT INTO `booking`(`BookingID`,`CustomerID`,`EmployeeUsername`,`AppointmentDate`,`AppointmentTime`,`ServiceID`) VALUES
(1,1,'AndSch676','2018-08-30 00:00:00','09:00',2),
(2,2,'AndSch676','2018-10-29 00:00:00','10:00',1),
(3,3,'AndSch676','2018-08-27 00:00:00','12:00',1),
(4,1,'AndSch676','2018-11-04 00:00:00','08:00',1);
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;

-- 
-- Definition of customer
-- 

DROP TABLE IF EXISTS `customer`;
CREATE TABLE IF NOT EXISTS `customer` (
  `CustomerID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(45) DEFAULT NULL,
  `CustomerLastName` varchar(45) DEFAULT NULL,
  `CustomerPhone` varchar(12) DEFAULT NULL,
  `CustomerEmail` varchar(45) DEFAULT NULL,
  `CustomerStatus` varchar(45) DEFAULT 'Active',
  PRIMARY KEY (`CustomerID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table customer
-- 

/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer`(`CustomerID`,`CustomerName`,`CustomerLastName`,`CustomerPhone`,`CustomerEmail`,`CustomerStatus`) VALUES
(1,'Sarah','Jone','0873774773','swabe@live.co.za','Active'),
(2,'Jessica','Lane','0857477345','swabe@live.co.za','Active'),
(3,'Mary','Black','0764662366','swabe@live.co.za','Active');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;

-- 
-- Definition of employee
-- 

DROP TABLE IF EXISTS `employee`;
CREATE TABLE IF NOT EXISTS `employee` (
  `Username` varchar(100) NOT NULL,
  `EmployeeFname` varchar(45) DEFAULT NULL,
  `EmployeeLname` varchar(45) DEFAULT NULL,
  `EmployeePassword` varchar(45) DEFAULT NULL,
  `EmployeePhoneNumber` varchar(12) DEFAULT NULL,
  `EmployeeEmail` varchar(45) DEFAULT NULL,
  `EmployeeStatus` varchar(45) CHARACTER SET big5 DEFAULT 'Active',
  `EmployeeType` int(11) NOT NULL,
  PRIMARY KEY (`Username`,`EmployeeType`),
  KEY `fk_Employee_EmployeeType1_idx` (`EmployeeType`),
  CONSTRAINT `fk_Employee_EmployeeType1` FOREIGN KEY (`EmployeeType`) REFERENCES `employeetype` (`idEmployeeType`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table employee
-- 

/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee`(`Username`,`EmployeeFname`,`EmployeeLname`,`EmployeePassword`,`EmployeePhoneNumber`,`EmployeeEmail`,`EmployeeStatus`,`EmployeeType`) VALUES
('AndSch676','Andrew','Schwabe','123','0769329192','swabe@live.co.za','Active',1),
('EriOdd357','Eric','Odding','123','0769329192','eodding@test.com','Active',1),
('JPDeJ874','JP','DeJager','123','0769329192','jpdejager@test.com','Active',1),
('NicCla309','Nick','Claassens','123','0769329192','nclassens@test.com','Active',1);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;

-- 
-- Definition of employeetype
-- 

DROP TABLE IF EXISTS `employeetype`;
CREATE TABLE IF NOT EXISTS `employeetype` (
  `idEmployeeType` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeType` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idEmployeeType`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table employeetype
-- 

/*!40000 ALTER TABLE `employeetype` DISABLE KEYS */;
INSERT INTO `employeetype`(`idEmployeeType`,`EmployeeType`) VALUES
(1,'Manager'),
(2,'Stylist');
/*!40000 ALTER TABLE `employeetype` ENABLE KEYS */;

-- 
-- Definition of service
-- 

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `ServiceID` int(11) NOT NULL,
  `ServiceDescription` varchar(45) NOT NULL,
  `ServiceDuration` varchar(45) NOT NULL,
  PRIMARY KEY (`ServiceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table service
-- 

/*!40000 ALTER TABLE `service` DISABLE KEYS */;
INSERT INTO `service`(`ServiceID`,`ServiceDescription`,`ServiceDuration`) VALUES
(1,'Gents Cut','45'),
(2,'Gents Shave','30'),
(3,'Ladies Cut','90'),
(4,'Ladies Cut and Blow','120'),
(5,'Ladies Blow','30'),
(6,'Tint Short','60'),
(7,'Tint Medium','90'),
(8,'Tint Long','120'),
(9,'Highlights Short','90'),
(10,'Highlights Medium','120'),
(11,'Highlights Long','150'),
(12,'Kids - Boy','45'),
(13,'Kids - Girl','45'),
(14,'Chemical Straightener','180');
/*!40000 ALTER TABLE `service` ENABLE KEYS */;

-- 
-- Dumping procedures
-- 

DROP PROCEDURE IF EXISTS `bookingCheck`;
DELIMITER |
CREATE PROCEDURE `bookingCheck`(efname VARCHAR(45),elname VARCHAR(45), adate DATE, atime VARCHAR(45), service VARCHAR(45))
BEGIN
 SELECT COUNT(*) 
 FROM Booking 
 WHERE  EmployeeUsername=(SELECT Username FROM Employee WHERE EmployeeFName=efname AND EmployeeLName=elname) 
 AND AppointmentDate=adate 
 AND (TIME(AppointmentTime) BETWEEN TIME(atime) AND TIME(ADDTIME(atime,(SELECT CONCAT('0',FLOOR(ServiceDuration/60),':',LPAD(MOD(ServiceDuration,60),2,0)-1) FROM Service WHERE ServiceDescription=service)))
 OR TIME(atime) BETWEEN TIME(AppointmentTime) AND TIME(ADDTIME(AppointmentTime,(SELECT CONCAT('0',FLOOR(ServiceDuration/60),':',LPAD(MOD(ServiceDuration,60),2,0)) FROM Service WHERE Booking.ServiceID=Service.ServiceID))));
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `cancelAppointment`;
DELIMITER |
CREATE PROCEDURE `cancelAppointment`(id VARCHAR(45))
BEGIN
	UPDATE Booking
	SET AppointmentTime = 'Cancelled'	
    WHERE BookingID=id; 
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `deleteCustomer`;
DELIMITER |
CREATE PROCEDURE `deleteCustomer`(id VARCHAR(45))
BEGIN
	DELETE FROM Booking 
    WHERE CustomerID=id; 
    
	DELETE FROM Customer
    WHERE CustomerID=id; 
    
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `deleteEmployee`;
DELIMITER |
CREATE PROCEDURE `deleteEmployee`(id VARCHAR(45))
BEGIN
	DELETE FROM Employee
    WHERE Username=id; 
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getBooking`;
DELIMITER |
CREATE PROCEDURE `getBooking`()
BEGIN
	SELECT BookingID , (SELECT CustomerName FROM Customer WHERE Booking.CustomerID=Customer.CustomerID),
    (SELECT EmployeeFname FROM Employee WHERE Booking.EmployeeUsername=Employee.Username),DATE_FORMAT(AppointmentDate,"%d/%m"), AppointmentTime, 
    (SELECT ServiceDescription FROM Service WHERE Booking.ServiceID = Service.ServiceID) FROM Booking 
    ORDER BY AppointmentDate ASC;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getBookingDetails`;
DELIMITER |
CREATE PROCEDURE `getBookingDetails`()
BEGIN
	SELECT (SELECT CustomerName FROM Customer WHERE Booking.CustomerID=Customer.CustomerID),DATE_FORMAT(AppointmentDate,"%d/%m"),
    AppointmentTime, (SELECT ServiceDuration FROM Service WHERE Service.ServiceID=Booking.ServiceID) FROM Booking 
    WHERE AppointmentDate >= DATE_FORMAT(NOW(),"%d/%m")
    ORDER BY AppointmentDate ASC;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getBookingHistory`;
DELIMITER |
CREATE PROCEDURE `getBookingHistory`(id VARCHAR(45))
BEGIN
	SELECT BookingID,(SELECT EmployeeFname FROM Employee WHERE Booking.EmployeeUsername=Employee.Username),DATE_FORMAT(AppointmentDate,"%d/%m"),
    AppointmentTime, (SELECT ServiceDuration FROM Service WHERE Service.ServiceID=Booking.ServiceID) AS `Service Duration`
    FROM Booking WHERE booking.CustomerID=id
    ORDER BY AppointmentDate ASC;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getCalendar`;
DELIMITER |
CREATE PROCEDURE `getCalendar`(username VARCHAR(45))
BEGIN
	SELECT (SELECT CustomerName FROM Customer WHERE Booking.CustomerID=Customer.CustomerID),DATE_FORMAT(AppointmentDate,"%d/%m"),
    AppointmentTime, (SELECT ServiceDuration FROM Service WHERE Service.ServiceID=Booking.ServiceID) FROM Booking 
     WHERE  AppointmentDate >= DATE(NOW()) AND Booking.EmployeeUsername=username
    ORDER BY AppointmentDate ASC;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getCustomer`;
DELIMITER |
CREATE PROCEDURE `getCustomer`()
BEGIN
	SELECT * FROM Customer;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getCustomerDetails`;
DELIMITER |
CREATE PROCEDURE `getCustomerDetails`(fname varchar(45),lname Varchar(45))
BEGIN
	SELECT * FROM Customer WHERE CustomerName=fname AND CustomerLastName=lname;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getEmployee`;
DELIMITER |
CREATE PROCEDURE `getEmployee`()
BEGIN
	SELECT * FROM Employee;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getEmployeeSchedule`;
DELIMITER |
CREATE PROCEDURE `getEmployeeSchedule`(username VARCHAR(45))
BEGIN
	SELECT BookingID, (SELECT CustomerName FROM Customer WHERE Booking.CustomerID=Customer.CustomerID),DATE_FORMAT(AppointmentDate,"%d/%m"), AppointmentTime,
     (SELECT ServiceDescription FROM Service WHERE Booking.ServiceID = Service.ServiceID),
    (SELECT ServiceDuration FROM Service WHERE Service.ServiceID=Booking.ServiceID)
    FROM Booking 
    WHERE  AppointmentDate >= DATE(NOW()) AND Booking.EmployeeUsername=username
    ORDER BY AppointmentDate ASC;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `getService`;
DELIMITER |
CREATE PROCEDURE `getService`()
BEGIN
	SELECT * FROM Service;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `insertBooking`;
DELIMITER |
CREATE PROCEDURE `insertBooking`(cfname VARCHAR(45), clname VARCHAR(45), efname VARCHAR(45), elname VARCHAR(45), adate VARCHAR(12), atime VARCHAR(45), service VARCHAR(45))
BEGIN
	INSERT INTO booking (CustomerID, EmployeeUsername, AppointmentDate, AppointmentTime, ServiceID)
    VALUES ((SELECT CustomerID FROM Customer WHERE CustomerName=cfname AND CustomerLastName=clname), (SELECT Username FROM Employee WHERE EmployeeFName=efname AND EmployeeLName=elname), adate, atime, (SELECT ServiceID from Service WHERE ServiceDescription=service));
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `insertClient`;
DELIMITER |
CREATE PROCEDURE `insertClient`(fname VARCHAR(45), lname VARCHAR(45), phone VARCHAR(12), email VARCHAR(45))
BEGIN
	INSERT INTO Customer (CustomerName, CustomerLastName, CustomerPhone, CustomerEmail)
    VALUES (fname, lname, phone, email);
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `insertEmployee`;
DELIMITER |
CREATE PROCEDURE `insertEmployee`(uname VARCHAR(45), fname VARCHAR(45),lname VARCHAR(45), email VARCHAR(45), phone VARCHAR(12), upassword VARCHAR(45), etype INT)
BEGIN
	INSERT INTO Employee (Username, EmployeeFname,EmployeeLname, EmployeePassword, EmployeePhoneNumber, EmployeeEmail,EmployeeType)
    VALUES (uname,fname,lname, email, phone, upassword,etype);
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `login`;
DELIMITER |
CREATE PROCEDURE `login`()
BEGIN
	SELECT Username, EmployeePassword, EmployeeType FROM Employee;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `updateBooking`;
DELIMITER |
CREATE PROCEDURE `updateBooking`(id INT, newDate VARCHAR(45), newTime VARCHAR(45), newService VARCHAR(45))
BEGIN
	UPDATE Booking
	SET AppointmentDate=newDate, AppointmentTime=newTime, ServiceID=(SELECT ServiceID FROM Service WHERE ServiceDescription=newService)
    WHERE BookingID=id;
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `updateBookingCheck`;
DELIMITER |
CREATE PROCEDURE `updateBookingCheck`(efname VARCHAR(45),elname VARCHAR(45), adate DATE, atime VARCHAR(45), bookingId int, service VARCHAR(45))
BEGIN
 SELECT COUNT(*) 
 FROM Booking 
 WHERE BookingID != bookingId
 AND EmployeeUsername=(SELECT Username FROM Employee WHERE EmployeeFName=efname AND EmployeeLName=elname) 
 AND AppointmentDate=adate 
 AND (TIME(AppointmentTime) BETWEEN TIME(atime) AND TIME(ADDTIME(atime,(SELECT CONCAT('0',FLOOR(ServiceDuration/60),':',LPAD(MOD(ServiceDuration,60),2,0)-1) FROM Service WHERE ServiceDescription=service)))
 OR TIME(atime) BETWEEN TIME(AppointmentTime) AND TIME(ADDTIME(AppointmentTime,(SELECT CONCAT('0',FLOOR(ServiceDuration/60),':',LPAD(MOD(ServiceDuration,60),2,0)) FROM Service WHERE Booking.ServiceID=Service.ServiceID))));
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `updateClient`;
DELIMITER |
CREATE PROCEDURE `updateClient`(id INT, fname VARCHAR(45), lname VARCHAR(45), phone VARCHAR(12), email VARCHAR(45))
BEGIN
	UPDATE Customer
	SET CustomerName = fname,	CustomerLastName=lname, CustomerPhone=phone, CustomerEmail=email
    WHERE CustomerID=id; 
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `updateEmployee`;
DELIMITER |
CREATE PROCEDURE `updateEmployee`(id VARCHAR(45), fname VARCHAR(45), lname VARCHAR(45), phone VARCHAR(12), email VARCHAR(45))
BEGIN
	UPDATE Employee
	SET EmployeeFname = fname,	EmployeeLname=lname, EmployeePhoneNumber=phone, EmployeeEmail=email
    WHERE Username=id; 
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `voidCustomer`;
DELIMITER |
CREATE PROCEDURE `voidCustomer`(id VARCHAR(45))
BEGIN
	UPDATE Customer
	SET CustomerStatus = 'Inactive'	
    WHERE CustomerID=id; 
END |
DELIMITER ;

DROP PROCEDURE IF EXISTS `voidEmployee`;
DELIMITER |
CREATE PROCEDURE `voidEmployee`(id VARCHAR(45))
BEGIN
	UPDATE Employee
	SET EmployeeStatus = 'Inactive'	
    WHERE Username=id; 
END |
DELIMITER ;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2018-11-05 21:49:01
-- Total time: 0:0:0:0:223 (d:h:m:s:ms)
