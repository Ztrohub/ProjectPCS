-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 31, 2022 at 06:35 AM
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
-- Table structure for table `aksesoris`
--

CREATE TABLE `aksesoris` (
  `AK_ID` int(11) NOT NULL,
  `AK_NAME` varchar(255) DEFAULT NULL,
  `AK_BR_ID` int(11) DEFAULT NULL,
  `AK_AMOUNT` int(11) DEFAULT NULL,
  `AK_PRICE_DAY` int(11) DEFAULT NULL,
  `AK_PRICE_HOUR` int(11) DEFAULT NULL,
  `AK_STATUS` int(11) DEFAULT NULL,
  `AK_TY_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aksesoris`
--

INSERT INTO `aksesoris` (`AK_ID`, `AK_NAME`, `AK_BR_ID`, `AK_AMOUNT`, `AK_PRICE_DAY`, `AK_PRICE_HOUR`, `AK_STATUS`, `AK_TY_ID`) VALUES
(1, 'LF0802 Knee Protector', 5, 20, 20000, 2000, 1, 6),
(2, 'TT-30 Cycling Bike Helmet', 5, 5, 40000, 5000, 1, 7);

-- --------------------------------------------------------

--
-- Table structure for table `brand`
--

CREATE TABLE `brand` (
  `BR_ID` int(11) NOT NULL,
  `BR_NAME` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `brand`
--

INSERT INTO `brand` (`BR_ID`, `BR_NAME`) VALUES
(1, 'Polygon'),
(2, 'Wimcycle'),
(3, 'United'),
(4, 'Brompton'),
(5, 'Rockbros');

-- --------------------------------------------------------

--
-- Table structure for table `denda`
--

CREATE TABLE `denda` (
  `D_ID` int(11) NOT NULL,
  `D_NAME` varchar(255) DEFAULT NULL,
  `D_PRICE` int(11) DEFAULT NULL,
  `D_HT_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `denda`
--

INSERT INTO `denda` (`D_ID`, `D_NAME`, `D_PRICE`, `D_HT_ID`) VALUES
(1, 'Terlambat Kembali 1 Jam @50.000', 50000, 4),
(2, 'Setir sepeda patah', 300000, 4);

-- --------------------------------------------------------

--
-- Table structure for table `dompet`
--

CREATE TABLE `dompet` (
  `DM_ID` int(11) NOT NULL,
  `DM_NAME` varchar(255) DEFAULT NULL,
  `DM_AMOUNT` int(11) DEFAULT NULL,
  `DM_US_ID` int(11) DEFAULT NULL,
  `DM_DATE` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dompet`
--

INSERT INTO `dompet` (`DM_ID`, `DM_NAME`, `DM_AMOUNT`, `DM_US_ID`, `DM_DATE`) VALUES
(1, 'Berhasil Top-Up', 80000, 6, '2022-05-31 06:09:09'),
(2, 'Pembayaran Transaksi #220531001', -80000, 6, '2022-05-31 10:09:05'),
(3, 'Berhasil Top-Up', 88000, 8, '2022-05-31 08:11:53'),
(4, 'Pembayaran Transaksi #220531002', -88000, 8, '2022-05-31 10:26:01'),
(5, 'Berhasil Top-Up', 350000, 8, '2022-05-31 15:30:36'),
(6, 'Pembayaran Denda Transaksi #220531002', -350000, 8, '2022-05-31 15:35:00'),
(7, 'Berhasil Top-Up', 320000, 8, '2022-06-01 06:25:09'),
(8, 'Pembayaran Transaksi #220601001', -320000, 8, '2022-06-01 11:16:22');

-- --------------------------------------------------------

--
-- Table structure for table `dtrans_aksesoris`
--

CREATE TABLE `dtrans_aksesoris` (
  `DTAK_ID` int(11) NOT NULL,
  `DTAK_HT_ID` int(11) DEFAULT NULL,
  `DTAK_AK_ID` int(11) DEFAULT NULL,
  `DTAK_AMOUNT` int(11) DEFAULT NULL,
  `DTAK_SUBTOTAL` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dtrans_aksesoris`
--

INSERT INTO `dtrans_aksesoris` (`DTAK_ID`, `DTAK_HT_ID`, `DTAK_AK_ID`, `DTAK_AMOUNT`, `DTAK_SUBTOTAL`) VALUES
(1, 4, 1, 1, 8000),
(2, 4, 2, 1, 20000);

-- --------------------------------------------------------

--
-- Table structure for table `dtrans_sepeda`
--

CREATE TABLE `dtrans_sepeda` (
  `DTSP_ID` int(11) NOT NULL,
  `DTSP_HT_ID` int(11) DEFAULT NULL,
  `DTSP_SP_ID` int(11) DEFAULT NULL,
  `DTSP_AMOUNT` int(11) DEFAULT NULL,
  `DTSP_SUBTOTAL` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dtrans_sepeda`
--

INSERT INTO `dtrans_sepeda` (`DTSP_ID`, `DTSP_HT_ID`, `DTSP_SP_ID`, `DTSP_AMOUNT`, `DTSP_SUBTOTAL`) VALUES
(1, 3, 1, 1, 80000),
(2, 4, 3, 1, 60000),
(3, 5, 1, 1, 320000);

-- --------------------------------------------------------

--
-- Table structure for table `htrans`
--

CREATE TABLE `htrans` (
  `HT_ID` int(11) NOT NULL,
  `HT_DATE` datetime DEFAULT NULL,
  `HT_INVOICE_NUMBER` int(11) DEFAULT NULL COMMENT '2 digit tahun + 2 digit bulan + 2 digit tgl + 3 digit no urut',
  `HT_US_ID` int(11) DEFAULT NULL,
  `HT_TOTAL` int(11) DEFAULT NULL,
  `HT_STATUS` int(11) DEFAULT 0 COMMENT '0 - belum kembali\n1 - sudah kembali\n2 - diacc dan ada denda\n3 - tidak ada denda / sudah bayar denda',
  `HT_US_ACC` int(11) DEFAULT NULL,
  `HT_HARI` int(11) DEFAULT NULL,
  `HT_JAM` int(11) DEFAULT NULL,
  `HT_KEMBALIAN` datetime DEFAULT NULL,
  `HT_DIKEMBALIKAN` datetime DEFAULT NULL,
  `HT_US_PENERIMA` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `htrans`
--

INSERT INTO `htrans` (`HT_ID`, `HT_DATE`, `HT_INVOICE_NUMBER`, `HT_US_ID`, `HT_TOTAL`, `HT_STATUS`, `HT_US_ACC`, `HT_HARI`, `HT_JAM`, `HT_KEMBALIAN`, `HT_DIKEMBALIKAN`, `HT_US_PENERIMA`) VALUES
(3, '2022-05-31 10:09:05', 220531001, 6, 80000, 1, 1, 1, NULL, '2022-06-01 23:59:59', '2022-06-01 12:00:00', NULL),
(4, '2022-05-31 10:26:01', 220531002, 8, 88000, 3, 7, NULL, 4, '2022-05-31 14:26:01', '2022-05-31 15:00:00', 7),
(5, '2022-06-01 11:16:22', 220601001, 8, 320000, 0, 1, 4, NULL, '2022-06-04 23:59:59', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `jaminan`
--

CREATE TABLE `jaminan` (
  `J_ID` int(11) NOT NULL,
  `J_TYPE` int(11) DEFAULT NULL COMMENT '1 - KTP\n2 - SIM\n3 - PASPOR',
  `J_IMAGE` varchar(255) DEFAULT NULL,
  `J_NUMBER` varchar(255) DEFAULT NULL,
  `J_HT_ID` int(11) DEFAULT NULL,
  `J_NOPENG` varchar(255) DEFAULT NULL,
  `J_DATE` datetime DEFAULT NULL,
  `J_AMBIL` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `jaminan`
--

INSERT INTO `jaminan` (`J_ID`, `J_TYPE`, `J_IMAGE`, `J_NUMBER`, `J_HT_ID`, `J_NOPENG`, `J_DATE`, `J_AMBIL`) VALUES
(1, 1, '1.jpg', '3326160608070256', 3, 'JM220531001', '2022-05-31 10:48:35', NULL),
(2, 1, '2.jpg', '3326063102134512', 4, 'JM220531002', '2022-05-31 10:26:01', '2022-05-31 16:00:00'),
(3, 1, '3.jpg', '3326063102134512', 5, 'JM220601001', '2022-06-01 11:16:22', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `sepeda`
--

CREATE TABLE `sepeda` (
  `SP_ID` int(11) NOT NULL,
  `SP_NAME` varchar(255) DEFAULT NULL,
  `SP_AMOUNT` int(11) DEFAULT NULL,
  `SP_PRICE_DAY` int(11) DEFAULT NULL,
  `SP_PRICE_HOUR` int(11) DEFAULT NULL,
  `SP_STATUS` int(11) DEFAULT 1,
  `SP_TY_ID` int(11) DEFAULT NULL,
  `SP_BR_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sepeda`
--

INSERT INTO `sepeda` (`SP_ID`, `SP_NAME`, `SP_AMOUNT`, `SP_PRICE_DAY`, `SP_PRICE_HOUR`, `SP_STATUS`, `SP_TY_ID`, `SP_BR_ID`) VALUES
(1, 'Polygon Helios LT9X', 5, 80000, 8000, 1, 5, 1),
(2, 'Polygon Stratos S7', 2, 90000, 10000, 1, 1, 1),
(3, 'Brompton Basic M6R', 2, 120000, 15000, 1, 4, 4);

-- --------------------------------------------------------

--
-- Table structure for table `type`
--

CREATE TABLE `type` (
  `TY_ID` int(11) NOT NULL,
  `TY_NAME` varchar(255) DEFAULT NULL,
  `TY_FOR` int(11) DEFAULT NULL COMMENT '0 - SEPEDA\n1 - AKSESORIS'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `type`
--

INSERT INTO `type` (`TY_ID`, `TY_NAME`, `TY_FOR`) VALUES
(1, 'Sepeda Gunung', 0),
(2, 'BMX', 0),
(3, 'Hybrid', 0),
(4, 'Sepeda Lipat', 0),
(5, 'Touring', 0),
(6, 'Pelindung Lutut', 1),
(7, 'Helm', 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

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
-- Dumping data for table `users`
--

INSERT INTO `users` (`US_ID`, `US_USERNAME`, `US_PASSWORD`, `US_NAME`, `US_PR`, `US_STATUS`, `US_SALDO`) VALUES
(1, 'admin', '123', 'Joko Sujoko', 1, 1, 0),
(6, 'budi', 'abc', 'Budi Subudi', 2, 1, 0),
(7, 'bambang123', '123', 'Bambang Subambang', 1, 1, 0),
(8, 'rizky321', '321', 'Rizky Surizky', 2, 1, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aksesoris`
--
ALTER TABLE `aksesoris`
  ADD PRIMARY KEY (`AK_ID`),
  ADD KEY `aksesoris_BR_fk` (`AK_BR_ID`),
  ADD KEY `aksesoris_ty_fk` (`AK_TY_ID`);

--
-- Indexes for table `brand`
--
ALTER TABLE `brand`
  ADD PRIMARY KEY (`BR_ID`);

--
-- Indexes for table `denda`
--
ALTER TABLE `denda`
  ADD PRIMARY KEY (`D_ID`),
  ADD KEY `denda_htrans_HT_ID_fk` (`D_HT_ID`);

--
-- Indexes for table `dompet`
--
ALTER TABLE `dompet`
  ADD PRIMARY KEY (`DM_ID`),
  ADD KEY `Dompet_users_US_ID_fk` (`DM_US_ID`);

--
-- Indexes for table `dtrans_aksesoris`
--
ALTER TABLE `dtrans_aksesoris`
  ADD PRIMARY KEY (`DTAK_ID`),
  ADD KEY `dtrans_aksesoris_htrans_HT_ID_fk` (`DTAK_HT_ID`),
  ADD KEY `dtrans_aksesoris_aksesoris_AK_ID_fk` (`DTAK_AK_ID`);

--
-- Indexes for table `dtrans_sepeda`
--
ALTER TABLE `dtrans_sepeda`
  ADD PRIMARY KEY (`DTSP_ID`),
  ADD KEY `DT_HT_ID_fk` (`DTSP_HT_ID`),
  ADD KEY `DT_SP_ID_fk` (`DTSP_SP_ID`);

--
-- Indexes for table `htrans`
--
ALTER TABLE `htrans`
  ADD PRIMARY KEY (`HT_ID`),
  ADD UNIQUE KEY `htrans_HT_INVOICE_NUMBER_uindex` (`HT_INVOICE_NUMBER`),
  ADD KEY `HT_US_ID__fk` (`HT_US_ID`),
  ADD KEY `ht_US_ACC_fk` (`HT_US_ACC`),
  ADD KEY `htrans_users_US_ID_fk` (`HT_US_PENERIMA`);

--
-- Indexes for table `jaminan`
--
ALTER TABLE `jaminan`
  ADD PRIMARY KEY (`J_ID`),
  ADD KEY `jaminan_htrans_HT_ID_fk` (`J_HT_ID`);

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
-- AUTO_INCREMENT for table `aksesoris`
--
ALTER TABLE `aksesoris`
  MODIFY `AK_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `brand`
--
ALTER TABLE `brand`
  MODIFY `BR_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `denda`
--
ALTER TABLE `denda`
  MODIFY `D_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `dompet`
--
ALTER TABLE `dompet`
  MODIFY `DM_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `dtrans_aksesoris`
--
ALTER TABLE `dtrans_aksesoris`
  MODIFY `DTAK_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `dtrans_sepeda`
--
ALTER TABLE `dtrans_sepeda`
  MODIFY `DTSP_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `htrans`
--
ALTER TABLE `htrans`
  MODIFY `HT_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `jaminan`
--
ALTER TABLE `jaminan`
  MODIFY `J_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `sepeda`
--
ALTER TABLE `sepeda`
  MODIFY `SP_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `type`
--
ALTER TABLE `type`
  MODIFY `TY_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `US_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aksesoris`
--
ALTER TABLE `aksesoris`
  ADD CONSTRAINT `aksesoris_BR_fk` FOREIGN KEY (`AK_BR_ID`) REFERENCES `brand` (`BR_ID`),
  ADD CONSTRAINT `aksesoris_ty_fk` FOREIGN KEY (`AK_TY_ID`) REFERENCES `type` (`TY_ID`);

--
-- Constraints for table `denda`
--
ALTER TABLE `denda`
  ADD CONSTRAINT `denda_htrans_HT_ID_fk` FOREIGN KEY (`D_HT_ID`) REFERENCES `htrans` (`HT_ID`);

--
-- Constraints for table `dompet`
--
ALTER TABLE `dompet`
  ADD CONSTRAINT `Dompet_users_US_ID_fk` FOREIGN KEY (`DM_US_ID`) REFERENCES `users` (`US_ID`);

--
-- Constraints for table `dtrans_aksesoris`
--
ALTER TABLE `dtrans_aksesoris`
  ADD CONSTRAINT `dtrans_aksesoris_aksesoris_AK_ID_fk` FOREIGN KEY (`DTAK_AK_ID`) REFERENCES `aksesoris` (`AK_ID`),
  ADD CONSTRAINT `dtrans_aksesoris_htrans_HT_ID_fk` FOREIGN KEY (`DTAK_HT_ID`) REFERENCES `htrans` (`HT_ID`);

--
-- Constraints for table `dtrans_sepeda`
--
ALTER TABLE `dtrans_sepeda`
  ADD CONSTRAINT `DT_HT_ID_fk` FOREIGN KEY (`DTSP_HT_ID`) REFERENCES `htrans` (`HT_ID`),
  ADD CONSTRAINT `DT_SP_ID_fk` FOREIGN KEY (`DTSP_SP_ID`) REFERENCES `sepeda` (`SP_ID`);

--
-- Constraints for table `htrans`
--
ALTER TABLE `htrans`
  ADD CONSTRAINT `HT_US_ID__fk` FOREIGN KEY (`HT_US_ID`) REFERENCES `users` (`US_ID`),
  ADD CONSTRAINT `ht_US_ACC_fk` FOREIGN KEY (`HT_US_ACC`) REFERENCES `users` (`US_ID`),
  ADD CONSTRAINT `htrans_users_US_ID_fk` FOREIGN KEY (`HT_US_PENERIMA`) REFERENCES `users` (`US_ID`);

--
-- Constraints for table `jaminan`
--
ALTER TABLE `jaminan`
  ADD CONSTRAINT `jaminan_htrans_HT_ID_fk` FOREIGN KEY (`J_HT_ID`) REFERENCES `htrans` (`HT_ID`);

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
