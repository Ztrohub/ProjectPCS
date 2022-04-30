-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 30, 2022 at 04:39 AM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_project`
--
CREATE DATABASE IF NOT EXISTS `db_project` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_project`;

-- --------------------------------------------------------

--
-- Table structure for table `brand`
--

DROP TABLE IF EXISTS `brand`;
CREATE TABLE `brand` (
  `BR_ID` int(11) NOT NULL,
  `BR_NAME` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `dtrans`
--

DROP TABLE IF EXISTS `dtrans`;
CREATE TABLE `dtrans` (
  `DT_ID` int(11) NOT NULL,
  `DT_HT_ID` int(11) DEFAULT NULL,
  `DT_SP_ID` int(11) DEFAULT NULL,
  `DT_PINJAM` datetime DEFAULT NULL,
  `DT_KEMBALI` datetime DEFAULT NULL,
  `DT_KEMBALIKAN` datetime DEFAULT NULL,
  `DT_HARI` int(11) DEFAULT NULL,
  `DT_AMOUNT` int(11) DEFAULT NULL,
  `DT_SUBTOTAL` int(11) DEFAULT NULL,
  `DT_STATUS` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `htrans`
--

DROP TABLE IF EXISTS `htrans`;
CREATE TABLE `htrans` (
  `HT_ID` int(11) NOT NULL,
  `HT_DATE` datetime DEFAULT NULL,
  `HT_INVOICE_NUMBER` int(11) DEFAULT NULL COMMENT '2 digit tahun + 2 digit bulan + 2 digit tgl + 3 digit no urut',
  `HT_US_ID` int(11) DEFAULT NULL,
  `HT_STATUS` int(11) DEFAULT 0 COMMENT '0 - belum kembali\n1 - sudah kembali semua',
  `HT_TOTAL` int(11) DEFAULT NULL,
  `HT_ACC` int(11) DEFAULT 0 COMMENT '- 0 not accepted\n- 1 accepted',
  `HT_US_ACC` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `sepeda`
--

DROP TABLE IF EXISTS `sepeda`;
CREATE TABLE `sepeda` (
  `SP_ID` int(11) NOT NULL,
  `SP_NAME` varchar(255) DEFAULT NULL,
  `SP_AMOUNT` int(11) DEFAULT NULL,
  `SP_PRICE` int(11) DEFAULT NULL,
  `SP_STATUS` int(11) DEFAULT 1,
  `SP_TY_ID` int(11) DEFAULT NULL,
  `SP_BR_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `type`
--

DROP TABLE IF EXISTS `type`;
CREATE TABLE `type` (
  `TY_ID` int(11) NOT NULL,
  `TY_NAME` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `US_ID` int(11) NOT NULL,
  `US_USERNAME` varchar(255) DEFAULT NULL,
  `US_PASSWORD` varchar(255) DEFAULT NULL,
  `US_NAME` varchar(255) DEFAULT NULL,
  `US_PR` int(11) DEFAULT NULL COMMENT 'Previllege\n1 - ADMIN\n2 - USER',
  `US_STATUS` int(11) DEFAULT 1,
  `US_SALDO` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `brand`
--
ALTER TABLE `brand`
  ADD PRIMARY KEY (`BR_ID`);

--
-- Indexes for table `dtrans`
--
ALTER TABLE `dtrans`
  ADD PRIMARY KEY (`DT_ID`),
  ADD KEY `DT_HT_ID_fk` (`DT_HT_ID`),
  ADD KEY `DT_SP_ID_fk` (`DT_SP_ID`);

--
-- Indexes for table `htrans`
--
ALTER TABLE `htrans`
  ADD PRIMARY KEY (`HT_ID`),
  ADD UNIQUE KEY `htrans_HT_INVOICE_NUMBER_uindex` (`HT_INVOICE_NUMBER`),
  ADD KEY `HT_US_ID__fk` (`HT_US_ID`),
  ADD KEY `ht_US_ACC_fk` (`HT_US_ACC`);

--
-- Indexes for table `sepeda`
--
ALTER TABLE `sepeda`
  ADD PRIMARY KEY (`SP_ID`),
  ADD KEY `SP_BR_fk` (`SP_BR_ID`),
  ADD KEY `SP_TY_fk` (`SP_TY_ID`);

--
-- Indexes for table `type`
--
ALTER TABLE `type`
  ADD PRIMARY KEY (`TY_ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`US_ID`),
  ADD UNIQUE KEY `users_US_USERNAME_uindex` (`US_USERNAME`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `brand`
--
ALTER TABLE `brand`
  MODIFY `BR_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dtrans`
--
ALTER TABLE `dtrans`
  MODIFY `DT_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `htrans`
--
ALTER TABLE `htrans`
  MODIFY `HT_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sepeda`
--
ALTER TABLE `sepeda`
  MODIFY `SP_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `type`
--
ALTER TABLE `type`
  MODIFY `TY_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `US_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `dtrans`
--
ALTER TABLE `dtrans`
  ADD CONSTRAINT `DT_HT_ID_fk` FOREIGN KEY (`DT_HT_ID`) REFERENCES `htrans` (`HT_ID`),
  ADD CONSTRAINT `DT_SP_ID_fk` FOREIGN KEY (`DT_SP_ID`) REFERENCES `sepeda` (`SP_ID`);

--
-- Constraints for table `htrans`
--
ALTER TABLE `htrans`
  ADD CONSTRAINT `HT_US_ID__fk` FOREIGN KEY (`HT_US_ID`) REFERENCES `users` (`US_ID`),
  ADD CONSTRAINT `ht_US_ACC_fk` FOREIGN KEY (`HT_US_ACC`) REFERENCES `users` (`US_ID`);

--
-- Constraints for table `sepeda`
--
ALTER TABLE `sepeda`
  ADD CONSTRAINT `SP_BR_fk` FOREIGN KEY (`SP_BR_ID`) REFERENCES `brand` (`BR_ID`),
  ADD CONSTRAINT `SP_TY_fk` FOREIGN KEY (`SP_TY_ID`) REFERENCES `type` (`TY_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
