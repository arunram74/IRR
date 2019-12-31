-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: timken_irr
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alarmlog`
--

DROP TABLE IF EXISTS `alarmlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `alarmlog` (
  `AlarmNo` int(11) NOT NULL AUTO_INCREMENT,
  `AlarmID` int(11) NOT NULL,
  `LogTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `HeadName` varchar(5) NOT NULL DEFAULT '1',
  `MachineName` varchar(10) DEFAULT NULL,
  `ProjectIDTxt` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`AlarmNo`)
) ENGINE=InnoDB AUTO_INCREMENT=66807 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bearings`
--

DROP TABLE IF EXISTS `bearings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `bearings` (
  `idBearingNo` int(11) NOT NULL AUTO_INCREMENT,
  `BearingNo` int(11) NOT NULL,
  `AddedTime` datetime DEFAULT NULL,
  `FailedTime` datetime DEFAULT NULL,
  `Failed` tinyint(4) NOT NULL,
  `Active` tinyint(4) NOT NULL,
  `ProjectID` int(11) NOT NULL,
  PRIMARY KEY (`idBearingNo`)
) ENGINE=InnoDB AUTO_INCREMENT=409 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `charts`
--

DROP TABLE IF EXISTS `charts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `charts` (
  `MinValV` float DEFAULT '0',
  `MaxValV` float DEFAULT '0',
  `VibrationA` float DEFAULT '0',
  `VibrationB` float DEFAULT '0',
  `VibrationC` float DEFAULT '0',
  `VibrationD` float DEFAULT '0',
  `MinValB` float DEFAULT '0',
  `MaxValB` float DEFAULT '0',
  `BA` float DEFAULT '0',
  `BB` float DEFAULT '0',
  `BC` float DEFAULT '0',
  `BD` float DEFAULT '0',
  `SBA` float DEFAULT '0',
  `SBB` float DEFAULT '0',
  `SBC` float DEFAULT '0',
  `SBD` float DEFAULT '0',
  `MinValOil` float DEFAULT '0',
  `MaxValOil` float DEFAULT '0',
  `InletOilA` float DEFAULT '0',
  `InletOilB` float DEFAULT '0',
  `InletOilC` float DEFAULT '0',
  `InletOilD` float DEFAULT '0',
  `TankOil` float DEFAULT '0',
  `MinValS` float DEFAULT '0',
  `MaxValS` float DEFAULT '0',
  `Speed` float DEFAULT '0',
  `MinValL` float DEFAULT '0',
  `MaxValL` float DEFAULT '0',
  `Load1` float DEFAULT '0',
  `idcharts` bigint(20) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idcharts`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `chrt_bearings`
--

DROP TABLE IF EXISTS `chrt_bearings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chrt_bearings` (
  `MinVal` float DEFAULT '0',
  `MaxVal` float DEFAULT '0',
  `BA` float DEFAULT '0',
  `BB` float DEFAULT '0',
  `BC` float DEFAULT '0',
  `BD` float DEFAULT '0',
  `SBA` float DEFAULT '0',
  `SBB` float DEFAULT '0',
  `SBC` float DEFAULT '0',
  `SBD` float DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `chrt_load`
--

DROP TABLE IF EXISTS `chrt_load`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chrt_load` (
  `MinVal` float DEFAULT '0',
  `MaxVal` float DEFAULT '0',
  `Load` float DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `chrt_oiltemp`
--

DROP TABLE IF EXISTS `chrt_oiltemp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chrt_oiltemp` (
  `MinVal` float DEFAULT '0',
  `MaxVal` float DEFAULT '0',
  `InletOilA` float DEFAULT '0',
  `InletOilB` float DEFAULT '0',
  `InletOilC` float DEFAULT '0',
  `InletOilD` float DEFAULT '0',
  `TankOil` float DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `chrt_speed`
--

DROP TABLE IF EXISTS `chrt_speed`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chrt_speed` (
  `MinVal` float DEFAULT '0',
  `MaxVal` float DEFAULT '0',
  `Speed` float DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `chrt_vib`
--

DROP TABLE IF EXISTS `chrt_vib`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chrt_vib` (
  `MinVal` float DEFAULT '0',
  `MaxVal` float DEFAULT '0',
  `VibrationA` float DEFAULT '0',
  `VibrationB` float DEFAULT '0',
  `VibrationC` float DEFAULT '0',
  `VibrationD` float DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `datalogs`
--

DROP TABLE IF EXISTS `datalogs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `datalogs` (
  `idDataLogs` bigint(20) NOT NULL AUTO_INCREMENT,
  `Status` varchar(5) NOT NULL DEFAULT '0',
  `StopReason` int(11) DEFAULT '0',
  `TankOilTemp` float NOT NULL DEFAULT '0',
  `Speed` float NOT NULL DEFAULT '0',
  `Load1` float DEFAULT '0',
  `Revolutions` float NOT NULL DEFAULT '0',
  `NoOfHours` float NOT NULL DEFAULT '0' COMMENT 'Recommend to store in Seconds.. so that hours can be calculated',
  `ProjectID` int(11) NOT NULL,
  `LogTime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idDataLogs`)
) ENGINE=InnoDB AUTO_INCREMENT=18621 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Duration between isSTarted and isStopped or isSuspended gives the run time';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `datalogs_a`
--

DROP TABLE IF EXISTS `datalogs_a`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `datalogs_a` (
  `iddatalogs_a` bigint(20) NOT NULL AUTO_INCREMENT,
  `Status` varchar(5) DEFAULT '0',
  `StopReason` int(11) NOT NULL DEFAULT '0',
  `B` float NOT NULL DEFAULT '0',
  `SB` float NOT NULL DEFAULT '0',
  `Inlet_Temp` float NOT NULL DEFAULT '0',
  `Vib` float NOT NULL DEFAULT '0',
  `ProjectID` int(11) NOT NULL,
  `BearingNo` int(11) NOT NULL DEFAULT '0',
  `LogTime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`iddatalogs_a`)
) ENGINE=InnoDB AUTO_INCREMENT=413 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `datalogs_b`
--

DROP TABLE IF EXISTS `datalogs_b`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `datalogs_b` (
  `iddatalogs_b` bigint(20) NOT NULL AUTO_INCREMENT,
  `Status` varchar(5) DEFAULT '0',
  `StopReason` int(11) NOT NULL DEFAULT '0',
  `B` float NOT NULL DEFAULT '0',
  `SB` float NOT NULL DEFAULT '0',
  `Inlet_Temp` float NOT NULL DEFAULT '0',
  `Vib` float NOT NULL DEFAULT '0',
  `ProjectID` int(11) NOT NULL,
  `BearingNo` int(11) NOT NULL DEFAULT '0',
  `LogTime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`iddatalogs_b`)
) ENGINE=InnoDB AUTO_INCREMENT=448 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `datalogs_c`
--

DROP TABLE IF EXISTS `datalogs_c`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `datalogs_c` (
  `iddatalogs_c` bigint(20) NOT NULL AUTO_INCREMENT,
  `Status` varchar(5) DEFAULT '0',
  `StopReason` int(11) NOT NULL DEFAULT '0',
  `B` float NOT NULL DEFAULT '0',
  `SB` float NOT NULL DEFAULT '0',
  `Inlet_Temp` float NOT NULL DEFAULT '0',
  `Vib` float NOT NULL DEFAULT '0',
  `ProjectID` int(11) NOT NULL,
  `BearingNo` int(11) NOT NULL DEFAULT '0',
  `LogTime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`iddatalogs_c`)
) ENGINE=InnoDB AUTO_INCREMENT=359 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `datalogs_d`
--

DROP TABLE IF EXISTS `datalogs_d`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `datalogs_d` (
  `iddatalogs_d` bigint(20) NOT NULL AUTO_INCREMENT,
  `Status` varchar(5) DEFAULT '0',
  `StopReason` int(11) NOT NULL DEFAULT '0',
  `B` float NOT NULL DEFAULT '0',
  `SB` float NOT NULL DEFAULT '0',
  `Inlet_Temp` float NOT NULL DEFAULT '0',
  `Vib` float NOT NULL DEFAULT '0',
  `ProjectID` int(11) NOT NULL,
  `BearingNo` int(11) NOT NULL DEFAULT '0',
  `LogTime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`iddatalogs_d`)
) ENGINE=InnoDB AUTO_INCREMENT=359 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `limitname`
--

DROP TABLE IF EXISTS `limitname`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `limitname` (
  `idlimitname` int(11) NOT NULL AUTO_INCREMENT,
  `LimitSetName` varchar(45) NOT NULL,
  PRIMARY KEY (`idlimitname`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `loadsteps`
--

DROP TABLE IF EXISTS `loadsteps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `loadsteps` (
  `idLoadSteps` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectID` int(11) NOT NULL,
  `StartLoad` float NOT NULL,
  `EndLoad` float NOT NULL,
  `LoadDuration` time NOT NULL,
  `RunDuration` time NOT NULL,
  `StepNo` int(11) NOT NULL,
  PRIMARY KEY (`idLoadSteps`)
) ENGINE=InnoDB AUTO_INCREMENT=130 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `loadstepstemp`
--

DROP TABLE IF EXISTS `loadstepstemp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `loadstepstemp` (
  `idLoadSteps` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectID` int(11) NOT NULL,
  `StartLoad` float NOT NULL,
  `EndLoad` float NOT NULL,
  `LoadDuration` time NOT NULL,
  `RunDuration` time NOT NULL,
  `StepNo` int(11) NOT NULL,
  PRIMARY KEY (`idLoadSteps`)
) ENGINE=InnoDB AUTO_INCREMENT=337 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `luboil`
--

DROP TABLE IF EXISTS `luboil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `luboil` (
  `idLubOil` int(11) NOT NULL AUTO_INCREMENT,
  `LubOilMC1` float DEFAULT NULL,
  `LubOilMC2` float DEFAULT NULL,
  `LubOilMC3` float DEFAULT NULL,
  `LubOilMC4` float DEFAULT NULL,
  `LogDate` datetime DEFAULT NULL,
  PRIMARY KEY (`idLubOil`)
) ENGINE=InnoDB AUTO_INCREMENT=367 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `parameters`
--

DROP TABLE IF EXISTS `parameters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `parameters` (
  `idParamDB` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectID` int(11) NOT NULL,
  `ParameterID` int(11) NOT NULL,
  `WH` float NOT NULL,
  `WL` float NOT NULL,
  `SH` float NOT NULL,
  `SL` float NOT NULL,
  `Value` float NOT NULL DEFAULT '0',
  `Setpoint` float NOT NULL DEFAULT '100',
  `Bypass` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idParamDB`)
) ENGINE=InnoDB AUTO_INCREMENT=535 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `project` (
  `ProjectName` varchar(45) DEFAULT NULL,
  `ProjectID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `ProjectIDTxt` varchar(45) DEFAULT NULL COMMENT 'There can be many rows with the same ProjectIDTxt',
  `Owner` varchar(45) DEFAULT NULL,
  `Make` varchar(45) DEFAULT NULL,
  `Lubrication` varchar(45) DEFAULT NULL,
  `PartNo` varchar(45) DEFAULT NULL,
  `HeadABearing` varchar(45) DEFAULT NULL,
  `HeadBBearing` varchar(45) DEFAULT NULL,
  `HeadCBearing` varchar(45) DEFAULT NULL,
  `HeadDBearing` varchar(45) DEFAULT NULL,
  `MaxRev` bigint(20) DEFAULT NULL,
  `MaxRevActive` tinyint(1) DEFAULT '0',
  `RunLogRate` time DEFAULT NULL,
  `LoadLogRate` time DEFAULT NULL,
  `DispUpdateRate` time DEFAULT NULL,
  `LoadDurationRemaining` time DEFAULT NULL,
  `RunDurationRemaining` time DEFAULT NULL,
  `CurrentStep` int(11) DEFAULT NULL,
  `CurrLoad` float DEFAULT NULL,
  `CurrRev` bigint(20) unsigned DEFAULT '0',
  `CreatedDate` datetime DEFAULT NULL,
  `TerminatedDate` datetime DEFAULT NULL,
  `ProjectStatus` int(11) DEFAULT NULL,
  `TotalHrs` time DEFAULT NULL,
  `HeadA_Enable` tinyint(4) DEFAULT '0',
  `HeadB_Enable` tinyint(4) DEFAULT '0',
  `HeadC_Enable` tinyint(4) DEFAULT '0',
  `HeadD_Enable` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`ProjectID`),
  UNIQUE KEY `ProjectID_UNIQUE` (`ProjectID`)
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reasondb`
--

DROP TABLE IF EXISTS `reasondb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `reasondb` (
  `ReasonID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `ReasonTxt` varchar(100) DEFAULT 'Alarm Text',
  PRIMARY KEY (`ReasonID`),
  UNIQUE KEY `ReasonID_UNIQUE` (`ReasonID`)
) ENGINE=InnoDB AUTO_INCREMENT=2100 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `scaling`
--

DROP TABLE IF EXISTS `scaling`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `scaling` (
  `idscaling` int(11) NOT NULL AUTO_INCREMENT,
  `Slope` float NOT NULL DEFAULT '0',
  `Intercept` float NOT NULL DEFAULT '0',
  `StationNo` int(11) DEFAULT '1',
  PRIMARY KEY (`idscaling`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `statustb`
--

DROP TABLE IF EXISTS `statustb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `statustb` (
  `statusID` int(11) NOT NULL,
  `statustxt` varchar(45) NOT NULL,
  PRIMARY KEY (`statusID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `testrun`
--

DROP TABLE IF EXISTS `testrun`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `testrun` (
  `idtestrun` int(11) NOT NULL AUTO_INCREMENT,
  `DateTimeLog` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `TestStatus` int(11) NOT NULL COMMENT 'Running/Stopped/Suspended',
  `Reason` varchar(100) DEFAULT NULL,
  `RigNo` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`idtestrun`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='for calculating number of hours run';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `userdb`
--

DROP TABLE IF EXISTS `userdb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `userdb` (
  `idUserDB` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `UserLevel` int(11) NOT NULL,
  PRIMARY KEY (`idUserDB`),
  UNIQUE KEY `UserLevel_UNIQUE` (`UserLevel`),
  UNIQUE KEY `UserName_UNIQUE` (`UserName`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `userlogs`
--

DROP TABLE IF EXISTS `userlogs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `userlogs` (
  `idUserLogs` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `UserLogDetail` varchar(100) NOT NULL,
  `LogTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `RigNo` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`idUserLogs`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `utility`
--

DROP TABLE IF EXISTS `utility`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `utility` (
  `idutility` int(11) NOT NULL AUTO_INCREMENT,
  `DateandTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ProjectIDTxt` varchar(45) NOT NULL DEFAULT '0',
  `Operation` varchar(5) NOT NULL DEFAULT '0',
  `ReasonID` int(11) DEFAULT '0',
  `BA` int(11) DEFAULT '0',
  `BB` int(11) DEFAULT '0',
  `BC` int(11) DEFAULT '0',
  `BD` int(11) DEFAULT '0',
  PRIMARY KEY (`idutility`)
) ENGINE=InnoDB AUTO_INCREMENT=4104 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping routines for database 'timken_irr'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-31 12:04:02
