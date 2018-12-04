CREATE DATABASE  IF NOT EXISTS `cexam_retake` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `cexam_retake`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: cexam_retake
-- ------------------------------------------------------
-- Server version	8.0.12

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
-- Table structure for table `Activities`
--

DROP TABLE IF EXISTS `Activities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Activities` (
  `activityId` int(11) NOT NULL AUTO_INCREMENT,
  `activityName` varchar(255) DEFAULT NULL,
  `duration` varchar(255) DEFAULT NULL,
  `desc` varchar(255) DEFAULT NULL,
  `settime` datetime DEFAULT NULL,
  `setdate` date DEFAULT NULL,
  `stamp_created` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `stamp_updated` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `userId` int(11) NOT NULL,
  PRIMARY KEY (`activityId`,`userId`),
  KEY `fk_Activities_users1_idx` (`userId`),
  CONSTRAINT `fk_Activities_users1` FOREIGN KEY (`userId`) REFERENCES `Users` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Activities`
--

LOCK TABLES `Activities` WRITE;
/*!40000 ALTER TABLE `activities` DISABLE KEYS */;
INSERT INTO `Activities` VALUES (6,'test','test Hours','I DO THIS EVERY DAY','2018-11-24 15:24:00','2342-03-24','2018-11-24 17:30:43','2018-11-24 17:30:43',3),(7,'YELLING','24 Hours','I DO THIS EVERY DAY','2018-11-24 14:32:00','2024-01-01','2018-11-24 18:43:20','2018-11-24 18:43:20',3);
/*!40000 ALTER TABLE `activities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `JoinAct`
--

DROP TABLE IF EXISTS `JoinAct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `JoinAct` (
  `joinactId` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) NOT NULL,
  `activityId` int(11) NOT NULL,
  PRIMARY KEY (`joinactId`,`userId`,`activityId`),
  KEY `fk_table2_activities1_idx` (`activityId`),
  KEY `fk_table2_users` (`userId`),
  CONSTRAINT `fk_table2_Activities1` FOREIGN KEY (`activityId`) REFERENCES `Activities` (`activityid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_table2_users` FOREIGN KEY (`userId`) REFERENCES `Users` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `JoinAct`
--

LOCK TABLES `JoinAct` WRITE;
/*!40000 ALTER TABLE `joinact` DISABLE KEYS */;
INSERT INTO `JoinAct` VALUES (16,3,6),(15,3,7);
/*!40000 ALTER TABLE `joinact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Users` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `stamp_created` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `stamp_updated` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (3,'Jeremy','Felts','jeremyfto@hotmail.com','SmitePro12','2018-11-24 15:35:06','2018-11-24 15:35:06');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-12-04  0:44:10
