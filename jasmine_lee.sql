-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 14, 2019 at 03:39 AM
-- Server version: 5.7.24-log
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jasmine_lee`
--
CREATE DATABASE IF NOT EXISTS `jasmine_lee` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `jasmine_lee`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
`name` varchar(255) DEFAULT NULL,
`phoneNumber` int(11) DEFAULT NULL,
`stylistId` int(11) DEFAULT NULL,
`id` bigint(20) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`name`, `phoneNumber`, `stylistId`, `id`) VALUES
('Drogon', 2339, 3, 4),
('Viserion', 2599, 1, 5),
('Rhaegal', 2111, 1, 6),
('Groot', 7771, 2, 7);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
`feature` varchar(255) NOT NULL
`id` int(11) NOT NULL,
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`description`, `id` ) VALUES
('pompadour', 40),
('combover', 41),
('ducktail', 42);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
`id` int(11) NOT NULL,
`name` varchar(255) NOT NULL,
`phoneNumber` varchar(255) NOT NULL,
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`name`, `phoneNumber`, `id`) VALUES
('Daenerys', '2633', 1),
('Jon','9992', 2),
('Cersei', '3644', 3);
-- --------------------------------------------------------

--
-- Table structure for table `stylists_specialties`
--

CREATE TABLE `stylists_specialties` (
`id` int(11) NOT NULL,
`stylist_ID` int(11) NOT NULL,
`specialty_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_specialties`
--

INSERT INTO `stylists_specialties` (`ID`, `stylist_ID`, `specialty_ID`) VALUES
(9, 1, 40),
(10, 2, 40),
(11, 3, 42);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
