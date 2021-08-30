-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 27.08.2021 klo 09:55
-- Palvelimen versio: 10.4.20-MariaDB
-- PHP Version: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `torstai`
--

-- --------------------------------------------------------

--
-- Rakenne taululle `asiakas`
--

CREATE TABLE `asiakas` (
  `IDasiakas` int(11) NOT NULL,
  `nimi` varchar(20) DEFAULT NULL,
  `osoite` varchar(50) DEFAULT NULL,
  `puhelin` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vedos taulusta `asiakas`
--

INSERT INTO `asiakas` (`IDasiakas`, `nimi`, `osoite`, `puhelin`) VALUES
(1, 'Veikon urheilu', 'valimotie 200 00010 Helsinki', '010 1234567'),
(2, 'Urheilu vilkas', 'Syrjäkylä 1 00000 kaupaunki', '010 7654321'),
(3, 'Urheilu pekka', 'Kauppatie 1 00000 kaupaunki', '010 7655555');

-- --------------------------------------------------------

--
-- Rakenne taululle `myynti`
--

CREATE TABLE `myynti` (
  `IDmyynti` int(11) NOT NULL,
  `kpl` smallint(6) DEFAULT NULL,
  `hinta` decimal(6,2) DEFAULT NULL,
  `maksettu` bit(1) DEFAULT NULL,
  `asikasID` int(11) DEFAULT NULL,
  `tuoteID` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vedos taulusta `myynti`
--

INSERT INTO `myynti` (`IDmyynti`, `kpl`, `hinta`, `maksettu`, `asikasID`, `tuoteID`) VALUES
(1, 50, '25.00', b'0', 1, 1),
(2, 10, '5.50', b'0', 1, 2),
(3, 20, '15.60', b'0', 3, 6),
(4, 5, '23.45', b'0', 2, 10);

-- --------------------------------------------------------

--
-- Rakenne taululle `valine`
--

CREATE TABLE `valine` (
  `valineID` smallint(6) NOT NULL,
  `vnimi` varchar(30) DEFAULT NULL,
  `ostettu` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vedos taulusta `valine`
--

INSERT INTO `valine` (`valineID`, `vnimi`, `ostettu`) VALUES
(1, 'Keilapallo', '2021-08-26'),
(2, 'Jalkapallo', '2021-08-26'),
(3, 'Keihäs', '2021-08-26'),
(4, 'Tennismaila', '2021-08-20'),
(5, 'Lumilauta', '2021-01-20'),
(6, 'Juoksukengät', '2021-04-10'),
(7, 'Koripallo', '2021-04-14'),
(8, 'Polkupyörä', '2021-08-14'),
(10, 'Golf putteri', '2021-05-05'),
(11, 'Sukset', '2021-05-15'),
(12, 'Levypainot', '2021-09-15'),
(14, 'SUP lauta', '2021-06-15');

-- --------------------------------------------------------

--
-- Rakenne taululle `varasto`
--

CREATE TABLE `varasto` (
  `IDvarasto` int(11) NOT NULL,
  `maara` int(11) DEFAULT NULL,
  `avain_valine` smallint(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Vedos taulusta `varasto`
--

INSERT INTO `varasto` (`IDvarasto`, `maara`, `avain_valine`) VALUES
(1, 25, 3),
(2, 17, 1),
(3, 17, 2),
(4, 7, 4),
(5, 12, 5),
(6, 22, 6),
(7, 52, 7),
(8, 9, 8),
(10, 27, 10),
(11, 7, 11),
(12, 37, 12),
(14, 8, 14);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `asiakas`
--
ALTER TABLE `asiakas`
  ADD PRIMARY KEY (`IDasiakas`);

--
-- Indexes for table `myynti`
--
ALTER TABLE `myynti`
  ADD PRIMARY KEY (`IDmyynti`);

--
-- Indexes for table `varasto`
--
ALTER TABLE `varasto`
  ADD PRIMARY KEY (`IDvarasto`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `asiakas`
--
ALTER TABLE `asiakas`
  MODIFY `IDasiakas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `myynti`
--
ALTER TABLE `myynti`
  MODIFY `IDmyynti` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `varasto`
--
ALTER TABLE `varasto`
  MODIFY `IDvarasto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
